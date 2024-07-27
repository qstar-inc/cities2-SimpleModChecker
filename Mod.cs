// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.Logging;
using Game.Modding;
using Game.SceneFlow;
using Game;
using Unity.Entities;
using Colossal.IO.AssetDatabase;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public const string ModName = "Simple Mod Checker Plus";
        public const string Version = "2.1.3";
        
        public static SimpleModCheckerSetting Setting;
        public ModNotification _modNotification;
        public CIDBackupRestore _backupRestore;
        public CocCleaner _cocCleaner;
        public SettingsChanger _settingsChanger;

        public static readonly string logFileName = ModName;
        public static ILog log = LogManager.GetLogger(ModName).SetShowsErrorsInUI(true);

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info($"Starting up {ModName}");

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"DLL: {asset.path}");

            Setting = new SimpleModCheckerSetting(this);
            Setting.RegisterInOptionsUI();
            SimpleModCheckerSetting.Instance = Setting;
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            AssetDatabase.global.LoadSettings(nameof(SimpleModCheckerPlus), Setting, new SimpleModCheckerSetting(this));

            _modNotification = new ModNotification(this);
            _backupRestore = new CIDBackupRestore(this);
            _cocCleaner = new CocCleaner(this);
            _settingsChanger = new SettingsChanger(this);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_modNotification);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_backupRestore);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_settingsChanger);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_cocCleaner);
        }

        public void OnDispose()
        {
            if (Setting.DeleteMissing && _backupRestore.deleteables.Count > 0)
            {
                _backupRestore.DeleteFolders();
            }

            if (Setting.DeleteCorrupted && _cocCleaner.deleteables.Count > 0)
            {
                _cocCleaner.DeleteFolders();
            }            
            
            log.Info($"Shutting down {ModName}");
        }
    }
}