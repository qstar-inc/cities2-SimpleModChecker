using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.PSI.Common;
using Game;
using Game.PSI;
using Game.UI.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_prev.json";
        private static readonly string backupFile1 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_1.json";
        private static readonly string backupFile2 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_2.json";
        private static readonly string backupFile3 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_3.json";
        private static readonly string backupFile4 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_4.json";
        private static readonly string backupFile5 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_5.json";
        private static readonly string backupFile6 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_6.json";
        private static readonly string backupFile7 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_7.json";
        private static readonly string backupFile8 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_8.json";
        private static readonly string backupFile9 =
            $"{Mod.DataDir}\\SettingsBackup\\ModSettingsBackup_9.json";
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
            ContractResolver = new SkipUnsetSettingsResolver(),
            Error = (sender, args) =>
            {
                LogHelper.SendLog(
                    $"JSON error on {args.ErrorContext.Member}: {args.ErrorContext.Error.Message}"
                );
                args.ErrorContext.Handled = true;
            },
        };

        /// <summary>
        /// Drops any mapping class property we never read a value into. A mapping class lists every
        /// property a mod is known to have, but the live mod only gives us the ones it really has.
        /// Without this the rest come out as explicit nulls, and a restore writes those back: null
        /// for a string, default(T) for a value type.
        /// </summary>
        private sealed class SkipUnsetSettingsResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(
                MemberInfo member,
                MemberSerialization memberSerialization
            )
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                property.ShouldSerialize = instance =>
                    !(instance is ISettingsBackup settings) || settings.HasValue(member.Name);

                return property;
            }
        }

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
                            JObject jsonObject = ParseBackup(jsonStringRead);
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

            // Sections of the old backup, kept as raw JSON in case we can't rebuild them.
            Dictionary<string, JToken> previousSections = new();

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
                            jsonObject = ParseBackup(jsonStringRead);
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
                        if (loadedMods.Contains(assembly))
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

                        // Keep the old section around to fill any gap we leave below, whether the
                        // mod isn't loaded or we just couldn't read it. Only the keys the mapping
                        // class still declares, same as the old rebuild did, so a property dropped
                        // from the class stops coming back.
                        if (jsonObject?[classType.Name] is JObject previous)
                        {
                            previousSections[classType.Name] = OnlyDeclaredKeys(
                                previous,
                                classType
                            );
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
                // FromObject, not Parse of a serialized string: re-reading our own JSON turns a
                // date-shaped setting into a DateTime and writes it back different.
                JObject output = JObject.FromObject(
                    ModSettings,
                    JsonSerializer.CreateDefault(JsonSettings)
                );

                // Fill in what we couldn't read, key by key. Whole-section replacement threw away
                // the good half whenever one getter failed, and kept nothing when they all did.
                foreach (var section in previousSections)
                {
                    if (!(output[section.Key] is JObject fresh))
                    {
                        output[section.Key] = section.Value;
                        continue;
                    }

                    foreach (JProperty old in ((JObject)section.Value).Properties())
                    {
                        // TryGetValue, not a null check: a key we wrote as null is present and must
                        // stay null, and fresh["X"] on a JSON null is not a C# null.
                        if (!fresh.TryGetValue(old.Name, out _))
                        {
                            fresh.Add(old.Name, old.Value);
                        }
                    }
                }
                File.WriteAllText(backupFile, output.ToString(Formatting.Indented));
                LogHelper.SendLog(
                    $"Mod Settings backup created successfully: {Path.GetFileName(backupFile)}"
                );
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
        }

        /// <summary>
        /// The old backup section minus anything the mapping class no longer declares. Those
        /// are curated: a property commented out of one is a property we stopped backing up on
        /// purpose, and a stale copy would otherwise live in the file forever and get restored into
        /// the mod.
        /// </summary>
        private static JObject OnlyDeclaredKeys(JObject section, Type classType)
        {
            HashSet<string> declared = new(classType.GetProperties().Select(p => p.Name));
            JObject kept = new();

            foreach (JProperty prop in section.Properties())
            {
                if (declared.Contains(prop.Name))
                {
                    kept.Add(prop.Name, prop.Value);
                }
            }

            return kept;
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

        // Marks a getter that threw, so we can tell it apart from one that returned null.
        private static readonly object Unreadable = new();

        /// <summary>
        /// Reads a backup file. JObject.Parse turns a date-shaped setting into a DateTime and hands
        /// back a different string than the mod stored, so we tell the reader to leave strings be.
        /// </summary>
        private static JObject ParseBackup(string json)
        {
            using StringReader text = new(json);
            using JsonTextReader reader = new(text) { DateParseHandling = DateParseHandling.None };

            return JObject.Load(reader);
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
                            return Unreadable;
                        }
                    }
                );

            // Drop the ones that threw, so what's left is what the mod actually told us. A getter
            // that failed and a getter that returned null are not the same thing.
            foreach (var failed in props.Where(p => p.Value == Unreadable).ToList())
            {
                props.Remove(failed.Key);
            }
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
                    // Ask props, not sourceObj: a value that failed to serialize also lands in
                    // sourceObj as a null, and we'd read that as "the mod cleared it". No key at
                    // all means the mod doesn't have this property, or its getter threw. Leave it
                    // unset, that's what keeps it out of the backup.
                    if (!props.TryGetValue(property.Name, out object raw))
                    {
                        continue;
                    }

                    if (raw == null)
                    {
                        // The mod really holds null. Write it down, or a setting the user cleared
                        // looks the same as one we never read, and the old value gets carried
                        // forward over it. Reference types only: reflection would turn a null into
                        // default(T), which is the bug this all started with.
                        if (!property.PropertyType.IsValueType)
                        {
                            property.SetValue(settingsBackup, null);
                        }
                    }
                    else if (sourceObj.TryGetValue(property.Name, out JToken valueToken))
                    {
                        var value = valueToken.ToObject(property.PropertyType, Serializer);

                        // Null out of a non-null value means the conversion failed and the error
                        // handler ate it. We read nothing, so record nothing.
                        if (value != null)
                        {
                            property.SetValue(settingsBackup, value);
                        }
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
            JObject jsonObject = ParseBackup(jsonString);

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
                        LogHelper.CheckNull(
                            assembly,
                            $"{sectionName} assembly",
                            level: LogLevel.Info
                        );
                        LogHelper.CheckNull(
                            fragmentSource,
                            $"{sectionName} fragmentSource",
                            level: LogLevel.Info
                        );
                        LogHelper.CheckNull(
                            jsonObject,
                            $"{sectionName} jsonObject",
                            level: LogLevel.Info
                        );
                        LogHelper.CheckNull(
                            classType,
                            $"{sectionName} classType",
                            level: LogLevel.Info
                        );
                        LogHelper.CheckNull(
                            classType.Name,
                            $"{sectionName} classType.Name",
                            level: LogLevel.Info
                        );
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
                        // Skip it, don't stop: an empty fragment can sit ahead of the one we want,
                        // and breaking here left those mods backed up but never restored.
                        if (fragment.source == null)
                            continue;
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
                            //LogHelper.SendLog("sectionKey != null && sectionKey == className");
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
                                        // A mod's accessor can throw. Keep it to this one property:
                                        // letting it out skips the rest of the mod and the save
                                        // below, leaving it half restored.
                                        try
                                        {
                                            var oldValue = propInfo.GetValue(fragment.source);
                                            var newValue = prop.Value.ToObject(
                                                propInfo.PropertyType,
                                                Serializer
                                            );

                                            // Never restore a null: old backups are full of them,
                                            // and writing one back blanks a string or turns a
                                            // value type into default(T). Leave the mod with what
                                            // it has, the user's value or its own default.
                                            if (newValue == null)
                                            {
                                                continue;
                                            }

                                            if (!Equals(oldValue, newValue))
                                            {
                                                // Count and log after the write, not before: a
                                                // setter that throws must not be reported as a
                                                // restored option.
                                                propInfo.SetValue(fragment.source, newValue);
                                                LogHelper.SendLog(
                                                    $"Restoring '{sectionKey}:{prop.Name}': {oldValue} => {newValue}."
                                                );
                                                if (sectionKey != "SimpleModCheckerSettings")
                                                {
                                                    i++;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHelper.SendLog(
                                                $"ERROR restoring '{sectionKey}:{prop.Name}': {ex}",
                                                LogLevel.Error
                                            );
                                        }
                                    }
                                }

                                try
                                {
                                    // FIXME: this doesn't wait for anything. SettingAsset.Save is
                                    // async void, so the task completes at its first await and we
                                    // log a save that hasn't happened yet. The awaitable overload
                                    // is internal.
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
