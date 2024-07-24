// Simple Mod Checker
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using System.Collections.Generic;

namespace SimpleModChecker
{
    [FileLocation($"ModsSettings\\{Mod.ModName}\\{Mod.ModName}")]
    public class SimpleModCheckerSetting : ModSetting
    {
        public static SimpleModCheckerSetting Instance;
        public SimpleModCheckerSetting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        //public bool ShowNotif { get; set; }

        public bool ShowNotif { get; set; }
        public bool DeleteMissing { get; set; }
        public bool DeleteCorrupted { get; set; }
        public bool EnableAutoSave { get; set; }
        public bool DisableRadio { get; set; }

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
            };
        }

        public void Unload()
        {
        }
    }
}