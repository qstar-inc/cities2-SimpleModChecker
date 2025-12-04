using System;
using System.Collections.Generic;
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

namespace SimpleModCheckerPlus
{
    [FileLocation("ModsSettings\\StarQ\\" + nameof(SimpleModCheckerPlus))]
    [SettingsUITabOrder(
        ModListTab,
        VerifyTab,
        BackupTab,
        GeneralTab,
        ProfileNameTab,
        AboutTab,
        LogTab
    )]
    [SettingsUIGroupOrder(
        ModsListSortGroup,
        CodeModsGroup,
        PackageModsGroup,
        ModVerifyGroup,
        BackupGroup,
        GeneralGroup,
        InfoGroup,
        ModInfo,
        SupportedMod
    )]
    [SettingsUIShowGroupName(
        CodeModsGroup,
        PackageModsGroup,
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

        public Setting(IMod mod)
            : base(mod) => SetDefaults();

        public const string GeneralTab = "GeneralTab";
        public const string GeneralGroup = "GeneralGroup";

        public const string BackupTab = "BackupTab";
        public const string BackupGroup = "BackupGroup";

        public const string ModListTab = "ModListTab";
        public const string ModsListSortGroup = "ModsListSortGroup";
        public const string CodeModsGroup = "CodeModsGroup";
        public const string PackageModsGroup = "PackageModsGroup";

        public const string VerifyTab = "VerifyTab";
        public const string ModVerifyGroup = "ModVerifyGroup";
        public const string ModCleanupGroup = "ModCleanupGroup";

        //public const string ModWithIssueListTab = "Mods with Issues";
        //public const string ModWithIssueListGroup = "Loaded Mods with Issues";

        public const string ProfileNameTab = "ProfileNameTab";

        public const string AboutTab = "AboutTab";
        public const string InfoGroup = "InfoGroup";
        public const string ModInfo = "ModInfo";
        public const string SupportedMod = "SupportedMod";

        public const string LogTab = "LogTab";

        [SettingsUIHidden]
        public bool DeletedBackupCIDs { get; set; } = false;

        //[SettingsUISlider(min = 10, max = 120)]
        //[SettingsUISection(MainTab, OptionsGroup)]
        //public int ErrorMuteCooldownSeconds
        //{
        //    get => ErrorMuteCooldownSeconds;
        //    set => GameSettingsBackup.SetErrorMuteCooldown(value);
        //}

        [Exclude]
        [SettingsUIHidden]
        public bool IsCustomChirpsOn { get; set; } = false;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool ShowNotif { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool PlaySound { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsCustomChirpsOn), true)]
        public bool AutoSaveOffChirp { get; set; } = true;

        //[SettingsUISection(MainTab, OptionsGroup)]
        //public bool DeleteMissingCIDs { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool DisableContinueOnLauncher { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool DisableContinueInGame { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool DeleteCorrupted { get; set; } = true;

        [SettingsUISection(GeneralTab, GeneralGroup)]
        public bool EnableVerboseLogging { get; set; } = false; // SET TO FALSE //

        [SettingsUISection(BackupTab, BackupGroup)]
        public bool AutoRestoreSettingBackupOnStartup { get; set; } = true;

        [SettingsUIDropdown(typeof(Setting), nameof(GetProfileNames))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ProfileListVersion))]
        [SettingsUISection(BackupTab, BackupGroup)]
        public int ProfileDropdown { get; set; } = 1;

        [SettingsUIHidden]
        public int ProfileListVersion { get; set; }

        [SettingsUIButtonGroup("AllBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool CreateAllBackup
        {
            set
            {
                GameSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
                ModSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
                KeybindsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
            }
        }

        [SettingsUIButtonGroup("AllBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool RestoreAllBackup
        {
            set
            {
                GameSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
                ModSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
                KeybindsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
            }
        }

        [SettingsUIButtonGroup("GameBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool CreateGameBackup
        {
            set => GameSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
        }

        [SettingsUIButtonGroup("GameBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool RestoreGameBackup
        {
            set => GameSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
        }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool CreateModBackup
        {
            set => ModSettingsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
        }

        [SettingsUIButtonGroup("ModBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool RestoreModBackup
        {
            set => ModSettingsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
        }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool CreateKeybindsBackup
        {
            set => KeybindsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging);
        }

        [SettingsUIButtonGroup("KeybindsBackup")]
        [SettingsUIButton]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool RestoreKeybindsBackup
        {
            set => KeybindsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging);
        }

#if DEBUG
        //[SettingsUIAdvanced]
        [SettingsUIDeveloper]
        [SettingsUISection(BackupTab, BackupGroup)]
        public bool GetSettingsFiles
        {
            set { ModSettingsBackup.GetSettingsFiles(); }
        }
#endif

        [Exclude]
        [SettingsUIHidden]
        public int ModDatabaseTimeVersion { get; set; }

        [Exclude]
        [SettingsUISection(BackupTab, BackupGroup)]
        public string ModDatabaseTime => ModDatabase.ModDatabaseTime;

        [Exclude]
        [SettingsUIHidden]
        public bool VerifyRunning { get; set; } = false;

        [Exclude]
        [SettingsUIHidden]
        public bool IsInGameOrEditor { get; set; } = false;

        [Exclude]
        [SettingsUIHidden]
        public bool ReadyForVerify => !(!VerifyRunning && !IsInGameOrEditor);

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

        [SettingsUIButton]
        [SettingsUIButtonGroup("ModsListG1")]
        [SettingsUISection(ModListTab, ModsListSortGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableSortBySize))]
        public bool ModListSortBySize
        {
            set
            {
                TextSort = ModCheckup.SortOptions.Size;
                LocaleHelper.OnActiveDictionaryChanged();
            }
        }

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

        [Exclude]
        [SettingsUIHidden]
        public int ModLoadedVersion { get; set; }

        [SettingsUIMultilineText]
        [SettingsUISection(ModListTab, CodeModsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(ModLoadedVersion))]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.CodeModsText))]
        public string CodeMods => "";

        [SettingsUIMultilineText]
        [SettingsUISection(ModListTab, PackageModsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(ModLoadedVersion))]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.PackageModsText))]
        public string PackageMods => "";

        [Exclude]
        [SettingsUIHidden]
        public int ModFolderListVersion { get; set; }

        [Exclude]
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
            set { Task.Run(() => ModVerifier.VerifyMods(ModVerifier.ProcessType.All)); }
        }

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerifySelected))]
        public bool VerifyModSelected
        {
            set
            {
                Task.Run(() =>
                    ModVerifier.VerifyMods(ModVerifier.ProcessType.Selected, ModFolderDropdown)
                );
            }
        }

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        public bool VerifyModsWithoutRP
        {
            set { Task.Run(() => ModVerifier.VerifyMods(ModVerifier.ProcessType.NoRP)); }
        }

        [SettingsUIButtonGroup("VerifyMod")]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        public bool VerifyModsActivePlayset
        {
            set { Task.Run(() => ModVerifier.VerifyMods(ModVerifier.ProcessType.ActivePlayset)); }
        }

        //[SettingsUIButtonGroup("VerifyMod")]
        //[SettingsUISection(VerifyTab, ModVerifyGroup)]
        //[SettingsUIDisableByCondition(typeof(Setting), nameof(ReadyForVerify))]
        //public bool VerifyModsCheckMetadataFormat
        //{
        //    set
        //    {
        //        Task.Run(() => ModVerifier.VerifyMods(ModVerifier.ProcessType.CheckMetadataFormat));
        //    }
        //}

        [SettingsUIMultilineText]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisplayName(typeof(ModVerifier), nameof(ModVerifier.VerificationResultText))]
        public string VerificationResult => "";

        //[SettingsUISection(VerifyTab, ModCleanupGroup)]
        //public bool AutoCleanUpOldVersions { get; set; } = true;

        //[SettingsUISection(VerifyTab, ModCleanupGroup)]
        //public bool CleanUpOldVersions
        //{
        //    set { Task.Run(() => ModCheckup.CleanUpOldVersions()); }
        //}

        //[SettingsUIMultilineText]
        //[SettingsUISection(VerifyTab, ModCleanupGroup)]
        //[SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.CleanupResultText))]
        //public string CleanUpResult => "";

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

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, SupportedMod)]
        public string SupportedModText => string.Empty;

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
                        modName =
                            jsonObject["DisplayName"]?.ToString()
                            ?? jsonObject["displayName"]?.ToString()
                            ?? modId;
                    }
                    catch (Exception) { }
                }

                x.Add(
                    new DropdownItem<string>
                    {
                        value = subfolder.Replace("\\", "/"),
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
            AutoSaveOffChirp = true;
            DisableContinueOnLauncher = true;
            DisableContinueInGame = true;
            DeleteCorrupted = true;
            AutoRestoreSettingBackupOnStartup = true;
            //AutoCleanUpOldVersions = true;
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
            VerifyRunning = false;
            IsInGameOrEditor = false;
            ModFolderDropdown = "";
            //ErrorMuteCooldownSecond/s = 10;
            //LastDownloaded = (long)0;
            //LastChecked = (long)0;
        }

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => VariableHelper.AddDevSuffix(Mod.Version);

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => VariableHelper.StarQ;

        [SettingsUIButton]
        [SettingsUIButtonGroup("Social")]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool BMaCLink
        {
            set => VariableHelper.OpenBMAC();
        }

        [SettingsUIButton]
        [SettingsUIButtonGroup("Social")]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool Discord
        {
            set => VariableHelper.OpenDiscord("1287440491239047208");
        }

        [SettingsUIMultilineText]
        [SettingsUIDisplayName(typeof(LogHelper), nameof(LogHelper.LogText))]
        [SettingsUISection(LogTab, "")]
        public string LogText => string.Empty;

        [Exclude]
        [SettingsUIHidden]
        public bool IsLogMissing
        {
            get => VariableHelper.CheckLog(Mod.Id);
        }

        [SettingsUIButton]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsLogMissing))]
        [SettingsUISection(LogTab, "")]
        public bool OpenLog
        {
            set => VariableHelper.OpenLog(Mod.Id);
        }
    }
}
