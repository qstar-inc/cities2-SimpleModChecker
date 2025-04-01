// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Colossal.PSI.Environment;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using Newtonsoft.Json.Linq;
using SimpleModChecker.Systems;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using UnityEngine.Device;
using System.Diagnostics;

namespace SimpleModCheckerPlus
{
    [FileLocation($"ModsSettings\\StarQ\\{Mod.Name}")]
    [SettingsUITabOrder(ModListTab, VerifyTab, MainTab, ProfileNameTab, AboutTab)]
    [SettingsUIGroupOrder(CodeModsGroup, PackageModsGroup, ModVerifyGroup, BackupGroup, OptionsGroup, ProfileNameGroup, InfoGroup, ModInfo, SupportedMod)]
    [SettingsUIShowGroupName(CodeModsGroup, PackageModsGroup, BackupGroup, OptionsGroup, ModInfo, SupportedMod)]
    //[SettingsUITabOrder(ModListTab, ModWithIssueListTab, MainTab, ProfileNameTab, AboutTab)]
    //[SettingsUIGroupOrder(ModListGroup, ModWithIssueListGroup, OptionsGroup, BackupGroup, ModUtilityGroup, ProfileNameGroup, InfoGroup, ModInfo, SupportedMod)]
    //[SettingsUIShowGroupName(ModListGroup, ModWithIssueListGroup, OptionsGroup, BackupGroup, ModInfo, SupportedMod)]
    public class Setting : ModSetting
    {
        public static Setting Instance;

        private readonly ModDatabase ModDatabase = new();
        private readonly GameSettingsBackup GameSettingsBackup = new();
        private readonly ModSettingsBackup ModSettingsBackup = new();
        private readonly KeybindsBackup KeybindsBackup = new();
        private readonly ProfileNameBackup ProfileNameBackup = new();
        private readonly string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        public const string MainTab = "Options & Backup";

        public const string OptionsGroup = "Options";
        public const string BackupGroup = "Settings Backup";

        public const string ModListTab = "Mods";
        public const string VerifyTab = "Verify";
        //public const string ModListGroup = "Loaded Mods";
        public const string CodeModsGroup = "Code Mods Loaded";
        public const string PackageModsGroup = "Package Mods Loaded";
        public const string ModVerifyGroup = "Mod Verification";
        //public const string ModWithIssueListTab = "Mods with Issues";
        //public const string ModWithIssueListGroup = "Loaded Mods with Issues";

        public const string ProfileNameTab = "Profile Names";
        public const string ProfileNameGroup = ProfileNameTab;

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";
        public const string ModInfo = "About the Mod";
        public const string SupportedMod = "Currently Supported Mods for Mod Settings Backup";

