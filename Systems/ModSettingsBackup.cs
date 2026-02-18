using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
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

        //public static ModManager modManager;
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
            while (!AutoRestoreDone && Mod.m_Setting.AutoRestoreSettingBackupOnStartup)
            {
                LogHelper.SendLog("Starting ModSettingsBackup process");
                ModDatabaseInfo = ModDatabase.ModDatabaseInfo;
                if (!AutoRestoreDone) // && mode == GameMode.MainMenu)
                {
                    if (Mod.m_Setting.AutoRestoreSettingBackupOnStartup)
                    {
                        if (File.Exists(backupFile1))
                        {
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
                                        {
                                            SendModUpdateNotification(currentModVersion, "null");
                                        }
                                        else
                                        {
                                            if (BackupModVersion.ToString() != currentModVersion)
                                            {
                                                SendModUpdateNotification(
                                                    currentModVersion,
                                                    BackupModVersion.ToString()
                                                );
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogHelper.SendLog(ex);
                                }
                            }

                            CreateBackup(0, false);
                            if (
                                !File.ReadAllText(backupFile0).Equals(File.ReadAllText(backupFile1))
                            )
                            {
                                RestoreBackup(1, false);
                            }
                            else
                            {
                                LogHelper.SendLog("Nothing to restore");
                            }
                        }
                        else
                        {
                            LogHelper.SendLog(
                                "Auto Restore failed, no Mod Setting Backup was found."
                            );
                        }
                    }
                    else
                    {
                        LogHelper.SendLog("Auto Restore is disabled...");
                    }
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
                    {
                        continue;
                    }
                    if (log)
                        LogHelper.SendLog($"Backing up {entry.Value.ModName}");
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

                        PropertyInfo property = typeof(ModSettings).GetProperty(
                            $"{entry.Value.ClassType.Name}"
                        );
                        //try { LogHelper.SendLog($"{property.Name} found"); } catch (Exception) { LogHelper.SendLog($"property found"); }
                        object sectionSettings; // = Activator.CreateInstance(classType);
                        sectionSettings = default;
                        //LogHelper.SendLog(loadedMods.Contains(assembly));
                        if (!loadedMods.Contains(assembly))
                        {
                            if (log)
                                LogHelper.SendLog($"{sectionName} is not currently loaded.");
                            if (File.Exists(backupFile))
                            {
                                string jsonStringRead = File.ReadAllText(backupFile);
                                if (!string.IsNullOrEmpty(jsonStringRead))
                                {
                                    try
                                    {
                                        JObject jsonObject = JObject.Parse(jsonStringRead);
                                        var settingsJson = jsonObject[classType.Name];
                                        //LogHelper.SendLog("5");
                                        if (
                                            settingsJson != null
                                            && settingsJson.Type != JTokenType.Null
                                        )
                                        {
                                            //LogHelper.SendLog("4");
                                            try
                                            {
                                                //LogHelper.SendLog("1");
                                                ConstructorInfo constructor =
                                                    classType.GetConstructor(Type.EmptyTypes);
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
                                                foreach (
                                                    PropertyInfo prop in classType.GetProperties()
                                                )
                                                {
                                                    //LogHelper.SendLog("3");
                                                    //LogHelper.SendLog(prop.Name);
                                                    //LogHelper.SendLog(settingsJson[prop.Name] != null);
                                                    //LogHelper.SendLog(settingsJson[prop.Name].Type != JTokenType.Null);
                                                    if (
                                                        settingsJson[prop.Name] != null
                                                        && settingsJson[prop.Name].Type
                                                            != JTokenType.Null
                                                    )
                                                    {
                                                        //LogHelper.SendLog("X");
                                                        var value = settingsJson[prop.Name]
                                                            .ToObject(prop.PropertyType);
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
                                                if (log)
                                                    LogHelper.SendLog(
                                                        $"Keeping existing backup for {sectionName}."
                                                    );
                                            }
                                            catch (Exception ex)
                                            {
                                                LogHelper.SendLog("Error: " + ex);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogHelper.SendLog("Error: " + ex);
                                    }
                                }
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
                                LogHelper.SendLog("ERR: " + ex);
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
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    Error = (sender, args) =>
                    {
                        LogHelper.SendLog(
                            $"Serialization error on property '{args.ErrorContext.Member}': {args.ErrorContext.Error.Message}"
                        );
                        args.ErrorContext.Handled = true;
                    },
                };
                string jsonString = JsonConvert.SerializeObject(
                    ModSettings,
                    jsonSerializerSettings
                );
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
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    LogHelper.SendLog(
                        $"Serialization error on property '{args.ErrorContext.Member}': {args.ErrorContext.Error.Message}"
                    );
                    args.ErrorContext.Handled = true;
                },
                MaxDepth = 5,
            };
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
                    else if (
                        fragment.source.ToString().Contains("=====APM Settings=====")
                        && name == "78903"
                    )
                    {
                        (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(
                            fragment.source,
                            classType,
                            JsonSerializerSettings
                        );
                    }
                    else
                    {
                        //LogHelper.SendLog($"{fragment.source}+{name}");
                        bool validity = GetSectionValidity($"{name}+{fragment.source}");
                        //LogHelper.SendLog($"{fragment.source}+{name} is {validity}");
                        if (validity)
                        {
                            (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(
                                fragment.source,
                                classType,
                                JsonSerializerSettings
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

        private static bool GetSectionValidity(string fragmentSourceType)
        {
            //LogHelper.SendLog($"Choosing {fragmentSourceType}");
            return fragmentSourceType switch
            {
                // fragment.source => class
                "74286+FPS_Limiter.FPSLimiterSettings"
                or "74324+MoveIt.Settings.Settings"
                or "74328+FiveTwentyNineTiles.ModSettings"
                or "74535+HistoricalStart.ModSettings"
                or "74539+ImageOverlay.ModSettings"
                or "74604+Anarchy.Settings.AnarchyModSettings"
                or "75190+SchoolCapacityBalancer.Setting"
                or "75249+BrushSizeUnlimiter.MyOptions"
                or "75250+Better_Bulldozer.Settings.BetterBulldozerModSettings"
                or "75426+I18NEverywhere.Setting"
                or "75613+Water_Features.Settings.WaterFeaturesSettings"
                or "75684+DepotCapacityChanger.Setting"
                or "75826+PlopTheGrowables.ModSettings"
                or "75993+Tree_Controller.Settings.TreeControllerSettings"
                or "76662+EmploymentTracker.EmploymentTrackerSettings"
                or "76836+TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions"
                or "76849+SunGlasses.Setting"
                or "76908+AutoDistrictNameStations.ModOptions"
                or "76922+TerraformHardening.Settings"
                or "77171+Time2Work.Setting"
                or "77240+FindIt.FindItSettings"
                or "77260+WaterVisualTweaksMod.WaterVisualTweaksSettings"
                or "77463+RoadNameRemover.Setting"
                or "77923+BetterMoonLight.Setting"
                or "78131+StationNaming.Setting.StationNamingSettings"
                or "78188+ExtendedTooltip.ModSettings"
                or "78601+NoPollution.Setting"
                or "78622+TransportPolicyAdjuster.Setting"
                or "78847+AssetVariationChanger.Setting"
                or "78903+AssetPacksManager.Setting"
                or "78960+C2VM.TrafficLightsEnhancement.Settings"
                or "79186+SimpleModCheckerPlus.Setting"
                or "79237+FirstPersonCameraContinued.Setting"
                or "79634+AssetIconLibrary.Setting"
                or "79794+AdvancedSimulationSpeed.Setting"
                or "79872+AutoVehicleRenamer.Setting"
                or "80095+Traffic.ModSettings"
                or "80205+HardMode.Settings.HardModeSettings"
                or "80403+TransitCapacityMultiplier.Setting"
                or "80529+ExtraAssetsImporter.Setting"
                or "80826+Whiteness_Toggle.Setting"
                or "80931+ToggleableOverlays.Setting"
                or "81012+VehicleVariationPacks.Setting"
                or "81157+AreaBucket.Setting"
                or "81407+StifferVehicles.Setting"
                or "81568+ZoneColorChanger.Setting"
                or "82374+BetterSaveList.Setting"
                or "84638+Recolor.Settings.Setting"
                or "85211+NoTrafficDespawn.TrafficDespawnSettings"
                or "85284+CityStats.ModSettings"
                or "86124+TradingCostTweaker.Setting"
                or "86462+PathfindingCustomizer.Setting"
                or "86510+NoTeleporting.Setting"
                or "86605+AllAboard.Setting"
                or "86728+BoundaryLinesModifier.Setting"
                or "86868+RealLife.Setting"
                or "86944+DemandMasterControl.Setting"
                or "87190+RoadBuilder.Setting"
                or "87313+RealisticParking.Setting"
                or "87422+OSMExport.Setting"
                or "87428+Carto.Settings"
                or "87755+RealisticWorkplacesAndHouseholds.Setting"
                or "88266+LazyPedestrians.Settings"
                or "88500+NoDeadTrees.NoDeadTreesSetting"
                or "89495+CityController.Settings.Setting"
                or "90264+SmartTransportation.Setting"
                or "90641+HallOfFame.Settings"
                or "91433+InfoLoomTwo.Setting"
                or "92499+IndustriesExtended.ModSettings"
                or "92908+BelzontWE.WEModData"
                or "92952+CitizenModelManager.Setting"
                or "93523+NavigationView.Setting"
                or "94762+BuildingUse.ModSettings"
                or "95437+RegionFlagIcons.Setting"
                or "95872+CameraFieldOfView.Setting"
                or "96267+NoWaterElectricity.Setting"
                or "96645+HideBuildingNotification.Setting"
                or "96718+RoadWearAdjuster.Setting"
                or "97195+ParkingMonitor.Setting"
                or "98560+AssetUIManager.Setting"
                or "99048+ResourceLocator.ModSettings"
                or "102080+CrowdedStation.ModSettings"
                or "102147+AdvancedRoadTools.Setting"
                or "102892+CameraDrag.Setting"
                or "103515+TrafficJamMaker.ModSettings"
                or "103983+ShowMoreHappiness.ModSettings"
                or "104707+DetailedDescriptions.Setting"
                or "104781+VehicleController.Setting"
                or "104818+HomeOfHomeless.ModSettings"
                or "105288+AssetIconCreator.Setting"
                or "105715+DisableAccidents.ModSettings.Setting"
                or "105800+EventsController.Settings.Setting"
                or "106609+IndustryAutoTaxAdjuster.Setting"
                or "106957+RentMod2.RentModSettings"
                or "107487+SmartUpkeepManager.Setting"
                or "107939+MapExtPDX.ModSettings"
                or "109086+AirplaneParameterMod.Setting"
                or "110245+UrbanInequality.Setting"
                or "112452+ParkingPricing.ModSettings"
                or "113193+BuildingUsageTracker.Setting"
                or "113708+PrefabAssetFixes.Setting"
                or "114101+ChangeCompany.ModSettings" => true,
                _ => false,
            };
            ;
        }

        private static (bool, object) ProcessFragmentSource(
            object source,
            Type classType,
            JsonSerializerSettings jsonSerializerSettings
        )
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
                            return p.GetValue(source);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog($"❌ {p.Name}: {ex.Message}");
                            return null;
                        }
                    }
                );

            object settingsBackup = (ISettingsBackup)Activator.CreateInstance(classType);
            JObject sourceObj = JObject.FromObject(
                props,
                JsonSerializer.Create(jsonSerializerSettings)
            );

            //string TempForLogging = JsonConvert.SerializeObject(sourceObj);
            //LogHelper.SendLog(TempForLogging);
            var properties = classType.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    if (sourceObj.TryGetValue(property.Name, out JToken valueToken))
                    {
                        var value = valueToken.ToObject(property.PropertyType);
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
                    {
                        continue;
                    }
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
                        delay: 5f
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
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    LogHelper.SendLog(
                        $"Serialization error on property '{args.ErrorContext.Member}': {args.ErrorContext.Error.Message}"
                    );
                    args.ErrorContext.Handled = true;
                },
                MaxDepth = 5,
            };
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
                        string sectionKey = GetSectionKey($"{fragmentSourceType}+{name}");
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
                                            LogHelper.SendLog($"❌ {p.Name}: {ex.Message}");
                                            return null;
                                        }
                                    }
                                );

                            //LogHelper.SendLog("sectionKey != null && sectionKey == className");
                            JObject sectionSource = JObject.FromObject(
                                props,
                                JsonSerializer.Create(JsonSerializerSettings)
                            );

                            if (sourceObj[sectionKey] is JObject jsonSettingsSection)
                            {
                                //LogHelper.SendLog("sourceObj[sectionKey] is JObject jsonSettingsSection)");
                                foreach (var prop in jsonSettingsSection.Properties())
                                {
                                    var propInfo = fragment.source.GetType().GetProperty(prop.Name);
                                    if (
                                        propInfo != null
                                        && propInfo.CanWrite
                                        && !propInfo
                                            .ToString()
                                            .StartsWith("Game.Input.ProxyBinding")
                                    )
                                    {
                                        var oldValue = propInfo.GetValue(fragment.source);
                                        var newValue = prop.Value.ToObject(propInfo.PropertyType);
                                        if (!oldValue.Equals(newValue))
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
                                    $"{sectionKey} settings not found in the backup."
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
            //LogHelper.SendLog($"Done {name}");
        }

        private string GetSectionKey(string fragmentSourceType)
        {
            //LogHelper.SendLog($"Choosing {fragmentSourceType}");
            return fragmentSourceType switch
            {
                // fragment.source => class
                "FPS_Limiter.FPSLimiterSettings+FPS_Limiter" => "FPSLimiterSettings",
                "MoveIt.Settings.Settings+MoveIt" => "MoveItSettings",
                "FiveTwentyNineTiles.ModSettings+FiveTwentyNineTiles" =>
                    "FiveTwentyNineTilesSettings",
                "HistoricalStart.ModSettings+HistoricalStart" => "HistoricalStartSettings",
                "ImageOverlay.ModSettings+ImageOverlay" => "ImageOverlaySettings",
                "Anarchy.Settings.AnarchyModSettings+Anarchy" => "AnarchySettings",
                "SchoolCapacityBalancer.Setting+SchoolCapacityBalancer" =>
                    "SchoolCapacityBalancerSettings",
                "BrushSizeUnlimiter.MyOptions+BrushSizeUnlimiter" => "BrushSizeUnlimiterSettings",
                "Better_Bulldozer.Settings.BetterBulldozerModSettings+BetterBulldozer" =>
                    "BetterBulldozerSettings",
                "I18NEverywhere.Setting+I18NEverywhere" => "I18NEverywhereSettings",
                "Water_Features.Settings.WaterFeaturesSettings+Water_Features" =>
                    "WaterFeaturesSettings",
                "DepotCapacityChanger.Setting+DepotCapacityChanger" =>
                    "DepotCapacityChangerSettings",
                "PlopTheGrowables.ModSettings+PlopTheGrowables" => "PlopTheGrowablesSettings",
                "Tree_Controller.Settings.TreeControllerSettings+Tree_Controller" =>
                    "TreeControllerSettings",
                "EmploymentTracker.EmploymentTrackerSettings+EmploymentTracker" =>
                    "CimRouteHighlighterSettings",
                "TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions+TrafficSimulationAdjuster" =>
                    "TrafficSimulationAdjusterSettings",
                "SunGlasses.Setting+SunGlasses" => "SunGlassesSettings",
                "AutoDistrictNameStations.ModOptions+AutoDistrictNameStations" =>
                    "AutoDistrictNameStationsSettings",
                "TerraformHardening.Settings+TerraformHardening" => "TerraformHardeningSettings",
                "Time2Work.Setting+Time2Work" => "RealisticTripsSettings",
                "FindIt.FindItSettings+FindIt" => "FindItSettings",
                "WaterVisualTweaksMod.WaterVisualTweaksSettings+WaterVisualTweaks" =>
                    "WaterVisualTweaksSettings",
                "RoadNameRemover.Setting+RoadNameRemover" => "RoadNameRemoverSettings",
                "BetterMoonLight.Setting+BetterMoonLight" => "BetterMoonLightSettings",
                "StationNaming.Setting.StationNamingSettings+StationNaming" =>
                    "StationNamingSettings",
                "ExtendedTooltip.ModSettings+ExtendedTooltip" => "ExtendedTooltipSettings",
                "NoPollution.Setting+NoPollution" => "NoPollutionSettings",
                "TransportPolicyAdjuster.Setting+TransportPolicyAdjuster" =>
                    "TransportPolicyAdjusterSettings",
                "AssetVariationChanger.Setting+AssetVariationChanger" =>
                    "AssetVariationChangerSettings",
                "AssetPacksManager.Setting+AssetPacksManager" => "AssetPacksManagerSettings",
                "C2VM.TrafficLightsEnhancement.Settings+C2VM.TrafficLightsEnhancement" =>
                    "TrafficLightsEnhancementSettings",
                "SimpleModCheckerPlus.Setting+SimpleModChecker" => "SimpleModCheckerSettings",
                "FirstPersonCameraContinued.Setting+FirstPersonCameraContinued" =>
                    "FirstPersonCameraContinuedSettings",
                "AssetIconLibrary.Setting+AssetIconLibrary" => "AssetIconLibrarySettings",
                "AdvancedSimulationSpeed.Setting+AdvancedSimulationSpeed" =>
                    "AdvancedSimulationSpeedSettings",
                "AutoVehicleRenamer.Setting+AutoVehicleRenamer" => "AutoVehicleRenamerSettings",
                "Traffic.ModSettings+Traffic" => "TrafficSettings",
                "HardMode.Settings.HardModeSettings+HardMode" => "HardModeSettings",
                "TransitCapacityMultiplier.Setting+TransitCapacityMultiplier" =>
                    "TransitCapacityMultiplierSettings",
                "ExtraAssetsImporter.Setting+ExtraAssetsImporter" => "ExtraAssetsImporterSettings",
                "Whiteness_Toggle.Setting+Whiteness-Toggle" => "WhitenessToggleSettings",
                "ToggleableOverlays.Setting+ToggleableOverlays" => "ToggleOverlaysSettings",
                "VehicleVariationPacks.Setting+VehicleVariationPacks" =>
                    "VehicleVariationPacksSettings",
                "AreaBucket.Setting+AreaBucket" => "AreaBucketSettings",
                "StifferVehicles.Setting+StifferVehicles" => "StifferVehiclesSettings",
                "ZoneColorChanger.Setting+ZoneColorChanger" => "ZoneColorChangerSettings",
                "BetterSaveList.Setting+BetterSaveList" => "BetterSaveListSettings",
                "Recolor.Settings.Setting+Recolor" => "RecolorSettings",
                "NoTrafficDespawn.TrafficDespawnSettings+NoTrafficDespawn" =>
                    "NoVehicleDespawnSettings",
                "CityStats.ModSettings+CityStats" => "CityStatsSettings",
                "TradingCostTweaker.Setting+TradingCostTweaker" => "TradingCostTweakerSettings",
                "PathfindingCustomizer.Setting+PathfindingCustomizer" =>
                    "PathfindingCustomizerSettings",
                "NoTeleporting.Setting+NoTeleporting" => "NoTeleportingSettings",
                "AllAboard.Setting+AllAboard" => "AllAboardSettings",
                "BoundaryLinesModifier.Setting+BoundaryLinesModifier" =>
                    "BoundaryLinesModifierSettings",
                "RealLife.Setting+RealLife" => "RealLifeSettings",
                "DemandMasterControl.Setting+DemandMasterControl" => "DemandMasterControlSettings",
                "RoadBuilder.Setting+RoadBuilder" => "RoadBuilderSettings",
                "RealisticParking.Setting+RealisticParking" => "RealisticParkingSettings",
                "OSMExport.Setting+OSMExport" => "OSMExportSettings",
                "Carto.Settings+Carto" => "CartoSettings",
                "RealisticWorkplacesAndHouseholds.Setting+RWH" =>
                    "RealisticWorkplacesAndHouseholdsSettings",
                "LazyPedestrians.Settings+LazyPedestrians" => "LazyPedestriansSettings",
                "NoDeadTrees.NoDeadTreesSetting+NoDeadTrees" => "NoDeadTreesSettings",
                "CityController.Settings.Setting+CityController" => "CityControllerSettings",
                "SmartTransportation.Setting+SmartTransportation" => "SmartTransportationSettings",
                "HallOfFame.Settings+HallOfFame" => "HallOfFameSettings",
                "InfoLoomTwo.Setting+InfoLoomTwo" => "InfoLoomTwoSettings",
                "IndustriesExtended.ModSettings+IndustriesExtended" => "IndustriesExtendedSettings",
                "BelzontWE.WEModData+BelzontWE" => "WriteEverywhereSettings",
                "CitizenModelManager.Setting+CitizenModelManager" => "CitizenModelManagerSettings",
                "NavigationView.Setting+NavigationView" => "NavigationViewSettings",
                "BuildingUse.ModSettings+BuildingUse" => "BuildingUseSettings",
                "RegionFlagIcons.Setting+RegionFlagIcons" => "RegionFlagIconsSettings",
                "CameraFieldOfView.Setting+CameraFieldOfView" => "CameraFieldOfViewSettings",
                "NoWaterElectricity.Setting+NoWaterElectricity" => "NoWaterElectricitySettings",
                "HideBuildingNotification.Setting+HideBuildingNotification" =>
                    "HideBuildingsNotificationSettings",
                "RoadWearAdjuster.Setting+RoadWearAdjuster" => "RoadWearAdjusterSettings",
                "ParkingMonitor.Setting+ParkingMonitor" => "ParkingMonitorSettings",
                "AssetUIManager.Setting+AssetUIManager" => "AssetUIManagerSettings",
                "ResourceLocator.ModSettings+ResourceLocator" => "ResourceLocatorSettings",
                "CrowdedStation.ModSettings+CrowdedStation" => "CrowdedStationSettings",
                "AdvancedRoadTools.Setting+AdvancedRoadTools" => "AdvancedRoadToolsSettings",
                "CameraDrag.Setting+CameraDrag" => "CameraDragSettings",
                "TrafficJamMaker.ModSettings+TrafficJamMaker" => "TrafficJamMonitorSettings",
                "ShowMoreHappiness.ModSettings+ShowMoreHappiness" => "ShowMoreHappinessSettings",
                "DetailedDescriptions.Setting+DetailedDescriptions" =>
                    "DetailedDescriptionsSettings",
                "VehicleController.Setting+VehicleController" => "VehicleControllerSettings",
                "HomeOfHomeless.ModSettings+HomeOfHomeless" => "HomeOfHomelessSettings",
                "AssetIconCreator.Setting+AssetIconCreator" => "AssetIconCreatorSettings",
                "DisableAccidents.ModSettings.Setting+DisableAccidents" =>
                    "DisableAccidentsSettings",
                "EventsController.Settings.Setting+EventsController" => "EventsControllerSettings",
                "IndustryAutoTaxAdjuster.Setting+IndustryAutoTaxAdjuster" =>
                    "IndustryAutoTaxAdjusterSettings",
                "RentMod2.RentModSettings+RentMod2" => "RentMattersAgainSettings",
                "SmartUpkeepManager.Setting+SmartUpkeepManager" => "SmartUpkeepManagerSettings",
                "MapExtPDX.ModSettings+MapExt2" => "MapExtSettings",
                "AirplaneParameterMod.Setting+AirplaneParameterMod" =>
                    "AirplaneParameterModSettings",
                "UrbanInequality.Setting+UrbanInequality" => "UrbanInequalitySettings",
                "ParkingPricing.ModSettings+ParkingPricing" => "ParkingPricingSettings",
                "BuildingUsageTracker.Setting+BuildingUsageTracker" =>
                    "BuildingUsageTrackerSettings",
                "PrefabAssetFixes.Setting+PrefabAssetFixes" => "PrefabAssetFixesSettings",
                "ChangeCompany.ModSettings+ChangeCompany" => "ChangeCompanySettings",
                _ => null,
            };
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
                                LogHelper.SendLog(JSON.Dump(fragment.source));
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
