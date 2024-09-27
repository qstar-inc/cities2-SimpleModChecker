// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.IO.AssetDatabase;
using Colossal.PSI.Environment;
using Colossal.Serialization.Entities;
using Game.Modding;
using Game;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SimpleModCheckerPlus;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System;
using Game.PSI;
using Game.UI.Localization;

namespace SimpleModChecker.Systems
{

    public interface ISettingsBackup
    {
        void SetValue(string property, object value);
        object GetValue(string property);
    }

    public class SettingsBackup : ISettingsBackup
    {
        private Dictionary<string, object> settings = [];

        public void SetValue(string property, object value)
        {
            settings[property] = value;
        }

        public object GetValue(string property)
        {
            return settings.ContainsKey(property) ? settings[property] : null;
        }
    }
    //public class KeybindsModifier
    //{
    //    public string Name { get; set; }
    //    public string Path { get; set; }
    //}
    //public class Keybinds
    //{
    //    public string Path { get; set; }
    //    public List<KeybindsModifier> Modifiers { get; set; }
    //}

    public class AnarchySettings : SettingsBackup
    {
        public bool AnarchicBulldozer
        {
            get => (bool)GetValue(nameof(AnarchicBulldozer));
            set => SetValue(nameof(AnarchicBulldozer), value);
        }
        public bool ShowTooltip
        {
            get => (bool)GetValue(nameof(ShowTooltip));
            set => SetValue(nameof(ShowTooltip), value);
        }
        public bool FlamingChirper
        {
            get => (bool)GetValue(nameof(FlamingChirper));
            set => SetValue(nameof(FlamingChirper), value);
        }
        public bool ToolIcon
        {
            get => (bool)GetValue(nameof(ToolIcon));
            set => SetValue(nameof(ToolIcon), value);
        }
        public bool ShowElevationToolOption
        {
            get => (bool)GetValue(nameof(ShowElevationToolOption));
            set => SetValue(nameof(ShowElevationToolOption), value);
        }
        public bool ResetElevationWhenChangingPrefab
        {
            get => (bool)GetValue(nameof(ResetElevationWhenChangingPrefab));
            set => SetValue(nameof(ResetElevationWhenChangingPrefab), value);
        }
        public bool DisableAnarchyWhileBrushing
        {
            get => (bool)GetValue(nameof(DisableAnarchyWhileBrushing));
            set => SetValue(nameof(DisableAnarchyWhileBrushing), value);
        }
        public bool NetworkAnarchyToolOptions
        {
            get => (bool)GetValue(nameof(NetworkAnarchyToolOptions));
            set => SetValue(nameof(NetworkAnarchyToolOptions), value);
        }
        public bool NetworkUpgradesToolOptions
        {
            get => (bool)GetValue(nameof(NetworkUpgradesToolOptions));
            set => SetValue(nameof(NetworkUpgradesToolOptions), value);
        }
        public bool ElevationStepSlider
        {
            get => (bool)GetValue(nameof(ElevationStepSlider));
            set => SetValue(nameof(ElevationStepSlider), value);
        }
        public bool NetworkUpgradesPrefabs
        {
            get => (bool)GetValue(nameof(NetworkUpgradesPrefabs));
            set => SetValue(nameof(NetworkUpgradesPrefabs), value);
        }
        public bool ReplaceUpgradesBehavior
        {
            get => (bool)GetValue(nameof(ReplaceUpgradesBehavior));
            set => SetValue(nameof(ReplaceUpgradesBehavior), value);
        }
        public float MinimumClearanceBelowElevatedNetworks
        {
            get => (float)GetValue(nameof(MinimumClearanceBelowElevatedNetworks));
            set => SetValue(nameof(MinimumClearanceBelowElevatedNetworks), value);
        }
        public bool PreventAccidentalPropCulling
        {
            get => (bool)GetValue(nameof(PreventAccidentalPropCulling));
            set => SetValue(nameof(PreventAccidentalPropCulling), value);
        }
        public int PropRefreshFrequency
        {
            get => (int)GetValue(nameof(PropRefreshFrequency));
            set => SetValue(nameof(PropRefreshFrequency), value);
        }
        //public string ApplyMimic
        //{
        //    get
        //    {
        //        var applyMimicObj = GetValue(nameof(ApplyMimic));
        //        if (applyMimicObj is ProxyBinding applyMimic)
        //        {
        //            return JsonConvert.SerializeObject(applyMimic, new JsonSerializerSettings
        //            {
        //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //            });
        //        }
        //        else
        //        {
        //            throw new InvalidCastException($"The value returned by GetValue is not of type ProxyBinding, it is of type {applyMimicObj?.GetType().Name ?? "null"}.");
        //        }
        //    }
        //    set
        //    {
        //        ProxyBinding applyMimic = JsonConvert.DeserializeObject<ProxyBinding>(value);
        //        SetValue(nameof(ApplyMimic), applyMimic);
        //    }
        //}
        //public ProxyBinding SecondaryApplyMimic
        //{
        //    get => (ProxyBinding)GetValue(nameof(SecondaryApplyMimic));
        //    set => SetValue(nameof(SecondaryApplyMimic), value);
        //}
        public bool AllowPlacingMultipleUniqueBuildings
        {
            get => (bool)GetValue(nameof(AllowPlacingMultipleUniqueBuildings));
            set => SetValue(nameof(AllowPlacingMultipleUniqueBuildings), value);
        }
        public bool PreventOverrideInEditor
        {
            get => (bool)GetValue(nameof(PreventOverrideInEditor));
            set => SetValue(nameof(PreventOverrideInEditor), value);
        }
        //public ProxyBinding ToggleAnarchy
        //{
        //    get => (ProxyBinding)GetValue(nameof(ToggleAnarchy));
        //    set => SetValue(nameof(ToggleAnarchy), value);
        //}
        //public ProxyBinding ResetElevation
        //{
        //    get => (ProxyBinding)GetValue(nameof(ResetElevation));
        //    set => SetValue(nameof(ResetElevation), value);
        //}
        //public ProxyBinding ElevationStep
        //{
        //    get => (ProxyBinding)GetValue(nameof(ElevationStep));
        //    set => SetValue(nameof(ElevationStep), value);
        //}
        //public ProxyBinding IncreaseElevation
        //{
        //    get => (ProxyBinding)GetValue(nameof(IncreaseElevation));
        //    set => SetValue(nameof(IncreaseElevation), value);
        //}
        //public ProxyBinding DecreaseElevation
        //{
        //    get => (ProxyBinding)GetValue(nameof(DecreaseElevation));
        //    set => SetValue(nameof(DecreaseElevation), value);
        //}
        public bool ElevationLock
        {
            get => (bool)GetValue(nameof(ElevationLock));
            set => SetValue(nameof(ElevationLock), value);
        }
    }

