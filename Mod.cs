using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.PSI.Environment;
using Game;
using Game.Modding;
using Game.Settings;
using SimpleModCheckerPlus.Systems;
using StarQ.Shared.Extensions;
using StarQ.Shared.Generators;
using UnityEngine;

namespace SimpleModCheckerPlus
{
    [GenerateModInfo]
    public partial class Mod : IMod
    {
        public static string[] PDXModsPaths = Array.Empty<string>();

        public CocCleaner CocCleaner;

        public static string ModDatabaseJson;
        public static string LocalBackupPath;
        public static ModDatabaseMetadata oldMetadata;
        public static ModDatabaseMetadata newMetadata;

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            LogHelper.Init(Id, log);
            LocaleHelper.Init(Id, Name, GetReplacements, AddLocales);
            MigrateModsData();

            ModDatabaseJson = Path.Combine(DataDir, "ModDatabase.json");
            LogHelper.SendLog(ModDatabaseJson);
            LocalBackupPath = $"{ModHelper.GetModPath(this)}\\ModDatabase.json";
            LogHelper.SendLog(LocalBackupPath);

            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            AssetDatabase.global.LoadSettings(
                nameof(SimpleModCheckerPlus),
                m_Setting,
                new Setting(this)
            );

            PDXModsPaths = ModHelper.GetPDXModsPath();

            //Colossal.Core.MainThreadDispatcher.RegisterUpdater(TryFixUIMods);

            Task.Run(() => MigrateFiles()).Wait();

            Task.Run(() => ModDatabase.GetModDatabase()).Wait();
            Task.Run(() => ModDatabase.LoadModDatabase()).Wait();

#if DEBUG
            m_Setting.EnableVerboseLogging = true;
#endif
            //m_Setting.VerifyRunning = false;
            //m_Setting.IsInGameOrEditor = false;
            //m_Setting.ModFolderDropdown = "";
            //GameSettingsBackup.SetErrorMuteCooldown(10);

            if (m_Setting.DisableContinueInGame)
                SharedSettings.instance.userState.lastSaveGameMetadata = null;

            WorldHelper.GetSystem<ModCheckup>();
            WorldHelper.GetSystem<CocCleaner>();
            WorldHelper.GetSystem<MakeSomeNoise>();
            updateSystem.UpdateAt<AutosaveOffCheck>(SystemUpdatePhase.LateUpdate);
        }

        public static void InitBackup()
        {
            WorldHelper.GetSystem<ProfileNameBackup>();
            WorldHelper.GetSystem<GameSettingsBackup>();
            WorldHelper.GetSystem<ModSettingsBackup>();
            WorldHelper.GetSystem<KeybindsBackup>();
        }

        public void OnDispose()
        {
            LocaleHelper.Dispose();
            if (m_Setting != null)
            {
                try
                {
                    if (m_Setting.DisableContinueInGame)
                    {
                        if (m_Setting.EnableVerboseLogging)
                            LogHelper.SendLog("Setting lastSaveGameMetadata to null");
                        SharedSettings.instance.userState.lastSaveGameMetadata = null;
                    }

                    if (m_Setting.DisableContinueOnLauncher)
                    {
                        if (m_Setting.EnableVerboseLogging)
                            LogHelper.SendLog("Deleting continue_game.json");
                        File.Delete($"{EnvPath.kUserDataPath}/continue_game.json");
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog(ex);
                }

                if (m_Setting.DeleteCorrupted && CocCleaner.CanDelete.Count > 0)
                    CocCleaner.DeleteFolders();

                m_Setting.UnregisterInOptionsUI();
                m_Setting = null;
            }
        }

        public static Dictionary<string, string> GetReplacements()
        {
            int codeCount = (ModCheckup.codes?.Count ?? 0) + (ModCheckup.localMods?.Count ?? 0);

            int packageCount = ModCheckup.packages?.Count ?? 0;

            string textSort = m_Setting != null ? m_Setting.TextSort.ToString() : "Unknown";
            string sortOrder =
                m_Setting != null
                    ? (m_Setting.TextSortAscending == true ? "Ascending" : "Descending")
                    : "Unknown";

            Dictionary<string, string> dict = new()
            {
                { "SupportedMods", GetListOfSupportedMods() },
                {
                    "CodeCountSuffix",
                    codeCount > 1 ? $"{{{Id}.CodePlural}}" : $"{{{Id}.CodeSingular}}"
                },
                {
                    "PackageCountSuffix",
                    packageCount > 1 ? $"{{{Id}.PackagePlural}}" : $"{{{Id}.PackageSingular}}"
                },
                { "SortDetails", $"{textSort} - {sortOrder}" },
            };

            return dict;
        }

        public static void AddLocales()
        {
            string profile_label_key =
                "Options.OPTION[SimpleModCheckerPlus.SimpleModCheckerPlus.Mod.Setting.ProfileNameX]";
            string profile_desc_key =
                "Options.OPTION_DESCRIPTION[SimpleModCheckerPlus.SimpleModCheckerPlus.Mod.Setting.ProfileNameX]";

            string profile_label = LocaleHelper.Translate(profile_label_key);
            string profile_desc = LocaleHelper.Translate(profile_desc_key);

            for (int i = 1; i <= 9; i++)
            {
                LocaleHelper.AddLocalization(
                    profile_label_key.Replace("X]", $"{i}]"),
                    profile_label.Replace("{X}", i.ToString())
                );
                LocaleHelper.AddLocalization(
                    profile_desc_key.Replace("X]", $"{i}]"),
                    profile_desc.Replace("{X}", i.ToString())
                );
            }
        }

        public static string GetListOfSupportedMods()
        {
            List<ModInfo> backupable = ModInfoProcessor
                .SortByAuthor_Mod_ID()
                .Where(x => x.Backupable == true)
                .ToList();
            string finalLine =
                $"{LocaleHelper.Translate(LocaleHelper.GetOptionsGroupLocaleId("SupportedMod"))} ({backupable.Count})\n";
            foreach (var entry in backupable)
            {
                string name = entry.ModName ?? "(no name)";
                string id = entry.PDX_ID ?? "(no id)";
                string author = entry.Author ?? "(no author)";

                string line = $"- {author} — {id}: <{name}>";
                finalLine = string.Join("\n", finalLine, line);
            }
            finalLine +=
                "\n\n" + LocaleHelper.Translate("SimpleModCheckerPlus.KeybindsAlwaysSupported");
            finalLine = finalLine.TrimEnd('\n');
            return finalLine;
        }

        public static async Task MigrateFiles()
        {
            string folder = DataDir;
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

        internal static void MigrateModsData()
        {
            string root = $"{EnvPath.kUserDataPath}\\ModsData";
            string oldFolder = Path.Combine(root, "SimpleModChecker");
            string newFolder = Path.Combine(root, "SimpleModCheckerPlus");

            if (!Directory.Exists(oldFolder))
                return;

            try
            {
                if (Directory.Exists(newFolder))
                    FileHelper.DeleteDirectorySafe(newFolder);

                FileHelper.CopyDirectory(oldFolder, newFolder);
                FileHelper.DeleteDirectorySafe(oldFolder);
                LogHelper.SendLog("Migration to new data folder completed, restarting...");
                Application.Quit();
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Migration failed: {ex}", LogLevel.Error);
            }
        }
    }
}
