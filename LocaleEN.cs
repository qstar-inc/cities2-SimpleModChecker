// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal;
using Colossal.IO.AssetDatabase.Internal;
using Game.Settings;
using Game.UI.Widgets;
using System.Collections.Generic;
using static Colossal.AssetPipeline.Importers.ModelImporter;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using System.Reflection;
using System.Security.Cryptography;

namespace SimpleModCheckerPlus
{
    public class LocaleEN(Setting setting) : IDictionarySource
    {
        private readonly Setting m_Setting = setting;

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.Name },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), Setting.MainTab },
                { m_Setting.GetOptionTabLocaleID(Setting.ProfileNameTab), Setting.ProfileNameTab },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { m_Setting.GetOptionGroupLocaleID(Setting.OptionsGroup), Setting.OptionsGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.BackupGroup), Setting.BackupGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ModInfo), Setting.ModInfo },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShowNotif)), "Show Notification?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShowNotif)), "Enable or disable the Main Menu notification." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeleteMissing)), "Auto delete Mods with Missing CIDs?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DeleteMissing)), "Enable or disable the automatic deletion of mods with missing CIDs. These mods will be automatically redownloaded with the CIDs next time by Skyve or the game on next start." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeleteCorrupted)), "Auto delete Corrupted Settings?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DeleteCorrupted)), "Enable or disable the automatic deletion of corrupted settings (game or mod)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AutoRestoreSettingBackupOnStartup)), "Auto Restore Settings on Startup (Profile 1)?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AutoRestoreSettingBackupOnStartup)), "Enable or disable the automatic restoring of all game settings and supported mods settings from Profile 1 when the game starts." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName1)), "Profile 1" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName1)), "Rename Profile 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName2)), "Profile 2" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName2)), "Rename Profile 2." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName3)), "Profile 3" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName3)), "Rename Profile 3." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName4)), "Profile 4" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName4)), "Rename Profile 4." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName5)), "Profile 5" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName5)), "Rename Profile 5." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName6)), "Profile 6" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName6)), "Rename Profile 6." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName7)), "Profile 7" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName7)), "Rename Profile 7." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName8)), "Profile 8" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName8)), "Rename Profile 8." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName9)), "Profile 9" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName9)), "Rename Profile 9." },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileDropdown)), "Select Profile" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileDropdown)), $"Select the profile to be used for the buttons below. Profile 1 will be auto restored on launch if the \"Auto Restore Settings on Startup (Profile 1)?\" is active. The profile names can be changed from the \"Profile Names\" tab after toggling \"Show Advanced\"." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateGameBackup)), "Backup Game Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateGameBackup)), "Backup Game Settings to the selected profile." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreGameBackup)), "Restore Game Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreGameBackup)), "Restore Game Settings from the selected profile." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateModBackup)), "Backup Mod Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateModBackup)), "Backup Mod Settings to the selected profile. \r\nCurrently supported mods: \r\n◉ 529 Tiles\r\n◉ Anarchy\r\n◉ Asset Icon Library\r\n◉ Find It\r\n◉ I18n Everywhere\r\n◉ Plop The Growables\r\n◉ Simple Mod Checker Plus\r\nOther mods are coming soon." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreModBackup)), "Restore Mod Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreModBackup)), "Restore Mod Settings from the selected profile." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)), "Support the author." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)), "This mod provides options for managing mods and game settings in Cities: Skylines II:" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod1)), "◉ Show Notification?: Toggle main menu notifications on or off." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod1)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod2)), "◉ Auto Delete Mods with Missing CIDs?: Automatically remove packages with missing Content IDs." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod2)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod3)), "◉ Auto Delete Corrupted Settings?: Automatically delete corrupted settings files (game or mod)." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod3)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod4)), "◉ Auto Restore Settings on Startup (Profile 1)?: Automatically restore vanilla settings from Profile 1 on startup after accidental resets." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod4)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod5)), "◉ [NEW] Backup/Restore Settings: Manually backup and restore vanilla game settings and mod settings separately in 9 profiles." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod5)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheModX)), "(Keybinds and other mod settings are not yet supported but is on the roadmap.)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheModX)), "" },

                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]", Mod.Name },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]", "Loaded {modCount} mod." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]", "Loaded {modCount} mods." },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]", $$"""{{ Mod.Name }}: Found {fileCount} corrupted Settings file""" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]", "Click here to delete and restart to prevent errors..." },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", $$"""{{Mod.Name}}: Found {modCount} mod(s) with missing CIDs""" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]", "Click here to delete and restart to prevent errors..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreGame]", "Auto Restored game settings on game startup..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreMods]", "Auto Restored mod settings on game startup..." },
            };
        }

        public void Unload()
        {
        }
    }
}