    public class AssetIconLibrarySettings : SettingsBackup
    {
        public bool OverwriteIcons
        {
            get => (bool)GetValue(nameof(OverwriteIcons));
            set => SetValue(nameof(OverwriteIcons), value);
        }
    }

    public class FindItSettings : SettingsBackup
    {
        public string DefaultViewStyle
        {
            get => (string)GetValue(nameof(DefaultViewStyle));
            set => SetValue(nameof(DefaultViewStyle), value);
        }
        public bool OpenPanelOnPicker
        {
            get => (bool)GetValue(nameof(OpenPanelOnPicker));
            set => SetValue(nameof(OpenPanelOnPicker), value);
        }
        public bool SelectPrefabOnOpen
        {
            get => (bool)GetValue(nameof(SelectPrefabOnOpen));
            set => SetValue(nameof(SelectPrefabOnOpen), value);
        }
        public bool StrictSearch
        {
            get => (bool)GetValue(nameof(StrictSearch));
            set => SetValue(nameof(StrictSearch), value);
        }
        public bool HideRandomAssets
        {
            get => (bool)GetValue(nameof(HideRandomAssets));
            set => SetValue(nameof(HideRandomAssets), value);
        }
        public bool HideBrandsFromAny
        {
            get => (bool)GetValue(nameof(HideBrandsFromAny));
            set => SetValue(nameof(HideBrandsFromAny), value);
        }
        public bool SmoothScroll
        {
            get => (bool)GetValue(nameof(SmoothScroll));
            set => SetValue(nameof(SmoothScroll), value);
        }
        public float ScrollSpeed
        {
            get => (float)GetValue(nameof(ScrollSpeed));
            set => SetValue(nameof(ScrollSpeed), value);
        }
        public float RowSize
        {
            get => (float)GetValue(nameof(RowSize));
            set => SetValue(nameof(RowSize), value);
        }
        public float ColumnSize
        {
            get => (float)GetValue(nameof(ColumnSize));
            set => SetValue(nameof(ColumnSize), value);
        }
        public float ExpandedRowSize
        {
            get => (float)GetValue(nameof(ExpandedRowSize));
            set => SetValue(nameof(ExpandedRowSize), value);
        }
        public float ExpandedColumnSize
        {
            get => (float)GetValue(nameof(ExpandedColumnSize));
            set => SetValue(nameof(ExpandedColumnSize), value);
        }
    }

