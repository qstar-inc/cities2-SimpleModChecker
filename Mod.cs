using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Colossal.PSI.Environment;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Game.Settings;
using SimpleModCheckerPlus.Systems;
using StarQ.Shared.Extensions;
using Unity.Entities;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public static string Id = nameof(SimpleModCheckerPlus);
        public const string Name = "Simple Mod Checker Plus";
        public static string Version = Assembly
            .GetExecutingAssembly()
            .GetName()
            .Version.ToString(3);

        public static Setting Setting;
        public CocCleaner CocCleaner;

        public static readonly string logFileName = nameof(SimpleModCheckerPlus);
        public static ILog log = LogManager
            .GetLogger(nameof(SimpleModCheckerPlus))
            .SetShowsErrorsInUI(true);
        public static ModManager modManager = GameManager.instance.modManager;
        public static readonly string modDatabaseJson =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModDatabase.json";
        public static string localBackupPath;
        public static ModDatabaseMetadata oldMetadata;
        public static ModDatabaseMetadata newMetadata;

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogHelper.Init(Id, log);
            LocaleHelper.Init(Id, GetReplacements);

            foreach (var item in new LocaleHelper($"{Id}.Locale.json").GetAvailableLanguages())
            {
                GameManager.instance.localizationManager.AddSource(item.LocaleId, item);
            }

            GameManager.instance.localizationManager.onActiveDictionaryChanged +=
                LocaleHelper.OnActiveDictionaryChanged;

            //LogHelper.SendLog($"Starting up {Name} {Version}");
            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            //LogHelper.SendLog($"Loading from \"{asset.path}\"");
            localBackupPath = $"{Directory.GetParent(asset.path).FullName}\\ModDatabase.json";
            Setting = new Setting(this);
            Setting.RegisterInOptionsUI();
            Setting.Instance = Setting;
            AssetDatabase.global.LoadSettings(
                nameof(SimpleModCheckerPlus),
                Setting,
                new Setting(this)
            );

            Task.Run(() => MigrateFiles(Directory.GetParent(modDatabaseJson).FullName)).Wait();

            Task.Run(() => ModDatabase.GetModDatabase()).Wait();
            Task.Run(() => ModDatabase.LoadModDatabase()).Wait();

#if DEBUG
            Setting.DeletedBackupCIDs = false;
            Setting.EnableVerboseLogging = true;
#endif

            if (!Setting.DeletedBackupCIDs)
                Task.Run(() => ModVerifier.RemoveBackupCID()).Wait();
            //GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            Setting.VerifiedRecently = false;
            Setting.IsInGameOrEditor = false;
            Setting.ModFolderDropdown = "";

            if (Setting.DisableContinueInGame)
                SharedSettings.instance.userState.lastSaveGameMetadata = null;

            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModCheckup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CocCleaner>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ProfileNameBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<GameSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<KeybindsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<MakeSomeNoise>();
        }

        public void OnDispose()
        {
            try
            {
                if (Setting.DisableContinueInGame)
                {
                    if (Setting.EnableVerboseLogging)
                        LogHelper.SendLog("Setting lastSaveGameMetadata to null");
                    SharedSettings.instance.userState.lastSaveGameMetadata = null;
                }

                if (Setting.DisableContinueOnLauncher)
                {
                    if (Setting.EnableVerboseLogging)
                        LogHelper.SendLog("Deleting continue_game.json");
                    File.Delete($"{EnvPath.kUserDataPath}/continue_game.json");
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }

            //if (Setting.DeleteMissing && CIDBackupRestore.CanDelete.Count > 0)
            //{
            //    CIDBackupRestore.DeleteFolders();
            //}

            if (Setting.DeleteCorrupted && CocCleaner.CanDelete.Count > 0)
                CocCleaner.DeleteFolders();
            Setting.VerifiedRecently = false;
            Setting.IsInGameOrEditor = false;
            Setting.ModFolderDropdown = "";
            Setting.UnregisterInOptionsUI();
            LogHelper.SendLog($"Shutting down {Name}");
        }

        public static Dictionary<string, string> GetReplacements()
        {
            return new()
            {
                { "SupportedMods", GetListOfSupportedMods() },
                {
                    "CodeCountSuffix",
                    ModCheckup.codes.Count > 1 ? $"{{{Id}.CodePlural}}" : $"{{{Id}.CodeSingular}}"
                },
                {
                    "PackageCountSuffix",
                    ModCheckup.packages.Count > 1
                        ? $"{{{Id}.PackagePlural}}"
                        : $"{{{Id}.PackageSingular}}"
                },
                {
                    "SortDetails",
                    $"{Setting.TextSort} - {(Setting.TextSortAscending ? "Ascending" : "Descending")}"
                },
            };
        }

        public static string GetListOfSupportedMods()
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
                finalLine = string.Join("\n", finalLine, line);
            }
            return finalLine;
        }

        public static async Task MigrateFiles(string folder)
        {
            string backupFolder = Path.Combine(folder, "SettingsBackup");

            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
                LogHelper.SendLog($"Created backup folder: {backupFolder}");
            }

            string[] filePatterns = new string[]
            {
                "GameSettings*",
                "ModSettings*",
                "ProfileName*",
            };

            foreach (var pattern in filePatterns)
            {
                var files = Directory.GetFiles(folder, pattern);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(backupFolder, fileName);
                    await Task.Run(() => File.Move(file, destinationPath));
                    LogHelper.SendLog($"Moved file: {file} to {destinationPath}");
                }
            }

            string prevFolder = Path.Combine(folder, "_prev");
            if (Directory.Exists(prevFolder))
            {
                string destinationPath = Path.Combine(backupFolder, "_prev");
                await Task.Run(() => MoveDirectory(prevFolder, destinationPath));
            }
        }

        private static void MoveDirectory(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
                LogHelper.SendLog($"Created backup folder: {destinationDir}");
            }
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Move(file, destFile);
                LogHelper.SendLog($"Moved file: {file} to {destFile}");
            }
            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(dir);
                string destDir = Path.Combine(destinationDir, dirName);
                MoveDirectory(dir, destDir);
            }
            Directory.Delete(sourceDir);
            LogHelper.SendLog($"Deleted source directory: {sourceDir}");
        }
    }
}
