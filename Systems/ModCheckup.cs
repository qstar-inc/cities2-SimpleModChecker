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
using Game.Audio;
using Game.Prefabs;
using Unity.Entities;

namespace SimpleModChecker.Systems
{

    public partial class ModCheckup : GameSystemBase
    {
        public Mod _mod;
        //private int count;
        public static List<string> loadedMods = [];

        private EntityQuery m_SoundQuery;
        //public static Dictionary<string, ModInfo> LoadedModsInDatabase = [];
        //public static Dictionary<string, ModInfo> LoadedModsNotInDatabase = [];
        //public static Dictionary<string, ModWithIssueInfo> LoadedModsWithIssue = [];

        public static OptionsUISystem uISystem = new();
        //public static string LoadedModsList { get; set; } = "";
        //public static string LoadedModsListWithIssue { get; set; } = "";
        public static string LoggedInUserName { get; set; } = "";

        //public static LocalizedString LoadedModsListLocalized()
        //{
        //    return LocalizedString.Id(LoadedModsList);
        //}
        //public static LocalizedString LoadedModsListWithIssueLocalized()
        //{
        //    return LocalizedString.Id(LoadedModsListWithIssue);
        //}

        public List<string> GetLoadedMods()
        {
            return loadedMods;
        }

        //protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        //{
        //    Mod.log.Info("GameLoadingComplete");
        //}

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckMod();
            CheckModNew();
            //ProcessMods();
            if (Mod.Setting.ShowNotif)
            {
                SendNotification(codeMods.Count + localMods.Count);
            }
            Mod.log.Info($"\r\nCods mods loaded:\r\n{LoadedList("CodeMods").Trim()}\r\n");
            Mod.log.Info($"\r\nPackage mods loaded:\r\n{LoadedList("PackageMods").Trim()}\r\n");
            GameManager.instance.RegisterUpdater(PlaySound);
            //string lm = "";
            //foreach (var item in loadedMods)
            //{
            //    lm += $"{item}\r\n";
            //}
            //Mod.log.Info($"\r\nLoaded mods raw:\r\n{lm}".Trim());
        }

