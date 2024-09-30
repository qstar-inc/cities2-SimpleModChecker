// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Colossal.Serialization.Entities;
using Game.Modding;
using Game.PSI;
using Game.UI.Localization;
using Game;
using Mod = SimpleModCheckerPlus.Mod;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;

namespace SimpleModChecker.Systems
{
    public partial class ModSettingsBackup : GameSystemBase
    {
        public SimpleModCheckerPlus.Mod _mod;
        public static ModNotification SMC = new();
        private readonly List<string> loadedMods = SMC.GetLoadedMods();
        public static ModManager modManager;
        private readonly string backupFile0 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_prev.json";
        private readonly string backupFile1 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_1.json";
        private readonly string backupFile2 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_2.json";
        private readonly string backupFile3 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_3.json";
        private readonly string backupFile4 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_4.json";
        private readonly string backupFile5 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_5.json";
        private readonly string backupFile6 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_6.json";
        private readonly string backupFile7 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_7.json";
        private readonly string backupFile8 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_8.json";
        private readonly string backupFile9 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\ModSettingsBackup_9.json";

        private static readonly Dictionary<string, SettingInfo> settingsDictionary = new()
        {
            { "529Tile", new SettingInfo { AssemblyName = "FiveTwentyNineTiles", FragmentSource = "FiveTwentyNineTiles.ModSettings", ClassType = typeof(FiveTwentyNineTilesSettings)} },
            { "AdvancedSimulationSpeed", new SettingInfo { AssemblyName = "AdvancedSimulationSpeed", FragmentSource = "AdvancedSimulationSpeed.Setting", ClassType = typeof(AdvancedSimulationSpeedSettings)} },
            { "AllAboard", new SettingInfo { AssemblyName = "AllAboard", FragmentSource = "AllAboard.Setting", ClassType = typeof(AllAboardSettings)} },
            { "Anarchy", new SettingInfo { AssemblyName = "Anarchy", FragmentSource = "Anarchy.Settings.AnarchyModSettings", ClassType = typeof(AnarchySettings)} },
            { "AssetIconLibrary", new SettingInfo { AssemblyName = "AssetIconLibrary", FragmentSource = "AssetIconLibrary.Setting", ClassType = typeof(AssetIconLibrarySettings)} },
            { "AssetPacksManager", new SettingInfo { AssemblyName = "AssetPacksManager", FragmentSource = "AssetPacksManager.Setting", ClassType = typeof(AssetPacksManagerSettings)} },
            { "AssetVariationChanger", new SettingInfo { AssemblyName = "AssetVariationChanger", FragmentSource = "AssetVariationChanger.Setting", ClassType = typeof(AssetVariationChangerSettings)} },
            { "AutoDistrictNameStations", new SettingInfo { AssemblyName = "AutoDistrictNameStations", FragmentSource = "AutoDistrictNameStations.ModOptions", ClassType = typeof(AutoDistrictNameStationsSettings)} },
            { "AutoVehicleRenamer", new SettingInfo { AssemblyName = "AutoVehicleRenamer", FragmentSource = "AutoVehicleRenamer.AutoVehicleRenamerSetting", ClassType = typeof(AutoVehicleRenamerSettings)} },
            { "BetterBulldozer", new SettingInfo { AssemblyName = "BetterBulldozer", FragmentSource = "Better_Bulldozer.Settings.BetterBulldozerModSettings", ClassType = typeof(BetterBulldozerSettings)} },
            { "BetterMoonLight", new SettingInfo { AssemblyName = "BetterMoonLight", FragmentSource = "BetterMoonLight.Setting", ClassType = typeof(BetterMoonLightSettings)} },
            { "BetterSaveList", new SettingInfo { AssemblyName = "BetterSaveList", FragmentSource = "BetterSaveList.Setting", ClassType = typeof(BetterSaveListSettings)} },
            { "BoundaryLinesModifier", new SettingInfo { AssemblyName = "BoundaryLinesModifier", FragmentSource = "BoundaryLinesModifier.Setting", ClassType = typeof(BoundaryLinesModifierSettings)} },
            { "BrushSizeUnlimiter", new SettingInfo { AssemblyName = "BrushSizeUnlimiter", FragmentSource = "BrushSizeUnlimiter.MyOptions", ClassType = typeof(BrushSizeUnlimiterSettings)} },
            { "CimRouteHighlighter", new SettingInfo { AssemblyName = "EmploymentTracker", FragmentSource = "EmploymentTracker.EmploymentTrackerSettings", ClassType = typeof(CimRouteHighlighterSettings)} },
            { "CityStats", new SettingInfo { AssemblyName = "CityStats", FragmentSource = "CityStats.ModSettings", ClassType = typeof(CityStatsSettings)} },
            { "DemandMaster", new SettingInfo { AssemblyName = "DemandMaster", FragmentSource = "DemandMaster.Setting", ClassType = typeof(DemandMasterSettings)} },
            { "DepotCapacityChanger", new SettingInfo { AssemblyName = "DepotCapacityChanger", FragmentSource = "DepotCapacityChanger.Setting", ClassType = typeof(DepotCapacityChangerSettings)} },
            { "ExtendedTooltip", new SettingInfo { AssemblyName = "ExtendedTooltip", FragmentSource = "ExtendedTooltip.ModSettings", ClassType = typeof(ExtendedTooltipSettings)} },
            { "ExtraAssetsImporter", new SettingInfo { AssemblyName = "ExtraAssetsImporter", FragmentSource = "ExtraAssetsImporter.Setting", ClassType = typeof(ExtraAssetsImporterSettings)} },
            { "FindIt", new SettingInfo { AssemblyName = "FindIt", FragmentSource = "FindIt.FindItSettings", ClassType = typeof(FindItSettings)} },
            { "FirstPersonCameraContinued", new SettingInfo { AssemblyName = "FirstPersonCameraContinued", FragmentSource = "FirstPersonCameraContinued.Setting", ClassType = typeof(FirstPersonCameraContinuedSettings)} },
            { "FPSLimiter", new SettingInfo { AssemblyName = "FPS_Limiter", FragmentSource = "FPS_Limiter.FPSLimiterSettings", ClassType = typeof(FPSLimiterSettings)} },
            { "HallOfFame", new SettingInfo { AssemblyName = "HallOfFame", FragmentSource = "HallOfFame.Settings", ClassType = typeof(HallOfFameSettings)} },
            { "I18NEverywhere", new SettingInfo { AssemblyName = "I18NEverywhere", FragmentSource = "I18NEverywhere.Setting", ClassType = typeof(I18NEverywhereSettings)} },
            { "ImageOverlay", new SettingInfo { AssemblyName = "Image   Overlay", FragmentSource = "ImageOverlay.ModSettings", ClassType = typeof(ImageOverlaySettings)} },
            { "MoveIt", new SettingInfo { AssemblyName = "MoveIt", FragmentSource = "MoveIt.Settings.Settings", ClassType = typeof(MoveItSettings)} },
            { "NoPollution", new SettingInfo { AssemblyName = "NoPollution", FragmentSource = "NoPollution.Setting", ClassType = typeof(NoPollutionSettings)} },
            { "NoTeleporting", new SettingInfo { AssemblyName = "NoTeleporting", FragmentSource = "NoTeleporting.Setting", ClassType = typeof(NoTeleportingSettings)} },
            { "NoVehicleDespawn", new SettingInfo { AssemblyName = "NoTrafficDespawn", FragmentSource = "NoTrafficDespawn.TrafficDespawnSettings", ClassType = typeof(NoVehicleDespawnSettings)} },
            { "PathfindingCustomizer", new SettingInfo { AssemblyName = "PathfindingCustomizer", FragmentSource = "PathfindingCustomizer.Setting", ClassType = typeof(PathfindingCustomizerSettings)} },
            { "PlopTheGrowables", new SettingInfo { AssemblyName = "PlopTheGrowables", FragmentSource = "PlopTheGrowables.ModSettings", ClassType = typeof(PlopTheGrowablesSettings)} },
            { "RealisticParking", new SettingInfo { AssemblyName = "RealisticParking", FragmentSource = "RealisticParking.Setting", ClassType = typeof(RealisticParkingSettings)} },
            { "RealisticTrips", new SettingInfo { AssemblyName = "Time2Work", FragmentSource = "Time2Work.Setting", ClassType = typeof(RealisticTripsSettings)} },
            { "RealisticWorkplacesAndHouseholds", new SettingInfo { AssemblyName = "RWH", FragmentSource = "RealisticWorkplacesAndHouseholds.Setting", ClassType = typeof(RealisticWorkplacesAndHouseholdsSettings)} },
            { "RealLife", new SettingInfo { AssemblyName = "RealLife", FragmentSource = "RealLife.Setting", ClassType = typeof(RealLifeSettings)} },
            { "Recolor", new SettingInfo { AssemblyName = "Recolor", FragmentSource = "Recolor.Settings.Setting", ClassType = typeof(RecolorSettings)} },
            { "RoadBuilder", new SettingInfo { AssemblyName = "RoadBuilder", FragmentSource = "RoadBuilder.Setting", ClassType = typeof(RoadBuilderSettings)} },
            { "RoadNameRemover", new SettingInfo { AssemblyName = "RoadNameRemover", FragmentSource = "RoadNameRemover.Setting", ClassType = typeof(RoadNameRemoverSettings)} },
            { "SchoolCapacityBalancer", new SettingInfo { AssemblyName = "SchoolCapacityBalancer", FragmentSource = "SchoolCapacityBalancer.Setting", ClassType = typeof(SchoolCapacityBalancerSettings)} },
            { "SimpleModChecker", new SettingInfo { AssemblyName = "SimpleModChecker", FragmentSource = "SimpleModCheckerPlus.Setting", ClassType = typeof(SimpleModCheckerSettings)} },
            { "SmartTransportation", new SettingInfo { AssemblyName = "SmartTransportation", FragmentSource = "SmartTransportation.Setting", ClassType = typeof(SmartTransportationSettings)} },
            { "StationNaming", new SettingInfo { AssemblyName = "StationNaming", FragmentSource = "StationNaming.Setting.StationNamingSettings", ClassType = typeof(StationNamingSettings)} },
            { "StifferVehicles", new SettingInfo { AssemblyName = "StifferVehicles", FragmentSource = "StifferVehicles.Setting", ClassType = typeof(StifferVehiclesSettings)} },
            { "SunGlasses", new SettingInfo { AssemblyName = "SunGlasses", FragmentSource = "SunGlasses.Setting", ClassType = typeof(SunGlassesSettings)} },
            { "ToggleOverlays", new SettingInfo { AssemblyName = "ToggleableOverlays", FragmentSource = "ToggleableOverlays.Setting", ClassType = typeof(ToggleOverlaysSettings)} },
            { "TradingCostTweaker", new SettingInfo { AssemblyName = "TradingCostTweaker", FragmentSource = "TradingCostTweaker.Setting", ClassType = typeof(TradingCostTweakerSettings)} },
            { "Traffic", new SettingInfo { AssemblyName = "Traffic", FragmentSource = "Traffic.ModSettings", ClassType = typeof(TrafficSettings)} },
            { "TrafficLightsEnhancement", new SettingInfo { AssemblyName = "C2VM.TrafficLightsEnhancement", FragmentSource = "C2VM.TrafficLightsEnhancement.Settings", ClassType = typeof(TrafficLightsEnhancementSettings)} },
            { "TrafficSimulationAdjuster", new SettingInfo { AssemblyName = "TrafficSimulationAdjuster", FragmentSource = "TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions", ClassType = typeof(TrafficSimulationAdjusterSettings)} },
            { "TransitCapacityMultiplier", new SettingInfo { AssemblyName = "TransitCapacityMultiplier", FragmentSource = "TransitCapacityMultiplier.Setting", ClassType = typeof(TransitCapacityMultiplierSettings)} },
            { "TransportPolicyAdjuster", new SettingInfo { AssemblyName = "TransportPolicyAdjuster", FragmentSource = "TransportPolicyAdjuster.Setting", ClassType = typeof(TransportPolicyAdjusterSettings)} },
            { "TreeController", new SettingInfo { AssemblyName = "Tree_Controller", FragmentSource = "Tree_Controller.Settings.TreeControllerSettings", ClassType = typeof(TreeControllerSettings)} },
            { "TripsData", new SettingInfo { AssemblyName = "TripsData", FragmentSource = "TripsData.Setting", ClassType = typeof(TripsDataSettings)} },
            { "VehicleVariationPacks", new SettingInfo { AssemblyName = "VehicleVariationPacks", FragmentSource = "VehicleVariationPacks.Setting", ClassType = typeof(VehicleVariationPacksSettings)} },
            { "WaterFeatures", new SettingInfo { AssemblyName = "Water_Features", FragmentSource = "Water_Features.Settings.WaterFeaturesSettings", ClassType = typeof(WaterFeaturesSettings)} },
            { "WaterVisualTweaks", new SettingInfo { AssemblyName = "WaterVisualTweaks", FragmentSource = "WaterVisualTweaksMod.WaterVisualTweaksSettings", ClassType = typeof(WaterVisualTweaksSettings)} },
            { "ZoneColorChanger", new SettingInfo { AssemblyName = "ZoneColorChanger", FragmentSource = "ZoneColorChanger.Setting", ClassType = typeof(ZoneColorChangerSettings)} },
        };

