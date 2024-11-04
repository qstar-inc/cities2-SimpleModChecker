// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Colossal.PSI.PdxSdk;
using Colossal.Serialization.Entities;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Game;
using Mod = SimpleModCheckerPlus.Mod;
using PDX.SDK.Contracts.Service.Profile.Result;
using PDX.SDK.Contracts;
using static SimpleModChecker.Systems.ModsWithIssues;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using static Colossal.AssetPipeline.Importers.ModelImporter;

namespace SimpleModChecker.Systems
{

    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        private int count;
        public static List<string> loadedMods = [];

        public static Dictionary<string, ModInfo> LoadedModsInDatabase = [];
        public static Dictionary<string, ModInfo> LoadedModsNotInDatabase = [];
        public static Dictionary<string, ModWithIssueInfo> LoadedModsWithIssue = [];

        public static OptionsUISystem uISystem = new();
        public static string LoadedModsList { get; set; } = "";
        public static string LoadedModsListWithIssue { get; set; } = "";
        public static string LoggedInUserName { get; set; } = "";

        public static LocalizedString LoadedModsListLocalized()
        {
            return LocalizedString.Id(LoadedModsList);
        }
        public static LocalizedString LoadedModsListWithIssueLocalized()
        {
            return LocalizedString.Id(LoadedModsListWithIssue);
        }

        public List<string> GetLoadedMods()
        {
            return loadedMods;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckMod();
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            if (mode.IsGameOrEditor())
            {
                RemoveNotification();
            }
            else
            {
                if (Mod.Setting.ShowNotif)
                {
                    SendNotification(count);
                }
            }
            ProcessMods();
            ProcessModsWithIssue();
        }