    public class FiveTwentyNineTilesSettings : SettingsBackup
    {
        public bool UnlockAll
        {
            get => (bool)GetValue(nameof(UnlockAll));
            set => SetValue(nameof(UnlockAll), value);
        }
        public bool ExtraTilesAtStart
        {
            get => (bool)GetValue(nameof(ExtraTilesAtStart));
            set => SetValue(nameof(ExtraTilesAtStart), value);
        }
        public bool ExtraTilesAtEnd
        {
            get => (bool)GetValue(nameof(ExtraTilesAtEnd));
            set => SetValue(nameof(ExtraTilesAtEnd), value);
        }
        public bool AssignToMilestones
        {
            get => (bool)GetValue(nameof(AssignToMilestones));
            set => SetValue(nameof(AssignToMilestones), value);
        }
        public float UpkeepMultiplier
        {
            get => (float)GetValue(nameof(UpkeepMultiplier));
            set => SetValue(nameof(UpkeepMultiplier), value);
        }
        public bool NoStartingTiles
        {
            get => (bool)GetValue(nameof(NoStartingTiles));
            set => SetValue(nameof(NoStartingTiles), value);
        }
        public bool RelockAllTiles
        {
            get => (bool)GetValue(nameof(RelockAllTiles));
            set => SetValue(nameof(RelockAllTiles), value);
        }
    }

    public class I18NEverywhereSettings : SettingsBackup
    {
        public bool Overwrite
        {
            get => (bool)GetValue(nameof(Overwrite));
            set => SetValue(nameof(Overwrite), value);
        }
        public bool Restrict
        {
            get => (bool)GetValue(nameof(Restrict));
            set => SetValue(nameof(Restrict), value);
        }
        public bool LoadLanguagePacks
        {
            get => (bool)GetValue(nameof(LoadLanguagePacks));
            set => SetValue(nameof(LoadLanguagePacks), value);
        }
        public bool LogKey
        {
            get => (bool)GetValue(nameof(LogKey));
            set => SetValue(nameof(LogKey), value);
        }
        public bool UseNewModDetectMethod
        {
            get => (bool)GetValue(nameof(UseNewModDetectMethod));
            set => SetValue(nameof(UseNewModDetectMethod), value);
        }
    }

    public class PlopTheGrowablesSettings: SettingsBackup
    {
        public bool LockPloppedBuildings
        {
            get => (bool)GetValue(nameof(LockPloppedBuildings));
            set => SetValue(nameof(LockPloppedBuildings), value);
        }
        public bool NoAbandonment
        {
            get => (bool)GetValue(nameof(NoAbandonment));
            set => SetValue(nameof(NoAbandonment), value);
        }
        public bool DisableLevelling
        {
            get => (bool)GetValue(nameof(DisableLevelling));
            set => SetValue(nameof(DisableLevelling), value);
        }

    }