        protected override void OnCreate()
        {
            base.OnCreate();
        }
        private bool AutoRestoreDone = false;

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            //Mod.log.Info("OnGameLoadingComplete");
            if (!AutoRestoreDone && mode == GameMode.MainMenu)
            {
                if (Mod.Setting.AutoRestoreSettingBackupOnStartup)
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
                                    if (!jsonObject.TryGetValue("ModVersion", out JToken BackupModVersion) || BackupModVersion == null)
                                    {
                                        SendModUpdateNotification(currentModVersion, "null");
                                    }
                                    else
                                    {
                                        if (BackupModVersion.ToString() != currentModVersion)
                                        {
                                            SendModUpdateNotification(currentModVersion, BackupModVersion.ToString());
                                        }
                                    }
                                }
                            }
                            catch (Exception ex) { Mod.log.Info(ex); }
                        }
                            
                        CreateBackup(0);
                        if (!File.ReadAllText(backupFile0).Equals(File.ReadAllText(backupFile1)))
                        {
                            RestoreBackup(1, false);
                            NotificationSystem.Pop("starq-smc-mod-settings-restore",
                                    title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                                    text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreMods]"),
                                    onClicked: () => { },
                                    delay: 10f);
                        }
                        else
                        {
                            Mod.log.Info("Nothing to restore");
                        }
                    }
                    else
                    {
                        Mod.log.Info("Auto Restore failed, no Mod Setting Backup was found.");
                    }
                }
                else
                {
                    Mod.log.Info("Auto Restore is disabled...");
                }
                AutoRestoreDone = true;
            }
        }

        protected override void OnUpdate()
        {

        }

        private void SendModUpdateNotification(string current, string prev)
        {
            Mod.log.Info($"Mod version mismatch. Current: {current}, Backup: {prev}");
            NotificationSystem.Push("starq-smc-mod-settings-update",
                title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeBackup]"),
                text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeBackup]"),
                progressState: ProgressState.Warning,
                onClicked: () => { NotificationSystem.Pop("starq-smc-mod-settings-update", delay: 1f); CreateBackup(1); });
        }

        public void CreateBackup(int profile)
        {
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
            Mod.log.Info($"Creating Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            ModSettings ModSettings = new();

            ModSettings.ModVersion = Mod.Version;
            ModSettings.LastUpdated = DateTime.Now.ToLongDateString();

            foreach (var entry in settingsDictionary)
            {
                try
                {
                    string sectionName = entry.Key;
                    string fragmentSource = entry.Value.FragmentSource;
                    Type classType = entry.Value.ClassType;
                    string assembly = entry.Value.AssemblyName;

                    //Mod.log.Info($"Entry ready for backup: {sectionName}, {fragmentSource}, {classType.Name}, {assembly}");
                    if (fragmentSource == "FiveTwentyNineTiles.ModSettings") { fragmentSource = "529."; }
                    if (fragmentSource == "AutoDistrictNameStations.ModOptions") { fragmentSource = "AutoDistrict."; }

                    PropertyInfo property = typeof(ModSettings).GetProperty($"{entry.Value.ClassType.Name}");
                    object sectionSettings;// = Activator.CreateInstance(classType);
                    sectionSettings = default;
                    if (!loadedMods.Contains(assembly))
                    {
                        if (File.Exists(backupFile))
                        {
                            string jsonStringRead = File.ReadAllText(backupFile);
                            if (jsonStringRead != null && jsonStringRead != "")
                            {
                                try
                                {
                                    JObject jsonObject = JObject.Parse(jsonStringRead);

                                    if (jsonObject[classType.Name] != null)
                                    {
                                        //Mod.log.Info($"Existing {sectionName}Settings found.");
                                        sectionSettings = jsonObject[entry.Value.ClassType.Name].ToObject(classType);
                                    }
                                }
                                catch (Exception ex) { Mod.log.Info(ex); }
                            }
                        }
                    }
                    else
                    {
                        sectionSettings = GetSettingsData(sectionName, fragmentSource, sectionSettings, classType);
                    }

                    //string TempForLogging = JsonConvert.SerializeObject(sectionSettings);
                    //Mod.log.Info(TempForLogging);
                    property?.SetValue(ModSettings, sectionSettings);
                }
                catch (Exception ex) { Mod.log.Info(ex); }
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(ModSettings, Formatting.Indented);
                File.WriteAllText(backupFile, jsonString);
            }
            catch (Exception ex) { Mod.log.Info(ex); }
        }

        public object GetSettingsData(string name, string fragmentSource, object settingsBackup, Type classType)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var filter = SearchFilter<SettingAsset>.ByCondition(asset => asset.name.Contains(fragmentSource.Substring(0, fragmentSource.IndexOf("."))) || asset.name.Contains(name));
            var settingAssets = AssetDatabase.global.GetAssets(filter);
            bool ProcessedFragmentSource = false;
            foreach (SettingAsset settingAsset in settingAssets)
            {
                //try { Mod.log.Info(settingAsset.name); } catch (Exception ex) { Mod.log.Info(ex); }

                foreach (var fragment in settingAsset)
                {
                    //try { Mod.log.Info(fragment.name); } catch (Exception ex) { Mod.log.Info(ex); }
                    
                    //try { Mod.log.Info($"{fragment.name} is {fragment.source.GetType().Name}"); } catch (Exception ex) { Mod.log.Info(ex); }
                    if (fragment.source.GetType().Name == "UnityLogger" )
                    {
                        //Mod.log.Info("Skipping Logger");
                        break;
                    }
                    else if (fragment.source.ToString().Contains("=====APM Settings=====") && name == "AssetPacksManager")
                    {
                        (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(fragment.source, settingsBackup, classType, JsonSerializerSettings);
                    }
                    else
                    {
                        switch (fragment.source.ToString())
                        {
                            case "FiveTwentyNineTiles.ModSettings":
                            case "AdvancedSimulationSpeed.Setting":
                            case "AllAboard.Setting":
                            case "Anarchy.Settings.AnarchyModSettings":
                            case "AssetIconLibrary.Setting":
                            //case "AssetPacksManager.Setting":
                            case "AssetVariationChanger.Setting":
                            case "AutoDistrictNameStations.ModOptions":
                            case "AutoVehicleRenamer.AutoVehicleRenamerSetting":
                            case "Better_Bulldozer.Settings.BetterBulldozerModSettings":
                            case "BetterMoonLight.Setting":
                            case "BetterSaveList.Setting":
                            case "BoundaryLinesModifier.Setting":
                            case "BrushSizeUnlimiter.MyOptions":
                            case "EmploymentTracker.EmploymentTrackerSettings":
                            case "CityStats.ModSettings":
                            case "DemandMaster.Setting":
                            case "DepotCapacityChanger.Setting":
                            case "ExtendedTooltip.ModSettings":
                            case "ExtraAssetsImporter.Setting":
                            case "FindIt.FindItSettings":
                            case "FirstPersonCameraContinued.Setting":
                            case "FPS_Limiter.FPSLimiterSettings":
                            case "HallOfFame.Settings":
                            case "I18NEverywhere.Setting":
                            case "ImageOverlay.ModSettings":
                            case "MoveIt.Settings.Settings":
                            case "NoPollution.Setting":
                            case "NoTeleporting.Setting":
                            case "NoTrafficDespawn.TrafficDespawnSettings":
                            case "PathfindingCustomizer.Setting":
                            case "PlopTheGrowables.ModSettings":
                            case "RealisticParking.Setting":
                            case "Time2Work.Setting":
                            case "RealisticWorkplacesAndHouseholds.Setting":
                            case "RealLife.Setting":
                            case "Recolor.Settings.Setting":
                            case "RoadBuilder.Setting":
                            case "RoadNameRemover.Setting":
                            case "SchoolCapacityBalancer.Setting":
                            case "SimpleModCheckerPlus.Setting":
                            case "SmartTransportation.Setting":
                            case "StationNaming.Setting.StationNamingSettings":
                            case "StifferVehicles.Setting":
                            case "SunGlasses.Setting":
                            case "ToggleableOverlays.Setting":
                            case "TradingCostTweaker.Setting":
                            case "Traffic.ModSettings":
                            case "C2VM.TrafficLightsEnhancement.Settings":
                            case "TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions":
                            case "TransitCapacityMultiplier.Setting":
                            case "TransportPolicyAdjuster.Setting":
                            case "Tree_Controller.Settings.TreeControllerSettings":
                            case "TripsData.Setting":
                            case "VehicleVariationPacks.Setting":
                            case "Water_Features.Settings.WaterFeaturesSettings":
                            case "WaterVisualTweaksMod.WaterVisualTweaksSettings":
                            case "ZoneColorChanger.Setting":
                                (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(fragment.source, settingsBackup, classType, JsonSerializerSettings);
                                break;
                            default:
                                Mod.log.Info($"Failed finding { fragment.source.ToString()}");
                                break;
                        }
                    }
                    if (ProcessedFragmentSource)
                    {
                        break;
                    }
                }
            }
            if (ProcessedFragmentSource)
            {
                return settingsBackup;
            } else
            {
                return null;
            }
        }

        private (bool, object) ProcessFragmentSource(object source, object settingsBackup, Type classType, JsonSerializerSettings jsonSerializerSettings)
        {
            settingsBackup = (ISettingsBackup)Activator.CreateInstance(classType);
            JObject sourceObj = JObject.FromObject(source, JsonSerializer.Create(jsonSerializerSettings));

            //string TempForLogging = JsonConvert.SerializeObject(sourceObj);
            //Mod.log.Info(TempForLogging);
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
                Mod.log.Error("Trying to Restore Backup, when Backup file is not found.");
                return;
            }

            Mod.log.Info("Restoring Backup");
            string jsonString = File.ReadAllText(backupFile);
            JObject jsonObject = JObject.Parse(jsonString);

            foreach (var entry in settingsDictionary)
            {
                string sectionName = entry.Key;
                string fragmentSource = entry.Value.FragmentSource;
                //Type classType = entry.Value.ClassType;
                string assembly = entry.Value.AssemblyName;

                if (fragmentSource == "FiveTwentyNineTiles.ModSettings") { fragmentSource = "529."; }
                if (fragmentSource == "AutoDistrictNameStations.ModOptions") { fragmentSource = "AutoDistrict."; }

                if (!loadedMods.Contains(assembly))
                {
                    //Mod.log.Info($"skipping {sectionName}...");
                }
                else
                {
                    SetSettings(sectionName, fragmentSource, jsonObject);
                }
            }
            return;
        }

        private protected void RestoreSection<T>(string sectionName, string jsonPropertyName, string fragmentSource, JObject jsonObject) where T : class
        {
            T sectionSettings = jsonObject[jsonPropertyName]?.ToObject<T>();

            if (sectionSettings != null)
            {
                this.SetSettings(sectionName, fragmentSource, jsonObject);
    }
            else
            {
                Mod.log.Info($"{sectionName}Settings not found");
            }
        }

        public void SetSettings(string name, string fragmentSource, JObject sourceObj)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            try
            {
                var settingAssets = AssetDatabase.global.GetAssets<SettingAsset>(fragmentSource.Substring(0, fragmentSource.IndexOf(".")));
                //Mod.log.Debug($"Setting settings: {name} ({settingAssets.Count()})");
                foreach (SettingAsset settingAsset in settingAssets)
                {
                    foreach (var fragment in settingAsset)
                    {
                        string fragmentSourceType = fragment.source.ToString();
                        string sectionKey = GetSectionKey(fragmentSourceType);

                        if (sectionKey != null)
                        {
                            JObject sectionSource = JObject.FromObject(fragment.source, JsonSerializer.Create(JsonSerializerSettings));

                            if (sourceObj[sectionKey] is JObject jsonSettingsSection)
                            {
                                foreach (var prop in jsonSettingsSection.Properties())
                                {
                                    var propInfo = fragment.source.GetType().GetProperty(prop.Name);
                                    if (propInfo != null && propInfo.CanWrite && !propInfo.ToString().StartsWith("Game.Input.ProxyBinding"))
                                    {
                                        propInfo.SetValue(fragment.source, prop.Value.ToObject(propInfo.PropertyType));
                                    }
                                }

                                Mod.log.Info($"Restoring {sectionKey} settings.");
                                try
                                {
                                    settingAsset.Save();
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Info($"Error saving {sectionKey} settings: {ex}");
                                }
                            }
                            else
                            {
                                Mod.log.Info($"{sectionKey} settings not found in the backup.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mod.log.Info($"{name} not found. Skipping restore... {ex}");
            }
        }

        private string GetSectionKey(string fragmentSourceType)
        {
            //Mod.log.Debug($"Choosing {fragmentSourceType}");
            return fragmentSourceType switch
            {
                // fragment.source => class
                "FiveTwentyNineTiles.ModSettings" => "FiveTwentyNineTilesSettings",
                "AdvancedSimulationSpeed.Setting" => "AdvancedSimulationSpeedSettings",
                "AllAboard.Setting" => "AllAboardSettings",
                "Anarchy.Settings.AnarchyModSettings" => "AnarchySettings",
                "AssetIconLibrary.Setting" => "AssetIconLibrarySettings",
                "AssetPacksManager.Setting" => "AssetPacksManagerSettings",
                "AssetVariationChanger.Setting" => "AssetVariationChangerSettings",
                "AutoDistrictNameStations.ModOptions" => "AutoDistrictNameStationsSettings",
                "AutoVehicleRenamer.AutoVehicleRenamerSetting" => "AutoVehicleRenamerSettings",
                "Better_Bulldozer.Settings.BetterBulldozerModSettings" => "BetterBulldozerSettings",
                "BetterMoonLight.Setting" => "BetterMoonLightSettings",
                "BetterSaveList.Setting" => "BetterSaveListSettings",
                "BoundaryLinesModifier.Setting" => "BoundaryLinesModifierSettings",
                "BrushSizeUnlimiter.MyOptions" => "BrushSizeUnlimiterSettings",
                //"ByeByeHomelessMod.Setting" => "ByeByeHomelessSettings",
                "EmploymentTracker.EmploymentTrackerSettings" => "CimRouteHighlighterSettings",
                "CityStats.ModSettings" => "CityStatsSettings",
                "DemandMaster.Setting" => "DemandMasterSettings",
                "DepotCapacityChanger.Setting" => "DepotCapacityChangerSettings",
                "ExtendedTooltip.ModSettings" => "ExtendedTooltipSettings",
                "ExtraAssetsImporter.Setting" => "ExtraAssetsImporterSettings",
                "FindIt.FindItSettings" => "FindItSettings",
                "FirstPersonCameraContinued.Setting" => "FirstPersonCameraContinuedSettings",
                "FPS_Limiter.FPSLimiterSettings" => "FPSLimiterSettings",
                "HallOfFame.Settings" => "HallOfFameSettings",
                "I18NEverywhere.Setting" => "I18NEverywhereSettings",
                "ImageOverlay.ModSettings" => "ImageOverlaySettings",
                //"Lumina.Setting" => "LuminaSettings",
                "MoveIt.Settings.Settings" => "MoveItSettings",
                "NoPollution.Setting" => "NoPollutionSettings",
                "NoTeleporting.Setting" => "NoTeleportingSettings",
                "NoTrafficDespawn.TrafficDespawnSettings" => "NoVehicleDespawnSettings",
                "PathfindingCustomizer.Setting" => "PathfindingCustomizerSettings",
                "PlopTheGrowables.ModSettings" => "PlopTheGrowablesSettings",
                "RealisticParking.Setting" => "RealisticParkingSettings",
                "Time2Work.Setting" => "RealisticTripsSettings",
                "RealisticWorkplacesAndHouseholds.Setting" => "RealisticWorkplacesAndHouseholdsSettings",
                "RealLife.Setting" => "RealLifeSettings",
                "Recolor.Settings.Setting" => "RecolorSettings",
                "RoadBuilder.Setting" => "RoadBuilderSettings",
                "RoadNameRemover.Setting" => "RoadNameRemoverSettings",
                "SchoolCapacityBalancer.Setting" => "SchoolCapacityBalancerSettings",
                "SimpleModCheckerPlus.Setting" => "SimpleModCheckerSettings",
                "SmartTransportation.Setting" => "SmartTransportationSettings",
                "StationNaming.Setting.StationNamingSettings" => "StationNamingSettings",
                "StifferVehicles.Setting" => "StifferVehiclesSettings",
                "SunGlasses.Setting" => "SunGlassesSettings",
                "ToggleableOverlays.Setting" => "ToggleOverlaysSettings",
                "TradingCostTweaker.Setting" => "TradingCostTweakerSettings",
                "Traffic.ModSettings" => "TrafficSettings",
                "C2VM.TrafficLightsEnhancement.Settings" => "TrafficLightsEnhancementSettings",
                "TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions" => "TrafficSimulationAdjusterSettings",
                "TransitCapacityMultiplier.Setting" => "TransitCapacityMultiplierSettings",
                "TransportPolicyAdjuster.Setting" => "TransportPolicyAdjusterSettings",
                "Tree_Controller.Settings.TreeControllerSettings" => "TreeControllerSettings",
                "TripsData.Setting" => "TripsDataSettings",
                "VehicleVariationPacks.Setting" => "VehicleVariationPacksSettings",
                "Water_Features.Settings.WaterFeaturesSettings" => "WaterFeaturesSettings",
                "WaterVisualTweaksMod.WaterVisualTweaksSettings" => "WaterVisualTweaksSettings",
                "ZoneColorChanger.Setting" => "ZoneColorChangerSettings",
                _ => null
            };
        }

        public void GetSettingsFiles()
        {
            var settingAssets = AssetDatabase.global.GetAssets<SettingAsset>("");
            Mod.log.Info($"Found: {settingAssets.Count()}");
            foreach (var settingAsset in settingAssets)
            {
                if (!settingAsset.name.Contains("Logger"))
                {
                    Mod.log.Info(settingAsset.name);
                    foreach (var fragment in settingAsset)
                    {
                        try
                        {
                            string fragmentSourceType = fragment.source.ToString();
                            Mod.log.Info($"fragment.source = \"{fragmentSourceType}\"");
                            //try
                            //{
                            //    if (fragmentSourceType == "XX")
                            //    {
                            //        try { Mod.log.Info(fragment.source.ToJSONString()); } catch (Exception ex) { Mod.log.Info(ex); }
                            //        try { Mod.log.Info(fragment.source.ToString()); } catch (Exception ex) { Mod.log.Info(ex); }
                            //    }
                            //}
                            //catch (Exception ex)
                            //{ Mod.log.Info(ex); }
                        }
                        catch (Exception ex)
                        {
                            Mod.log.Info(ex);
                        }
                    }
                }
            }
        }
    }
}