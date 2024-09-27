// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using SimpleModChecker.Systems;
using System;
using System.Collections.Generic;
using UnityEngine.Device;

namespace SimpleModCheckerPlus
{
    [FileLocation($"ModsSettings\\StarQ\\{Mod.Name}")]
    [SettingsUITabOrder(MainTab, ProfileNameTab, AboutTab)]
    [SettingsUIGroupOrder(OptionsGroup, BackupGroup, ProfileNameGroup, InfoGroup, ModInfo)]
    [SettingsUIShowGroupName(OptionsGroup, BackupGroup, ModInfo)]
    public class Setting : ModSetting
    {
        public static Setting Instance;

        private readonly GameSettingsBackup GameSettingsBackup = new();
        private readonly ModSettingsBackup ModSettingsBackup = new();

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        public const string MainTab = "Main";
        
        public const string OptionsGroup = "Options";
        public const string BackupGroup = "Settings Backup";

        public const string ProfileNameTab = "Profile Names";
        public const string ProfileNameGroup = ProfileNameTab;

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";
        public const string ModInfo = "About the Mod";

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool ShowNotif { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteMissing { get; set; } = true;

        [SettingsUISection(MainTab, OptionsGroup)]
        public bool DeleteCorrupted { get; set; } = true;

        [SettingsUISection(MainTab, BackupGroup)]
        public bool AutoRestoreSettingBackupOnStartup { get; set; } = true;

        [SettingsUIDropdown(typeof(Setting), nameof(GetIntDropdownItems))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ProfileListVersion))]
        [SettingsUISection(MainTab, BackupGroup)]
        public int ProfileDropdown { get; set; } = 1;

        public int ProfileListVersion { get; set; }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateGameBackup { set { GameSettingsBackup.CreateBackup(ProfileDropdown); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreGameBackup { set { GameSettingsBackup.RestoreBackup(ProfileDropdown); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateModBackup { set { ModSettingsBackup.CreateBackup(ProfileDropdown); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreModBackup { set { ModSettingsBackup.RestoreBackup(ProfileDropdown); } }

        //[SettingsUISection(MainTab, BackupGroup)]
        //public bool GetSettingsFiles { set { ModSettingsBackup.GetSettingsFiles(); } }

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => "StarQ";

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
                    Mod.log.Error(e);
                }
            }
        }

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
            set
            {
                profileName1 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName2 = "Profile 2";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName2
        {
            get => profileName2;
            set
            {
                profileName2 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName3 = "Profile 3";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName3
        {
            get => profileName3;
            set
            {
                profileName3 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName4 = "Profile 4";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName4
        {
            get => profileName4;
            set
            {
                profileName4 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName5 = "Profile 5";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName5
        {
            get => profileName5;
            set
            {
                profileName5 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName6 = "Profile 6";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName6
        {
            get => profileName6;
            set
            {
                profileName6 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName7 = "Profile 7";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName7
        {
            get => profileName7;
            set
            {
                profileName7 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName8 = "Profile 8";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName8
        {
            get => profileName8;
            set
            {
                profileName8 = value;
                ++ProfileListVersion;
            }
        }
        private string profileName9 = "Profile 9";
        [SettingsUIAdvanced]
        [SettingsUISection(ProfileNameTab, ProfileNameGroup)]
        [SettingsUITextInput]
        public string ProfileName9
        {
            get => profileName9;
            set
            {
                profileName9 = value;
                ++ProfileListVersion;
            }
        }

        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod1 => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod2 => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod3 => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod4 => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod5 => "";
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheModX => "";

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
        }

    }
}