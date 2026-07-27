using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Game;
using Game.PSI;
using Game.UI.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarQ.Shared.Extensions;

namespace SimpleModCheckerPlus.Systems
{
    public partial class ModSettingsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModCheckup SMC = new();
        public static readonly List<string> loadedMods = SMC.GetLoadedMods();

        public static ConcurrentDictionary<string, ModInfo> ModDatabaseInfo =
            ModDatabase.ModDatabaseInfo;
        private static readonly string backupFile0 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_prev.json";
        private static readonly string backupFile1 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_1.json";
        private static readonly string backupFile2 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_2.json";
        private static readonly string backupFile3 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_3.json";
        private static readonly string backupFile4 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_4.json";
        private static readonly string backupFile5 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_5.json";
        private static readonly string backupFile6 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_6.json";
        private static readonly string backupFile7 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_7.json";
        private static readonly string backupFile8 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_8.json";
        private static readonly string backupFile9 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_9.json";
        private static int i = 0;

        private bool AutoRestoreDone = false;

        protected override void OnCreate()
        {
            base.OnCreate();
            //}

            //protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
            //{
            //base.OnGameLoadingComplete(purpose, mode);
            Colossal.Core.MainThreadDispatcher.RegisterUpdater(InitializeAutoRestore);
        }

