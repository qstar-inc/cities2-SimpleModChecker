// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Colossal.IO.AssetDatabase.Internal;
using Colossal.Json;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Colossal.PSI.PdxSdk;
using Colossal.Serialization.Entities;
using Game;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Game.UI.Widgets;
using Newtonsoft.Json.Linq;
using PDX.SDK.Contracts;
using PDX.SDK.Contracts.Service.Mods.Models;
using Unity.Entities;

namespace SimpleModCheckerPlus.Systems
{
    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        public static List<string> loadedMods = new();
        public static OptionsUISystem uISystem = new();

        //public static string LoggedInUserName { get; set; } = "";
        public static Dictionary<string, string> localMods = new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> codeMods =
            new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> packageMods =
            new();
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> allMods = new();

        public static LocalizedString CleanupResultText => LocalizedString.Id(GetText());
        public static string Header = "Mod Cleanup Result will appear here.";
        public static string Progress = "";
        public static int ModCount = 0;
        public static string IssueList = "";
        public static int ProcesStatus = 0;

        public static string GetText()
        {
            if (ProcesStatus == 0)
            {
                return Header;
            }
            else if (ProcesStatus == 1)
            {
                return $"{Header}\r\n{Progress}\r\n{IssueList}";
            }
            else if (ProcesStatus == 2)
            {
                return $"{Header}\r\n{IssueList}";
            }
            else
            {
                return $"{Header}\r\n{IssueList}";
            }
        }

        public List<string> GetLoadedMods()
        {
            return loadedMods;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckMod();
            CheckModNew();
            if (Mod.Setting.ShowNotif)
            {
                SendNotification(codeMods.Count + localMods.Count, packageMods.Count);
            }
            Mod.log.Info($"\r\nCods mods loaded:\r\n{LoadedList("CodeMods").Trim()}\r\n");
            Mod.log.Info($"\r\nPackage mods loaded:\r\n{LoadedList("PackageMods").Trim()}\r\n");
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            if (mode.IsGameOrEditor())
            {
                Mod.Setting.IsInGameOrEditor = true;
                RemoveNotification();
            }
            else
            {
                Mod.Setting.IsInGameOrEditor = false;
                if (Mod.Setting.ShowNotif)
                {
                    SendNotification(codeMods.Count + localMods.Count, packageMods.Count);
                }
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
                            "Colossal Order/Cities Skylines II/.cache/Mods/mods_subscribed"
                        )
                        && !modName.StartsWith("Colossal.")
                        && !modName.StartsWith("0Harmony")
                        && !modName.StartsWith("Newtonsoft.Json")
                    )
                    {
                        //Mod.log.Info($"Found local mod {modInfo.asset.name} in {modInfo.asset.path}");
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
                        Mod.log.Error(
                            ex,
                            $"Known malwares are being loaded: {modName}. Close the game and contact Cities: Skylines Discord/Reddit or PDX Forum immediately."
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Mod.log.Info(ex);
            }
        }

        public static string LoadedList(string type)
        {
            string returnText = "";
            switch (type)
            {
                case "CodeMods":
                    returnText = $"{localMods.Count + codeMods.Count} Code Mods\r\n";
                    if (localMods.Count > 0)
                    {
                        SortedDictionary<string, string> sortedDict = new(localMods);
                        foreach (var mod in sortedDict)
                        {
                            returnText += $"• {mod.Key}\r\n";
                        }
                    }
                    if (codeMods.Count > 0)
                    {
                        SortedDictionary<
                            string,
                            PDX.SDK.Contracts.Service.Mods.Models.Mod
                        > sortedDict = new(codeMods);
                        foreach (var mod in sortedDict)
                        {
                            returnText += ReturnText(mod.Value);
                        }
                    }
                    break;
                case "PackageMods":
                    returnText = $"{packageMods.Count} Package Mods\r\n";
                    if (packageMods.Count > 0)
                    {
                        SortedDictionary<
                            string,
                            PDX.SDK.Contracts.Service.Mods.Models.Mod
                        > sortedDict = new(packageMods);
                        foreach (var mod in sortedDict)
                        {
                            returnText += ReturnText(mod.Value);
                        }
                    }
                    break;
                default:
                    break;
            }
            return returnText;
        }

