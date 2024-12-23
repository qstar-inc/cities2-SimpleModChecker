﻿// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Colossal.PSI.Environment;
using Game.Modding;
using Game.SceneFlow;
using Game;
using SimpleModChecker.Systems;
using System.IO;
using System.Threading.Tasks;
using System;
using Unity.Entities;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public const string Name = "Simple Mod Checker Plus";
        public static string Version = "3.2.2";
        
        public static Setting Setting;
        //public ModCheckup ModCheckup;
        public CIDBackupRestore CIDBackupRestore;
        public CocCleaner CocCleaner;

        public static readonly string logFileName = nameof(SimpleModCheckerPlus);
        public static ILog log = LogManager.GetLogger(nameof(SimpleModCheckerPlus)).SetShowsErrorsInUI(true);
        public static ModManager modManager = GameManager.instance.modManager;
        private static readonly string modDatabaseJson = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModDatabase.json";
        public static string localBackupPath;
        public static ModDatabaseMetadata oldMetadata;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info($"Starting up {Name} {Version}");
            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            log.Info($"Loading from \"{asset.path}\"");
            localBackupPath = $"{Directory.GetParent(asset.path).FullName}\\ModDatabase.json";
            Setting = new Setting(this);
            Setting.RegisterInOptionsUI();
            Setting.Instance = Setting;
            AssetDatabase.global.LoadSettings(nameof(SimpleModCheckerPlus), Setting, new Setting(this));

            Task.Run(() => MigrateFiles(Directory.GetParent(modDatabaseJson).FullName)).Wait();

            Task.Run(() => GetModDatabase()).Wait();
            ModDatabase.LoadModDatabase();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            Setting.VerifiedRecently = false;
            Setting.IsInGameOrEditor = false;

            ////ModCheckup = new ModCheckup();
            //CIDBackupRestore = new CIDBackupRestore(this);
            //CocCleaner = new CocCleaner(this);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModCheckup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CIDBackupRestore>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CocCleaner>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ProfileNameBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<GameSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<KeybindsBackup>();
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
            Setting.VerifiedRecently = false;
            Setting.IsInGameOrEditor = false;
            MakeBackupOfModsData.MakePrev();
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
                    //await DownloadNow(0);
                    CopyLocalBackup();
                }

                //string jsonData = File.ReadAllText(modDatabaseJson, Encoding.UTF8);
                //oldMetadata = JsonConvert.DeserializeObject<ModDatabaseWrapper>(jsonData).Metadata;
                //if (Setting.LastDownloaded == 0) Setting.LastDownloaded = oldMetadata.Time;
                //TimeSpan timeSinceLastUpdate = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - oldMetadata.Time);
                //log.Info($"Current ModDatabase is {ReadableAge(timeSinceLastUpdate)}. Version {oldMetadata.Version}.");
                //if ((timeSinceLastUpdate > TimeSpan.FromDays(10) && (DateTime.UtcNow - DateTimeOffset.FromUnixTimeSeconds(Setting.LastChecked).UtcDateTime) > TimeSpan.FromDays(5)) || (new System.Version(oldMetadata.Version) < new System.Version(Version)))
                //{
                //    log.Info($"Looking for update...");
                //    await DownloadNow(1);
                //}

            }
            catch (Exception ex)
            {
                log.Info("An error occurred: " + ex.Message);
            }
        }

        //public static async Task DownloadNow(int mode)
        //{
        //    log.Info("Downloading ModDatabase");
        //    if (Setting.LastDownloaded == 0)
        //    {
        //        log.Info($"First download in progress...");
        //    }
        //    else
        //    {
        //        TimeSpan timeSinceLastDownload = TimeSpan.FromSeconds((DateTimeOffset.UtcNow.ToUnixTimeSeconds() - Setting.LastDownloaded));
        //        log.Info($"Last download was {ReadableAge(timeSinceLastDownload)}...");
        //    }
        //    Setting.LastChecked = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        //    string downloadUrl = "https://github.com/qstar-inc/cities2-SimpleModChecker/raw/refs/heads/master/Resources/ModDatabase.json";
        //    if (mode == 2) { Setting.VerifiedRecently = true; }
            
        //    NotificationSystem.Push("starq-smc-mod-database-downloaded",
        //        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
        //        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloadStarting]"),
        //        progressState: ProgressState.Indeterminate
        //        );
        //    try
        //    {
        //        using HttpClient client = new();
        //        client.DefaultRequestHeaders.ExpectContinue = false;
        //        client.Timeout = TimeSpan.FromSeconds(120);
        //        var content = await client.GetStringAsync(downloadUrl);
        //        string newJsonData = content;
        //        var newMetadata = JsonConvert.DeserializeObject<ModDatabaseWrapper>(newJsonData).Metadata;
        //        Setting.LastDownloaded = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        //        if (oldMetadata.Time < newMetadata.Time)
        //        {
        //            TimeSpan newTimeSinceLastUpdate = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - newMetadata.Time);
        //            log.Info($"New ModDatabase is {ReadableAge(newTimeSinceLastUpdate)}...");
        //            NotificationSystem.Push("starq-smc-mod-database-downloaded",
        //            title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
        //            text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.ModDatabaseDownloaded]"),
        //            progressState: ProgressState.Complete,
        //            onClicked: () =>
        //            {
        //                NotificationSystem.Pop("starq-smc-mod-database-downloaded");
        //            });
        //            await Task.Run(() => File.WriteAllText(modDatabaseJson, content));
        //            log.Info("ModDatabase Updated successfully.");
        //        }
        //        else
        //        {
        //            log.Info("No update found... Enjoy.");
        //            NotificationSystem.Pop("starq-smc-mod-database-downloaded");
        //        }
        //    }
        //    catch (HttpRequestException)
        //    {
        //        log.Info($"Network error occurred while trying to download. Copying local backup...");
        //        if (mode == 0)
        //        {
        //            CopyLocalBackup();
        //        }
        //        NotificationSystem.Pop("starq-smc-mod-database-downloaded");
        //    }
        //    catch (TimeoutException timeoutEx)
        //    {
        //        log.Info($"Download timed out: {timeoutEx.Message}");
        //        if (mode == 0)
        //        {
        //            CopyLocalBackup();
        //        }
        //        NotificationSystem.Pop("starq-smc-mod-database-downloaded");
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Info($"Failed to download file: {ex.Message}");
        //        if (mode == 0)
        //        {
        //            CopyLocalBackup();
        //        }
        //        NotificationSystem.Pop("starq-smc-mod-database-downloaded");
        //    }
        //}

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

        //public static string ReadableAge (TimeSpan timeSinceLastUpdate)
        //{
        //    string readableAge = $"{timeSinceLastUpdate.Days} day{(timeSinceLastUpdate.Days != 1 ? "s" : "")}, " +
        //                    $"{timeSinceLastUpdate.Hours} hour{(timeSinceLastUpdate.Hours != 1 ? "s" : "")}, " +
        //                    $"{timeSinceLastUpdate.Minutes} minute{(timeSinceLastUpdate.Minutes != 1 ? "s" : "")}, " +
        //                    $"{timeSinceLastUpdate.Seconds} second{(timeSinceLastUpdate.Seconds != 1 ? "s" : "")} old";
        //    return readableAge;
        //}
    }
}