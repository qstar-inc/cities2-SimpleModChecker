// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game.Modding;
using Game.SceneFlow;
using Game;
using SimpleModChecker.Systems;
using Unity.Entities;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public const string Name = "Simple Mod Checker Plus";
        public const string Version = "2.2.3";
        
        public static Setting Setting;
        public ModNotification ModNotification;
        public CIDBackupRestore CIDBackupRestore;
        public CocCleaner CocCleaner;

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
            

            ModNotification = new ModNotification();
            CIDBackupRestore = new CIDBackupRestore(this);
            CocCleaner = new CocCleaner(this);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(ModNotification);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(CIDBackupRestore);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(CocCleaner);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<GameSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModSettingsBackup>();
        }

        public void OnDispose()
        {
            if (Setting.DeleteMissing && CIDBackupRestore.CanDelete.Count > 0)
            {
                CIDBackupRestore.DeleteFolders();
            }

            if (Setting.DeleteCorrupted && CocCleaner.CanDelete.Count > 0)
            {
                CocCleaner.DeleteFolders();
            }

            MakeBackupOfModsData.MakePrev();
            log.Info($"Shutting down {Name}");
        }
    }
}