        private bool PlaySound()
        {
            if (!GameManager.instance.modManager.isInitialized ||
                GameManager.instance.gameMode != GameMode.MainMenu ||
                GameManager.instance.state == GameManager.State.Loading ||
                GameManager.instance.state == GameManager.State.Booting
            ) return false;

            try
            {
                m_SoundQuery = GetEntityQuery(ComponentType.ReadOnly<ToolUXSoundSettingsData>());
                AudioManager m_AudioManager = AudioManager.instance;
                m_AudioManager.PlayUISound(m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_SelectEntitySound);
            }
            catch (Exception e)
            {
                Mod.log.Info("Failed to play audio: " + e.Message);
            }
            return true;
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
                    SendNotification(codeMods.Count + localMods.Count);
                }
            }
            //ProcessModsWithIssue();
        }

        //public void ProcessMods()
        //{
        //    if (Mod.Setting.ShowNotif)
        //    {
        //        SendNotification(count);
        //    }
        //    List<ModInfo> sortedMods1 = ModInfoProcessor.SortByModName(LoadedModsInDatabase);
        //    List<ModInfo> sortedMods2 = ModInfoProcessor.SortByAssembly(LoadedModsNotInDatabase);
        //    sortedMods2.AddRange(sortedMods1);


        //    foreach (var item in sortedMods2)
        //    {
        //        if (item.PDX_ID != null)
        //        {
        //            LoadedModsList += $"- <{item.ModName.Replace("<", "").Replace(">", "")}> [{item.PDX_ID}] — {item.Author}\r\n";
        //        }
        //        else
        //        {
        //            LoadedModsList += $"- {item.AssemblyName}\r\n";
        //        }
        //    }
        //    string ModsLoaded = Mod.Setting.ModsLoaded + LoadedModsList;
        //    ModsLoaded = ModsLoaded.Trim();
        //    ++Mod.Setting.ModsLoadedVersion;

        //    Mod.log.Info($"Loaded {count} mod(s): \r\n{ModsLoaded}");
        //}
        //public async void ProcessModsWithIssue()
        //{
        //    PdxSdkPlatform _pdxPlatform;
        //    IContext _context;

        //    _pdxPlatform = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
        //    _context = typeof(PdxSdkPlatform).GetField("m_SDKContext", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_pdxPlatform) as IContext; ;
        //    try
        //    {
        //        GetProfileResult getProfileResult = await _context.Profile.Get();
        //        if (getProfileResult.Success)
        //        {
        //            LoggedInUserName = getProfileResult.Social.DisplayName;
        //            Mod.log.Info($"Logged in as ******");
        //        }

        //        var ModsWithIssueByLoggedInUser = LoadedModsWithIssue
        //            .Where(mod => mod.Value.Author == LoggedInUserName)
        //            .ToDictionary(mod => mod.Key, mod => mod.Value);
        //        if (ModsWithIssueByLoggedInUser.Count > 0)
        //        {
        //            NotificationSystem.Push("starq-smc-mod-with-issue-author",
        //                        title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.ModWithIssueAuthor]", null,
        //                            new Dictionary<string, ILocElement>
        //                            {
        //                                {"count", LocalizedString.Value(ModsWithIssueByLoggedInUser.Count.ToString())}
        //                            }),
        //                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LearnMore]"),
        //                        onClicked: () => {
        //                            uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModWithIssueListTab", true);
        //                            NotificationSystem.Pop("starq-smc-mod-with-issue-author");
        //                            NotificationSystem.Pop("starq-smc-mod-with-issue-local");
        //                        });
        //        }
        //        var ModsWithIssueByLocal = LoadedModsWithIssue
        //            .Where(mod => mod.Value.Local == true)
        //            .ToDictionary(mod => mod.Key, mod => mod.Value);
        //        if (ModsWithIssueByLocal.Count > 0)
        //        {
        //            NotificationSystem.Push("starq-smc-mod-with-issue-local",
        //                        title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.ModWithIssueLocal]", null,
        //                            new Dictionary<string, ILocElement>
        //                            {
        //                                {"count", LocalizedString.Value(ModsWithIssueByLocal.Count.ToString())}
        //                            }),
        //                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LearnMore]"),
        //                        onClicked: () => {
        //                            uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModWithIssueListTab", true);
        //                            NotificationSystem.Pop("starq-smc-mod-with-issue-author");
        //                            NotificationSystem.Pop("starq-smc-mod-with-issue-local");
        //                        });
        //        }
        //        var sortedModsWithIssue = SortModsWithIssue(LoggedInUserName);

        //        //foreach (var group in sortedModsWithIssue.GroupBy(item => item.Value.Issue))
        //        //{
        //        //    string issueDescription = group.Key.GetDescription();
        //        //    LoadedModsListWithIssue += $"{issueDescription}:\r\n";

        //        //    foreach (var folderGroup in group.GroupBy(item => item.Value.Folder))
        //        //    {
        //        //        string assemblyNames = string.Join(", ", folderGroup.Select(item => $"{item.Value.AssemblyName}"));

        //        //        var firstItem = folderGroup.First();
        //        //        string modType = firstItem.Value.Local ? "[Local] " : "";
        //        //        string authorText = firstItem.Value.Author == "" ? "" : $"— {firstItem.Value.Author}";
        //        //        string yours = firstItem.Value.Author == LoggedInUserName ? $"— <{firstItem.Value.Author}>" : authorText;

        //        //        LoadedModsListWithIssue += $"- {modType}<{firstItem.Value.ModName}> {yours}:\r\n- - {assemblyNames}\r\n";
        //        //    }

        //        //    //foreach (var item in group)
        //        //    //{
        //        //    //    string modType = item.Value.Local ? "[Local] " : "";
        //        //    //    string authorText = item.Value.Author == "" ? "" : $"— {item.Value.Author}";
        //        //    //    string yours = item.Value.Author == LoggedInUserName ? $"— <{item.Value.Author}>" : authorText;
        //        //    //    LoadedModsListWithIssue += $"- {modType}<{item.Value.AssemblyName}> in <{item.Value.ModName}> {yours}\r\n";
        //        //    //}

        //        //    LoadedModsListWithIssue += "\r\n";
        //        //}
        //        //LoadedModsListWithIssue = LoadedModsListWithIssue.Trim();
        //        //if (LoadedModsListWithIssue == "")
        //        //{

        //        //}
        //        ++Mod.Setting.ModsLoadedVersion;

        //        //Mod.log.Info($"{LoadedModsWithIssue.Count} mods with issues: \r\n {LoadedModsListWithIssue}");
        //    }
        //    catch (Exception ex) { Mod.log.Info(ex); }
        //}

        protected override void OnUpdate()
        {
        }

        private void CheckMod()
        {
            //string managedPath = $"{EnvPath.kGameDataPath}\\Managed";
            //List<string> vanillaDllList = [];
            //try
            //{
            //    vanillaDllList = Directory.GetFiles(managedPath, "*.dll")
            //                              .Select(Path.GetFileNameWithoutExtension)
            //                              .ToList();
            //}
            //catch (Exception ex) { Mod.log.Info(ex); }
            List<string> badDllList = ["FastMath"];

            try
            {
                //count = 0;

                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (!loadedMods.Contains(modName) && !modName.StartsWith("Colossal.") && !modName.StartsWith("0Harmony") && !modName.StartsWith("Newtonsoft.Json"))
                    {
                            loadedMods.Add(modName);
                    //    var entry =  ModDatabase.ModDatabaseInfo.FirstOrDefault(m => m.Value.AssemblyName == modName);
                    //    (string id, ModInfo mod) = (entry.Key, entry.Value);
                    //    if (mod != null)
                    //    {
                    //        LoadedModsInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = mod.FragmentSource, ClassType = mod.ClassType, Author = mod.Author, ModName = mod.ModName, PDX_ID = id });
                    //    }
                    //    else
                    //    {
                    //        LoadedModsNotInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = null, ClassType = null, Author = null, ModName = null, PDX_ID = null });
                    //    }
                    //    count += 1;
                    //}
                    //else if (!loadedMods.Contains(modName))
                    //{
                    //    Mod.log.Info($"Ignoring {modName}");
                    }

                    if (!modInfo.asset.path.Contains("Colossal Order/Cities Skylines II/.cache/Mods/mods_subscribed") && !modName.StartsWith("Colossal.") && !modName.StartsWith("0Harmony") && !modName.StartsWith("Newtonsoft.Json"))
                    {
                        //Mod.log.Info($"Found local mod {modInfo.asset.name} in {modInfo.asset.path}");
                        localMods.Add(modName, modInfo.asset.path);
                    }

                    //if (vanillaDllList.Contains(modName))
                    //{
                    //    string path = modInfo.asset.path;
                    //    string FolderName = Path.GetFileName(Path.GetDirectoryName(path));
                    //    if (!LoadedModsWithIssue.ContainsKey($"{FolderName}__{modName}"))
                    //    {
                    //        if (path.StartsWith(EnvPath.kCacheDataPath))
                    //        {
                    //            try
                    //            {
                    //                string IdFromPath = FolderName.Split('_')[0];
                    //                var entry = ModDatabase.ModDatabaseInfo.FirstOrDefault(m => m.Key == IdFromPath);
                    //                (string id, ModInfo mod) = (entry.Key, entry.Value);
                    //                if (mod != null)
                    //                {
                    //                    LoadedModsWithIssue.Add($"{FolderName}__{modName}", new ModWithIssueInfo { AssemblyName = modName, ModName = mod.ModName, Author = mod.Author, Issue = IssueEnum.VanillaDLL, Local = false, Folder = FolderName });
                    //                }
                    //                else
                    //                {
                    //                    LoadedModsWithIssue.Add($"{FolderName}__{modName}", new ModWithIssueInfo { AssemblyName = modName, ModName = FolderName, Author = "", Issue = IssueEnum.VanillaDLL, Local = false, Folder = FolderName });
                    //                }
                    //            }
                    //            catch (Exception ex) { Mod.log.Info(ex); }
                    //        }
                    //        else if (path.StartsWith(EnvPath.kUserDataPath + "/Mods"))
                    //        {
                    //            LoadedModsWithIssue.Add(Directory.GetParent(path) + "__" + modName, new ModWithIssueInfo { AssemblyName = modName, ModName = FolderName, Author = "", Issue = IssueEnum.VanillaDLL, Local = true, Folder = FolderName });
                    //        }
                    //    }
                    //}
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

        static Dictionary<string, string> localMods = [];
        static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> codeMods = [];
        static Dictionary<string, PDX.SDK.Contracts.Service.Mods.Models.Mod> packageMods = [];

        public static string LoadedList(string type)
        {
            string returnText = "";
            switch (type)
            {
                case "CodeMods":
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

            return $"• <{mod.DisplayName.Replace("<", "(").Replace(">", ")")}>{version} [{mod.Id}] — <{mod.Author}>{outDatedText}\r\n";
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
                }
                //else if (extensionCounts.ContainsKey(".prefab") && extensionCounts[".prefab"] > 0)
                //{
                //    prefabMods.Add(mod.DisplayName, mod);
                //}
                //else if (extensionCounts.ContainsKey(".cok") && extensionCounts[".cok"] > 0)
                //{
                //    packageMods.Add(mod.DisplayName, mod);
                //}
                else
                {
                    packageMods.Add(mod.DisplayName, mod);
                    //Mod.log.Info($"Unknown mod info: {mod.DisplayName}: {string.Join(", ", extensionCounts.Select(kv => $"{kv.Key} = {kv.Value}"))}");
                }
            }

            PdxSdkPlatform m_Manager = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
            List<PDX.SDK.Contracts.Service.Mods.Models.Mod> mods = m_Manager.GetModsInActivePlayset().GetAwaiter().GetResult();

            foreach (var mod in mods)
            {
                //try { Mod.log.Info(mod.Author); } catch (Exception exception) { Mod.log.Info(exception); };
                ////try { Mod.log.Info(mod.CreationDate.Value.ToShortTimeString()); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.DisplayName); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.HasLiked); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.Id); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.InstalledDate); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LatestUpdate); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LatestVersion); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LocalData.ContentFileOrFolder); } catch (Exception exception) { Mod.log.Info(exception); };
                try {
                    //Mod.log.Info(mod.LocalData.FolderAbsolutePath);
                    string folderPath = mod.LocalData.FolderAbsolutePath; 
                    Dictionary<string, int> extensionCounts = [];
                    ProcessFolder(folderPath, extensionCounts);
                    CategoriseMods(mod, extensionCounts);
                    //foreach (var entry in extensionCounts)
                    //{
                    //    Mod.log.Info($"{entry.Key}: {entry.Value}");
                    //}
                } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LocalData.LocalType); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LocalData.ScreenshotsFilenames.ToString()); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LocalData.ThumbnailFilename); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.LongDescription); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.Name); } catch (Exception exception) { Mod.log.Info(exception); };
                //try {
                //    foreach (var playset in mod.Playsets)
                //    {
                //        try { Mod.log.Info(playset.LoadOrder); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(playset.ModIsEnabled); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(playset.Name); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(playset.PlaysetId); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(playset.SubscribedDate.Value.ToShortTimeString()); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(playset.Version); } catch (Exception exception) { Mod.log.Info(exception); };
                //    }
                //} catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.Rating); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.RatingsTotal); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.RequiredGameVersion); } catch (Exception exception) { Mod.log.Info(exception); };
                ////try { Mod.log.Info(mod.ShortDescription); } catch (Exception exception) { Mod.log.Info(exception); };
                ////try { Mod.log.Info(mod.Size); } catch (Exception exception) { Mod.log.Info(exception); };
                ////try { Mod.log.Info(mod.State.ToString()); } catch (Exception exception) { Mod.log.Info(exception); };
                //try
                //{
                //    foreach (var tag in mod.Tags)
                //    {
                //        try { Mod.log.Info(tag.DisplayName); } catch (Exception exception) { Mod.log.Info(exception); };
                //        try { Mod.log.Info(tag.Id); } catch (Exception exception) { Mod.log.Info(exception); };
                //    }
                //}
                //catch (Exception exception) { Mod.log.Info(exception); };
                ////try { Mod.log.Info(mod.ThumbnailPath); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.UserModVersion); } catch (Exception exception) { Mod.log.Info(exception); };
                //try { Mod.log.Info(mod.Version); } catch (Exception exception) { Mod.log.Info(exception); };
            }
            Mod.log.Info(mods.Count + " subbed mods");
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
                //title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                titleId: "SimpleModCheckerPlus",
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