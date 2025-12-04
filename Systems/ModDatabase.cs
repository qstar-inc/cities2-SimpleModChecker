using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public static ConcurrentDictionary<string, ModInfo> ModDatabaseInfo { get; private set; }

        public static ModDatabaseMetadata Metadata { get; private set; }
        public static string ModDatabaseTime;
        public static bool isModDatabaseLoaded = false;
        private static readonly object databaseLock = new();

        public static string FormatTimeSpan(float seconds, string suffix = " old")
        {
            if (seconds < 0)
                seconds = 0;

            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            return FormatTimeSpan(ts, suffix);
        }

        public static string FormatTimeSpan(TimeSpan ts, string suffix = " old")
        {
            var parts = new List<string>();

            if (ts.Days > 0)
                parts.Add($"{ts.Days} day{(ts.Days != 1 ? "s" : "")}");
            if (ts.Hours > 0)
                parts.Add($"{ts.Hours} hour{(ts.Hours != 1 ? "s" : "")}");
            if (ts.Minutes > 0)
                parts.Add($"{ts.Minutes} minute{(ts.Minutes != 1 ? "s" : "")}");
            if (ts.Seconds > 0 || parts.Count == 0)
                parts.Add($"{ts.Seconds} second{(ts.Seconds != 1 ? "s" : "")}");

            return string.Join(", ", parts) + suffix;
        }

        public static void LoadModDatabase()
        {
            lock (databaseLock)
            {
                if (!File.Exists(Mod.modDatabaseJson))
                {
                    LogHelper.SendLog("Mod database file not found");
                    return;
                }

                string jsonData = File.ReadAllText(Mod.modDatabaseJson);
                var jsonDataObject = JsonConvert.DeserializeObject<ModDatabaseWrapper>(jsonData);
                if (jsonDataObject?.ModDatabaseInfo == null || jsonDataObject.Metadata == null)
                {
                    LogHelper.SendLog("Invalid mod database JSON.");
                    return;
                }
                var rawModData = jsonDataObject.ModDatabaseInfo;
                var metaData = jsonDataObject.Metadata;
                TimeSpan timeSinceLastUpdate = TimeSpan.FromSeconds(
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds() - metaData.Time
                );
                string readableAge = FormatTimeSpan(timeSinceLastUpdate);
                ModDatabaseTime = DateTimeOffset
                    .FromUnixTimeSeconds(metaData.Time)
                    .ToLocalTime()
                    .ToString("dd MMMM yyyy hh:mm:ss tt zzz");
                LogHelper.SendLog($"ModDatabase.json is {readableAge} ({ModDatabaseTime})...");

                ModDatabaseInfo = new ConcurrentDictionary<string, ModInfo>(
                    rawModData.Select(entry => new KeyValuePair<string, ModInfo>(
                        entry.Key,
                        ConvertToModInfo(entry.Key, entry.Value)
                    ))
                );
                LogHelper.SendLog($"Found {ModDatabaseInfo.Count} mods in the database");
                isModDatabaseLoaded = true;
                LocaleHelper.UpdateDictionary();
            }
        }

        public static void GetModDatabase()
        {
            try
            {
                if (!File.Exists(Mod.modDatabaseJson))
                {
                    LogHelper.SendLog("ModDatabase not found. Attempting to copy...");
                    CopyLocalBackup();
                }

                var oldJsonData = JsonConvert.DeserializeObject<ModDatabaseWrapper>(
                    File.ReadAllText(Mod.modDatabaseJson, Encoding.UTF8)
                );
                var newJsonData = JsonConvert.DeserializeObject<ModDatabaseWrapper>(
                    File.ReadAllText(Mod.localBackupPath, Encoding.UTF8)
                );

                if (oldJsonData?.Metadata == null || newJsonData?.Metadata == null)
                {
                    LogHelper.SendLog("Metadata missing in ModDatabase or backup.", LogLevel.Error);
                    return;
                }

                Mod.oldMetadata = oldJsonData.Metadata;
                Mod.newMetadata = newJsonData.Metadata;

                if (oldJsonData.Metadata.Time < newJsonData.Metadata.Time)
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

        private static ModInfo ConvertToModInfo(string key, ModInfoTemp temp)
        {
            return new ModInfo
            {
                AssemblyName = temp.AssemblyName ?? "",
                FragmentSource = temp.FragmentSource ?? "",
                ClassType = !string.IsNullOrEmpty(temp.ClassType)
                    ? Type.GetType(
                        $"{nameof(SimpleModCheckerPlus)}.{nameof(Systems)}.{temp.ClassType}"
                    )
                    : null,
                ModName = temp.ModName ?? "",
                PDX_ID = key ?? "",
                Author = temp.Author ?? "",
                Backupable = temp.Backupable,
            };
        }
    }

    public class ModInfoProcessor
    {
        public static List<ModInfo> SortByAuthor_Mod_ID(IEnumerable<ModInfo> mods = null)
        {
            var list = mods ?? ModDatabase.ModDatabaseInfo?.Values;

            if (list == null)
            {
                LogHelper.SendLog("No mods available to sort.", LogLevel.DEV);
                return new List<ModInfo>();
            }

            return list.OrderBy(m => m.Author)
                .ThenBy(m => m.ModName)
                .ThenBy(m => m.PDX_ID)
                .ToList();
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
