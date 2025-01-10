// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Game.Settings;
using System.Collections.Generic;

namespace SimpleModChecker.Systems
{
    public interface ISettingsBackup
    {
        void SetValue(string property, object value);
        object GetValue(string property);
    }

    public class SettingsBackup : ISettingsBackup
    {
        private Dictionary<string, object> SettingsItems = [];

        public void SetValue(string property, object value)
        {
            SettingsItems[property] = value;
        }

        public object GetValue(string property)
        {
            return SettingsItems.ContainsKey(property) ? SettingsItems[property] : null;
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
        public bool EnableLocalAssetPacks
        {
            get => (bool)GetValue(nameof(EnableLocalAssetPacks));
            set => SetValue(nameof(EnableLocalAssetPacks), value);
        }
        public bool EnableSubscribedAssetPacks
        {
            get => (bool)GetValue(nameof(EnableSubscribedAssetPacks));
            set => SetValue(nameof(EnableSubscribedAssetPacks), value);
        }
        public bool EnableAssetPackLoadingOnStartup
        {
            get => (bool)GetValue(nameof(EnableAssetPackLoadingOnStartup));
            set => SetValue(nameof(EnableAssetPackLoadingOnStartup), value);
        }
        public bool AdaptiveAssetLoading
        {
            get => (bool)GetValue(nameof(AdaptiveAssetLoading));
            set => SetValue(nameof(AdaptiveAssetLoading), value);
        }
        public bool DisableSettingsWarning
        {
            get => (bool)GetValue(nameof(DisableSettingsWarning));
            set => SetValue(nameof(DisableSettingsWarning), value);
        }
        public bool DisableTelemetry
        {
            get => (bool)GetValue(nameof(DisableTelemetry));
            set => SetValue(nameof(DisableTelemetry), value);
        }
        public bool AutoHideNotifications
        {
            get => (bool)GetValue(nameof(AutoHideNotifications));
            set => SetValue(nameof(AutoHideNotifications), value);
        }
        public bool ShowWarningForLocalAssets
        {
            get => (bool)GetValue(nameof(ShowWarningForLocalAssets));
            set => SetValue(nameof(ShowWarningForLocalAssets), value);
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
        public bool enableDefault
        {
            get => (bool)GetValue(nameof(enableDefault));
            set => SetValue(nameof(enableDefault), value);
        }
        public string separator
        {
            get => (string)GetValue(nameof(separator));
            set => SetValue(nameof(separator), value);
        }
        public int textFormat
        {
            get => (int)GetValue(nameof(textFormat));
            set => SetValue(nameof(textFormat), value);
        }
        public bool enableVerbose
        {
            get => (bool)GetValue(nameof(enableVerbose));
            set => SetValue(nameof(enableVerbose), value);
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

    public class DemandMasterSettings : SettingsBackup
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
        public float TaxEffect
        {
            get => (float)GetValue(nameof(TaxEffect));
            set => SetValue(nameof(TaxEffect), value);
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
        public float FreeCommercialProportion
        {
            get => (float)GetValue(nameof(FreeCommercialProportion));
            set => SetValue(nameof(FreeCommercialProportion), value);
        }
        public float FreeIndustrialProportion
        {
            get => (float)GetValue(nameof(FreeIndustrialProportion));
            set => SetValue(nameof(FreeIndustrialProportion), value);
        }
        public float CommercialStorageMinimum
        {
            get => (float)GetValue(nameof(CommercialStorageMinimum));
            set => SetValue(nameof(CommercialStorageMinimum), value);
        }
        public float CommercialStorageEffect
        {
            get => (float)GetValue(nameof(CommercialStorageEffect));
            set => SetValue(nameof(CommercialStorageEffect), value);
        }
        public float CommercialBaseDemand
        {
            get => (float)GetValue(nameof(CommercialBaseDemand));
            set => SetValue(nameof(CommercialBaseDemand), value);
        }
        public float IndustrialStorageMinimum
        {
            get => (float)GetValue(nameof(IndustrialStorageMinimum));
            set => SetValue(nameof(IndustrialStorageMinimum), value);
        }
        public float IndustrialStorageEffect
        {
            get => (float)GetValue(nameof(IndustrialStorageEffect));
            set => SetValue(nameof(IndustrialStorageEffect), value);
        }
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
        public float StorageDemandMultiplier
        {
            get => (float)GetValue(nameof(StorageDemandMultiplier));
            set => SetValue(nameof(StorageDemandMultiplier), value);
        }
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
        public bool HideLocaleAssets
        {
            get => (bool)GetValue(nameof(HideLocaleAssets));
            set => SetValue(nameof(HideLocaleAssets), value);
        }
        public string SelectedModDropDown
        {
            get => (string)GetValue(nameof(SelectedModDropDown));
            set => SetValue(nameof(SelectedModDropDown), value);
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

    public class InfoLoomTwoSettings : SettingsBackup
    {
        public float TaxRateEffect
        {
            get => (float)GetValue(nameof(TaxRateEffect));
            set => SetValue(nameof(TaxRateEffect), value);
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
        public bool night_trucks
        {
            get => (bool)GetValue(nameof(night_trucks));
            set => SetValue(nameof(night_trucks), value);
        }
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
    }

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
        public int find_property_limit_factor
        {
            get => (int)GetValue(nameof(find_property_limit_factor));
            set => SetValue(nameof(find_property_limit_factor), value);
        }
        public bool find_property_night
        {
            get => (bool)GetValue(nameof(find_property_night));
            set => SetValue(nameof(find_property_night), value);
        }
    }

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
        public int adult_age_limit
        {
            get => (int)GetValue(nameof(adult_age_limit));
            set => SetValue(nameof(adult_age_limit), value);
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
    }

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
        public bool SeasonalStreamsAffectEditorSimulation
        {
            get => (bool)GetValue(nameof(SeasonalStreamsAffectEditorSimulation));
            set => SetValue(nameof(SeasonalStreamsAffectEditorSimulation), value);
        }
        public bool WavesAndTidesAffectEditorSimulation
        {
            get => (bool)GetValue(nameof(WavesAndTidesAffectEditorSimulation));
            set => SetValue(nameof(WavesAndTidesAffectEditorSimulation), value);
        }
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

    public class ModSettings
    {
        public string ModVersion { get; set; }
        public string LastUpdated { get; set; }
        public AdvancedSimulationSpeedSettings AdvancedSimulationSpeedSettings { get; set; }
        public AllAboardSettings AllAboardSettings { get; set; }
        public AnarchySettings AnarchySettings { get; set; }
        public AreaBucketSettings AreaBucketSettings { get; set; }
        public AssetIconLibrarySettings AssetIconLibrarySettings { get; set; }
        public AssetPacksManagerSettings AssetPacksManagerSettings { get; set; }
        public AssetVariationChangerSettings AssetVariationChangerSettings { get; set; }
        public AutoDistrictNameStationsSettings AutoDistrictNameStationsSettings { get; set; }
        public AutoVehicleRenamerSettings AutoVehicleRenamerSettings { get; set; }
        public BetterBulldozerSettings BetterBulldozerSettings { get; set; }
        public BetterMoonLightSettings BetterMoonLightSettings { get; set; }
        public BetterSaveListSettings BetterSaveListSettings { get; set; }
        public BoundaryLinesModifierSettings BoundaryLinesModifierSettings { get; set; }
        public BrushSizeUnlimiterSettings BrushSizeUnlimiterSettings { get; set; }
        public CimRouteHighlighterSettings CimRouteHighlighterSettings { get; set; }
        public CitizenModelManagerSettings CitizenModelManagerSettings { get; set; }
        public CityStatsSettings CityStatsSettings { get; set; }
        public DemandMasterSettings DemandMasterSettings { get; set; }
        public DepotCapacityChangerSettings DepotCapacityChangerSettings { get; set; }
        public ExtendedTooltipSettings ExtendedTooltipSettings { get; set; }
        public ExtraAssetsImporterSettings ExtraAssetsImporterSettings { get; set; }
        public FindItSettings FindItSettings { get; set; }
        public FirstPersonCameraContinuedSettings FirstPersonCameraContinuedSettings { get; set; }
        public FiveTwentyNineTilesSettings FiveTwentyNineTilesSettings { get; set; }
        public FPSLimiterSettings FPSLimiterSettings { get; set; }
        public HallOfFameSettings HallOfFameSettings { get; set; }
        public HistoricalStartSettings HistoricalStartSettings { get; set; }
        public I18NEverywhereSettings I18NEverywhereSettings { get; set; }
        public ImageOverlaySettings ImageOverlaySettings { get; set; }
        public InfoLoomTwoSettings InfoLoomTwoSettings { get; set; }
        public MoveItSettings MoveItSettings { get; set; }
        public NoPollutionSettings NoPollutionSettings { get; set; }
        public NoTeleportingSettings NoTeleportingSettings { get; set; }
        public NoVehicleDespawnSettings NoVehicleDespawnSettings { get; set; }
        public PathfindingCustomizerSettings PathfindingCustomizerSettings { get; set; }
        public PlopTheGrowablesSettings PlopTheGrowablesSettings { get; set; }
        public RealisticParkingSettings RealisticParkingSettings { get; set; }
        public RealisticTripsSettings RealisticTripsSettings { get; set; }
        public RealisticWorkplacesAndHouseholdsSettings RealisticWorkplacesAndHouseholdsSettings { get; set; }
        public RealLifeSettings RealLifeSettings { get; set; }
        public RecolorSettings RecolorSettings { get; set; }
        public RoadBuilderSettings RoadBuilderSettings { get; set; }
        public RoadNameRemoverSettings RoadNameRemoverSettings { get; set; }
        public RoadWearAdjusterSettings RoadWearAdjusterSettings { get; set; }
        public SchoolCapacityBalancerSettings SchoolCapacityBalancerSettings { get; set; }
        public SimpleModCheckerSettings SimpleModCheckerSettings { get; set; }
        public SmartTransportationSettings SmartTransportationSettings { get; set; }
        public StationNamingSettings StationNamingSettings { get; set; }
        public StifferVehiclesSettings StifferVehiclesSettings { get; set; }
        public SunGlassesSettings SunGlassesSettings { get; set; }
        public ToggleOverlaysSettings ToggleOverlaysSettings { get; set; }
        public TradingCostTweakerSettings TradingCostTweakerSettings { get; set; }
        public TrafficLightsEnhancementSettings TrafficLightsEnhancementSettings { get; set; }
        public TrafficSettings TrafficSettings { get; set; }
        public TrafficSimulationAdjusterSettings TrafficSimulationAdjusterSettings { get; set; }
        public TransitCapacityMultiplierSettings TransitCapacityMultiplierSettings { get; set; }
        public TransportPolicyAdjusterSettings TransportPolicyAdjusterSettings { get; set; }
        public TreeControllerSettings TreeControllerSettings { get; set; }
        //public TripsDataSettings TripsDataSettings { get; set; }
        public VehicleVariationPacksSettings VehicleVariationPacksSettings { get; set; }
        public WaterFeaturesSettings WaterFeaturesSettings { get; set; }
        public WaterVisualTweaksSettings WaterVisualTweaksSettings { get; set; }
        public WhitenessToggleSettings WhitenessToggleSettings { get; set; }
        public ZoneColorChangerSettings ZoneColorChangerSettings { get; set; }
    }
}
