// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.Logging;
using Game.Modding;
using Game.SceneFlow;
using Game;
using Unity.Entities;
using Colossal.IO.AssetDatabase;
using SimpleModChecker.Systems;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public const string Name = "Simple Mod Checker Plus";
        public const string Version = "2.2.2";
        
        public static Setting Setting;
        public ModNotification _modNotification;
        public CIDBackupRestore _cidBackupRestore;
        public CocCleaner _cocCleaner;
        //public SettingsChanger _settingsChanger;

        public static readonly string logFileName = nameof(SimpleModCheckerPlus);
        public static ILog log = LogManager.GetLogger(nameof(SimpleModCheckerPlus)).SetShowsErrorsInUI(true);
        public static ModManager modManager = GameManager.instance.modManager;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info($"Starting up {Name}");

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Loading from \"{asset.path}\"");

            Setting = new Setting(this);
            Setting.RegisterInOptionsUI();
            Setting.Instance = Setting;
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            AssetDatabase.global.LoadSettings(nameof(SimpleModCheckerPlus), Setting, new Setting(this));
            

            _modNotification = new ModNotification(this);
            _cidBackupRestore = new CIDBackupRestore(this);
            _cocCleaner = new CocCleaner(this);
            //_settingsChanger = new SettingsChanger(this);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_modNotification);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_cidBackupRestore);
            //World.DefaultGameObjectInjectionWorld.AddSystemManaged(_settingsChanger);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_cocCleaner);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<GameSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModSettingsBackup>();
        }

        public void OnDispose()
        {
            if (Setting.DeleteMissing && _cidBackupRestore.CanDelete.Count > 0)
            {
                _cidBackupRestore.DeleteFolders();
            }

            if (Setting.DeleteCorrupted && _cocCleaner.CanDelete.Count > 0)
            {
                _cocCleaner.DeleteFolders();
            }            
            
            log.Info($"Shutting down {Name}");
        }
    }
}