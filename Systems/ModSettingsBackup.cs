﻿// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.Reflection;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mod = SimpleModCheckerPlus.Mod;
using Game;
using Game.UI.Localization;
using Game.PSI;
using Game.Modding;
using Colossal.Serialization.Entities;
using Colossal.PSI.Environment;
using Colossal.PSI.Common;
using Colossal.IO.AssetDatabase;
using static Colossal.AssetPipeline.Importers.DidimoImporter.DidimoData;

namespace SimpleModChecker.Systems
{
    public partial class ModSettingsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModNotification SMC = new();
        private readonly List<string> loadedMods = SMC.GetLoadedMods();
        public static ModManager modManager;
        private static Dictionary<string, ModInfo> ModDatabaseInfo;
        private readonly string backupFile0 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_prev.json";
        private readonly string backupFile1 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_1.json";
        private readonly string backupFile2 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_2.json";
        private readonly string backupFile3 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_3.json";
        private readonly string backupFile4 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_4.json";
        private readonly string backupFile5 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_5.json";
        private readonly string backupFile6 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_6.json";
        private readonly string backupFile7 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_7.json";
        private readonly string backupFile8 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_8.json";
        private readonly string backupFile9 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ModSettingsBackup_9.json";

        private bool AutoRestoreDone = false;
 
