using System.Collections.Generic;
using Game.Input;
using Game.Settings;
using static UnityEngine.Rendering.DebugUI;

namespace SimpleModCheckerPlus.Systems
{
    public interface ISettingsBackup
    {
        void SetValue(string property, object value);
        object GetValue(string property);
    }

    public class SettingsBackup : ISettingsBackup
    {
        private readonly Dictionary<string, object> SettingsItems = new();

        public void SetValue(string property, object value)
        {
            SettingsItems[property] = value;
        }

        public object GetValue(string property)
        {
            return SettingsItems.ContainsKey(property) ? SettingsItems[property] : null;
        }
    }

    public class AdvancedRoadToolsSettings : SettingsBackup
    {
        public bool RemoveZonedCells
        {
            get => (bool)GetValue(nameof(RemoveZonedCells));
            set => SetValue(nameof(RemoveZonedCells), value);
        }
        public bool RemoveOccupiedCells
        {
            get => (bool)GetValue(nameof(RemoveOccupiedCells));
            set => SetValue(nameof(RemoveOccupiedCells), value);
        }
    }

    public class AdvancedSimulationSpeedSettings : SettingsBackup
    {
        public int ModeSelection
        {
            get => (int)GetValue(nameof(ModeSelection));
            set => SetValue(nameof(ModeSelection), value);
        }
        public float StepValue
        {
            get => (float)GetValue(nameof(StepValue));
            set => SetValue(nameof(StepValue), value);
        }
        public bool DisplayActualSpeed
        {
            get => (bool)GetValue(nameof(DisplayActualSpeed));
            set => SetValue(nameof(DisplayActualSpeed), value);
        }
    }

    public class AirplaneParameterModSettings : SettingsBackup
    {
        public float MinSpeed
        {
            get => (float)GetValue(nameof(MinSpeed));
            set => SetValue(nameof(MinSpeed), value);
        }
        public float MaxSpeed
        {
            get => (float)GetValue(nameof(MaxSpeed));
            set => SetValue(nameof(MaxSpeed), value);
        }
        public float AccelerationModifier
        {
            get => (float)GetValue(nameof(AccelerationModifier));
            set => SetValue(nameof(AccelerationModifier), value);
        }
        public float BrakingModifier
        {
            get => (float)GetValue(nameof(BrakingModifier));
            set => SetValue(nameof(BrakingModifier), value);
        }
        public float TurningModifier
        {
            get => (float)GetValue(nameof(TurningModifier));
            set => SetValue(nameof(TurningModifier), value);
        }
        public float AngularAccelerationModifier
        {
            get => (float)GetValue(nameof(AngularAccelerationModifier));
            set => SetValue(nameof(AngularAccelerationModifier), value);
        }
        public float ClimbAngleModifier
        {
            get => (float)GetValue(nameof(ClimbAngleModifier));
            set => SetValue(nameof(ClimbAngleModifier), value);
        }
        public float SlowPitchAngleModifier
        {
            get => (float)GetValue(nameof(SlowPitchAngleModifier));
            set => SetValue(nameof(SlowPitchAngleModifier), value);
        }
        public float TurningRollFactorModifier
        {
            get => (float)GetValue(nameof(TurningRollFactorModifier));
            set => SetValue(nameof(TurningRollFactorModifier), value);
        }
    }

    public class AllAboardSettings : SettingsBackup
    {
        public int TrainMaxDwellDelaySlider
        {
            get => (int)GetValue(nameof(TrainMaxDwellDelaySlider));
            set => SetValue(nameof(TrainMaxDwellDelaySlider), value);
        }
        public int BusMaxDwellDelaySlider
        {
            get => (int)GetValue(nameof(BusMaxDwellDelaySlider));
            set => SetValue(nameof(BusMaxDwellDelaySlider), value);
        }
    }

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
        public bool ResetNetworkToolOptionsWhenChangingPrefab
        {
            get => (bool)GetValue(nameof(ResetNetworkToolOptionsWhenChangingPrefab));
            set => SetValue(nameof(ResetNetworkToolOptionsWhenChangingPrefab), value);
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
        public bool UseElevationMimics
        {
            get => (bool)GetValue(nameof(UseElevationMimics));
            set => SetValue(nameof(UseElevationMimics), value);
        }
    }

    public class AreaBucketSettings : SettingsBackup
    {
        public float MinGeneratedLineLength
        {
            get => (float)GetValue(nameof(MinGeneratedLineLength));
            set => SetValue(nameof(MinGeneratedLineLength), value);
        }
        public bool UseExperientalOption
        {
            get => (bool)GetValue(nameof(UseExperientalOption));
            set => SetValue(nameof(UseExperientalOption), value);
        }
        public bool DrawAreaOverlay
        {
            get => (bool)GetValue(nameof(DrawAreaOverlay));
            set => SetValue(nameof(DrawAreaOverlay), value);
        }
        public bool PreviewSurface
        {
            get => (bool)GetValue(nameof(PreviewSurface));
            set => SetValue(nameof(PreviewSurface), value);
        }
        public bool AlterVanillaGeometrySystem
        {
            get => (bool)GetValue(nameof(AlterVanillaGeometrySystem));
            set => SetValue(nameof(AlterVanillaGeometrySystem), value);
        }
        public bool ShowDebugOption
        {
            get => (bool)GetValue(nameof(ShowDebugOption));
            set => SetValue(nameof(ShowDebugOption), value);
        }
        public float MaxFillingRange
        {
            get => (float)GetValue(nameof(MaxFillingRange));
            set => SetValue(nameof(MaxFillingRange), value);
        }
    }

    public class AssetIconCreatorSettings : SettingsBackup
    {
        public bool ClearMap
        {
            get => (bool)GetValue(nameof(ClearMap));
            set => SetValue(nameof(ClearMap), value);
        }
        public int OutputSize
        {
            get => (int)GetValue(nameof(OutputSize));
            set => SetValue(nameof(OutputSize), value);
        }
        public bool CompressOutput
        {
            get => (bool)GetValue(nameof(CompressOutput));
            set => SetValue(nameof(CompressOutput), value);
        }
        public bool SaveThumbnailsPermanently
        {
            get => (bool)GetValue(nameof(SaveThumbnailsPermanently));
            set => SetValue(nameof(SaveThumbnailsPermanently), value);
        }
        public bool AutoSetIcon
        {
            get => (bool)GetValue(nameof(AutoSetIcon));
            set => SetValue(nameof(AutoSetIcon), value);
        }
        public string ThumbnailsFolder
        {
            get => (string)GetValue(nameof(ThumbnailsFolder));
            set => SetValue(nameof(ThumbnailsFolder), value);
        }
    }

    public class AssetIconLibrarySettings : SettingsBackup
    {
        public string IconsStyle
        {
            get => (string)GetValue(nameof(IconsStyle));
            set => SetValue(nameof(IconsStyle), value);
        }
        public bool OverwriteIcons
        {
            get => (bool)GetValue(nameof(OverwriteIcons));
            set => SetValue(nameof(OverwriteIcons), value);
        }
    }

    public class AssetPacksManagerSettings : SettingsBackup
    {
        //public bool EnableLocalAssetPacks
        //{
        //    get => (bool)GetValue(nameof(EnableLocalAssetPacks));
        //    set => SetValue(nameof(EnableLocalAssetPacks), value);
        //}
        //public bool EnableSubscribedAssetPacks
        //{
        //    get => (bool)GetValue(nameof(EnableSubscribedAssetPacks));
        //    set => SetValue(nameof(EnableSubscribedAssetPacks), value);
        //}
        //public bool EnableAssetPackLoadingOnStartup
        //{
        //    get => (bool)GetValue(nameof(EnableAssetPackLoadingOnStartup));
        //    set => SetValue(nameof(EnableAssetPackLoadingOnStartup), value);
        //}
        //public bool AdaptiveAssetLoading
        //{
        //    get => (bool)GetValue(nameof(AdaptiveAssetLoading));
        //    set => SetValue(nameof(AdaptiveAssetLoading), value);
        //}
        //public bool DisableSettingsWarning
        //{
        //    get => (bool)GetValue(nameof(DisableSettingsWarning));
        //    set => SetValue(nameof(DisableSettingsWarning), value);
        //}
        //public bool DisableTelemetry
        //{
        //    get => (bool)GetValue(nameof(DisableTelemetry));
        //    set => SetValue(nameof(DisableTelemetry), value);
        //}
        public bool AutoHideNotifications
        {
            get => (bool)GetValue(nameof(AutoHideNotifications));
            set => SetValue(nameof(AutoHideNotifications), value);
        }
        public bool DisableLoadingNotification
        {
            get => (bool)GetValue(nameof(DisableLoadingNotification));
            set => SetValue(nameof(DisableLoadingNotification), value);
        }
        public bool ShowWarningForLocalAssets
        {
            get => (bool)GetValue(nameof(ShowWarningForLocalAssets));
            set => SetValue(nameof(ShowWarningForLocalAssets), value);
        }
    }

    public class AssetUIManagerSettings : SettingsBackup
    {
        public bool PathwayInRoads
        {
            get => (bool)GetValue(nameof(PathwayInRoads));
            set => SetValue(nameof(PathwayInRoads), value);
        }
        public bool PedestrianInPathway
        {
            get => (bool)GetValue(nameof(PedestrianInPathway));
            set => SetValue(nameof(PedestrianInPathway), value);
        }
        public int PathwayPriorityDropdown
        {
            get => (int)GetValue(nameof(PathwayPriorityDropdown));
            set => SetValue(nameof(PathwayPriorityDropdown), value);
        }
        public bool BridgesInRoads
        {
            get => (bool)GetValue(nameof(BridgesInRoads));
            set => SetValue(nameof(BridgesInRoads), value);
        }
        public bool ParkingRoadsInRoads
        {
            get => (bool)GetValue(nameof(ParkingRoadsInRoads));
            set => SetValue(nameof(ParkingRoadsInRoads), value);
        }
        public bool SeparatedSchools
        {
            get => (bool)GetValue(nameof(SeparatedSchools));
            set => SetValue(nameof(SeparatedSchools), value);
        }
        public bool SeparatedPocketParks
        {
            get => (bool)GetValue(nameof(SeparatedPocketParks));
            set => SetValue(nameof(SeparatedPocketParks), value);
        }
        public bool SeparatedCityParks
        {
            get => (bool)GetValue(nameof(SeparatedCityParks));
            set => SetValue(nameof(SeparatedCityParks), value);
        }
        public bool EnableAssetPacks
        {
            get => (bool)GetValue(nameof(EnableAssetPacks));
            set => SetValue(nameof(EnableAssetPacks), value);
        }
        public bool VerboseLogging
        {
            get => (bool)GetValue(nameof(VerboseLogging));
            set => SetValue(nameof(VerboseLogging), value);
        }
    }