    public class SimpleModCheckerSettings : SettingsBackup
    {
        public bool ShowNotif
        {
            get => (bool)GetValue(nameof(ShowNotif));
            set => SetValue(nameof(ShowNotif), value);
        }
        public bool DeleteMissing
        {
            get => (bool)GetValue(nameof(DeleteMissing));
            set => SetValue(nameof(DeleteMissing), value);
        }
        public bool DeleteCorrupted
        {
            get => (bool)GetValue(nameof(DeleteCorrupted));
            set => SetValue(nameof(DeleteCorrupted), value);
        }
        public bool AutoRestoreSettingBackupOnStartup
        {
            get => (bool)GetValue(nameof(AutoRestoreSettingBackupOnStartup));
            set => SetValue(nameof(AutoRestoreSettingBackupOnStartup), value);
        }

        public string ProfileName0
        {
            get => (string)GetValue(nameof(ProfileName0));
            set => SetValue(nameof(ProfileName0), value);
        }
        public string ProfileName1
        {
            get => (string)GetValue(nameof(ProfileName1));
            set => SetValue(nameof(ProfileName1), value);
        }
        public string ProfileName2
        {
            get => (string)GetValue(nameof(ProfileName2));
            set => SetValue(nameof(ProfileName2), value);
        }
        public string ProfileName3
        {
            get => (string)GetValue(nameof(ProfileName3));
            set => SetValue(nameof(ProfileName3), value);
        }
        public string ProfileName4
        {
            get => (string)GetValue(nameof(ProfileName4));
            set => SetValue(nameof(ProfileName4), value);
        }
        public string ProfileName5
        {
            get => (string)GetValue(nameof(ProfileName5));
            set => SetValue(nameof(ProfileName5), value);
        }
        public string ProfileName6
        {
            get => (string)GetValue(nameof(ProfileName6));
            set => SetValue(nameof(ProfileName6), value);
        }
        public string ProfileName7
        {
            get => (string)GetValue(nameof(ProfileName7));
            set => SetValue(nameof(ProfileName7), value);
        }
        public string ProfileName8
        {
            get => (string)GetValue(nameof(ProfileName8));
            set => SetValue(nameof(ProfileName8), value);
        }
        public string ProfileName9
        {
            get => (string)GetValue(nameof(ProfileName9));
            set => SetValue(nameof(ProfileName9), value);
        }
    }

    public class ModSettings
    {
        public AnarchySettings AnarchySettings { get; set; }
        public AssetIconLibrarySettings AssetIconLibrarySettings { get; set; }
        public FindItSettings FindItSettings { get; set; }
        public FiveTwentyNineTilesSettings FiveTwentyNineTilesSettings { get; set; }
        public I18NEverywhereSettings I18NEverywhereSettings { get; set; }
        public PlopTheGrowablesSettings PlopTheGrowablesSettings { get; set; }
        public SimpleModCheckerSettings SimpleModCheckerSettings { get; set; }
    }

    public class SettingInfo
    {
        public string SettingName { get; set; }
        public string FragmentSource { get; set; }
        public Type ClassType { get; set; }
    }