        [SettingsUIHidden]
        public bool DeletedBackupCIDs { get; set; } = false;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool ShowNotif { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool PlaySound { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteMissing { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteCorrupted { get; set; } = true;
        [SettingsUISection(MainTab, OptionsGroup)]
        public bool EnableVerboseLogging { get; set; } = false; // SET TO FALSE //

        [SettingsUISection(MainTab, BackupGroup)]
        public bool AutoRestoreSettingBackupOnStartup { get; set; } = true;

        [SettingsUIDropdown(typeof(Setting), nameof(GetProfileNames))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ProfileListVersion))]
        [SettingsUISection(MainTab, BackupGroup)]
        public int ProfileDropdown { get; set; } = 1;

        [SettingsUIHidden]
        public int ProfileListVersion { get; set; }

        [SettingsUIButtonGroup("GameBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateGameBackup { set { GameSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); } }

        [SettingsUIButtonGroup("GameBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreGameBackup { set { GameSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); } }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateModBackup { set { ModSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); } }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreModBackup { set { ModSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); } }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateKeybindsBackup { set { KeybindsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); } }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreKeybindsBackup { set { KeybindsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); } }

        //[SettingsUIAdvanced]
        //[SettingsUIDeveloper]
        //[SettingsUISection(MainTab, BackupGroup)]
        //public bool GetSettingsFiles { set { ModSettingsBackup.GetSettingsFiles(); } }

        //[SettingsUIHidden]
        //public int ModsLoadedVersion { get; set; }

        [SettingsUIHidden]
        public int ModDatabaseTimeVersion { get; set; }
        [SettingsUISection(MainTab, BackupGroup)]
        public string ModDatabaseTime => ModDatabase.ModDatabaseTime;

        [SettingsUIHidden]
        public bool VerifiedRecently { get; set; } = false;
        [SettingsUIHidden]
        public bool IsInGameOrEditor { get; set; } = false;
        [SettingsUIHidden]
        public bool ReadyForVerify => !(!VerifiedRecently && !IsInGameOrEditor);
        //[SettingsUIHidden]
        //public long LastDownloaded { get; set; } = (long)0;
        //[SettingsUIHidden]
        //public long LastChecked { get; set; } = (long)0;

        //[SettingsUIMultilineText]
        //[SettingsUISection(ModListTab, ModListGroup)]
        //[SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.LoadedModsListLocalized))]
        //public string ModsLoaded => "";

        //[SettingsUIAdvanced]
        //[SettingsUIMultilineText]
        //[SettingsUISection(ModWithIssueListTab, ModWithIssueListGroup)]
        //[SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.LoadedModsListWithIssueLocalized))]
        //public string ModsWithIssueLoaded => "";

        [SettingsUIMultilineText]
        [SettingsUISection(ModListTab, CodeModsGroup)]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.CodeModsText))]
        public string CodeMods => "";

        [SettingsUIMultilineText]
        [SettingsUISection(ModListTab, PackageModsGroup)]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.PackageModsText))]
        public string PackageMods => "";

        [SettingsUIMultilineText]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisplayName(typeof(ModVerifier), nameof(ModVerifier.VerificationResultText))]
        public string VerificationResult => "";

        [SettingsUIHidden]
        public int ModFolderListVersion { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetModFolderList))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ModFolderListVersion))]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        public string ModFolderDropdown { get; set; } = string.Empty;

        [SettingsUIHidden]
        public bool ReadyForVerifySelected => !(!ReadyForVerify && !(ModFolderDropdown == string.Empty));

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        public bool VerifyMods { set { Task.Run(() => ModVerifier.VerifyMods()); } }

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerifySelected))]
        public bool VerifyModSelected { set { Task.Run(() => ModVerifier.VerifyMods(ModFolderDropdown)); } }

        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        public bool OpenLog { set { Task.Run(() => Process.Start($"{EnvPath.kUserDataPath}/Logs/{Mod.Name.Replace(" ","")}.log")); } }

        [SettingsUIHidden]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        public string ProfileName0 { get; set; } = "Profile Auto";

        private string profileName1 = "Profile 1";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName1
        {
            get => profileName1;
            set => profileName1 = value;
        }

        private string profileName2 = "Profile 2";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName2
        {
            get => profileName2;
            set => profileName2 = value;
        }

        private string profileName3 = "Profile 3";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName3
        {
            get => profileName3;
            set => profileName3 = value;
        }

        private string profileName4 = "Profile 4";
        //[SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName4
        {
            get => profileName4;
            set => profileName4 = value;
        }

        private string profileName5 = "Profile 5";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName5
        {
            get => profileName5;
            set => profileName5 = value;
        }

        private string profileName6 = "Profile 6";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName6
        {
            get => profileName6;
            set => profileName6 = value;
        }

        private string profileName7 = "Profile 7";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName7
        {
            get => profileName7;
            set => profileName7 = value;
        }

        private string profileName8 = "Profile 8";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName8
        {
            get => profileName8;
            set => profileName8 = value;
        }

        private string profileName9 = "Profile 9";
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName9
        {
            get => profileName9;
            set => profileName9 = value;
        }
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUIButton]
        public bool SaveProfileName
        {
            set
            {
                ProfileNameBackup.CreateBackup();
                ++ProfileListVersion;
            }
        }

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText =>
#if DEBUG
            $"{Mod.Name} - DEBUG";
#else
            Mod.Name;