        private static readonly JsonSerializerSettings JsonSettings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            MaxDepth = 5,
            Formatting = Formatting.Indented,
            Error = (sender, args) =>
            {
                LogHelper.SendLog(
                    $"JSON error on {args.ErrorContext.Member}: {args.ErrorContext.Error.Message}"
                );
                args.ErrorContext.Handled = true;
            },
        };

        private static readonly JsonSerializer Serializer = CreateSerializer();

        private static JsonSerializer CreateSerializer()
        {
            var serializer = JsonSerializer.Create(JsonSettings);
            serializer.Converters.Add(new Float2Converter());
            return serializer;
        }

        public void InitializeAutoRestore()
        {
            if (!AutoRestoreDone && Mod.m_Setting.AutoRestoreSettingBackupOnStartup)
            {
                LogHelper.SendLog("Starting ModSettingsBackup process");
                ModDatabaseInfo = ModDatabase.ModDatabaseInfo;
                if (!AutoRestoreDone) // && mode == GameMode.MainMenu)
                {
                    if (!Mod.m_Setting.AutoRestoreSettingBackupOnStartup)
                    {
                        LogHelper.SendLog("Auto Restore is disabled...");
                        goto EndAutoRestore;
                    }

                    if (!File.Exists(backupFile1))
                    {
                        LogHelper.SendLog("Auto Restore failed, no Mod Setting Backup was found.");
                        goto EndAutoRestore;
                    }

                    string currentModVersion = Mod.Version;
                    string jsonStringRead = File.ReadAllText(backupFile1);
                    if (jsonStringRead != null && jsonStringRead != "")
                    {
                        try
                        {
                            JObject jsonObject = JObject.Parse(jsonStringRead);
                            if (jsonObject != null)
                            {
                                if (
                                    !jsonObject.TryGetValue(
                                        "ModVersion",
                                        out JToken BackupModVersion
                                    )
                                    || BackupModVersion == null
                                )
                                    SendModUpdateNotification(currentModVersion, "null");
                                else if (BackupModVersion.ToString() != currentModVersion)
                                    SendModUpdateNotification(
                                        currentModVersion,
                                        BackupModVersion.ToString()
                                    );
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog(ex);
                        }
                    }

                    CreateBackup(0, false);
                    if (!FileHelper.FilesAreEqual(backupFile0, backupFile1))
                        RestoreBackup(1, false);
                    else
                        LogHelper.SendLog("Nothing to restore");

                    EndAutoRestore:
                    AutoRestoreDone = true;
                }
            }
        }

        protected override void OnUpdate() { }

        private void SendModUpdateNotification(string current, string prev)
        {
            //var validVersions = new HashSet<string> { "2.2.4", "2.2.5", "2.2.6", "2.2.7" };
            //if (validVersions.Contains(current) && (prev == "2.2.3" || validVersions.Contains(prev)))
            //{
            //    return;
            //}
            LogHelper.SendLog($"Mod version mismatch. Current: {current}, Backup: {prev}");
            NotificationSystem.Push(
                "starq-smc-mod-settings-update",
                title: LocalizedString.Id("SimpleModCheckerPlus.MakeModBackup.Title"),
                text: LocalizedString.Id("SimpleModCheckerPlus.MakeModBackup.Desc"),
                progressState: ProgressState.Warning,
                onClicked: () =>
                {
                    CreateBackup(1);
                    GameSettingsBackup.CreateBackup(1);
                }
            );
        }

        public static void CreateBackup(int profile, bool log = true)
        {
#if DEBUG
            log = true;
#endif

            if (profile == 1)
            {
                NotificationSystem.Pop(
                    "starq-smc-game-settings-update",
                    delay: 1f,
                    text: LocalizedString.Id($"{Mod.Id}.Working")
                );
                NotificationSystem.Pop(
                    "starq-smc-mod-settings-update",
                    delay: 1f,
                    text: LocalizedString.Id($"{Mod.Id}.Working")
                );
            }
            if (!ModDatabase.isModDatabaseLoaded)
            {
                LogHelper.SendLog("Mod Database wasn't loaded. Attempting to reload");
                Task.Run(() => ModDatabase.LoadModDatabase()).Wait();
            }

            string backupFile = profile switch
            {
                0 => backupFile0,
                1 => backupFile1,
                2 => backupFile2,
                3 => backupFile3,
                4 => backupFile4,
                5 => backupFile5,
                6 => backupFile6,
                7 => backupFile7,
                8 => backupFile8,
                9 => backupFile9,
                _ => backupFile1,
            };
            LogHelper.SendLog($"Creating Mod Settings Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            ModSettings ModSettings = new()
            {
                ModVersion = Mod.Version,
                LastUpdated = DateTime.Now.ToLongDateString(),
            };

            try
            {
                if (ModDatabaseInfo == null || !ModDatabaseInfo.Any())
                {
                    LogHelper.SendLog(
                        "ModDatabaseInfo is null or empty. Reloading Mod Database..."
                    );
                    Task.Run(() => ModDatabase.LoadModDatabase()).Wait();
                    ModDatabaseInfo = ModDatabase.ModDatabaseInfo;
                    if (ModDatabaseInfo == null || !ModDatabaseInfo.Any())
                    {
                        LogHelper.SendLog(
                            "Failed to initialize ModDatabaseInfo after reloading. Aborting backup.",
                            LogLevel.Error
                        );
                        return;
                    }
                }
                JObject jsonObject = null;
                if (File.Exists(backupFile))
                {
                    string jsonStringRead = File.ReadAllText(backupFile);
                    if (!string.IsNullOrEmpty(jsonStringRead))
                    {
                        try
                        {
                            jsonObject = JObject.Parse(jsonStringRead);
                        }
                        catch
                        {
                            LogHelper.SendLog($"Error reading {backupFile}");
                        }
                    }
                }

                foreach (var entry in ModDatabaseInfo)
                {
                    //try
                    //{
                    //    LogHelper.SendLog(entry.Key);
                    //}
                    //catch (Exception)
                    //{
                    //    LogHelper.SendLog($"entry.Key");
                    //}
                    //try
                    //{
                    //    LogHelper.SendLog(entry.Value.ModName);
                    //    LogHelper.SendLog(entry.Value.Author);
                    //    LogHelper.SendLog(entry.Value.PDX_ID);
                    //    LogHelper.SendLog(entry.Value.AssemblyName);
                    //    LogHelper.SendLog(entry.Value.FragmentSource);
                    //    LogHelper.SendLog(entry.Value.ClassType.Name);
                    //    LogHelper.SendLog(entry.Value.Backupable);
                    //}
                    //catch (Exception)
                    //{
                    //    LogHelper.SendLog($"entry.Value");
                    //}
                    if (entry.Value.Backupable == false)
                        continue;

                    LogHelper.SendLog($"Backing up {entry.Value.ModName}", LogLevel.DEVD);
                    try
                    {
                        string sectionName = entry.Key;
                        string fragmentSource = entry.Value.FragmentSource;
                        Type classType = entry.Value.ClassType;
                        string assembly = entry.Value.AssemblyName;

                        //LogHelper.SendLog(
                        //    $"Entry ready for backup: {sectionName}, {fragmentSource}, {classType.Name}, {assembly}"
                        //);

                        if (fragmentSource == "FiveTwentyNineTiles.ModSettings")
                        {
                            fragmentSource = "529.";
                        }
                        if (fragmentSource == "AutoDistrictNameStations.ModOptions")
                        {
                            fragmentSource = "AutoDistrict.";
                        }
                        //LogHelper.SendLog(
                        //    $"Entry ready for backup: {sectionName}, {fragmentSource}, {classType.Name}, {assembly}"
                        //);

                        PropertyInfo property = null;
                        try
                        {
                            property = typeof(ModSettings).GetProperty($"{classType.Name}");
                            //LogHelper.SendLog($"{property.Name} found");
                        }
                        catch (Exception)
                        {
                            //LogHelper.SendLog($"property not found");
                            continue;
                        }
                        object sectionSettings; // = Activator.CreateInstance(classType);
                        sectionSettings = default;
                        //LogHelper.SendLog(loadedMods.Contains(assembly));
                        if (!loadedMods.Contains(assembly))
                        {
                            //    LogHelper.SendLog($"{sectionName} is not currently loaded.", LogLevel.DEVD);
                            if (jsonObject != null)
                            {
                                var settingsJson = jsonObject[classType.Name];
                                //LogHelper.SendLog("5");
                                if (settingsJson != null && settingsJson.Type != JTokenType.Null)
                                {
                                    //LogHelper.SendLog("4");
                                    try
                                    {
                                        //LogHelper.SendLog("1");
                                        ConstructorInfo constructor = classType.GetConstructor(
                                            Type.EmptyTypes
                                        );
                                        if (constructor != null)
                                        {
                                            sectionSettings = constructor.Invoke(null);
                                        }
                                        else
                                        {
                                            LogHelper.SendLog(
                                                $"No parameterless constructor found for {classType.Name}"
                                            );
                                            sectionSettings = null;
                                        }
                                        //LogHelper.SendLog("2");
                                        foreach (PropertyInfo prop in classType.GetProperties())
                                        {
                                            //LogHelper.SendLog("3");
                                            //LogHelper.SendLog(prop.Name);
                                            //LogHelper.SendLog(settingsJson[prop.Name] != null);
                                            //LogHelper.SendLog(settingsJson[prop.Name].Type != JTokenType.Null);
                                            if (
                                                settingsJson[prop.Name] != null
                                                && settingsJson[prop.Name].Type != JTokenType.Null
                                            )
                                            {
                                                //LogHelper.SendLog("X");
                                                var value = settingsJson[prop.Name]
                                                    .ToObject(prop.PropertyType, Serializer);
                                                prop.SetValue(sectionSettings, value);
                                                //LogHelper.SendLog(value);
                                            }
                                            else
                                            {
                                                prop.SetValue(sectionSettings, null);
                                                //LogHelper.SendLog("setting null");
                                            }
                                        }
                                        //LogHelper.SendLog($"Existing {sectionName}Settings found.");
                                        //sectionSettings = jsonObject[entry.Value.ClassType.Name].ToObject(classType);
                                        //if (log)
                                        //    LogHelper.SendLog(
                                        //        $"Keeping existing backup for {sectionName}."
                                        //    );
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.SendLog("Error: " + ex);
                                    }
                                }
                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        LogHelper.SendLog("Error: " + ex);
                                //    }
                                //}
                            }
                        }
                        else
                        {
                            try
                            {
                                sectionSettings = GetSettingsData(
                                    sectionName,
                                    fragmentSource,
                                    sectionSettings,
                                    classType
                                );
                            }
                            catch (Exception ex)
                            {
                                LogHelper.SendLog(
                                    $"ERROR getting SettingsData for {classType} => {sectionName} => {fragmentSource}\n{ex}"
                                );
                            }
                        }

                        //string TempForLogging = JsonConvert.SerializeObject(sectionSettings);
                        //LogHelper.SendLog(TempForLogging);
                        property?.SetValue(ModSettings, sectionSettings);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(ModSettings, JsonSettings);
                File.WriteAllText(backupFile, jsonString);
                LogHelper.SendLog(
                    $"Mod Settings backup created successfully: {Path.GetFileName(backupFile)}"
                );
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
        }

        public static object GetSettingsData(
            string name,
            string fragmentSource,
            object settingsBackup,
            Type classType
        )
        {
            IEnumerable<SettingAsset> settingAssets;
            if (name == "80095")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains("Traffic General Settings")
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else if (name == "74286")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains("FPSLimiter General Settings")
                    || asset.name.Contains("FPSLimiter")
                    || asset.name.Contains("FPS_Limiter")
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else if (name == "75613")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains("Mods_Yenyang_Water_Features")
                    || asset.name.Contains("WaterFeatures")
                    || asset.name.Contains("Water_Feature")
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else if (name == "75250")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains("Mods_Yenyang_Better_Bulldozer")
                    || asset.name.Contains("BetterBulldozer")
                    || asset.name.Contains("Better_Bulldozer")
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else if (name == "75993")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains("Mods_Yenyang_Tree_Controller")
                    || asset.name.Contains("TreeController")
                    || asset.name.Contains("Tree_Controller")
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains(fragmentSource[..fragmentSource.IndexOf(".")])
                    || asset.name.Contains(name)
                );
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            //LogHelper.SendLog($"Getting settings: {name} ({settingAssets.Count()})");
            bool ProcessedFragmentSource = false;
            foreach (SettingAsset settingAsset in settingAssets)
            {
                //try { LogHelper.SendLog("settingAsset.name is " + settingAsset.name); } catch (Exception ex) { LogHelper.SendLog(ex); }
                //foreach (var fragment in settingAsset)
                //{ try { LogHelper.SendLog(fragment.name); } catch (Exception ex) { LogHelper.SendLog(ex); } }
                foreach (var fragment in settingAsset)
                {
                    //LogHelper.SendLog("var fragment in settingAsset");
                    //try { LogHelper.SendLog(fragment.name); } catch (Exception ex) { LogHelper.SendLog(ex); }
                    if (fragment.source == null)
                    {
                        //LogHelper.SendLog("fragment.source == null");
                        continue;
                    }
                    //try { LogHelper.SendLog(fragment.source); } catch (Exception ex) { LogHelper.SendLog(ex); }
                    //try { LogHelper.SendLog(fragment.source.GetType()); } catch (Exception ex) { LogHelper.SendLog(ex); }
                    //try { LogHelper.SendLog(fragment.source.GetType().Name); } catch (Exception ex) { LogHelper.SendLog(ex); }

                    //try { LogHelper.SendLog($"{fragment.name} is {fragment.source.GetType().Name}"); } catch (Exception ex) { LogHelper.SendLog(ex); }
                    if (fragment.source.GetType().Name == "UnityLogger") { }
                    //else if (
                    //    fragment.source.ToString().Contains("=====APM Settings=====")
                    //    && name == "78903"
                    //)
                    //{
                    //    (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(
                    //        fragment.source,
                    //        classType,
                    //        JsonSerializerSettings
                    //    );
                    //}
                    else
                    {
                        //LogHelper.SendLog($"{name}+{fragment.source}", LogLevel.DEV);
                        bool validity = ModSettingsMap.IsValid($"{name}+{fragment.source}");
                        //LogHelper.SendLog($"{fragment.source}+{name} is {validity}", LogLevel.DEV);
                        if (validity)
                        {
                            (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(
                                fragment.source,
                                classType
                            );
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (ProcessedFragmentSource)
                {
                    continue;
                }
            }
            if (ProcessedFragmentSource)
            {
                //if (log) LogHelper.SendLog($"Retrieved valid settings for {name}");
                return settingsBackup;
            }
            else
            {
                return null;
            }
        }

        private static (bool, object) ProcessFragmentSource(object source, Type classType)
        {
            var props = source
                .GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
                .ToDictionary(
                    p => p.Name,
                    p =>
                    {
                        try
                        {
                            var sw = System.Diagnostics.Stopwatch.StartNew();

                            var value = p.GetValue(source);

                            sw.Stop();
                            //LogHelper.SendLog(
                            //    $"OK: {p.Name} took {sw.ElapsedMilliseconds}ms",
                            //    LogLevel.DEV
                            //);

                            return value;
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog($"{p.Name}: {ex.Message}", LogLevel.Error);
                            return null;
                        }
                    }
                );
            //LogHelper.SendLog($"Processing fragment source for {classType.Name}", LogLevel.DEV);
            object settingsBackup = (ISettingsBackup)Activator.CreateInstance(classType);
            //LogHelper.SendLog($"SettingsBackup found for {classType.Name}", LogLevel.DEV);
            JObject sourceObj = JObject.FromObject(props, Serializer);
            //LogHelper.SendLog(
            //    $"JObject retrieved for fragment source {classType.Name}",
            //    LogLevel.DEV
            //);

#if DEBUG
            //string TempForLogging = JsonConvert.SerializeObject(sourceObj);
            //LogHelper.SendLog(TempForLogging, LogLevel.DEV);
#endif
            var properties = classType.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    if (sourceObj.TryGetValue(property.Name, out JToken valueToken))
                    {
                        var value = valueToken.ToObject(property.PropertyType, Serializer);
                        property.SetValue(settingsBackup, value);
                    }
                }
            }
            return (true, settingsBackup);
        }

        public void RestoreBackup(int profile, bool log = true)
        {
            i = 0;
            string backupFile = profile switch
            {
                0 => backupFile0,
                1 => backupFile1,
                2 => backupFile2,
                3 => backupFile3,
                4 => backupFile4,
                5 => backupFile5,
                6 => backupFile6,
                7 => backupFile7,
                8 => backupFile8,
                9 => backupFile9,
                _ => backupFile1,
            };
            if (!File.Exists(backupFile))
            {
                LogHelper.SendLog(
                    "Trying to Restore Backup, when Backup file is not found.",
                    LogLevel.Error
                );
                return;
            }

            LogHelper.SendLog("Restoring Mod Settings Backup");
            string jsonString = File.ReadAllText(backupFile);
            JObject jsonObject = JObject.Parse(jsonString);

            try
            {
                LogHelper.SendLog($"{ModDatabaseInfo.Count} mods in DB");
                foreach (var entry in ModDatabaseInfo)
                {
                    if (entry.Value.Backupable != true)
                        continue;

                    string sectionName = entry.Key;
                    string fragmentSource = entry.Value.FragmentSource;
                    Type classType = entry.Value.ClassType;
                    string assembly = entry.Value.AssemblyName;

                    //LogHelper.SendLog($"{sectionName}__{fragmentSource}");
                    //LogHelper.SendLog($"{assembly}");
                    //LogHelper.SendLog($"{classType.Name}");
                    if (fragmentSource == "FiveTwentyNineTiles.ModSettings")
                    {
                        fragmentSource = "529.";
                    }
                    if (fragmentSource == "AutoDistrictNameStations.ModOptions")
                    {
                        fragmentSource = "AutoDistrict.";
                    }

                    if (!loadedMods.Contains(assembly))
                    {
                        if (log)
                            LogHelper.SendLog($"skipping {assembly}...");
                    }
                    else
                    {
                        SetSettings(assembly, fragmentSource, jsonObject, classType.Name, log);
                    }
                }

                if (i > 0)
                {
                    NotificationSystem.Pop(
                        "starq-smc-mod-settings-restore",
                        title: Mod.Name,
                        text: new LocalizedString(
                            $"{Mod.Id}.RestoreModsSettings",
                            null,
                            new Dictionary<string, ILocElement>
                            {
                                { "Count", new LocalizedNumber<int>(i) },
                            }
                        ),
                        delay: 30f
                    );
                    LogHelper.SendLog(
                        $"Mod Settings Restoration Complete: {Path.GetFileName(backupFile)}... ({i} options restored)"
                    );
                }
                else
                {
                    LogHelper.SendLog("No changes found to restore Mod Settings...");
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Mod Settings Restoration Failed: {ex}");
            }
        }

        public void SetSettings(
            string name,
            string fragmentSource,
            JObject sourceObj,
            string className,
            bool log
        )
        {
            //LogHelper.SendLog($"Setting Settings for {name} with {fragmentSource} in {className}");
            try
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset =>
                    asset.name.Contains(fragmentSource[..fragmentSource.IndexOf(".")])
                    || asset.name.Contains(name)
                );
                var settingAssets = AssetDatabase.global.GetAssets(filter);
                //LogHelper.SendLog($"Setting settings: {name} ({settingAssets.Count()})");
                foreach (SettingAsset settingAsset in settingAssets)
                {
                    foreach (var fragment in settingAsset)
                    {
                        if (fragment.source == null)
                            break;
                        string fragmentSourceType = fragment.source.ToString();
                        string sectionKey = ModSettingsMap.GetClassName(
                            $"{fragmentSourceType}+{name}"
                        );
                        //LogHelper.SendLog(fragmentSourceType);
                        //LogHelper.SendLog($"{fragmentSourceType}+{name}");
                        //LogHelper.SendLog($"{sectionKey} == {className}");
                        //LogHelper.SendLog($"{sectionKey != null}");
                        if (sectionKey != null && sectionKey == className)
                        {
                            var props = fragment
                                .source.GetType()
                                .GetProperties()
                                .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
                                .ToDictionary(
                                    p => p.Name,
                                    p =>
                                    {
                                        try
                                        {
                                            return p.GetValue(fragment.source);
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.SendLog($"ERROR with {p.Name}: {ex.Message}");
                                            return null;
                                        }
                                    }
                                );

                            //LogHelper.SendLog("sectionKey != null && sectionKey == className");
                            JObject sectionSource = JObject.FromObject(props, Serializer);

                            if (sourceObj[sectionKey] is JObject jsonSettingsSection)
                            {
                                //LogHelper.SendLog("sourceObj[sectionKey] is JObject jsonSettingsSection)");
                                foreach (JProperty prop in jsonSettingsSection.Properties())
                                {
                                    PropertyInfo propInfo = fragment
                                        .source.GetType()
                                        .GetProperty(prop.Name);
                                    if (
                                        propInfo != null
                                        && propInfo.CanWrite
                                        && !propInfo
                                            .ToString()
                                            .StartsWith("Game.Input.ProxyBinding")
                                    )
                                    {
                                        var oldValue = propInfo.GetValue(fragment.source);
                                        var newValue = prop.Value.ToObject(
                                            propInfo.PropertyType,
                                            Serializer
                                        );
                                        if (!Equals(oldValue, newValue))
                                        {
                                            LogHelper.SendLog(
                                                $"Restoring '{sectionKey}:{prop.Name}': {oldValue} => {newValue}."
                                            );
                                            if (sectionKey != "SimpleModCheckerSettings")
                                            {
                                                i++;
                                            }
                                            propInfo.SetValue(fragment.source, newValue);
                                        }
                                    }
                                }

                                try
                                {
                                    Task.Run(() => settingAsset.Save(true)).Wait();
                                    if (log)
                                        LogHelper.SendLog($"{sectionKey} setting saved.");
                                }
                                catch (Exception ex)
                                {
                                    LogHelper.SendLog($"Error saving {sectionKey} settings: {ex}");
                                }
                            }
                            else
                            {
                                LogHelper.SendLog(
                                    $"{sectionKey} settings not found in the backup.",
                                    LogLevel.DEV
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"{name} not found. Skipping restore... {ex}");
            }
        }

#if DEBUG
        public void GetSettingsFiles()
        {
            var settingAssets = AssetDatabase.global.GetAssets<SettingAsset>("");
            LogHelper.SendLog($"Found: {settingAssets.Count()}");
            foreach (var settingAsset in settingAssets)
            {
                if (
                    settingAsset.name.Contains("Logger")
                    || settingAsset.name == "Radio Channel"
                    || settingAsset.name.EndsWith(" Settings")
                )
                {
                    continue;
                }
                LogHelper.SendLog(settingAsset.name);
                foreach (SettingAsset.Fragment fragment in settingAsset)
                {
                    try
                    {
                        if (fragment.source == null)
                        {
                            continue;
                        }
                        string fragmentSourceType = fragment.source.ToString();
                        LogHelper.SendLog($"fragment.source = \"{fragmentSourceType}\"");
                        try
                        {
                            //if (fragmentSourceType == "RealLife.Setting")
                            //{
                            //try { LogHelper.SendLog(fragment.source.ToJSONString()); } catch (Exception ex) { LogHelper.SendLog(ex); }
                            try
                            {
                                //LogHelper.SendLog(fragment.source.ToString());
                                LogHelper.SendLog(Colossal.Json.JSON.Dump(fragment.source));
                            }
                            catch (Exception ex)
                            {
                                LogHelper.SendLog(ex);
                            }
                            try
                            {
                                //LogHelper.SendLog(fragment.source.ToString());
                                LogHelper.SendLog(fragment.variant?.ToJSON());
                            }
                            catch (Exception ex)
                            {
                                LogHelper.SendLog(ex);
                            }
                            //}
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog(ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.SendLog(ex);
                    }
                }
            }
        }
#endif
    }
}
