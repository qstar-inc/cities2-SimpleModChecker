//using Colossal;
//using Colossal.IO.AssetDatabase;
//using Game.Modding;
//using Game.Settings;
//using System.Collections.Generic;

//namespace SimpleModChecker
//{
//    [FileLocation("ModsSettings\\" + nameof(SimpleModChecker))]
//    public class SimpleModCheckerSetting : ModSetting
//    {
//        public SimpleModCheckerSetting(IMod mod) : base(mod)
//        {
//            SetDefaults();
//        }

//        public bool Toggle { get; set; }
        
//        [SettingsUIHidden]
//        public bool DummyItem { get; set; }

//        public override void SetDefaults()
//        {
//            Toggle = true;
//            DummyItem = true;
//        }
//    }

//    public class LocaleEN(SimpleModCheckerSetting setting) : IDictionarySource
//    {
//        private readonly SimpleModCheckerSetting m_Setting = setting;

//        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
//        {
//            return new Dictionary<string, string>
//            {
//                { m_Setting.GetSettingsLocaleID(), "Simple Mod Checker" },
//                { m_Setting.GetOptionLabelLocaleID(nameof(SimpleModCheckerSetting.Toggle)), "Show Notification?" },
//                { m_Setting.GetOptionDescLocaleID(nameof(SimpleModCheckerSetting.Toggle)), "Enable or disable the Main Menu notification. Applies on next restart" },
//            };
//        }

//        public void Unload()
//        {
//        }
//    }
//}