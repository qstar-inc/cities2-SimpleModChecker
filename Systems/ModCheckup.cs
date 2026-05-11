using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Colossal.PSI.Common;
using Colossal.PSI.PdxSdk;
using Colossal.Serialization.Entities;
using Game;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Newtonsoft.Json.Linq;
using PDX.SDK.Contracts;
using PDX.SDK.Contracts.Service.Mods.Interfaces;
using StarQ.Shared.Extensions;
using Unity.Entities;

namespace SimpleModCheckerPlus.Systems
{
    public class LoadedModInfo
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string LatestVersion { get; set; }
        public string UserModVersion { get; set; }
        public ulong Size { get; set; }
        public bool Active { get; set; }
    }

    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        public static List<string> loadedMods = new();

        public static Dictionary<string, string> modLocationDict = new();
        public static OptionsUISystem uISystem = new();

        public static SortedDictionary<string, string> localMods = new();
        public static Dictionary<string, LoadedModInfo> codes = new();
        public static Dictionary<string, LoadedModInfo> packages = new();
        public static Dictionary<string, LoadedModInfo> allMods = new();

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

        private const string MetadataFolder = ".metadata";
        private const string CPatchFolder = ".cpatch";

        private static readonly Regex TrailingBracketRegex = new(
            @"\s*[\(\[\<].*?[\)\]\>]\s*$",
            RegexOptions.Compiled
        );
        public static readonly Regex ModFolderPattern = new(@"^\d+_\d+$");

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
            Colossal.Core.MainThreadDispatcher.RegisterUpdater(FirstRunMethod);
        }

        private static bool FirstMethodRan = false;

        private bool FirstRunMethod()
        {
            if (FirstMethodRan)
                return true;

            if (
                !GameManager.instance.modManager.isInitialized
                || GameManager.instance.gameMode != GameMode.MainMenu
                || GameManager.instance.state == GameManager.State.Loading
                || GameManager.instance.state == GameManager.State.Booting
            )
                return false;

            FirstMethodRan = true;
            Stopwatch stopwatch = new();
            stopwatch.Start();
            Initialize();
            stopwatch.Stop();
            LogHelper.SendLog(
                $"First initialization took {stopwatch.Elapsed.TotalSeconds} seconds"
            );
            Mod.InitBackup();
            return true;
        }

        public void Initialize()
        {
            if (!FirstMethodRan)
            {
                FirstRunMethod();
                return;
            }
            LogHelper.SendLog($"PDX Mods Locations: {string.Join(", ", Mod.PDXModsPaths)}");
            Mod.m_Setting.IsCustomChirpsOn = ModHelper.IsModActive("CustomChirps");
            loadedMods.Clear();
            localMods.Clear();
            codes.Clear();
            packages.Clear();
            allMods.Clear();

            CheckMod();
            CheckModNew();
            SendNotification(packages.Count > 0);

            string text1 =
                $"\nCods mods loaded:\n{LoadedList(ModTypes.CodeMods, forLog: true).Trim()}\n";
            string text2 =
                $"\nPackage mods loaded:\n{LoadedList(ModTypes.PackageMods, forLog: true).Trim()}\n";

            if (text1 + text2 == lastText)
                return;

            LogHelper.SendLog(text1 + text2);
            lastText = text1 + text2;
            CachedLists.Clear();
            Mod.m_Setting.ModLoadedVersion++;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            try
            {
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
            catch (Exception e)
            {
                LogHelper.SendLog(e, LogLevel.Error);
            }
        }

        protected override void OnUpdate() { }

        private void CheckMod()
        {
            List<string> badDllList = new() { "FastMath" };
            List<string> failed = new();

            try
            {
                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (
                        modName.StartsWith("Colossal.")
                        || modName.StartsWith("0Harmony")
                        || modName.StartsWith("Newtonsoft.Json")
                    )
                        continue;

                    if (modInfo.loadError != null)
                    {
                        failed.Add(
                            $"{modName} => {modInfo.loadError.Split("\n", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()}"
                        );
                        continue;
                    }
                    string normalizedFolder = Path.GetFullPath(
                            Path.GetDirectoryName(modInfo.asset.path)
                        )
                        .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                        .Replace("\\", "/");

                    if (!loadedMods.Contains(modName))
                    {
                        loadedMods.Add(modName);
                        modLocationDict[normalizedFolder] = modName;

                        //LogHelper.SendLog($"Adding {modName} from {normalizedFolder}");
                    }

                    if (
                        !Mod.PDXModsPaths.Any(p =>
                            normalizedFolder.StartsWith(p, StringComparison.OrdinalIgnoreCase)
                        )
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

                if (failed.Count > 0)
                    LogHelper.SendLog($"Mods failed to load:\n- {string.Join("\n- ", failed)}");
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

            (ModTypes type, SortOptions sort, bool isAsc) key = (type, sort, isAsc);

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
                    isAsc,
                    "code"
                ),
                ModTypes.PackageMods => BuildModList(
                    LocaleHelper.Translate(
                        $"{Mod.Id}.{(packages.Count > 1 ? "PackagePlural" : "PackageSingular")}"
                    ),
                    null,
                    packages,
                    sort,
                    forLog,
                    isAsc,
                    "package"
                ),
                _ => string.Empty,
            };
        }

        private static string BuildModList(
            string headerText,
            SortedDictionary<string, string> localMods,
            Dictionary<string, LoadedModInfo> mods,
            SortOptions sort,
            bool forLog,
            bool isAsc,
            string codeOrPackage
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
                    builder.Append(ReturnText(mod.Value, codeOrPackage, forLog));
            }

            return builder.ToString();
        }

        private static IEnumerable<KeyValuePair<string, LoadedModInfo>> SortMods(
            Dictionary<string, LoadedModInfo> mods,
            SortOptions sort,
            bool isAsc
        )
        {
            return sort switch
            {
                SortOptions.Size => isAsc
                    ? mods.OrderBy(kv => kv.Value.Size).ThenBy(kv => kv.Value.Active)
                    : mods.OrderByDescending(kv => kv.Value.Size).ThenBy(kv => kv.Value.Active),

                SortOptions.Author => isAsc
                    ? mods.OrderBy(kv => kv.Value.Author)
                        .ThenBy(kv => kv.Value.Active)
                        .ThenBy(kv => kv.Value.DisplayName)
                    : mods.OrderByDescending(kv => kv.Value.Author)
                        .ThenBy(kv => kv.Value.Active)
                        .ThenByDescending(kv => kv.Value.DisplayName),

                _ => isAsc
                    ? mods.OrderBy(kv => kv.Value.Active).ThenBy(kv => kv.Key)
                    : mods.OrderBy(kv => kv.Value.Active).ThenByDescending(kv => kv.Key),
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

        static string ReturnText(LoadedModInfo mod, string codeOrPackage, bool forLog = false)
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

            string inactive =
                codeOrPackage == "package" || mod.Active ? "" : $" {prefix}[FAILED]{suffix}";

            string displayName = TrailingBracketRegex.Replace(mod.DisplayName ?? "", "");

            return $"• [{mod.Id}] {prefix}{displayName}{suffix}{version} — {prefix}{mod.Author}{suffix}{sizeText}{outDatedText}{inactive}\n";
        }

        public static LocalizedString CodeModsText =>
            LocalizedString.Id(LoadedList(ModTypes.CodeMods, Mod.m_Setting.TextSort));
        public static LocalizedString PackageModsText =>
            LocalizedString.Id(LoadedList(ModTypes.PackageMods, Mod.m_Setting.TextSort));

        public void CheckModNew()
        {
            void ProcessFolder(string folderPath, Dictionary<string, int> extensionCounts)
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

            void CategoriseMods(LoadedModInfo mod, Dictionary<string, int> extensionCounts)
            {
                if (
                    extensionCounts.ContainsKey(".dll") && extensionCounts[".dll"] > 0
                    || extensionCounts.ContainsKey(".mjs") && extensionCounts[".mjs"] > 0
                    || extensionCounts.ContainsKey(".pdb") && extensionCounts[".pdb"] > 0
                    || extensionCounts.ContainsKey(".so") && extensionCounts[".so"] > 0
                    || extensionCounts.ContainsKey(".bundle") && extensionCounts[".bundle"] > 0
                )
                {
                    codes[mod.DisplayName] = mod;
                    allMods[mod.DisplayName] = mod;
                }
                else
                {
                    packages[mod.DisplayName] = mod;
                    allMods[mod.DisplayName] = mod;
                }
            }

            IContext context = (IContext)SDKContextField.GetValue(m_Manager);

            PDX.SDK.Contracts.Service.Mods.Results.IListModsInPlaysetResult playsetResult = context
                .Mods.GetActivePlaysetEnabledMods()
                .Result;
            ILocalPlaysetMod[] modsResult = !playsetResult.Success
                ? Array.Empty<ILocalPlaysetMod>()
                : (playsetResult.Mods ?? Enumerable.Empty<ILocalPlaysetMod>())
                    .Where(m => !string.IsNullOrEmpty(m?.LocalData?.FolderAbsolutePath))
                    .ToArray();

            HashSet<ILocalPlaysetMod> mods = new(modsResult);

            if (LogHelper.CheckNull(mods, $"Playset mod data"))
                return;

            foreach (ILocalPlaysetMod modX in mods)
            {
                try
                {
                    PDX.SDK.Contracts.Service.Mods.Results.IModDetailsResult data = context
                        .Mods.GetLocalModDetails(modX.Id)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
                    IModDetails mod = data.Mod;

                    string folderPath = mod?.LocalData?.FolderAbsolutePath;
                    Dictionary<string, int> extensionCounts = new();

                    if (LogHelper.CheckNull(mod, $"Mod {mod.Id}"))
                        continue;
                    if (LogHelper.CheckNull(mod.LocalData, $"Mod {mod.Id} LocalData"))
                        continue;
                    if (
                        LogHelper.CheckNull(
                            mod.LocalData.FolderAbsolutePath,
                            $"Mod {mod.Id} LocalData.FolderAbsolutePath"
                        )
                    )
                        continue;

                    LoadedModInfo lm = new()
                    {
                        Id = mod.Id,
                        DisplayName = mod.DisplayName,
                        Author = mod.Author,
                        Version = mod.Version,
                        LatestVersion = mod.LatestVersion,
                        UserModVersion = mod.UserModVersion,
                        Size = mod.Size,
                        Active = true,
                    };

                    try
                    {
                        string normalizedFolder = Path.GetFullPath(folderPath)
                            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                            .Replace("\\", "/");

                        //LogHelper.SendLog(normalizedFolder);

                        if (!modLocationDict.TryGetValue(normalizedFolder, out string existingMod))
                            lm.Active = false;
                    }
                    catch (Exception exception)
                    {
                        LogHelper.SendLog(
                            $"Error while running ProcessFolder for {lm.DisplayName ?? ""} ({lm.Id ?? ""}) for {extensionCounts} extensions on folderPath"
                        );
                        LogHelper.SendLog(exception);
                        continue;
                    }

                    //LogHelper.SendLog(lm.ToJSONString());
                    try
                    {
                        ProcessFolder(folderPath, extensionCounts);
                    }
                    catch (Exception exception)
                    {
                        LogHelper.SendLog(
                            $"Error while running ProcessFolder for {lm.DisplayName ?? ""} ({lm.Id ?? ""}) for {extensionCounts} extensions on folderPath"
                        );
                        LogHelper.SendLog(exception);
                        continue;
                    }
                    try
                    {
                        CategoriseMods(lm, extensionCounts);
                    }
                    catch (Exception exception)
                    {
                        LogHelper.SendLog(
                            $"Error while running CategoriseMods for {lm.DisplayName ?? ""} ({lm.Id ?? ""}) for {extensionCounts} extensions"
                        );
                        LogHelper.SendLog(exception);
                        continue;
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.SendLog(exception);
                    continue;
                }
            }
            LogHelper.SendLog(mods.Count + " subbed mods");
            FirstRun = false;
        }

        public void SendNotification(bool hasPackage)
        {
            if (Mod.m_Setting.ShowNotif)
            {
                try
                {
                    uISystem =
                        World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<OptionsUISystem>();

                    string modMessageKey = "ActiveMod";

                    if (hasPackage)
                        modMessageKey += "AndPackage";

                    List<string> inactives = new();
                    foreach (var mod in codes.Values)
                    {
                        if (!mod.Active)
                            inactives.Add(mod.DisplayName);
                    }

                    if (inactives.Count > 0)
                    {
                        NotificationSystem.Pop("starq-smc-mod-warn");
                        NotificationSystem.Push(
                            "starq-smc-mod-warn",
                            progressState: ProgressState.Failed,
                            title: new LocalizedString(
                                $"{Mod.Id}.FailedMod",
                                null,
                                new Dictionary<string, ILocElement>()
                                {
                                    { "SMC+", new LocalizedString($"{Mod.Id}.SMC+", "SMC+", null) },
                                    { "FailedCount", new LocalizedNumber<int>(inactives.Count) },
                                    {
                                        "FailedCountSuffix",
                                        new LocalizedString(
                                            inactives.Count > 1
                                                ? $"{Mod.Id}.CodePlural"
                                                : $"{Mod.Id}.CodeSingular",
                                            null,
                                            null
                                        )
                                    },
                                }
                            ),
                            text: $"{string.Join(", ", inactives.OrderBy(x => x))}",
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
                    else
                    {
                        NotificationSystem.Pop("starq-smc-mod-warn");
                    }

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

        public class DownloadedModData
        {
            public string Id;
            public int Version;
            public string DisplayName;
        }

        public static List<DownloadedModData> GetCurrentDownloadedMods()
        {
            var list = new List<DownloadedModData>();

            var directories = Mod
                .PDXModsPaths.Where(Directory.Exists)
                .SelectMany(path =>
                    Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly)
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
                        Id = modId,
                        Version = int.Parse(modFolderParts[1]),
                        DisplayName = modName,
                    }
                );
            }

            return list;
        }
    }
}