        static string ReturnText(PDX.SDK.Contracts.Service.Mods.Models.Mod mod)
        {
            string outDatedText = "";
            if (mod.LatestVersion != mod.Version)
            {
                outDatedText = " <[OUTDATED]>";
            }

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
            {
                version = $" v{mod.UserModVersion}";
            }

            return $"• [{mod.Id}] <{mod.DisplayName.Replace("<", "(").Replace(">", ")")}>{version} — <{mod.Author}>{outDatedText}\r\n";
        }

        public static LocalizedString CodeModsText => LocalizedString.Id(LoadedList("CodeMods"));
        public static LocalizedString PackageModsText =>
            LocalizedString.Id(LoadedList("PackageMods"));

        public void CheckModNew()
        {
            static void ProcessFolder(string folderPath, Dictionary<string, int> extensionCounts)
            {
                try
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (var file in files)
                    {
                        string extension = Path.GetExtension(file)?.ToLower() ?? "???";
                        if (extension == string.Empty)
                            extension = "???";

                        if (extensionCounts.ContainsKey(extension))
                            extensionCounts[extension]++;
                        else
                            extensionCounts[extension] = 1;
                    }

                    string[] directories = Directory.GetDirectories(folderPath);
                    foreach (var directory in directories)
                    {
                        string dirName = new DirectoryInfo(directory).Name;
                        if (
                            dirName.Equals(".cpatch", StringComparison.OrdinalIgnoreCase)
                            || dirName.Equals(".metadata", StringComparison.OrdinalIgnoreCase)
                        )
                        {
                            continue;
                        }

                        ProcessFolder(directory, extensionCounts);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Mod.log.Info($"Access denied to {folderPath}");
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
                    codeMods.Add(mod.DisplayName, mod);
                    allMods.Add(mod.DisplayName, mod);
                }
                else
                {
                    packageMods.Add(mod.DisplayName, mod);
                    allMods.Add(mod.DisplayName, mod);
                }
            }

            PdxSdkPlatform m_Manager = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
            //List<PDX.SDK.Contracts.Service.Mods.Models.Mod> mods = m_Manager
            //    .GetModsInActivePlayset()
            //    .GetAwaiter()
            //    .GetResult();

            var context = (IContext)
                typeof(PdxSdkPlatform)
                    .GetField("m_SDKContext", BindingFlags.NonPublic | BindingFlags.Instance)!
                    .GetValue(m_Manager);
            var playsetResult = context.Mods.GetActivePlaysetEnabledMods().Result;
            PDX.SDK.Contracts.Service.Mods.Models.Mod[] modsResult = (
                !playsetResult.Success
                    ? new List<PDX.SDK.Contracts.Service.Mods.Models.Mod>()
                    : playsetResult.Mods.Where(m =>
                        !string.IsNullOrEmpty(m.LocalData.FolderAbsolutePath)
                    )
            ).ToArray();

            HashSet<PDX.SDK.Contracts.Service.Mods.Models.Mod> mods = new(modsResult);

            //HashSet<Colossal.PSI.Common.Mod> mods = m_Manager
            //    .GetModsInActivePlayset()
            //    .GetAwaiter()
            //    .GetResult();

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
                        Mod.log.Info(exception);
                    }
                }
                Mod.log.Info(mods.Count + " subbed mods");
            }
            else
            {
                Mod.log.Info("No playset active");
            }
        }

        public void SendNotification(int code, int package)
        {
            uISystem = World.GetOrCreateSystemManaged<OptionsUISystem>();

            string modMessageKey = "";
            Dictionary<string, ILocElement> dict = new()
            {
                { "codeCount", LocalizedString.Value(code.ToString()) },
                { "packageCount", LocalizedString.Value(package.ToString()) },
            };

            if (package == 0)
            {
                modMessageKey =
                    code > 1
                        ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]"
                        : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]";
                dict.Remove("packageCount");
            }
            else if (package == 1)
            {
                modMessageKey =
                    code > 1
                        ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackage]"
                        : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackage]";
            }
            else
            {
                modMessageKey =
                    code > 1
                        ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackages]"
                        : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackages]";
            }

            NotificationSystem.Push(
                "starq-smc-mod-check",
                titleId: "SimpleModCheckerPlus",
                text: new LocalizedString(modMessageKey, null, dict),
                onClicked: () =>
                {
                    uISystem.OpenPage(
                        "SimpleModChecker.SimpleModCheckerPlus.Mod",
                        "Setting.ModListTab",
                        false
                    );
                }
            );
        }

        public void RemoveNotification()
        {
            NotificationSystem.Pop("starq-smc-mod-check", delay: 1, text: "...");
        }

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

                var context = (IContext)
                    typeof(PdxSdkPlatform)
                        .GetField("m_SDKContext", BindingFlags.NonPublic | BindingFlags.Instance)!
                        .GetValue(m_Manager);
                var playsetResult = context.Mods.ListAllPlaysets().Result;
                if (playsetResult.Success)
                {
                    for (int i = 0; i < playsetResult.AllPlaysets.Count; i++)
                    {
                        Playset playset = playsetResult.AllPlaysets[i];
                        Progress += $"\nChecking Playset <{playset.PlaysetId}>: {playset.Name}";

                        var playsetModResult = context
                            .Mods.ListModsInPlayset(playset.PlaysetId, Int32.MaxValue)
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
                                    .Replace("/Mods/mods_subscribed/", "")
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
                                Mod.log.Info($"{playset.PlaysetId}, {id}_{ver}");
                            }
                            Progress += ".. Done";
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
                            Mod.log.Info(text);
                            Progress += $"\n{text}";
                            foreach (var playset in playsets)
                            {
                                var subscribeResult = context
                                    .Mods.Subscribe(match.Id, playset, $"{latest}")
                                    .Result;

                                Mod.log.Info(subscribeResult.Success);
                                if (subscribeResult.Success)
                                {
                                    Mod.log.Info(
                                        subscribeResult.ModsSubscribedStatus[0].Mod.Version
                                    );
                                    Progress += "... Fixed!";
                                    hasSubbed = true;
                                }
                            }
                        }
                    }
                }

                foreach (var mod in CurrentDownloadedModsFiltered)
                {
                    string text =
                        $"[{mod.Id}_{mod.Version}] {mod.DisplayName} is not present in any playsets.";
                    Mod.log.Info(text);
                    Progress += $"\n{text}";
                }

                Header = "Mod Cleanup Process has ended!";
                if (hasSubbed)
                {
                    Header += " Restart Required...";
                    Progress += "\nRestart Required...";
                    context.Mods.Sync(PDX.SDK.Contracts.Service.Mods.Enums.SyncDirection.Upstream);
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
                    EnvPath.kCacheDataPath + "/Mods/mods_subscribed",
                    "*",
                    SearchOption.TopDirectoryOnly
                )
                .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]));

            foreach (var subfolder in directories)
            {
                string modFolder = Path.GetFileName(subfolder);
                string[] modFolderParts = modFolder.Split('_');

                string modId = modFolderParts.Length == 2 ? modFolderParts[0] : "";
                string metadataFile = Path.Combine(subfolder, ".metadata", "metadata.json");
                string modName = modId;

                if (modFolderParts.Length == 2)
                {
                    try
                    {
                        var jsonContent = File.ReadAllText(metadataFile);
                        var jsonObject = JObject.Parse(jsonContent);
                        modName = jsonObject["DisplayName"]?.ToString() ?? modId;
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
    }
}
