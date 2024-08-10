// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal;
using Colossal.IO.AssetDatabase;
using Colossal.IO.AssetDatabase.Internal;

using Game.Modding;
using Game.Settings;
using System.Collections.Generic;
using static Colossal.IO.AssetDatabase.AssetDatabase;

namespace SimpleModCheckerPlus
{
    [FileLocation($"ModsSettings\\StarQ\\{Mod.ModName}")]
    public class SimpleModCheckerSetting : ModSetting
    {
        public static SimpleModCheckerSetting Instance;
        public SimpleModCheckerSetting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        //public bool ShowNotif { get; set; }

        public bool ShowNotif { get; set; } = true;
        public bool DeleteMissing { get; set; } = true;
        public bool DeleteCorrupted { get; set; } = true;
        public bool EnableAutoSave { get; set; } = true;
        public bool DisableRadio { get; set; } = true;
        public string ModVersion => Mod.Version;

        public override void SetDefaults()
        {
            ShowNotif = true;
            DeleteMissing = true;
            DeleteCorrupted = true;
            EnableAutoSave = true;
            DisableRadio = true;
        }

    }

    public class LocaleEN(SimpleModCheckerSetting setting) : IDictionarySource
    {
        private readonly SimpleModCheckerSetting m_Setting = setting;

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.ModName },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.ShowNotif)), "Show Notification?" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.ShowNotif)), "Enable or disable the Main Menu notification." },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.DeleteMissing)), "Auto delete Mods with Missing CIDs?" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.DeleteMissing)), "Enable or disable the automatic deletion of mods with missing CIDs." },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.DeleteCorrupted)), "Auto delete Corrupted Settings?" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.DeleteCorrupted)), "Enable or disable the automatic deletion of corrupted settings." },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.EnableAutoSave)), "Auto enable Auto save on Settings Crash?" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.EnableAutoSave)), "Enable or disable the automatic activation of autosave in the event of accidental game settings reset." },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.DisableRadio)), "Auto disable Radio on Settings Crash?" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.DisableRadio)), "Enable or disable the automatic deactivation of radio in the event of accidental game settings reset." },
                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.ModVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.ModVersion)), $"Current running version of {Mod.ModName}" },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]", Mod.ModName },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]", "Loaded {modCount} mod." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]", "Loaded {modCount} mods." },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]", $$"""{{ Mod.ModName }}: Found {fileCount} corrupted Settings file""" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]", "Click here to delete and restart to prevent errors..." },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoSave]", "Auto Save enabled" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DisableRadio]", "Radio disabled" },
                { "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", $$"""{{Mod.ModName}}: Found {modCount} mod(s) with missing CIDs""" },
                { "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]", "Click here to delete and restart to prevent errors..." },
            };
        }

        public void Unload()
        {
        }
    }
}