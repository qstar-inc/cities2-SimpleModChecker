// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using SimpleModChecker.Systems;
using System;
using UnityEngine.Device;

namespace SimpleModCheckerPlus
{
    [FileLocation($"ModsSettings\\StarQ\\{Mod.Name}")]
    [SettingsUITabOrder(MainTab, AboutTab)]
    [SettingsUIGroupOrder(OptionsGroup, BackupGroup, InfoGroup, ModInfo)]
    [SettingsUIShowGroupName(OptionsGroup, BackupGroup, ModInfo)]
    public class Setting : ModSetting
    {
        public static Setting Instance;

        private readonly GameSettingsBackup SettingsBackup = new();

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        public const string MainTab = "Main";

        public const string OptionsGroup = "Options";
        public const string BackupGroup = "Game Settings Backup";

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

        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateBackup1 { set { SettingsBackup.CreateBackup(1); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreBackup1 { set { SettingsBackup.RestoreBackup(1); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool CreateBackup2 { set { SettingsBackup.CreateBackup(2); } }

        [SettingsUISection(MainTab, BackupGroup)]
        public bool RestoreBackup2 { set { SettingsBackup.RestoreBackup(2); } }

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

        public override void SetDefaults()
        {
            ShowNotif = true;
            DeleteMissing = true;
            DeleteCorrupted = true;
            AutoRestoreSettingBackupOnStartup = true;
        }

    }
}