        protected override void OnCreate()
        {
            base.OnCreate();
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            ModDatabaseInfo = ModDatabase.ModDatabaseInfo;
            base.OnGameLoadingComplete(purpose, mode);
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
                            
                        CreateBackup(0, false);
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
            //var validVersions = new HashSet<string> { "2.2.4", "2.2.5", "2.2.6", "2.2.7" };
            //if (validVersions.Contains(current) && (prev == "2.2.3" || validVersions.Contains(prev)))
            //{
            //    return;
            //}
            Mod.log.Info($"Mod version mismatch. Current: {current}, Backup: {prev}");
            NotificationSystem.Push("starq-smc-mod-settings-update",
                title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeModBackup]"),
                text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeModBackup]"),
                progressState: ProgressState.Warning,
                onClicked: () => { NotificationSystem.Pop("starq-smc-mod-settings-update", delay: 1f); CreateBackup(1); });
        }

        public void CreateBackup(int profile, bool log = true)
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
            Mod.log.Info($"Creating Mod Settings Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            ModSettings ModSettings = new()
            {
                ModVersion = Mod.Version,
                LastUpdated = DateTime.Now.ToLongDateString()
            };
            
            foreach (var entry in ModDatabaseInfo)
            {
                if (entry.Value.Backupable == false)
                {
                    continue;
                }
                try
                {
                    string sectionName = entry.Key;
                    string fragmentSource = entry.Value.FragmentSource;
                    Type classType = entry.Value.ClassType;
                    string assembly = entry.Value.AssemblyName;
                    //Mod.log.Info($"Entry ready for backup: {sectionName}, {fragmentSource}, {classType.Name}, {assembly}");

                    if (fragmentSource == "FiveTwentyNineTiles.ModS ettings") { fragmentSource = "529."; }
                    if (fragmentSource == "AutoDistrictNameStations.ModOptions") { fragmentSource = "AutoDistrict."; }

                    PropertyInfo property = typeof(ModSettings).GetProperty($"{entry.Value.ClassType.Name}");
                    object sectionSettings;// = Activator.CreateInstance(classType);
                    sectionSettings = default;
                    if (!loadedMods.Contains(assembly))
                    {
                        if (log) Mod.log.Info($"{sectionName} is not currently loaded.");
                        if (File.Exists(backupFile))
                        {
                            string jsonStringRead = File.ReadAllText(backupFile);
                            if (!string.IsNullOrEmpty(jsonStringRead))
                            {
                                try
                                {
                                    JObject jsonObject = JObject.Parse(jsonStringRead);
                                    var settingsJson = jsonObject[classType.Name];
                                    if (settingsJson != null && settingsJson.Type != JTokenType.Null)
                                    {
                                        try
                                        {
                                            ConstructorInfo constructor = classType.GetConstructor(Type.EmptyTypes);
                                            if (constructor != null)
                                            {
                                                sectionSettings = constructor.Invoke(null);
                                            }
                                            else
                                            {
                                                Mod.log.Info($"No parameterless constructor found for {classType.Name}");
                                                sectionSettings = null;
                                            }
                                            foreach (PropertyInfo prop in classType.GetProperties())
                                            {
                                                if (settingsJson[prop.Name] != null && settingsJson[prop.Name].Type != JTokenType.Null)
                                                {
                                                    var value = settingsJson[prop.Name].ToObject(prop.PropertyType);
                                                    prop.SetValue(sectionSettings, value);
                                                }
                                                else
                                                {
                                                    prop.SetValue(sectionSettings, null);
                                                }
                                            }
                                            //Mod.log.Info($"Existing {sectionName}Settings found.");
                                            //sectionSettings = jsonObject[entry.Value.ClassType.Name].ToObject(classType);
                                            if (log) Mod.log.Info($"Keeping existing backup for {sectionName}.");
                                        } catch (Exception ex) { Mod.log.Info("Error: " + ex); }
                                    }
                                } catch (Exception ex) { Mod.log.Info("Error: " + ex); }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            sectionSettings = GetSettingsData(sectionName, fragmentSource, sectionSettings, classType, log);
                        } catch (Exception ex ) { Mod.log.Info("ERR: "+ex); }
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
                if (log) Mod.log.Info($"Mod Settings backup created successfully: {backupFile}");
            }
            catch (Exception ex) { Mod.log.Info(ex); }
        }

        public object GetSettingsData(string name, string fragmentSource, object settingsBackup, Type classType, bool log)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            IEnumerable<SettingAsset> settingAssets;
            if (name == "80095")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset => asset.name.Contains("Traffic General Settings"));
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else if(name == "75613")
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset => asset.name.Contains("Mods_Yenyang_Water_Features") || asset.name.Contains("WaterFeatures") || asset.name.Contains("Water_Feature"));
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            else
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset => asset.name.Contains(fragmentSource.Substring(0, fragmentSource.IndexOf("."))) || asset.name.Contains(name));
                settingAssets = AssetDatabase.global.GetAssets(filter);
            }
            //Mod.log.Info($"Getting settings: {name} ({settingAssets.Count()})");
            bool ProcessedFragmentSource = false;
            foreach (SettingAsset settingAsset in settingAssets)
            {
                //try { Mod.log.Info(settingAsset.name); } catch (Exception ex) { Mod.log.Info(ex); }
                //foreach (var fragment in settingAsset)
                //{ try { Mod.log.Info(fragment.name); } catch (Exception ex) { Mod.log.Info(ex); } }
                foreach (var fragment in settingAsset)
                {
                    //try { Mod.log.Info(fragment.name); } catch (Exception ex) { Mod.log.Info(ex); }
                    
                    //try { Mod.log.Info($"{fragment.name} is {fragment.source.GetType().Name}"); } catch (Exception ex) { Mod.log.Info(ex); }
                    if (fragment.source.GetType().Name == "UnityLogger" ) { }
                    else if (fragment.source.ToString().Contains("=====APM Settings=====") && name == "78903")
                    {
                        (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(fragment.source, classType, JsonSerializerSettings);
                    }
                    else
                    {
                        //Mod.log.Info($"{fragment.source}+{name}");
                        bool validity = GetSectionValidity($"{name}+{fragment.source}");
                        //Mod.log.Info($"{fragment.source}+{name} is {validity}");
                        if (validity)
                        {
                            (ProcessedFragmentSource, settingsBackup) = ProcessFragmentSource(fragment.source, classType, JsonSerializerSettings);
                        }else { continue; }
                    }
                }
                if (ProcessedFragmentSource)
                {
                    continue;
                }
            }
            if (ProcessedFragmentSource)
            {
                if (log) Mod.log.Info($"Retrieved valid settings for {name}");
                return settingsBackup;
            } else
            {
                return null;
            }
        }

        private bool GetSectionValidity(string fragmentSourceType)
        {
            //Mod.log.Info($"Choosing {fragmentSourceType}");
            switch (fragmentSourceType)
            {
                // fragment.source => class
                case "74286+FPS_Limiter.FPSLimiterSettings":
                case "74324+MoveIt.Settings.Settings":
                case "74328+FiveTwentyNineTiles.ModSettings":
                case "74539+ImageOverlay.ModSettings":
                case "74604+Anarchy.Settings.AnarchyModSettings":
                case "75190+SchoolCapacityBalancer.Setting":
                case "75249+BrushSizeUnlimiter.MyOptions":
                case "75250+Better_Bulldozer.Settings.BetterBulldozerModSettings":
                case "75426+I18NEverywhere.Setting":
                case "75613+Water_Features.Settings.WaterFeaturesSettings":
                case "75684+DepotCapacityChanger.Setting":
                case "75826+PlopTheGrowables.ModSettings":
                case "75993+Tree_Controller.Settings.TreeControllerSettings":
                case "76662+EmploymentTracker.EmploymentTrackerSettings":
                case "76836+TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions":
                case "76849+SunGlasses.Setting":
                case "76908+AutoDistrictNameStations.ModOptions":
                case "77171+Time2Work.Setting":
                case "77240+FindIt.FindItSettings":
                case "77260+WaterVisualTweaksMod.WaterVisualTweaksSettings":
                case "77463+RoadNameRemover.Setting":
                case "77923+BetterMoonLight.Setting":
                case "78131+StationNaming.Setting.StationNamingSettings":
                case "78188+ExtendedTooltip.ModSettings":
                case "78601+NoPollution.Setting":
                case "78622+TransportPolicyAdjuster.Setting":
                case "78847+AssetVariationChanger.Setting":
                case "78903+AssetPacksManager.Setting":
                case "78960+C2VM.TrafficLightsEnhancement.Settings":
                case "79186+SimpleModCheckerPlus.Setting":
                case "79237+FirstPersonCameraContinued.Setting":
                case "79634+AssetIconLibrary.Setting":
                case "79794+AdvancedSimulationSpeed.Setting":
                case "79872+AutoVehicleRenamer.AutoVehicleRenamerSetting":
                case "79875+TripsData.Setting":
                case "80095+Traffic.ModSettings":
                case "80403+TransitCapacityMultiplier.Setting":
                case "80529+ExtraAssetsImporter.Setting":
                case "80826+Whiteness_Toggle.Setting":
                case "80931+ToggleableOverlays.Setting":
                case "81012+VehicleVariationPacks.Setting":
                case "81157+AreaBucket.Setting":
                case "81407+StifferVehicles.Setting":
                case "81568+ZoneColorChanger.Setting":
                case "82374+BetterSaveList.Setting":
                case "84638+Recolor.Settings.Setting":
                case "85211+NoTrafficDespawn.TrafficDespawnSettings":
                case "85284+CityStats.ModSettings":
                case "86124+TradingCostTweaker.Setting":
                case "86462+PathfindingCustomizer.Setting":
                case "86510+NoTeleporting.Setting":
                case "86605+AllAboard.Setting":
                case "86728+BoundaryLinesModifier.Setting":
                case "86868+RealLife.Setting":
                case "86944+DemandMaster.Setting":
                case "87190+RoadBuilder.Setting":
                case "87313+RealisticParking.Setting":
                case "87755+RealisticWorkplacesAndHouseholds.Setting":
                case "90264+SmartTransportation.Setting":
                case "90641+HallOfFame.Settings":
                    return true;
                default:
                    return false;
            };
        }

        private (bool, object) ProcessFragmentSource(object source, Type classType, JsonSerializerSettings jsonSerializerSettings)
        {
            object settingsBackup = (ISettingsBackup)Activator.CreateInstance(classType);
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

            Mod.log.Info("Restoring Mod Settings Backup");
            string jsonString = File.ReadAllText(backupFile);
            JObject jsonObject = JObject.Parse(jsonString);

            try
            {
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

                    //Mod.log.Info($"{sectionName}__{fragmentSource}");
                    if (fragmentSource == "FiveTwentyNineTiles.ModSettings") { fragmentSource = "529."; }
                    if (fragmentSource == "AutoDistrictNameStations.ModOptions") { fragmentSource = "AutoDistrict."; }

                    if (!loadedMods.Contains(assembly))
                    {
                        if (log) Mod.log.Info($"skipping {sectionName}...");
                    }
                    else
                    {
                        SetSettings(sectionName, fragmentSource, jsonObject, classType.Name, log);
                    }
                }
                Mod.log.Info("Mod Settings Restoration Complete...");
            }
            catch (Exception ex)
            {
                Mod.log.Info($"Mod Settings Restoration Failed: {ex}");
            }
        }

        public void SetSettings(string name, string fragmentSource, JObject sourceObj, string className, bool log)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            try
            {
                var filter = SearchFilter<SettingAsset>.ByCondition(asset => asset.name.Contains(fragmentSource.Substring(0, fragmentSource.IndexOf("."))) || asset.name.Contains(name));
                var settingAssets = AssetDatabase.global.GetAssets(filter);
                //Mod.log.Info($"Setting settings: {name} ({settingAssets.Count()})");
                foreach (SettingAsset settingAsset in settingAssets)
                {
                    foreach (var fragment in settingAsset)
                    {
                        if (fragment.source == null) break;
                        string fragmentSourceType = fragment.source.ToString();
                        string sectionKey = GetSectionKey($"{fragmentSourceType}+{name}");

                        if (sectionKey != null && sectionKey == className)
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
                                    if (log) Mod.log.Info($"{sectionKey} setting saved.");
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
            //Mod.log.Info($"Done {name}");
        }

        private string GetSectionKey(string fragmentSourceType)
        {
            //Mod.log.Info($"Choosing {fragmentSourceType}");
            return fragmentSourceType switch
            {
                // fragment.source => class
                "FiveTwentyNineTiles.ModSettings+529Tile" => "FiveTwentyNineTilesSettings",
                "AdvancedSimulationSpeed.Setting+AdvancedSimulationSpeed" => "AdvancedSimulationSpeedSettings",
                "AllAboard.Setting+AllAboard" => "AllAboardSettings",
                "Anarchy.Settings.AnarchyModSettings+Anarchy" => "AnarchySettings",
                "AreaBucket.Setting+AreaBucket" => "AreaBucketSettings",
                "AssetIconLibrary.Setting+AssetIconLibrary" => "AssetIconLibrarySettings",
                "AssetPacksManager.Setting+AssetPacksManager" => "AssetPacksManagerSettings",
                "AssetVariationChanger.Setting+AssetVariationChanger" => "AssetVariationChangerSettings",
                "AutoDistrictNameStations.ModOptions+AutoDistrictNameStations" => "AutoDistrictNameStationsSettings",
                "AutoVehicleRenamer.AutoVehicleRenamerSetting+AutoVehicleRenamer" => "AutoVehicleRenamerSettings",
                "Better_Bulldozer.Settings.BetterBulldozerModSettings+BetterBulldozer" => "BetterBulldozerSettings",
                "BetterMoonLight.Setting+BetterMoonLight" => "BetterMoonLightSettings",
                "BetterSaveList.Setting+BetterSaveList" => "BetterSaveListSettings",
                "BoundaryLinesModifier.Setting+BoundaryLinesModifier" => "BoundaryLinesModifierSettings",
                "BrushSizeUnlimiter.MyOptions+BrushSizeUnlimiter" => "BrushSizeUnlimiterSettings",
                "EmploymentTracker.EmploymentTrackerSettings+CimRouteHighlighter" => "CimRouteHighlighterSettings",
                "CityStats.ModSettings+CityStats" => "CityStatsSettings",
                "DemandMaster.Setting+DemandMaster" => "DemandMasterSettings",
                "DepotCapacityChanger.Setting+DepotCapacityChanger" => "DepotCapacityChangerSettings",
                "ExtendedTooltip.ModSettings+ExtendedTooltip" => "ExtendedTooltipSettings",
                "ExtraAssetsImporter.Setting+ExtraAssetsImporter" => "ExtraAssetsImporterSettings",
                "FindIt.FindItSettings+FindIt" => "FindItSettings",
                "FirstPersonCameraContinued.Setting+FirstPersonCameraContinued" => "FirstPersonCameraContinuedSettings",
                "FPS_Limiter.FPSLimiterSettings+FPSLimiter" => "FPSLimiterSettings",
                "HallOfFame.Settings+HallOfFame" => "HallOfFameSettings",
                "I18NEverywhere.Setting+I18NEverywhere" => "I18NEverywhereSettings",
                "ImageOverlay.ModSettings+ImageOverlay" => "ImageOverlaySettings",
                "MoveIt.Settings.Settings+MoveIt" => "MoveItSettings",
                "NoPollution.Setting+NoPollution" => "NoPollutionSettings",
                "NoTeleporting.Setting+NoTeleporting" => "NoTeleportingSettings",
                "NoTrafficDespawn.TrafficDespawnSettings+NoVehicleDespawn" => "NoVehicleDespawnSettings",
                "PathfindingCustomizer.Setting+PathfindingCustomizer" => "PathfindingCustomizerSettings",
                "PlopTheGrowables.ModSettings+PlopTheGrowables" => "PlopTheGrowablesSettings",
                "RealisticParking.Setting+RealisticParking" => "RealisticParkingSettings",
                "Time2Work.Setting+RealisticTrips" => "RealisticTripsSettings",
                "RealisticWorkplacesAndHouseholds.Setting+RealisticWorkplacesAndHouseholds" => "RealisticWorkplacesAndHouseholdsSettings",
                "RealLife.Setting+RealLife" => "RealLifeSettings",
                "Recolor.Settings.Setting+Recolor" => "RecolorSettings",
                "RoadBuilder.Setting+RoadBuilder" => "RoadBuilderSettings",
                "RoadNameRemover.Setting+RoadNameRemover" => "RoadNameRemoverSettings",
                "SchoolCapacityBalancer.Setting+SchoolCapacityBalancer" => "SchoolCapacityBalancerSettings",
                "SimpleModCheckerPlus.Setting+SimpleModChecker" => "SimpleModCheckerSettings",
                "SmartTransportation.Setting+SmartTransportation" => "SmartTransportationSettings",
                "StationNaming.Setting.StationNamingSettings+StationNaming" => "StationNamingSettings",
                "StifferVehicles.Setting+StifferVehicles" => "StifferVehiclesSettings",
                "SunGlasses.Setting+SunGlasses" => "SunGlassesSettings",
                "ToggleableOverlays.Setting+ToggleOverlays" => "ToggleOverlaysSettings",
                "TradingCostTweaker.Setting+TradingCostTweaker" => "TradingCostTweakerSettings",
                "Traffic.ModSettings+Traffic" => "TrafficSettings",
                "C2VM.TrafficLightsEnhancement.Settings+TrafficLightsEnhancement" => "TrafficLightsEnhancementSettings",
                "TrafficSimulationAdjuster.TrafficSimulationAdjusterOptions+TrafficSimulationAdjuster" => "TrafficSimulationAdjusterSettings",
                "TransitCapacityMultiplier.Setting+TransitCapacityMultiplier" => "TransitCapacityMultiplierSettings",
                "TransportPolicyAdjuster.Setting+TransportPolicyAdjuster" => "TransportPolicyAdjusterSettings",
                "Tree_Controller.Settings.TreeControllerSettings+TreeController" => "TreeControllerSettings",
                "TripsData.Setting+TripsData" => "TripsDataSettings",
                "VehicleVariationPacks.Setting+VehicleVariationPacks" => "VehicleVariationPacksSettings",
                "Water_Features.Settings.WaterFeaturesSettings+WaterFeatures" => "WaterFeaturesSettings",
                "WaterVisualTweaksMod.WaterVisualTweaksSettings+WaterVisualTweaks" => "WaterVisualTweaksSettings",
                "Whiteness_Toggle.Setting+WhitenessToggle" => "WhitenessToggleSettings",
                "ZoneColorChanger.Setting+ZoneColorChanger" => "ZoneColorChangerSettings",

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