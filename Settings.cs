// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using Colossal.PSI.Environment;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using Newtonsoft.Json.Linq;
using SimpleModCheckerPlus.Systems;
using StarQ.Shared.Extensions;
using UnityEngine.Device;

namespace SimpleModCheckerPlus
{
    [FileLocation("ModsSettings\\StarQ\\" + nameof(SimpleModCheckerPlus))]
    [SettingsUITabOrder(ModListTab, VerifyTab, MainTab, ProfileNameTab, AboutTab, LogTab)]
    [SettingsUIGroupOrder(
        ModsListSortGroup,
        CodeModsGroup,
        PackageModsGroup,
        ModVerifyGroup,
        BackupGroup,
        OptionsGroup,
        InfoGroup,
        ModInfo,
        SupportedMod
    )]
    [SettingsUIShowGroupName(
        CodeModsGroup,
        PackageModsGroup,
        BackupGroup,
        OptionsGroup,
        ModVerifyGroup,
        ModCleanupGroup,
        ModInfo,
        SupportedMod
    )]
    //[SettingsUITabOrder(ModListTab, ModWithIssueListTab, MainTab, ProfileNameTab, AboutTab)]
    //[SettingsUIGroupOrder(ModListGroup, ModWithIssueListGroup, OptionsGroup, BackupGroup, ModUtilityGroup, ProfileNameGroup, InfoGroup, ModInfo, SupportedMod)]
    //[SettingsUIShowGroupName(ModListGroup, ModWithIssueListGroup, OptionsGroup, BackupGroup, ModInfo, SupportedMod)]
    public class Setting : ModSetting
    {
        public static Setting Instance;

        private readonly GameSettingsBackup GameSettingsBackup = new();
        private readonly ModSettingsBackup ModSettingsBackup = new();
        private readonly KeybindsBackup KeybindsBackup = new();
        private readonly ProfileNameBackup ProfileNameBackup = new();
        private readonly string rootFolder = EnvPath.kCacheDataPath + "/Mods/mods_subscribed";

        public Setting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        public const string MainTab = "MainTab";

        public const string OptionsGroup = "OptionsGroup";
        public const string BackupGroup = "BackupGroup";

        public const string ModListTab = "ModListTab";
        public const string VerifyTab = "VerifyTab";

        //public const string ModListGroup = "Loaded Mods";
        public const string ModsListSortGroup = "ModsListSortGroup";
        public const string CodeModsGroup = "CodeModsGroup";
        public const string PackageModsGroup = "PackageModsGroup";
        public const string ModVerifyGroup = "ModVerifyGroup";
        public const string ModCleanupGroup = "ModCleanupGroup";

        //public const string ModWithIssueListTab = "Mods with Issues";
        //public const string ModWithIssueListGroup = "Loaded Mods with Issues";

        public const string ProfileNameTab = "ProfileNameTab";

        public const string AboutTab = "AboutTab";
        public const string InfoGroup = "InfoGroup";
        public const string LogTab = "LogTab";
        public const string ModInfo = "ModInfo";
        public const string SupportedMod = "SupportedMod";

        [SettingsUIHidden]
        public bool DeletedBackupCIDs { get; set; } = false;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool ShowNotif { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool PlaySound { get; set; } = true;

        //[SettingsUISection(MainTab, OptionsGroup)]
        //public bool DeleteMissingCIDs { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DisableContinueOnLauncher { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DisableContinueInGame { get; set; } = true;

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
        public bool CreateGameBackup
        {
            set { GameSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); }
        }

        [SettingsUIButtonGroup("GameBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreGameBackup
        {
            set { GameSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); }
        }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateModBackup
        {
            set { ModSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); }
        }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreModBackup
        {
            set { ModSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); }
        }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateKeybindsBackup
        {
            set { KeybindsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); }
        }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreKeybindsBackup
        {
            set { KeybindsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); }
        }

#if DEBUG
        //[SettingsUIAdvanced]
        [SettingsUIDeveloper]
        [SettingsUISection(MainTab, BackupGroup)]
        public bool GetSettingsFiles
        {
            set { ModSettingsBackup.GetSettingsFiles(); }
        }
