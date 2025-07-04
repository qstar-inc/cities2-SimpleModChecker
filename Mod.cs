﻿// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
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
using Newtonsoft.Json;
using SimpleModCheckerPlus.Systems;
using Unity.Entities;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
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
        private static readonly string modDatabaseJson =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModDatabase.json";
        public static string localBackupPath;
        public static ModDatabaseMetadata oldMetadata;
        public static ModDatabaseMetadata newMetadata;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info($"Starting up {Name} {Version}");
            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            log.Info($"Loading from \"{asset.path}\"");
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

            Task.Run(() => GetModDatabase()).Wait();
            Task.Run(() => ModDatabase.LoadModDatabase()).Wait();

#if DEBUG
            Setting.DeletedBackupCIDs = false;
#endif

            if (!Setting.DeletedBackupCIDs)
                Task.Run(() => ModVerifier.RemoveBackupCID()).Wait();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
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
                        log.Info("Setting lastSaveGameMetadata to null");
                    SharedSettings.instance.userState.lastSaveGameMetadata = null;
                }

                if (Setting.DisableContinueOnLauncher)
                {
                    if (Setting.EnableVerboseLogging)
                        log.Info("Deleting continue_game.json");
                    File.Delete($"{EnvPath.kUserDataPath}/continue_game.json");
                }
            }
            catch (Exception ex)
            {
                log.Info(ex);
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
            log.Info($"Shutting down {Name}");
        }

        public static void GetModDatabase()
        {
            try
            {
                if (!File.Exists(modDatabaseJson))
                {
                    log.Info("ModDatabase not found. Attempting to copy...");
                    CopyLocalBackup();
                }

                string oldJsonData = File.ReadAllText(modDatabaseJson, Encoding.UTF8);
                oldMetadata = JsonConvert
                    .DeserializeObject<ModDatabaseWrapper>(oldJsonData)
                    .Metadata;
                string newJsonData = File.ReadAllText(localBackupPath, Encoding.UTF8);
                newMetadata = JsonConvert
                    .DeserializeObject<ModDatabaseWrapper>(newJsonData)
                    .Metadata;
                if (oldMetadata.Time < newMetadata.Time)
                    CopyLocalBackup();
            }
            catch (Exception ex)
            {
                log.Info("An error occurred: " + ex.Message);
            }
        }

        private static void CopyLocalBackup()
        {
            try
            {
                if (File.Exists(localBackupPath))
                {
                    File.Copy(localBackupPath, modDatabaseJson, true);
                    log.Info("Local backup copied to ModDatabase.json.");
                }
                else
                {
                    log.Info("Local backup not found. Unable to copy.");
                }
            }
            catch (Exception ex)
            {
                log.Info("Error copying local backup: " + ex.Message);
            }
        }

        public static async Task MigrateFiles(string folder)
        {
            string backupFolder = Path.Combine(folder, "SettingsBackup");

            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
                log.Info($"Created backup folder: {backupFolder}");
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
                    log.Info($"Moved file: {file} to {destinationPath}");
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
                log.Info($"Created backup folder: {destinationDir}");
            }
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Move(file, destFile);
                log.Info($"Moved file: {file} to {destFile}");
            }
            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(dir);
                string destDir = Path.Combine(destinationDir, dirName);
                MoveDirectory(dir, destDir);
            }
            Directory.Delete(sourceDir);
            Mod.log.Info($"Deleted source directory: {sourceDir}");
        }

        //private static void RegisterSetting(Setting setting, string id, bool addPrefix = false)
        //{
        //    Game.UI.Menu.OptionsUISystem.Page page = setting.GetPageData(id, addPrefix).BuildPage();
        //    Mod.log.Info(page.ToString() );
        //    page.UpdateVisibility(false);
        //    page.UpdateNameAndDescription(false);
        //}
    }
}
