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
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Colossal.PSI.Environment;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Game.PSI;
using Game.UI.Localization;
using Colossal.PSI.Common;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public const string Name = "Simple Mod Checker Plus";
        public static string Version = "2.2.6";
        
        public static Setting Setting;
        public ModNotification ModNotification;
        public CIDBackupRestore CIDBackupRestore;
        public CocCleaner CocCleaner;

        public static readonly string logFileName = nameof(SimpleModCheckerPlus);
        public static ILog log = LogManager.GetLogger(nameof(SimpleModCheckerPlus)).SetShowsErrorsInUI(true);
        public static ModManager modManager = GameManager.instance.modManager;
        private static readonly string modDatabaseJson = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModDatabase.json";
        public static string localBackupPath;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info($"Starting up {Name}");
            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            log.Info($"Loading from \"{asset.path}\"");
            localBackupPath = $"{Directory.GetParent(asset.path).FullName}\\ModDatabase.json";
            Setting = new Setting(this);
            Setting.RegisterInOptionsUI();
            Setting.Instance = Setting;
            AssetDatabase.global.LoadSettings(nameof(SimpleModCheckerPlus), Setting, new Setting(this));

            Task.Run(() => MigrateFiles(Directory.GetParent(modDatabaseJson).FullName)).Wait();

            Task.Run(() => EnsureModDatabaseAsync()).Wait();
            ModDatabase.LoadModDatabase();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            Setting.RefreshedRecently = false;
            
            ModNotification = new ModNotification();
            CIDBackupRestore = new CIDBackupRestore(this);
            CocCleaner = new CocCleaner(this);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(ModNotification);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(CIDBackupRestore);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(CocCleaner);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ProfileNameBackup>();
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
            Setting.RefreshedRecently = false;
            MakeBackupOfModsData.MakePrev();
            Setting.UnregisterInOptionsUI();
            log.Info($"Shutting down {Name}");
        }

        public static async Task EnsureModDatabaseAsync()
        {
            try
            {
                if (!File.Exists(modDatabaseJson))
                {
                    log.Info("ModDatabase not found. Attempting to download...");
                    await DownloadNow(0);
                }
                else
                {
                    string jsonData = File.ReadAllText(modDatabaseJson);
                    var metadata = JsonConvert.DeserializeObject<ModDatabaseWrapper>(jsonData).Metadata;
                    if (Setting.LastDownloaded == 0) Setting.LastDownloaded = metadata.Time;
                    if ((DateTime.UtcNow - DateTimeOffset.FromUnixTimeSeconds(metadata.Time).UtcDateTime) > TimeSpan.FromDays(3))
                    {
                        TimeSpan timeSinceLastUpdate = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - metadata.Time);
                        string readableAge = $"{timeSinceLastUpdate.Days} day{(timeSinceLastUpdate.Days != 1 ? "s" : "")}, " +
                                $"{timeSinceLastUpdate.Hours} hour{(timeSinceLastUpdate.Hours != 1 ? "s" : "")}, " +
                                $"{timeSinceLastUpdate.Minutes} minute{(timeSinceLastUpdate.Minutes != 1 ? "s" : "")}, " +
                                $"{timeSinceLastUpdate.Seconds} second{(timeSinceLastUpdate.Seconds != 1 ? "s" : "")} old";
                        log.Info($"ModDatabase is {readableAge}. Looking for update...");
                        await DownloadNow(1);
                    }
                    else
                    {
                        log.Info("ModDatabase found.");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("An error occurred: " + ex.Message);
            }
        }

        public static async Task DownloadNow(int mode)
        {
            log.Info("Downloading ModDatabase");
            if (Setting.LastDownloaded == 0)
            {
                log.Info($"First download in progress...");
            }
            else
            {
                TimeSpan timeSinceLastDownload = TimeSpan.FromSeconds((DateTimeOffset.UtcNow.ToUnixTimeSeconds() - Setting.LastDownloaded));
                string readableTime = $"{timeSinceLastDownload.Days} day{(timeSinceLastDownload.Days != 1 ? "s" : "")}, " +
                      $"{timeSinceLastDownload.Hours} hour{(timeSinceLastDownload.Hours != 1 ? "s" : "")}, " +
                      $"{timeSinceLastDownload.Minutes} minute{(timeSinceLastDownload.Minutes != 1 ? "s" : "")}, " +
                      $"{timeSinceLastDownload.Seconds} second{(timeSinceLastDownload.Seconds != 1 ? "s" : "")} ago";
                log.Info($"Last download was {readableTime}...");
            }
            string downloadUrl = "https://github.com/qstar-inc/cities2-SimpleModChecker/raw/refs/heads/master/Resources/ModDatabase.json";
            if (mode == 2) { Setting.RefreshedRecently = true; }
            if (mode == 1 && !((DateTimeOffset.UtcNow.ToUnixTimeSeconds() - Setting.LastDownloaded) > (long)TimeSpan.FromDays(3).TotalSeconds))
            {
                log.Info($"Skipping...");
                return;
            }
            else
            {
                NotificationSystem.Push("starq-smc-mod-database-downloaded",
                    title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                    text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloadStarting]"),
                    progressState: ProgressState.Indeterminate
                    );
            }
            try
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.Timeout = TimeSpan.FromSeconds(120);
                var content = await client.GetStringAsync(downloadUrl);
                await Task.Run(() => File.WriteAllText(modDatabaseJson, content));
                log.Info("ModDatabase.json downloaded successfully.");
                NotificationSystem.Push("starq-smc-mod-database-downloaded",
                    title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                    text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloaded]"),
                    progressState: ProgressState.Complete,
                    onClicked: () => {
                        NotificationSystem.Pop("starq-smc-mod-database-downloaded");
                    });
            }
            catch (HttpRequestException)
            {
                log.Info($"Network error occurred while trying to download. Copying local backup...");
                if (mode == 0)
                {
                    NotificationSystem.Push("starq-smc-mod-database-downloaded",
                        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseLocalCopy]"),
                        progressState: ProgressState.Complete,
                        onClicked: () => { NotificationSystem.Pop("starq-smc-mod-database-downloaded"); }
                        );
                    CopyLocalBackup();
                }
                else
                {
                    NotificationSystem.Pop("starq-smc-mod-database-downloaded");
                }
            }
            catch (TimeoutException timeoutEx)
            {
                log.Error($"Download timed out: {timeoutEx.Message}");
                if (mode == 0)
                {
                    CopyLocalBackup();
                }
                NotificationSystem.Pop("starq-smc-mod-database-downloaded");
            }
            catch (Exception ex)
            {
                log.Error($"Failed to download file: {ex.Message}");
                if (mode == 0)
                {
                    CopyLocalBackup();
                }
                NotificationSystem.Pop("starq-smc-mod-database-downloaded");
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

            string[] filePatterns = ["GameSettings*", "ModSettings*", "ProfileName*"];

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
    }
}