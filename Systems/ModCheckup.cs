using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Colossal.PSI.PdxSdk;
using Colossal.Serialization.Entities;
using Game;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Newtonsoft.Json.Linq;
using PDX.SDK.Contracts;
using PDX.SDK.Contracts.Service.Mods.Models;
using StarQ.Shared.Extensions;
using Unity.Entities;
using UnityEngine;

namespace SimpleModCheckerPlus.Systems
{
    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        public static List<string> loadedMods = new();
        public static OptionsUISystem uISystem = new();

        //public static string LoggedInUserName { get; set; } = "";
        public static SortedDictionary<string, string> localMods = new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> codes = new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> packages =
            new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> allMods = new();

        public static string lastText = "";
        public static LocalizedString CleanupResultText => LocalizedString.Id(GetText());
        public static string Header = "Mod Cleanup Result will appear here.";
        public static string Progress = "";
        public static int ModCount = 0;
        public static string IssueList = "";
        public static int ProcesStatus = 0;
        private PdxSdkPlatform m_Manager;

        private static readonly FieldInfo SDKContextField = typeof(PdxSdkPlatform).GetField(
            "m_SDKContext",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        private const string ModsSubscribedPath = "/Mods/mods_subscribed/";
        private const string MetadataFolder = ".metadata";
        private const string CPatchFolder = ".cpatch";

        private static readonly Regex TrailingBracketRegex = new(
            @"\s*[\(\[\<].*?[\)\]\>]\s*$",
            RegexOptions.Compiled
        );

        private static readonly object _extLock = new();

        public static string GetText()
        {
            return ProcesStatus switch
            {
                0 => Header,
                1 => $"{Header}\n{Progress}\n{IssueList}",
                2 => $"{Header}\n{IssueList}",
                _ => $"{Header}\n{IssueList}",
            };
        }

        public List<string> GetLoadedMods() => loadedMods;

        public enum ModTypes
        {
            CodeMods,
            PackageMods,
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            m_Manager = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
            ModHelper.AddAfterActivePlaysetOrModStatusChanged(Initialize);
            Initialize();
        }

        public void Initialize()
        {
            Mod.m_Setting.IsCustomChirpsOn = ModHelper.IsModActive("CustomChirps");
            loadedMods.Clear();
            localMods.Clear();
            codes.Clear();
            packages.Clear();
            allMods.Clear();

            CheckMod();
            CheckModNew();
            SendNotification(packages.Count > 0);
            //if (Mod.m_Setting.AutoCleanUpOldVersions)
            //    CleanUpOldVersions();

            string text1 =
                $"\nCods mods loaded:\n{LoadedList(ModTypes.CodeMods, forLog: true).Trim()}\n";
            string text2 =
                $"\nPackage mods loaded:\n{LoadedList(ModTypes.PackageMods, forLog: true).Trim()}\n";

            if (text1 + text2 == lastText)
                return;

            LogHelper.SendLog(text1 + text2);
            lastText = text1 + text2;
            Mod.m_Setting.ModLoadedVersion++;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            if (mode.IsGameOrEditor())
            {
                Mod.m_Setting.IsInGameOrEditor = true;
                RemoveNotification();
            }
            else
            {
                Mod.m_Setting.IsInGameOrEditor = false;
                SendNotification(packages.Count > 0);
            }
        }

        protected override void OnUpdate() { }

        private void CheckMod()
        {
            List<string> badDllList = new() { "FastMath" };

            try
            {
                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (
                        !loadedMods.Contains(modName)
                        && !modName.StartsWith("Colossal.")
                        && !modName.StartsWith("0Harmony")
                        && !modName.StartsWith("Newtonsoft.Json")
                    )
                    {
                        loadedMods.Add(modName);
                    }

                    if (
                        !modInfo.asset.path.Contains(
                            $"{EnvPath.kCacheDataPath}{ModsSubscribedPath}"
                        )
                        && !modName.StartsWith("Colossal.")
                        && !modName.StartsWith("0Harmony")
                        && !modName.StartsWith("Newtonsoft.Json")
                    )
                    {
                        //LogHelper.SendLog($"Found local mod {modInfo.asset.name} in {modInfo.asset.path}");
                        if (localMods.ContainsKey(modName))
                            LogHelper.SendLog($"{modName} is loaded multiple times!");
                        else
                            localMods.Add(modName, modInfo.asset.path);
                    }
                    if (badDllList.Contains(modName))
                    {
                        NotificationSystem.Push(
                            "starq-smc-mod-check-malware-detected",
                            title: "SMC+: Known Malware Detected",
                            text: "Contact any Cities: Skylines community ASAP.",
                            onClicked: () =>
                            {
                                uISystem.OpenPage(
                                    "SimpleModChecker.SimpleModCheckerPlus.Mod",
                                    "Setting.ModListTab",
                                    false
                                );
                            }
                        );
                        Exception ex = new("Bad_DLL_Exception");
                        LogHelper.SendLog(
                            $"{ex} Known malwares are being loaded: {modName}. Close the game and contact Cities: Skylines Discord/Reddit or PDX Forum immediately.",
                            LogLevel.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
        }

        public enum SortOptions
        {
            Name,
            Size,
            Author,
        }

        private static readonly Dictionary<(ModTypes, SortOptions, bool), string> CachedLists =
            new();

        private static bool FirstRun = true;

        public static string LoadedList(
            ModTypes type,
            SortOptions sort = SortOptions.Name,
            bool forLog = false
        )
        {
            if (FirstRun)
                return "";
            bool isAsc = Mod.m_Setting.TextSortAscending;

            var key = (type, sort, isAsc);

            if (!FirstRun && CachedLists.TryGetValue(key, out var cached))
                return cached;

            var result = BuildLoadedList(type, sort, forLog, isAsc);
            if (!forLog)
                CachedLists[key] = result;
            return result;
        }

        public static string BuildLoadedList(
            ModTypes type,
            SortOptions sort,
            bool forLog,
            bool isAsc
        )
        {
            return type switch
            {
                ModTypes.CodeMods => BuildModList(
                    LocaleHelper.Translate(
                        $"{Mod.Id}.{(localMods.Count + codes.Count > 1 ? "CodePlural" : "CodeSingular")}"
                    ),
                    localMods,
                    codes,
                    sort,
                    forLog,
                    isAsc
                ),
                ModTypes.PackageMods => BuildModList(
                    LocaleHelper.Translate(
                        $"{Mod.Id}.{(packages.Count > 1 ? "PackagePlural" : "PackageSingular")}"
                    ),
                    null,
                    packages,
                    sort,
                    forLog,
                    isAsc
                ),
                _ => string.Empty,
            };
        }

        private static string BuildModList(
            string headerText,
            SortedDictionary<string, string> localMods,
            Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> mods,
            SortOptions sort,
            bool forLog,
            bool isAsc
        )
        {
            var builder = new StringBuilder();
            int totalCount = (localMods?.Count ?? 0) + (mods?.Count ?? 0);

            builder.AppendLine($"{totalCount} {headerText}");

            if (localMods?.Count > 0)
            {
                foreach (var mod in localMods.OrderBy(kv => kv.Key))
                    builder.AppendLine($"• {mod.Key}");
            }

            if (mods?.Count > 0)
            {
                foreach (var mod in SortMods(mods, sort, isAsc))
                    builder.Append(ReturnText(mod.Value, forLog));
            }

            return builder.ToString();
        }

        private static IEnumerable<
            KeyValuePair<string, PDX.SDK.Contracts.Service.Mods.Models.Mod>
        > SortMods(
            Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> mods,
            SortOptions sort,
            bool isAsc
        )
        {
            return sort switch
            {
                SortOptions.Size => isAsc
                    ? mods.OrderBy(kv => kv.Value.Size)
                    : mods.OrderByDescending(kv => kv.Value.Size),

                SortOptions.Author => isAsc
                    ? mods.OrderBy(kv => kv.Value.Author).ThenBy(kv => kv.Value.DisplayName)
                    : mods.OrderByDescending(kv => kv.Value.Author)
                        .ThenByDescending(kv => kv.Value.DisplayName),

                _ => isAsc ? mods.OrderBy(kv => kv.Key) : mods.OrderByDescending(kv => kv.Key),
            };
        }

        static string FormatSize(ulong bytes)
        {
            double sizeInKB = bytes / 1024.0;
            double sizeInMB = sizeInKB / 1024.0;
            double sizeInGB = sizeInMB / 1024.0;

            if (sizeInGB >= 1)
                return $"{sizeInGB:0.##} GB";
            else if (sizeInMB >= 1)
                return $"{sizeInMB:0.##} MB";
            else
                return $"{sizeInKB:0.##} KB";
        }

        static string ReturnText(PDX.SDK.Contracts.Service.Mods.Models.Mod mod, bool forLog = false)
        {
            if (mod == null)
                return string.Empty;

            string prefix = string.Empty;
            string suffix = string.Empty;
            string sizeText = string.Empty;

            if (!forLog)
            {
                prefix = "<";
                suffix = ">";
                sizeText = $" — {FormatSize(mod.Size)}" ?? "";
            }

            string outDatedText = "";
            if (mod.LatestVersion != mod.Version)
                outDatedText = $" {prefix}[OUTDATED]{suffix}";

            string version;
            if (mod.UserModVersion == "" || mod.UserModVersion == null)
            {
                if (mod.Version == "" || mod.Version == null)
                {
                    version = "";
                }
                else
                {
                    version = $" u{mod.Version}";
                }
            }
            else
                version = $" v{mod.UserModVersion}";

            string displayName = TrailingBracketRegex.Replace(mod.DisplayName ?? "", "");

            return $"• [{mod.Id}] {prefix}{displayName}{suffix}{version} — {prefix}{mod.Author}{suffix}{sizeText}{outDatedText}\n";
        }

        public static LocalizedString CodeModsText =>
            LocalizedString.Id(LoadedList(ModTypes.CodeMods, Mod.m_Setting.TextSort));
        public static LocalizedString PackageModsText =>
            LocalizedString.Id(LoadedList(ModTypes.PackageMods, Mod.m_Setting.TextSort));

        public void CheckModNew()
        {
            static void ProcessFolder(string folderPath, Dictionary<string, int> extensionCounts)
            {
                try
                {
                    Parallel.ForEach(
                        Directory.EnumerateFiles(folderPath),
                        file =>
                        {
                            string extension = Path.GetExtension(file)?.ToLowerInvariant();
                            if (string.IsNullOrEmpty(extension))
                                extension = "???";

                            lock (_extLock)
                            {
                                extensionCounts.TryGetValue(extension, out int count);
                                extensionCounts[extension] = count + 1;
                            }
                        }
                    );

                    Parallel.ForEach(
                        Directory.EnumerateDirectories(folderPath),
                        dir =>
                        {
                            string dirName = Path.GetFileName(dir);
                            if (
                                !dirName.Equals(CPatchFolder, StringComparison.OrdinalIgnoreCase)
                                && !dirName.Equals(
                                    MetadataFolder,
                                    StringComparison.OrdinalIgnoreCase
                                )
                            )
                                ProcessFolder(dir, extensionCounts);
                        }
                    );
                }
                catch (UnauthorizedAccessException)
                {
                    LogHelper.SendLog($"Access denied to {folderPath}");
                }
            }

            static void CategoriseMods(
                PDX.SDK.Contracts.Service.Mods.Models.Mod mod,
                Dictionary<string, int> extensionCounts
            )
            {
                if (
                    extensionCounts.ContainsKey(".dll") && extensionCounts[".dll"] > 0
                    || extensionCounts.ContainsKey(".mjs") && extensionCounts[".mjs"] > 0
                    || extensionCounts.ContainsKey(".pdb") && extensionCounts[".pdb"] > 0
                    || extensionCounts.ContainsKey(".so") && extensionCounts[".so"] > 0
                    || extensionCounts.ContainsKey(".bundle") && extensionCounts[".bundle"] > 0
                )
                {
                    codes.Add(mod.DisplayName, mod);
                    allMods.Add(mod.DisplayName, mod);
                }
                else
                {
                    packages.Add(mod.DisplayName, mod);
                    allMods.Add(mod.DisplayName, mod);
                }
            }

            var context = (IContext)SDKContextField.GetValue(m_Manager);
            var playsetResult = context.Mods.GetActivePlaysetEnabledMods().Result;
            PDX.SDK.Contracts.Service.Mods.Models.Mod[] modsResult = (
                !playsetResult.Success
                    ? new List<PDX.SDK.Contracts.Service.Mods.Models.Mod>()
                    : playsetResult.Mods.Where(m =>
                        !string.IsNullOrEmpty(m.LocalData.FolderAbsolutePath)
                    )
            ).ToArray();

            HashSet<PDX.SDK.Contracts.Service.Mods.Models.Mod> mods = new(modsResult);

            if (mods != null)
            {
                foreach (var mod in mods)
                {
                    try
                    {
                        string folderPath = mod.LocalData.FolderAbsolutePath;
                        Dictionary<string, int> extensionCounts = new();
                        ProcessFolder(folderPath, extensionCounts);
                        CategoriseMods(mod, extensionCounts);
                    }
                    catch (Exception exception)
                    {
                        LogHelper.SendLog(exception);
                    }
                }
                LogHelper.SendLog(mods.Count + " subbed mods");
                FirstRun = false;
            }
            else
            {
                LogHelper.SendLog("No playset active");
            }
        }

        public void SendNotification(bool hasPackage)
        {
            if (Mod.m_Setting.ShowNotif)
            {
                try
                {
                    uISystem =
                        World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<OptionsUISystem>();

                    string modMessageKey = "LoadedMod";

                    if (hasPackage)
                        modMessageKey = "LoadedModAndPackage";

                    NotificationSystem.Push(
                        "starq-smc-mod-check",
                        title: Mod.Name,
                        text: new LocalizedString(
                            $"{Mod.Id}.{modMessageKey}",
                            null,
                            new Dictionary<string, ILocElement>()
                            {
                                {
                                    "CodeCount",
                                    new LocalizedNumber<int>(codes.Count + localMods.Count)
                                },
                                { "PackageCount", new LocalizedNumber<int>(packages.Count) },
                            }
                        ),
                        onClicked: () =>
                        {
                            uISystem.OpenPage(
                                $"{Mod.Id}.{Mod.Id}.Mod",
                                "Setting.ModListTab",
                                false
                            );
                        }
                    );
                }
                catch (Exception exception)
                {
                    NotificationSystem.Push(
                        "starq-smc-mod-check-failed",
                        title: Mod.Name,
                        text: LocalizedString.Id($"SMC Failed to load. Click here to retry..."),
                        progressState: ProgressState.Failed,
                        onClicked: () => SendNotification(hasPackage)
                    );
                    LogHelper.SendLog(exception);
                }
            }
        }

        public void RemoveNotification() =>
            NotificationSystem.Pop("starq-smc-mod-check", delay: 1, text: "...");

        public static void CleanUpOldVersions()
        {
            Header = $"Mod Cleanup Process is running...";
            ProcesStatus = 1;
            Progress = "";

            PdxSdkPlatform m_Manager = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
            if (m_Manager != null)
            {
                Dictionary<int, SortedSet<int>> modIdToVersions = new();
                Dictionary<(int modId, int version), HashSet<int>> modVersionToPlaysets = new();

                var context = (IContext)SDKContextField.GetValue(m_Manager);
                var playsetResult = context.Mods.ListAllPlaysets().Result;
                if (playsetResult.Success)
                {
                    for (int i = 0; i < playsetResult.AllPlaysets.Count; i++)
                    {
                        Playset playset = playsetResult.AllPlaysets[i];
                        Progress += $"\nChecking Playset <{playset.PlaysetId}>: {playset.Name}";

                        var playsetModResult = context
                            .Mods.ListModsInPlayset(playset.PlaysetId, int.MaxValue)
                            .Result;
                        if (playsetModResult.Success)
                        {
                            Progress += ".";
                            for (int j = 0; j < playsetModResult.Mods.Count; j++)
                            {
                                var mod = playsetModResult.Mods[j];

                                string[] modFolderParts = mod
                                    .LocalData.FolderAbsolutePath.Replace(
                                        EnvPath.kCacheDataPath,
                                        ""
                                    )
                                    .Replace("\\", "/")
                                    .Replace(ModsSubscribedPath, "")
                                    .Split('_');
                                int id = int.Parse(modFolderParts[0]);
                                int ver = int.Parse(modFolderParts[1]);
                                if (!modIdToVersions.TryGetValue(id, out var versions))
                                    modIdToVersions[id] = versions = new SortedSet<int>();
                                versions.Add(ver);
                                var key = (id, ver);
                                if (!modVersionToPlaysets.TryGetValue(key, out var playsets))
                                    modVersionToPlaysets[key] = playsets = new HashSet<int>();
                                playsets.Add(playset.PlaysetId);
                                //LogHelper.SendLog($"{playset.PlaysetId}, {id}_{ver}");
                            }
                            Progress += ".. **Done**";
                        }
                    }
                }

                Progress += "\n ------------------------";

                List<DownloadedModData> CurrentDownloadedMods = GetCurrentDownloadedMods();
                List<DownloadedModData> CurrentDownloadedModsFiltered = new();
                bool hasSubbed = false;

                foreach (var kvp in modIdToVersions)
                {
                    int modId = kvp.Key;
                    var versions = kvp.Value;

                    if (versions.Count <= 1)
                    {
                        continue;
                    }

                    int latest = versions.Max();

                    foreach (var version in versions)
                    {
                        var match = CurrentDownloadedMods.FirstOrDefault(m =>
                            m.Id == modId && m.Version == version
                        );
                        if (match == null)
                            CurrentDownloadedModsFiltered.Add(match);

                        var playsets = modVersionToPlaysets[(modId, version)];
                        if (version < latest)
                        {
                            string text =
                                $"[{match.Id}_{match.Version}] {match.DisplayName} is outdated in playsets: {string.Join(", ", playsets)} (latest: {latest})";
                            LogHelper.SendLog(text);
                            Progress += $"\n{text}";
                            foreach (var playset in playsets)
                            {
                                var subscribeResult = context
                                    .Mods.Subscribe(match.Id, playset, $"{latest}")
                                    .Result;

                                if (subscribeResult.Success)
                                {
                                    LogHelper.SendLog(
                                        $"Resub successful: {match.Id} ({subscribeResult.ModsSubscribedStatus[0].Mod.Version})"
                                    );
                                    Progress += "... **Fixed!**";
                                    hasSubbed = true;
                                }
                                else
                                {
                                    LogHelper.SendLog(
                                        $"Resub failed: {match.Id} ({subscribeResult.ModsSubscribedStatus[0].Mod.Version})"
                                    );
                                    Progress += "... **Failed!**";
                                }
                            }
                        }
                    }
                }

                foreach (var mod in CurrentDownloadedModsFiltered)
                {
                    string text =
                        $"[{mod.Id}_{mod.Version}] {mod.DisplayName} is not present in any playsets.";
                    LogHelper.SendLog(text);
                    Progress += $"\n{text}";
                }

                Header = "Mod Cleanup Process has ended!";
                if (hasSubbed)
                {
                    Header += " **Restart Required...**";
                    Progress += "\n**Restart Required...**";
                    context.Mods.Sync(PDX.SDK.Contracts.Service.Mods.Enums.SyncDirection.Upstream);

                    string notifPrefix = $"{Mod.Id}.Cleanup";
                    NotificationSystem.Push(
                        "starq-smc-cleanup-restart",
                        title: new LocalizedString($"{notifPrefix}.Title", null, null),
                        text: LocalizedString.Id($"{notifPrefix}.Desc"),
                        onClicked: () =>
                        {
                            NotificationSystem.Pop("starq-smc-coc-restart");
                            Application.Quit(0);
                        }
                    );
                }
                Progress += "\nDone";
            }
        }

        public class DownloadedModData
        {
            public int Id;
            public int Version;
            public string DisplayName;
        }

        public static List<DownloadedModData> GetCurrentDownloadedMods()
        {
            var list = new List<DownloadedModData>();

            var directories = Directory
                .GetDirectories(
                    EnvPath.kCacheDataPath + ModsSubscribedPath,
                    "*",
                    SearchOption.TopDirectoryOnly
                )
                .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]));

            foreach (var subfolder in directories)
            {
                string modFolder = Path.GetFileName(subfolder);
                string[] modFolderParts = modFolder.Split('_');

                string modId = modFolderParts.Length == 2 ? modFolderParts[0] : "";
                string metadataFile = Path.Combine(subfolder, MetadataFolder, "metadata.json");
                string modName = modId;

                if (modFolderParts.Length == 2)
                {
                    try
                    {
                        var jsonContent = File.ReadAllText(metadataFile);
                        var jsonObject = JObject.Parse(jsonContent);
                        modName =
                            jsonObject["DisplayName"]?.ToString()
                            ?? jsonObject["displayName"]?.ToString()
                            ?? modId;
                    }
                    catch (Exception) { }
                }

                list.Add(
                    new DownloadedModData
                    {
                        Id = int.Parse(modId),
                        Version = int.Parse(modFolderParts[1]),
                        DisplayName = modName,
                    }
                );
            }

            return list;
        }

        public static List<string> backupsToCheck = new();

        public static void RemoveBackupCID()
        {
            int RemovedBackupCIDs = 0;
            int SkippedBackupCIDs = 0;
            try
            {
                string rootFolder = EnvPath.kCacheDataPath + ModsSubscribedPath;
                if (!Directory.Exists(rootFolder))
                {
                    return;
                }

                foreach (
                    var subfolder in Directory
                        .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
                        .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]))
                )
                {
                    string modFolder = Path.GetFileName(subfolder);
                    string metadataFile = Path.Combine(subfolder, MetadataFolder, "metadata.json");

                    string[] modFolderParts = modFolder.Split('_');
                    if (modFolderParts.Length != 2)
                    {
                        continue;
                    }

                    if (subfolder != null)
                    {
                        try
                        {
                            CheckForBackupCID(subfolder);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog(
                                $"Error verifying files in '{subfolder}': {ex.Message}"
                            );
                        }
                    }
                }

