using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Colossal.PSI.Environment;
using Newtonsoft.Json;
using StarQ.Shared.Extensions;

namespace SimpleModCheckerPlus.Systems
{
    public class ModInfo
    {
        public string AssemblyName { get; set; } = "";
        public string FragmentSource { get; set; } = "";
        public Type ClassType { get; set; } = null;
        public string PDX_ID { get; set; } = "";
        public string ModName { get; set; } = "";
        public string Author { get; set; } = "";
        public bool Backupable { get; set; } = false;
    }

    public class ModDatabaseMetadata
    {
        public string Version { get; set; }
        public long Time { get; set; }
    }

    public class ModDatabaseWrapper
    {
        public Dictionary<string, ModInfoTemp> ModDatabaseInfo { get; set; }
        public ModDatabaseMetadata Metadata { get; set; }
    }

    public class ModInfoTemp
    {
        public string AssemblyName { get; set; } = "";
        public string FragmentSource { get; set; } = "";
        public string ClassType { get; set; } = "";
        public string PDX_ID { get; set; } = "";
        public string ModName { get; set; } = "";
        public string Author { get; set; } = "";
        public bool Backupable { get; set; } = false;
    }

    public class ModDatabase
    {
        public Mod _mod;
        public static Dictionary<string, ModInfo> ModDatabaseInfo { get; private set; }

        public static ModDatabaseMetadata Metadata { get; private set; }
        public static string ModDatabaseTime;
        private static readonly string modDatabaseJson =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModDatabase.json";
        public static bool isModDatabaseLoaded = false;
        private static readonly object databaseLock = new();

        public static void LoadModDatabase()
        {
            lock (databaseLock)
            {
                if (!File.Exists(modDatabaseJson))
                {
                    LogHelper.SendLog("Mod database file not found");
                    return;
                }

                string jsonData = File.ReadAllText(modDatabaseJson);
                var jsonDataObject = JsonConvert.DeserializeObject<ModDatabaseWrapper>(jsonData);
                var rawModData = jsonDataObject.ModDatabaseInfo;
                var metaData = jsonDataObject.Metadata;
                TimeSpan timeSinceLastUpdate = TimeSpan.FromSeconds(
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds() - metaData.Time
                );
                string readableAge =
                    $"{timeSinceLastUpdate.Days} day{(timeSinceLastUpdate.Days != 1 ? "s" : "")}, "
                    + $"{timeSinceLastUpdate.Hours} hour{(timeSinceLastUpdate.Hours != 1 ? "s" : "")}, "
                    + $"{timeSinceLastUpdate.Minutes} minute{(timeSinceLastUpdate.Minutes != 1 ? "s" : "")}, "
                    + $"{timeSinceLastUpdate.Seconds} second{(timeSinceLastUpdate.Seconds != 1 ? "s" : "")} old";
                ModDatabaseTime = DateTimeOffset
                    .FromUnixTimeSeconds(metaData.Time)
                    .ToLocalTime()
                    .ToString("dd MMMM yyyy hh:mm:ss tt zzz");
                LogHelper.SendLog($"ModDatabase.json is {readableAge} ({ModDatabaseTime})...");

                ModDatabaseInfo = new();
                foreach (var entry in rawModData)
                {
                    var modInfoTemp = entry.Value;
                    string tempclassname =
                        $"{nameof(SimpleModCheckerPlus)}.{nameof(Systems)}.{modInfoTemp.ClassType}";
                    var modInfo = new ModInfo
                    {
                        AssemblyName = modInfoTemp.AssemblyName ?? "",
                        FragmentSource = modInfoTemp.FragmentSource ?? "",

                        ClassType = !string.IsNullOrEmpty(modInfoTemp.ClassType)
                            ? Type.GetType(tempclassname)
                            : null,
                        ModName = modInfoTemp.ModName ?? "",
                        PDX_ID = entry.Key ?? "",
                        Author = modInfoTemp.Author ?? "",
                        Backupable = modInfoTemp.Backupable,
                    };
                    ModDatabaseInfo.Add(entry.Key, modInfo);
                }
                LogHelper.SendLog($"Found {ModDatabaseInfo.Count} mods in the database");
                isModDatabaseLoaded = true;
            }
        }

        public static void GetModDatabase()
        {
            string modDatabaseJson = Mod.modDatabaseJson;
            try
            {
                if (!File.Exists(modDatabaseJson))
                {
                    LogHelper.SendLog("ModDatabase not found. Attempting to copy...");
                    CopyLocalBackup();
                }

                string oldJsonData = File.ReadAllText(modDatabaseJson, Encoding.UTF8);
                Mod.oldMetadata = JsonConvert
                    .DeserializeObject<ModDatabaseWrapper>(oldJsonData)
                    .Metadata;
                string newJsonData = File.ReadAllText(Mod.localBackupPath, Encoding.UTF8);
                Mod.newMetadata = JsonConvert
                    .DeserializeObject<ModDatabaseWrapper>(newJsonData)
                    .Metadata;
                if (Mod.oldMetadata.Time < Mod.newMetadata.Time)
                    CopyLocalBackup();
            }
            catch (Exception ex)
            {
                LogHelper.SendLog("An error occurred: " + ex.Message);
            }
        }

        private static void CopyLocalBackup()
        {
            try
            {
                if (File.Exists(Mod.localBackupPath))
                {
                    File.Copy(Mod.localBackupPath, Mod.modDatabaseJson, true);
                    LogHelper.SendLog("Local backup copied to ModDatabase.json.");
                }
                else
                {
                    LogHelper.SendLog("Local backup not found. Unable to copy.");
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog("Error copying local backup: " + ex.Message);
            }
        }
    }

    public class ModInfoProcessor
    {
        public static List<ModInfo> SortByAuthor_Mod_ID(Dictionary<string, ModInfo> type = null)
        {
            Dictionary<string, ModInfo>.ValueCollection list;
            if (type == null)
            {
                list = ModDatabase.ModDatabaseInfo.Values;
            }
            else
            {
                list = type.Values;
            }
            var sortedMods = list.OrderBy(mod => mod.Author)
                .ThenBy(mod => mod.ModName)
                .ThenBy(mod => mod.PDX_ID)
                .ToList();
            return sortedMods;
        }

        //public static List<ModInfo> SortByModName(Dictionary<string, ModInfo> type = null)
        //{
        //    Dictionary<string, ModInfo>.ValueCollection list;
        //    if (type == null)
        //    {
        //        list = ModDatabase.ModDatabaseInfo.Values;
        //    }
        //    else
        //    {
        //        list = type.Values;
        //    }
        //    var sortedMods = list
        //    .OrderBy(mod => mod.ModName)
        //    .ThenBy(mod => mod.PDX_ID)
        //    .ToList();
        //    return sortedMods;
        //}

        //public static List<ModInfo> SortByAssembly(Dictionary<string, ModInfo> type = null)
        //{
        //    Dictionary<string, ModInfo>.ValueCollection list;
        //    if (type == null)
        //    {
        //        list = ModDatabase.ModDatabaseInfo.Values;
        //    }
        //    else
        //    {
        //        list = type.Values;
        //    }
        //    var sortedMods = list
        //    .OrderBy(mod => mod.AssemblyName)
        //    .ToList();
        //    return sortedMods;
        //}
    }
}
