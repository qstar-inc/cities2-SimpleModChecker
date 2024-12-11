﻿// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using SimpleModChecker.Systems;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine.Device;

namespace SimpleModCheckerPlus
{
    [FileLocation($"ModsSettings\\StarQ\\{Mod.Name}")]
    [SettingsUITabOrder(ModListTab, MainTab, ProfileNameTab, AboutTab)]
    [SettingsUIGroupOrder(ModListGroup, OptionsGroup, BackupGroup, ModUtilityGroup, ProfileNameGroup, InfoGroup, ModInfo, SupportedMod)]
    [SettingsUIShowGroupName(ModListGroup, OptionsGroup, BackupGroup, ModInfo, SupportedMod)]
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

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        public const string MainTab = "Options and Backup";

        public const string OptionsGroup = "Options";
        public const string BackupGroup = "Settings Backup";

        public const string ModListTab = "Loaded Mods";
        public const string ModUtilityGroup = "";
        public const string ModListGroup = "Loaded Mods";
        //public const string ModWithIssueListTab = "Mods with Issues";
        //public const string ModWithIssueListGroup = "Loaded Mods with Issues";

        public const string ProfileNameTab = "Profile Names";
        public const string ProfileNameGroup = ProfileNameTab;

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";
        public const string ModInfo = "About the Mod";
        public const string SupportedMod = "Currently Supported Mods for Mod Settings Backup";

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool ShowNotif { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteMissing { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteCorrupted { get; set; } = true;
        [SettingsUISection(MainTab, OptionsGroup)]
        public bool EnableVerboseLogging { get; set; } = true; // SET TO FALSE //

        [SettingsUISection(MainTab, BackupGroup)]
        public bool AutoRestoreSettingBackupOnStartup { get; set; } = true;

        [SettingsUIDropdown(typeof(Setting), nameof(GetIntDropdownItems))]
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

        //[SettingsUIButtonGroup("KeybindsBackup")]
        //[SettingsUIButton]
        //[SettingsUISection(MainTab, BackupGroup)]
        //public bool CreateKeybindsBackup { set { KeybindsBackup.CreateBackup(ProfileDropdown, EnableVerboseLogging); } }

        //[SettingsUIButtonGroup("KeybindsBackup")]
        //[SettingsUIButton]
        //[SettingsUISection(MainTab, BackupGroup)]
        //public bool RestoreKeybindsBackup { set { KeybindsBackup.RestoreBackup(ProfileDropdown, EnableVerboseLogging); } }

        //[SettingsUIAdvanced]
        //[SettingsUIDeveloper]
        //[SettingsUISection(MainTab, BackupGroup)]
        //public bool GetSettingsFiles { set { ModSettingsBackup.GetSettingsFiles(); } }

        [SettingsUIHidden]
        public int ModsLoadedVersion { get; set; }

        [SettingsUIAdvanced]
        [SettingsUISection(MainTab, BackupGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(RefreshedRecently))]
        public bool RefreshModDatabase { set { Task.Run(() => Mod.DownloadNow(2)); } }

        [SettingsUIHidden]
        public int ModDatabaseTimeVersion { get; set; }
        [SettingsUISection(MainTab, BackupGroup)]
        public string ModDatabaseTime => ModDatabase.ModDatabaseTime;

        [SettingsUIHidden]
        public bool RefreshedRecently { get; set; } = false;
        [SettingsUIHidden]
        public long LastDownloaded { get; set; } = (long)0;
        [SettingsUIHidden]
        public long LastChecked { get; set; } = (long)0;

        [SettingsUIMultilineText]
        [SettingsUISection(ModListTab, ModListGroup)]
        [SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.LoadedModsListLocalized))]
        public string ModsLoaded => "";

        //[SettingsUIAdvanced]
        //[SettingsUIMultilineText]
        //[SettingsUISection(ModWithIssueListTab, ModWithIssueListGroup)]
        //[SettingsUIDisplayName(typeof(ModCheckup), nameof(ModCheckup.LoadedModsListWithIssueLocalized))]
        //public string ModsWithIssueLoaded => "";

        [SettingsUIAdvanced]
        [SettingsUIHidden]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        public string ProfileName0 { get; set; } = "Profile Auto";

        private string profileName1 = "Profile 1";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName1
        {
            get => profileName1;
            set => profileName1 = value;
        }

        private string profileName2 = "Profile 2";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName2
        {
            get => profileName2;
            set => profileName2 = value;
        }

        private string profileName3 = "Profile 3";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName3
        {
            get => profileName3;
            set => profileName3 = value;
        }

        private string profileName4 = "Profile 4";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName4
        {
            get => profileName4;
            set => profileName4 = value;
        }

        private string profileName5 = "Profile 5";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName5
        {
            get => profileName5;
            set => profileName5 = value;
        }

        private string profileName6 = "Profile 6";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName6
        {
            get => profileName6;
            set => profileName6 = value;
        }

        private string profileName7 = "Profile 7";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName7
        {
            get => profileName7;
            set => profileName7 = value;
        }

        private string profileName8 = "Profile 8";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName8
        {
            get => profileName8;
            set => profileName8 = value;
        }

        private string profileName9 = "Profile 9";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName9
        {
            get => profileName9;
            set => profileName9 = value;
        }

        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUIButton]
        public bool CreateProfileNameBackup
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

        public DropdownItem<int>[] GetIntDropdownItems()
        {
            var profileNames = new[] { ProfileName0, ProfileName1, ProfileName2, ProfileName3, ProfileName4, ProfileName5, ProfileName6, ProfileName7, ProfileName8, ProfileName9 };
            var items = new List<DropdownItem<int>>();

            for (var i = 1; i < 10; i += 1)
            {
                items.Add(new DropdownItem<int>()
                {
                    value = i,
                    displayName = profileNames[i],
                });
            }

            return [.. items];
        }

        public override void SetDefaults()
        {
            ShowNotif = true;
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
            RefreshedRecently = false;
            LastDownloaded = (long)0;
            LastChecked = (long)0;
        }
    }
}