#endif

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

        [Exclude]
        [SettingsUIHidden]
        public ModCheckup.SortOptions TextSort = ModCheckup.SortOptions.Name;

        [Exclude]
        [SettingsUIHidden]
        public bool TextSortAscending = true;

        [Exclude]
        [SettingsUIHidden]
        public bool DisableSortByName => TextSort == ModCheckup.SortOptions.Name;

        [Exclude]
        [SettingsUIHidden]
        public bool DisableSortBySize => TextSort == ModCheckup.SortOptions.Size;

        [Exclude]
        [SettingsUIHidden]
        public bool DisableSortByAuthor => TextSort == ModCheckup.SortOptions.Author;

        [SettingsUIButton]
        [SettingsUIButtonGroup("ModsListG1")]
        [SettingsUISection(ModListTab, ModsListSortGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableSortByName))]
        public bool ModListSortByName
        {
            set
            {
                TextSort = ModCheckup.SortOptions.Name;
                LocaleHelper.OnActiveDictionaryChanged();
            }
        }

        //[SettingsUIButton]
        //[SettingsUIButtonGroup("ModsListG1")]
        //[SettingsUISection(ModListTab, ModsListSortGroup)]
        //[SettingsUIDisableByCondition(typeof(Setting), nameof(DisableSortBySize))]
        //public bool ModListSortBySize
        //{
        //    set { TextSort = ModCheckup.SortOptions.Size;LocaleHelper.OnActiveDictionaryChanged(); }
        //}

        [SettingsUIButton]
        [SettingsUIButtonGroup("ModsListG1")]
        [SettingsUISection(ModListTab, ModsListSortGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableSortByAuthor))]
        public bool ModListSortByAuthor
        {
            set
            {
                TextSort = ModCheckup.SortOptions.Author;
                LocaleHelper.OnActiveDictionaryChanged();
            }
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup("ModsListG2")]
        [SettingsUISection(ModListTab, ModsListSortGroup)]
        public bool ModListSortDirection
        {
            set
            {
                TextSortAscending = !TextSortAscending;
                LocaleHelper.OnActiveDictionaryChanged();
            }
        }

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
        public bool ReadyForVerifySelected =>
            !(!ReadyForVerify && !(ModFolderDropdown == string.Empty));

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        public bool VerifyMods
        {
            set { Task.Run(() => ModVerifier.VerifyMods()); }
        }

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerifySelected))]
        public bool VerifyModSelected
        {
            set { Task.Run(() => ModVerifier.VerifyMods(ModFolderDropdown)); }
        }

        [SettingsUISection(VerifyTab, ModCleanupGroup)]
        public bool CleanUpOldVersions
        {
            set { Task.Run(() => ModCheckup.CleanUpOldVersions()); }
        }

        [SettingsUIMultilineText]
        [SettingsUISection(VerifyTab, ModCleanupGroup)]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.CleanupResultText))]
        public string CleanUpResult => "";

        [SettingsUIHidden]
        [SettingsUISection(ProfileNameTab, "")]
        public string ProfileName0 { get; set; } = "Profile Auto";

        private string profileName1 = "Profile 1";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName1
        {
            get => profileName1;
            set => profileName1 = value;
        }

        private string profileName2 = "Profile 2";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName2
        {
            get => profileName2;
            set => profileName2 = value;
        }

        private string profileName3 = "Profile 3";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName3
        {
            get => profileName3;
            set => profileName3 = value;
        }

        private string profileName4 = "Profile 4";

        //[SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName4
        {
            get => profileName4;
            set => profileName4 = value;
        }

        private string profileName5 = "Profile 5";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName5
        {
            get => profileName5;
            set => profileName5 = value;
        }

        private string profileName6 = "Profile 6";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName6
        {
            get => profileName6;
            set => profileName6 = value;
        }

        private string profileName7 = "Profile 7";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName7
        {
            get => profileName7;
            set => profileName7 = value;
        }

        private string profileName8 = "Profile 8";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName8
        {
            get => profileName8;
            set => profileName8 = value;
        }

        private string profileName9 = "Profile 9";

        [SettingsUISection(ProfileNameTab, "")]
        [SettingsUITextInput]
        public string ProfileName9
        {
            get => profileName9;
            set => profileName9 = value;
        }

        [SettingsUISection(ProfileNameTab, "")]
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
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText =>
#if DEBUG
            $"{Mod.Version} - DEBUG";
#else
            Mod.Version;
# endif

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
                    LogHelper.SendLog(e);
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
                    Application.OpenURL(
                        $"https://discord.com/channels/1024242828114673724/1287440491239047208"
                    );
                }
                catch (Exception e)
                {
                    LogHelper.SendLog(e);
                }
            }
        }

        //[SettingsUIMultilineText]
        //[SettingsUISection(AboutTab, ModInfo)]
        //public string AboutTheMod => string.Empty;

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, SupportedMod)]
        public string SupportedModText => string.Empty;

        [SettingsUIMultilineText]
        [SettingsUIDisplayName(typeof(LogHelper), nameof(LogHelper.LogText))]
        [SettingsUISection(LogTab, "")]
        public string LogText => string.Empty;

        [SettingsUISection(LogTab, "")]
        public bool OpenLog
        {
            set
            {
                Task.Run(() =>
                    Process.Start(
                        $"{EnvPath.kUserDataPath}/Logs/{nameof(SimpleModCheckerPlus)}.log"
                    )
                );
            }
        }

        public DropdownItem<int>[] GetProfileNames()
        {
            var profileNames = new[]
            {
                ProfileName0,
                ProfileName1,
                ProfileName2,
                ProfileName3,
                ProfileName4,
                ProfileName5,
                ProfileName6,
                ProfileName7,
                ProfileName8,
                ProfileName9,
            };
            var items = new List<DropdownItem<int>>();

            return Enumerable
                .Range(1, 9)
                .Select(i => new DropdownItem<int> { value = i, displayName = profileNames[i] })
                .ToArray();
        }

        public DropdownItem<string>[] GetModFolderList()
        {
            var x = new List<DropdownItem<string>>();

            var directories = Directory
                .GetDirectories(rootFolder, "*", SearchOption.TopDirectoryOnly)
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

                x.Add(
                    new DropdownItem<string>
                    {
                        value = subfolder,
                        displayName = $"{modName} [{modFolder}]",
                    }
                );
            }

            x.Sort((a, b) => a.displayName.id.CompareTo(b.displayName.id));

            return x.ToArray();
        }

        public override void SetDefaults()
        {
            ShowNotif = true;
            PlaySound = true;
            DisableContinueOnLauncher = true;
            DisableContinueInGame = true;
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
