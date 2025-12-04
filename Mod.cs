using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.Localization;
using Colossal.Logging;
using Colossal.PSI.Environment;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Game.Serialization;
using Game.Settings;
using SimpleModCheckerPlus.Systems;
using StarQ.Shared.Extensions;
using Unity.Entities;

namespace SimpleModCheckerPlus
{
    public class Mod : IMod
    {
        public static string Id = nameof(SimpleModCheckerPlus);
        public static string Name = Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyTitleAttribute>()
            .Title;
        public static string Version = Assembly
            .GetExecutingAssembly()
            .GetName()
            .Version.ToString(3);

        public static ILog log = LogManager.GetLogger($"{Id}").SetShowsErrorsInUI(false);
        public static Setting m_Setting;

        public CocCleaner CocCleaner;

        public static ModManager modManager = GameManager.instance.modManager;
        public static readonly string modDatabaseJson = Path.Combine(
            EnvPath.kUserDataPath,
            "ModsData",
            "SimpleModChecker",
            "ModDatabase.json"
        );
        public static string localBackupPath;
        public static ModDatabaseMetadata oldMetadata;
        public static ModDatabaseMetadata newMetadata;

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogHelper.Init(Id, log);
            LocaleHelper.Init(Id, Name, GetReplacements, AddLocales);

            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            localBackupPath = $"{Directory.GetParent(asset.path).FullName}\\ModDatabase.json";

            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            AssetDatabase.global.LoadSettings(
                nameof(SimpleModCheckerPlus),
                m_Setting,
                new Setting(this)
            );

            Task.Run(() => MigrateFiles(Directory.GetParent(modDatabaseJson).FullName)).Wait();

            Task.Run(() => ModDatabase.GetModDatabase()).Wait();
            Task.Run(() => ModDatabase.LoadModDatabase()).Wait();

#if DEBUG
            m_Setting.DeletedBackupCIDs = false;
            m_Setting.EnableVerboseLogging = true;
#endif

            if (!m_Setting.DeletedBackupCIDs)
                Task.Run(() => ModCheckup.RemoveBackupCID()).Wait();
            //GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Setting));
            m_Setting.VerifyRunning = false;
            m_Setting.IsInGameOrEditor = false;
            m_Setting.ModFolderDropdown = "";
            //GameSettingsBackup.SetErrorMuteCooldown(10);

            if (m_Setting.DisableContinueInGame)
                SharedSettings.instance.userState.lastSaveGameMetadata = null;

            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModCheckup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CocCleaner>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ProfileNameBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<GameSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ModSettingsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<KeybindsBackup>();
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<MakeSomeNoise>();
            //World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<ContentPrereq>();
            updateSystem.UpdateAt<AutosaveOffCheck>(SystemUpdatePhase.LateUpdate);
            //updateSystem.UpdateBefore<PreDeserialize<ContentPrereq>>(SystemUpdatePhase.Deserialize);
        }

        public void OnDispose()
        {
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

                //if (Setting.DeleteMissing && CIDBackupRestore.CanDelete.Count > 0)
                //{
                //    CIDBackupRestore.DeleteFolders();
                //}

                if (m_Setting.DeleteCorrupted && CocCleaner.CanDelete.Count > 0)
                    CocCleaner.DeleteFolders();
                m_Setting.VerifyRunning = false;
                m_Setting.IsInGameOrEditor = false;
                m_Setting.ModFolderDropdown = "";
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
            string finalLine = "";
            List<ModInfo> sortedMods = ModInfoProcessor.SortByAuthor_Mod_ID();
            foreach (var entry in sortedMods)
            {
                if (entry.Backupable != true)
                    continue;
                string name = entry.ModName ?? "(no name)";
                string id = entry.PDX_ID ?? "(no id)";
                string author = entry.Author ?? "(no author)";

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