    public partial class ModSettingsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModManager modManager = Mod.modManager;
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
            { "529Tile", new SettingInfo { SettingName = "529TileSettings", FragmentSource = "FiveTwentyNineTiles.ModSettings", ClassType = typeof(FiveTwentyNineTilesSettings) } },
            { "Anarchy", new SettingInfo { SettingName = "AnarchySettings", FragmentSource = "Anarchy.Settings.AnarchyModSettings", ClassType = typeof(AnarchySettings) } },
            { "AssetIconLibrary", new SettingInfo { SettingName = "AssetIconLibrarySettings", FragmentSource = "AssetIconLibrary.Setting", ClassType = typeof(AssetIconLibrarySettings) } },
            // AssetPacksManager
            // BetterBulldozerMod
            // CitizenChanger
            { "FindIt", new SettingInfo { SettingName = "FindItSettings", FragmentSource = "FindIt.FindItSettings", ClassType = typeof(FindItSettings) } },
            { "I18NEverywhere", new SettingInfo { SettingName = "I18NEverywhereSettings", FragmentSource = "I18NEverywhere.Setting", ClassType = typeof(I18NEverywhereSettings) } },
            // I18NEverywhere
            // ImageOverlaySettings - ImageOverlay.ModSettings
            // [NULL] Line Tool
            // MoveIt
            { "PlopTheGrowables", new SettingInfo {SettingName = "PlopTheGrowablesSettings", FragmentSource = "PlopTheGrowables.ModSettings", ClassType = typeof(PlopTheGrowablesSettings)} },
            // RoadBuilder
            { "SimpleModChecker", new SettingInfo { SettingName = "SimpleModCheckerSettings", FragmentSource = "SimpleModCheckerPlus.Setting", ClassType = typeof(SimpleModCheckerSettings) } }
        };

        protected override void OnCreate()
        {
            base.OnCreate();
        }
        private bool AutoRestoreDone = false;

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            Mod.log.Info("OnGameLoadingComplete");
            if (!AutoRestoreDone && mode == GameMode.MainMenu)
            {

                if (Mod.Setting.AutoRestoreSettingBackupOnStartup)
                {
                    if (File.Exists(backupFile1))
                    {
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

            //ModSettings.AnarchySettings = BackupSection<AnarchySettings>("Anarchy", backupFile, "AnarchySettings");
            //ModSettings.AssetIconLibrarySettings = BackupSection<AssetIconLibrarySettings>("AssetIconLibrary", backupFile, "AssetIconLibrarySettings");
            //ModSettings.FindItSettings = BackupSection<FindItSettings>("FindIt", backupFile, "FindItSettings");
            //ModSettings.FiveTwentyNineTilesSettings = BackupSection<FiveTwentyNineTilesSettings>("529TileSettings", backupFile, "FiveTwentyNineTilesSettings");
            //ModSettings.PlopTheGrowablesSettings = BackupSection<PlopTheGrowablesSettings>("PlopTheGrowables", backupFile, "PlopTheGrowablesSettings");
            //ModSettings.SimpleModCheckerSettings = BackupSection<SimpleModCheckerSettings>("SimpleModChecker", backupFile, "SimpleModCheckerSettings");

            foreach (var entry in settingsDictionary)
            {
                string sectionName = entry.Key;
                Type classType = entry.Value.ClassType;


                MethodInfo backupSectionMethod = typeof(ModSettingsBackup).GetMethod("BackupSection", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo genericBackupSectionMethod = backupSectionMethod.MakeGenericMethod(classType);
                object sectionSettings;
                if (profile == 0)
                {
                    sectionSettings = genericBackupSectionMethod.Invoke(this, [sectionName, backupFile1, entry.Value.ClassType.Name]);
                }
                else
                {
                    sectionSettings = genericBackupSectionMethod.Invoke(this, [sectionName, backupFile, entry.Value.ClassType.Name]);
                }
                
                //Mod.log.Info($"{classType.Name}");
                try
                {
                    PropertyInfo property = typeof(ModSettings).GetProperty($"{entry.Value.ClassType.Name}");
                    property?.SetValue(ModSettings, sectionSettings);
                }
                catch (Exception ex)
                {
                    Mod.log.Info($"Error setting property; {ex}");
                }
            }
            //foreach (var setting in settingsDictionary)
            //{
            //    var sectionSettings = BackupSection(setting.Value.ClassType, setting.Key, backupFile, setting.Value.SettingName);
            //    ModSettings.GetType().GetProperty(setting.Value.SettingName)?.SetValue(ModSettings, sectionSettings);
            //}

            string jsonString = JsonConvert.SerializeObject(ModSettings, Formatting.Indented);
            File.WriteAllText(backupFile, jsonString);

        }

        private protected T BackupSection<T>(string sectionName, string backupFile, string jsonPropertyName) where T : ISettingsBackup, new()
        {
            T sectionSettings = new();
            bool sectionFound = GetSettings(sectionName, sectionSettings);

            if (!sectionFound)
            {
                Mod.log.Info($"{sectionName}Settings not found, looking for existing settings.");
                try
                {
                    string jsonStringRead = File.ReadAllText(backupFile);

                    JObject jsonObject = JObject.Parse(jsonStringRead);
                    if (jsonObject[jsonPropertyName] != null)
                    {
                        Mod.log.Debug($"Existing {sectionName}Settings found.");
                        sectionSettings = jsonObject[jsonPropertyName].ToObject<T>();
                    }
                    else
                    {
                        Mod.log.Debug($"Existing {sectionName}Settings not found, setting it to null.");
                        sectionSettings = default;
                    }
                }
                catch (Exception ex)
                {
                    Mod.log.Info($"[ERROR]: {ex}");
                    sectionSettings = default;
                }
            }
            else
            {
                Mod.log.Debug($"Found {sectionName}");
            }

            return sectionSettings;
        }

        public bool GetSettings(string name, ISettingsBackup settingsBackup)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            try
            {
                var settingAssets = AssetDatabase.global.GetAssets<SettingAsset>(name);
                Mod.log.Info($"Getting settings: {name} ({settingAssets.Count()})");
                foreach (SettingAsset settingAsset in settingAssets)
                {
                    foreach (var fragment in settingAsset)
                    {
                        string fragmentSource = fragment.source.ToString();
                        //Mod.log.Info($"fragment.source = \"{fragmentSource}\""); // <--------------------------- REMOVE THIS BEFORE PUBLISHING
                        switch (fragmentSource)
                        {
                            case "Anarchy.Settings.AnarchyModSettings":
                            case "AssetIconLibrary.Setting":
                            case "FindIt.FindItSettings":
                            case "FiveTwentyNineTiles.ModSettings":
                            case "I18NEverywhere.Setting":
                            case "PlopTheGrowables.ModSettings":
                            case "SimpleModCheckerPlus.Setting":
                                ProcessFragmentSource(fragment.source, settingsBackup, JsonSerializerSettings);
                                break;
                        }
                }
                }
                return true;
            }
            catch (Exception ex)
            {
                Mod.log.Info($"{name} not found. Skipping backup...");
                return false;
            }
        }

        private void ProcessFragmentSource(object source, ISettingsBackup settingsBackup, JsonSerializerSettings jsonSerializerSettings)
        {
            //Mod.log.Info($"ProcessingFragmentSource");
            JObject sourceObj = JObject.FromObject(source, JsonSerializer.Create(jsonSerializerSettings));
            foreach (var property in sourceObj.Properties())
            {
                //Mod.log.Info(property.Name);
                settingsBackup.SetValue(property.Name, property.Value.ToObject<object>());
            }
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

            // RestoreSection<AnarchySettings>("Anarchy", "AnarchySettings", jsonObject);
            // RestoreSection<AssetIconLibrarySettings>("AssetIconLibrary", "AssetIconLibrarySettings", jsonObject);
            // RestoreSection<FindItSettings>("FindIt", "FindItSettings", jsonObject);
            // RestoreSection<FiveTwentyNineTilesSettings>("529TileSettings", "FiveTwentyNineTilesSettings", jsonObject);
            // RestoreSection<PlopTheGrowablesSettings>("PlopTheGrowables", "PlopTheGrowablesSettings", jsonObject);
            // RestoreSection<SimpleModCheckerSettings>("SimpleModChecker", "SimpleModCheckerSettings", jsonObject);

            foreach (var entry in settingsDictionary)
            {
                string sectionName = entry.Key;
                Type classType = entry.Value.ClassType;

                // Use reflection to invoke RestoreSection with the correct type argument
                MethodInfo restoreSectionMethod = typeof(ModSettingsBackup).GetMethod("RestoreSection", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo genericRestoreSectionMethod = restoreSectionMethod.MakeGenericMethod(classType);

                genericRestoreSectionMethod.Invoke(this, [sectionName, entry.Value.ClassType.Name, jsonObject]);
            }

            //foreach (var setting in settingsDictionary)
            //{
            //    RestoreSection(setting.Value.ClassType, setting.Value.SettingName, jsonObject);
            //}
        }

        private protected void RestoreSection<T>(string sectionName, string jsonPropertyName, JObject jsonObject) where T : class
        {
            T sectionSettings = jsonObject[jsonPropertyName]?.ToObject<T>();

            if (sectionSettings != null)
            {
                Mod.log.Debug($"Restoring {sectionName}");
                //Mod.log.Info(jsonObject);
                this.SetSettings(sectionName, jsonObject);
    }
            else
            {
                Mod.log.Info($"{sectionName}Settings not found");
            }
        }

        public void SetSettings(string name, JObject sourceObj)
        {
            JsonSerializerSettings JsonSerializerSettings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            try
            {
                var settingAssets = AssetDatabase.global.GetAssets<SettingAsset>(name);
                Mod.log.Debug($"Setting settings: {name} ({settingAssets.Count()})");
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
                                settingAsset.Save();
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
                Mod.log.Info($"{name} not found. Skipping restore...");
            }
        }

        private string GetSectionKey(string fragmentSourceType)
        {
            Mod.log.Debug($"Choosing {fragmentSourceType}");
            return fragmentSourceType switch
            {
                // fragment.source => class
                "Anarchy.Settings.AnarchyModSettings" => "AnarchySettings",
                "AssetIconLibrary.Setting" => "AssetIconLibrarySettings",
                "FindIt.FindItSettings" => "FindItSettings",
                "FiveTwentyNineTiles.ModSettings" => "FiveTwentyNineTilesSettings",
                "I18NEverywhere.Setting" => "I18NEverywhereSettings",
                "PlopTheGrowables.ModSettings" => "PlopTheGrowablesSettings",
                "SimpleModCheckerPlus.Setting" => "SimpleModCheckerSettings",
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

// {"asset":"00000000000000000000000000000000","guid":"b5bdf528ccf509b0bd002e41c14820c1","variant":{"DefaultBlock":false},"source":{"id":"AssetIconLibrary.AssetIconLibrary.Mod","name":"Setting","keyBindingRegistered":false,"DefaultBlock":false,"OverwriteIcons":true},"default":{"id":"AssetIconLibrary.AssetIconLibrary.Mod","name":"Setting","keyBindingRegistered":false,"DefaultBlock":true,"OverwriteIcons":true},"name":"AssetIconLibrary","meta":{"mimeType":".coc","displayName":"AssetIconLibrary","fileName":"AssetIconLibrary","path":"C:/Users/Qoushik/AppData/LocalLow/Colossal Order/Cities Skylines II/AssetIconLibrary.coc","subPath":null,"size":49,"uri":"user://AssetIconLibrary.coc","creationTime":"09/16/2024 10:57:01","lastAccessTime":"09/25/2024 20:55:41","lastWriteTime":"09/25/2024 20:54:44","persistent":true,"belongsToCurrentUser":false,"packageName":null,"package":"00000000000000000000000000000000","remoteStorageSourceName":"Local","isPackaged":false}}

// TODO:
// WATER VISUAL TWEAKS
// TREE CONTROLLER
// TRANSIT CAPACITY MULTIPLIER
// DEPOT CAPACITY CHANGER
// SCHOOL CAPACITY BALANCER
// TRAFFIC SIMULATION ADJUSTER
// ROAD NAME REMOVER
// BOUNDARY LINES MODIFIER
// DEMAND MASTER PRO
// REALISTIC TRIPS
// REAL TIME
// REALISTIC PARKING
// REALISTIC WORKPLACES & HOUSEHOLDS
// EXTENDED TOOLTIP
// VEHICLE VARIATION PACKS

// DONE:
//529 Tiles
//Anarchy
//Asset Icon Library
//Find It
//I18n Everywhere
//Plop The Growables
//Simple Mod Checker Plus