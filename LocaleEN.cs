// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal;
using System.Collections.Generic;

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
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AutoRestoreSettingBackupOnStartup)), "Enable or disable the automatic restoring of all game settings from Profile 1 when the game starts." },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateBackup1)), "Backup Settings (Profile 1)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateBackup1)), "Backup Game Settings in Profile 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreBackup1)), "Restore Settings (Profile 1)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreBackup1)), "Restore Game Settings in Profile 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateBackup2)), "Backup Settings (Profile 2)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateBackup2)), "Backup Game Settings in Profile 2." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreBackup2)), "Restore Settings (Profile 2)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreBackup2)), "Restore Game Settings in Profile 2." },

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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod5)), "◉ [NEW] Backup/Restore Settings (Profile 1 & 2): Manually backup and restore vanilla game settings in Profile 1 or Profile 2." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod5)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheModX)), "(Keybinds and mod settings are not yet supported but is on the roadmap.)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheModX)), "" },
            };
        }

        public void Unload()
        {
        }
    }
}