        public void ProcessMods()
        {
            if (Mod.Setting.ShowNotif)
            {
                SendNotification(count);
            }
            List<ModInfo> sortedMods1 = ModInfoProcessor.SortByModName(LoadedModsInDatabase);
            List<ModInfo> sortedMods2 = ModInfoProcessor.SortByAssembly(LoadedModsNotInDatabase);
            sortedMods2.AddRange(sortedMods1);


            foreach (var item in sortedMods2)
            {
                if (item.PDX_ID != null)
                {
                    LoadedModsList += $"- <{item.ModName.Replace("<", "").Replace(">", "")}> [{item.PDX_ID}] — {item.Author}\r\n";
                }
                else
                {
                    LoadedModsList += $"- {item.AssemblyName}\r\n";
                }
            }
            string ModsLoaded = Mod.Setting.ModsLoaded + LoadedModsList;
            ModsLoaded = ModsLoaded.Trim();
            ++Mod.Setting.ModsLoadedVersion;

            Mod.log.Info($"Loaded {count} mod(s): \r\n{ModsLoaded}");
        }
        public async void ProcessModsWithIssue()
        {
            PdxSdkPlatform _pdxPlatform;
            IContext _context;

            _pdxPlatform = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
            _context = typeof(PdxSdkPlatform).GetField("m_SDKContext", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_pdxPlatform) as IContext; ;
            try
            {
                GetProfileResult getProfileResult = await _context.Profile.Get();
                if (getProfileResult.Success)
                {
                    LoggedInUserName = getProfileResult.Social.DisplayName;
                    Mod.log.Info($"Logged in as ******");
                }

                var ModsWithIssueByLoggedInUser = LoadedModsWithIssue
                    .Where(mod => mod.Value.Author == LoggedInUserName)
                    .ToDictionary(mod => mod.Key, mod => mod.Value);
                if (ModsWithIssueByLoggedInUser.Count > 0)
                {
                    NotificationSystem.Push("starq-smc-mod-with-issue-author",
                                title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.ModWithIssueAuthor]", null,
                                    new Dictionary<string, ILocElement>
                                    {
                                        {"count", LocalizedString.Value(ModsWithIssueByLoggedInUser.Count.ToString())}
                                    }),
                                text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LearnMore]"),
                                onClicked: () => {
                                    uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModWithIssueListTab", false);
                                    NotificationSystem.Pop("starq-smc-mod-with-issue-author");
                                    NotificationSystem.Pop("starq-smc-mod-with-issue-local");
                                });
                }
                var ModsWithIssueByLocal = LoadedModsWithIssue
                    .Where(mod => mod.Value.Local == true)
                    .ToDictionary(mod => mod.Key, mod => mod.Value);
                if (ModsWithIssueByLocal.Count > 0)
                {
                    NotificationSystem.Push("starq-smc-mod-with-issue-local",
                                title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.ModWithIssueLocal]", null,
                                    new Dictionary<string, ILocElement>
                                    {
                                        {"count", LocalizedString.Value(ModsWithIssueByLocal.Count.ToString())}
                                    }),
                                text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LearnMore]"),
                                onClicked: () => {
                                    uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModWithIssueListTab", false);
                                    NotificationSystem.Pop("starq-smc-mod-with-issue-author");
                                    NotificationSystem.Pop("starq-smc-mod-with-issue-local");
                                });
                }
                var sortedModsWithIssue = SortModsWithIssue(LoggedInUserName);

                foreach (var group in sortedModsWithIssue.GroupBy(item => item.Value.Issue))
                {
                    string issueDescription = group.Key.GetDescription();
                    LoadedModsListWithIssue += $"{issueDescription}:\r\n";

                    foreach (var folderGroup in group.GroupBy(item => item.Value.Folder))
                    {
                        string assemblyNames = string.Join(", ", folderGroup.Select(item => $"{item.Value.AssemblyName}"));

                        var firstItem = folderGroup.First();
                        string modType = firstItem.Value.Local ? "[Local] " : "";
                        string authorText = firstItem.Value.Author == "" ? "" : $"— {firstItem.Value.Author}";
                        string yours = firstItem.Value.Author == LoggedInUserName ? $"— <{firstItem.Value.Author}>" : authorText;

                        LoadedModsListWithIssue += $"- {modType}<{firstItem.Value.ModName}> {yours}:\r\n- - {assemblyNames}\r\n";
                    }

                    //foreach (var item in group)
                    //{
                    //    string modType = item.Value.Local ? "[Local] " : "";
                    //    string authorText = item.Value.Author == "" ? "" : $"— {item.Value.Author}";
                    //    string yours = item.Value.Author == LoggedInUserName ? $"— <{item.Value.Author}>" : authorText;
                    //    LoadedModsListWithIssue += $"- {modType}<{item.Value.AssemblyName}> in <{item.Value.ModName}> {yours}\r\n";
                    //}

                    LoadedModsListWithIssue += "\r\n";
                }
                LoadedModsListWithIssue = LoadedModsListWithIssue.Trim();
                if (LoadedModsListWithIssue == "")
                {

                }
                ++Mod.Setting.ModsLoadedVersion;
                
                Mod.log.Info($"{LoadedModsWithIssue.Count} mods with issues: \r\n {LoadedModsListWithIssue}");
            }
            catch (Exception ex) { Mod.log.Info(ex); }
        }

        protected override void OnUpdate()
        {
        }

        private void CheckMod()
        {
            string managedPath = $"{EnvPath.kGameDataPath}\\Managed";
            List<string> vanillaDllList = [];
            try
            {
                vanillaDllList = Directory.GetFiles(managedPath, "*.dll")
                                          .Select(Path.GetFileNameWithoutExtension)
                                          .ToList();
            }
            catch (Exception ex) { Mod.log.Info(ex); }
            List<string> badDllList = ["FastMath"];

            try
            {
                count = 0;

                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (!loadedMods.Contains(modName) && !modName.StartsWith("Colossal.") && !modName.StartsWith("0Harmony") && !modName.StartsWith("Newtonsoft.Json"))
                    {
                        loadedMods.Add(modName);
                        var entry =  ModDatabase.ModDatabaseInfo.FirstOrDefault(m => m.Value.AssemblyName == modName);
                        (string id, ModInfo mod) = (entry.Key, entry.Value);
                        if (mod != null)
                        {
                            LoadedModsInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = mod.FragmentSource, ClassType = mod.ClassType, Author = mod.Author, ModName = mod.ModName, PDX_ID = id });
                        }
                        else
                        {
                            LoadedModsNotInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = null, ClassType = null, Author = null, ModName = null, PDX_ID = null });
                        }
                        count += 1;
                    }
                    else if (!loadedMods.Contains(modName))
                    {
                        Mod.log.Info($"Ignoring {modName}");
                    }

                    if (vanillaDllList.Contains(modName))
                    {
                        string path = modInfo.asset.path;
                        string FolderName = Path.GetFileName(Path.GetDirectoryName(path));
                        if (path.StartsWith(EnvPath.kCacheDataPath))
                        {
                            try { 
                                string IdFromPath = FolderName.Split('_')[0];
                                var entry = ModDatabase.ModDatabaseInfo.FirstOrDefault(m => m.Key == IdFromPath);
                                (string id, ModInfo mod) = (entry.Key, entry.Value);
                                if (mod != null)
                                {
                                    LoadedModsWithIssue.Add($"{FolderName}__{modName}", new ModWithIssueInfo { AssemblyName = modName, ModName = mod.ModName, Author = mod.Author, Issue = IssueEnum.VanillaDLL, Local= false, Folder = FolderName });
                                }
                                else
                                {
                                    LoadedModsWithIssue.Add($"{FolderName}__{modName}", new ModWithIssueInfo { AssemblyName = modName, ModName = FolderName, Author = "", Issue = IssueEnum.VanillaDLL, Local = false, Folder = FolderName });
                                }
                            } catch (Exception ex) { Mod.log.Info(ex); }
                        } else if (path.StartsWith(EnvPath.kLocalModsPath))
                        {
                            LoadedModsWithIssue.Add(Directory.GetParent(path) + "__" + modName, new ModWithIssueInfo { AssemblyName = modName, ModName = FolderName, Author = "", Issue = IssueEnum.VanillaDLL, Local = true, Folder = FolderName });
                        }
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

        public void SendNotification(int count)
        {
            uISystem = World.GetOrCreateSystemManaged<OptionsUISystem>();
            var modstext = "mod";
            if (count < 2)
            {
                modstext += "";
            }
            else
            {
                modstext += "s";
            }
            //string pageID = "SimpleModChecker.SimpleModCheckerPlus.Mod";
            //Dictionary<string, OptionsUISystem.Page> pages = [];
            //if (pages.TryGetValue(pageID, out OptionsUISystem.Page value))
            //{
            //    var sections = value.visibleSections;
            //    foreach (OptionsUISystem.Section item in sections)
            //    {
            //        Mod.log.Info(item.id);
            //        try { Mod.log.Info(item.ToJSONString()); } catch (Exception) { }
            //    }
            //}
            //else { Mod.log.Info(":("); }

            string modMessageKey = count > 1
                ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]"
                : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]";

            NotificationSystem.Push("starq-smc-mod-check",
                        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                        text: new LocalizedString(modMessageKey, null,
                            new Dictionary<string, ILocElement>
                            {
                                {"modCount", LocalizedString.Value(count.ToString())}
                            }),
                        onClicked: () => {
                            //System.Diagnostics.Process.Start($"{EnvPath.kUserDataPath}/Logs/{Mod.logFileName}.log");
                            uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                        });
        }

        public void RemoveNotification()
        {
            NotificationSystem.Pop("starq-smc-mod-check", delay: 1);
        }
    }
}