#endif

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => "StarQ";

        [SettingsUIButtonGroup("Social")]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool BMaCLink
        {
            set
            {
                try
                {
                    Application.OpenURL($"https://buymeacoffee.com/starq");
                }
                catch (Exception e)
                {
                    Mod.log.Info(e);
                }
            }
        }
        [SettingsUIButtonGroup("Social")]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool Discord
        {
            set
            {
                try
                {
                    Application.OpenURL($"https://discord.com/channels/1024242828114673724/1287440491239047208");
                }
                catch (Exception e)
                {
                    Mod.log.Info(e);
                }
            }
        }

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod => string.Empty;
        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, SupportedMod)]
        public string SupportedModText => string.Empty;

        public DropdownItem<int>[] GetProfileNames()
        {
            var profileNames = new[] { ProfileName0, ProfileName1, ProfileName2, ProfileName3, ProfileName4, ProfileName5, ProfileName6, ProfileName7, ProfileName8, ProfileName9 };
            var items = new List<DropdownItem<int>>();

            return Enumerable.Range(1, 9)
                .Select(i => new DropdownItem<int> { value = i, displayName = profileNames[i] })
                .ToArray();
        }

        public DropdownItem<string>[] GetModFolderList()
        {
            var x = new List<DropdownItem<string>>();

            var directories = Directory.GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
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

                x.Add(new DropdownItem<string> { value = subfolder, displayName = $"{modName} [{modFolder}]" });
            }

            x.Sort((a, b) => a.displayName.id.CompareTo(b.displayName.id));

            return [.. x];
        }

        //public override AutomaticSettings.SettingPageData GetPageData(string id, bool addPrefix)
        //{
        //    AutomaticSettings.SettingPageData pageData = base.GetPageData(id, addPrefix);
        //    if (ModDatabase.ModDatabaseInfo == null)
        //    {
        //        ModDatabase.OnDatabaseLoaded += () => GetPageSection(pageData);
        //        //return;
        //    }
        //    //GetPageSection(pageData);
        //    return pageData;
        //}

        //private void GetPageSection(AutomaticSettings.SettingPageData pageData)
        //{
        //    //if (ModDatabase.ModDatabaseInfo == null) {
        //    //    ModDatabase.OnDatabaseLoaded += () => GetPageSection(pageData);
        //    //    return;
        //    //}
            
        //    foreach (var kvp in ModDatabase.ModDatabaseInfo)
        //    {
        //        string modName = kvp.Key;
        //        ModInfo modInfo = kvp.Value;

        //        Mod.log.Info($"{modName}");

        //        AutomaticSettings.ManualProperty property = new AutomaticSettings.ManualProperty(typeof(Setting), typeof(bool), modName)
        //        {
        //            canRead = true,
        //            canWrite = true,
        //            //attributes =
        //            //{
        //            //    (Attribute)new SettingsUIPathAttribute($"Mods.{modName}"),
        //            //    (Attribute)new SettingsUIDisplayNameAttribute(modName)
        //            //},
        //            getter = (_) => modInfo.Backupable,
        //            setter = (_, obj) => modInfo.Backupable = (bool)obj
        //        };

        //        AutomaticSettings.SettingItemData item = new AutomaticSettings.SettingItemData(AutomaticSettings.WidgetType.BoolToggle, this, property, pageData.prefix)
        //        {
        //            simpleGroup = "BackupGroup"
        //        };

        //        pageData["B&R"].AddItem(item);
        //        pageData.AddGroup("B&R");
        //        pageData.AddGroupToShowName("B&R");
        //    }
        //}

        public override void SetDefaults()
        {
            ShowNotif = true;
            PlaySound = true;
            DeleteMissing = true;
            DeleteCorrupted = true;
            AutoRestoreSettingBackupOnStartup = true;
            EnableVerboseLogging = false;
            ProfileName1 = "Profile 1";
            ProfileName2 = "Profile 2";
            ProfileName3 = "Profile 3";
            ProfileName4 = "Profile 4";
            ProfileName5 = "Profile 5";
            ProfileName6 = "Profile 6";
            ProfileName7 = "Profile 7";
            ProfileName8 = "Profile 8";
            ProfileName9 = "Profile 9";
            VerifiedRecently = false;
            IsInGameOrEditor = false;
            ModFolderDropdown = "";
            //LastDownloaded = (long)0;
            //LastChecked = (long)0;
        }
    }
}