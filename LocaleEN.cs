// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System.Collections.Generic;
using Colossal;
using Game.Modding;
using SimpleModCheckerPlus.Systems;

namespace SimpleModCheckerPlus
{
    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public static ModManager modManager;

        public string GetListOfSupportedMods()
        {
            string finalLine = "";
            List<ModInfo> sortedMods = ModInfoProcessor.SortByAuthor_Mod_ID();
            foreach (var entry in sortedMods)
            {
                if (entry.Backupable != true)
                    continue;
                string name = entry.ModName;
                string id = entry.PDX_ID;
                string author = entry.Author;

                string line = $"- {author} — {id}: <{name}>";
                finalLine = string.Join("\r\n", finalLine, line);
            }
            return finalLine;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts
        )
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.Name },
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), Setting.MainTab },
                { m_Setting.GetOptionTabLocaleID(Setting.ModListTab), Setting.ModListTab },
                { m_Setting.GetOptionTabLocaleID(Setting.ProfileNameTab), Setting.ProfileNameTab },
                { m_Setting.GetOptionTabLocaleID(Setting.VerifyTab), Setting.VerifyTab },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },
                { m_Setting.GetOptionGroupLocaleID(Setting.OptionsGroup), Setting.OptionsGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.BackupGroup), Setting.BackupGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.CodeModsGroup), Setting.CodeModsGroup },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.PackageModsGroup),
                    Setting.PackageModsGroup
                },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.ModVerifyGroup),
                    Setting.ModVerifyGroup
                },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.ProfileNameGroup),
                    Setting.ProfileNameGroup
                },
                { m_Setting.GetOptionGroupLocaleID(Setting.ModInfo), Setting.ModInfo },
                { m_Setting.GetOptionGroupLocaleID(Setting.SupportedMod), Setting.SupportedMod },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShowNotif)),
                    "Show Notification?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ShowNotif)),
                    "Enable the Main Menu notification."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PlaySound)), "Play Sound?" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PlaySound)),
                    "Enable playing a small audio sound on mods loading completed."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DisableContinueOnLauncher)),
                    "Disable \"Resume\" button on the Paradox Launcher?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DisableContinueOnLauncher)),
                    "Disable showing the \"Resume\" button on the Paradox Launcher, so it's not clicked accidentally."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DisableContinueInGame)),
                    "Disable \"Continue Game\" button on the Main Menu?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DisableContinueInGame)),
                    "Disable showing the \"Continue Game\" button on the Main Menu, so it's not clicked accidentally."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DeleteCorrupted)),
                    "Auto delete Corrupted Settings?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DeleteCorrupted)),
                    "Enable the automatic deletion of corrupted settings (game or mod)."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(Setting.AutoRestoreSettingBackupOnStartup)
                    ),
                    "Auto Restore Settings on Startup (Profile 1)?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(Setting.AutoRestoreSettingBackupOnStartup)
                    ),
                    "Enable the automatic restoring of all game settings, supported mods settings and all keybinds from Profile 1 when the game starts."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableVerboseLogging)),
                    "Enable Verbose Logging?"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableVerboseLogging)),
                    "Enable detailed logging to catch issues (only to be used for debugging purpose)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName1)), "Profile 1" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName1)),
                    "Rename Profile 1."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName2)), "Profile 2" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName2)),
                    "Rename Profile 2."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName3)), "Profile 3" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName3)),
                    "Rename Profile 3."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName4)), "Profile 4" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName4)),
                    "Rename Profile 4."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName5)), "Profile 5" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName5)),
                    "Rename Profile 5."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName6)), "Profile 6" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName6)),
                    "Rename Profile 6."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName7)), "Profile 7" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName7)),
                    "Rename Profile 7."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName8)), "Profile 8" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName8)),
                    "Rename Profile 8."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileName9)), "Profile 9" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileName9)),
                    "Rename Profile 9."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.SaveProfileName)),
                    "Save Profile Names"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.SaveProfileName)),
                    "Save Profile Names after typing the entries."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProfileDropdown)),
                    "Select Profile"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ProfileDropdown)),
                    $"Select the profile to be used for the buttons below. Profile 1 will be auto restored on launch if the \"Auto Restore Settings on Startup (Profile 1)?\" is active.\r\nThe profile names can be changed from the \"Profile Names\" tab."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateGameBackup)),
                    "Backup Game Settings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateGameBackup)),
                    "Backup Game Settings to the selected profile."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreGameBackup)),
                    "Restore Game Settings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreGameBackup)),
                    "Restore Game Settings from the selected profile."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateModBackup)),
                    "Backup Mod Settings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateModBackup)),
                    "Backup Mod Settings to the selected profile."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreModBackup)),
                    "Restore Mod Settings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreModBackup)),
                    "Restore Mod Settings from the selected profile."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CreateKeybindsBackup)),
                    "Backup Keybinds"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CreateKeybindsBackup)),
                    "Backup Keybinds to the selected profile."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RestoreKeybindsBackup)),
                    "Restore Keybinds"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RestoreKeybindsBackup)),
                    "Restore Keybinds from the selected profile."
                },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModsLoaded)), "" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.ModsLoaded)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CodeMods)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CodeMods)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PackageMods)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PackageMods)), "" },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModFolderDropdown)),
                    "Select Mod for Verification"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModFolderDropdown)),
                    "Select a mod package and to verify only that package."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerifyMods)), "Verify All Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerifyMods)),
                    "Verify all mods downloaded from PDX Mods and currently stored on disk.\r\nThe process will take some time depending on the number and size of the mods.\r\n- Please do not run this while in game/editor.\r\n- Please do not launch game/editor while the verification is running."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerifyModSelected)),
                    "Verify Selected Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerifyModSelected)),
                    "Verify only the mod package selected above which are downloaded from PDX Mods and currently stored on disk.\r\nThe process will take some time depending on the number and size of the mods.\r\n- Please do not run this while in game/editor.\r\n- Please do not launch game/editor while the verification is running."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerificationResult)), "" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerificationResult)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log File" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Open the log file for the mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CleanUpOldVersions)),
                    "Clean Up Old Mod Versions"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CleanUpOldVersions)),
                    "Clean up all playsets where old versions of mods are still subscribed where a more latest version is available."
                },
                //{ m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModsWithIssueLoaded)), "" },
                //{ m_Setting.GetOptionDescLocaleID(nameof(Setting.ModsWithIssueLoaded)), "List of mods with issues loaded in this session." },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModDatabaseTime)),
                    "Mod Database Time"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ModDatabaseTime)),
                    "The time when the current mod database was published."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)),
                    "Support the author."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Discord)), "Discord" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Discord)),
                    "Feedback/Suggestions for the mod in the Cities: Skylines Modding Server."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)),
                    "This mod offers utility features for managing mods and various settings in Cities: Skylines II:\r\nFeautures\r\n- Mod Loaded Notification: Get a main menu notifications on startup which shows how many mod is loaded in this session. A list of assemblies can be found on the Mod List tab.\r\n- Auto Delete Mods with Missing CIDs: Automatically remove asset/map packages with missing Content IDs.\r\n- Auto Delete Corrupted Settings: In an event when the game crashes without improper disposing, the settings files for various mods or the game itself can get corrupted. Automatically delete those corrupted settings files.\r\n- Backup/Restore Settings: Manually backup and restore vanilla game settings and mod settings separately in 9 profiles.\r\n- Auto Restore Settings on Startup (Profile 1): Automatically restore vanilla game settings and supported mod settings from Profile 1 on startup after accidental resets.\r\n- [NEW] Backup/restore keybinds from vanilla game or any mods!\r\n- [NEW] Mod verification."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.SupportedModText)),
                    GetListOfSupportedMods()
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.SupportedModText)),
                    "A list of currently supported mod for settings backup/restore."
                },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]", Mod.Name },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]",
                    "Loaded {codeCount} mod."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]",
                    "Loaded {codeCount} mods."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackage]",
                    "Loaded {codeCount} mod and {packageCount} package."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackage]",
                    "Loaded {codeCount} mods and {packageCount} package."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModAndPackages]",
                    "Loaded {codeCount} mod and {packageCount} packages."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedModsAndPackages]",
                    "Loaded {codeCount} mods and {packageCount} packages."
                },
                {
                    "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]",
                    "SMC+: Found {fileCount} corrupted Settings file"
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]",
                    "Click here to delete and restart to prevent errors..."
                },
                {
                    "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]",
                    "SMC+: Found {modCount} mod(s) with missing CIDs"
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]",
                    "Click here to delete and restart to prevent errors..."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.RestoreGame]",
                    "Restored game settings..."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.RestoreMods]",
                    "Restored mod settings..."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.RestoreKeybinds]",
                    "Restored keybinds..."
                },
                {
                    "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeModBackup]",
                    $"SMC+: The mod has updated."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeModBackup]",
                    "Click here to recreate your Profile 1 (Mod) again..."
                },
                {
                    "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeGameBackup]",
                    $"SMC+: The game has updated."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeGameBackup]",
                    "Click here to recreate your Profile 1 (Game) again..."
                },
                {
                    "Menu.ERROR[SimpleModCheckerPlus.Missing_CID_Exception]",
                    "Found {modCount} mods with missing CID with no backup:\r\n{modList}\r\nSMC+ will handle the deletion of these folders on exit. On next restart, the missing mods will be redownloaded automatically."
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.VerifyStart]",
                    "Starting Mod Verification"
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.VerifyingMods]",
                    "Verifying mods: {modCount} out of {total} ({modName})"
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.VerifyEnd]",
                    "Mod Verification completed. Click here for details"
                },
                {
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.VerifyFailed]",
                    "Mod Verification failed."
                },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.Working]", "Working..." },
            };
        }

        public void Unload() { }
    }
}
