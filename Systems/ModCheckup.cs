// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Common;
using Colossal.PSI.PdxSdk;
using Colossal.Serialization.Entities;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Game;
using Mod = SimpleModCheckerPlus.Mod;
using System.Collections.Generic;
using System.IO;
using System;
using Unity.Entities;
using PDX.SDK.Contracts.Service.Profile.Result;
using PDX.SDK.Contracts;
using Colossal.PSI.Environment;
using System.Linq;

namespace SimpleModChecker.Systems
{
    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        public static List<string> loadedMods = [];
        public static OptionsUISystem uISystem = new();
        //public static string LoggedInUserName { get; set; } = "";
        public static Dictionary<string, string> localMods = [];
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> codeMods = [];
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> packageMods = [];
        public static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> allMods = [];

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

        protected override void OnUpdate()
        {
        }

        private void CheckMod()
        {
            List<string> badDllList = ["FastMath"];

            try
            {
                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (!loadedMods.Contains(modName) && !modName.StartsWith("Colossal.") && !modName.StartsWith("0Harmony") && !modName.StartsWith("Newtonsoft.Json"))
                    {
                            loadedMods.Add(modName);
                    }

                    if (!modInfo.asset.path.Contains("Colossal Order/Cities Skylines II/.cache/Mods/mods_subscribed") && !modName.StartsWith("Colossal.") && !modName.StartsWith("0Harmony") && !modName.StartsWith("Newtonsoft.Json"))
                    {
                        //Mod.log.Info($"Found local mod {modInfo.asset.name} in {modInfo.asset.path}");
                        localMods.Add(modName, modInfo.asset.path);
                    }
                    if (badDllList.Contains(modName))
                    {
                        NotificationSystem.Push("starq-smc-mod-check-malware-detected",
                            title: "SMC+: Known Malware Detected",
                            text: "Contact any Cities: Skylines community ASAP.",
                            onClicked: () => {
                                uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                            });
                        Exception ex = new("Bad_DLL_Exception");
                        Mod.log.Error(ex, $"Known malwares are being loaded: {modName}. Close the game and contact Cities: Skylines Discord/Reddit or PDX Forum immediately.");
                    }
                }
            }
            catch (Exception ex) { Mod.log.Info(ex); }
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
                        SortedDictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> sortedDict = new(codeMods);
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
                        SortedDictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> sortedDict = new(packageMods);
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
                else {  version = $" u{mod.Version}"; }
            }
            else { version = $" v{mod.UserModVersion}"; }

            return $"• [{mod.Id}] <{mod.DisplayName.Replace("<", "(").Replace(">", ")")}>{version} — <{mod.Author}>{outDatedText}\r\n";
        }

        public static LocalizedString CodeModsText => LocalizedString.Id(LoadedList("CodeMods"));
        public static LocalizedString PackageModsText => LocalizedString.Id(LoadedList("PackageMods"));


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
                        if (extension == string.Empty) extension = "???";

                        if (extensionCounts.ContainsKey(extension))
                            extensionCounts[extension]++;
                        else
                            extensionCounts[extension] = 1;
                    }

                    string[] directories = Directory.GetDirectories(folderPath);
                    foreach (var directory in directories)
                    {
                        string dirName = new DirectoryInfo(directory).Name;
                        if (dirName.Equals(".cpatch", StringComparison.OrdinalIgnoreCase) ||
                            dirName.Equals(".metadata", StringComparison.OrdinalIgnoreCase))
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

            static void CategoriseMods(PDX.SDK.Contracts.Service.Mods.Models.Mod mod, Dictionary<string, int> extensionCounts)
            {
                if (extensionCounts.ContainsKey(".dll") && extensionCounts[".dll"] > 0 || extensionCounts.ContainsKey(".mjs") && extensionCounts[".mjs"] > 0 || extensionCounts.ContainsKey(".pdb") && extensionCounts[".pdb"] > 0 || extensionCounts.ContainsKey(".so") && extensionCounts[".so"] > 0 || extensionCounts.ContainsKey(".bundle") && extensionCounts[".bundle"] > 0)
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
            List<PDX.SDK.Contracts.Service.Mods.Models.Mod> mods = m_Manager.GetModsInActivePlayset().GetAwaiter().GetResult();

            foreach (var mod in mods)
            {
                try {
                    string folderPath = mod.LocalData.FolderAbsolutePath; 
                    Dictionary<string, int> extensionCounts = [];
                    ProcessFolder(folderPath, extensionCounts);
                    CategoriseMods(mod, extensionCounts);
                } catch (Exception exception) { Mod.log.Info(exception); };
            }
            Mod.log.Info(mods.Count + " subbed mods");
        }

        public void SendNotification(int code, int package)
        {
            uISystem = World.GetOrCreateSystemManaged<OptionsUISystem>();

            string modMessageKey = "";
            Dictionary<string, ILocElement> dict = new()
            {
                {"codeCount", LocalizedString.Value(code.ToString())},
                {"packageCount", LocalizedString.Value(package.ToString())},
            };

            if (package == 0)
            {
                modMessageKey = code > 1 ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]" : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]";
                dict.Remove("packageCount");
            }
            else if (package == 1)
            {
                modMessageKey = code > 1 ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackage]" : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackage]";
            }
            else
            {
                modMessageKey = code > 1 ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackages]" : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackages]";
            }

            NotificationSystem.Push("starq-smc-mod-check",
                titleId: "SimpleModCheckerPlus",
                text: new LocalizedString(modMessageKey, null, dict),
                onClicked: () => {
                    uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                });
        }

        public void RemoveNotification()
        {
            NotificationSystem.Pop("starq-smc-mod-check", delay: 1, text: "...");
        }
    }
}