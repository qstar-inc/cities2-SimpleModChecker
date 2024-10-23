// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal;
using Game.Modding;
using SimpleModChecker.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SimpleModCheckerPlus
{

    public class LocaleEN(Setting setting) : IDictionarySource
    {
        private readonly Setting m_Setting = setting;

        public static ModManager modManager;

        public string GetListOfSupportedMods()
        {
            string finalLine = "";
            List<ModInfo> sortedMods = ModInfoProcessor.SortByAuthor_Mod_ID();
            foreach (var entry in sortedMods)
            {
                if (entry.Backupable != true) continue;
                string name = entry.ModName;
                string id = entry.PDX_ID;
                string author = entry.Author;

                string line = $"- {author} — {id}: <{name}>";
                finalLine = string.Join("\r\n", finalLine, line);
            }
            return finalLine;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.Name },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), Setting.MainTab },
                { m_Setting.GetOptionTabLocaleID(Setting.ModListTab), Setting.ModListTab },
                { m_Setting.GetOptionTabLocaleID(Setting.ProfileNameTab), Setting.ProfileNameTab },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { m_Setting.GetOptionGroupLocaleID(Setting.OptionsGroup), Setting.OptionsGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.BackupGroup), Setting.BackupGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ModUtilityGroup), Setting.ModUtilityGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ModListGroup), Setting.ModListGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ProfileNameGroup), Setting.ProfileNameGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ModInfo), Setting.ModInfo },
                { m_Setting.GetOptionGroupLocaleID(Setting.SupportedMod ), Setting.SupportedMod },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShowNotif)), "Show Notification?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ShowNotif)), "Enable or disable the Main Menu notification." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeleteMissing)), "Auto delete Mods with Missing CIDs?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DeleteMissing)), "Enable or disable the automatic deletion of mods with missing CIDs. These mods will be automatically redownloaded with the CIDs next time by Skyve or the game on next start." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeleteCorrupted)), "Auto delete Corrupted Settings?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DeleteCorrupted)), "Enable or disable the automatic deletion of corrupted settings (game or mod)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AutoRestoreSettingBackupOnStartup)), "Auto Restore Settings on Startup (Profile 1)?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AutoRestoreSettingBackupOnStartup)), "Enable or disable the automatic restoring of all game settings and supported mods settings from Profile 1 when the game starts." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableVerboseLogging)), "Enable Verbose Logging?" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableVerboseLogging)), "Enable or disable detailed logging to catch issues (only to be used for debugging purpose)." },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateProfileNameBackup)), "Save Profile Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateProfileNameBackup)), "Save Profile Names after typing the entries." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileDropdown)), "Select Profile" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileDropdown)), $"Select the profile to be used for the buttons below. Profile 1 will be auto restored on launch if the \"Auto Restore Settings on Startup (Profile 1)?\" is active.\r\nThe profile names can be changed from the \"Profile Names\" tab after toggling \"<[Show Advanced]>\"." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateGameBackup)), "Backup Game Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateGameBackup)), "Backup Game Settings to the selected profile." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreGameBackup)), "Restore Game Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreGameBackup)), "Restore Game Settings from the selected profile." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateModBackup)), "Backup Mod Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateModBackup)), "Backup Mod Settings to the selected profile." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreModBackup)), "Restore Mod Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreModBackup)), "Restore Mod Settings from the selected profile." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModsLoaded)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModsLoaded)), "List of mods loaded in this session." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RefreshModDatabase)), "Refresh Mod Database" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RefreshModDatabase)), "Refresh Mod Database from the Internet." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModDatabaseTime)), "Mod Database Time" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModDatabaseTime)), "The time when the current mod database was published." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)), "Support the author." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Discord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Discord)), "Feedback/Suggestions for the mod in the Cities: Skylines Modding Server." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)), "This mod offers utility features for managing mods and various settings in Cities: Skylines II:\r\nFeautures\r\n- Mod Loaded Notification: Get a main menu notifications on startup which shows how many mod is loaded in this session. A list of assemblies can be found on the Mod List tab.\r\n- Auto Delete Mods with Missing CIDs: Automatically remove asset/map packages with missing Content IDs.\r\n- Auto Delete Corrupted Settings: In an event when the game crashes without improper disposing, the settings files for various mods or the game itself can get corrupted. Automatically delete those corrupted settings files.\r\n- [NEW] Backup/Restore Settings: Manually backup and restore vanilla game settings and mod settings separately in 9 profiles.\r\n- Auto Restore Settings on Startup (Profile 1): Automatically restore vanilla game settings and supported mod settings from Profile 1 on startup after accidental resets.\r\nKeybind backup/restore is not supported (yet)!" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SupportedModText)), GetListOfSupportedMods() },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SupportedModText)), "A list of currently supported mod for settings backup/restore." },

                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]", Mod.Name },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]", "Loaded {modCount} mod." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]", "Loaded {modCount} mods." },

                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]", "SMC+: Found {fileCount} corrupted Settings file" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]", "Click here to delete and restart to prevent errors..." },
                
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", "SMC+: Found {modCount} mod(s) with missing CIDs" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]", "Click here to delete and restart to prevent errors..." },
                
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreGame]", "Auto Restored game settings on game startup..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreMods]", "Auto Restored mod settings on game startup..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloadStarting]", "Mod Database is now being downloaded..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloaded]", "Mod Database has been updated, it is recommended to restart the game..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseLocalCopy]", "Using offline Mod Database. Click to dismiss..." },

                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeModBackup]", $"{Mod.Name} has updated." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeModBackup]", "Click here to recreate your Profile 1 (Mod) again..." },

                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeGameBackup]", $"The game has updated." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeGameBackup]", "Click here to recreate your Profile 1 (Game) again..." },

                { "Menu.ERROR[SimpleModCheckerPlus.Missing_CID_Exception]", "Found {modCount} mods with missing CID with no backup:\r\n{modList}\r\nSMC+ will handle the deletion of these folders on exit. On next restart, the missing mods will be redownloaded automatically." },
            };
        }

        public void Unload()
        {
        }
    }
}