    public class AssetVariationChangerSettings : SettingsBackup
    {
        public bool EnableVariationChooser
        {
            get => (bool)GetValue(nameof(EnableVariationChooser));
            set => SetValue(nameof(EnableVariationChooser), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class AutoDistrictNameStationsSettings : SettingsBackup
    {
        public string stationFormat
        {
            get => (string)GetValue(nameof(stationFormat));
            set => SetValue(nameof(stationFormat), value);
        }
        public bool allowUnique
        {
            get => (bool)GetValue(nameof(allowUnique));
            set => SetValue(nameof(allowUnique), value);
        }
        public bool allowStreetnaming
        {
            get => (bool)GetValue(nameof(allowStreetnaming));
            set => SetValue(nameof(allowStreetnaming), value);
        }
        public bool changeStations
        {
            get => (bool)GetValue(nameof(changeStations));
            set => SetValue(nameof(changeStations), value);
        }
        public int stationsApplyTo
        {
            get => (int)GetValue(nameof(stationsApplyTo));
            set => SetValue(nameof(stationsApplyTo), value);
        }
        public bool changeDeathsCare
        {
            get => (bool)GetValue(nameof(changeDeathsCare));
            set => SetValue(nameof(changeDeathsCare), value);
        }
        public int deathsCareApplyTo
        {
            get => (int)GetValue(nameof(deathsCareApplyTo));
            set => SetValue(nameof(deathsCareApplyTo), value);
        }
        public bool changeHospital
        {
            get => (bool)GetValue(nameof(changeHospital));
            set => SetValue(nameof(changeHospital), value);
        }
        public int hospitalApplyTo
        {
            get => (int)GetValue(nameof(hospitalApplyTo));
            set => SetValue(nameof(hospitalApplyTo), value);
        }
        public bool changePark
        {
            get => (bool)GetValue(nameof(changePark));
            set => SetValue(nameof(changePark), value);
        }
        public int parkApplyTo
        {
            get => (int)GetValue(nameof(parkApplyTo));
            set => SetValue(nameof(parkApplyTo), value);
        }
        public bool changePolice
        {
            get => (bool)GetValue(nameof(changePolice));
            set => SetValue(nameof(changePolice), value);
        }
        public int policeApplyTo
        {
            get => (int)GetValue(nameof(policeApplyTo));
            set => SetValue(nameof(policeApplyTo), value);
        }
        public bool changeSchool
        {
            get => (bool)GetValue(nameof(changeSchool));
            set => SetValue(nameof(changeSchool), value);
        }
        public int schoolApplyTo
        {
            get => (int)GetValue(nameof(schoolApplyTo));
            set => SetValue(nameof(schoolApplyTo), value);
        }
        public bool changeShelter
        {
            get => (bool)GetValue(nameof(changeShelter));
            set => SetValue(nameof(changeShelter), value);
        }
        public int shelterApplyTo
        {
            get => (int)GetValue(nameof(shelterApplyTo));
            set => SetValue(nameof(shelterApplyTo), value);
        }
        public bool changeFirestation
        {
            get => (bool)GetValue(nameof(changeFirestation));
            set => SetValue(nameof(changeFirestation), value);
        }
        public int firestationApplayTo
        {
            get => (int)GetValue(nameof(firestationApplayTo));
            set => SetValue(nameof(firestationApplayTo), value);
        }
        public bool changeGarbage
        {
            get => (bool)GetValue(nameof(changeGarbage));
            set => SetValue(nameof(changeGarbage), value);
        }
        public int garbageApplyTo
        {
            get => (int)GetValue(nameof(garbageApplyTo));
            set => SetValue(nameof(garbageApplyTo), value);
        }
        public bool changePost
        {
            get => (bool)GetValue(nameof(changePost));
            set => SetValue(nameof(changePost), value);
        }
        public int postApplyTo
        {
            get => (int)GetValue(nameof(postApplyTo));
            set => SetValue(nameof(postApplyTo), value);
        }
        public bool changeParking
        {
            get => (bool)GetValue(nameof(changeParking));
            set => SetValue(nameof(changeParking), value);
        }
        public int parkingApplyTo
        {
            get => (int)GetValue(nameof(parkingApplyTo));
            set => SetValue(nameof(parkingApplyTo), value);
        }
    }

    public class AutoVehicleRenamerSettings : SettingsBackup
    {
        public bool EnableDefault
        {
            get => (bool)GetValue(nameof(EnableDefault));
            set => SetValue(nameof(EnableDefault), value);
        }
        public string Separator
        {
            get => (string)GetValue(nameof(Separator));
            set => SetValue(nameof(Separator), value);
        }
        public int TextFormat
        {
            get => (int)GetValue(nameof(TextFormat));
            set => SetValue(nameof(TextFormat), value);
        }
        public bool EnableVerbose
        {
            get => (bool)GetValue(nameof(EnableVerbose));
            set => SetValue(nameof(EnableVerbose), value);
        }
    }

    public class BetterBulldozerSettings : SettingsBackup
    {
        public bool AllowRemovingSubElementNetworks
        {
            get => (bool)GetValue(nameof(AllowRemovingSubElementNetworks));
            set => SetValue(nameof(AllowRemovingSubElementNetworks), value);
        }
        public bool AllowRemovingExtensions
        {
            get => (bool)GetValue(nameof(AllowRemovingExtensions));
            set => SetValue(nameof(AllowRemovingExtensions), value);
        }
        public bool AutomaticRemovalManicuredGrass
        {
            get => (bool)GetValue(nameof(AutomaticRemovalManicuredGrass));
            set => SetValue(nameof(AutomaticRemovalManicuredGrass), value);
        }
        public bool AutomaticRemovalFencesAndHedges
        {
            get => (bool)GetValue(nameof(AutomaticRemovalFencesAndHedges));
            set => SetValue(nameof(AutomaticRemovalFencesAndHedges), value);
        }
        public bool AutomaticRemovalBrandingObjects
        {
            get => (bool)GetValue(nameof(AutomaticRemovalBrandingObjects));
            set => SetValue(nameof(AutomaticRemovalBrandingObjects), value);
        }
    }

    public class BetterMoonLightSettings : SettingsBackup
    {
        public bool OverwriteNightLighting
        {
            get => (bool)GetValue(nameof(OverwriteNightLighting));
            set => SetValue(nameof(OverwriteNightLighting), value);
        }
        public float AmbientLight
        {
            get => (float)GetValue(nameof(AmbientLight));
            set => SetValue(nameof(AmbientLight), value);
        }
        public float NightSkyLight
        {
            get => (float)GetValue(nameof(NightSkyLight));
            set => SetValue(nameof(NightSkyLight), value);
        }
        public float MoonDirectionalLight
        {
            get => (float)GetValue(nameof(MoonDirectionalLight));
            set => SetValue(nameof(MoonDirectionalLight), value);
        }
        public float MoonDiskSize
        {
            get => (float)GetValue(nameof(MoonDiskSize));
            set => SetValue(nameof(MoonDiskSize), value);
        }
        public float MoonDiskIntensity
        {
            get => (float)GetValue(nameof(MoonDiskIntensity));
            set => SetValue(nameof(MoonDiskIntensity), value);
        }
        public float NightLightTemperature
        {
            get => (float)GetValue(nameof(NightLightTemperature));
            set => SetValue(nameof(NightLightTemperature), value);
        }
        public float MoonTemperature
        {
            get => (float)GetValue(nameof(MoonTemperature));
            set => SetValue(nameof(MoonTemperature), value);
        }
        public float StarfieldEmmisionStrength
        {
            get => (float)GetValue(nameof(StarfieldEmmisionStrength));
            set => SetValue(nameof(StarfieldEmmisionStrength), value);
        }
        public int AuroraOverwriteLevel
        {
            get => (int)GetValue(nameof(AuroraOverwriteLevel));
            set => SetValue(nameof(AuroraOverwriteLevel), value);
        }
        public float AuroraIntensity
        {
            get => (float)GetValue(nameof(AuroraIntensity));
            set => SetValue(nameof(AuroraIntensity), value);
        }
        public bool ShowOptionsInDeveloperPanel
        {
            get => (bool)GetValue(nameof(ShowOptionsInDeveloperPanel));
            set => SetValue(nameof(ShowOptionsInDeveloperPanel), value);
        }
    }

    public class BetterSaveListSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public string SelectedCityName
        {
            get => (string)GetValue(nameof(SelectedCityName));
            set => SetValue(nameof(SelectedCityName), value);
        }
        public string SelectedSaveID
        {
            get => (string)GetValue(nameof(SelectedSaveID));
            set => SetValue(nameof(SelectedSaveID), value);
        }
        public int CityListOrdering
        {
            get => (int)GetValue(nameof(CityListOrdering));
            set => SetValue(nameof(CityListOrdering), value);
        }
        public bool IsCityListOrderingDesc
        {
            get => (bool)GetValue(nameof(IsCityListOrderingDesc));
            set => SetValue(nameof(IsCityListOrderingDesc), value);
        }
        public int SaveListOrdering
        {
            get => (int)GetValue(nameof(SaveListOrdering));
            set => SetValue(nameof(SaveListOrdering), value);
        }
        public bool IsSaveListOrderingDesc
        {
            get => (bool)GetValue(nameof(IsSaveListOrderingDesc));
            set => SetValue(nameof(IsSaveListOrderingDesc), value);
        }
    }

    public class BoundaryLinesModifierSettings : SettingsBackup
    {
        public float Width
        {
            get => (float)GetValue(nameof(Width));
            set => SetValue(nameof(Width), value);
        }
        public float Length
        {
            get => (float)GetValue(nameof(Length));
            set => SetValue(nameof(Length), value);
        }
        public string CityBorderColor
        {
            get => (string)GetValue(nameof(CityBorderColor));
            set => SetValue(nameof(CityBorderColor), value);
        }
        public string MapBorderColor
        {
            get => (string)GetValue(nameof(MapBorderColor));
            set => SetValue(nameof(MapBorderColor), value);
        }
    }

    public class BrushSizeUnlimiterSettings : SettingsBackup
    {
        public float MaxBrushSize
        {
            get => (float)GetValue(nameof(MaxBrushSize));
            set => SetValue(nameof(MaxBrushSize), value);
        }
        public bool BrushPreviewMod
        {
            get => (bool)GetValue(nameof(BrushPreviewMod));
            set => SetValue(nameof(BrushPreviewMod), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class BuildingUsageTrackerSettings : SettingsBackup
    {
        public bool showEnrouteCimCounts
        {
            get => (bool)GetValue(nameof(showEnrouteCimCounts));
            set => SetValue(nameof(showEnrouteCimCounts), value);
        }
        public bool showEnrouteVehicleCounts
        {
            get => (bool)GetValue(nameof(showEnrouteVehicleCounts));
            set => SetValue(nameof(showEnrouteVehicleCounts), value);
        }
        public bool showBuildingOccupancy
        {
            get => (bool)GetValue(nameof(showBuildingOccupancy));
            set => SetValue(nameof(showBuildingOccupancy), value);
        }
    }

    public class BuildingUseSettings : SettingsBackup
    {
        public int ZonedBuildingColor
        {
            get => (int)GetValue(nameof(ZonedBuildingColor));
            set => SetValue(nameof(ZonedBuildingColor), value);
        }
        public int ServiceBuildingColor
        {
            get => (int)GetValue(nameof(ServiceBuildingColor));
            set => SetValue(nameof(ServiceBuildingColor), value);
        }
        public bool ColorSpecializedIndustryLots
        {
            get => (bool)GetValue(nameof(ColorSpecializedIndustryLots));
            set => SetValue(nameof(ColorSpecializedIndustryLots), value);
        }
        public bool ReverseColors
        {
            get => (bool)GetValue(nameof(ReverseColors));
            set => SetValue(nameof(ReverseColors), value);
        }
    }

    public class CameraDragSettings : SettingsBackup
    {
        public int AllowLeftMouseButton
        {
            get => (int)GetValue(nameof(AllowLeftMouseButton));
            set => SetValue(nameof(AllowLeftMouseButton), value);
        }
        public int AllowRightMouseButton
        {
            get => (int)GetValue(nameof(AllowRightMouseButton));
            set => SetValue(nameof(AllowRightMouseButton), value);
        }
        public int AllowMiddleMouseButton
        {
            get => (int)GetValue(nameof(AllowMiddleMouseButton));
            set => SetValue(nameof(AllowMiddleMouseButton), value);
        }
        public float Sensitivity
        {
            get => (float)GetValue(nameof(Sensitivity));
            set => SetValue(nameof(Sensitivity), value);
        }
        public float Smoothing
        {
            get => (float)GetValue(nameof(Smoothing));
            set => SetValue(nameof(Smoothing), value);
        }
    }

    public class CameraFieldOfViewSettings : SettingsBackup
    {
        public int FieldOfView
        {
            get => (int)GetValue(nameof(FieldOfView));
            set => SetValue(nameof(FieldOfView), value);
        }
    }

    public class CartoSettings : SettingsBackup
    {
        public int ExportNamingFormat
        {
            get => (int)GetValue(nameof(ExportNamingFormat));
            set => SetValue(nameof(ExportNamingFormat), value);
        }
        public string CustomNamingFormat
        {
            get => (string)GetValue(nameof(CustomNamingFormat));
            set => SetValue(nameof(CustomNamingFormat), value);
        }
        public int ExportVectorFormat
        {
            get => (int)GetValue(nameof(ExportVectorFormat));
            set => SetValue(nameof(ExportVectorFormat), value);
        }
        public int ExportGeoTiffFormat
        {
            get => (int)GetValue(nameof(ExportGeoTiffFormat));
            set => SetValue(nameof(ExportGeoTiffFormat), value);
        }
        public bool SystemArea
        {
            get => (bool)GetValue(nameof(SystemArea));
            set => SetValue(nameof(SystemArea), value);
        }
        public bool FeatureDistrict
        {
            get => (bool)GetValue(nameof(FeatureDistrict));
            set => SetValue(nameof(FeatureDistrict), value);
        }
        public bool FeatureMapTile
        {
            get => (bool)GetValue(nameof(FeatureMapTile));
            set => SetValue(nameof(FeatureMapTile), value);
        }
        public bool SystemBuilding
        {
            get => (bool)GetValue(nameof(SystemBuilding));
            set => SetValue(nameof(SystemBuilding), value);
        }
        public bool FeatureBuilding
        {
            get => (bool)GetValue(nameof(FeatureBuilding));
            set => SetValue(nameof(FeatureBuilding), value);
        }
        public bool FeatureLandfill
        {
            get => (bool)GetValue(nameof(FeatureLandfill));
            set => SetValue(nameof(FeatureLandfill), value);
        }
        public bool FeatureExtractor
        {
            get => (bool)GetValue(nameof(FeatureExtractor));
            set => SetValue(nameof(FeatureExtractor), value);
        }
        public bool SystemNetwork
        {
            get => (bool)GetValue(nameof(SystemNetwork));
            set => SetValue(nameof(SystemNetwork), value);
        }
        public bool FeaturePathway
        {
            get => (bool)GetValue(nameof(FeaturePathway));
            set => SetValue(nameof(FeaturePathway), value);
        }
        public bool FeatureRoad
        {
            get => (bool)GetValue(nameof(FeatureRoad));
            set => SetValue(nameof(FeatureRoad), value);
        }
        public bool FeatureRunwayAndTaxiway
        {
            get => (bool)GetValue(nameof(FeatureRunwayAndTaxiway));
            set => SetValue(nameof(FeatureRunwayAndTaxiway), value);
        }
        public bool FeatureWaterway
        {
            get => (bool)GetValue(nameof(FeatureWaterway));
            set => SetValue(nameof(FeatureWaterway), value);
        }
        public bool FeatureTrack
        {
            get => (bool)GetValue(nameof(FeatureTrack));
            set => SetValue(nameof(FeatureTrack), value);
        }
        public bool SystemPOI
        {
            get => (bool)GetValue(nameof(SystemPOI));
            set => SetValue(nameof(SystemPOI), value);
        }
        public bool FeaturePOIPrivate
        {
            get => (bool)GetValue(nameof(FeaturePOIPrivate));
            set => SetValue(nameof(FeaturePOIPrivate), value);
        }
        public bool FeaturePOIPublic
        {
            get => (bool)GetValue(nameof(FeaturePOIPublic));
            set => SetValue(nameof(FeaturePOIPublic), value);
        }
        public bool FeaturePOITransport
        {
            get => (bool)GetValue(nameof(FeaturePOITransport));
            set => SetValue(nameof(FeaturePOITransport), value);
        }
        public bool FeaturePOIUtility
        {
            get => (bool)GetValue(nameof(FeaturePOIUtility));
            set => SetValue(nameof(FeaturePOIUtility), value);
        }
        public bool SystemRoute
        {
            get => (bool)GetValue(nameof(SystemRoute));
            set => SetValue(nameof(SystemRoute), value);
        }
        public bool FeatureRouteCargo
        {
            get => (bool)GetValue(nameof(FeatureRouteCargo));
            set => SetValue(nameof(FeatureRouteCargo), value);
        }
        public bool FeatureRoutePassenger
        {
            get => (bool)GetValue(nameof(FeatureRoutePassenger));
            set => SetValue(nameof(FeatureRoutePassenger), value);
        }
        public bool SystemZoning
        {
            get => (bool)GetValue(nameof(SystemZoning));
            set => SetValue(nameof(SystemZoning), value);
        }
        public bool FeatureTerrain
        {
            get => (bool)GetValue(nameof(FeatureTerrain));
            set => SetValue(nameof(FeatureTerrain), value);
        }
        public bool FeatureWater
        {
            get => (bool)GetValue(nameof(FeatureWater));
            set => SetValue(nameof(FeatureWater), value);
        }
        public int PropertiesSystemSelector
        {
            get => (int)GetValue(nameof(PropertiesSystemSelector));
            set => SetValue(nameof(PropertiesSystemSelector), value);
        }
        public bool GeometryBoundaryArea
        {
            get => (bool)GetValue(nameof(GeometryBoundaryArea));
            set => SetValue(nameof(GeometryBoundaryArea), value);
        }
        public bool GeometryBoundaryBuilding
        {
            get => (bool)GetValue(nameof(GeometryBoundaryBuilding));
            set => SetValue(nameof(GeometryBoundaryBuilding), value);
        }
        public bool GeometryBoundaryNetwork
        {
            get => (bool)GetValue(nameof(GeometryBoundaryNetwork));
            set => SetValue(nameof(GeometryBoundaryNetwork), value);
        }
        public bool GeometryBoundaryZoning
        {
            get => (bool)GetValue(nameof(GeometryBoundaryZoning));
            set => SetValue(nameof(GeometryBoundaryZoning), value);
        }
        public bool GeometryCenterlineNetwork
        {
            get => (bool)GetValue(nameof(GeometryCenterlineNetwork));
            set => SetValue(nameof(GeometryCenterlineNetwork), value);
        }
        public bool GeometryCenterlineRoute
        {
            get => (bool)GetValue(nameof(GeometryCenterlineRoute));
            set => SetValue(nameof(GeometryCenterlineRoute), value);
        }
        public bool GeometryLocationPOI
        {
            get => (bool)GetValue(nameof(GeometryLocationPOI));
            set => SetValue(nameof(GeometryLocationPOI), value);
        }
        public bool GeometryDepthWater
        {
            get => (bool)GetValue(nameof(GeometryDepthWater));
            set => SetValue(nameof(GeometryDepthWater), value);
        }
        public bool GeometryElevationTerrain
        {
            get => (bool)GetValue(nameof(GeometryElevationTerrain));
            set => SetValue(nameof(GeometryElevationTerrain), value);
        }
        public bool GeometryWorldDepthWater
        {
            get => (bool)GetValue(nameof(GeometryWorldDepthWater));
            set => SetValue(nameof(GeometryWorldDepthWater), value);
        }
        public bool GeometryWorldElevationTerrain
        {
            get => (bool)GetValue(nameof(GeometryWorldElevationTerrain));
            set => SetValue(nameof(GeometryWorldElevationTerrain), value);
        }
        public bool PropertyNameArea
        {
            get => (bool)GetValue(nameof(PropertyNameArea));
            set => SetValue(nameof(PropertyNameArea), value);
        }
        public bool PropertyNameBuilding
        {
            get => (bool)GetValue(nameof(PropertyNameBuilding));
            set => SetValue(nameof(PropertyNameBuilding), value);
        }
        public bool PropertyNameNetwork
        {
            get => (bool)GetValue(nameof(PropertyNameNetwork));
            set => SetValue(nameof(PropertyNameNetwork), value);
        }
        public bool PropertyNamePOI
        {
            get => (bool)GetValue(nameof(PropertyNamePOI));
            set => SetValue(nameof(PropertyNamePOI), value);
        }
        public bool PropertyNameRoute
        {
            get => (bool)GetValue(nameof(PropertyNameRoute));
            set => SetValue(nameof(PropertyNameRoute), value);
        }
        public bool PropertyNameZoning
        {
            get => (bool)GetValue(nameof(PropertyNameZoning));
            set => SetValue(nameof(PropertyNameZoning), value);
        }
        public bool PropertyAddressBuilding
        {
            get => (bool)GetValue(nameof(PropertyAddressBuilding));
            set => SetValue(nameof(PropertyAddressBuilding), value);
        }
        public bool PropertyAddressPOI
        {
            get => (bool)GetValue(nameof(PropertyAddressPOI));
            set => SetValue(nameof(PropertyAddressPOI), value);
        }
        public bool PropertyAgeArea
        {
            get => (bool)GetValue(nameof(PropertyAgeArea));
            set => SetValue(nameof(PropertyAgeArea), value);
        }
        public bool PropertyAgeBuilding
        {
            get => (bool)GetValue(nameof(PropertyAgeBuilding));
            set => SetValue(nameof(PropertyAgeBuilding), value);
        }
        public bool PropertyAreaArea
        {
            get => (bool)GetValue(nameof(PropertyAreaArea));
            set => SetValue(nameof(PropertyAreaArea), value);
        }
        public bool PropertyAssetBuilding
        {
            get => (bool)GetValue(nameof(PropertyAssetBuilding));
            set => SetValue(nameof(PropertyAssetBuilding), value);
        }
        public bool PropertyAssetNetwork
        {
            get => (bool)GetValue(nameof(PropertyAssetNetwork));
            set => SetValue(nameof(PropertyAssetNetwork), value);
        }
        public bool PropertyBrandBuilding
        {
            get => (bool)GetValue(nameof(PropertyBrandBuilding));
            set => SetValue(nameof(PropertyBrandBuilding), value);
        }
        public bool PropertyCategoryBuilding
        {
            get => (bool)GetValue(nameof(PropertyCategoryBuilding));
            set => SetValue(nameof(PropertyCategoryBuilding), value);
        }
        public bool PropertyCategoryNetwork
        {
            get => (bool)GetValue(nameof(PropertyCategoryNetwork));
            set => SetValue(nameof(PropertyCategoryNetwork), value);
        }
        public bool PropertyCategoryPOI
        {
            get => (bool)GetValue(nameof(PropertyCategoryPOI));
            set => SetValue(nameof(PropertyCategoryPOI), value);
        }
        public bool PropertyColorRoute
        {
            get => (bool)GetValue(nameof(PropertyColorRoute));
            set => SetValue(nameof(PropertyColorRoute), value);
        }
        public bool PropertyColorZoning
        {
            get => (bool)GetValue(nameof(PropertyColorZoning));
            set => SetValue(nameof(PropertyColorZoning), value);
        }
        public bool PropertyCompanyArea
        {
            get => (bool)GetValue(nameof(PropertyCompanyArea));
            set => SetValue(nameof(PropertyCompanyArea), value);
        }
        public bool PropertyDensityZoning
        {
            get => (bool)GetValue(nameof(PropertyDensityZoning));
            set => SetValue(nameof(PropertyDensityZoning), value);
        }
        public bool PropertyDirectionNetwork
        {
            get => (bool)GetValue(nameof(PropertyDirectionNetwork));
            set => SetValue(nameof(PropertyDirectionNetwork), value);
        }
        public bool PropertyElevationBuilding
        {
            get => (bool)GetValue(nameof(PropertyElevationBuilding));
            set => SetValue(nameof(PropertyElevationBuilding), value);
        }
        public bool PropertyElevationNetwork
        {
            get => (bool)GetValue(nameof(PropertyElevationNetwork));
            set => SetValue(nameof(PropertyElevationNetwork), value);
        }
        public bool PropertyEmployeeArea
        {
            get => (bool)GetValue(nameof(PropertyEmployeeArea));
            set => SetValue(nameof(PropertyEmployeeArea), value);
        }
        public bool PropertyEmployeeBuilding
        {
            get => (bool)GetValue(nameof(PropertyEmployeeBuilding));
            set => SetValue(nameof(PropertyEmployeeBuilding), value);
        }
        public bool PropertyFormNetwork
        {
            get => (bool)GetValue(nameof(PropertyFormNetwork));
            set => SetValue(nameof(PropertyFormNetwork), value);
        }
        public bool PropertyHouseholdArea
        {
            get => (bool)GetValue(nameof(PropertyHouseholdArea));
            set => SetValue(nameof(PropertyHouseholdArea), value);
        }
        public bool PropertyHouseholdBuilding
        {
            get => (bool)GetValue(nameof(PropertyHouseholdBuilding));
            set => SetValue(nameof(PropertyHouseholdBuilding), value);
        }
        public bool PropertyLaborArea
        {
            get => (bool)GetValue(nameof(PropertyLaborArea));
            set => SetValue(nameof(PropertyLaborArea), value);
        }
        public bool PropertyLaborBuilding
        {
            get => (bool)GetValue(nameof(PropertyLaborBuilding));
            set => SetValue(nameof(PropertyLaborBuilding), value);
        }
        public bool PropertyLaneNetwork
        {
            get => (bool)GetValue(nameof(PropertyLaneNetwork));
            set => SetValue(nameof(PropertyLaneNetwork), value);
        }
        public bool PropertyLengthNetwork
        {
            get => (bool)GetValue(nameof(PropertyLengthNetwork));
            set => SetValue(nameof(PropertyLengthNetwork), value);
        }
        public bool PropertyLengthRoute
        {
            get => (bool)GetValue(nameof(PropertyLengthRoute));
            set => SetValue(nameof(PropertyLengthRoute), value);
        }
        public bool PropertyLevelBuilding
        {
            get => (bool)GetValue(nameof(PropertyLevelBuilding));
            set => SetValue(nameof(PropertyLevelBuilding), value);
        }
        public bool PropertyLimitNetwork
        {
            get => (bool)GetValue(nameof(PropertyLimitNetwork));
            set => SetValue(nameof(PropertyLimitNetwork), value);
        }
        public bool PropertyModelRoute
        {
            get => (bool)GetValue(nameof(PropertyModelRoute));
            set => SetValue(nameof(PropertyModelRoute), value);
        }
        public bool PropertyObjectArea
        {
            get => (bool)GetValue(nameof(PropertyObjectArea));
            set => SetValue(nameof(PropertyObjectArea), value);
        }
        public bool PropertyObjectBuilding
        {
            get => (bool)GetValue(nameof(PropertyObjectBuilding));
            set => SetValue(nameof(PropertyObjectBuilding), value);
        }
        public bool PropertyObjectNetwork
        {
            get => (bool)GetValue(nameof(PropertyObjectNetwork));
            set => SetValue(nameof(PropertyObjectNetwork), value);
        }
        public bool PropertyObjectPOI
        {
            get => (bool)GetValue(nameof(PropertyObjectPOI));
            set => SetValue(nameof(PropertyObjectPOI), value);
        }
        public bool PropertyObjectRoute
        {
            get => (bool)GetValue(nameof(PropertyObjectRoute));
            set => SetValue(nameof(PropertyObjectRoute), value);
        }
        public bool PropertyObjectZoning
        {
            get => (bool)GetValue(nameof(PropertyObjectZoning));
            set => SetValue(nameof(PropertyObjectZoning), value);
        }
        public bool PropertyPassengerRoute
        {
            get => (bool)GetValue(nameof(PropertyPassengerRoute));
            set => SetValue(nameof(PropertyPassengerRoute), value);
        }
        public bool PropertyProductBuilding
        {
            get => (bool)GetValue(nameof(PropertyProductBuilding));
            set => SetValue(nameof(PropertyProductBuilding), value);
        }
        public bool PropertyProfitArea
        {
            get => (bool)GetValue(nameof(PropertyProfitArea));
            set => SetValue(nameof(PropertyProfitArea), value);
        }
        public bool PropertyProfitBuilding
        {
            get => (bool)GetValue(nameof(PropertyProfitBuilding));
            set => SetValue(nameof(PropertyProfitBuilding), value);
        }
        public bool PropertyResidentArea
        {
            get => (bool)GetValue(nameof(PropertyResidentArea));
            set => SetValue(nameof(PropertyResidentArea), value);
        }
        public bool PropertyResidentBuilding
        {
            get => (bool)GetValue(nameof(PropertyResidentBuilding));
            set => SetValue(nameof(PropertyResidentBuilding), value);
        }
        public bool PropertyRouteRoute
        {
            get => (bool)GetValue(nameof(PropertyRouteRoute));
            set => SetValue(nameof(PropertyRouteRoute), value);
        }
        public bool PropertySexRatioArea
        {
            get => (bool)GetValue(nameof(PropertySexRatioArea));
            set => SetValue(nameof(PropertySexRatioArea), value);
        }
        public bool PropertySexRatioBuilding
        {
            get => (bool)GetValue(nameof(PropertySexRatioBuilding));
            set => SetValue(nameof(PropertySexRatioBuilding), value);
        }
        public bool PropertyStopRoute
        {
            get => (bool)GetValue(nameof(PropertyStopRoute));
            set => SetValue(nameof(PropertyStopRoute), value);
        }
        public bool PropertyThemeBuilding
        {
            get => (bool)GetValue(nameof(PropertyThemeBuilding));
            set => SetValue(nameof(PropertyThemeBuilding), value);
        }
        public bool PropertyThemeZoning
        {
            get => (bool)GetValue(nameof(PropertyThemeZoning));
            set => SetValue(nameof(PropertyThemeZoning), value);
        }
        public bool PropertyTransportRoute
        {
            get => (bool)GetValue(nameof(PropertyTransportRoute));
            set => SetValue(nameof(PropertyTransportRoute), value);
        }
        public bool PropertyUnlockedArea
        {
            get => (bool)GetValue(nameof(PropertyUnlockedArea));
            set => SetValue(nameof(PropertyUnlockedArea), value);
        }
        public bool PropertyUsageRoute
        {
            get => (bool)GetValue(nameof(PropertyUsageRoute));
            set => SetValue(nameof(PropertyUsageRoute), value);
        }
        public bool PropertyVehicleRoute
        {
            get => (bool)GetValue(nameof(PropertyVehicleRoute));
            set => SetValue(nameof(PropertyVehicleRoute), value);
        }
        public bool PropertyVolumeNetwork
        {
            get => (bool)GetValue(nameof(PropertyVolumeNetwork));
            set => SetValue(nameof(PropertyVolumeNetwork), value);
        }
        public bool PropertyWageArea
        {
            get => (bool)GetValue(nameof(PropertyWageArea));
            set => SetValue(nameof(PropertyWageArea), value);
        }
        public bool PropertyWageBuilding
        {
            get => (bool)GetValue(nameof(PropertyWageBuilding));
            set => SetValue(nameof(PropertyWageBuilding), value);
        }
        public bool PropertyWeightRoute
        {
            get => (bool)GetValue(nameof(PropertyWeightRoute));
            set => SetValue(nameof(PropertyWeightRoute), value);
        }
        public bool PropertyWidthNetwork
        {
            get => (bool)GetValue(nameof(PropertyWidthNetwork));
            set => SetValue(nameof(PropertyWidthNetwork), value);
        }
        public bool PropertyZoneBuilding
        {
            get => (bool)GetValue(nameof(PropertyZoneBuilding));
            set => SetValue(nameof(PropertyZoneBuilding), value);
        }
        public bool PropertyZoningBuilding
        {
            get => (bool)GetValue(nameof(PropertyZoningBuilding));
            set => SetValue(nameof(PropertyZoningBuilding), value);
        }
        public bool PropertyZoningZoning
        {
            get => (bool)GetValue(nameof(PropertyZoningZoning));
            set => SetValue(nameof(PropertyZoningZoning), value);
        }
        public int SourceCRS
        {
            get => (int)GetValue(nameof(SourceCRS));
            set => SetValue(nameof(SourceCRS), value);
        }
        public string SourceXCoord
        {
            get => (string)GetValue(nameof(SourceXCoord));
            set => SetValue(nameof(SourceXCoord), value);
        }
        public string SourceYCoord
        {
            get => (string)GetValue(nameof(SourceYCoord));
            set => SetValue(nameof(SourceYCoord), value);
        }
        public int SourceHemisphere
        {
            get => (int)GetValue(nameof(SourceHemisphere));
            set => SetValue(nameof(SourceHemisphere), value);
        }
        public string SourceUTMZone
        {
            get => (string)GetValue(nameof(SourceUTMZone));
            set => SetValue(nameof(SourceUTMZone), value);
        }
        public int SourceEllipsoid
        {
            get => (int)GetValue(nameof(SourceEllipsoid));
            set => SetValue(nameof(SourceEllipsoid), value);
        }
        public string SourceEllipsoidSemiMajorAxis
        {
            get => (string)GetValue(nameof(SourceEllipsoidSemiMajorAxis));
            set => SetValue(nameof(SourceEllipsoidSemiMajorAxis), value);
        }
        public string SourceEllipsoidInverseFlattening
        {
            get => (string)GetValue(nameof(SourceEllipsoidInverseFlattening));
            set => SetValue(nameof(SourceEllipsoidInverseFlattening), value);
        }
        public string SourceCRSOriginLongitude
        {
            get => (string)GetValue(nameof(SourceCRSOriginLongitude));
            set => SetValue(nameof(SourceCRSOriginLongitude), value);
        }
        public string SourceCRSOriginLatitude
        {
            get => (string)GetValue(nameof(SourceCRSOriginLatitude));
            set => SetValue(nameof(SourceCRSOriginLatitude), value);
        }
        public string SourceCRSFalseEasting
        {
            get => (string)GetValue(nameof(SourceCRSFalseEasting));
            set => SetValue(nameof(SourceCRSFalseEasting), value);
        }
        public string SourceCRSFalseNorthing
        {
            get => (string)GetValue(nameof(SourceCRSFalseNorthing));
            set => SetValue(nameof(SourceCRSFalseNorthing), value);
        }
        public string SourceCRSScaleFactor
        {
            get => (string)GetValue(nameof(SourceCRSScaleFactor));
            set => SetValue(nameof(SourceCRSScaleFactor), value);
        }
        public string SourceCRSTransform
        {
            get => (string)GetValue(nameof(SourceCRSTransform));
            set => SetValue(nameof(SourceCRSTransform), value);
        }
        public bool OutputElevation
        {
            get => (bool)GetValue(nameof(OutputElevation));
            set => SetValue(nameof(OutputElevation), value);
        }
        public bool OutputMinimizedGeoJSON
        {
            get => (bool)GetValue(nameof(OutputMinimizedGeoJSON));
            set => SetValue(nameof(OutputMinimizedGeoJSON), value);
        }
        public bool PlayCompletionSound
        {
            get => (bool)GetValue(nameof(PlayCompletionSound));
            set => SetValue(nameof(PlayCompletionSound), value);
        }
        public bool ShowCompletionDialog
        {
            get => (bool)GetValue(nameof(ShowCompletionDialog));
            set => SetValue(nameof(ShowCompletionDialog), value);
        }
        public bool GeometryInactiveRoute
        {
            get => (bool)GetValue(nameof(GeometryInactiveRoute));
            set => SetValue(nameof(GeometryInactiveRoute), value);
        }
        public bool GeometrySeparateServiceUpgrade
        {
            get => (bool)GetValue(nameof(GeometrySeparateServiceUpgrade));
            set => SetValue(nameof(GeometrySeparateServiceUpgrade), value);
        }
        public bool GeometryUnzoned
        {
            get => (bool)GetValue(nameof(GeometryUnzoned));
            set => SetValue(nameof(GeometryUnzoned), value);
        }
        public bool PropertyGeneralMapTileStatistics
        {
            get => (bool)GetValue(nameof(PropertyGeneralMapTileStatistics));
            set => SetValue(nameof(PropertyGeneralMapTileStatistics), value);
        }
        public bool PropertyGeneralHomeless
        {
            get => (bool)GetValue(nameof(PropertyGeneralHomeless));
            set => SetValue(nameof(PropertyGeneralHomeless), value);
        }
        public int PropertyCategoryBuildingDisplayMode
        {
            get => (int)GetValue(nameof(PropertyCategoryBuildingDisplayMode));
            set => SetValue(nameof(PropertyCategoryBuildingDisplayMode), value);
        }
        public int PropertyCategoryNetworkDisplayMode
        {
            get => (int)GetValue(nameof(PropertyCategoryNetworkDisplayMode));
            set => SetValue(nameof(PropertyCategoryNetworkDisplayMode), value);
        }
        public int PropertyCategoryPOIDisplayMode
        {
            get => (int)GetValue(nameof(PropertyCategoryPOIDisplayMode));
            set => SetValue(nameof(PropertyCategoryPOIDisplayMode), value);
        }
        public int PropertyCategoryRoadClassification
        {
            get => (int)GetValue(nameof(PropertyCategoryRoadClassification));
            set => SetValue(nameof(PropertyCategoryRoadClassification), value);
        }
        public bool PropertyColorZcc
        {
            get => (bool)GetValue(nameof(PropertyColorZcc));
            set => SetValue(nameof(PropertyColorZcc), value);
        }
        public bool PropertyPassengerPet
        {
            get => (bool)GetValue(nameof(PropertyPassengerPet));
            set => SetValue(nameof(PropertyPassengerPet), value);
        }
        public bool PropertyResidentSeparateBySex
        {
            get => (bool)GetValue(nameof(PropertyResidentSeparateBySex));
            set => SetValue(nameof(PropertyResidentSeparateBySex), value);
        }
        public bool PropertyRouteXtm
        {
            get => (bool)GetValue(nameof(PropertyRouteXtm));
            set => SetValue(nameof(PropertyRouteXtm), value);
        }
        public bool PropertyThemeAssetPack
        {
            get => (bool)GetValue(nameof(PropertyThemeAssetPack));
            set => SetValue(nameof(PropertyThemeAssetPack), value);
        }
        public bool PropertyWageTaxable
        {
            get => (bool)GetValue(nameof(PropertyWageTaxable));
            set => SetValue(nameof(PropertyWageTaxable), value);
        }
        public int PropertyZoningDisplayMode
        {
            get => (int)GetValue(nameof(PropertyZoningDisplayMode));
            set => SetValue(nameof(PropertyZoningDisplayMode), value);
        }
    }

    public class ChangeCompanySettings : SettingsBackup
    {
        public bool LockAfterChange
        {
            get => (bool)GetValue(nameof(LockAfterChange));
            set => SetValue(nameof(LockAfterChange), value);
        }
        public bool LockAllCompanies
        {
            get => (bool)GetValue(nameof(LockAllCompanies));
            set => SetValue(nameof(LockAllCompanies), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class CimRouteHighlighterSettings : SettingsBackup
    {
        public bool highlightWorkplaces
        {
            get => (bool)GetValue(nameof(highlightWorkplaces));
            set => SetValue(nameof(highlightWorkplaces), value);
        }
        public bool highlightEmployeeResidences
        {
            get => (bool)GetValue(nameof(highlightEmployeeResidences));
            set => SetValue(nameof(highlightEmployeeResidences), value);
        }
        public bool highlightEmployeeCommuters
        {
            get => (bool)GetValue(nameof(highlightEmployeeCommuters));
            set => SetValue(nameof(highlightEmployeeCommuters), value);
        }
        public bool highlightStudentResidences
        {
            get => (bool)GetValue(nameof(highlightStudentResidences));
            set => SetValue(nameof(highlightStudentResidences), value);
        }
        public bool highlightDestinations
        {
            get => (bool)GetValue(nameof(highlightDestinations));
            set => SetValue(nameof(highlightDestinations), value);
        }
        public bool showToolIconsInUI
        {
            get => (bool)GetValue(nameof(showToolIconsInUI));
            set => SetValue(nameof(showToolIconsInUI), value);
        }
        public float vehicleRouteWidth
        {
            get => (float)GetValue(nameof(vehicleRouteWidth));
            set => SetValue(nameof(vehicleRouteWidth), value);
        }
        public float pedestrianRouteWidth
        {
            get => (float)GetValue(nameof(pedestrianRouteWidth));
            set => SetValue(nameof(pedestrianRouteWidth), value);
        }
        public float routeOpacity
        {
            get => (float)GetValue(nameof(routeOpacity));
            set => SetValue(nameof(routeOpacity), value);
        }
        public float routeOpacityMultilier
        {
            get => (float)GetValue(nameof(routeOpacityMultilier));
            set => SetValue(nameof(routeOpacityMultilier), value);
        }
        public int threadBatchSize
        {
            get => (int)GetValue(nameof(threadBatchSize));
            set => SetValue(nameof(threadBatchSize), value);
        }
        public bool highlightSelected
        {
            get => (bool)GetValue(nameof(highlightSelected));
            set => SetValue(nameof(highlightSelected), value);
        }
        public bool incomingRoutes
        {
            get => (bool)GetValue(nameof(incomingRoutes));
            set => SetValue(nameof(incomingRoutes), value);
        }
        public bool incomingRoutesTransit
        {
            get => (bool)GetValue(nameof(incomingRoutesTransit));
            set => SetValue(nameof(incomingRoutesTransit), value);
        }
        public bool highlightSelectedTransitVehiclePassengerRoutes
        {
            get => (bool)GetValue(nameof(highlightSelectedTransitVehiclePassengerRoutes));
            set => SetValue(nameof(highlightSelectedTransitVehiclePassengerRoutes), value);
        }
        public bool showCountsOnInfoPanel
        {
            get => (bool)GetValue(nameof(showCountsOnInfoPanel));
            set => SetValue(nameof(showCountsOnInfoPanel), value);
        }
    }

    public class CitizenModelManagerSettings : SettingsBackup
    {
        public string Child_Female_Warm
        {
            get => (string)GetValue(nameof(Child_Female_Warm));
            set => SetValue(nameof(Child_Female_Warm), value);
        }
        public string Child_Male_Warm
        {
            get => (string)GetValue(nameof(Child_Male_Warm));
            set => SetValue(nameof(Child_Male_Warm), value);
        }
        public string Child_Female_Cold
        {
            get => (string)GetValue(nameof(Child_Female_Cold));
            set => SetValue(nameof(Child_Female_Cold), value);
        }
        public string Child_Male_Cold
        {
            get => (string)GetValue(nameof(Child_Male_Cold));
            set => SetValue(nameof(Child_Male_Cold), value);
        }
        public string Teen_Female_Warm
        {
            get => (string)GetValue(nameof(Teen_Female_Warm));
            set => SetValue(nameof(Teen_Female_Warm), value);
        }
        public string Teen_Male_Warm
        {
            get => (string)GetValue(nameof(Teen_Male_Warm));
            set => SetValue(nameof(Teen_Male_Warm), value);
        }
        public string Teen_Female_Cold
        {
            get => (string)GetValue(nameof(Teen_Female_Cold));
            set => SetValue(nameof(Teen_Female_Cold), value);
        }
        public string Teen_Male_Cold
        {
            get => (string)GetValue(nameof(Teen_Male_Cold));
            set => SetValue(nameof(Teen_Male_Cold), value);
        }
        public string Adult_Female_Warm
        {
            get => (string)GetValue(nameof(Adult_Female_Warm));
            set => SetValue(nameof(Adult_Female_Warm), value);
        }
        public string Adult_Male_Warm
        {
            get => (string)GetValue(nameof(Adult_Male_Warm));
            set => SetValue(nameof(Adult_Male_Warm), value);
        }
        public string Adult_Female_Cold
        {
            get => (string)GetValue(nameof(Adult_Female_Cold));
            set => SetValue(nameof(Adult_Female_Cold), value);
        }
        public string Adult_Male_Cold
        {
            get => (string)GetValue(nameof(Adult_Male_Cold));
            set => SetValue(nameof(Adult_Male_Cold), value);
        }
        public string Adult_Female_Homeless
        {
            get => (string)GetValue(nameof(Adult_Female_Homeless));
            set => SetValue(nameof(Adult_Female_Homeless), value);
        }
        public string Adult_Male_Homeless
        {
            get => (string)GetValue(nameof(Adult_Male_Homeless));
            set => SetValue(nameof(Adult_Male_Homeless), value);
        }
        public string Elderly_Female_Warm
        {
            get => (string)GetValue(nameof(Elderly_Female_Warm));
            set => SetValue(nameof(Elderly_Female_Warm), value);
        }
        public string Elderly_Male_Warm
        {
            get => (string)GetValue(nameof(Elderly_Male_Warm));
            set => SetValue(nameof(Elderly_Male_Warm), value);
        }
        public string Elderly_Female_Cold
        {
            get => (string)GetValue(nameof(Elderly_Female_Cold));
            set => SetValue(nameof(Elderly_Female_Cold), value);
        }
        public string Elderly_Male_Cold
        {
            get => (string)GetValue(nameof(Elderly_Male_Cold));
            set => SetValue(nameof(Elderly_Male_Cold), value);
        }
        public string Elderly_Female_Homeless
        {
            get => (string)GetValue(nameof(Elderly_Female_Homeless));
            set => SetValue(nameof(Elderly_Female_Homeless), value);
        }
        public string Elderly_Male_Homeless
        {
            get => (string)GetValue(nameof(Elderly_Male_Homeless));
            set => SetValue(nameof(Elderly_Male_Homeless), value);
        }
    }

    public class CityControllerSettings : SettingsBackup
    {
        public bool AchievementsEnabled
        {
            get => (bool)GetValue(nameof(AchievementsEnabled));
            set => SetValue(nameof(AchievementsEnabled), value);
        }
        public int ManualMoneyAmount
        {
            get => (int)GetValue(nameof(ManualMoneyAmount));
            set => SetValue(nameof(ManualMoneyAmount), value);
        }
        public bool AutomaticAddMoney
        {
            get => (bool)GetValue(nameof(AutomaticAddMoney));
            set => SetValue(nameof(AutomaticAddMoney), value);
        }
        public int AutomaticAddMoneyThreshold
        {
            get => (int)GetValue(nameof(AutomaticAddMoneyThreshold));
            set => SetValue(nameof(AutomaticAddMoneyThreshold), value);
        }
        public int AutomaticAddMoneyAmount
        {
            get => (int)GetValue(nameof(AutomaticAddMoneyAmount));
            set => SetValue(nameof(AutomaticAddMoneyAmount), value);
        }
        public int InitialMoney
        {
            get => (int)GetValue(nameof(InitialMoney));
            set => SetValue(nameof(InitialMoney), value);
        }
        public bool CustomMilestone
        {
            get => (bool)GetValue(nameof(CustomMilestone));
            set => SetValue(nameof(CustomMilestone), value);
        }
        public int MilestoneLevel
        {
            get => (int)GetValue(nameof(MilestoneLevel));
            set => SetValue(nameof(MilestoneLevel), value);
        }
    }

    public class CityStatsSettings : SettingsBackup
    {
        public bool PanelOpenOnLoad
        {
            get => (bool)GetValue(nameof(PanelOpenOnLoad));
            set => SetValue(nameof(PanelOpenOnLoad), value);
        }
        public int PanelOrientation
        {
            get => (int)GetValue(nameof(PanelOrientation));
            set => SetValue(nameof(PanelOrientation), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class CrowdedStationSettings : SettingsBackup
    {
        public int iShowListTop
        {
            get => (int)GetValue(nameof(iShowListTop));
            set => SetValue(nameof(iShowListTop), value);
        }
        public bool bShowLineOnOpen
        {
            get => (bool)GetValue(nameof(bShowLineOnOpen));
            set => SetValue(nameof(bShowLineOnOpen), value);
        }
        public bool bShowLineUseRate
        {
            get => (bool)GetValue(nameof(bShowLineUseRate));
            set => SetValue(nameof(bShowLineUseRate), value);
        }
        public int uiShowScale
        {
            get => (int)GetValue(nameof(uiShowScale));
            set => SetValue(nameof(uiShowScale), value);
        }
    }

    public class DetailedDescriptionsSettings : SettingsBackup
    {
        public bool ShowBuildingLotSizes
        {
            get => (bool)GetValue(nameof(ShowBuildingLotSizes));
            set => SetValue(nameof(ShowBuildingLotSizes), value);
        }
        public int BuildingLotSizeUnit
        {
            get => (int)GetValue(nameof(BuildingLotSizeUnit));
            set => SetValue(nameof(BuildingLotSizeUnit), value);
        }
        public bool ShowZoneLotSizes
        {
            get => (bool)GetValue(nameof(ShowZoneLotSizes));
            set => SetValue(nameof(ShowZoneLotSizes), value);
        }
        public bool ShowBuildingWorkplaces
        {
            get => (bool)GetValue(nameof(ShowBuildingWorkplaces));
            set => SetValue(nameof(ShowBuildingWorkplaces), value);
        }
        public bool ShowRoadSpeedLimit
        {
            get => (bool)GetValue(nameof(ShowRoadSpeedLimit));
            set => SetValue(nameof(ShowRoadSpeedLimit), value);
        }
        public int RoadSpeedLimitUnit
        {
            get => (int)GetValue(nameof(RoadSpeedLimitUnit));
            set => SetValue(nameof(RoadSpeedLimitUnit), value);
        }
    }

    public class DemandMasterControlSettings : SettingsBackup
    {
        public int MinimumHappiness
        {
            get => (int)GetValue(nameof(MinimumHappiness));
            set => SetValue(nameof(MinimumHappiness), value);
        }
        public int NeutralHappiness
        {
            get => (int)GetValue(nameof(NeutralHappiness));
            set => SetValue(nameof(NeutralHappiness), value);
        }
        public float HappinessEffect
        {
            get => (float)GetValue(nameof(HappinessEffect));
            set => SetValue(nameof(HappinessEffect), value);
        }
        public float AvailableWorkplaceEffect
        {
            get => (float)GetValue(nameof(AvailableWorkplaceEffect));
            set => SetValue(nameof(AvailableWorkplaceEffect), value);
        }
        public float NeutralUnemployment
        {
            get => (float)GetValue(nameof(NeutralUnemployment));
            set => SetValue(nameof(NeutralUnemployment), value);
        }
        public float NeutralAvailableWorkplacePercentage
        {
            get => (float)GetValue(nameof(NeutralAvailableWorkplacePercentage));
            set => SetValue(nameof(NeutralAvailableWorkplacePercentage), value);
        }
        public float TaxEffect_x
        {
            get => (float)GetValue(nameof(TaxEffect_x));
            set => SetValue(nameof(TaxEffect_x), value);
        }
        public float TaxEffect_y
        {
            get => (float)GetValue(nameof(TaxEffect_y));
            set => SetValue(nameof(TaxEffect_y), value);
        }
        public float TaxEffect_z
        {
            get => (float)GetValue(nameof(TaxEffect_z));
            set => SetValue(nameof(TaxEffect_z), value);
        }
        public float StudentEffect
        {
            get => (float)GetValue(nameof(StudentEffect));
            set => SetValue(nameof(StudentEffect), value);
        }
        public float HomelessEffect
        {
            get => (float)GetValue(nameof(HomelessEffect));
            set => SetValue(nameof(HomelessEffect), value);
        }
        public float NeutralHomelessness
        {
            get => (float)GetValue(nameof(NeutralHomelessness));
            set => SetValue(nameof(NeutralHomelessness), value);
        }
        public int FreeResidentialRequirement_Low
        {
            get => (int)GetValue(nameof(FreeResidentialRequirement_Low));
            set => SetValue(nameof(FreeResidentialRequirement_Low), value);
        }
        public int FreeResidentialRequirement_Medium
        {
            get => (int)GetValue(nameof(FreeResidentialRequirement_Medium));
            set => SetValue(nameof(FreeResidentialRequirement_Medium), value);
        }
        public int FreeResidentialRequirement_High
        {
            get => (int)GetValue(nameof(FreeResidentialRequirement_High));
            set => SetValue(nameof(FreeResidentialRequirement_High), value);
        }

        //public float FreeCommercialProportion
        //{
        //    get => (float)GetValue(nameof(FreeCommercialProportion));
        //    set => SetValue(nameof(FreeCommercialProportion), value);
        //}
        //public float FreeIndustrialProportion
        //{
        //    get => (float)GetValue(nameof(FreeIndustrialProportion));
        //    set => SetValue(nameof(FreeIndustrialProportion), value);
        //}
        //public float CommercialStorageMinimum
        //{
        //    get => (float)GetValue(nameof(CommercialStorageMinimum));
        //    set => SetValue(nameof(CommercialStorageMinimum), value);
        //}
        //public float CommercialStorageEffect
        //{
        //    get => (float)GetValue(nameof(CommercialStorageEffect));
        //    set => SetValue(nameof(CommercialStorageEffect), value);
        //}
        public float CommercialBaseDemand
        {
            get => (float)GetValue(nameof(CommercialBaseDemand));
            set => SetValue(nameof(CommercialBaseDemand), value);
        }
        public float HotelRoomPercentRequirement
        {
            get => (float)GetValue(nameof(HotelRoomPercentRequirement));
            set => SetValue(nameof(HotelRoomPercentRequirement), value);
        }

        //public float IndustrialStorageMinimum
        //{
        //    get => (float)GetValue(nameof(IndustrialStorageMinimum));
        //    set => SetValue(nameof(IndustrialStorageMinimum), value);
        //}
        //public float IndustrialStorageEffect
        //{
        //    get => (float)GetValue(nameof(IndustrialStorageEffect));
        //    set => SetValue(nameof(IndustrialStorageEffect), value);
        //}
        public float IndustrialBaseDemand
        {
            get => (float)GetValue(nameof(IndustrialBaseDemand));
            set => SetValue(nameof(IndustrialBaseDemand), value);
        }
        public float ExtractorBaseDemand
        {
            get => (float)GetValue(nameof(ExtractorBaseDemand));
            set => SetValue(nameof(ExtractorBaseDemand), value);
        }

        //public float StorageDemandMultiplier
        //{
        //    get => (float)GetValue(nameof(StorageDemandMultiplier));
        //    set => SetValue(nameof(StorageDemandMultiplier), value);
        //}
        public int CommuterWorkerRatioLimit
        {
            get => (int)GetValue(nameof(CommuterWorkerRatioLimit));
            set => SetValue(nameof(CommuterWorkerRatioLimit), value);
        }
        public int CommuterSlowSpawnFactor
        {
            get => (int)GetValue(nameof(CommuterSlowSpawnFactor));
            set => SetValue(nameof(CommuterSlowSpawnFactor), value);
        }
        public float CommuterOCSpawnParameters_Road
        {
            get => (float)GetValue(nameof(CommuterOCSpawnParameters_Road));
            set => SetValue(nameof(CommuterOCSpawnParameters_Road), value);
        }
        public float CommuterOCSpawnParameters_Train
        {
            get => (float)GetValue(nameof(CommuterOCSpawnParameters_Train));
            set => SetValue(nameof(CommuterOCSpawnParameters_Train), value);
        }
        public float CommuterOCSpawnParameters_Air
        {
            get => (float)GetValue(nameof(CommuterOCSpawnParameters_Air));
            set => SetValue(nameof(CommuterOCSpawnParameters_Air), value);
        }
        public float CommuterOCSpawnParameters_Ship
        {
            get => (float)GetValue(nameof(CommuterOCSpawnParameters_Ship));
            set => SetValue(nameof(CommuterOCSpawnParameters_Ship), value);
        }
        public float TouristOCSpawnParameters_Road
        {
            get => (float)GetValue(nameof(TouristOCSpawnParameters_Road));
            set => SetValue(nameof(TouristOCSpawnParameters_Road), value);
        }
        public float TouristOCSpawnParameters_Train
        {
            get => (float)GetValue(nameof(TouristOCSpawnParameters_Train));
            set => SetValue(nameof(TouristOCSpawnParameters_Train), value);
        }
        public float TouristOCSpawnParameters_Air
        {
            get => (float)GetValue(nameof(TouristOCSpawnParameters_Air));
            set => SetValue(nameof(TouristOCSpawnParameters_Air), value);
        }
        public float TouristOCSpawnParameters_Ship
        {
            get => (float)GetValue(nameof(TouristOCSpawnParameters_Ship));
            set => SetValue(nameof(TouristOCSpawnParameters_Ship), value);
        }
        public float CitizenOCSpawnParameters_Road
        {
            get => (float)GetValue(nameof(CitizenOCSpawnParameters_Road));
            set => SetValue(nameof(CitizenOCSpawnParameters_Road), value);
        }
        public float CitizenOCSpawnParameters_Train
        {
            get => (float)GetValue(nameof(CitizenOCSpawnParameters_Train));
            set => SetValue(nameof(CitizenOCSpawnParameters_Train), value);
        }
        public float CitizenOCSpawnParameters_Air
        {
            get => (float)GetValue(nameof(CitizenOCSpawnParameters_Air));
            set => SetValue(nameof(CitizenOCSpawnParameters_Air), value);
        }
        public float CitizenOCSpawnParameters_Ship
        {
            get => (float)GetValue(nameof(CitizenOCSpawnParameters_Ship));
            set => SetValue(nameof(CitizenOCSpawnParameters_Ship), value);
        }
        public float TeenSpawnPercentage
        {
            get => (float)GetValue(nameof(TeenSpawnPercentage));
            set => SetValue(nameof(TeenSpawnPercentage), value);
        }
        public int FrameIntervalForSpawning_Res
        {
            get => (int)GetValue(nameof(FrameIntervalForSpawning_Res));
            set => SetValue(nameof(FrameIntervalForSpawning_Res), value);
        }
        public int FrameIntervalForSpawning_Com
        {
            get => (int)GetValue(nameof(FrameIntervalForSpawning_Com));
            set => SetValue(nameof(FrameIntervalForSpawning_Com), value);
        }
        public int FrameIntervalForSpawning_Ind
        {
            get => (int)GetValue(nameof(FrameIntervalForSpawning_Ind));
            set => SetValue(nameof(FrameIntervalForSpawning_Ind), value);
        }
        public float HouseholdSpawnSpeedFactor
        {
            get => (float)GetValue(nameof(HouseholdSpawnSpeedFactor));
            set => SetValue(nameof(HouseholdSpawnSpeedFactor), value);
        }
        public float NewCitizenEducationParameters_Uneducated
        {
            get => (float)GetValue(nameof(NewCitizenEducationParameters_Uneducated));
            set => SetValue(nameof(NewCitizenEducationParameters_Uneducated), value);
        }
        public float NewCitizenEducationParameters_PoorlyEducated
        {
            get => (float)GetValue(nameof(NewCitizenEducationParameters_PoorlyEducated));
            set => SetValue(nameof(NewCitizenEducationParameters_PoorlyEducated), value);
        }
        public float NewCitizenEducationParameters_Educated
        {
            get => (float)GetValue(nameof(NewCitizenEducationParameters_Educated));
            set => SetValue(nameof(NewCitizenEducationParameters_Educated), value);
        }
        public float NewCitizenEducationParameters_WellEducated
        {
            get => (float)GetValue(nameof(NewCitizenEducationParameters_WellEducated));
            set => SetValue(nameof(NewCitizenEducationParameters_WellEducated), value);
        }
        public float NewCitizenEducationParameters_HighlyEducated
        {
            get => (float)GetValue(nameof(NewCitizenEducationParameters_HighlyEducated));
            set => SetValue(nameof(NewCitizenEducationParameters_HighlyEducated), value);
        }
    }

    public class DepotCapacityChangerSettings : SettingsBackup
    {
        public int BusSlider
        {
            get => (int)GetValue(nameof(BusSlider));
            set => SetValue(nameof(BusSlider), value);
        }
        public int TaxiSlider
        {
            get => (int)GetValue(nameof(TaxiSlider));
            set => SetValue(nameof(TaxiSlider), value);
        }
        public int TramSlider
        {
            get => (int)GetValue(nameof(TramSlider));
            set => SetValue(nameof(TramSlider), value);
        }
        public int TrainSlider
        {
            get => (int)GetValue(nameof(TrainSlider));
            set => SetValue(nameof(TrainSlider), value);
        }
        public int SubwaySlider
        {
            get => (int)GetValue(nameof(SubwaySlider));
            set => SetValue(nameof(SubwaySlider), value);
        }
    }

    public class DisableAccidentsSettings : SettingsBackup
    {
        public bool ModEnabled
        {
            get => (bool)GetValue(nameof(ModEnabled));
            set => SetValue(nameof(ModEnabled), value);
        }
        public int AccidentProbability
        {
            get => (int)GetValue(nameof(AccidentProbability));
            set => SetValue(nameof(AccidentProbability), value);
        }
    }

    public class EventsControllerSettings : SettingsBackup
    {
        public bool LightningStrikeOccurenceToggle
        {
            get => (bool)GetValue(nameof(LightningStrikeOccurenceToggle));
            set => SetValue(nameof(LightningStrikeOccurenceToggle), value);
        }
        public float LightningIntervalMin
        {
            get => (float)GetValue(nameof(LightningIntervalMin));
            set => SetValue(nameof(LightningIntervalMin), value);
        }
        public float LightningIntervalMax
        {
            get => (float)GetValue(nameof(LightningIntervalMax));
            set => SetValue(nameof(LightningIntervalMax), value);
        }
        public float DurationMin
        {
            get => (float)GetValue(nameof(DurationMin));
            set => SetValue(nameof(DurationMin), value);
        }
        public float DurationMax
        {
            get => (float)GetValue(nameof(DurationMax));
            set => SetValue(nameof(DurationMax), value);
        }
        public float OccurenceTemperatureMin
        {
            get => (float)GetValue(nameof(OccurenceTemperatureMin));
            set => SetValue(nameof(OccurenceTemperatureMin), value);
        }
        public float OccurenceTemperatureMax
        {
            get => (float)GetValue(nameof(OccurenceTemperatureMax));
            set => SetValue(nameof(OccurenceTemperatureMax), value);
        }
        public float LightningFireStartProbability
        {
            get => (float)GetValue(nameof(LightningFireStartProbability));
            set => SetValue(nameof(LightningFireStartProbability), value);
        }
        public float LightningFireStartIntensity
        {
            get => (float)GetValue(nameof(LightningFireStartIntensity));
            set => SetValue(nameof(LightningFireStartIntensity), value);
        }
        public float LightningFireEscalationRate
        {
            get => (float)GetValue(nameof(LightningFireEscalationRate));
            set => SetValue(nameof(LightningFireEscalationRate), value);
        }
        public float LightningFireSpreadProbability
        {
            get => (float)GetValue(nameof(LightningFireSpreadProbability));
            set => SetValue(nameof(LightningFireSpreadProbability), value);
        }
        public float LightningFireSpreadRange
        {
            get => (float)GetValue(nameof(LightningFireSpreadRange));
            set => SetValue(nameof(LightningFireSpreadRange), value);
        }
        public bool TornadoOccurenceToggle
        {
            get => (bool)GetValue(nameof(TornadoOccurenceToggle));
            set => SetValue(nameof(TornadoOccurenceToggle), value);
        }
        public float TornadoDamageSeverity
        {
            get => (float)GetValue(nameof(TornadoDamageSeverity));
            set => SetValue(nameof(TornadoDamageSeverity), value);
        }
        public float TornadoDurationMin
        {
            get => (float)GetValue(nameof(TornadoDurationMin));
            set => SetValue(nameof(TornadoDurationMin), value);
        }
        public float TornadoDurationMax
        {
            get => (float)GetValue(nameof(TornadoDurationMax));
            set => SetValue(nameof(TornadoDurationMax), value);
        }
        public float TornadoOccurenceTemperatureMin
        {
            get => (float)GetValue(nameof(TornadoOccurenceTemperatureMin));
            set => SetValue(nameof(TornadoOccurenceTemperatureMin), value);
        }
        public float TornadoOccurenceTemperatureMax
        {
            get => (float)GetValue(nameof(TornadoOccurenceTemperatureMax));
            set => SetValue(nameof(TornadoOccurenceTemperatureMax), value);
        }
        public float TornadoOccurenceRainMin
        {
            get => (float)GetValue(nameof(TornadoOccurenceRainMin));
            set => SetValue(nameof(TornadoOccurenceRainMin), value);
        }
        public float TornadoOccurenceRainMax
        {
            get => (float)GetValue(nameof(TornadoOccurenceRainMax));
            set => SetValue(nameof(TornadoOccurenceRainMax), value);
        }
        public float TornadoTrafficAccidentOccurenceProbability
        {
            get => (float)GetValue(nameof(TornadoTrafficAccidentOccurenceProbability));
            set => SetValue(nameof(TornadoTrafficAccidentOccurenceProbability), value);
        }
        public bool BuildingCollapseOccurenceToggle
        {
            get => (bool)GetValue(nameof(BuildingCollapseOccurenceToggle));
            set => SetValue(nameof(BuildingCollapseOccurenceToggle), value);
        }
        public bool BuildingFireToggle
        {
            get => (bool)GetValue(nameof(BuildingFireToggle));
            set => SetValue(nameof(BuildingFireToggle), value);
        }
        public float BuildingFireStartIntensity
        {
            get => (float)GetValue(nameof(BuildingFireStartIntensity));
            set => SetValue(nameof(BuildingFireStartIntensity), value);
        }
        public float BuildingFireEscalationRate
        {
            get => (float)GetValue(nameof(BuildingFireEscalationRate));
            set => SetValue(nameof(BuildingFireEscalationRate), value);
        }
        public float BuildingFireSpreadProbability
        {
            get => (float)GetValue(nameof(BuildingFireSpreadProbability));
            set => SetValue(nameof(BuildingFireSpreadProbability), value);
        }
        public float BuildingFireSpreadRange
        {
            get => (float)GetValue(nameof(BuildingFireSpreadRange));
            set => SetValue(nameof(BuildingFireSpreadRange), value);
        }
        public bool ForestFireToggle
        {
            get => (bool)GetValue(nameof(ForestFireToggle));
            set => SetValue(nameof(ForestFireToggle), value);
        }
        public float ForestFireStartIntensity
        {
            get => (float)GetValue(nameof(ForestFireStartIntensity));
            set => SetValue(nameof(ForestFireStartIntensity), value);
        }
        public float ForestFireEscalationRate
        {
            get => (float)GetValue(nameof(ForestFireEscalationRate));
            set => SetValue(nameof(ForestFireEscalationRate), value);
        }
        public float ForestFireSpreadProbability
        {
            get => (float)GetValue(nameof(ForestFireSpreadProbability));
            set => SetValue(nameof(ForestFireSpreadProbability), value);
        }
        public float ForestFireSpreadRange
        {
            get => (float)GetValue(nameof(ForestFireSpreadRange));
            set => SetValue(nameof(ForestFireSpreadRange), value);
        }
        public bool RobberyOccurenceToggle
        {
            get => (bool)GetValue(nameof(RobberyOccurenceToggle));
            set => SetValue(nameof(RobberyOccurenceToggle), value);
        }
        public float OccurenceProbabilityMin
        {
            get => (float)GetValue(nameof(OccurenceProbabilityMin));
            set => SetValue(nameof(OccurenceProbabilityMin), value);
        }
        public float OccurenceProbabilityMax
        {
            get => (float)GetValue(nameof(OccurenceProbabilityMax));
            set => SetValue(nameof(OccurenceProbabilityMax), value);
        }
        public float RecurrenceProbabilityMin
        {
            get => (float)GetValue(nameof(RecurrenceProbabilityMin));
            set => SetValue(nameof(RecurrenceProbabilityMin), value);
        }
        public float RecurrenceProbabilityMax
        {
            get => (float)GetValue(nameof(RecurrenceProbabilityMax));
            set => SetValue(nameof(RecurrenceProbabilityMax), value);
        }
        public bool LCAAccidentOccurenceToggle
        {
            get => (bool)GetValue(nameof(LCAAccidentOccurenceToggle));
            set => SetValue(nameof(LCAAccidentOccurenceToggle), value);
        }
        public bool LCAFireStartProbabilityToggle
        {
            get => (bool)GetValue(nameof(LCAFireStartProbabilityToggle));
            set => SetValue(nameof(LCAFireStartProbabilityToggle), value);
        }
        public bool HsOccurenceToggle
        {
            get => (bool)GetValue(nameof(HsOccurenceToggle));
            set => SetValue(nameof(HsOccurenceToggle), value);
        }
        public float HSDamageSeverity
        {
            get => (float)GetValue(nameof(HSDamageSeverity));
            set => SetValue(nameof(HSDamageSeverity), value);
        }
        public float HSDurationMin
        {
            get => (float)GetValue(nameof(HSDurationMin));
            set => SetValue(nameof(HSDurationMin), value);
        }
        public float HSDurationMax
        {
            get => (float)GetValue(nameof(HSDurationMax));
            set => SetValue(nameof(HSDurationMax), value);
        }
        public float HSTemperatureMin
        {
            get => (float)GetValue(nameof(HSTemperatureMin));
            set => SetValue(nameof(HSTemperatureMin), value);
        }
        public float HSTemperatureMax
        {
            get => (float)GetValue(nameof(HSTemperatureMax));
            set => SetValue(nameof(HSTemperatureMax), value);
        }
        public float HSRainMin
        {
            get => (float)GetValue(nameof(HSRainMin));
            set => SetValue(nameof(HSRainMin), value);
        }
        public float HSRainMax
        {
            get => (float)GetValue(nameof(HSRainMax));
            set => SetValue(nameof(HSRainMax), value);
        }
        public float HSTrafficAccidentOccurenceProbability
        {
            get => (float)GetValue(nameof(HSTrafficAccidentOccurenceProbability));
            set => SetValue(nameof(HSTrafficAccidentOccurenceProbability), value);
        }
        public bool EnableSummerFireIncrease
        {
            get => (bool)GetValue(nameof(EnableSummerFireIncrease));
            set => SetValue(nameof(EnableSummerFireIncrease), value);
        }
        public bool EnableWeatherEffectsOnFires
        {
            get => (bool)GetValue(nameof(EnableWeatherEffectsOnFires));
            set => SetValue(nameof(EnableWeatherEffectsOnFires), value);
        }
    }

    public class ExtendedTooltipSettings : SettingsBackup
    {
        public bool UseExtendedLayout
        {
            get => (bool)GetValue(nameof(UseExtendedLayout));
            set => SetValue(nameof(UseExtendedLayout), value);
        }
        public DisplayMode DisplayMode
        {
            get => (DisplayMode)GetValue(nameof(DisplayMode));
            set => SetValue(nameof(DisplayMode), value);
        }
        public int DisplayModeHotkey
        {
            get => (int)GetValue(nameof(DisplayModeHotkey));
            set => SetValue(nameof(DisplayModeHotkey), value);
        }
        public int DisplayModeDelay
        {
            get => (int)GetValue(nameof(DisplayModeDelay));
            set => SetValue(nameof(DisplayModeDelay), value);
        }
        public bool DisplayModeDelayOnMoveables
        {
            get => (bool)GetValue(nameof(DisplayModeDelayOnMoveables));
            set => SetValue(nameof(DisplayModeDelayOnMoveables), value);
        }
        public bool ShowEfficiency
        {
            get => (bool)GetValue(nameof(ShowEfficiency));
            set => SetValue(nameof(ShowEfficiency), value);
        }
        public bool ShowLotSize
        {
            get => (bool)GetValue(nameof(ShowLotSize));
            set => SetValue(nameof(ShowLotSize), value);
        }
        public bool ShowCompanyOutput
        {
            get => (bool)GetValue(nameof(ShowCompanyOutput));
            set => SetValue(nameof(ShowCompanyOutput), value);
        }
        public bool ShowEmployee
        {
            get => (bool)GetValue(nameof(ShowEmployee));
            set => SetValue(nameof(ShowEmployee), value);
        }
        public bool ShowCompanyRent
        {
            get => (bool)GetValue(nameof(ShowCompanyRent));
            set => SetValue(nameof(ShowCompanyRent), value);
        }
        public bool ShowCompanyBalance
        {
            get => (bool)GetValue(nameof(ShowCompanyBalance));
            set => SetValue(nameof(ShowCompanyBalance), value);
        }
        public bool ShowCompanyProfitability
        {
            get => (bool)GetValue(nameof(ShowCompanyProfitability));
            set => SetValue(nameof(ShowCompanyProfitability), value);
        }
        public bool ShowCompanyProfitabilityAbsolute
        {
            get => (bool)GetValue(nameof(ShowCompanyProfitabilityAbsolute));
            set => SetValue(nameof(ShowCompanyProfitabilityAbsolute), value);
        }
        public bool ShowNetToolSystem
        {
            get => (bool)GetValue(nameof(ShowNetToolSystem));
            set => SetValue(nameof(ShowNetToolSystem), value);
        }
        public bool ShowNetToolUnits
        {
            get => (bool)GetValue(nameof(ShowNetToolUnits));
            set => SetValue(nameof(ShowNetToolUnits), value);
        }
        public bool ShowNetToolMode
        {
            get => (bool)GetValue(nameof(ShowNetToolMode));
            set => SetValue(nameof(ShowNetToolMode), value);
        }
        public bool ShowNetToolElevation
        {
            get => (bool)GetValue(nameof(ShowNetToolElevation));
            set => SetValue(nameof(ShowNetToolElevation), value);
        }
        public bool ShowTerrainToolHeight
        {
            get => (bool)GetValue(nameof(ShowTerrainToolHeight));
            set => SetValue(nameof(ShowTerrainToolHeight), value);
        }
        public bool ShowWaterToolHeight
        {
            get => (bool)GetValue(nameof(ShowWaterToolHeight));
            set => SetValue(nameof(ShowWaterToolHeight), value);
        }
        public bool ShowCitizen
        {
            get => (bool)GetValue(nameof(ShowCitizen));
            set => SetValue(nameof(ShowCitizen), value);
        }
        public bool ShowCitizenState
        {
            get => (bool)GetValue(nameof(ShowCitizenState));
            set => SetValue(nameof(ShowCitizenState), value);
        }
        public bool ShowCitizenWealth
        {
            get => (bool)GetValue(nameof(ShowCitizenWealth));
            set => SetValue(nameof(ShowCitizenWealth), value);
        }
        public bool ShowCitizenType
        {
            get => (bool)GetValue(nameof(ShowCitizenType));
            set => SetValue(nameof(ShowCitizenType), value);
        }
        public bool ShowCitizenHappiness
        {
            get => (bool)GetValue(nameof(ShowCitizenHappiness));
            set => SetValue(nameof(ShowCitizenHappiness), value);
        }
        public bool ShowCitizenEducation
        {
            get => (bool)GetValue(nameof(ShowCitizenEducation));
            set => SetValue(nameof(ShowCitizenEducation), value);
        }
        public bool ShowPark
        {
            get => (bool)GetValue(nameof(ShowPark));
            set => SetValue(nameof(ShowPark), value);
        }
        public bool ShowParkMaintenance
        {
            get => (bool)GetValue(nameof(ShowParkMaintenance));
            set => SetValue(nameof(ShowParkMaintenance), value);
        }
        public bool ShowParkingFacility
        {
            get => (bool)GetValue(nameof(ShowParkingFacility));
            set => SetValue(nameof(ShowParkingFacility), value);
        }
        public bool ShowParkingFees
        {
            get => (bool)GetValue(nameof(ShowParkingFees));
            set => SetValue(nameof(ShowParkingFees), value);
        }
        public bool ShowParkingCapacity
        {
            get => (bool)GetValue(nameof(ShowParkingCapacity));
            set => SetValue(nameof(ShowParkingCapacity), value);
        }
        public bool ShowPublicTransport
        {
            get => (bool)GetValue(nameof(ShowPublicTransport));
            set => SetValue(nameof(ShowPublicTransport), value);
        }
        public bool ShowPublicTransportWaitingPassengers
        {
            get => (bool)GetValue(nameof(ShowPublicTransportWaitingPassengers));
            set => SetValue(nameof(ShowPublicTransportWaitingPassengers), value);
        }
        public bool ShowPublicTransportWaitingTime
        {
            get => (bool)GetValue(nameof(ShowPublicTransportWaitingTime));
            set => SetValue(nameof(ShowPublicTransportWaitingTime), value);
        }
        public bool ShowRoad
        {
            get => (bool)GetValue(nameof(ShowRoad));
            set => SetValue(nameof(ShowRoad), value);
        }
        public bool ShowRoadLength
        {
            get => (bool)GetValue(nameof(ShowRoadLength));
            set => SetValue(nameof(ShowRoadLength), value);
        }
        public bool ShowRoadUpkeep
        {
            get => (bool)GetValue(nameof(ShowRoadUpkeep));
            set => SetValue(nameof(ShowRoadUpkeep), value);
        }
        public bool ShowRoadCondition
        {
            get => (bool)GetValue(nameof(ShowRoadCondition));
            set => SetValue(nameof(ShowRoadCondition), value);
        }
        public bool ShowEducation
        {
            get => (bool)GetValue(nameof(ShowEducation));
            set => SetValue(nameof(ShowEducation), value);
        }
        public bool ShowEducationStudentCapacity
        {
            get => (bool)GetValue(nameof(ShowEducationStudentCapacity));
            set => SetValue(nameof(ShowEducationStudentCapacity), value);
        }
        public bool ShowGrowables
        {
            get => (bool)GetValue(nameof(ShowGrowables));
            set => SetValue(nameof(ShowGrowables), value);
        }
        public bool ShowLandValue
        {
            get => (bool)GetValue(nameof(ShowLandValue));
            set => SetValue(nameof(ShowLandValue), value);
        }
        public bool ShowGrowablesHousehold
        {
            get => (bool)GetValue(nameof(ShowGrowablesHousehold));
            set => SetValue(nameof(ShowGrowablesHousehold), value);
        }
        public bool ShowGrowablesHouseholdDetails
        {
            get => (bool)GetValue(nameof(ShowGrowablesHouseholdDetails));
            set => SetValue(nameof(ShowGrowablesHouseholdDetails), value);
        }
        public bool ShowGrowablesLevel
        {
            get => (bool)GetValue(nameof(ShowGrowablesLevel));
            set => SetValue(nameof(ShowGrowablesLevel), value);
        }
        public bool ShowGrowablesLevelDetails
        {
            get => (bool)GetValue(nameof(ShowGrowablesLevelDetails));
            set => SetValue(nameof(ShowGrowablesLevelDetails), value);
        }
        public bool ShowGrowablesRent
        {
            get => (bool)GetValue(nameof(ShowGrowablesRent));
            set => SetValue(nameof(ShowGrowablesRent), value);
        }
        public bool ShowGrowablesHouseholdWealth
        {
            get => (bool)GetValue(nameof(ShowGrowablesHouseholdWealth));
            set => SetValue(nameof(ShowGrowablesHouseholdWealth), value);
        }
        public bool ShowGrowablesBalance
        {
            get => (bool)GetValue(nameof(ShowGrowablesBalance));
            set => SetValue(nameof(ShowGrowablesBalance), value);
        }
        public bool ShowGrowablesZoneInfo
        {
            get => (bool)GetValue(nameof(ShowGrowablesZoneInfo));
            set => SetValue(nameof(ShowGrowablesZoneInfo), value);
        }
        public bool ShowVehicle
        {
            get => (bool)GetValue(nameof(ShowVehicle));
            set => SetValue(nameof(ShowVehicle), value);
        }
        public bool ShowVehicleState
        {
            get => (bool)GetValue(nameof(ShowVehicleState));
            set => SetValue(nameof(ShowVehicleState), value);
        }
        public bool ShowVehiclePostvan
        {
            get => (bool)GetValue(nameof(ShowVehiclePostvan));
            set => SetValue(nameof(ShowVehiclePostvan), value);
        }
        public bool ShowVehicleGarbageTruck
        {
            get => (bool)GetValue(nameof(ShowVehicleGarbageTruck));
            set => SetValue(nameof(ShowVehicleGarbageTruck), value);
        }
        public bool ShowVehiclePassengerDetails
        {
            get => (bool)GetValue(nameof(ShowVehiclePassengerDetails));
            set => SetValue(nameof(ShowVehiclePassengerDetails), value);
        }
    }

    public class ExtraAssetsImporterSettings : SettingsBackup
    {
        public bool Surfaces
        {
            get => (bool)GetValue(nameof(Surfaces));
            set => SetValue(nameof(Surfaces), value);
        }
        public bool Decals
        {
            get => (bool)GetValue(nameof(Decals));
            set => SetValue(nameof(Decals), value);
        }
        public bool NetLanes
        {
            get => (bool)GetValue(nameof(NetLanes));
            set => SetValue(nameof(NetLanes), value);
        }
        public int CompatibilityDropDown
        {
            get => (int)GetValue(nameof(CompatibilityDropDown));
            set => SetValue(nameof(CompatibilityDropDown), value);
        }

        //public string DatabasePath
        //{
        //    get => (string)GetValue(nameof(DatabasePath));
        //    set => SetValue(nameof(DatabasePath), value);
        //}
        public bool DeleteNotLoadedAssets
        {
            get => (bool)GetValue(nameof(DeleteNotLoadedAssets));
            set => SetValue(nameof(DeleteNotLoadedAssets), value);
        }
    }

    public class FindItSettings : SettingsBackup
    {
        public string DefaultViewStyle
        {
            get => (string)GetValue(nameof(DefaultViewStyle));
            set => SetValue(nameof(DefaultViewStyle), value);
        }
        public string DefaultAlignmentStyle
        {
            get => (string)GetValue(nameof(DefaultAlignmentStyle));
            set => SetValue(nameof(DefaultAlignmentStyle), value);
        }

        //public bool VehicleWarningShown
        //{
        //    get => (bool)GetValue(nameof(VehicleWarningShown));
        //    set => SetValue(nameof(VehicleWarningShown), value);
        //}
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
        public bool StrictSearch
        {
            get => (bool)GetValue(nameof(StrictSearch));
            set => SetValue(nameof(StrictSearch), value);
        }
        public bool NoAssetImage
        {
            get => (bool)GetValue(nameof(NoAssetImage));
            set => SetValue(nameof(NoAssetImage), value);
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
        public float RightRowSize
        {
            get => (float)GetValue(nameof(RightRowSize));
            set => SetValue(nameof(RightRowSize), value);
        }
        public float RightColumnSize
        {
            get => (float)GetValue(nameof(RightColumnSize));
            set => SetValue(nameof(RightColumnSize), value);
        }
    }

    public class FirstPersonCameraContinuedSettings : SettingsBackup
    {
        public int FOV
        {
            get => (int)GetValue(nameof(FOV));
            set => SetValue(nameof(FOV), value);
        }
        public float MovementSpeed
        {
            get => (float)GetValue(nameof(MovementSpeed));
            set => SetValue(nameof(MovementSpeed), value);
        }
        public float RunSpeed
        {
            get => (float)GetValue(nameof(RunSpeed));
            set => SetValue(nameof(RunSpeed), value);
        }
        public float CimHeight
        {
            get => (float)GetValue(nameof(CimHeight));
            set => SetValue(nameof(CimHeight), value);
        }
        public float TransitionSpeedFactor
        {
            get => (float)GetValue(nameof(TransitionSpeedFactor));
            set => SetValue(nameof(TransitionSpeedFactor), value);
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

    public class FPSLimiterSettings : SettingsBackup
    {
        public bool MenuLimitEnabled
        {
            get => (bool)GetValue(nameof(MenuLimitEnabled));
            set => SetValue(nameof(MenuLimitEnabled), value);
        }
        public int Menu
        {
            get => (int)GetValue(nameof(Menu));
            set => SetValue(nameof(Menu), value);
        }
        public bool InGameLimitEnabled
        {
            get => (bool)GetValue(nameof(InGameLimitEnabled));
            set => SetValue(nameof(InGameLimitEnabled), value);
        }
        public int InGame
        {
            get => (int)GetValue(nameof(InGame));
            set => SetValue(nameof(InGame), value);
        }
        public bool PausedLimitEnabled
        {
            get => (bool)GetValue(nameof(PausedLimitEnabled));
            set => SetValue(nameof(PausedLimitEnabled), value);
        }
        public int Paused
        {
            get => (int)GetValue(nameof(Paused));
            set => SetValue(nameof(Paused), value);
        }
    }

    public class HallOfFameSettings : SettingsBackup
    {
        public string CreatorID
        {
            get => (string)GetValue(nameof(CreatorID));
            set => SetValue(nameof(CreatorID), value);
        }
        public bool IsParadoxAccountID
        {
            get => (bool)GetValue(nameof(IsParadoxAccountID));
            set => SetValue(nameof(IsParadoxAccountID), value);
        }
        public string CreatorName
        {
            get => (string)GetValue(nameof(CreatorName));
            set => SetValue(nameof(CreatorName), value);
        }
        public int TrendingScreenshotWeight
        {
            get => (int)GetValue(nameof(TrendingScreenshotWeight));
            set => SetValue(nameof(TrendingScreenshotWeight), value);
        }
        public int RecentScreenshotWeight
        {
            get => (int)GetValue(nameof(RecentScreenshotWeight));
            set => SetValue(nameof(RecentScreenshotWeight), value);
        }
        public int ArcheologistScreenshotWeight
        {
            get => (int)GetValue(nameof(ArcheologistScreenshotWeight));
            set => SetValue(nameof(ArcheologistScreenshotWeight), value);
        }
        public int RandomScreenshotWeight
        {
            get => (int)GetValue(nameof(RandomScreenshotWeight));
            set => SetValue(nameof(RandomScreenshotWeight), value);
        }
        public int SupporterScreenshotWeight
        {
            get => (int)GetValue(nameof(SupporterScreenshotWeight));
            set => SetValue(nameof(SupporterScreenshotWeight), value);
        }
        public int ViewMaxAge
        {
            get => (int)GetValue(nameof(ViewMaxAge));
            set => SetValue(nameof(ViewMaxAge), value);
        }
        public string ScreenshotResolution
        {
            get => (string)GetValue(nameof(ScreenshotResolution));
            set => SetValue(nameof(ScreenshotResolution), value);
        }
        public bool CreateLocalScreenshot
        {
            get => (bool)GetValue(nameof(CreateLocalScreenshot));
            set => SetValue(nameof(CreateLocalScreenshot), value);
        }
        public bool DisableGlobalIllumination
        {
            get => (bool)GetValue(nameof(DisableGlobalIllumination));
            set => SetValue(nameof(DisableGlobalIllumination), value);
        }
        public string BaseUrl
        {
            get => (string)GetValue(nameof(BaseUrl));
            set => SetValue(nameof(BaseUrl), value);
        }
    }

    public class HardModeSettings : SettingsBackup
    {
        public int EconomyDifficulty
        {
            get => (int)GetValue(nameof(EconomyDifficulty));
            set => SetValue(nameof(EconomyDifficulty), value);
        }
        public bool BulldozeCostsMoney
        {
            get => (bool)GetValue(nameof(BulldozeCostsMoney));
            set => SetValue(nameof(BulldozeCostsMoney), value);
        }
        public bool BulldozeCausesDemolition
        {
            get => (bool)GetValue(nameof(BulldozeCausesDemolition));
            set => SetValue(nameof(BulldozeCausesDemolition), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class HideBuildingsNotificationSettings : SettingsBackup
    {
        public bool hideBuldingNotifications
        {
            get => (bool)GetValue(nameof(hideBuldingNotifications));
            set => SetValue(nameof(hideBuldingNotifications), value);
        }
    }

    public class HistoricalStartSettings : SettingsBackup
    {
        public bool UnlockBus
        {
            get => (bool)GetValue(nameof(UnlockBus));
            set => SetValue(nameof(UnlockBus), value);
        }
        public bool UnlockTrams
        {
            get => (bool)GetValue(nameof(UnlockTrams));
            set => SetValue(nameof(UnlockTrams), value);
        }
        public bool UnlockTrains
        {
            get => (bool)GetValue(nameof(UnlockTrains));
            set => SetValue(nameof(UnlockTrains), value);
        }
        public bool UnlockShips
        {
            get => (bool)GetValue(nameof(UnlockShips));
            set => SetValue(nameof(UnlockShips), value);
        }
        public bool UnlockFarming
        {
            get => (bool)GetValue(nameof(UnlockFarming));
            set => SetValue(nameof(UnlockFarming), value);
        }
        public bool UnlockMining
        {
            get => (bool)GetValue(nameof(UnlockMining));
            set => SetValue(nameof(UnlockMining), value);
        }
        public bool UnlockOil
        {
            get => (bool)GetValue(nameof(UnlockOil));
            set => SetValue(nameof(UnlockOil), value);
        }
        public bool UnlockBasicHighways
        {
            get => (bool)GetValue(nameof(UnlockBasicHighways));
            set => SetValue(nameof(UnlockBasicHighways), value);
        }
        public bool UnlockAllHighways
        {
            get => (bool)GetValue(nameof(UnlockAllHighways));
            set => SetValue(nameof(UnlockAllHighways), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class HomeOfHomelessSettings : SettingsBackup
    {
        public int uiShowScale
        {
            get => (int)GetValue(nameof(uiShowScale));
            set => SetValue(nameof(uiShowScale), value);
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
        public bool SuppressNullError
        {
            get => (bool)GetValue(nameof(SuppressNullError));
            set => SetValue(nameof(SuppressNullError), value);
        }
        public string LocaleType
        {
            get => (string)GetValue(nameof(LocaleType));
            set => SetValue(nameof(LocaleType), value);
        }
    }

    public class ImageOverlaySettings : SettingsBackup
    {
        public string SelectedOverlay
        {
            get => (string)GetValue(nameof(SelectedOverlay));
            set => SetValue(nameof(SelectedOverlay), value);
        }
        public bool ShowThroughTerrain
        {
            get => (bool)GetValue(nameof(ShowThroughTerrain));
            set => SetValue(nameof(ShowThroughTerrain), value);
        }
        public float Alpha
        {
            get => (float)GetValue(nameof(Alpha));
            set => SetValue(nameof(Alpha), value);
        }
        public float OverlaySize
        {
            get => (float)GetValue(nameof(OverlaySize));
            set => SetValue(nameof(OverlaySize), value);
        }
        public float OverlayPosX
        {
            get => (float)GetValue(nameof(OverlayPosX));
            set => SetValue(nameof(OverlayPosX), value);
        }
        public float OverlayPosZ
        {
            get => (float)GetValue(nameof(OverlayPosZ));
            set => SetValue(nameof(OverlayPosZ), value);
        }
        public float OverlayPosY
        {
            get => (float)GetValue(nameof(OverlayPosY));
            set => SetValue(nameof(OverlayPosY), value);
        }
        public float OverlayRotation
        {
            get => (float)GetValue(nameof(OverlayRotation));
            set => SetValue(nameof(OverlayRotation), value);
        }
    }

    public class IndustriesExtendedSettings : SettingsBackup
    {
        public float ExtractorProductionEfficiency
        {
            get => (float)GetValue(nameof(ExtractorProductionEfficiency));
            set => SetValue(nameof(ExtractorProductionEfficiency), value);
        }
        public float ExtractorCompanyExportMultiplier
        {
            get => (float)GetValue(nameof(ExtractorCompanyExportMultiplier));
            set => SetValue(nameof(ExtractorCompanyExportMultiplier), value);
        }
    }

    public class IndustryAutoTaxAdjusterSettings : SettingsBackup
    {
        public bool ActivateAI
        {
            get => (bool)GetValue(nameof(ActivateAI));
            set => SetValue(nameof(ActivateAI), value);
        }
        public int MinTax
        {
            get => (int)GetValue(nameof(MinTax));
            set => SetValue(nameof(MinTax), value);
        }
        public int MaxTax
        {
            get => (int)GetValue(nameof(MaxTax));
            set => SetValue(nameof(MaxTax), value);
        }
        public bool AllowGrain
        {
            get => (bool)GetValue(nameof(AllowGrain));
            set => SetValue(nameof(AllowGrain), value);
        }
        public bool AllowConvenienceFood
        {
            get => (bool)GetValue(nameof(AllowConvenienceFood));
            set => SetValue(nameof(AllowConvenienceFood), value);
        }
        public bool AllowFood
        {
            get => (bool)GetValue(nameof(AllowFood));
            set => SetValue(nameof(AllowFood), value);
        }
        public bool AllowVegetables
        {
            get => (bool)GetValue(nameof(AllowVegetables));
            set => SetValue(nameof(AllowVegetables), value);
        }
        public bool AllowMeals
        {
            get => (bool)GetValue(nameof(AllowMeals));
            set => SetValue(nameof(AllowMeals), value);
        }
        public bool AllowWood
        {
            get => (bool)GetValue(nameof(AllowWood));
            set => SetValue(nameof(AllowWood), value);
        }
        public bool AllowTimber
        {
            get => (bool)GetValue(nameof(AllowTimber));
            set => SetValue(nameof(AllowTimber), value);
        }
        public bool AllowPaper
        {
            get => (bool)GetValue(nameof(AllowPaper));
            set => SetValue(nameof(AllowPaper), value);
        }
        public bool AllowFurniture
        {
            get => (bool)GetValue(nameof(AllowFurniture));
            set => SetValue(nameof(AllowFurniture), value);
        }
        public bool AllowVehicles
        {
            get => (bool)GetValue(nameof(AllowVehicles));
            set => SetValue(nameof(AllowVehicles), value);
        }
        public bool AllowLodging
        {
            get => (bool)GetValue(nameof(AllowLodging));
            set => SetValue(nameof(AllowLodging), value);
        }
        public bool AllowOil
        {
            get => (bool)GetValue(nameof(AllowOil));
            set => SetValue(nameof(AllowOil), value);
        }
        public bool AllowPetrochemicals
        {
            get => (bool)GetValue(nameof(AllowPetrochemicals));
            set => SetValue(nameof(AllowPetrochemicals), value);
        }
        public bool AllowOre
        {
            get => (bool)GetValue(nameof(AllowOre));
            set => SetValue(nameof(AllowOre), value);
        }
        public bool AllowPlastics
        {
            get => (bool)GetValue(nameof(AllowPlastics));
            set => SetValue(nameof(AllowPlastics), value);
        }
        public bool AllowMetals
        {
            get => (bool)GetValue(nameof(AllowMetals));
            set => SetValue(nameof(AllowMetals), value);
        }
        public bool AllowElectronics
        {
            get => (bool)GetValue(nameof(AllowElectronics));
            set => SetValue(nameof(AllowElectronics), value);
        }
        public bool AllowSoftware
        {
            get => (bool)GetValue(nameof(AllowSoftware));
            set => SetValue(nameof(AllowSoftware), value);
        }
        public bool AllowCoal
        {
            get => (bool)GetValue(nameof(AllowCoal));
            set => SetValue(nameof(AllowCoal), value);
        }
        public bool AllowStone
        {
            get => (bool)GetValue(nameof(AllowStone));
            set => SetValue(nameof(AllowStone), value);
        }
        public bool AllowLivestock
        {
            get => (bool)GetValue(nameof(AllowLivestock));
            set => SetValue(nameof(AllowLivestock), value);
        }
        public bool AllowCotton
        {
            get => (bool)GetValue(nameof(AllowCotton));
            set => SetValue(nameof(AllowCotton), value);
        }
        public bool AllowSteel
        {
            get => (bool)GetValue(nameof(AllowSteel));
            set => SetValue(nameof(AllowSteel), value);
        }
        public bool AllowMinerals
        {
            get => (bool)GetValue(nameof(AllowMinerals));
            set => SetValue(nameof(AllowMinerals), value);
        }
        public bool AllowConcrete
        {
            get => (bool)GetValue(nameof(AllowConcrete));
            set => SetValue(nameof(AllowConcrete), value);
        }
        public bool AllowChemicals
        {
            get => (bool)GetValue(nameof(AllowChemicals));
            set => SetValue(nameof(AllowChemicals), value);
        }
        public bool AllowPharmaceuticals
        {
            get => (bool)GetValue(nameof(AllowPharmaceuticals));
            set => SetValue(nameof(AllowPharmaceuticals), value);
        }
        public bool AllowBeverages
        {
            get => (bool)GetValue(nameof(AllowBeverages));
            set => SetValue(nameof(AllowBeverages), value);
        }
        public bool AllowTextiles
        {
            get => (bool)GetValue(nameof(AllowTextiles));
            set => SetValue(nameof(AllowTextiles), value);
        }
        public bool AllowTelecom
        {
            get => (bool)GetValue(nameof(AllowTelecom));
            set => SetValue(nameof(AllowTelecom), value);
        }
        public bool AllowFinancial
        {
            get => (bool)GetValue(nameof(AllowFinancial));
            set => SetValue(nameof(AllowFinancial), value);
        }
        public bool AllowMedia
        {
            get => (bool)GetValue(nameof(AllowMedia));
            set => SetValue(nameof(AllowMedia), value);
        }
        public bool AllowEntertainment
        {
            get => (bool)GetValue(nameof(AllowEntertainment));
            set => SetValue(nameof(AllowEntertainment), value);
        }
        public bool AllowRecreation
        {
            get => (bool)GetValue(nameof(AllowRecreation));
            set => SetValue(nameof(AllowRecreation), value);
        }
    }

    //public class InfoLoomTwoSettings : SettingsBackup
    //{
    //    public int CommercialIndexSorting
    //    {
    //        get => (int)GetValue(nameof(CommercialIndexSorting));
    //        set => SetValue(nameof(CommercialIndexSorting), value);
    //    }
    //    public int CommercialNameSorting
    //    {
    //        get => (int)GetValue(nameof(CommercialNameSorting));
    //        set => SetValue(nameof(CommercialNameSorting), value);
    //    }
    //    public int CommercialServiceUsageSorting
    //    {
    //        get => (int)GetValue(nameof(CommercialServiceUsageSorting));
    //        set => SetValue(nameof(CommercialServiceUsageSorting), value);
    //    }
    //    public int CommercialEmployeesSorting
    //    {
    //        get => (int)GetValue(nameof(CommercialEmployeesSorting));
    //        set => SetValue(nameof(CommercialEmployeesSorting), value);
    //    }
    //    public int CommercialEfficiencySorting
    //    {
    //        get => (int)GetValue(nameof(CommercialEfficiencySorting));
    //        set => SetValue(nameof(CommercialEfficiencySorting), value);
    //    }
    //    public int CommercialProfitabilitySorting
    //    {
    //        get => (int)GetValue(nameof(CommercialProfitabilitySorting));
    //        set => SetValue(nameof(CommercialProfitabilitySorting), value);
    //    }
    //    public int IndustrialIndexSorting
    //    {
    //        get => (int)GetValue(nameof(IndustrialIndexSorting));
    //        set => SetValue(nameof(IndustrialIndexSorting), value);
    //    }
    //    public int IndustrialNameSorting
    //    {
    //        get => (int)GetValue(nameof(IndustrialNameSorting));
    //        set => SetValue(nameof(IndustrialNameSorting), value);
    //    }
    //    public int IndustrialEmployeesSorting
    //    {
    //        get => (int)GetValue(nameof(IndustrialEmployeesSorting));
    //        set => SetValue(nameof(IndustrialEmployeesSorting), value);
    //    }
    //    public int IndustrialEfficiencySorting
    //    {
    //        get => (int)GetValue(nameof(IndustrialEfficiencySorting));
    //        set => SetValue(nameof(IndustrialEfficiencySorting), value);
    //    }
    //    public int IndustrialProfitabilitySorting
    //    {
    //        get => (int)GetValue(nameof(IndustrialProfitabilitySorting));
    //        set => SetValue(nameof(IndustrialProfitabilitySorting), value);
    //    }
    //    public int ResourceName
    //    {
    //        get => (int)GetValue(nameof(ResourceName));
    //        set => SetValue(nameof(ResourceName), value);
    //    }
    //    public int BuyCost
    //    {
    //        get => (int)GetValue(nameof(BuyCost));
    //        set => SetValue(nameof(BuyCost), value);
    //    }
    //    public int SellCost
    //    {
    //        get => (int)GetValue(nameof(SellCost));
    //        set => SetValue(nameof(SellCost), value);
    //    }
    //    public int Profit
    //    {
    //        get => (int)GetValue(nameof(Profit));
    //        set => SetValue(nameof(Profit), value);
    //    }
    //    public int ProfitMargin
    //    {
    //        get => (int)GetValue(nameof(ProfitMargin));
    //        set => SetValue(nameof(ProfitMargin), value);
    //    }
    //    public int ImportAmount
    //    {
    //        get => (int)GetValue(nameof(ImportAmount));
    //        set => SetValue(nameof(ImportAmount), value);
    //    }
    //    public int ExportAmount
    //    {
    //        get => (int)GetValue(nameof(ExportAmount));
    //        set => SetValue(nameof(ExportAmount), value);
    //    }
    //}

    public class LazyPedestriansSettings : SettingsBackup
    {
        public string DropdownMultiplier
        {
            get => (string)GetValue(nameof(DropdownMultiplier));
            set => SetValue(nameof(DropdownMultiplier), value);
        }
    }

    //public class LuminaSettings : SettingsBackup
    //{
    //    public bool ReloadAllPackagesOnRestart
    //    {
    //        get => (bool)GetValue(nameof(ReloadAllPackagesOnRestart));
    //        set => SetValue(nameof(ReloadAllPackagesOnRestart), value);
    //    }
    //    public bool SaveAutomatically
    //    {
    //        get => (bool)GetValue(nameof(SaveAutomatically));
    //        set => SetValue(nameof(SaveAutomatically), value);
    //    }
    //    public bool UseTimeOfDaySlider
    //    {
    //        get => (bool)GetValue(nameof(UseTimeOfDaySlider));
    //        set => SetValue(nameof(UseTimeOfDaySlider), value);
    //    }
    //}

    public class MapExtSettings : SettingsBackup
    {
        public int PatchModeChoice
        {
            get => (int)GetValue(nameof(PatchModeChoice));
            set => SetValue(nameof(PatchModeChoice), value);
        }
        public bool NoDogs
        {
            get => (bool)GetValue(nameof(NoDogs));
            set => SetValue(nameof(NoDogs), value);
        }
        public bool NoThroughTraffic
        {
            get => (bool)GetValue(nameof(NoThroughTraffic));
            set => SetValue(nameof(NoThroughTraffic), value);
        }
        //public bool LandValueRemake
        //{
        //    get => (bool)GetValue(nameof(LandValueRemake));
        //    set => SetValue(nameof(LandValueRemake), value);
        //}
    }

    public class MoveItSettings : SettingsBackup
    {
        public bool InvertRotation
        {
            get => (bool)GetValue(nameof(InvertRotation));
            set => SetValue(nameof(InvertRotation), value);
        }
        public bool ExtraDebugLogging
        {
            get => (bool)GetValue(nameof(ExtraDebugLogging));
            set => SetValue(nameof(ExtraDebugLogging), value);
        }
        public bool ShowDebugPanel
        {
            get => (bool)GetValue(nameof(ShowDebugPanel));
            set => SetValue(nameof(ShowDebugPanel), value);
        }
        public bool HideMoveItIcon
        {
            get => (bool)GetValue(nameof(HideMoveItIcon));
            set => SetValue(nameof(HideMoveItIcon), value);
        }
        public bool ShowDebugLines
        {
            get => (bool)GetValue(nameof(ShowDebugLines));
            set => SetValue(nameof(ShowDebugLines), value);
        }
        public bool HasShownMConflictPanel
        {
            get => (bool)GetValue(nameof(HasShownMConflictPanel));
            set => SetValue(nameof(HasShownMConflictPanel), value);
        }
    }

    public class NavigationViewSettings : SettingsBackup
    {
        public int RefreshFrequency
        {
            get => (int)GetValue(nameof(RefreshFrequency));
            set => SetValue(nameof(RefreshFrequency), value);
        }
    }

    public class NoDeadTreesSettings : SettingsBackup
    {
        public int DeadTreeReplacementTypeDropdown
        {
            get => (int)GetValue(nameof(DeadTreeReplacementTypeDropdown));
            set => SetValue(nameof(DeadTreeReplacementTypeDropdown), value);
        }
    }

    public class NoPollutionSettings : SettingsBackup
    {
        public bool NoisePollutionToggle
        {
            get => (bool)GetValue(nameof(NoisePollutionToggle));
            set => SetValue(nameof(NoisePollutionToggle), value);
        }
        public float NoisePollutionSlider
        {
            get => (float)GetValue(nameof(NoisePollutionSlider));
            set => SetValue(nameof(NoisePollutionSlider), value);
        }
        public bool GroundPollutionToggle
        {
            get => (bool)GetValue(nameof(GroundPollutionToggle));
            set => SetValue(nameof(GroundPollutionToggle), value);
        }
        public float GroundPollutionSlider
        {
            get => (float)GetValue(nameof(GroundPollutionSlider));
            set => SetValue(nameof(GroundPollutionSlider), value);
        }
        public bool AirPollutionToggle
        {
            get => (bool)GetValue(nameof(AirPollutionToggle));
            set => SetValue(nameof(AirPollutionToggle), value);
        }
        public float AirPollutionSlider
        {
            get => (float)GetValue(nameof(AirPollutionSlider));
            set => SetValue(nameof(AirPollutionSlider), value);
        }
        public bool NetPollutionToggle
        {
            get => (bool)GetValue(nameof(NetPollutionToggle));
            set => SetValue(nameof(NetPollutionToggle), value);
        }
        public float NetPollutionSlider1
        {
            get => (float)GetValue(nameof(NetPollutionSlider1));
            set => SetValue(nameof(NetPollutionSlider1), value);
        }
        public float NetPollutionSlider2
        {
            get => (float)GetValue(nameof(NetPollutionSlider2));
            set => SetValue(nameof(NetPollutionSlider2), value);
        }
        public float NetPollutionAccumulationSlider1
        {
            get => (float)GetValue(nameof(NetPollutionAccumulationSlider1));
            set => SetValue(nameof(NetPollutionAccumulationSlider1), value);
        }
        public float NetPollutionAccumulationSlider2
        {
            get => (float)GetValue(nameof(NetPollutionAccumulationSlider2));
            set => SetValue(nameof(NetPollutionAccumulationSlider2), value);
        }
        public int GroundWaterPollutionReductionRate
        {
            get => (int)GetValue(nameof(GroundWaterPollutionReductionRate));
            set => SetValue(nameof(GroundWaterPollutionReductionRate), value);
        }
        public bool WaterPollutionDecayInstantToggle
        {
            get => (bool)GetValue(nameof(WaterPollutionDecayInstantToggle));
            set => SetValue(nameof(WaterPollutionDecayInstantToggle), value);
        }
        public int WaterPollutionDecayRateSlider
        {
            get => (int)GetValue(nameof(WaterPollutionDecayRateSlider));
            set => SetValue(nameof(WaterPollutionDecayRateSlider), value);
        }
        public float GroundMultiplier
        {
            get => (float)GetValue(nameof(GroundMultiplier));
            set => SetValue(nameof(GroundMultiplier), value);
        }
        public float AirMultiplier
        {
            get => (float)GetValue(nameof(AirMultiplier));
            set => SetValue(nameof(AirMultiplier), value);
        }
        public float NoiseMultiplier
        {
            get => (float)GetValue(nameof(NoiseMultiplier));
            set => SetValue(nameof(NoiseMultiplier), value);
        }
        public float NetAirMultiplier
        {
            get => (float)GetValue(nameof(NetAirMultiplier));
            set => SetValue(nameof(NetAirMultiplier), value);
        }
        public float NetNoiseMultiplier
        {
            get => (float)GetValue(nameof(NetNoiseMultiplier));
            set => SetValue(nameof(NetNoiseMultiplier), value);
        }
        public float PlantAirMultiplier
        {
            get => (float)GetValue(nameof(PlantAirMultiplier));
            set => SetValue(nameof(PlantAirMultiplier), value);
        }
        public float PlantGroundMultiplier
        {
            get => (float)GetValue(nameof(PlantGroundMultiplier));
            set => SetValue(nameof(PlantGroundMultiplier), value);
        }
        public float FertilityGroundMultiplier
        {
            get => (float)GetValue(nameof(FertilityGroundMultiplier));
            set => SetValue(nameof(FertilityGroundMultiplier), value);
        }
        public float AbandonedNoisePollutionMultiplier
        {
            get => (float)GetValue(nameof(AbandonedNoisePollutionMultiplier));
            set => SetValue(nameof(AbandonedNoisePollutionMultiplier), value);
        }
        public float AirRadius
        {
            get => (float)GetValue(nameof(AirRadius));
            set => SetValue(nameof(AirRadius), value);
        }
        public float GroundRadius
        {
            get => (float)GetValue(nameof(GroundRadius));
            set => SetValue(nameof(GroundRadius), value);
        }
        public float NoiseRadius
        {
            get => (float)GetValue(nameof(NoiseRadius));
            set => SetValue(nameof(NoiseRadius), value);
        }
        public float NetNoiseRadius
        {
            get => (float)GetValue(nameof(NetNoiseRadius));
            set => SetValue(nameof(NetNoiseRadius), value);
        }
        public float AirFade
        {
            get => (float)GetValue(nameof(AirFade));
            set => SetValue(nameof(AirFade), value);
        }
        public float GroundFade
        {
            get => (float)GetValue(nameof(GroundFade));
            set => SetValue(nameof(GroundFade), value);
        }
        public float PlantFade
        {
            get => (float)GetValue(nameof(PlantFade));
            set => SetValue(nameof(PlantFade), value);
        }
        public float AirPollutionNotificationLimit
        {
            get => (float)GetValue(nameof(AirPollutionNotificationLimit));
            set => SetValue(nameof(AirPollutionNotificationLimit), value);
        }
        public float NoisePollutionNotificationLimit
        {
            get => (float)GetValue(nameof(NoisePollutionNotificationLimit));
            set => SetValue(nameof(NoisePollutionNotificationLimit), value);
        }
        public float GroundPollutionNotificationLimit
        {
            get => (float)GetValue(nameof(GroundPollutionNotificationLimit));
            set => SetValue(nameof(GroundPollutionNotificationLimit), value);
        }
        public float WindAdvectionSpeed
        {
            get => (float)GetValue(nameof(WindAdvectionSpeed));
            set => SetValue(nameof(WindAdvectionSpeed), value);
        }
        public float DistanceExponent
        {
            get => (float)GetValue(nameof(DistanceExponent));
            set => SetValue(nameof(DistanceExponent), value);
        }
        public float HomelessNoisePollution
        {
            get => (float)GetValue(nameof(HomelessNoisePollution));
            set => SetValue(nameof(HomelessNoisePollution), value);
        }
        public float GroundPollutionLandValueDivisor
        {
            get => (float)GetValue(nameof(GroundPollutionLandValueDivisor));
            set => SetValue(nameof(GroundPollutionLandValueDivisor), value);
        }
    }

    public class NoTeleportingSettings : SettingsBackup
    {
        public int ProcessorStartingResourceAmount
        {
            get => (int)GetValue(nameof(ProcessorStartingResourceAmount));
            set => SetValue(nameof(ProcessorStartingResourceAmount), value);
        }
        public int ProcessorStartingOutputResourceAmount
        {
            get => (int)GetValue(nameof(ProcessorStartingOutputResourceAmount));
            set => SetValue(nameof(ProcessorStartingOutputResourceAmount), value);
        }
        public int ServiceStartingResourceAmount
        {
            get => (int)GetValue(nameof(ServiceStartingResourceAmount));
            set => SetValue(nameof(ServiceStartingResourceAmount), value);
        }
        public int ServiceBuildingStartingResourcePercentage
        {
            get => (int)GetValue(nameof(ServiceBuildingStartingResourcePercentage));
            set => SetValue(nameof(ServiceBuildingStartingResourcePercentage), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class NoVehicleDespawnSettings : SettingsBackup
    {
        public int despawnBehavior
        {
            get => (int)GetValue(nameof(despawnBehavior));
            set => SetValue(nameof(despawnBehavior), value);
        }
        public bool highlightStuckObjects
        {
            get => (bool)GetValue(nameof(highlightStuckObjects));
            set => SetValue(nameof(highlightStuckObjects), value);
        }
        public int deadlockLingerFrames
        {
            get => (int)GetValue(nameof(deadlockLingerFrames));
            set => SetValue(nameof(deadlockLingerFrames), value);
        }
        public int deadlockSearchDepth
        {
            get => (int)GetValue(nameof(deadlockSearchDepth));
            set => SetValue(nameof(deadlockSearchDepth), value);
        }
        public int maxStuckObjectRemovalCount
        {
            get => (int)GetValue(nameof(maxStuckObjectRemovalCount));
            set => SetValue(nameof(maxStuckObjectRemovalCount), value);
        }
        public int maxStuckObjectSpeed
        {
            get => (int)GetValue(nameof(maxStuckObjectSpeed));
            set => SetValue(nameof(maxStuckObjectSpeed), value);
        }
        public bool despawnAll
        {
            get => (bool)GetValue(nameof(despawnAll));
            set => SetValue(nameof(despawnAll), value);
        }
        public bool despawnCommercialVehicles
        {
            get => (bool)GetValue(nameof(despawnCommercialVehicles));
            set => SetValue(nameof(despawnCommercialVehicles), value);
        }
        public bool despawnPedestrians
        {
            get => (bool)GetValue(nameof(despawnPedestrians));
            set => SetValue(nameof(despawnPedestrians), value);
        }
        public bool despawnPersonalVehicles
        {
            get => (bool)GetValue(nameof(despawnPersonalVehicles));
            set => SetValue(nameof(despawnPersonalVehicles), value);
        }
        public bool despawnPublicTransit
        {
            get => (bool)GetValue(nameof(despawnPublicTransit));
            set => SetValue(nameof(despawnPublicTransit), value);
        }
        public bool despawnServiceVehicles
        {
            get => (bool)GetValue(nameof(despawnServiceVehicles));
            set => SetValue(nameof(despawnServiceVehicles), value);
        }
        public bool despawnTaxis
        {
            get => (bool)GetValue(nameof(despawnTaxis));
            set => SetValue(nameof(despawnTaxis), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class NoWaterElectricitySettings : SettingsBackup
    {
        public bool buildingNeedElectricity
        {
            get => (bool)GetValue(nameof(buildingNeedElectricity));
            set => SetValue(nameof(buildingNeedElectricity), value);
        }
        public bool buildingNeedWater
        {
            get => (bool)GetValue(nameof(buildingNeedWater));
            set => SetValue(nameof(buildingNeedWater), value);
        }
    }

    public class OSMExportSettings : SettingsBackup
    {
        public int NorthOverride
        {
            get => (int)GetValue(nameof(NorthOverride));
            set => SetValue(nameof(NorthOverride), value);
        }
        public bool EnableMotorways
        {
            get => (bool)GetValue(nameof(EnableMotorways));
            set => SetValue(nameof(EnableMotorways), value);
        }

        //public bool EnableAccurateWays
        //{
        //    get => (bool)GetValue(nameof(EnableAccurateWays));
        //    set => SetValue(nameof(EnableAccurateWays), value);
        //}
        public bool EnableAccurateTrams
        {
            get => (bool)GetValue(nameof(EnableAccurateTrams));
            set => SetValue(nameof(EnableAccurateTrams), value);
        }
        public int WaterResolution
        {
            get => (int)GetValue(nameof(WaterResolution));
            set => SetValue(nameof(WaterResolution), value);
        }

        //public string FileName
        //{
        //    get => (string)GetValue(nameof(FileName));
        //    set => SetValue(nameof(FileName), value);
        //}
        public int ZoomLevel
        {
            get => (int)GetValue(nameof(ZoomLevel));
            set => SetValue(nameof(ZoomLevel), value);
        }
        public int Ruleset
        {
            get => (int)GetValue(nameof(Ruleset));
            set => SetValue(nameof(Ruleset), value);
        }
        public bool EnableContours
        {
            get => (bool)GetValue(nameof(EnableContours));
            set => SetValue(nameof(EnableContours), value);
        }
        public bool EnableTrees
        {
            get => (bool)GetValue(nameof(EnableTrees));
            set => SetValue(nameof(EnableTrees), value);
        }
        public bool EnableNonstandardTransit
        {
            get => (bool)GetValue(nameof(EnableNonstandardTransit));
            set => SetValue(nameof(EnableNonstandardTransit), value);
        }
        public bool EnableNonstandardTaxi
        {
            get => (bool)GetValue(nameof(EnableNonstandardTaxi));
            set => SetValue(nameof(EnableNonstandardTaxi), value);
        }
        public bool EnableNonstandardBus
        {
            get => (bool)GetValue(nameof(EnableNonstandardBus));
            set => SetValue(nameof(EnableNonstandardBus), value);
        }
        public bool EnableNonstandardTram
        {
            get => (bool)GetValue(nameof(EnableNonstandardTram));
            set => SetValue(nameof(EnableNonstandardTram), value);
        }
        public bool EnableNonstandardTrain
        {
            get => (bool)GetValue(nameof(EnableNonstandardTrain));
            set => SetValue(nameof(EnableNonstandardTrain), value);
        }
        public bool EnableNonstandardSubway
        {
            get => (bool)GetValue(nameof(EnableNonstandardSubway));
            set => SetValue(nameof(EnableNonstandardSubway), value);
        }
        //public bool EnableNonstandardShip
        //{
        //    get => (bool)GetValue(nameof(EnableNonstandardShip));
        //    set => SetValue(nameof(EnableNonstandardShip), value);
        //}
        //public bool EnableNonstandardAirplane
        //{
        //    get => (bool)GetValue(nameof(EnableNonstandardAirplane));
        //    set => SetValue(nameof(EnableNonstandardAirplane), value);
        //}
    }

    public class PathfindingCustomizerSettings : SettingsBackup
    {
        public int UnsafeTurningSlider
        {
            get => (int)GetValue(nameof(UnsafeTurningSlider));
            set => SetValue(nameof(UnsafeTurningSlider), value);
        }
        public int UnsafeUTurnSlider
        {
            get => (int)GetValue(nameof(UnsafeUTurnSlider));
            set => SetValue(nameof(UnsafeUTurnSlider), value);
        }
        public int ForbiddenSlider
        {
            get => (int)GetValue(nameof(ForbiddenSlider));
            set => SetValue(nameof(ForbiddenSlider), value);
        }
        public int DrivingSlider
        {
            get => (int)GetValue(nameof(DrivingSlider));
            set => SetValue(nameof(DrivingSlider), value);
        }
        public int ParkingSlider
        {
            get => (int)GetValue(nameof(ParkingSlider));
            set => SetValue(nameof(ParkingSlider), value);
        }
        public int TurningSlider
        {
            get => (int)GetValue(nameof(TurningSlider));
            set => SetValue(nameof(TurningSlider), value);
        }
        public int LaneSwitchSlider
        {
            get => (int)GetValue(nameof(LaneSwitchSlider));
            set => SetValue(nameof(LaneSwitchSlider), value);
        }
        public int TraficSpawnSlider
        {
            get => (int)GetValue(nameof(TraficSpawnSlider));
            set => SetValue(nameof(TraficSpawnSlider), value);
        }
        public int UnsafeCrossingSlider
        {
            get => (int)GetValue(nameof(UnsafeCrossingSlider));
            set => SetValue(nameof(UnsafeCrossingSlider), value);
        }
        public int CrossingSlider
        {
            get => (int)GetValue(nameof(CrossingSlider));
            set => SetValue(nameof(CrossingSlider), value);
        }
        public int SpawnSlider
        {
            get => (int)GetValue(nameof(SpawnSlider));
            set => SetValue(nameof(SpawnSlider), value);
        }
        public int WalkingSlider
        {
            get => (int)GetValue(nameof(WalkingSlider));
            set => SetValue(nameof(WalkingSlider), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class ParkingMonitorSettings : SettingsBackup
    {
        public int parkingRowCount
        {
            get => (int)GetValue(nameof(parkingRowCount));
            set => SetValue(nameof(parkingRowCount), value);
        }
        public int defaultRowsPerDistrict
        {
            get => (int)GetValue(nameof(defaultRowsPerDistrict));
            set => SetValue(nameof(defaultRowsPerDistrict), value);
        }
        public int districtSortOrder
        {
            get => (int)GetValue(nameof(districtSortOrder));
            set => SetValue(nameof(districtSortOrder), value);
        }
        public int initialState
        {
            get => (int)GetValue(nameof(initialState));
            set => SetValue(nameof(initialState), value);
        }
    }

    public class ParkingPricingSettings : SettingsBackup
    {
        public bool EnableForLot
        {
            get => (bool)GetValue(nameof(EnableForLot));
            set => SetValue(nameof(EnableForLot), value);
        }
        public int StandardPriceLot
        {
            get => (int)GetValue(nameof(StandardPriceLot));
            set => SetValue(nameof(StandardPriceLot), value);
        }
        public int MaxPriceIncreaseLot
        {
            get => (int)GetValue(nameof(MaxPriceIncreaseLot));
            set => SetValue(nameof(MaxPriceIncreaseLot), value);
        }
        public int MaxPriceDiscountLot
        {
            get => (int)GetValue(nameof(MaxPriceDiscountLot));
            set => SetValue(nameof(MaxPriceDiscountLot), value);
        }
        public bool EnableForStreet
        {
            get => (bool)GetValue(nameof(EnableForStreet));
            set => SetValue(nameof(EnableForStreet), value);
        }
        public int StandardPriceStreet
        {
            get => (int)GetValue(nameof(StandardPriceStreet));
            set => SetValue(nameof(StandardPriceStreet), value);
        }
        public int MaxPriceIncreaseStreet
        {
            get => (int)GetValue(nameof(MaxPriceIncreaseStreet));
            set => SetValue(nameof(MaxPriceIncreaseStreet), value);
        }
        public int MaxPriceDiscountStreet
        {
            get => (int)GetValue(nameof(MaxPriceDiscountStreet));
            set => SetValue(nameof(MaxPriceDiscountStreet), value);
        }
        public int UpdateFreq
        {
            get => (int)GetValue(nameof(UpdateFreq));
            set => SetValue(nameof(UpdateFreq), value);
        }
    }

    public class PlopTheGrowablesSettings : SettingsBackup
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

    public class PrefabAssetFixesSettings : SettingsBackup
    {
        public bool PrisonVan
        {
            get => (bool)GetValue(nameof(PrisonVan));
            set => SetValue(nameof(PrisonVan), value);
        }
        public bool Prison
        {
            get => (bool)GetValue(nameof(Prison));
            set => SetValue(nameof(Prison), value);
        }

        //public bool Storage
        //{
        //    get => (bool)GetValue(nameof(Storage));
        //    set => SetValue(nameof(Storage), value);
        //}
        public bool Recycling
        {
            get => (bool)GetValue(nameof(Recycling));
            set => SetValue(nameof(Recycling), value);
        }
        public bool Hospital
        {
            get => (bool)GetValue(nameof(Hospital));
            set => SetValue(nameof(Hospital), value);
        }
        public bool USSWHospital
        {
            get => (bool)GetValue(nameof(USSWHospital));
            set => SetValue(nameof(USSWHospital), value);
        }
        public bool HoveringPoles
        {
            get => (bool)GetValue(nameof(HoveringPoles));
            set => SetValue(nameof(HoveringPoles), value);
        }
        public bool SolarParking
        {
            get => (bool)GetValue(nameof(SolarParking));
            set => SetValue(nameof(SolarParking), value);
        }
    }

    public class RealisticParkingSettings : SettingsBackup
    {
        public bool EnableInducedDemand
        {
            get => (bool)GetValue(nameof(EnableInducedDemand));
            set => SetValue(nameof(EnableInducedDemand), value);
        }
        public int InducedDemandInitialTolerance
        {
            get => (int)GetValue(nameof(InducedDemandInitialTolerance));
            set => SetValue(nameof(InducedDemandInitialTolerance), value);
        }
        public float InducedDemandQueueSizePerSpot
        {
            get => (float)GetValue(nameof(InducedDemandQueueSizePerSpot));
            set => SetValue(nameof(InducedDemandQueueSizePerSpot), value);
        }
        public int InducedDemandCooldown
        {
            get => (int)GetValue(nameof(InducedDemandCooldown));
            set => SetValue(nameof(InducedDemandCooldown), value);
        }
        public bool EnableRerouteDistance
        {
            get => (bool)GetValue(nameof(EnableRerouteDistance));
            set => SetValue(nameof(EnableRerouteDistance), value);
        }
        public int RerouteDistance
        {
            get => (int)GetValue(nameof(RerouteDistance));
            set => SetValue(nameof(RerouteDistance), value);
        }
        public bool EnableParkingMins
        {
            get => (bool)GetValue(nameof(EnableParkingMins));
            set => SetValue(nameof(EnableParkingMins), value);
        }
        public float GarageSpotsPerResProp
        {
            get => (float)GetValue(nameof(GarageSpotsPerResProp));
            set => SetValue(nameof(GarageSpotsPerResProp), value);
        }
        public float GarageSpotsPerWorker
        {
            get => (float)GetValue(nameof(GarageSpotsPerWorker));
            set => SetValue(nameof(GarageSpotsPerWorker), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class RealisticTripsSettings : SettingsBackup
    {
        public int settings_choice
        {
            get => (int)GetValue(nameof(settings_choice));
            set => SetValue(nameof(settings_choice), value);
        }
        public float average_commute
        {
            get => (float)GetValue(nameof(average_commute));
            set => SetValue(nameof(average_commute), value);
        }
        public float commute_top10per
        {
            get => (float)GetValue(nameof(commute_top10per));
            set => SetValue(nameof(commute_top10per), value);
        }
        public int evening_share
        {
            get => (int)GetValue(nameof(evening_share));
            set => SetValue(nameof(evening_share), value);
        }
        public int nonday_office_share
        {
            get => (int)GetValue(nameof(nonday_office_share));
            set => SetValue(nameof(nonday_office_share), value);
        }
        public int nonday_commercial_share
        {
            get => (int)GetValue(nameof(nonday_commercial_share));
            set => SetValue(nameof(nonday_commercial_share), value);
        }
        public int nonday_industry_share
        {
            get => (int)GetValue(nameof(nonday_industry_share));
            set => SetValue(nameof(nonday_industry_share), value);
        }
        public int nonday_cityservices_share
        {
            get => (int)GetValue(nameof(nonday_cityservices_share));
            set => SetValue(nameof(nonday_cityservices_share), value);
        }
        public int night_share
        {
            get => (int)GetValue(nameof(night_share));
            set => SetValue(nameof(night_share), value);
        }
        public float delay_factor
        {
            get => (float)GetValue(nameof(delay_factor));
            set => SetValue(nameof(delay_factor), value);
        }
        public bool peak_spread
        {
            get => (bool)GetValue(nameof(peak_spread));
            set => SetValue(nameof(peak_spread), value);
        }
        public int lunch_break_percentage
        {
            get => (int)GetValue(nameof(lunch_break_percentage));
            set => SetValue(nameof(lunch_break_percentage), value);
        }
        public int remote_percentage
        {
            get => (int)GetValue(nameof(remote_percentage));
            set => SetValue(nameof(remote_percentage), value);
        }
        public bool disable_early_shop_leisure
        {
            get => (bool)GetValue(nameof(disable_early_shop_leisure));
            set => SetValue(nameof(disable_early_shop_leisure), value);
        }
        public bool use_vanilla_timeoff
        {
            get => (bool)GetValue(nameof(use_vanilla_timeoff));
            set => SetValue(nameof(use_vanilla_timeoff), value);
        }
        public float holidays_per_year
        {
            get => (float)GetValue(nameof(holidays_per_year));
            set => SetValue(nameof(holidays_per_year), value);
        }
        public float vacation_per_year
        {
            get => (float)GetValue(nameof(vacation_per_year));
            set => SetValue(nameof(vacation_per_year), value);
        }
        public float meals_weekday
        {
            get => (float)GetValue(nameof(meals_weekday));
            set => SetValue(nameof(meals_weekday), value);
        }
        public float meals_avgday
        {
            get => (float)GetValue(nameof(meals_avgday));
            set => SetValue(nameof(meals_avgday), value);
        }
        public float meals_saturday
        {
            get => (float)GetValue(nameof(meals_saturday));
            set => SetValue(nameof(meals_saturday), value);
        }
        public float meals_sunday
        {
            get => (float)GetValue(nameof(meals_sunday));
            set => SetValue(nameof(meals_sunday), value);
        }
        public float entertainment_weekday
        {
            get => (float)GetValue(nameof(entertainment_weekday));
            set => SetValue(nameof(entertainment_weekday), value);
        }
        public float entertainment_avgday
        {
            get => (float)GetValue(nameof(entertainment_avgday));
            set => SetValue(nameof(entertainment_avgday), value);
        }
        public float entertainment_saturday
        {
            get => (float)GetValue(nameof(entertainment_saturday));
            set => SetValue(nameof(entertainment_saturday), value);
        }
        public float entertainment_sunday
        {
            get => (float)GetValue(nameof(entertainment_sunday));
            set => SetValue(nameof(entertainment_sunday), value);
        }
        public float shopping_weekday
        {
            get => (float)GetValue(nameof(shopping_weekday));
            set => SetValue(nameof(shopping_weekday), value);
        }
        public float shopping_avgday
        {
            get => (float)GetValue(nameof(shopping_avgday));
            set => SetValue(nameof(shopping_avgday), value);
        }
        public float shopping_saturday
        {
            get => (float)GetValue(nameof(shopping_saturday));
            set => SetValue(nameof(shopping_saturday), value);
        }
        public float shopping_sunday
        {
            get => (float)GetValue(nameof(shopping_sunday));
            set => SetValue(nameof(shopping_sunday), value);
        }
        public float park_weekday
        {
            get => (float)GetValue(nameof(park_weekday));
            set => SetValue(nameof(park_weekday), value);
        }
        public float park_avgday
        {
            get => (float)GetValue(nameof(park_avgday));
            set => SetValue(nameof(park_avgday), value);
        }
        public float park_saturday
        {
            get => (float)GetValue(nameof(park_saturday));
            set => SetValue(nameof(park_saturday), value);
        }
        public float park_sunday
        {
            get => (float)GetValue(nameof(park_sunday));
            set => SetValue(nameof(park_sunday), value);
        }
        public float travel_weekday
        {
            get => (float)GetValue(nameof(travel_weekday));
            set => SetValue(nameof(travel_weekday), value);
        }
        public float travel_avgday
        {
            get => (float)GetValue(nameof(travel_avgday));
            set => SetValue(nameof(travel_avgday), value);
        }
        public float travel_saturday
        {
            get => (float)GetValue(nameof(travel_saturday));
            set => SetValue(nameof(travel_saturday), value);
        }
        public float travel_sunday
        {
            get => (float)GetValue(nameof(travel_sunday));
            set => SetValue(nameof(travel_sunday), value);
        }
        public int avg_time_beverages
        {
            get => (int)GetValue(nameof(avg_time_beverages));
            set => SetValue(nameof(avg_time_beverages), value);
        }
        public int avg_time_chemicals
        {
            get => (int)GetValue(nameof(avg_time_chemicals));
            set => SetValue(nameof(avg_time_chemicals), value);
        }
        public int avg_time_convenienceFood
        {
            get => (int)GetValue(nameof(avg_time_convenienceFood));
            set => SetValue(nameof(avg_time_convenienceFood), value);
        }
        public int avg_time_electronics
        {
            get => (int)GetValue(nameof(avg_time_electronics));
            set => SetValue(nameof(avg_time_electronics), value);
        }
        public int avg_time_software
        {
            get => (int)GetValue(nameof(avg_time_software));
            set => SetValue(nameof(avg_time_software), value);
        }
        public int avg_time_financial
        {
            get => (int)GetValue(nameof(avg_time_financial));
            set => SetValue(nameof(avg_time_financial), value);
        }
        public int avg_time_food
        {
            get => (int)GetValue(nameof(avg_time_food));
            set => SetValue(nameof(avg_time_food), value);
        }
        public int avg_time_furniture
        {
            get => (int)GetValue(nameof(avg_time_furniture));
            set => SetValue(nameof(avg_time_furniture), value);
        }
        public int avg_time_meals
        {
            get => (int)GetValue(nameof(avg_time_meals));
            set => SetValue(nameof(avg_time_meals), value);
        }
        public int avg_time_media
        {
            get => (int)GetValue(nameof(avg_time_media));
            set => SetValue(nameof(avg_time_media), value);
        }
        public int avg_time_paper
        {
            get => (int)GetValue(nameof(avg_time_paper));
            set => SetValue(nameof(avg_time_paper), value);
        }
        public int avg_time_petrochemicals
        {
            get => (int)GetValue(nameof(avg_time_petrochemicals));
            set => SetValue(nameof(avg_time_petrochemicals), value);
        }
        public int avg_time_pharmaceuticals
        {
            get => (int)GetValue(nameof(avg_time_pharmaceuticals));
            set => SetValue(nameof(avg_time_pharmaceuticals), value);
        }
        public int avg_time_plastics
        {
            get => (int)GetValue(nameof(avg_time_plastics));
            set => SetValue(nameof(avg_time_plastics), value);
        }
        public int avg_time_telecom
        {
            get => (int)GetValue(nameof(avg_time_telecom));
            set => SetValue(nameof(avg_time_telecom), value);
        }
        public int avg_time_textiles
        {
            get => (int)GetValue(nameof(avg_time_textiles));
            set => SetValue(nameof(avg_time_textiles), value);
        }
        public int avg_time_recreation
        {
            get => (int)GetValue(nameof(avg_time_recreation));
            set => SetValue(nameof(avg_time_recreation), value);
        }
        public int avg_time_entertainment
        {
            get => (int)GetValue(nameof(avg_time_entertainment));
            set => SetValue(nameof(avg_time_entertainment), value);
        }
        public int avg_time_vehicles
        {
            get => (int)GetValue(nameof(avg_time_vehicles));
            set => SetValue(nameof(avg_time_vehicles), value);
        }
        public bool use_school_vanilla_timeoff
        {
            get => (bool)GetValue(nameof(use_school_vanilla_timeoff));
            set => SetValue(nameof(use_school_vanilla_timeoff), value);
        }
        public int school_vacation_month1
        {
            get => (int)GetValue(nameof(school_vacation_month1));
            set => SetValue(nameof(school_vacation_month1), value);
        }
        public int school_vacation_month2
        {
            get => (int)GetValue(nameof(school_vacation_month2));
            set => SetValue(nameof(school_vacation_month2), value);
        }
        public int school_start_time
        {
            get => (int)GetValue(nameof(school_start_time));
            set => SetValue(nameof(school_start_time), value);
        }
        public int school_end_time
        {
            get => (int)GetValue(nameof(school_end_time));
            set => SetValue(nameof(school_end_time), value);
        }
        public int high_school_start_time
        {
            get => (int)GetValue(nameof(high_school_start_time));
            set => SetValue(nameof(high_school_start_time), value);
        }
        public int high_school_end_time
        {
            get => (int)GetValue(nameof(high_school_end_time));
            set => SetValue(nameof(high_school_end_time), value);
        }
        public int univ_start_time
        {
            get => (int)GetValue(nameof(univ_start_time));
            set => SetValue(nameof(univ_start_time), value);
        }
        public int univ_end_time
        {
            get => (int)GetValue(nameof(univ_end_time));
            set => SetValue(nameof(univ_end_time), value);
        }
        public int school_lv1_weekday_pct
        {
            get => (int)GetValue(nameof(school_lv1_weekday_pct));
            set => SetValue(nameof(school_lv1_weekday_pct), value);
        }
        public int school_lv1_avgday_pct
        {
            get => (int)GetValue(nameof(school_lv1_avgday_pct));
            set => SetValue(nameof(school_lv1_avgday_pct), value);
        }
        public int school_lv1_saturday_pct
        {
            get => (int)GetValue(nameof(school_lv1_saturday_pct));
            set => SetValue(nameof(school_lv1_saturday_pct), value);
        }
        public int school_lv1_sunday_pct
        {
            get => (int)GetValue(nameof(school_lv1_sunday_pct));
            set => SetValue(nameof(school_lv1_sunday_pct), value);
        }
        public int school_lv2_weekday_pct
        {
            get => (int)GetValue(nameof(school_lv2_weekday_pct));
            set => SetValue(nameof(school_lv2_weekday_pct), value);
        }
        public int school_lv2_avgday_pct
        {
            get => (int)GetValue(nameof(school_lv2_avgday_pct));
            set => SetValue(nameof(school_lv2_avgday_pct), value);
        }
        public int school_lv2_saturday_pct
        {
            get => (int)GetValue(nameof(school_lv2_saturday_pct));
            set => SetValue(nameof(school_lv2_saturday_pct), value);
        }
        public int school_lv2_sunday_pct
        {
            get => (int)GetValue(nameof(school_lv2_sunday_pct));
            set => SetValue(nameof(school_lv2_sunday_pct), value);
        }
        public int school_lv34_weekday_pct
        {
            get => (int)GetValue(nameof(school_lv34_weekday_pct));
            set => SetValue(nameof(school_lv34_weekday_pct), value);
        }
        public int school_lv34_avgday_pct
        {
            get => (int)GetValue(nameof(school_lv34_avgday_pct));
            set => SetValue(nameof(school_lv34_avgday_pct), value);
        }
        public int school_lv34_saturday_pct
        {
            get => (int)GetValue(nameof(school_lv34_saturday_pct));
            set => SetValue(nameof(school_lv34_saturday_pct), value);
        }
        public int school_lv34_sunday_pct
        {
            get => (int)GetValue(nameof(school_lv34_sunday_pct));
            set => SetValue(nameof(school_lv34_sunday_pct), value);
        }
        public int work_start_time
        {
            get => (int)GetValue(nameof(work_start_time));
            set => SetValue(nameof(work_start_time), value);
        }
        public int work_end_time
        {
            get => (int)GetValue(nameof(work_end_time));
            set => SetValue(nameof(work_end_time), value);
        }
        public float avg_work_hours_ft_wd
        {
            get => (float)GetValue(nameof(avg_work_hours_ft_wd));
            set => SetValue(nameof(avg_work_hours_ft_wd), value);
        }
        public int part_time_percentage
        {
            get => (int)GetValue(nameof(part_time_percentage));
            set => SetValue(nameof(part_time_percentage), value);
        }
        public float avg_work_hours_pt_wd
        {
            get => (float)GetValue(nameof(avg_work_hours_pt_wd));
            set => SetValue(nameof(avg_work_hours_pt_wd), value);
        }
        public int dt_simulation
        {
            get => (int)GetValue(nameof(dt_simulation));
            set => SetValue(nameof(dt_simulation), value);
        }
        public float slow_time_factor
        {
            get => (float)GetValue(nameof(slow_time_factor));
            set => SetValue(nameof(slow_time_factor), value);
        }
        public int daysPerMonth
        {
            get => (int)GetValue(nameof(daysPerMonth));
            set => SetValue(nameof(daysPerMonth), value);
        }
        public int office_weekday_pct
        {
            get => (int)GetValue(nameof(office_weekday_pct));
            set => SetValue(nameof(office_weekday_pct), value);
        }
        public int office_avgday_pct
        {
            get => (int)GetValue(nameof(office_avgday_pct));
            set => SetValue(nameof(office_avgday_pct), value);
        }
        public int office_sat_pct
        {
            get => (int)GetValue(nameof(office_sat_pct));
            set => SetValue(nameof(office_sat_pct), value);
        }
        public int office_sun_pct
        {
            get => (int)GetValue(nameof(office_sun_pct));
            set => SetValue(nameof(office_sun_pct), value);
        }
        public int commercial_weekday_pct
        {
            get => (int)GetValue(nameof(commercial_weekday_pct));
            set => SetValue(nameof(commercial_weekday_pct), value);
        }
        public int commercial_avgday_pct
        {
            get => (int)GetValue(nameof(commercial_avgday_pct));
            set => SetValue(nameof(commercial_avgday_pct), value);
        }
        public int commercial_sat_pct
        {
            get => (int)GetValue(nameof(commercial_sat_pct));
            set => SetValue(nameof(commercial_sat_pct), value);
        }
        public int commercial_sun_pct
        {
            get => (int)GetValue(nameof(commercial_sun_pct));
            set => SetValue(nameof(commercial_sun_pct), value);
        }
        public int industry_weekday_pct
        {
            get => (int)GetValue(nameof(industry_weekday_pct));
            set => SetValue(nameof(industry_weekday_pct), value);
        }
        public int industry_avgday_pct
        {
            get => (int)GetValue(nameof(industry_avgday_pct));
            set => SetValue(nameof(industry_avgday_pct), value);
        }
        public int industry_sat_pct
        {
            get => (int)GetValue(nameof(industry_sat_pct));
            set => SetValue(nameof(industry_sat_pct), value);
        }
        public int industry_sun_pct
        {
            get => (int)GetValue(nameof(industry_sun_pct));
            set => SetValue(nameof(industry_sun_pct), value);
        }
        public int cityServices_weekday_pct
        {
            get => (int)GetValue(nameof(cityServices_weekday_pct));
            set => SetValue(nameof(cityServices_weekday_pct), value);
        }
        public int cityServices_avgday_pct
        {
            get => (int)GetValue(nameof(cityServices_avgday_pct));
            set => SetValue(nameof(cityServices_avgday_pct), value);
        }
        public int cityServices_sat_pct
        {
            get => (int)GetValue(nameof(cityServices_sat_pct));
            set => SetValue(nameof(cityServices_sat_pct), value);
        }
        public int cityServices_sun_pct
        {
            get => (int)GetValue(nameof(cityServices_sun_pct));
            set => SetValue(nameof(cityServices_sun_pct), value);
        }

        //public bool night_trucks
        //{
        //    get => (bool)GetValue(nameof(night_trucks));
        //    set => SetValue(nameof(night_trucks), value);
        //}
        public bool tourism_trips
        {
            get => (bool)GetValue(nameof(tourism_trips));
            set => SetValue(nameof(tourism_trips), value);
        }
        public bool commuter_trips
        {
            get => (bool)GetValue(nameof(commuter_trips));
            set => SetValue(nameof(commuter_trips), value);
        }
        public int service_expenses_night_reduction
        {
            get => (int)GetValue(nameof(service_expenses_night_reduction));
            set => SetValue(nameof(service_expenses_night_reduction), value);
        }
        public int trafficReduction
        {
            get => (int)GetValue(nameof(trafficReduction));
            set => SetValue(nameof(trafficReduction), value);
        }
        public int min_attraction
        {
            get => (int)GetValue(nameof(min_attraction));
            set => SetValue(nameof(min_attraction), value);
        }
        public int min_event_weekday
        {
            get => (int)GetValue(nameof(min_event_weekday));
            set => SetValue(nameof(min_event_weekday), value);
        }
        public int min_event_avg_day
        {
            get => (int)GetValue(nameof(min_event_avg_day));
            set => SetValue(nameof(min_event_avg_day), value);
        }
        public int min_event_weekend
        {
            get => (int)GetValue(nameof(min_event_weekend));
            set => SetValue(nameof(min_event_weekend), value);
        }
        public int max_event_weekday
        {
            get => (int)GetValue(nameof(max_event_weekday));
            set => SetValue(nameof(max_event_weekday), value);
        }
        public int max_event_avg_day
        {
            get => (int)GetValue(nameof(max_event_avg_day));
            set => SetValue(nameof(max_event_avg_day), value);
        }
        public int max_event_weekend
        {
            get => (int)GetValue(nameof(max_event_weekend));
            set => SetValue(nameof(max_event_weekend), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class RealisticWorkplacesAndHouseholdsSettings : SettingsBackup
    {
        public bool single_household_low_density
        {
            get => (bool)GetValue(nameof(single_household_low_density));
            set => SetValue(nameof(single_household_low_density), value);
        }
        public int residential_lowdensity_sqm_per_apartment
        {
            get => (int)GetValue(nameof(residential_lowdensity_sqm_per_apartment));
            set => SetValue(nameof(residential_lowdensity_sqm_per_apartment), value);
        }
        public float residential_avg_floor_height
        {
            get => (float)GetValue(nameof(residential_avg_floor_height));
            set => SetValue(nameof(residential_avg_floor_height), value);
        }
        public int residential_sqm_per_apartment
        {
            get => (int)GetValue(nameof(residential_sqm_per_apartment));
            set => SetValue(nameof(residential_sqm_per_apartment), value);
        }
        public int residential_vacancy_rate
        {
            get => (int)GetValue(nameof(residential_vacancy_rate));
            set => SetValue(nameof(residential_vacancy_rate), value);
        }
        public int residential_hallway_space
        {
            get => (int)GetValue(nameof(residential_hallway_space));
            set => SetValue(nameof(residential_hallway_space), value);
        }
        public int residential_units_per_elevator
        {
            get => (int)GetValue(nameof(residential_units_per_elevator));
            set => SetValue(nameof(residential_units_per_elevator), value);
        }
        public bool disable_high_level_less_apt
        {
            get => (bool)GetValue(nameof(disable_high_level_less_apt));
            set => SetValue(nameof(disable_high_level_less_apt), value);
        }
        public int residential_l4_reduction
        {
            get => (int)GetValue(nameof(residential_l4_reduction));
            set => SetValue(nameof(residential_l4_reduction), value);
        }
        public int residential_l5_reduction
        {
            get => (int)GetValue(nameof(residential_l5_reduction));
            set => SetValue(nameof(residential_l5_reduction), value);
        }
        public bool disable_row_homes_apt_per_floor
        {
            get => (bool)GetValue(nameof(disable_row_homes_apt_per_floor));
            set => SetValue(nameof(disable_row_homes_apt_per_floor), value);
        }
        public int rowhomes_apt_per_floor
        {
            get => (int)GetValue(nameof(rowhomes_apt_per_floor));
            set => SetValue(nameof(rowhomes_apt_per_floor), value);
        }
        public bool rowhomes_basement
        {
            get => (bool)GetValue(nameof(rowhomes_basement));
            set => SetValue(nameof(rowhomes_basement), value);
        }
        public float commercial_avg_floor_height
        {
            get => (float)GetValue(nameof(commercial_avg_floor_height));
            set => SetValue(nameof(commercial_avg_floor_height), value);
        }
        public bool commercial_self_service_gas
        {
            get => (bool)GetValue(nameof(commercial_self_service_gas));
            set => SetValue(nameof(commercial_self_service_gas), value);
        }
        public float industry_avg_floor_height
        {
            get => (float)GetValue(nameof(industry_avg_floor_height));
            set => SetValue(nameof(industry_avg_floor_height), value);
        }
        public int industry_area_base
        {
            get => (int)GetValue(nameof(industry_area_base));
            set => SetValue(nameof(industry_area_base), value);
        }
        public int commercial_sqm_per_worker
        {
            get => (int)GetValue(nameof(commercial_sqm_per_worker));
            set => SetValue(nameof(commercial_sqm_per_worker), value);
        }
        public int commercial_sqm_per_worker_supermarket
        {
            get => (int)GetValue(nameof(commercial_sqm_per_worker_supermarket));
            set => SetValue(nameof(commercial_sqm_per_worker_supermarket), value);
        }
        public int commercial_sqm_per_worker_restaurants
        {
            get => (int)GetValue(nameof(commercial_sqm_per_worker_restaurants));
            set => SetValue(nameof(commercial_sqm_per_worker_restaurants), value);
        }
        public int office_sqm_per_worker
        {
            get => (int)GetValue(nameof(office_sqm_per_worker));
            set => SetValue(nameof(office_sqm_per_worker), value);
        }
        public int office_non_usable_space
        {
            get => (int)GetValue(nameof(office_non_usable_space));
            set => SetValue(nameof(office_non_usable_space), value);
        }
        public int office_elevators_per_sqm
        {
            get => (int)GetValue(nameof(office_elevators_per_sqm));
            set => SetValue(nameof(office_elevators_per_sqm), value);
        }
        public int office_height_base
        {
            get => (int)GetValue(nameof(office_height_base));
            set => SetValue(nameof(office_height_base), value);
        }
        public bool disable_hospital
        {
            get => (bool)GetValue(nameof(disable_hospital));
            set => SetValue(nameof(disable_hospital), value);
        }
        public int hospital_sqm_per_worker
        {
            get => (int)GetValue(nameof(hospital_sqm_per_worker));
            set => SetValue(nameof(hospital_sqm_per_worker), value);
        }
        public bool disable_transit
        {
            get => (bool)GetValue(nameof(disable_transit));
            set => SetValue(nameof(disable_transit), value);
        }
        public int transit_station_sqm_per_worker
        {
            get => (int)GetValue(nameof(transit_station_sqm_per_worker));
            set => SetValue(nameof(transit_station_sqm_per_worker), value);
        }
        public bool disable_airport
        {
            get => (bool)GetValue(nameof(disable_airport));
            set => SetValue(nameof(disable_airport), value);
        }
        public int airport_sqm_per_worker
        {
            get => (int)GetValue(nameof(airport_sqm_per_worker));
            set => SetValue(nameof(airport_sqm_per_worker), value);
        }
        public bool disable_postoffice
        {
            get => (bool)GetValue(nameof(disable_postoffice));
            set => SetValue(nameof(disable_postoffice), value);
        }
        public int postoffice_sqm_per_worker
        {
            get => (int)GetValue(nameof(postoffice_sqm_per_worker));
            set => SetValue(nameof(postoffice_sqm_per_worker), value);
        }
        public bool disable_police
        {
            get => (bool)GetValue(nameof(disable_police));
            set => SetValue(nameof(disable_police), value);
        }
        public int police_sqm_per_worker
        {
            get => (int)GetValue(nameof(police_sqm_per_worker));
            set => SetValue(nameof(police_sqm_per_worker), value);
        }
        public bool disable_fire
        {
            get => (bool)GetValue(nameof(disable_fire));
            set => SetValue(nameof(disable_fire), value);
        }
        public int fire_sqm_per_worker
        {
            get => (int)GetValue(nameof(fire_sqm_per_worker));
            set => SetValue(nameof(fire_sqm_per_worker), value);
        }
        public int prison_sqm_per_prisoner
        {
            get => (int)GetValue(nameof(prison_sqm_per_prisoner));
            set => SetValue(nameof(prison_sqm_per_prisoner), value);
        }
        public int prisoners_per_officer
        {
            get => (int)GetValue(nameof(prisoners_per_officer));
            set => SetValue(nameof(prisoners_per_officer), value);
        }
        public int prison_non_usable_space
        {
            get => (int)GetValue(nameof(prison_non_usable_space));
            set => SetValue(nameof(prison_non_usable_space), value);
        }
        public int industry_sqm_per_worker
        {
            get => (int)GetValue(nameof(industry_sqm_per_worker));
            set => SetValue(nameof(industry_sqm_per_worker), value);
        }
        public bool disable_powerplant
        {
            get => (bool)GetValue(nameof(disable_powerplant));
            set => SetValue(nameof(disable_powerplant), value);
        }
        public int powerplant_sqm_per_worker
        {
            get => (int)GetValue(nameof(powerplant_sqm_per_worker));
            set => SetValue(nameof(powerplant_sqm_per_worker), value);
        }
        public bool disable_park
        {
            get => (bool)GetValue(nameof(disable_park));
            set => SetValue(nameof(disable_park), value);
        }
        public int park_sqm_per_worker
        {
            get => (int)GetValue(nameof(park_sqm_per_worker));
            set => SetValue(nameof(park_sqm_per_worker), value);
        }
        public bool increase_power_production
        {
            get => (bool)GetValue(nameof(increase_power_production));
            set => SetValue(nameof(increase_power_production), value);
        }
        public int solarpowerplant_reduction_factor
        {
            get => (int)GetValue(nameof(solarpowerplant_reduction_factor));
            set => SetValue(nameof(solarpowerplant_reduction_factor), value);
        }
        public int hospital_sqm_per_patient
        {
            get => (int)GetValue(nameof(hospital_sqm_per_patient));
            set => SetValue(nameof(hospital_sqm_per_patient), value);
        }
        public bool disable_school
        {
            get => (bool)GetValue(nameof(disable_school));
            set => SetValue(nameof(disable_school), value);
        }
        public int students_per_teacher
        {
            get => (int)GetValue(nameof(students_per_teacher));
            set => SetValue(nameof(students_per_teacher), value);
        }
        public float support_staff
        {
            get => (float)GetValue(nameof(support_staff));
            set => SetValue(nameof(support_staff), value);
        }
        public int sqm_per_student
        {
            get => (int)GetValue(nameof(sqm_per_student));
            set => SetValue(nameof(sqm_per_student), value);
        }
        public bool disable_depot
        {
            get => (bool)GetValue(nameof(disable_depot));
            set => SetValue(nameof(disable_depot), value);
        }
        public int depot_sqm_per_worker
        {
            get => (int)GetValue(nameof(depot_sqm_per_worker));
            set => SetValue(nameof(depot_sqm_per_worker), value);
        }
        public bool disable_garbage
        {
            get => (bool)GetValue(nameof(disable_garbage));
            set => SetValue(nameof(disable_garbage), value);
        }
        public int garbage_sqm_per_worker
        {
            get => (int)GetValue(nameof(garbage_sqm_per_worker));
            set => SetValue(nameof(garbage_sqm_per_worker), value);
        }
        public float sqm_college_adjuster
        {
            get => (float)GetValue(nameof(sqm_college_adjuster));
            set => SetValue(nameof(sqm_college_adjuster), value);
        }
        public float sqm_univ_adjuster
        {
            get => (float)GetValue(nameof(sqm_univ_adjuster));
            set => SetValue(nameof(sqm_univ_adjuster), value);
        }
        public bool disable_households_calculations
        {
            get => (bool)GetValue(nameof(disable_households_calculations));
            set => SetValue(nameof(disable_households_calculations), value);
        }
        public bool disable_workplace_calculations
        {
            get => (bool)GetValue(nameof(disable_workplace_calculations));
            set => SetValue(nameof(disable_workplace_calculations), value);
        }
        public bool disable_cityservices_calculations
        {
            get => (bool)GetValue(nameof(disable_cityservices_calculations));
            set => SetValue(nameof(disable_cityservices_calculations), value);
        }
        public int service_upkeep_reduction
        {
            get => (int)GetValue(nameof(service_upkeep_reduction));
            set => SetValue(nameof(service_upkeep_reduction), value);
        }
        public int electricity_consumption_reduction
        {
            get => (int)GetValue(nameof(electricity_consumption_reduction));
            set => SetValue(nameof(electricity_consumption_reduction), value);
        }
        public int water_consumption_reduction
        {
            get => (int)GetValue(nameof(water_consumption_reduction));
            set => SetValue(nameof(water_consumption_reduction), value);
        }
        public int noise_factor
        {
            get => (int)GetValue(nameof(noise_factor));
            set => SetValue(nameof(noise_factor), value);
        }
        public int rent_discount
        {
            get => (int)GetValue(nameof(rent_discount));
            set => SetValue(nameof(rent_discount), value);
        }
        public int results_reduction
        {
            get => (int)GetValue(nameof(results_reduction));
            set => SetValue(nameof(results_reduction), value);
        }
        public int evicted_reset_type
        {
            get => (int)GetValue(nameof(evicted_reset_type));
            set => SetValue(nameof(evicted_reset_type), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class RealLifeSettings : SettingsBackup
    {
        public int child_school_start_age
        {
            get => (int)GetValue(nameof(child_school_start_age));
            set => SetValue(nameof(child_school_start_age), value);
        }
        public int child_age_limit
        {
            get => (int)GetValue(nameof(child_age_limit));
            set => SetValue(nameof(child_age_limit), value);
        }
        public int teen_age_limit
        {
            get => (int)GetValue(nameof(teen_age_limit));
            set => SetValue(nameof(teen_age_limit), value);
        }
        public int male_adult_age_limit
        {
            get => (int)GetValue(nameof(male_adult_age_limit));
            set => SetValue(nameof(male_adult_age_limit), value);
        }
        public int female_adult_age_limit
        {
            get => (int)GetValue(nameof(female_adult_age_limit));
            set => SetValue(nameof(female_adult_age_limit), value);
        }
        public int female_life_expectancy
        {
            get => (int)GetValue(nameof(female_life_expectancy));
            set => SetValue(nameof(female_life_expectancy), value);
        }
        public int male_life_expectancy
        {
            get => (int)GetValue(nameof(male_life_expectancy));
            set => SetValue(nameof(male_life_expectancy), value);
        }
        public int corpse_vanish
        {
            get => (int)GetValue(nameof(corpse_vanish));
            set => SetValue(nameof(corpse_vanish), value);
        }
        public int years_in_college
        {
            get => (int)GetValue(nameof(years_in_college));
            set => SetValue(nameof(years_in_college), value);
        }
        public int years_in_university
        {
            get => (int)GetValue(nameof(years_in_university));
            set => SetValue(nameof(years_in_university), value);
        }
        public int elementary_grad_prob
        {
            get => (int)GetValue(nameof(elementary_grad_prob));
            set => SetValue(nameof(elementary_grad_prob), value);
        }
        public int college_edu_in_univ
        {
            get => (int)GetValue(nameof(college_edu_in_univ));
            set => SetValue(nameof(college_edu_in_univ), value);
        }
        public int high_grad_prob
        {
            get => (int)GetValue(nameof(high_grad_prob));
            set => SetValue(nameof(high_grad_prob), value);
        }
        public int college_grad_prob
        {
            get => (int)GetValue(nameof(college_grad_prob));
            set => SetValue(nameof(college_grad_prob), value);
        }
        public int university_grad_prob
        {
            get => (int)GetValue(nameof(university_grad_prob));
            set => SetValue(nameof(university_grad_prob), value);
        }
        public int enter_high_school_prob
        {
            get => (int)GetValue(nameof(enter_high_school_prob));
            set => SetValue(nameof(enter_high_school_prob), value);
        }
        public int adult_enter_high_school_prob
        {
            get => (int)GetValue(nameof(adult_enter_high_school_prob));
            set => SetValue(nameof(adult_enter_high_school_prob), value);
        }
        public int worker_continue_education
        {
            get => (int)GetValue(nameof(worker_continue_education));
            set => SetValue(nameof(worker_continue_education), value);
        }
        public int student_birth_rate_adjuster
        {
            get => (int)GetValue(nameof(student_birth_rate_adjuster));
            set => SetValue(nameof(student_birth_rate_adjuster), value);
        }
        public int base_birth_rate_adjuster
        {
            get => (int)GetValue(nameof(base_birth_rate_adjuster));
            set => SetValue(nameof(base_birth_rate_adjuster), value);
        }
        public int divorce_rate_adjuster
        {
            get => (int)GetValue(nameof(divorce_rate_adjuster));
            set => SetValue(nameof(divorce_rate_adjuster), value);
        }
        public int adult_female_birth_rate_bonus_adjuster
        {
            get => (int)GetValue(nameof(adult_female_birth_rate_bonus_adjuster));
            set => SetValue(nameof(adult_female_birth_rate_bonus_adjuster), value);
        }
        public int look_for_partner_rate_adjuster
        {
            get => (int)GetValue(nameof(look_for_partner_rate_adjuster));
            set => SetValue(nameof(look_for_partner_rate_adjuster), value);
        }
    }

    public class RecolorSettings : SettingsBackup
    {
        public bool ColorPainterAutomaticCopyColor
        {
            get => (bool)GetValue(nameof(ColorPainterAutomaticCopyColor));
            set => SetValue(nameof(ColorPainterAutomaticCopyColor), value);
        }
    }

    public class RegionFlagIconsSettings : SettingsBackup
    {
        public int NorthAmericanFlagStyle
        {
            get => (int)GetValue(nameof(NorthAmericanFlagStyle));
            set => SetValue(nameof(NorthAmericanFlagStyle), value);
        }
        public string RestartGameText
        {
            get => (string)GetValue(nameof(RestartGameText));
            set => SetValue(nameof(RestartGameText), value);
        }
        public string FlagFR
        {
            get => (string)GetValue(nameof(FlagFR));
            set => SetValue(nameof(FlagFR), value);
        }
        public string FlagDE
        {
            get => (string)GetValue(nameof(FlagDE));
            set => SetValue(nameof(FlagDE), value);
        }
        public string FlagUK
        {
            get => (string)GetValue(nameof(FlagUK));
            set => SetValue(nameof(FlagUK), value);
        }
        public string FlagJP
        {
            get => (string)GetValue(nameof(FlagJP));
            set => SetValue(nameof(FlagJP), value);
        }
        public string FlagEE
        {
            get => (string)GetValue(nameof(FlagEE));
            set => SetValue(nameof(FlagEE), value);
        }
        public string FlagCN
        {
            get => (string)GetValue(nameof(FlagCN));
            set => SetValue(nameof(FlagCN), value);
        }
        public string FlagSW
        {
            get => (string)GetValue(nameof(FlagSW));
            set => SetValue(nameof(FlagSW), value);
        }
        public string FlagNE
        {
            get => (string)GetValue(nameof(FlagNE));
            set => SetValue(nameof(FlagNE), value);
        }
    }

    public class ResourceLocatorSettings : SettingsBackup
    {
        public bool IncludeRecyclingCenter
        {
            get => (bool)GetValue(nameof(IncludeRecyclingCenter));
            set => SetValue(nameof(IncludeRecyclingCenter), value);
        }
        public bool IncludeCoalPowerPlant
        {
            get => (bool)GetValue(nameof(IncludeCoalPowerPlant));
            set => SetValue(nameof(IncludeCoalPowerPlant), value);
        }
        public bool IncludeGasPowerPlant
        {
            get => (bool)GetValue(nameof(IncludeGasPowerPlant));
            set => SetValue(nameof(IncludeGasPowerPlant), value);
        }
        public bool IncludeMedicalFacility
        {
            get => (bool)GetValue(nameof(IncludeMedicalFacility));
            set => SetValue(nameof(IncludeMedicalFacility), value);
        }
        public bool IncludeEmeregencyShelter
        {
            get => (bool)GetValue(nameof(IncludeEmeregencyShelter));
            set => SetValue(nameof(IncludeEmeregencyShelter), value);
        }
        public bool IncludeCargoStation
        {
            get => (bool)GetValue(nameof(IncludeCargoStation));
            set => SetValue(nameof(IncludeCargoStation), value);
        }
    }

    public class RentMattersAgainSettings : SettingsBackup
    {
        public bool UseCustomDefaults
        {
            get => (bool)GetValue(nameof(UseCustomDefaults));
            set => SetValue(nameof(UseCustomDefaults), value);
        }
        public float LandValueRentFactor
        {
            get => (float)GetValue(nameof(LandValueRentFactor));
            set => SetValue(nameof(LandValueRentFactor), value);
        }
        public float BaseRentFactor
        {
            get => (float)GetValue(nameof(BaseRentFactor));
            set => SetValue(nameof(BaseRentFactor), value);
        }
    }

    public class RoadBuilderSettings : SettingsBackup
    {
        public bool HideRoadsFromToolbarByDefault
        {
            get => (bool)GetValue(nameof(HideRoadsFromToolbarByDefault));
            set => SetValue(nameof(HideRoadsFromToolbarByDefault), value);
        }
        public bool NoPlaysetIsolation
        {
            get => (bool)GetValue(nameof(NoPlaysetIsolation));
            set => SetValue(nameof(NoPlaysetIsolation), value);
        }
        public bool SaveUsedRoadsOnly
        {
            get => (bool)GetValue(nameof(SaveUsedRoadsOnly));
            set => SetValue(nameof(SaveUsedRoadsOnly), value);
        }
        public bool HideArrowsOnThumbnails
        {
            get => (bool)GetValue(nameof(HideArrowsOnThumbnails));
            set => SetValue(nameof(HideArrowsOnThumbnails), value);
        }
        public bool NoImitateLaneOptionsOnPlace
        {
            get => (bool)GetValue(nameof(NoImitateLaneOptionsOnPlace));
            set => SetValue(nameof(NoImitateLaneOptionsOnPlace), value);
        }
        public bool RemoveLockRequirements
        {
            get => (bool)GetValue(nameof(RemoveLockRequirements));
            set => SetValue(nameof(RemoveLockRequirements), value);
        }
        public bool UnrestrictedLanes
        {
            get => (bool)GetValue(nameof(UnrestrictedLanes));
            set => SetValue(nameof(UnrestrictedLanes), value);
        }
        public bool RemoveSafetyMeasures
        {
            get => (bool)GetValue(nameof(RemoveSafetyMeasures));
            set => SetValue(nameof(RemoveSafetyMeasures), value);
        }
        public bool DoNotAddSides
        {
            get => (bool)GetValue(nameof(DoNotAddSides));
            set => SetValue(nameof(DoNotAddSides), value);
        }
        public bool AskToResetRoads
        {
            get => (bool)GetValue(nameof(AskToResetRoads));
            set => SetValue(nameof(AskToResetRoads), value);
        }
    }

    public class RoadNameRemoverSettings : SettingsBackup
    {
        public bool HideStreetNames
        {
            get => (bool)GetValue(nameof(HideStreetNames));
            set => SetValue(nameof(HideStreetNames), value);
        }
        public bool HideHighwayNames
        {
            get => (bool)GetValue(nameof(HideHighwayNames));
            set => SetValue(nameof(HideHighwayNames), value);
        }
        public bool HideAlleyNames
        {
            get => (bool)GetValue(nameof(HideAlleyNames));
            set => SetValue(nameof(HideAlleyNames), value);
        }
        public bool HideBridgeNames
        {
            get => (bool)GetValue(nameof(HideBridgeNames));
            set => SetValue(nameof(HideBridgeNames), value);
        }
        public bool HideDamNames
        {
            get => (bool)GetValue(nameof(HideDamNames));
            set => SetValue(nameof(HideDamNames), value);
        }
        public bool HideDistrictNames
        {
            get => (bool)GetValue(nameof(HideDistrictNames));
            set => SetValue(nameof(HideDistrictNames), value);
        }
    }

    public class RoadWearAdjusterSettings : SettingsBackup
    {
        public int TextureVariant
        {
            get => (int)GetValue(nameof(TextureVariant));
            set => SetValue(nameof(TextureVariant), value);
        }
        public float TextureBrightness
        {
            get => (float)GetValue(nameof(TextureBrightness));
            set => SetValue(nameof(TextureBrightness), value);
        }
        public float TextureOpacity
        {
            get => (float)GetValue(nameof(TextureOpacity));
            set => SetValue(nameof(TextureOpacity), value);
        }
        public float TextureSmoothness
        {
            get => (float)GetValue(nameof(TextureSmoothness));
            set => SetValue(nameof(TextureSmoothness), value);
        }
    }

    public class SchoolCapacityBalancerSettings : SettingsBackup
    {
        public int ElementarySlider
        {
            get => (int)GetValue(nameof(ElementarySlider));
            set => SetValue(nameof(ElementarySlider), value);
        }
        public int HighSchoolSlider
        {
            get => (int)GetValue(nameof(HighSchoolSlider));
            set => SetValue(nameof(HighSchoolSlider), value);
        }
        public int CollegeSlider
        {
            get => (int)GetValue(nameof(CollegeSlider));
            set => SetValue(nameof(CollegeSlider), value);
        }
        public int UniversitySlider
        {
            get => (int)GetValue(nameof(UniversitySlider));
            set => SetValue(nameof(UniversitySlider), value);
        }
        //public bool ScaleUpkeepWithCapacity
        //{
        //    get => (bool)GetValue(nameof(ScaleUpkeepWithCapacity));
        //    set => SetValue(nameof(ScaleUpkeepWithCapacity), value);
        //}
    }

    public class ShowMoreHappinessSettings : SettingsBackup
    {
        public int MaximumFactors
        {
            get => (int)GetValue(nameof(MaximumFactors));
            set => SetValue(nameof(MaximumFactors), value);
        }
        public bool ShowZeroValues
        {
            get => (bool)GetValue(nameof(ShowZeroValues));
            set => SetValue(nameof(ShowZeroValues), value);
        }
        public int PositiveNegativeValues
        {
            get => (int)GetValue(nameof(PositiveNegativeValues));
            set => SetValue(nameof(PositiveNegativeValues), value);
        }
        public int SortDirection
        {
            get => (int)GetValue(nameof(SortDirection));
            set => SetValue(nameof(SortDirection), value);
        }
    }

    public class SimpleModCheckerSettings : SettingsBackup
    {
        public bool ShowNotif
        {
            get => (bool)GetValue(nameof(ShowNotif));
            set => SetValue(nameof(ShowNotif), value);
        }
        public bool PlaySound
        {
            get => (bool)GetValue(nameof(PlaySound));
            set => SetValue(nameof(PlaySound), value);
        }
        public bool DisableContinueOnLauncher
        {
            get => (bool)GetValue(nameof(DisableContinueOnLauncher));
            set => SetValue(nameof(DisableContinueOnLauncher), value);
        }
        public bool DisableContinueInGame
        {
            get => (bool)GetValue(nameof(DisableContinueInGame));
            set => SetValue(nameof(DisableContinueInGame), value);
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
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class SmartTransportationSettings : SettingsBackup
    {
        public bool disable_bus
        {
            get => (bool)GetValue(nameof(disable_bus));
            set => SetValue(nameof(disable_bus), value);
        }
        public int target_occupancy_bus
        {
            get => (int)GetValue(nameof(target_occupancy_bus));
            set => SetValue(nameof(target_occupancy_bus), value);
        }
        public int standard_ticket_bus
        {
            get => (int)GetValue(nameof(standard_ticket_bus));
            set => SetValue(nameof(standard_ticket_bus), value);
        }
        public int max_ticket_increase_bus
        {
            get => (int)GetValue(nameof(max_ticket_increase_bus));
            set => SetValue(nameof(max_ticket_increase_bus), value);
        }
        public int max_ticket_discount_bus
        {
            get => (int)GetValue(nameof(max_ticket_discount_bus));
            set => SetValue(nameof(max_ticket_discount_bus), value);
        }
        public int max_vahicles_adj_bus
        {
            get => (int)GetValue(nameof(max_vahicles_adj_bus));
            set => SetValue(nameof(max_vahicles_adj_bus), value);
        }
        public int min_vahicles_adj_bus
        {
            get => (int)GetValue(nameof(min_vahicles_adj_bus));
            set => SetValue(nameof(min_vahicles_adj_bus), value);
        }
        public bool disable_Tram
        {
            get => (bool)GetValue(nameof(disable_Tram));
            set => SetValue(nameof(disable_Tram), value);
        }
        public int target_occupancy_Tram
        {
            get => (int)GetValue(nameof(target_occupancy_Tram));
            set => SetValue(nameof(target_occupancy_Tram), value);
        }
        public int standard_ticket_Tram
        {
            get => (int)GetValue(nameof(standard_ticket_Tram));
            set => SetValue(nameof(standard_ticket_Tram), value);
        }
        public int max_ticket_increase_Tram
        {
            get => (int)GetValue(nameof(max_ticket_increase_Tram));
            set => SetValue(nameof(max_ticket_increase_Tram), value);
        }
        public int max_ticket_discount_Tram
        {
            get => (int)GetValue(nameof(max_ticket_discount_Tram));
            set => SetValue(nameof(max_ticket_discount_Tram), value);
        }
        public int max_vahicles_adj_Tram
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Tram));
            set => SetValue(nameof(max_vahicles_adj_Tram), value);
        }
        public int min_vahicles_adj_Tram
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Tram));
            set => SetValue(nameof(min_vahicles_adj_Tram), value);
        }
        public bool disable_Subway
        {
            get => (bool)GetValue(nameof(disable_Subway));
            set => SetValue(nameof(disable_Subway), value);
        }
        public int target_occupancy_Subway
        {
            get => (int)GetValue(nameof(target_occupancy_Subway));
            set => SetValue(nameof(target_occupancy_Subway), value);
        }
        public int standard_ticket_Subway
        {
            get => (int)GetValue(nameof(standard_ticket_Subway));
            set => SetValue(nameof(standard_ticket_Subway), value);
        }
        public int max_ticket_increase_Subway
        {
            get => (int)GetValue(nameof(max_ticket_increase_Subway));
            set => SetValue(nameof(max_ticket_increase_Subway), value);
        }
        public int max_ticket_discount_Subway
        {
            get => (int)GetValue(nameof(max_ticket_discount_Subway));
            set => SetValue(nameof(max_ticket_discount_Subway), value);
        }
        public int max_vahicles_adj_Subway
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Subway));
            set => SetValue(nameof(max_vahicles_adj_Subway), value);
        }
        public int min_vahicles_adj_Subway
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Subway));
            set => SetValue(nameof(min_vahicles_adj_Subway), value);
        }
        public bool disable_Train
        {
            get => (bool)GetValue(nameof(disable_Train));
            set => SetValue(nameof(disable_Train), value);
        }
        public int target_occupancy_Train
        {
            get => (int)GetValue(nameof(target_occupancy_Train));
            set => SetValue(nameof(target_occupancy_Train), value);
        }
        public int standard_ticket_Train
        {
            get => (int)GetValue(nameof(standard_ticket_Train));
            set => SetValue(nameof(standard_ticket_Train), value);
        }
        public int max_ticket_increase_Train
        {
            get => (int)GetValue(nameof(max_ticket_increase_Train));
            set => SetValue(nameof(max_ticket_increase_Train), value);
        }
        public int max_ticket_discount_Train
        {
            get => (int)GetValue(nameof(max_ticket_discount_Train));
            set => SetValue(nameof(max_ticket_discount_Train), value);
        }
        public int max_vahicles_adj_Train
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Train));
            set => SetValue(nameof(max_vahicles_adj_Train), value);
        }
        public int min_vahicles_adj_Train
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Train));
            set => SetValue(nameof(min_vahicles_adj_Train), value);
        }
        public float waiting_time_weight
        {
            get => (float)GetValue(nameof(waiting_time_weight));
            set => SetValue(nameof(waiting_time_weight), value);
        }
        public float threshold
        {
            get => (float)GetValue(nameof(threshold));
            set => SetValue(nameof(threshold), value);
        }
        public int updateFreq
        {
            get => (int)GetValue(nameof(updateFreq));
            set => SetValue(nameof(updateFreq), value);
        }
        public bool debug
        {
            get => (bool)GetValue(nameof(debug));
            set => SetValue(nameof(debug), value);
        }
    }

    public class SmartUpkeepManagerSettings : SettingsBackup
    {
        public bool Disable
        {
            get => (bool)GetValue(nameof(Disable));
            set => SetValue(nameof(Disable), value);
        }
        public int RoadMaintenance
        {
            get => (int)GetValue(nameof(RoadMaintenance));
            set => SetValue(nameof(RoadMaintenance), value);
        }
        public int SnowPloughing
        {
            get => (int)GetValue(nameof(SnowPloughing));
            set => SetValue(nameof(SnowPloughing), value);
        }
        public int Towing
        {
            get => (int)GetValue(nameof(Towing));
            set => SetValue(nameof(Towing), value);
        }
        public int RoadMaintenanceVehicle
        {
            get => (int)GetValue(nameof(RoadMaintenanceVehicle));
            set => SetValue(nameof(RoadMaintenanceVehicle), value);
        }
        public int SolarPowered
        {
            get => (int)GetValue(nameof(SolarPowered));
            set => SetValue(nameof(SolarPowered), value);
        }
        public int GroundWaterPowered
        {
            get => (int)GetValue(nameof(GroundWaterPowered));
            set => SetValue(nameof(GroundWaterPowered), value);
        }
        public int WaterPowered
        {
            get => (int)GetValue(nameof(WaterPowered));
            set => SetValue(nameof(WaterPowered), value);
        }
        public int WindPowered
        {
            get => (int)GetValue(nameof(WindPowered));
            set => SetValue(nameof(WindPowered), value);
        }
        public int GarbagePowered
        {
            get => (int)GetValue(nameof(GarbagePowered));
            set => SetValue(nameof(GarbagePowered), value);
        }
        public int ElectricityProduction
        {
            get => (int)GetValue(nameof(ElectricityProduction));
            set => SetValue(nameof(ElectricityProduction), value);
        }
        public int BatteryOut
        {
            get => (int)GetValue(nameof(BatteryOut));
            set => SetValue(nameof(BatteryOut), value);
        }
        public int BatteryCap
        {
            get => (int)GetValue(nameof(BatteryCap));
            set => SetValue(nameof(BatteryCap), value);
        }
        public int Transformer
        {
            get => (int)GetValue(nameof(Transformer));
            set => SetValue(nameof(Transformer), value);
        }
        public int WaterPumpCap
        {
            get => (int)GetValue(nameof(WaterPumpCap));
            set => SetValue(nameof(WaterPumpCap), value);
        }
        public int SewageOutCap
        {
            get => (int)GetValue(nameof(SewageOutCap));
            set => SetValue(nameof(SewageOutCap), value);
        }
        public int Purification
        {
            get => (int)GetValue(nameof(Purification));
            set => SetValue(nameof(Purification), value);
        }
        public int Ambulance
        {
            get => (int)GetValue(nameof(Ambulance));
            set => SetValue(nameof(Ambulance), value);
        }
        public int MedicalHelicopter
        {
            get => (int)GetValue(nameof(MedicalHelicopter));
            set => SetValue(nameof(MedicalHelicopter), value);
        }
        public int Patient
        {
            get => (int)GetValue(nameof(Patient));
            set => SetValue(nameof(Patient), value);
        }
        public int HealthBonus
        {
            get => (int)GetValue(nameof(HealthBonus));
            set => SetValue(nameof(HealthBonus), value);
        }
        public int HealthRange
        {
            get => (int)GetValue(nameof(HealthRange));
            set => SetValue(nameof(HealthRange), value);
        }
        public int Treatment
        {
            get => (int)GetValue(nameof(Treatment));
            set => SetValue(nameof(Treatment), value);
        }
        public int Hearse
        {
            get => (int)GetValue(nameof(Hearse));
            set => SetValue(nameof(Hearse), value);
        }
        public int BodyStorage
        {
            get => (int)GetValue(nameof(BodyStorage));
            set => SetValue(nameof(BodyStorage), value);
        }
        public int BodyProcessing
        {
            get => (int)GetValue(nameof(BodyProcessing));
            set => SetValue(nameof(BodyProcessing), value);
        }
        public int GarbageCap
        {
            get => (int)GetValue(nameof(GarbageCap));
            set => SetValue(nameof(GarbageCap), value);
        }
        public int GarbageTruck
        {
            get => (int)GetValue(nameof(GarbageTruck));
            set => SetValue(nameof(GarbageTruck), value);
        }
        public int DumpTruck
        {
            get => (int)GetValue(nameof(DumpTruck));
            set => SetValue(nameof(DumpTruck), value);
        }
        public int GarbageProcessing
        {
            get => (int)GetValue(nameof(GarbageProcessing));
            set => SetValue(nameof(GarbageProcessing), value);
        }
        public int Student
        {
            get => (int)GetValue(nameof(Student));
            set => SetValue(nameof(Student), value);
        }
        public int StudentGraduation
        {
            get => (int)GetValue(nameof(StudentGraduation));
            set => SetValue(nameof(StudentGraduation), value);
        }
        public int StudentWellbeing
        {
            get => (int)GetValue(nameof(StudentWellbeing));
            set => SetValue(nameof(StudentWellbeing), value);
        }
        public int StudentHealth
        {
            get => (int)GetValue(nameof(StudentHealth));
            set => SetValue(nameof(StudentHealth), value);
        }
        public int ResearchFacility
        {
            get => (int)GetValue(nameof(ResearchFacility));
            set => SetValue(nameof(ResearchFacility), value);
        }
        public int FireTruck
        {
            get => (int)GetValue(nameof(FireTruck));
            set => SetValue(nameof(FireTruck), value);
        }
        public int FireHelicopter
        {
            get => (int)GetValue(nameof(FireHelicopter));
            set => SetValue(nameof(FireHelicopter), value);
        }
        public int FireDisasterCap
        {
            get => (int)GetValue(nameof(FireDisasterCap));
            set => SetValue(nameof(FireDisasterCap), value);
        }
        public int FireVehicleEffi
        {
            get => (int)GetValue(nameof(FireVehicleEffi));
            set => SetValue(nameof(FireVehicleEffi), value);
        }
        public int Firewatch
        {
            get => (int)GetValue(nameof(Firewatch));
            set => SetValue(nameof(Firewatch), value);
        }
        public int EarlyDisasterWarningSystem
        {
            get => (int)GetValue(nameof(EarlyDisasterWarningSystem));
            set => SetValue(nameof(EarlyDisasterWarningSystem), value);
        }
        public int DisasterFacility
        {
            get => (int)GetValue(nameof(DisasterFacility));
            set => SetValue(nameof(DisasterFacility), value);
        }
        public int ShelterCap
        {
            get => (int)GetValue(nameof(ShelterCap));
            set => SetValue(nameof(ShelterCap), value);
        }
        public int EvacuationBus
        {
            get => (int)GetValue(nameof(EvacuationBus));
            set => SetValue(nameof(EvacuationBus), value);
        }
        public int EmergencyGenerator
        {
            get => (int)GetValue(nameof(EmergencyGenerator));
            set => SetValue(nameof(EmergencyGenerator), value);
        }
        public int PatrolCar
        {
            get => (int)GetValue(nameof(PatrolCar));
            set => SetValue(nameof(PatrolCar), value);
        }
        public int PoliceHelicopter
        {
            get => (int)GetValue(nameof(PoliceHelicopter));
            set => SetValue(nameof(PoliceHelicopter), value);
        }
        public int LocalJail
        {
            get => (int)GetValue(nameof(LocalJail));
            set => SetValue(nameof(LocalJail), value);
        }
        public int Patrol
        {
            get => (int)GetValue(nameof(Patrol));
            set => SetValue(nameof(Patrol), value);
        }
        public int EmergencyPolice
        {
            get => (int)GetValue(nameof(EmergencyPolice));
            set => SetValue(nameof(EmergencyPolice), value);
        }
        public int Intelligence
        {
            get => (int)GetValue(nameof(Intelligence));
            set => SetValue(nameof(Intelligence), value);
        }
        public int PrisonVan
        {
            get => (int)GetValue(nameof(PrisonVan));
            set => SetValue(nameof(PrisonVan), value);
        }
        public int PrisonerCap
        {
            get => (int)GetValue(nameof(PrisonerCap));
            set => SetValue(nameof(PrisonerCap), value);
        }
        public int PrisonerWellbeing
        {
            get => (int)GetValue(nameof(PrisonerWellbeing));
            set => SetValue(nameof(PrisonerWellbeing), value);
        }
        public int PrisonerHealth
        {
            get => (int)GetValue(nameof(PrisonerHealth));
            set => SetValue(nameof(PrisonerHealth), value);
        }
        public int WelfareOffice
        {
            get => (int)GetValue(nameof(WelfareOffice));
            set => SetValue(nameof(WelfareOffice), value);
        }
        public int AdminBuilding
        {
            get => (int)GetValue(nameof(AdminBuilding));
            set => SetValue(nameof(AdminBuilding), value);
        }
        public int PlatformMaintenance
        {
            get => (int)GetValue(nameof(PlatformMaintenance));
            set => SetValue(nameof(PlatformMaintenance), value);
        }
        public int Bus
        {
            get => (int)GetValue(nameof(Bus));
            set => SetValue(nameof(Bus), value);
        }
        public int Train
        {
            get => (int)GetValue(nameof(Train));
            set => SetValue(nameof(Train), value);
        }
        public int Taxi
        {
            get => (int)GetValue(nameof(Taxi));
            set => SetValue(nameof(Taxi), value);
        }
        public int Tram
        {
            get => (int)GetValue(nameof(Tram));
            set => SetValue(nameof(Tram), value);
        }
        public int Ship
        {
            get => (int)GetValue(nameof(Ship));
            set => SetValue(nameof(Ship), value);
        }
        public int Airplane
        {
            get => (int)GetValue(nameof(Airplane));
            set => SetValue(nameof(Airplane), value);
        }
        public int Subway
        {
            get => (int)GetValue(nameof(Subway));
            set => SetValue(nameof(Subway), value);
        }
        public int Rocket
        {
            get => (int)GetValue(nameof(Rocket));
            set => SetValue(nameof(Rocket), value);
        }
        public int EnergyFuel
        {
            get => (int)GetValue(nameof(EnergyFuel));
            set => SetValue(nameof(EnergyFuel), value);
        }
        public int EnergyElectricity
        {
            get => (int)GetValue(nameof(EnergyElectricity));
            set => SetValue(nameof(EnergyElectricity), value);
        }
        public int MaintenanceBoost
        {
            get => (int)GetValue(nameof(MaintenanceBoost));
            set => SetValue(nameof(MaintenanceBoost), value);
        }
        public int DispatchCenter
        {
            get => (int)GetValue(nameof(DispatchCenter));
            set => SetValue(nameof(DispatchCenter), value);
        }
        public int TradedResource
        {
            get => (int)GetValue(nameof(TradedResource));
            set => SetValue(nameof(TradedResource), value);
        }
        public int DeliveryTruck
        {
            get => (int)GetValue(nameof(DeliveryTruck));
            set => SetValue(nameof(DeliveryTruck), value);
        }
        public int ComfortFactor
        {
            get => (int)GetValue(nameof(ComfortFactor));
            set => SetValue(nameof(ComfortFactor), value);
        }
        public int ParkMaintenance
        {
            get => (int)GetValue(nameof(ParkMaintenance));
            set => SetValue(nameof(ParkMaintenance), value);
        }
        public int ParkMaintenanceVehicle
        {
            get => (int)GetValue(nameof(ParkMaintenanceVehicle));
            set => SetValue(nameof(ParkMaintenanceVehicle), value);
        }
        public int LeisureEfficieny
        {
            get => (int)GetValue(nameof(LeisureEfficieny));
            set => SetValue(nameof(LeisureEfficieny), value);
        }
        public int LeisureMeals
        {
            get => (int)GetValue(nameof(LeisureMeals));
            set => SetValue(nameof(LeisureMeals), value);
        }
        public int LeisureEntertainment
        {
            get => (int)GetValue(nameof(LeisureEntertainment));
            set => SetValue(nameof(LeisureEntertainment), value);
        }
        public int LeisureCommercial
        {
            get => (int)GetValue(nameof(LeisureCommercial));
            set => SetValue(nameof(LeisureCommercial), value);
        }
        public int LeisureCityIndoors
        {
            get => (int)GetValue(nameof(LeisureCityIndoors));
            set => SetValue(nameof(LeisureCityIndoors), value);
        }
        public int LeisureTravel
        {
            get => (int)GetValue(nameof(LeisureTravel));
            set => SetValue(nameof(LeisureTravel), value);
        }
        public int LeisureCityPark
        {
            get => (int)GetValue(nameof(LeisureCityPark));
            set => SetValue(nameof(LeisureCityPark), value);
        }
        public int LeisureCityBeach
        {
            get => (int)GetValue(nameof(LeisureCityBeach));
            set => SetValue(nameof(LeisureCityBeach), value);
        }
        public int LeisureAttractions
        {
            get => (int)GetValue(nameof(LeisureAttractions));
            set => SetValue(nameof(LeisureAttractions), value);
        }
        public int LeisureRelaxation
        {
            get => (int)GetValue(nameof(LeisureRelaxation));
            set => SetValue(nameof(LeisureRelaxation), value);
        }
        public int LeisureSightseeing
        {
            get => (int)GetValue(nameof(LeisureSightseeing));
            set => SetValue(nameof(LeisureSightseeing), value);
        }
        public int Attraction
        {
            get => (int)GetValue(nameof(Attraction));
            set => SetValue(nameof(Attraction), value);
        }
        public int PostVan
        {
            get => (int)GetValue(nameof(PostVan));
            set => SetValue(nameof(PostVan), value);
        }
        public int PostTruck
        {
            get => (int)GetValue(nameof(PostTruck));
            set => SetValue(nameof(PostTruck), value);
        }
        public int MailCap
        {
            get => (int)GetValue(nameof(MailCap));
            set => SetValue(nameof(MailCap), value);
        }
        public int PostSortingRate
        {
            get => (int)GetValue(nameof(PostSortingRate));
            set => SetValue(nameof(PostSortingRate), value);
        }
        public int TelecomRange
        {
            get => (int)GetValue(nameof(TelecomRange));
            set => SetValue(nameof(TelecomRange), value);
        }
        public int NetworkCap
        {
            get => (int)GetValue(nameof(NetworkCap));
            set => SetValue(nameof(NetworkCap), value);
        }
        public int Wireless
        {
            get => (int)GetValue(nameof(Wireless));
            set => SetValue(nameof(Wireless), value);
        }
        public int Fibre
        {
            get => (int)GetValue(nameof(Fibre));
            set => SetValue(nameof(Fibre), value);
        }
        public bool ServiceBudgetMultiplier
        {
            get => (bool)GetValue(nameof(ServiceBudgetMultiplier));
            set => SetValue(nameof(ServiceBudgetMultiplier), value);
        }
        public bool CityBonusMultiplier
        {
            get => (bool)GetValue(nameof(CityBonusMultiplier));
            set => SetValue(nameof(CityBonusMultiplier), value);
        }
        public int ServiceCoverageMultiplier
        {
            get => (int)GetValue(nameof(ServiceCoverageMultiplier));
            set => SetValue(nameof(ServiceCoverageMultiplier), value);
        }
        public int PlotPrice
        {
            get => (int)GetValue(nameof(PlotPrice));
            set => SetValue(nameof(PlotPrice), value);
        }
        public int ParkingSpots
        {
            get => (int)GetValue(nameof(ParkingSpots));
            set => SetValue(nameof(ParkingSpots), value);
        }
        public int GroundPollution
        {
            get => (int)GetValue(nameof(GroundPollution));
            set => SetValue(nameof(GroundPollution), value);
        }
        public int AirPollution
        {
            get => (int)GetValue(nameof(AirPollution));
            set => SetValue(nameof(AirPollution), value);
        }
        public int NoisePollution
        {
            get => (int)GetValue(nameof(NoisePollution));
            set => SetValue(nameof(NoisePollution), value);
        }
        public int EmployeeUpkeep
        {
            get => (int)GetValue(nameof(EmployeeUpkeep));
            set => SetValue(nameof(EmployeeUpkeep), value);
        }
        public int StorageUpkeep
        {
            get => (int)GetValue(nameof(StorageUpkeep));
            set => SetValue(nameof(StorageUpkeep), value);
        }
        public int Uniqueness
        {
            get => (int)GetValue(nameof(Uniqueness));
            set => SetValue(nameof(Uniqueness), value);
        }
    }

    public class StationNamingSettings : SettingsBackup
    {
        public bool Enable
        {
            get => (bool)GetValue(nameof(Enable));
            set => SetValue(nameof(Enable), value);
        }
        public string NamingSeparator
        {
            get => (string)GetValue(nameof(NamingSeparator));
            set => SetValue(nameof(NamingSeparator), value);
        }

        //public string RoadFormat
        //{
        //    get => (string)GetValue(nameof(RoadFormat));
        //    set => SetValue(nameof(RoadFormat), value);
        //}
        public bool ReverseRoadOrder
        {
            get => (bool)GetValue(nameof(ReverseRoadOrder));
            set => SetValue(nameof(ReverseRoadOrder), value);
        }
        public int SearchDepth
        {
            get => (int)GetValue(nameof(SearchDepth));
            set => SetValue(nameof(SearchDepth), value);
        }
        public string Prefix
        {
            get => (string)GetValue(nameof(Prefix));
            set => SetValue(nameof(Prefix), value);
        }
        public string Suffix
        {
            get => (string)GetValue(nameof(Suffix));
            set => SetValue(nameof(Suffix), value);
        }
        public bool AutoUpdate
        {
            get => (bool)GetValue(nameof(AutoUpdate));
            set => SetValue(nameof(AutoUpdate), value);
        }
        public bool AutoNaming
        {
            get => (bool)GetValue(nameof(AutoNaming));
            set => SetValue(nameof(AutoNaming), value);
        }
        public bool ApplyXfixToStops
        {
            get => (bool)GetValue(nameof(ApplyXfixToStops));
            set => SetValue(nameof(ApplyXfixToStops), value);
        }
        public string StopPrefix
        {
            get => (string)GetValue(nameof(StopPrefix));
            set => SetValue(nameof(StopPrefix), value);
        }
        public string StopSuffix
        {
            get => (string)GetValue(nameof(StopSuffix));
            set => SetValue(nameof(StopSuffix), value);
        }
        public bool EnableDistrict
        {
            get => (bool)GetValue(nameof(EnableDistrict));
            set => SetValue(nameof(EnableDistrict), value);
        }
        public bool EnableDistrictPrefix
        {
            get => (bool)GetValue(nameof(EnableDistrictPrefix));
            set => SetValue(nameof(EnableDistrictPrefix), value);
        }

        //public string DistrictFormat
        //{
        //    get => (string)GetValue(nameof(DistrictFormat));
        //    set => SetValue(nameof(DistrictFormat), value);
        //}
        public bool BuildingName
        {
            get => (bool)GetValue(nameof(BuildingName));
            set => SetValue(nameof(BuildingName), value);
        }
        public bool BuildingNameWithCurrentRoad
        {
            get => (bool)GetValue(nameof(BuildingNameWithCurrentRoad));
            set => SetValue(nameof(BuildingNameWithCurrentRoad), value);
        }
        public bool SpawnableBuildingName
        {
            get => (bool)GetValue(nameof(SpawnableBuildingName));
            set => SetValue(nameof(SpawnableBuildingName), value);
        }
        public string AddressNameFormat
        {
            get => (string)GetValue(nameof(AddressNameFormat));
            set => SetValue(nameof(AddressNameFormat), value);
        }
        public string NamedAddressNameFormat
        {
            get => (string)GetValue(nameof(NamedAddressNameFormat));
            set => SetValue(nameof(NamedAddressNameFormat), value);
        }
        public bool OverrideVanillaAddress
        {
            get => (bool)GetValue(nameof(OverrideVanillaAddress));
            set => SetValue(nameof(OverrideVanillaAddress), value);
        }
        public bool TransportStopAutoNaming
        {
            get => (bool)GetValue(nameof(TransportStopAutoNaming));
            set => SetValue(nameof(TransportStopAutoNaming), value);
        }
        public bool TransportStationAutoNaming
        {
            get => (bool)GetValue(nameof(TransportStationAutoNaming));
            set => SetValue(nameof(TransportStationAutoNaming), value);
        }
        public bool TransportDepotAutoNaming
        {
            get => (bool)GetValue(nameof(TransportDepotAutoNaming));
            set => SetValue(nameof(TransportDepotAutoNaming), value);
        }
        public bool SchoolAutoNaming
        {
            get => (bool)GetValue(nameof(SchoolAutoNaming));
            set => SetValue(nameof(SchoolAutoNaming), value);
        }
        public bool FireStationAutoNaming
        {
            get => (bool)GetValue(nameof(FireStationAutoNaming));
            set => SetValue(nameof(FireStationAutoNaming), value);
        }
        public bool PoliceStationAutoNaming
        {
            get => (bool)GetValue(nameof(PoliceStationAutoNaming));
            set => SetValue(nameof(PoliceStationAutoNaming), value);
        }
        public bool HospitalAutoNaming
        {
            get => (bool)GetValue(nameof(HospitalAutoNaming));
            set => SetValue(nameof(HospitalAutoNaming), value);
        }
        public bool ParkAutoNaming
        {
            get => (bool)GetValue(nameof(ParkAutoNaming));
            set => SetValue(nameof(ParkAutoNaming), value);
        }
        public bool ElectricityAutoNaming
        {
            get => (bool)GetValue(nameof(ElectricityAutoNaming));
            set => SetValue(nameof(ElectricityAutoNaming), value);
        }
        public bool WaterAutoNaming
        {
            get => (bool)GetValue(nameof(WaterAutoNaming));
            set => SetValue(nameof(WaterAutoNaming), value);
        }
        public bool SewageAutoNaming
        {
            get => (bool)GetValue(nameof(SewageAutoNaming));
            set => SetValue(nameof(SewageAutoNaming), value);
        }
        public bool GarbageAutoNaming
        {
            get => (bool)GetValue(nameof(GarbageAutoNaming));
            set => SetValue(nameof(GarbageAutoNaming), value);
        }
        public bool DisasterAutoNaming
        {
            get => (bool)GetValue(nameof(DisasterAutoNaming));
            set => SetValue(nameof(DisasterAutoNaming), value);
        }
        public bool DeathcareAutoNaming
        {
            get => (bool)GetValue(nameof(DeathcareAutoNaming));
            set => SetValue(nameof(DeathcareAutoNaming), value);
        }
        public bool TelecomAutoNaming
        {
            get => (bool)GetValue(nameof(TelecomAutoNaming));
            set => SetValue(nameof(TelecomAutoNaming), value);
        }
        public bool PostAutoNaming
        {
            get => (bool)GetValue(nameof(PostAutoNaming));
            set => SetValue(nameof(PostAutoNaming), value);
        }
        public bool ParkingAutoNaming
        {
            get => (bool)GetValue(nameof(ParkingAutoNaming));
            set => SetValue(nameof(ParkingAutoNaming), value);
        }
        public bool RoadFacilityAutoNaming
        {
            get => (bool)GetValue(nameof(RoadFacilityAutoNaming));
            set => SetValue(nameof(RoadFacilityAutoNaming), value);
        }
        public bool AdminAutoNaming
        {
            get => (bool)GetValue(nameof(AdminAutoNaming));
            set => SetValue(nameof(AdminAutoNaming), value);
        }
    }

    public class StifferVehiclesSettings : SettingsBackup
    {
        public float StiffnessModifier
        {
            get => (float)GetValue(nameof(StiffnessModifier));
            set => SetValue(nameof(StiffnessModifier), value);
        }
        public float DampingModifier
        {
            get => (float)GetValue(nameof(DampingModifier));
            set => SetValue(nameof(DampingModifier), value);
        }
    }

    public class SunGlassesSettings : SettingsBackup
    {
        public float SunSize
        {
            get => (float)GetValue(nameof(SunSize));
            set => SetValue(nameof(SunSize), value);
        }
        public float SunLightIntensity
        {
            get => (float)GetValue(nameof(SunLightIntensity));
            set => SetValue(nameof(SunLightIntensity), value);
        }
        public bool LensFlare
        {
            get => (bool)GetValue(nameof(LensFlare));
            set => SetValue(nameof(LensFlare), value);
        }
        public float SunBloom
        {
            get => (float)GetValue(nameof(SunBloom));
            set => SetValue(nameof(SunBloom), value);
        }
        public float SkyExposure
        {
            get => (float)GetValue(nameof(SkyExposure));
            set => SetValue(nameof(SkyExposure), value);
        }
        public float IndirectDiffuseSunLighting
        {
            get => (float)GetValue(nameof(IndirectDiffuseSunLighting));
            set => SetValue(nameof(IndirectDiffuseSunLighting), value);
        }
        public int BrightenLevel
        {
            get => (int)GetValue(nameof(BrightenLevel));
            set => SetValue(nameof(BrightenLevel), value);
        }
        public bool Contra
        {
            get => (bool)GetValue(nameof(Contra));
            set => SetValue(nameof(Contra), value);
        }
    }

    public class TerraformHardeningSettings : SettingsBackup
    {
        public float TerraformingCostMultiplier
        {
            get => (float)GetValue(nameof(TerraformingCostMultiplier));
            set => SetValue(nameof(TerraformingCostMultiplier), value);
        }
    }

    public class ToggleOverlaysSettings : SettingsBackup
    {
        public bool OpenInfoViewWhenSelectingAsset
        {
            get => (bool)GetValue(nameof(OpenInfoViewWhenSelectingAsset));
            set => SetValue(nameof(OpenInfoViewWhenSelectingAsset), value);
        }
        public bool CloseInfoViewOnAssetChange
        {
            get => (bool)GetValue(nameof(CloseInfoViewOnAssetChange));
            set => SetValue(nameof(CloseInfoViewOnAssetChange), value);
        }
        public bool AutomaticallyOpenInfoView
        {
            get => (bool)GetValue(nameof(AutomaticallyOpenInfoView));
            set => SetValue(nameof(AutomaticallyOpenInfoView), value);
        }
        public bool AutomaticallySwitchInfoViewIfOpen
        {
            get => (bool)GetValue(nameof(AutomaticallySwitchInfoViewIfOpen));
            set => SetValue(nameof(AutomaticallySwitchInfoViewIfOpen), value);
        }
    }

    public class TradingCostTweakerSettings : SettingsBackup
    {
        public int ElectricityImportPrice
        {
            get => (int)GetValue(nameof(ElectricityImportPrice));
            set => SetValue(nameof(ElectricityImportPrice), value);
        }
        public int ElectricityExportPrice
        {
            get => (int)GetValue(nameof(ElectricityExportPrice));
            set => SetValue(nameof(ElectricityExportPrice), value);
        }
        public int WaterImportPrice
        {
            get => (int)GetValue(nameof(WaterImportPrice));
            set => SetValue(nameof(WaterImportPrice), value);
        }
        public int WaterExportPrice
        {
            get => (int)GetValue(nameof(WaterExportPrice));
            set => SetValue(nameof(WaterExportPrice), value);
        }
        public int WaterExportPollutionTolerance
        {
            get => (int)GetValue(nameof(WaterExportPollutionTolerance));
            set => SetValue(nameof(WaterExportPollutionTolerance), value);
        }
        public int SewageExportPrice
        {
            get => (int)GetValue(nameof(SewageExportPrice));
            set => SetValue(nameof(SewageExportPrice), value);
        }
        public int PopulationMultiplier
        {
            get => (int)GetValue(nameof(PopulationMultiplier));
            set => SetValue(nameof(PopulationMultiplier), value);
        }
        public double PopulationValue
        {
            get => (double)GetValue(nameof(PopulationValue));
            set => SetValue(nameof(PopulationValue), value);
        }
        public float PoliceFee
        {
            get => (float)GetValue(nameof(PoliceFee));
            set => SetValue(nameof(PoliceFee), value);
        }
        public float AmbulanceFee
        {
            get => (float)GetValue(nameof(AmbulanceFee));
            set => SetValue(nameof(AmbulanceFee), value);
        }
        public float HearseFee
        {
            get => (float)GetValue(nameof(HearseFee));
            set => SetValue(nameof(HearseFee), value);
        }
        public float FireEngineFee
        {
            get => (float)GetValue(nameof(FireEngineFee));
            set => SetValue(nameof(FireEngineFee), value);
        }
        public float GarbageFee
        {
            get => (float)GetValue(nameof(GarbageFee));
            set => SetValue(nameof(GarbageFee), value);
        }
        public float RoadWeightMultiplier
        {
            get => (float)GetValue(nameof(RoadWeightMultiplier));
            set => SetValue(nameof(RoadWeightMultiplier), value);
        }
        public float RoadDistanceMultiplier
        {
            get => (float)GetValue(nameof(RoadDistanceMultiplier));
            set => SetValue(nameof(RoadDistanceMultiplier), value);
        }
        public float TrainWeightMultiplier
        {
            get => (float)GetValue(nameof(TrainWeightMultiplier));
            set => SetValue(nameof(TrainWeightMultiplier), value);
        }
        public float TrainDistanceMultiplier
        {
            get => (float)GetValue(nameof(TrainDistanceMultiplier));
            set => SetValue(nameof(TrainDistanceMultiplier), value);
        }
        public float ShipWeightMultiplier
        {
            get => (float)GetValue(nameof(ShipWeightMultiplier));
            set => SetValue(nameof(ShipWeightMultiplier), value);
        }
        public float ShipDistanceMultiplier
        {
            get => (float)GetValue(nameof(ShipDistanceMultiplier));
            set => SetValue(nameof(ShipDistanceMultiplier), value);
        }
        public float AirWeightMultiplier
        {
            get => (float)GetValue(nameof(AirWeightMultiplier));
            set => SetValue(nameof(AirWeightMultiplier), value);
        }
        public float AirDistanceMultiplier
        {
            get => (float)GetValue(nameof(AirDistanceMultiplier));
            set => SetValue(nameof(AirDistanceMultiplier), value);
        }
    }

    public class TrafficSettings : SettingsBackup
    {
        public bool UseGameLanguage
        {
            get => (bool)GetValue(nameof(UseGameLanguage));
            set => SetValue(nameof(UseGameLanguage), value);
        }
        public string CurrentLocale
        {
            get => (string)GetValue(nameof(CurrentLocale));
            set => SetValue(nameof(CurrentLocale), value);
        }
        public float ConnectionLaneWidth
        {
            get => (float)GetValue(nameof(ConnectionLaneWidth));
            set => SetValue(nameof(ConnectionLaneWidth), value);
        }
        public float ConnectorSize
        {
            get => (float)GetValue(nameof(ConnectorSize));
            set => SetValue(nameof(ConnectorSize), value);
        }
        public float FeedbackOutlineWidth
        {
            get => (float)GetValue(nameof(FeedbackOutlineWidth));
            set => SetValue(nameof(FeedbackOutlineWidth), value);
        }
        public bool ShowConnectionsOverlayWhenEditing
        {
            get => (bool)GetValue(nameof(ShowConnectionsOverlayWhenEditing));
            set => SetValue(nameof(ShowConnectionsOverlayWhenEditing), value);
        }
        public bool UseVanillaToolActions
        {
            get => (bool)GetValue(nameof(UseVanillaToolActions));
            set => SetValue(nameof(UseVanillaToolActions), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class TrafficJamMonitorSettings : SettingsBackup
    {
        public int uiShowScale
        {
            get => (int)GetValue(nameof(uiShowScale));
            set => SetValue(nameof(uiShowScale), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class TrafficLightsEnhancementSettings : SettingsBackup
    {
        public string m_LocaleOption
        {
            get => (string)GetValue(nameof(m_LocaleOption));
            set => SetValue(nameof(m_LocaleOption), value);
        }
        public bool m_ShowFloatingButton
        {
            get => (bool)GetValue(nameof(m_ShowFloatingButton));
            set => SetValue(nameof(m_ShowFloatingButton), value);
        }
        public bool m_DefaultSplitPhasing
        {
            get => (bool)GetValue(nameof(m_DefaultSplitPhasing));
            set => SetValue(nameof(m_DefaultSplitPhasing), value);
        }
        public bool m_DefaultAlwaysGreenKerbsideTurn
        {
            get => (bool)GetValue(nameof(m_DefaultAlwaysGreenKerbsideTurn));
            set => SetValue(nameof(m_DefaultAlwaysGreenKerbsideTurn), value);
        }
        public bool m_DefaultExclusivePedestrian
        {
            get => (bool)GetValue(nameof(m_DefaultExclusivePedestrian));
            set => SetValue(nameof(m_DefaultExclusivePedestrian), value);
        }
        public bool m_HasReadLdtRetirementNotice
        {
            get => (bool)GetValue(nameof(m_HasReadLdtRetirementNotice));
            set => SetValue(nameof(m_HasReadLdtRetirementNotice), value);
        }
    }

    public class TrafficSimulationAdjusterSettings : SettingsBackup
    {
        public int TrafficReductionCoefficient
        {
            get => (int)GetValue(nameof(TrafficReductionCoefficient));
            set => SetValue(nameof(TrafficReductionCoefficient), value);
        }
    }

    public class TransitCapacityMultiplierSettings : SettingsBackup
    {
        public float BusSlider
        {
            get => (float)GetValue(nameof(BusSlider));
            set => SetValue(nameof(BusSlider), value);
        }
        public float TaxiSlider
        {
            get => (float)GetValue(nameof(TaxiSlider));
            set => SetValue(nameof(TaxiSlider), value);
        }
        public float TramSlider
        {
            get => (float)GetValue(nameof(TramSlider));
            set => SetValue(nameof(TramSlider), value);
        }
        public float TrainSlider
        {
            get => (float)GetValue(nameof(TrainSlider));
            set => SetValue(nameof(TrainSlider), value);
        }
        public float SubwaySlider
        {
            get => (float)GetValue(nameof(SubwaySlider));
            set => SetValue(nameof(SubwaySlider), value);
        }
        public float AirplaneSlider
        {
            get => (float)GetValue(nameof(AirplaneSlider));
            set => SetValue(nameof(AirplaneSlider), value);
        }
        public float ShipSlider
        {
            get => (float)GetValue(nameof(ShipSlider));
            set => SetValue(nameof(ShipSlider), value);
        }
    }

    public class TransportPolicyAdjusterSettings : SettingsBackup
    {
        public int Bus
        {
            get => (int)GetValue(nameof(Bus));
            set => SetValue(nameof(Bus), value);
        }
        public int Train
        {
            get => (int)GetValue(nameof(Train));
            set => SetValue(nameof(Train), value);
        }
        public int Tram
        {
            get => (int)GetValue(nameof(Tram));
            set => SetValue(nameof(Tram), value);
        }
        public int Ship
        {
            get => (int)GetValue(nameof(Ship));
            set => SetValue(nameof(Ship), value);
        }
        public int Airplane
        {
            get => (int)GetValue(nameof(Airplane));
            set => SetValue(nameof(Airplane), value);
        }
        public int Subway
        {
            get => (int)GetValue(nameof(Subway));
            set => SetValue(nameof(Subway), value);
        }
    }

    public class TreeControllerSettings : SettingsBackup
    {
        public bool UseDeadModelDuringWinter
        {
            get => (bool)GetValue(nameof(UseDeadModelDuringWinter));
            set => SetValue(nameof(UseDeadModelDuringWinter), value);
        }
        public bool DisableTreeGrowth
        {
            get => (bool)GetValue(nameof(DisableTreeGrowth));
            set => SetValue(nameof(DisableTreeGrowth), value);
        }
        public int AgeSelectionTechnique
        {
            get => (int)GetValue(nameof(AgeSelectionTechnique));
            set => SetValue(nameof(AgeSelectionTechnique), value);
        }
        public bool IncludeStumps
        {
            get => (bool)GetValue(nameof(IncludeStumps));
            set => SetValue(nameof(IncludeStumps), value);
        }
        public bool FasterFullBrushStrength
        {
            get => (bool)GetValue(nameof(FasterFullBrushStrength));
            set => SetValue(nameof(FasterFullBrushStrength), value);
        }
        public bool LimitedTreeAnarchy
        {
            get => (bool)GetValue(nameof(LimitedTreeAnarchy));
            set => SetValue(nameof(LimitedTreeAnarchy), value);
        }
        public int ColorVariationSet
        {
            get => (int)GetValue(nameof(ColorVariationSet));
            set => SetValue(nameof(ColorVariationSet), value);
        }
        public bool FreeVegetation
        {
            get => (bool)GetValue(nameof(FreeVegetation));
            set => SetValue(nameof(FreeVegetation), value);
        }
        public bool ConstrainBrush
        {
            get => (bool)GetValue(nameof(ConstrainBrush));
            set => SetValue(nameof(ConstrainBrush), value);
        }
        public int SelectedWindOption
        {
            get => (int)GetValue(nameof(SelectedWindOption));
            set => SetValue(nameof(SelectedWindOption), value);
        }
        public bool DisableWindWhenPaused
        {
            get => (bool)GetValue(nameof(DisableWindWhenPaused));
            set => SetValue(nameof(DisableWindWhenPaused), value);
        }
        public float WindGlobalStrength
        {
            get => (float)GetValue(nameof(WindGlobalStrength));
            set => SetValue(nameof(WindGlobalStrength), value);
        }
        public float WindGlobalStrength2
        {
            get => (float)GetValue(nameof(WindGlobalStrength2));
            set => SetValue(nameof(WindGlobalStrength2), value);
        }
        public float WindDirection
        {
            get => (float)GetValue(nameof(WindDirection));
            set => SetValue(nameof(WindDirection), value);
        }
        public float WindDirectionVariance
        {
            get => (float)GetValue(nameof(WindDirectionVariance));
            set => SetValue(nameof(WindDirectionVariance), value);
        }
        public float WindDirectionVariancePeriod
        {
            get => (float)GetValue(nameof(WindDirectionVariancePeriod));
            set => SetValue(nameof(WindDirectionVariancePeriod), value);
        }
        public float WindInterpolationDuration
        {
            get => (float)GetValue(nameof(WindInterpolationDuration));
            set => SetValue(nameof(WindInterpolationDuration), value);
        }
    }

    //public class TripsDataSettings : SettingsBackup
    //{
    //    public int numOutputs
    //    {
    //        get => (int)GetValue(nameof(numOutputs));
    //        set => SetValue(nameof(numOutputs), value);
    //    }
    //    public bool trip_type
    //    {
    //        get => (bool)GetValue(nameof(trip_type));
    //        set => SetValue(nameof(trip_type), value);
    //    }
    //    public bool citizen_purpose
    //    {
    //        get => (bool)GetValue(nameof(citizen_purpose));
    //        set => SetValue(nameof(citizen_purpose), value);
    //    }
    //    public bool avg_commute
    //    {
    //        get => (bool)GetValue(nameof(avg_commute));
    //        set => SetValue(nameof(avg_commute), value);
    //    }
    //    public bool cars
    //    {
    //        get => (bool)GetValue(nameof(cars));
    //        set => SetValue(nameof(cars), value);
    //    }
    //    public bool transit_passengers
    //    {
    //        get => (bool)GetValue(nameof(transit_passengers));
    //        set => SetValue(nameof(transit_passengers), value);
    //    }
    //    public bool transit_waiting
    //    {
    //        get => (bool)GetValue(nameof(transit_waiting));
    //        set => SetValue(nameof(transit_waiting), value);
    //    }
    //    public bool truck
    //    {
    //        get => (bool)GetValue(nameof(truck));
    //        set => SetValue(nameof(truck), value);
    //    }
    //    public bool smooth_speed
    //    {
    //        get => (bool)GetValue(nameof(smooth_speed));
    //        set => SetValue(nameof(smooth_speed), value);
    //    }
    //}

    public class VehicleControllerSettings : SettingsBackup
    {
        public int MotorbikeProbability
        {
            get => (int)GetValue(nameof(MotorbikeProbability));
            set => SetValue(nameof(MotorbikeProbability), value);
        }
        public int ScooterProbability
        {
            get => (int)GetValue(nameof(ScooterProbability));
            set => SetValue(nameof(ScooterProbability), value);
        }
        public int CityCarProbability
        {
            get => (int)GetValue(nameof(CityCarProbability));
            set => SetValue(nameof(CityCarProbability), value);
        }
        public int HatchbackProbability
        {
            get => (int)GetValue(nameof(HatchbackProbability));
            set => SetValue(nameof(HatchbackProbability), value);
        }
        public int MinivanProbability
        {
            get => (int)GetValue(nameof(MinivanProbability));
            set => SetValue(nameof(MinivanProbability), value);
        }
        public int SedanProbability
        {
            get => (int)GetValue(nameof(SedanProbability));
            set => SetValue(nameof(SedanProbability), value);
        }
        public int SportsCarProbability
        {
            get => (int)GetValue(nameof(SportsCarProbability));
            set => SetValue(nameof(SportsCarProbability), value);
        }
        public int PickupProbability
        {
            get => (int)GetValue(nameof(PickupProbability));
            set => SetValue(nameof(PickupProbability), value);
        }
        public int SUVProbability
        {
            get => (int)GetValue(nameof(SUVProbability));
            set => SetValue(nameof(SUVProbability), value);
        }
        public int MuscleCarProbability
        {
            get => (int)GetValue(nameof(MuscleCarProbability));
            set => SetValue(nameof(MuscleCarProbability), value);
        }
        public int VanProbability
        {
            get => (int)GetValue(nameof(VanProbability));
            set => SetValue(nameof(VanProbability), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class UrbanInequalitySettings : SettingsBackup
    {
        public int selectedCity
        {
            get => (int)GetValue(nameof(selectedCity));
            set => SetValue(nameof(selectedCity), value);
        }
        public float minIncomePenalty
        {
            get => (float)GetValue(nameof(minIncomePenalty));
            set => SetValue(nameof(minIncomePenalty), value);
        }
        public float minEducationPenalty
        {
            get => (float)GetValue(nameof(minEducationPenalty));
            set => SetValue(nameof(minEducationPenalty), value);
        }
        public float maxIncomePenalty
        {
            get => (float)GetValue(nameof(maxIncomePenalty));
            set => SetValue(nameof(maxIncomePenalty), value);
        }
        public float maxEducationPenalty
        {
            get => (float)GetValue(nameof(maxEducationPenalty));
            set => SetValue(nameof(maxEducationPenalty), value);
        }
        public float levelCap1
        {
            get => (float)GetValue(nameof(levelCap1));
            set => SetValue(nameof(levelCap1), value);
        }
        public float levelCap2
        {
            get => (float)GetValue(nameof(levelCap2));
            set => SetValue(nameof(levelCap2), value);
        }
        public float levelCap3
        {
            get => (float)GetValue(nameof(levelCap3));
            set => SetValue(nameof(levelCap3), value);
        }
        public float levelCap4
        {
            get => (float)GetValue(nameof(levelCap4));
            set => SetValue(nameof(levelCap4), value);
        }
        public float levelCap5
        {
            get => (float)GetValue(nameof(levelCap5));
            set => SetValue(nameof(levelCap5), value);
        }
        public int wageLevel1
        {
            get => (int)GetValue(nameof(wageLevel1));
            set => SetValue(nameof(wageLevel1), value);
        }
        public int wageLevel2
        {
            get => (int)GetValue(nameof(wageLevel2));
            set => SetValue(nameof(wageLevel2), value);
        }
        public int wageLevel3
        {
            get => (int)GetValue(nameof(wageLevel3));
            set => SetValue(nameof(wageLevel3), value);
        }
        public int wageLevel4
        {
            get => (int)GetValue(nameof(wageLevel4));
            set => SetValue(nameof(wageLevel4), value);
        }
        public int wageLevel5
        {
            get => (int)GetValue(nameof(wageLevel5));
            set => SetValue(nameof(wageLevel5), value);
        }
    }

    public class VehicleVariationPacksSettings : SettingsBackup
    {
        public string PackDropdown
        {
            get => (string)GetValue(nameof(PackDropdown));
            set => SetValue(nameof(PackDropdown), value);
        }
    }

    public class WaterFeaturesSettings : SettingsBackup
    {
        public bool TrySmallerRadii
        {
            get => (bool)GetValue(nameof(TrySmallerRadii));
            set => SetValue(nameof(TrySmallerRadii), value);
        }
        public bool IncludeDetentionBasins
        {
            get => (bool)GetValue(nameof(IncludeDetentionBasins));
            set => SetValue(nameof(IncludeDetentionBasins), value);
        }
        public bool IncludeRetentionBasins
        {
            get => (bool)GetValue(nameof(IncludeRetentionBasins));
            set => SetValue(nameof(IncludeRetentionBasins), value);
        }
        public float EvaporationRate
        {
            get => (float)GetValue(nameof(EvaporationRate));
            set => SetValue(nameof(EvaporationRate), value);
        }
        public bool EnableSeasonalStreams
        {
            get => (bool)GetValue(nameof(EnableSeasonalStreams));
            set => SetValue(nameof(EnableSeasonalStreams), value);
        }
        public bool SimulateSnowMelt
        {
            get => (bool)GetValue(nameof(SimulateSnowMelt));
            set => SetValue(nameof(SimulateSnowMelt), value);
        }
        public float ConstantFlowRate
        {
            get => (float)GetValue(nameof(ConstantFlowRate));
            set => SetValue(nameof(ConstantFlowRate), value);
        }
        public float StreamSeasonality
        {
            get => (float)GetValue(nameof(StreamSeasonality));
            set => SetValue(nameof(StreamSeasonality), value);
        }
        public float StreamStormwaterEffects
        {
            get => (float)GetValue(nameof(StreamStormwaterEffects));
            set => SetValue(nameof(StreamStormwaterEffects), value);
        }
        public float MinimumMultiplier
        {
            get => (float)GetValue(nameof(MinimumMultiplier));
            set => SetValue(nameof(MinimumMultiplier), value);
        }
        public float MaximumMultiplier
        {
            get => (float)GetValue(nameof(MaximumMultiplier));
            set => SetValue(nameof(MaximumMultiplier), value);
        }
        public bool EnableWavesAndTides
        {
            get => (bool)GetValue(nameof(EnableWavesAndTides));
            set => SetValue(nameof(EnableWavesAndTides), value);
        }
        public float WaveHeight
        {
            get => (float)GetValue(nameof(WaveHeight));
            set => SetValue(nameof(WaveHeight), value);
        }
        public float WaveFrequency
        {
            get => (float)GetValue(nameof(WaveFrequency));
            set => SetValue(nameof(WaveFrequency), value);
        }
        public float TideHeight
        {
            get => (float)GetValue(nameof(TideHeight));
            set => SetValue(nameof(TideHeight), value);
        }
        public int TideClassification
        {
            get => (int)GetValue(nameof(TideClassification));
            set => SetValue(nameof(TideClassification), value);
        }
        public float Damping
        {
            get => (float)GetValue(nameof(Damping));
            set => SetValue(nameof(Damping), value);
        }
        public float Fluidness
        {
            get => (float)GetValue(nameof(Fluidness));
            set => SetValue(nameof(Fluidness), value);
        }
        public bool WaterToolSettingsAffectEditorSimulation
        {
            get => (bool)GetValue(nameof(WaterToolSettingsAffectEditorSimulation));
            set => SetValue(nameof(WaterToolSettingsAffectEditorSimulation), value);
        }
        //public bool SeasonalStreamsAffectEditorSimulation
        //{
        //    get => (bool)GetValue(nameof(SeasonalStreamsAffectEditorSimulation));
        //    set => SetValue(nameof(SeasonalStreamsAffectEditorSimulation), value);
        //}
        //public bool WavesAndTidesAffectEditorSimulation
        //{
        //    get => (bool)GetValue(nameof(WavesAndTidesAffectEditorSimulation));
        //    set => SetValue(nameof(WavesAndTidesAffectEditorSimulation), value);
        //}
    }

    public class WaterVisualTweaksSettings : SettingsBackup
    {
        public bool SimulationOverrideEnable
        {
            get => (bool)GetValue(nameof(SimulationOverrideEnable));
            set => SetValue(nameof(SimulationOverrideEnable), value);
        }
        public float RipplesWindSpeed
        {
            get => (float)GetValue(nameof(RipplesWindSpeed));
            set => SetValue(nameof(RipplesWindSpeed), value);
        }
        public float Large1WindSpeed
        {
            get => (float)GetValue(nameof(Large1WindSpeed));
            set => SetValue(nameof(Large1WindSpeed), value);
        }
        public float Large0WindSpeed
        {
            get => (float)GetValue(nameof(Large0WindSpeed));
            set => SetValue(nameof(Large0WindSpeed), value);
        }
        public float RipplesPatchSize
        {
            get => (float)GetValue(nameof(RipplesPatchSize));
            set => SetValue(nameof(RipplesPatchSize), value);
        }
        public float Large1PatchSize
        {
            get => (float)GetValue(nameof(Large1PatchSize));
            set => SetValue(nameof(Large1PatchSize), value);
        }
        public float Large0PatchSize
        {
            get => (float)GetValue(nameof(Large0PatchSize));
            set => SetValue(nameof(Large0PatchSize), value);
        }
        public float RipplesAmplitudeMultiplier
        {
            get => (float)GetValue(nameof(RipplesAmplitudeMultiplier));
            set => SetValue(nameof(RipplesAmplitudeMultiplier), value);
        }
        public float Large1AmplitudeMultiplier
        {
            get => (float)GetValue(nameof(Large1AmplitudeMultiplier));
            set => SetValue(nameof(Large1AmplitudeMultiplier), value);
        }
        public float Large0AmplitudeMultiplier
        {
            get => (float)GetValue(nameof(Large0AmplitudeMultiplier));
            set => SetValue(nameof(Large0AmplitudeMultiplier), value);
        }
        public float StartSmoothness
        {
            get => (float)GetValue(nameof(StartSmoothness));
            set => SetValue(nameof(StartSmoothness), value);
        }
        public float EndSmoothness
        {
            get => (float)GetValue(nameof(EndSmoothness));
            set => SetValue(nameof(EndSmoothness), value);
        }
        public float AbsorptionDistance
        {
            get => (float)GetValue(nameof(AbsorptionDistance));
            set => SetValue(nameof(AbsorptionDistance), value);
        }
        public float RefractionColorR
        {
            get => (float)GetValue(nameof(RefractionColorR));
            set => SetValue(nameof(RefractionColorR), value);
        }
        public float RefractionColorG
        {
            get => (float)GetValue(nameof(RefractionColorG));
            set => SetValue(nameof(RefractionColorG), value);
        }
        public float RefractionColorB
        {
            get => (float)GetValue(nameof(RefractionColorB));
            set => SetValue(nameof(RefractionColorB), value);
        }
        public float ScatteringColorR
        {
            get => (float)GetValue(nameof(ScatteringColorR));
            set => SetValue(nameof(ScatteringColorR), value);
        }
        public float ScatteringColorG
        {
            get => (float)GetValue(nameof(ScatteringColorG));
            set => SetValue(nameof(ScatteringColorG), value);
        }
        public float ScatteringColorB
        {
            get => (float)GetValue(nameof(ScatteringColorB));
            set => SetValue(nameof(ScatteringColorB), value);
        }
        public bool CausticsUseRippleBand
        {
            get => (bool)GetValue(nameof(CausticsUseRippleBand));
            set => SetValue(nameof(CausticsUseRippleBand), value);
        }
        public float CausticsIntensity
        {
            get => (float)GetValue(nameof(CausticsIntensity));
            set => SetValue(nameof(CausticsIntensity), value);
        }
        public float CausticsVirtualPlaneDistance
        {
            get => (float)GetValue(nameof(CausticsVirtualPlaneDistance));
            set => SetValue(nameof(CausticsVirtualPlaneDistance), value);
        }
    }

    public class WhitenessToggleSettings : SettingsBackup
    {
        public bool ToggleWhiteness
        {
            get => (bool)GetValue(nameof(ToggleWhiteness));
            set => SetValue(nameof(ToggleWhiteness), value);
        }
        public bool ToggleOverlay
        {
            get => (bool)GetValue(nameof(ToggleOverlay));
            set => SetValue(nameof(ToggleOverlay), value);
        }
        public int Red
        {
            get => (int)GetValue(nameof(Red));
            set => SetValue(nameof(Red), value);
        }
        public int Green
        {
            get => (int)GetValue(nameof(Green));
            set => SetValue(nameof(Green), value);
        }
        public int Blue
        {
            get => (int)GetValue(nameof(Blue));
            set => SetValue(nameof(Blue), value);
        }
        public int Alpha
        {
            get => (int)GetValue(nameof(Alpha));
            set => SetValue(nameof(Alpha), value);
        }
    }

    public class WriteEverywhereSettings : SettingsBackup
    {
        public int StartTextureSizeFont
        {
            get => (int)GetValue(nameof(StartTextureSizeFont));
            set => SetValue(nameof(StartTextureSizeFont), value);
        }
        public int FontQuality
        {
            get => (int)GetValue(nameof(FontQuality));
            set => SetValue(nameof(FontQuality), value);
        }
        public int FramesCheckUpdate
        {
            get => (int)GetValue(nameof(FramesCheckUpdate));
            set => SetValue(nameof(FramesCheckUpdate), value);
        }
        public string LocaleFomatting
        {
            get => (string)GetValue(nameof(LocaleFomatting));
            set => SetValue(nameof(LocaleFomatting), value);
        }
    }

    public class ZoneColorChangerSettings : SettingsBackup
    {
        public bool RecolorIcons
        {
            get => (bool)GetValue(nameof(RecolorIcons));
            set => SetValue(nameof(RecolorIcons), value);
        }
        public bool GroupThemes
        {
            get => (bool)GetValue(nameof(GroupThemes));
            set => SetValue(nameof(GroupThemes), value);
        }
    }
}
