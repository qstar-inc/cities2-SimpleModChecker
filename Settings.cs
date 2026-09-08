using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Colossal.Json;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using SimpleModCheckerPlus.Systems;
using StarQ.Shared.Extensions;
using StarQ.Shared.Generators;

namespace SimpleModCheckerPlus
{
    [GenerateSettingCommonAttribute]
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
        SupportedMod,
        AboutModGroup
    )]
    public partial class Setting : ModSetting
    {
        private readonly GameSettingsBackup GameSettingsBackup = new();
        private readonly ModSettingsBackup ModSettingsBackup = new();
        private readonly KeybindsBackup KeybindsBackup = new();
        private readonly ProfileNameBackup ProfileNameBackup = new();

        public const string BackupTab = "BackupTab";
        public const string BackupGroup = "BackupGroup";

        public const string ModListTab = "ModListTab";
        public const string ModsListSortGroup = "ModsListSortGroup";
        public const string CodeModsGroup = "CodeModsGroup";
        public const string PackageModsGroup = "PackageModsGroup";

        public const string VerifyTab = "VerifyTab";
        public const string ModVerifyGroup = "ModVerifyGroup";
        public const string ModCleanupGroup = "ModCleanupGroup";

        public const string ProfileNameTab = "ProfileNameTab";

        public const string ModInfo = "ModInfo";
        public const string SupportedMod = "SupportedMod";

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
        public bool EnableVerboseLogging { get; set; } = false;

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
        [SettingsUIDisplayName(overrideValue: "Get Settings Files")]
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
        public bool ReadyForVerify => !(!VerifyRunning && !WorldHelper.IsGameOrEditor);

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

        [SettingsUIButton]
        [SettingsUISection(ModListTab, ModsListSortGroup)]
        public bool ReinitializeModList
        {
            set { WorldHelper.GetSystem<ModCheckup>().Initialize(); }
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
        [SettingsUIDropdown(typeof(Setting), nameof(GetModFolderList))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ModLoadedVersion))]
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

        [SettingsUIMultilineText]
        [SettingsUISection(VerifyTab, ModVerifyGroup)]
        [SettingsUIDisplayName(typeof(ModVerifier), nameof(ModVerifier.VerificationResultText))]
        public string VerificationResult => "";

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
            List<DropdownItem<string>> x = new();

            string[] roots = Mod.PDXModsPaths.Where(Directory.Exists).ToArray();

            if (roots.Length == 0)
                return x.ToArray();

            IOrderedEnumerable<string> directories = roots
                .SelectMany(root => Directory.GetDirectories(root))
                .Where(f => ModCheckup.ModFolderPattern.IsMatch(Path.GetFileName(f)))
                .OrderBy(f => int.Parse(Path.GetFileName(f).Split('_')[0]))
                .ThenBy(f => int.Parse(Path.GetFileName(f).Split('_')[1]));

            foreach (string subfolder in directories)
            {
                string modFolder = Path.GetFileName(subfolder);
                string[] modFolderParts = modFolder.Split('_');

                string modId = modFolderParts.Length == 2 ? modFolderParts[0] : "";

                PDX.SDK.Contracts.Service.Mods.Interfaces.IModDetails mod =
                    ModCheckup.GetLocalModData(modId);

                if (LogHelper.CheckNull(mod, $"{subfolder} is null", level: LogLevel.Info))
                {
                    x.Add(
                        new DropdownItem<string>
                        {
                            value = subfolder.Replace("\\", "/"),
                            displayName = $"⚠️⚠️⚠️ {modFolder} - Mod May Has Issue, Verify Now",
                        }
                    );
                    continue;
                }

                string modName = modId;

                if (modFolderParts.Length == 2)
                    modName = mod.DisplayName ?? modId;

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
            ModFolderDropdown = "";
        }
    }
}