                foreach (var filePath in backupsToCheck)
                {
                    string subfolder =
                        $"{EnvPath.kCacheDataPath}{ModsSubscribedPath}{filePath.Replace(EnvPath.kCacheDataPath, "").Replace("\\", "/").Replace(ModsSubscribedPath, "").Split('/')[0]}";

                    string relativePath = ModVerifier
                        .GetRelativePath(subfolder, filePath)
                        .Replace("/", "\\");
                    string manifestPath = ModVerifier.FindManifestFile(subfolder);
                    if (string.IsNullOrEmpty(manifestPath))
                    {
                        LogHelper.SendLog($"No manifestPath found for subfolder: {subfolder}");
                        continue;
                    }

                    Dictionary<string, string> manifestData;

                    try
                    {
                        manifestData = ModVerifier.ReadManifestFile(manifestPath);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog(
                            $"Error reading manifest at '{manifestPath}': {ex.Message}"
                        );
                        continue;
                    }

                    if (!manifestData.ContainsKey(relativePath))
                    {
                        File.Delete(filePath);
                        RemovedBackupCIDs++;
                        LogHelper.SendLog($"Deleted '{relativePath}'.");
                    }
                    else
                    {
                        SkippedBackupCIDs++;
                    }
                }

                LogHelper.SendLog(
                    $"Backup CIDs: Removed {RemovedBackupCIDs}; Ignored {SkippedBackupCIDs}"
                );
                Mod.m_Setting.DeletedBackupCIDs = true;
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex.ToString());
            }
        }

        private static void CheckForBackupCID(string subfolder)
        {
            if (!Directory.Exists(subfolder))
                return;

            foreach (
                var filePath in Directory
                    .EnumerateFiles(subfolder, ".cid.backup", SearchOption.AllDirectories)
                    .Where(file => !file.Contains(MetadataFolder) && !file.Contains(CPatchFolder))
            )
                backupsToCheck.Add(filePath);
        }
    }
}
