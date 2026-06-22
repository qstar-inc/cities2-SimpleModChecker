using System.Globalization;
using Game.Settings;
using Unity.Mathematics;

namespace SimpleModCheckerPlus.Systems
{
    public class AdjustSchoolCapacitySettings : SettingsBackup
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
    }

    public class AdjustTransitSettings : SettingsBackup
    {
        //public bool EnableDebugLogging
        //{
        //    get => (bool)GetValue(nameof(EnableDebugLogging));
        //    set => SetValue(nameof(EnableDebugLogging), value);
        //}
        public bool EnableLineVehicleCountTuner
        {
            get => (bool)GetValue(nameof(EnableLineVehicleCountTuner));
            set => SetValue(nameof(EnableLineVehicleCountTuner), value);
        }
        public float BusDepotScalar
        {
            get => (float)GetValue(nameof(BusDepotScalar));
            set => SetValue(nameof(BusDepotScalar), value);
        }
        public float FerryDepotScalar
        {
            get => (float)GetValue(nameof(FerryDepotScalar));
            set => SetValue(nameof(FerryDepotScalar), value);
        }
        public float SubwayDepotScalar
        {
            get => (float)GetValue(nameof(SubwayDepotScalar));
            set => SetValue(nameof(SubwayDepotScalar), value);
        }
        public float TaxiDepotScalar
        {
            get => (float)GetValue(nameof(TaxiDepotScalar));
            set => SetValue(nameof(TaxiDepotScalar), value);
        }
        public float TrainDepotScalar
        {
            get => (float)GetValue(nameof(TrainDepotScalar));
            set => SetValue(nameof(TrainDepotScalar), value);
        }
        public float TramDepotScalar
        {
            get => (float)GetValue(nameof(TramDepotScalar));
            set => SetValue(nameof(TramDepotScalar), value);
        }
        public float BusPassengerScalar
        {
            get => (float)GetValue(nameof(BusPassengerScalar));
            set => SetValue(nameof(BusPassengerScalar), value);
        }
        public float TramPassengerScalar
        {
            get => (float)GetValue(nameof(TramPassengerScalar));
            set => SetValue(nameof(TramPassengerScalar), value);
        }
        public float TrainPassengerScalar
        {
            get => (float)GetValue(nameof(TrainPassengerScalar));
            set => SetValue(nameof(TrainPassengerScalar), value);
        }
        public float SubwayPassengerScalar
        {
            get => (float)GetValue(nameof(SubwayPassengerScalar));
            set => SetValue(nameof(SubwayPassengerScalar), value);
        }
        public float ShipPassengerScalar
        {
            get => (float)GetValue(nameof(ShipPassengerScalar));
            set => SetValue(nameof(ShipPassengerScalar), value);
        }
        public float FerryPassengerScalar
        {
            get => (float)GetValue(nameof(FerryPassengerScalar));
            set => SetValue(nameof(FerryPassengerScalar), value);
        }
        public float AirplanePassengerScalar
        {
            get => (float)GetValue(nameof(AirplanePassengerScalar));
            set => SetValue(nameof(AirplanePassengerScalar), value);
        }
    }

    public class AdvancedLineToolSettings : SettingsBackup
    {
        public float GuidelineTransparency
        {
            get => (float)GetValue(nameof(GuidelineTransparency));
            set => SetValue(nameof(GuidelineTransparency), value);
        }
    }

    public class AdvancedRoadNamingSettings : SettingsBackup
    {
        public string BaseRouteSeparator
        {
            get => (string)GetValue(nameof(BaseRouteSeparator));
            set => SetValue(nameof(BaseRouteSeparator), value);
        }
        public string RouteNumberSeparator
        {
            get => (string)GetValue(nameof(RouteNumberSeparator));
            set => SetValue(nameof(RouteNumberSeparator), value);
        }
        public bool AllowMultipleRouteNumbers
        {
            get => (bool)GetValue(nameof(AllowMultipleRouteNumbers));
            set => SetValue(nameof(AllowMultipleRouteNumbers), value);
        }
        public int OrderingMode
        {
            get => (int)GetValue(nameof(OrderingMode));
            set => SetValue(nameof(OrderingMode), value);
        }
        public bool ShowAdvancedRouteDetails
        {
            get => (bool)GetValue(nameof(ShowAdvancedRouteDetails));
            set => SetValue(nameof(ShowAdvancedRouteDetails), value);
        }

        //public bool EnableLogging
        //{
        //    get => (bool)GetValue(nameof(EnableLogging));
        //    set => SetValue(nameof(EnableLogging), value);
        //}
        public bool CombineRoadAggregates
        {
            get => (bool)GetValue(nameof(CombineRoadAggregates));
            set => SetValue(nameof(CombineRoadAggregates), value);
        }
        //public bool CombineRoadAggregatesDefaultMigrated
        //{
        //    get => (bool)GetValue(nameof(CombineRoadAggregatesDefaultMigrated));
        //    set => SetValue(nameof(CombineRoadAggregatesDefaultMigrated), value);
        //}
    }

    public class AdvancedSimulationSpeedSettings : SettingsBackup
    {
        public int Type
        {
            get => (int)GetValue(nameof(Type));
            set => SetValue(nameof(Type), value);
        }
        public float Step
        {
            get => (float)GetValue(nameof(Step));
            set => SetValue(nameof(Step), value);
        }
        public bool ActualSpeed
        {
            get => (bool)GetValue(nameof(ActualSpeed));
            set => SetValue(nameof(ActualSpeed), value);
        }
        public int DecimalPlaces
        {
            get => (int)GetValue(nameof(DecimalPlaces));
            set => SetValue(nameof(DecimalPlaces), value);
        }
    }

    public class AdvancedTPMSettings : SettingsBackup
    {
        public int DefaultGlobalTaxRate
        {
            get => (int)GetValue(nameof(DefaultGlobalTaxRate));
            set => SetValue(nameof(DefaultGlobalTaxRate), value);
        }
        public bool ShowTopLeftButton
        {
            get => (bool)GetValue(nameof(ShowTopLeftButton));
            set => SetValue(nameof(ShowTopLeftButton), value);
        }
        public int UpdateSpeed
        {
            get => (int)GetValue(nameof(UpdateSpeed));
            set => SetValue(nameof(UpdateSpeed), value);
        }
        public int AdvancedWindowX
        {
            get => (int)GetValue(nameof(AdvancedWindowX));
            set => SetValue(nameof(AdvancedWindowX), value);
        }
        public int AdvancedWindowY
        {
            get => (int)GetValue(nameof(AdvancedWindowY));
            set => SetValue(nameof(AdvancedWindowY), value);
        }
        public int AdvancedWindowWidth
        {
            get => (int)GetValue(nameof(AdvancedWindowWidth));
            set => SetValue(nameof(AdvancedWindowWidth), value);
        }
        public int AdvancedWindowHeight
        {
            get => (int)GetValue(nameof(AdvancedWindowHeight));
            set => SetValue(nameof(AdvancedWindowHeight), value);
        }
        public bool AutoTaxEnabled
        {
            get => (bool)GetValue(nameof(AutoTaxEnabled));
            set => SetValue(nameof(AutoTaxEnabled), value);
        }
        public int AutoTaxInterval
        {
            get => (int)GetValue(nameof(AutoTaxInterval));
            set => SetValue(nameof(AutoTaxInterval), value);
        }
        public int AutoTaxMinRate
        {
            get => (int)GetValue(nameof(AutoTaxMinRate));
            set => SetValue(nameof(AutoTaxMinRate), value);
        }
        public int AutoTaxMaxRate
        {
            get => (int)GetValue(nameof(AutoTaxMaxRate));
            set => SetValue(nameof(AutoTaxMaxRate), value);
        }
        public int AutoTaxHappinessWeight
        {
            get => (int)GetValue(nameof(AutoTaxHappinessWeight));
            set => SetValue(nameof(AutoTaxHappinessWeight), value);
        }
        public string AutoTaxExcludedResources
        {
            get => (string)GetValue(nameof(AutoTaxExcludedResources));
            set => SetValue(nameof(AutoTaxExcludedResources), value);
        }
        public string AutoTaxPerResourceRanges
        {
            get => (string)GetValue(nameof(AutoTaxPerResourceRanges));
            set => SetValue(nameof(AutoTaxPerResourceRanges), value);
        }
        public int AutoTaxProfitWeight
        {
            get => (int)GetValue(nameof(AutoTaxProfitWeight));
            set => SetValue(nameof(AutoTaxProfitWeight), value);
        }
        public int AutoTaxPanelOpacity
        {
            get => (int)GetValue(nameof(AutoTaxPanelOpacity));
            set => SetValue(nameof(AutoTaxPanelOpacity), value);
        }
        public bool AdaptiveLearningEnabled
        {
            get => (bool)GetValue(nameof(AdaptiveLearningEnabled));
            set => SetValue(nameof(AdaptiveLearningEnabled), value);
        }
        public int LearningAggressiveness
        {
            get => (int)GetValue(nameof(LearningAggressiveness));
            set => SetValue(nameof(LearningAggressiveness), value);
        }
        public bool ShowAdvisorPanel
        {
            get => (bool)GetValue(nameof(ShowAdvisorPanel));
            set => SetValue(nameof(ShowAdvisorPanel), value);
        }
        public bool UseGameZoneIcons
        {
            get => (bool)GetValue(nameof(UseGameZoneIcons));
            set => SetValue(nameof(UseGameZoneIcons), value);
        }

        //public bool DebugEnabled
        //{
        //    get => (bool)GetValue(nameof(DebugEnabled));
        //    set => SetValue(nameof(DebugEnabled), value);
        //}
        //public bool ShowDebugPanel
        //{
        //    get => (bool)GetValue(nameof(ShowDebugPanel));
        //    set => SetValue(nameof(ShowDebugPanel), value);
        //}
        public bool ShowTips
        {
            get => (bool)GetValue(nameof(ShowTips));
            set => SetValue(nameof(ShowTips), value);
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
        public bool ElevationLock
        {
            get => (bool)GetValue(nameof(ElevationLock));
            set => SetValue(nameof(ElevationLock), value);
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

    public class AreaOfEffectSettings : SettingsBackup
    {
        public bool IsEnabled
        {
            get => (bool)GetValue(nameof(IsEnabled));
            set => SetValue(nameof(IsEnabled), value);
        }
        public int Opacity
        {
            get => (int)GetValue(nameof(Opacity));
            set => SetValue(nameof(Opacity), value);
        }
        public int Preset
        {
            get => (int)GetValue(nameof(Preset));
            set => SetValue(nameof(Preset), value);
        }
        public int GlobalCircleSize
        {
            get => (int)GetValue(nameof(GlobalCircleSize));
            set => SetValue(nameof(GlobalCircleSize), value);
        }
        public int OverlayHeight
        {
            get => (int)GetValue(nameof(OverlayHeight));
            set => SetValue(nameof(OverlayHeight), value);
        }
        public int LabelDistance
        {
            get => (int)GetValue(nameof(LabelDistance));
            set => SetValue(nameof(LabelDistance), value);
        }
        public int BubbleSize
        {
            get => (int)GetValue(nameof(BubbleSize));
            set => SetValue(nameof(BubbleSize), value);
        }
        public bool ShowStats
        {
            get => (bool)GetValue(nameof(ShowStats));
            set => SetValue(nameof(ShowStats), value);
        }
        public bool HighVis
        {
            get => (bool)GetValue(nameof(HighVis));
            set => SetValue(nameof(HighVis), value);
        }
        public bool ShowOnHover
        {
            get => (bool)GetValue(nameof(ShowOnHover));
            set => SetValue(nameof(ShowOnHover), value);
        }
        public bool EnablePreplacement
        {
            get => (bool)GetValue(nameof(EnablePreplacement));
            set => SetValue(nameof(EnablePreplacement), value);
        }
        public bool EnableMiniInspector
        {
            get => (bool)GetValue(nameof(EnableMiniInspector));
            set => SetValue(nameof(EnableMiniInspector), value);
        }
        public int ActiveMode
        {
            get => (int)GetValue(nameof(ActiveMode));
            set => SetValue(nameof(ActiveMode), value);
        }

        //public string SavedLocalSettings
        //{
        //    get => (string)GetValue(nameof(SavedLocalSettings));
        //    set => SetValue(nameof(SavedLocalSettings), value);
        //}
        //public string SavedGlobalSettings
        //{
        //    get => (string)GetValue(nameof(SavedGlobalSettings));
        //    set => SetValue(nameof(SavedGlobalSettings), value);
        //}
        public float WindowX
        {
            get => (float)GetValue(nameof(WindowX));
            set => SetValue(nameof(WindowX), value);
        }
        public float WindowY
        {
            get => (float)GetValue(nameof(WindowY));
            set => SetValue(nameof(WindowY), value);
        }

        //public string SavedPresets
        //{
        //    get => (string)GetValue(nameof(SavedPresets));
        //    set => SetValue(nameof(SavedPresets), value);
        //}
        public float InspectorX
        {
            get => (float)GetValue(nameof(InspectorX));
            set => SetValue(nameof(InspectorX), value);
        }
        public float InspectorY
        {
            get => (float)GetValue(nameof(InspectorY));
            set => SetValue(nameof(InspectorY), value);
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

    public class AssetMigrationUtilitySettings : SettingsBackup
    {
        public bool IsEnabled
        {
            get => (bool)GetValue(nameof(IsEnabled));
            set => SetValue(nameof(IsEnabled), value);
        }
    }

    public class AssetUIManagerSettings : SettingsBackup
    {
        //public bool IsGame
        //{
        //    get => (bool)GetValue(nameof(IsGame));
        //    set => SetValue(nameof(IsGame), value);
        //}
        public bool BridgesInRoads
        {
            get => (bool)GetValue(nameof(BridgesInRoads));
            set => SetValue(nameof(BridgesInRoads), value);
        }
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
        public bool BikewayInRoads
        {
            get => (bool)GetValue(nameof(BikewayInRoads));
            set => SetValue(nameof(BikewayInRoads), value);
        }
        public bool QuaysInRoads
        {
            get => (bool)GetValue(nameof(QuaysInRoads));
            set => SetValue(nameof(QuaysInRoads), value);
        }
        public bool ParkingRoadsInRoads
        {
            get => (bool)GetValue(nameof(ParkingRoadsInRoads));
            set => SetValue(nameof(ParkingRoadsInRoads), value);
        }

        //public int PathwayPriorityDropdownVersion
        //{
        //    get => (int)GetValue(nameof(PathwayPriorityDropdownVersion));
        //    set => SetValue(nameof(PathwayPriorityDropdownVersion), value);
        //}
        //public int PathwayPriorityDropdown
        //{
        //    get => (int)GetValue(nameof(PathwayPriorityDropdown));
        //    set => SetValue(nameof(PathwayPriorityDropdown), value);
        //}
        public bool SeparatedHospitals
        {
            get => (bool)GetValue(nameof(SeparatedHospitals));
            set => SetValue(nameof(SeparatedHospitals), value);
        }
        public bool SeparateControlAndResearch
        {
            get => (bool)GetValue(nameof(SeparateControlAndResearch));
            set => SetValue(nameof(SeparateControlAndResearch), value);
        }
        public bool SeparatedSchools
        {
            get => (bool)GetValue(nameof(SeparatedSchools));
            set => SetValue(nameof(SeparatedSchools), value);
        }
        public bool SeparatedPolice
        {
            get => (bool)GetValue(nameof(SeparatedPolice));
            set => SetValue(nameof(SeparatedPolice), value);
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
        //public bool BaseGameAssetPacks
        //{
        //    get => (bool)GetValue(nameof(BaseGameAssetPacks));
        //    set => SetValue(nameof(BaseGameAssetPacks), value);
        //}
        //public bool PDXModsAssetPacks
        //{
        //    get => (bool)GetValue(nameof(PDXModsAssetPacks));
        //    set => SetValue(nameof(PDXModsAssetPacks), value);
        //}
        //public bool EnableAssetPacks
        //{
        //    get => (bool)GetValue(nameof(EnableAssetPacks));
        //    set => SetValue(nameof(EnableAssetPacks), value);
        //}
        //public bool VerboseLogging
        //{
        //    get => (bool)GetValue(nameof(VerboseLogging));
        //    set => SetValue(nameof(VerboseLogging), value);
        //}
    }

    public class AssetVariationChangerSettings : SettingsBackup
    {
        public bool EnableVariationChooser
        {
            get => (bool)GetValue(nameof(EnableVariationChooser));
            set => SetValue(nameof(EnableVariationChooser), value);
        }
        public bool LineToolCompatibility
        {
            get => (bool)GetValue(nameof(LineToolCompatibility));
            set => SetValue(nameof(LineToolCompatibility), value);
        }
        public bool TreeControllerCompatibility
        {
            get => (bool)GetValue(nameof(TreeControllerCompatibility));
            set => SetValue(nameof(TreeControllerCompatibility), value);
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

    public class AutomaticBulldozeAndRepairSettings : SettingsBackup
    {
        public bool EnableAutoBulldoze
        {
            get => (bool)GetValue(nameof(EnableAutoBulldoze));
            set => SetValue(nameof(EnableAutoBulldoze), value);
        }
        public bool EnableAutoRepair
        {
            get => (bool)GetValue(nameof(EnableAutoRepair));
            set => SetValue(nameof(EnableAutoRepair), value);
        }
        public bool BulldozeAbandoned
        {
            get => (bool)GetValue(nameof(BulldozeAbandoned));
            set => SetValue(nameof(BulldozeAbandoned), value);
        }
        public bool BulldozeCondemned
        {
            get => (bool)GetValue(nameof(BulldozeCondemned));
            set => SetValue(nameof(BulldozeCondemned), value);
        }
        public bool BulldozeDestroyed
        {
            get => (bool)GetValue(nameof(BulldozeDestroyed));
            set => SetValue(nameof(BulldozeDestroyed), value);
        }
        public bool BulldozeFlooded
        {
            get => (bool)GetValue(nameof(BulldozeFlooded));
            set => SetValue(nameof(BulldozeFlooded), value);
        }
        public int IntervalType
        {
            get => (int)GetValue(nameof(IntervalType));
            set => SetValue(nameof(IntervalType), value);
        }
        public int NumberOfBuildings
        {
            get => (int)GetValue(nameof(NumberOfBuildings));
            set => SetValue(nameof(NumberOfBuildings), value);
        }
        public bool ShowCounters
        {
            get => (bool)GetValue(nameof(ShowCounters));
            set => SetValue(nameof(ShowCounters), value);
        }
    }

    public class AutoVehicleRenamerSettings : SettingsBackup
    {
        //public bool IsInGameOrEditor
        //{
        //    get => (bool)GetValue(nameof(IsInGameOrEditor));
        //    set => SetValue(nameof(IsInGameOrEditor), value);
        //}
        public bool IsDetailedDescriptionsRunning
        {
            get => (bool)GetValue(nameof(IsDetailedDescriptionsRunning));
            set => SetValue(nameof(IsDetailedDescriptionsRunning), value);
        }
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
        //public int PreviousSelectionMode
        //{
        //    get => (int)GetValue(nameof(PreviousSelectionMode));
        //    set => SetValue(nameof(PreviousSelectionMode), value);
        //}
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
        public float MoonLightAveragerStrength
        {
            get => (float)GetValue(nameof(MoonLightAveragerStrength));
            set => SetValue(nameof(MoonLightAveragerStrength), value);
        }
        public float StarfieldEmmisionStrength
        {
            get => (float)GetValue(nameof(StarfieldEmmisionStrength));
            set => SetValue(nameof(StarfieldEmmisionStrength), value);
        }
        public bool DoZRotation
        {
            get => (bool)GetValue(nameof(DoZRotation));
            set => SetValue(nameof(DoZRotation), value);
        }
        public float ZRotation
        {
            get => (float)GetValue(nameof(ZRotation));
            set => SetValue(nameof(ZRotation), value);
        }
        public bool MoonLightIntensityBalance
        {
            get => (bool)GetValue(nameof(MoonLightIntensityBalance));
            set => SetValue(nameof(MoonLightIntensityBalance), value);
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

        //public bool Contra
        //{
        //    get => (bool)GetValue(nameof(Contra));
        //    set => SetValue(nameof(Contra), value);
        //}
        public bool ShowOptionsInDeveloperPanel
        {
            get => (bool)GetValue(nameof(ShowOptionsInDeveloperPanel));
            set => SetValue(nameof(ShowOptionsInDeveloperPanel), value);
        }
        public bool OverrideTexture
        {
            get => (bool)GetValue(nameof(OverrideTexture));
            set => SetValue(nameof(OverrideTexture), value);
        }
        public string SelectedTexture
        {
            get => (string)GetValue(nameof(SelectedTexture));
            set => SetValue(nameof(SelectedTexture), value);
        }
    }

    public class BetterTransitViewSettings : SettingsBackup
    {
        public bool ShowAverageWaitTime
        {
            get => (bool)GetValue(nameof(ShowAverageWaitTime));
            set => SetValue(nameof(ShowAverageWaitTime), value);
        }
        public bool MapModeActivatedByDefault
        {
            get => (bool)GetValue(nameof(MapModeActivatedByDefault));
            set => SetValue(nameof(MapModeActivatedByDefault), value);
        }
        public bool DefaultBusVisible
        {
            get => (bool)GetValue(nameof(DefaultBusVisible));
            set => SetValue(nameof(DefaultBusVisible), value);
        }
        public bool DefaultTrainVisible
        {
            get => (bool)GetValue(nameof(DefaultTrainVisible));
            set => SetValue(nameof(DefaultTrainVisible), value);
        }
        public bool DefaultTramVisible
        {
            get => (bool)GetValue(nameof(DefaultTramVisible));
            set => SetValue(nameof(DefaultTramVisible), value);
        }
        public bool DefaultSubwayVisible
        {
            get => (bool)GetValue(nameof(DefaultSubwayVisible));
            set => SetValue(nameof(DefaultSubwayVisible), value);
        }
        public bool DefaultShipVisible
        {
            get => (bool)GetValue(nameof(DefaultShipVisible));
            set => SetValue(nameof(DefaultShipVisible), value);
        }
        public bool DefaultAirplaneVisible
        {
            get => (bool)GetValue(nameof(DefaultAirplaneVisible));
            set => SetValue(nameof(DefaultAirplaneVisible), value);
        }
        public bool DefaultCargoVisible
        {
            get => (bool)GetValue(nameof(DefaultCargoVisible));
            set => SetValue(nameof(DefaultCargoVisible), value);
        }
    }

    public class BeyondNumbersSettings : SettingsBackup
    {
        public bool HidePopulation
        {
            get => (bool)GetValue(nameof(HidePopulation));
            set => SetValue(nameof(HidePopulation), value);
        }
        public bool HideDemand
        {
            get => (bool)GetValue(nameof(HideDemand));
            set => SetValue(nameof(HideDemand), value);
        }
        public bool HideDate
        {
            get => (bool)GetValue(nameof(HideDate));
            set => SetValue(nameof(HideDate), value);
        }
        public bool HideTime
        {
            get => (bool)GetValue(nameof(HideTime));
            set => SetValue(nameof(HideTime), value);
        }
        public bool ShowMoneyTrendHourly
        {
            get => (bool)GetValue(nameof(ShowMoneyTrendHourly));
            set => SetValue(nameof(ShowMoneyTrendHourly), value);
        }
        public bool ShowMoneyTrendMonthly
        {
            get => (bool)GetValue(nameof(ShowMoneyTrendMonthly));
            set => SetValue(nameof(ShowMoneyTrendMonthly), value);
        }
        public bool ShowPopTrendHourly
        {
            get => (bool)GetValue(nameof(ShowPopTrendHourly));
            set => SetValue(nameof(ShowPopTrendHourly), value);
        }
        public bool ShowPopTrendMonthly
        {
            get => (bool)GetValue(nameof(ShowPopTrendMonthly));
            set => SetValue(nameof(ShowPopTrendMonthly), value);
        }
        public bool EnableMoneyTooltip
        {
            get => (bool)GetValue(nameof(EnableMoneyTooltip));
            set => SetValue(nameof(EnableMoneyTooltip), value);
        }
        public bool ShowTooltipIncome
        {
            get => (bool)GetValue(nameof(ShowTooltipIncome));
            set => SetValue(nameof(ShowTooltipIncome), value);
        }
        public bool ShowTooltipExpense
        {
            get => (bool)GetValue(nameof(ShowTooltipExpense));
            set => SetValue(nameof(ShowTooltipExpense), value);
        }
        public bool ShowTooltipNet
        {
            get => (bool)GetValue(nameof(ShowTooltipNet));
            set => SetValue(nameof(ShowTooltipNet), value);
        }
        public bool ShowTooltipHourlyValues
        {
            get => (bool)GetValue(nameof(ShowTooltipHourlyValues));
            set => SetValue(nameof(ShowTooltipHourlyValues), value);
        }
        public bool ShowTooltipMonthlyValues
        {
            get => (bool)GetValue(nameof(ShowTooltipMonthlyValues));
            set => SetValue(nameof(ShowTooltipMonthlyValues), value);
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
        //public int MakeSureSave
        //{
        //    get => (int)GetValue(nameof(MakeSureSave));
        //    set => SetValue(nameof(MakeSureSave), value);
        //}
    }

    public class BuildingHeightAndFootprintSettings : SettingsBackup
    {
        public int HeightUnit
        {
            get => (int)GetValue(nameof(HeightUnit));
            set => SetValue(nameof(HeightUnit), value);
        }
        public int SeaLevelOffsetMeters
        {
            get => (int)GetValue(nameof(SeaLevelOffsetMeters));
            set => SetValue(nameof(SeaLevelOffsetMeters), value);
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
        public bool showDetailedEnrouteCimCounts
        {
            get => (bool)GetValue(nameof(showDetailedEnrouteCimCounts));
            set => SetValue(nameof(showDetailedEnrouteCimCounts), value);
        }
        public bool showEnrouteVehicleCounts
        {
            get => (bool)GetValue(nameof(showEnrouteVehicleCounts));
            set => SetValue(nameof(showEnrouteVehicleCounts), value);
        }
        public bool showDetailedEnrouteVehicleCounts
        {
            get => (bool)GetValue(nameof(showDetailedEnrouteVehicleCounts));
            set => SetValue(nameof(showDetailedEnrouteVehicleCounts), value);
        }
        public bool showBuildingOccupancy
        {
            get => (bool)GetValue(nameof(showBuildingOccupancy));
            set => SetValue(nameof(showBuildingOccupancy), value);
        }
        public bool showDetailedBuildingOccupancy
        {
            get => (bool)GetValue(nameof(showDetailedBuildingOccupancy));
            set => SetValue(nameof(showDetailedBuildingOccupancy), value);
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
        public int ProductionInfoviewColor
        {
            get => (int)GetValue(nameof(ProductionInfoviewColor));
            set => SetValue(nameof(ProductionInfoviewColor), value);
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
        public bool CountVehiclesInUse
        {
            get => (bool)GetValue(nameof(CountVehiclesInUse));
            set => SetValue(nameof(CountVehiclesInUse), value);
        }
        public bool CountVehiclesInMaintenance
        {
            get => (bool)GetValue(nameof(CountVehiclesInMaintenance));
            set => SetValue(nameof(CountVehiclesInMaintenance), value);
        }
        public bool EfficiencyMaxColor200Percent
        {
            get => (bool)GetValue(nameof(EfficiencyMaxColor200Percent));
            set => SetValue(nameof(EfficiencyMaxColor200Percent), value);
        }
        public bool ProductionMaxColor200Percent
        {
            get => (bool)GetValue(nameof(ProductionMaxColor200Percent));
            set => SetValue(nameof(ProductionMaxColor200Percent), value);
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
        public string CustomDirectory
        {
            get => (string)GetValue(nameof(CustomDirectory));
            set => SetValue(nameof(CustomDirectory), value);
        }
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
        public bool ProductionBalanceEnabledIndustrial
        {
            get => (bool)GetValue(nameof(ProductionBalanceEnabledIndustrial));
            set => SetValue(nameof(ProductionBalanceEnabledIndustrial), value);
        }
        public bool ProductionBalanceEnabledOffice
        {
            get => (bool)GetValue(nameof(ProductionBalanceEnabledOffice));
            set => SetValue(nameof(ProductionBalanceEnabledOffice), value);
        }
        public int ProductionBalanceCheckIntervalIndustrial
        {
            get => (int)GetValue(nameof(ProductionBalanceCheckIntervalIndustrial));
            set => SetValue(nameof(ProductionBalanceCheckIntervalIndustrial), value);
        }
        public int ProductionBalanceCheckIntervalOffice
        {
            get => (int)GetValue(nameof(ProductionBalanceCheckIntervalOffice));
            set => SetValue(nameof(ProductionBalanceCheckIntervalOffice), value);
        }
        public int ProductionBalanceMinimumCompaniesIndustrial
        {
            get => (int)GetValue(nameof(ProductionBalanceMinimumCompaniesIndustrial));
            set => SetValue(nameof(ProductionBalanceMinimumCompaniesIndustrial), value);
        }
        public int ProductionBalanceMinimumCompaniesOffice
        {
            get => (int)GetValue(nameof(ProductionBalanceMinimumCompaniesOffice));
            set => SetValue(nameof(ProductionBalanceMinimumCompaniesOffice), value);
        }
        public int ProductionBalanceMinimumStandardDeviationIndustrial
        {
            get => (int)GetValue(nameof(ProductionBalanceMinimumStandardDeviationIndustrial));
            set => SetValue(nameof(ProductionBalanceMinimumStandardDeviationIndustrial), value);
        }
        public int ProductionBalanceMinimumStandardDeviationOffice
        {
            get => (int)GetValue(nameof(ProductionBalanceMinimumStandardDeviationOffice));
            set => SetValue(nameof(ProductionBalanceMinimumStandardDeviationOffice), value);
        }
        public int ProductionBalanceMaximumCompanyProductionIndustrial
        {
            get => (int)GetValue(nameof(ProductionBalanceMaximumCompanyProductionIndustrial));
            set => SetValue(nameof(ProductionBalanceMaximumCompanyProductionIndustrial), value);
        }
        public int ProductionBalanceMaximumCompanyProductionOffice
        {
            get => (int)GetValue(nameof(ProductionBalanceMaximumCompanyProductionOffice));
            set => SetValue(nameof(ProductionBalanceMaximumCompanyProductionOffice), value);
        }
        public bool ProductionBalanceHideActivationButton
        {
            get => (bool)GetValue(nameof(ProductionBalanceHideActivationButton));
            set => SetValue(nameof(ProductionBalanceHideActivationButton), value);
        }
        public bool ProductionBalancePanelVisible
        {
            get => (bool)GetValue(nameof(ProductionBalancePanelVisible));
            set => SetValue(nameof(ProductionBalancePanelVisible), value);
        }
        public int ProductionBalancePanelPositionX
        {
            get => (int)GetValue(nameof(ProductionBalancePanelPositionX));
            set => SetValue(nameof(ProductionBalancePanelPositionX), value);
        }
        public int ProductionBalancePanelPositionY
        {
            get => (int)GetValue(nameof(ProductionBalancePanelPositionY));
            set => SetValue(nameof(ProductionBalancePanelPositionY), value);
        }
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
        public bool KeepWorkplacesOverrideAfterChange
        {
            get => (bool)GetValue(nameof(KeepWorkplacesOverrideAfterChange));
            set => SetValue(nameof(KeepWorkplacesOverrideAfterChange), value);
        }
        //public int WorkplacesOverrideValue
        //{
        //    get => (int)GetValue(nameof(WorkplacesOverrideValue));
        //    set => SetValue(nameof(WorkplacesOverrideValue), value);
        //}
    }

    public class ChirpGPTSettings : SettingsBackup
    {
        //public string MistralAPIkeyEncrypted
        //{
        //    get => (string)GetValue(nameof(MistralAPIkeyEncrypted));
        //    set => SetValue(nameof(MistralAPIkeyEncrypted), value);
        //}
        //public string GoogleaiAPIkeyEncrypted
        //{
        //    get => (string)GetValue(nameof(GoogleaiAPIkeyEncrypted));
        //    set => SetValue(nameof(GoogleaiAPIkeyEncrypted), value);
        //}
        public int FrequencySlider
        {
            get => (int)GetValue(nameof(FrequencySlider));
            set => SetValue(nameof(FrequencySlider), value);
        }
        public int CacheSlider
        {
            get => (int)GetValue(nameof(CacheSlider));
            set => SetValue(nameof(CacheSlider), value);
        }
        public int UsesSlider
        {
            get => (int)GetValue(nameof(UsesSlider));
            set => SetValue(nameof(UsesSlider), value);
        }
        public int EnumDropdown
        {
            get => (int)GetValue(nameof(EnumDropdown));
            set => SetValue(nameof(EnumDropdown), value);
        }
        public int SelfAware
        {
            get => (int)GetValue(nameof(SelfAware));
            set => SetValue(nameof(SelfAware), value);
        }
        public int Cursing
        {
            get => (int)GetValue(nameof(Cursing));
            set => SetValue(nameof(Cursing), value);
        }
        public int Hashtags
        {
            get => (int)GetValue(nameof(Hashtags));
            set => SetValue(nameof(Hashtags), value);
        }
        public string Keywords
        {
            get => (string)GetValue(nameof(Keywords));
            set => SetValue(nameof(Keywords), value);
        }
        //public string MistralAPIKey
        //{
        //    get => (string)GetValue(nameof(MistralAPIKey));
        //    set => SetValue(nameof(MistralAPIKey), value);
        //}
        //public string GoogleaiAPIKey
        //{
        //    get => (string)GetValue(nameof(GoogleaiAPIKey));
        //    set => SetValue(nameof(GoogleaiAPIKey), value);
        //}
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class CimRouteHighlighterSettings : SettingsBackup
    {
        //public bool highlightRoutes
        //{
        //    get => (bool)GetValue(nameof(highlightRoutes));
        //    set => SetValue(nameof(highlightRoutes), value);
        //}
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

    public class CitizenCleanerSettings : SettingsBackup
    {
        public bool IncludeCorrupt
        {
            get => (bool)GetValue(nameof(IncludeCorrupt));
            set => SetValue(nameof(IncludeCorrupt), value);
        }
        public bool IncludeMovingAwayNoPR
        {
            get => (bool)GetValue(nameof(IncludeMovingAwayNoPR));
            set => SetValue(nameof(IncludeMovingAwayNoPR), value);
        }
        public bool IncludeCommuters
        {
            get => (bool)GetValue(nameof(IncludeCommuters));
            set => SetValue(nameof(IncludeCommuters), value);
        }
        public bool IncludeHomeless
        {
            get => (bool)GetValue(nameof(IncludeHomeless));
            set => SetValue(nameof(IncludeHomeless), value);
        }
    }

    public class CitizenModelManagerSettings : SettingsBackup
    {
        //public int SetVersion
        //{
        //    get => (int)GetValue(nameof(SetVersion));
        //    set => SetValue(nameof(SetVersion), value);
        //}
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
        //public int Notification
        //{
        //    get => (int)GetValue(nameof(Notification));
        //    set => SetValue(nameof(Notification), value);
        //}
        //public int NotificationSetting
        //{
        //    get => (int)GetValue(nameof(NotificationSetting));
        //    set => SetValue(nameof(NotificationSetting), value);
        //}
        //public bool ElectricityElectricityNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityElectricityNotification));
        //    set => SetValue(nameof(ElectricityElectricityNotification), value);
        //}
        //public bool ElectricityBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBottleneckNotification));
        //    set => SetValue(nameof(ElectricityBottleneckNotification), value);
        //}
        //public bool ElectricityBuildingBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBuildingBottleneckNotification));
        //    set => SetValue(nameof(ElectricityBuildingBottleneckNotification), value);
        //}
        //public bool ElectricityNotEnoughProductionNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityNotEnoughProductionNotification));
        //    set => SetValue(nameof(ElectricityNotEnoughProductionNotification), value);
        //}
        //public bool ElectricityTransformerNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityTransformerNotification));
        //    set => SetValue(nameof(ElectricityTransformerNotification), value);
        //}
        //public bool ElectricityNotEnoughConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityNotEnoughConnectedNotification));
        //    set => SetValue(nameof(ElectricityNotEnoughConnectedNotification), value);
        //}
        //public bool ElectricityBatteryEmptyNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBatteryEmptyNotification));
        //    set => SetValue(nameof(ElectricityBatteryEmptyNotification), value);
        //}
        //public bool ElectricityLowVoltageNotConnected
        //{
        //    get => (bool)GetValue(nameof(ElectricityLowVoltageNotConnected));
        //    set => SetValue(nameof(ElectricityLowVoltageNotConnected), value);
        //}
        //public bool ElectricityHighVoltageNotConnected
        //{
        //    get => (bool)GetValue(nameof(ElectricityHighVoltageNotConnected));
        //    set => SetValue(nameof(ElectricityHighVoltageNotConnected), value);
        //}
        //public bool WaterPipeWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeWaterNotification));
        //    set => SetValue(nameof(WaterPipeWaterNotification), value);
        //}
        //public bool WaterPipeDirtyWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeDirtyWaterNotification));
        //    set => SetValue(nameof(WaterPipeDirtyWaterNotification), value);
        //}
        //public bool WaterPipeSewageNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeSewageNotification));
        //    set => SetValue(nameof(WaterPipeSewageNotification), value);
        //}
        //public bool WaterPipeWaterPipeNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeWaterPipeNotConnectedNotification));
        //    set => SetValue(nameof(WaterPipeWaterPipeNotConnectedNotification), value);
        //}
        //public bool WaterPipeSewagePipeNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeSewagePipeNotConnectedNotification));
        //    set => SetValue(nameof(WaterPipeSewagePipeNotConnectedNotification), value);
        //}
        //public bool WaterPipeNotEnoughWaterCapacityNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughWaterCapacityNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughWaterCapacityNotification), value);
        //}
        //public bool WaterPipeNotEnoughSewageCapacityNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughSewageCapacityNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughSewageCapacityNotification), value);
        //}
        //public bool WaterPipeNotEnoughGroundwaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughGroundwaterNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughGroundwaterNotification), value);
        //}
        //public bool WaterPipeNotEnoughSurfaceWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughSurfaceWaterNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughSurfaceWaterNotification), value);
        //}
        //public bool WaterPipeDirtyWaterPumpNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeDirtyWaterPumpNotification));
        //    set => SetValue(nameof(WaterPipeDirtyWaterPumpNotification), value);
        //}
        //public bool BuildingAbandonedCollapsedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingAbandonedCollapsedNotification));
        //    set => SetValue(nameof(BuildingAbandonedCollapsedNotification), value);
        //}
        //public bool BuildingAbandonedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingAbandonedNotification));
        //    set => SetValue(nameof(BuildingAbandonedNotification), value);
        //}
        //public bool BuildingCondemnedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingCondemnedNotification));
        //    set => SetValue(nameof(BuildingCondemnedNotification), value);
        //}
        //public bool BuildingTurnedOffNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingTurnedOffNotification));
        //    set => SetValue(nameof(BuildingTurnedOffNotification), value);
        //}
        //public bool BuildingHighRentNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingHighRentNotification));
        //    set => SetValue(nameof(BuildingHighRentNotification), value);
        //}
        //public bool TrafficBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficBottleneckNotification));
        //    set => SetValue(nameof(TrafficBottleneckNotification), value);
        //}
        //public bool TrafficDeadEndNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficDeadEndNotification));
        //    set => SetValue(nameof(TrafficDeadEndNotification), value);
        //}
        //public bool TrafficRoadConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficRoadConnectionNotification));
        //    set => SetValue(nameof(TrafficRoadConnectionNotification), value);
        //}
        //public bool TrafficTrackConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficTrackConnectionNotification));
        //    set => SetValue(nameof(TrafficTrackConnectionNotification), value);
        //}
        //public bool TrafficCarConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficCarConnectionNotification));
        //    set => SetValue(nameof(TrafficCarConnectionNotification), value);
        //}
        //public bool TrafficShipConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficShipConnectionNotification));
        //    set => SetValue(nameof(TrafficShipConnectionNotification), value);
        //}
        //public bool TrafficTrainConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficTrainConnectionNotification));
        //    set => SetValue(nameof(TrafficTrainConnectionNotification), value);
        //}
        //public bool TrafficPedestrianConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficPedestrianConnectionNotification));
        //    set => SetValue(nameof(TrafficPedestrianConnectionNotification), value);
        //}
        //public bool CompanyNoInputsNotification
        //{
        //    get => (bool)GetValue(nameof(CompanyNoInputsNotification));
        //    set => SetValue(nameof(CompanyNoInputsNotification), value);
        //}
        //public bool CompanyNoCustomersNotification
        //{
        //    get => (bool)GetValue(nameof(CompanyNoCustomersNotification));
        //    set => SetValue(nameof(CompanyNoCustomersNotification), value);
        //}
        //public bool WorkProviderUneducatedNotification
        //{
        //    get => (bool)GetValue(nameof(WorkProviderUneducatedNotification));
        //    set => SetValue(nameof(WorkProviderUneducatedNotification), value);
        //}
        //public bool WorkProviderEducatedNotification
        //{
        //    get => (bool)GetValue(nameof(WorkProviderEducatedNotification));
        //    set => SetValue(nameof(WorkProviderEducatedNotification), value);
        //}
        //public bool DisasterWeatherDamageNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWeatherDamageNotification));
        //    set => SetValue(nameof(DisasterWeatherDamageNotification), value);
        //}
        //public bool DisasterWeatherDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWeatherDestroyedNotification));
        //    set => SetValue(nameof(DisasterWeatherDestroyedNotification), value);
        //}
        //public bool DisasterWaterDamageNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWaterDamageNotification));
        //    set => SetValue(nameof(DisasterWaterDamageNotification), value);
        //}
        //public bool DisasterWaterDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWaterDestroyedNotification));
        //    set => SetValue(nameof(DisasterWaterDestroyedNotification), value);
        //}
        //public bool DisasterDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterDestroyedNotification));
        //    set => SetValue(nameof(DisasterDestroyedNotification), value);
        //}
        //public bool FireFireNotification
        //{
        //    get => (bool)GetValue(nameof(FireFireNotification));
        //    set => SetValue(nameof(FireFireNotification), value);
        //}
        //public bool FireBurnedDownNotification
        //{
        //    get => (bool)GetValue(nameof(FireBurnedDownNotification));
        //    set => SetValue(nameof(FireBurnedDownNotification), value);
        //}
        //public bool GarbageGarbageNotification
        //{
        //    get => (bool)GetValue(nameof(GarbageGarbageNotification));
        //    set => SetValue(nameof(GarbageGarbageNotification), value);
        //}
        //public bool GarbageFacilityFullNotification
        //{
        //    get => (bool)GetValue(nameof(GarbageFacilityFullNotification));
        //    set => SetValue(nameof(GarbageFacilityFullNotification), value);
        //}
        //public bool HealthcareAmbulanceNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareAmbulanceNotification));
        //    set => SetValue(nameof(HealthcareAmbulanceNotification), value);
        //}
        //public bool HealthcareHearseNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareHearseNotification));
        //    set => SetValue(nameof(HealthcareHearseNotification), value);
        //}
        //public bool HealthcareFacilityFullNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareFacilityFullNotification));
        //    set => SetValue(nameof(HealthcareFacilityFullNotification), value);
        //}
        //public bool PoliceTrafficAccidentNotification
        //{
        //    get => (bool)GetValue(nameof(PoliceTrafficAccidentNotification));
        //    set => SetValue(nameof(PoliceTrafficAccidentNotification), value);
        //}
        //public bool PoliceCrimeSceneNotification
        //{
        //    get => (bool)GetValue(nameof(PoliceCrimeSceneNotification));
        //    set => SetValue(nameof(PoliceCrimeSceneNotification), value);
        //}
        //public bool PollutionAirPollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionAirPollutionNotification));
        //    set => SetValue(nameof(PollutionAirPollutionNotification), value);
        //}
        //public bool PollutionNoisePollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionNoisePollutionNotification));
        //    set => SetValue(nameof(PollutionNoisePollutionNotification), value);
        //}
        //public bool PollutionGroundPollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionGroundPollutionNotification));
        //    set => SetValue(nameof(PollutionGroundPollutionNotification), value);
        //}
        //public bool ResourceConsumerNoResourceNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConsumerNoResourceNotification));
        //    set => SetValue(nameof(ResourceConsumerNoResourceNotification), value);
        //}
        //public bool RoutePathfindNotification
        //{
        //    get => (bool)GetValue(nameof(RoutePathfindNotification));
        //    set => SetValue(nameof(RoutePathfindNotification), value);
        //}
        //public bool TransportLineVehicleNotification
        //{
        //    get => (bool)GetValue(nameof(TransportLineVehicleNotification));
        //    set => SetValue(nameof(TransportLineVehicleNotification), value);
        //}
    }

    public class CityServiceCapacityAdjusterSettings : SettingsBackup
    {
        public int CargoTruckSlider
        {
            get => (int)GetValue(nameof(CargoTruckSlider));
            set => SetValue(nameof(CargoTruckSlider), value);
        }
        public int PostSortingSlider
        {
            get => (int)GetValue(nameof(PostSortingSlider));
            set => SetValue(nameof(PostSortingSlider), value);
        }
        public bool FixMailOverflow
        {
            get => (bool)GetValue(nameof(FixMailOverflow));
            set => SetValue(nameof(FixMailOverflow), value);
        }
        public int GarbageTruckCapacitySlider
        {
            get => (int)GetValue(nameof(GarbageTruckCapacitySlider));
            set => SetValue(nameof(GarbageTruckCapacitySlider), value);
        }
        public float DepotCapacityBusSlider
        {
            get => (float)GetValue(nameof(DepotCapacityBusSlider));
            set => SetValue(nameof(DepotCapacityBusSlider), value);
        }
        public float DepotCapacityTaxiSlider
        {
            get => (float)GetValue(nameof(DepotCapacityTaxiSlider));
            set => SetValue(nameof(DepotCapacityTaxiSlider), value);
        }
        public float DepotCapacityTramSlider
        {
            get => (float)GetValue(nameof(DepotCapacityTramSlider));
            set => SetValue(nameof(DepotCapacityTramSlider), value);
        }
        public float DepotCapacityTrainSlider
        {
            get => (float)GetValue(nameof(DepotCapacityTrainSlider));
            set => SetValue(nameof(DepotCapacityTrainSlider), value);
        }
        public float DepotCapacitySubwaySlider
        {
            get => (float)GetValue(nameof(DepotCapacitySubwaySlider));
            set => SetValue(nameof(DepotCapacitySubwaySlider), value);
        }
        public float PeopleCapacityBusSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityBusSlider));
            set => SetValue(nameof(PeopleCapacityBusSlider), value);
        }
        public float PeopleCapacityTaxiSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityTaxiSlider));
            set => SetValue(nameof(PeopleCapacityTaxiSlider), value);
        }
        public float PeopleCapacityTramSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityTramSlider));
            set => SetValue(nameof(PeopleCapacityTramSlider), value);
        }
        public float PeopleCapacityTrainSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityTrainSlider));
            set => SetValue(nameof(PeopleCapacityTrainSlider), value);
        }
        public float PeopleCapacitySubwaySlider
        {
            get => (float)GetValue(nameof(PeopleCapacitySubwaySlider));
            set => SetValue(nameof(PeopleCapacitySubwaySlider), value);
        }
        public float PeopleCapacityAirplaneSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityAirplaneSlider));
            set => SetValue(nameof(PeopleCapacityAirplaneSlider), value);
        }
        public float PeopleCapacityShipSlider
        {
            get => (float)GetValue(nameof(PeopleCapacityShipSlider));
            set => SetValue(nameof(PeopleCapacityShipSlider), value);
        }
        public float CrematoriumSpeedSlider
        {
            get => (float)GetValue(nameof(CrematoriumSpeedSlider));
            set => SetValue(nameof(CrematoriumSpeedSlider), value);
        }
        public float CrematoriumCapcitySlider
        {
            get => (float)GetValue(nameof(CrematoriumCapcitySlider));
            set => SetValue(nameof(CrematoriumCapcitySlider), value);
        }
        public float CrematoriumHearseSlider
        {
            get => (float)GetValue(nameof(CrematoriumHearseSlider));
            set => SetValue(nameof(CrematoriumHearseSlider), value);
        }
        public float ElementrySchoolSlider
        {
            get => (float)GetValue(nameof(ElementrySchoolSlider));
            set => SetValue(nameof(ElementrySchoolSlider), value);
        }
        public float HighSchoolSlider
        {
            get => (float)GetValue(nameof(HighSchoolSlider));
            set => SetValue(nameof(HighSchoolSlider), value);
        }
        public float CollegeSlider
        {
            get => (float)GetValue(nameof(CollegeSlider));
            set => SetValue(nameof(CollegeSlider), value);
        }
        public float UniversitySlider
        {
            get => (float)GetValue(nameof(UniversitySlider));
            set => SetValue(nameof(UniversitySlider), value);
        }
        public int PedestrianCrosswalkReduction
        {
            get => (int)GetValue(nameof(PedestrianCrosswalkReduction));
            set => SetValue(nameof(PedestrianCrosswalkReduction), value);
        }
        public int CarForbiddenCostSlider
        {
            get => (int)GetValue(nameof(CarForbiddenCostSlider));
            set => SetValue(nameof(CarForbiddenCostSlider), value);
        }
        public int CarLaneCrossCostSlider
        {
            get => (int)GetValue(nameof(CarLaneCrossCostSlider));
            set => SetValue(nameof(CarLaneCrossCostSlider), value);
        }
        public int CarUnsafeTurningCostSlider
        {
            get => (int)GetValue(nameof(CarUnsafeTurningCostSlider));
            set => SetValue(nameof(CarUnsafeTurningCostSlider), value);
        }
        public int CarUnsafeUTurnCostSlider
        {
            get => (int)GetValue(nameof(CarUnsafeUTurnCostSlider));
            set => SetValue(nameof(CarUnsafeUTurnCostSlider), value);
        }
        public int CarUTurnCostSlider
        {
            get => (int)GetValue(nameof(CarUTurnCostSlider));
            set => SetValue(nameof(CarUTurnCostSlider), value);
        }
    }

    public class CityStatsSettings : SettingsBackup
    {
        public bool PanelOpenOnLoad
        {
            get => (bool)GetValue(nameof(PanelOpenOnLoad));
            set => SetValue(nameof(PanelOpenOnLoad), value);
        }
        public bool ModButtonVisible
        {
            get => (bool)GetValue(nameof(ModButtonVisible));
            set => SetValue(nameof(ModButtonVisible), value);
        }
        public int PanelOrientation
        {
            get => (int)GetValue(nameof(PanelOrientation));
            set => SetValue(nameof(PanelOrientation), value);
        }
        public bool PanelShowSectionDividers
        {
            get => (bool)GetValue(nameof(PanelShowSectionDividers));
            set => SetValue(nameof(PanelShowSectionDividers), value);
        }
        //public float2 PanelPosition
        //{
        //    get => (float2)GetValue(nameof(PanelPosition));
        //    set => SetValue(nameof(PanelPosition), value);
        //}
    }

    public class CityWatchdogSettings : SettingsBackup
    {
        public bool MoneyView
        {
            get => (bool)GetValue(nameof(MoneyView));
            set => SetValue(nameof(MoneyView), value);
        }
        public int MoneyViewMode
        {
            get => (int)GetValue(nameof(MoneyViewMode));
            set => SetValue(nameof(MoneyViewMode), value);
        }
        public int MoneyTooltipMode
        {
            get => (int)GetValue(nameof(MoneyTooltipMode));
            set => SetValue(nameof(MoneyTooltipMode), value);
        }
        public int MoneyTooltipFontScale
        {
            get => (int)GetValue(nameof(MoneyTooltipFontScale));
            set => SetValue(nameof(MoneyTooltipFontScale), value);
        }
        public int PopulationTooltipFontScale
        {
            get => (int)GetValue(nameof(PopulationTooltipFontScale));
            set => SetValue(nameof(PopulationTooltipFontScale), value);
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
        public bool HideRoadNames
        {
            get => (bool)GetValue(nameof(HideRoadNames));
            set => SetValue(nameof(HideRoadNames), value);
        }
        public bool ShowRoadArrows
        {
            get => (bool)GetValue(nameof(ShowRoadArrows));
            set => SetValue(nameof(ShowRoadArrows), value);
        }
        public bool DisableCwdTooltips
        {
            get => (bool)GetValue(nameof(DisableCwdTooltips));
            set => SetValue(nameof(DisableCwdTooltips), value);
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
        public bool ConfirmUnlimitedMoneySaveConversion
        {
            get => (bool)GetValue(nameof(ConfirmUnlimitedMoneySaveConversion));
            set => SetValue(nameof(ConfirmUnlimitedMoneySaveConversion), value);
        }
        public bool ShowUsage
        {
            get => (bool)GetValue(nameof(ShowUsage));
            set => SetValue(nameof(ShowUsage), value);
        }
        //public int Notification
        //{
        //    get => (int)GetValue(nameof(Notification));
        //    set => SetValue(nameof(Notification), value);
        //}
        //public int NotificationSetting
        //{
        //    get => (int)GetValue(nameof(NotificationSetting));
        //    set => SetValue(nameof(NotificationSetting), value);
        //}
        //public bool ElectricityElectricityNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityElectricityNotification));
        //    set => SetValue(nameof(ElectricityElectricityNotification), value);
        //}
        //public bool ElectricityBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBottleneckNotification));
        //    set => SetValue(nameof(ElectricityBottleneckNotification), value);
        //}
        //public bool ElectricityBuildingBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBuildingBottleneckNotification));
        //    set => SetValue(nameof(ElectricityBuildingBottleneckNotification), value);
        //}
        //public bool ElectricityNotEnoughProductionNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityNotEnoughProductionNotification));
        //    set => SetValue(nameof(ElectricityNotEnoughProductionNotification), value);
        //}
        //public bool ElectricityTransformerNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityTransformerNotification));
        //    set => SetValue(nameof(ElectricityTransformerNotification), value);
        //}
        //public bool ElectricityNotEnoughConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityNotEnoughConnectedNotification));
        //    set => SetValue(nameof(ElectricityNotEnoughConnectedNotification), value);
        //}
        //public bool ElectricityBatteryEmptyNotification
        //{
        //    get => (bool)GetValue(nameof(ElectricityBatteryEmptyNotification));
        //    set => SetValue(nameof(ElectricityBatteryEmptyNotification), value);
        //}
        //public bool ElectricityLowVoltageNotConnected
        //{
        //    get => (bool)GetValue(nameof(ElectricityLowVoltageNotConnected));
        //    set => SetValue(nameof(ElectricityLowVoltageNotConnected), value);
        //}
        //public bool ElectricityHighVoltageNotConnected
        //{
        //    get => (bool)GetValue(nameof(ElectricityHighVoltageNotConnected));
        //    set => SetValue(nameof(ElectricityHighVoltageNotConnected), value);
        //}
        //public bool WaterPipeWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeWaterNotification));
        //    set => SetValue(nameof(WaterPipeWaterNotification), value);
        //}
        //public bool WaterPipeDirtyWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeDirtyWaterNotification));
        //    set => SetValue(nameof(WaterPipeDirtyWaterNotification), value);
        //}
        //public bool WaterPipeSewageNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeSewageNotification));
        //    set => SetValue(nameof(WaterPipeSewageNotification), value);
        //}
        //public bool WaterPipeWaterPipeNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeWaterPipeNotConnectedNotification));
        //    set => SetValue(nameof(WaterPipeWaterPipeNotConnectedNotification), value);
        //}
        //public bool WaterPipeSewagePipeNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeSewagePipeNotConnectedNotification));
        //    set => SetValue(nameof(WaterPipeSewagePipeNotConnectedNotification), value);
        //}
        //public bool WaterPipeNotEnoughWaterCapacityNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughWaterCapacityNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughWaterCapacityNotification), value);
        //}
        //public bool WaterPipeNotEnoughSewageCapacityNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughSewageCapacityNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughSewageCapacityNotification), value);
        //}
        //public bool WaterPipeNotEnoughGroundwaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughGroundwaterNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughGroundwaterNotification), value);
        //}
        //public bool WaterPipeNotEnoughSurfaceWaterNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeNotEnoughSurfaceWaterNotification));
        //    set => SetValue(nameof(WaterPipeNotEnoughSurfaceWaterNotification), value);
        //}
        //public bool WaterPipeDirtyWaterPumpNotification
        //{
        //    get => (bool)GetValue(nameof(WaterPipeDirtyWaterPumpNotification));
        //    set => SetValue(nameof(WaterPipeDirtyWaterPumpNotification), value);
        //}
        //public bool BuildingAbandonedCollapsedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingAbandonedCollapsedNotification));
        //    set => SetValue(nameof(BuildingAbandonedCollapsedNotification), value);
        //}
        //public bool BuildingAbandonedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingAbandonedNotification));
        //    set => SetValue(nameof(BuildingAbandonedNotification), value);
        //}
        //public bool BuildingCondemnedNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingCondemnedNotification));
        //    set => SetValue(nameof(BuildingCondemnedNotification), value);
        //}
        //public bool BuildingTurnedOffNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingTurnedOffNotification));
        //    set => SetValue(nameof(BuildingTurnedOffNotification), value);
        //}
        //public bool BuildingHighRentNotification
        //{
        //    get => (bool)GetValue(nameof(BuildingHighRentNotification));
        //    set => SetValue(nameof(BuildingHighRentNotification), value);
        //}
        //public bool TrafficBottleneckNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficBottleneckNotification));
        //    set => SetValue(nameof(TrafficBottleneckNotification), value);
        //}
        //public bool TrafficDeadEndNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficDeadEndNotification));
        //    set => SetValue(nameof(TrafficDeadEndNotification), value);
        //}
        //public bool TrafficRoadConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficRoadConnectionNotification));
        //    set => SetValue(nameof(TrafficRoadConnectionNotification), value);
        //}
        //public bool TrafficTrackConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficTrackConnectionNotification));
        //    set => SetValue(nameof(TrafficTrackConnectionNotification), value);
        //}
        //public bool TrafficCarConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficCarConnectionNotification));
        //    set => SetValue(nameof(TrafficCarConnectionNotification), value);
        //}
        //public bool TrafficShipConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficShipConnectionNotification));
        //    set => SetValue(nameof(TrafficShipConnectionNotification), value);
        //}
        //public bool TrafficTrainConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficTrainConnectionNotification));
        //    set => SetValue(nameof(TrafficTrainConnectionNotification), value);
        //}
        //public bool TrafficPedestrianConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficPedestrianConnectionNotification));
        //    set => SetValue(nameof(TrafficPedestrianConnectionNotification), value);
        //}
        //public bool TrafficBicycleConnectionNotification
        //{
        //    get => (bool)GetValue(nameof(TrafficBicycleConnectionNotification));
        //    set => SetValue(nameof(TrafficBicycleConnectionNotification), value);
        //}
        //public bool CompanyNoInputsNotification
        //{
        //    get => (bool)GetValue(nameof(CompanyNoInputsNotification));
        //    set => SetValue(nameof(CompanyNoInputsNotification), value);
        //}
        //public bool CompanyNoCustomersNotification
        //{
        //    get => (bool)GetValue(nameof(CompanyNoCustomersNotification));
        //    set => SetValue(nameof(CompanyNoCustomersNotification), value);
        //}
        //public bool WorkProviderUneducatedNotification
        //{
        //    get => (bool)GetValue(nameof(WorkProviderUneducatedNotification));
        //    set => SetValue(nameof(WorkProviderUneducatedNotification), value);
        //}
        //public bool WorkProviderEducatedNotification
        //{
        //    get => (bool)GetValue(nameof(WorkProviderEducatedNotification));
        //    set => SetValue(nameof(WorkProviderEducatedNotification), value);
        //}
        //public bool DisasterWeatherDamageNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWeatherDamageNotification));
        //    set => SetValue(nameof(DisasterWeatherDamageNotification), value);
        //}
        //public bool DisasterWeatherDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWeatherDestroyedNotification));
        //    set => SetValue(nameof(DisasterWeatherDestroyedNotification), value);
        //}
        //public bool DisasterWaterDamageNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWaterDamageNotification));
        //    set => SetValue(nameof(DisasterWaterDamageNotification), value);
        //}
        //public bool DisasterWaterDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterWaterDestroyedNotification));
        //    set => SetValue(nameof(DisasterWaterDestroyedNotification), value);
        //}
        //public bool DisasterDestroyedNotification
        //{
        //    get => (bool)GetValue(nameof(DisasterDestroyedNotification));
        //    set => SetValue(nameof(DisasterDestroyedNotification), value);
        //}
        //public bool FireFireNotification
        //{
        //    get => (bool)GetValue(nameof(FireFireNotification));
        //    set => SetValue(nameof(FireFireNotification), value);
        //}
        //public bool FireBurnedDownNotification
        //{
        //    get => (bool)GetValue(nameof(FireBurnedDownNotification));
        //    set => SetValue(nameof(FireBurnedDownNotification), value);
        //}
        //public bool GarbageGarbageNotification
        //{
        //    get => (bool)GetValue(nameof(GarbageGarbageNotification));
        //    set => SetValue(nameof(GarbageGarbageNotification), value);
        //}
        //public bool GarbageFacilityFullNotification
        //{
        //    get => (bool)GetValue(nameof(GarbageFacilityFullNotification));
        //    set => SetValue(nameof(GarbageFacilityFullNotification), value);
        //}
        //public bool HealthcareAmbulanceNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareAmbulanceNotification));
        //    set => SetValue(nameof(HealthcareAmbulanceNotification), value);
        //}
        //public bool HealthcareHearseNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareHearseNotification));
        //    set => SetValue(nameof(HealthcareHearseNotification), value);
        //}
        //public bool HealthcareFacilityFullNotification
        //{
        //    get => (bool)GetValue(nameof(HealthcareFacilityFullNotification));
        //    set => SetValue(nameof(HealthcareFacilityFullNotification), value);
        //}
        //public bool PoliceTrafficAccidentNotification
        //{
        //    get => (bool)GetValue(nameof(PoliceTrafficAccidentNotification));
        //    set => SetValue(nameof(PoliceTrafficAccidentNotification), value);
        //}
        //public bool PoliceCrimeSceneNotification
        //{
        //    get => (bool)GetValue(nameof(PoliceCrimeSceneNotification));
        //    set => SetValue(nameof(PoliceCrimeSceneNotification), value);
        //}
        //public bool PollutionAirPollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionAirPollutionNotification));
        //    set => SetValue(nameof(PollutionAirPollutionNotification), value);
        //}
        //public bool PollutionNoisePollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionNoisePollutionNotification));
        //    set => SetValue(nameof(PollutionNoisePollutionNotification), value);
        //}
        //public bool PollutionGroundPollutionNotification
        //{
        //    get => (bool)GetValue(nameof(PollutionGroundPollutionNotification));
        //    set => SetValue(nameof(PollutionGroundPollutionNotification), value);
        //}
        //public bool ResourceConsumerNoResourceNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConsumerNoResourceNotification));
        //    set => SetValue(nameof(ResourceConsumerNoResourceNotification), value);
        //}
        //public bool ResourceConsumerNoFuelNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConsumerNoFuelNotification));
        //    set => SetValue(nameof(ResourceConsumerNoFuelNotification), value);
        //}
        //public bool ResourceConnectionWarningNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConnectionWarningNotification));
        //    set => SetValue(nameof(ResourceConnectionWarningNotification), value);
        //}
        //public bool ResourceConnectionOilPipeNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConnectionOilPipeNotConnectedNotification));
        //    set => SetValue(nameof(ResourceConnectionOilPipeNotConnectedNotification), value);
        //}
        //public bool ResourceConnectionFishingPierNotConnectedNotification
        //{
        //    get => (bool)GetValue(nameof(ResourceConnectionFishingPierNotConnectedNotification));
        //    set => SetValue(nameof(ResourceConnectionFishingPierNotConnectedNotification), value);
        //}
        //public bool RoutePathfindNotification
        //{
        //    get => (bool)GetValue(nameof(RoutePathfindNotification));
        //    set => SetValue(nameof(RoutePathfindNotification), value);
        //}
        //public bool RouteGateBypassNotification
        //{
        //    get => (bool)GetValue(nameof(RouteGateBypassNotification));
        //    set => SetValue(nameof(RouteGateBypassNotification), value);
        //}
        //public bool TransportLineVehicleNotification
        //{
        //    get => (bool)GetValue(nameof(TransportLineVehicleNotification));
        //    set => SetValue(nameof(TransportLineVehicleNotification), value);
        //}
    }

    public class CivicVoiceSettings : SettingsBackup
    {
        public bool UseUniversalModMenu
        {
            get => (bool)GetValue(nameof(UseUniversalModMenu));
            set => SetValue(nameof(UseUniversalModMenu), value);
        }
        public bool ShowNotifications
        {
            get => (bool)GetValue(nameof(ShowNotifications));
            set => SetValue(nameof(ShowNotifications), value);
        }

        //public bool ResetToDefaults
        //{
        //    get => (bool)GetValue(nameof(ResetToDefaults));
        //    set => SetValue(nameof(ResetToDefaults), value);
        //}
        public int UnemploymentThreshold
        {
            get => (int)GetValue(nameof(UnemploymentThreshold));
            set => SetValue(nameof(UnemploymentThreshold), value);
        }
        public int HomelessThreshold
        {
            get => (int)GetValue(nameof(HomelessThreshold));
            set => SetValue(nameof(HomelessThreshold), value);
        }
        public int CrimeRateThreshold
        {
            get => (int)GetValue(nameof(CrimeRateThreshold));
            set => SetValue(nameof(CrimeRateThreshold), value);
        }
        public int HousingDemandThreshold
        {
            get => (int)GetValue(nameof(HousingDemandThreshold));
            set => SetValue(nameof(HousingDemandThreshold), value);
        }
        public int HealthThreshold
        {
            get => (int)GetValue(nameof(HealthThreshold));
            set => SetValue(nameof(HealthThreshold), value);
        }
        public int WellbeingThreshold
        {
            get => (int)GetValue(nameof(WellbeingThreshold));
            set => SetValue(nameof(WellbeingThreshold), value);
        }
        public int MaxActiveMetricProposals
        {
            get => (int)GetValue(nameof(MaxActiveMetricProposals));
            set => SetValue(nameof(MaxActiveMetricProposals), value);
        }
        public int MaxActiveAdHocProposals
        {
            get => (int)GetValue(nameof(MaxActiveAdHocProposals));
            set => SetValue(nameof(MaxActiveAdHocProposals), value);
        }
        public int MaxActiveMajorProposals
        {
            get => (int)GetValue(nameof(MaxActiveMajorProposals));
            set => SetValue(nameof(MaxActiveMajorProposals), value);
        }
        public int MajorProjectMinPopulation
        {
            get => (int)GetValue(nameof(MajorProjectMinPopulation));
            set => SetValue(nameof(MajorProjectMinPopulation), value);
        }
        public int AdHocCooldownMonths
        {
            get => (int)GetValue(nameof(AdHocCooldownMonths));
            set => SetValue(nameof(AdHocCooldownMonths), value);
        }
        public int RejectedCooldownMonths
        {
            get => (int)GetValue(nameof(RejectedCooldownMonths));
            set => SetValue(nameof(RejectedCooldownMonths), value);
        }
        public int MetricProposalCooldownMonths
        {
            get => (int)GetValue(nameof(MetricProposalCooldownMonths));
            set => SetValue(nameof(MetricProposalCooldownMonths), value);
        }

        //public bool ForceElection
        //{
        //    get => (bool)GetValue(nameof(ForceElection));
        //    set => SetValue(nameof(ForceElection), value);
        //}
        public int ElectionFrequencyMonths
        {
            get => (int)GetValue(nameof(ElectionFrequencyMonths));
            set => SetValue(nameof(ElectionFrequencyMonths), value);
        }
        public int MinPopulationForElection
        {
            get => (int)GetValue(nameof(MinPopulationForElection));
            set => SetValue(nameof(MinPopulationForElection), value);
        }
        public int EndorsementInfluencePercent
        {
            get => (int)GetValue(nameof(EndorsementInfluencePercent));
            set => SetValue(nameof(EndorsementInfluencePercent), value);
        }
        //public bool ConcludeElection
        //{
        //    get => (bool)GetValue(nameof(ConcludeElection));
        //    set => SetValue(nameof(ConcludeElection), value);
        //}
    }

    public class ClearanceHelperSettings : SettingsBackup
    {
        public float RoadHeight
        {
            get => (float)GetValue(nameof(RoadHeight));
            set => SetValue(nameof(RoadHeight), value);
        }
        public float TrainTrackHeight
        {
            get => (float)GetValue(nameof(TrainTrackHeight));
            set => SetValue(nameof(TrainTrackHeight), value);
        }
        public float TramTrackHeight
        {
            get => (float)GetValue(nameof(TramTrackHeight));
            set => SetValue(nameof(TramTrackHeight), value);
        }
        public float SubwayTrackHeight
        {
            get => (float)GetValue(nameof(SubwayTrackHeight));
            set => SetValue(nameof(SubwayTrackHeight), value);
        }
        public float WaterwayHeight
        {
            get => (float)GetValue(nameof(WaterwayHeight));
            set => SetValue(nameof(WaterwayHeight), value);
        }
    }

    public class CollisionBeGoneSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public int ClippingMode
        {
            get => (int)GetValue(nameof(ClippingMode));
            set => SetValue(nameof(ClippingMode), value);
        }
        public bool ClipEmergency
        {
            get => (bool)GetValue(nameof(ClipEmergency));
            set => SetValue(nameof(ClipEmergency), value);
        }
        public bool ClipService
        {
            get => (bool)GetValue(nameof(ClipService));
            set => SetValue(nameof(ClipService), value);
        }
        public bool ClipPublicTransport
        {
            get => (bool)GetValue(nameof(ClipPublicTransport));
            set => SetValue(nameof(ClipPublicTransport), value);
        }
        public bool ClipCargo
        {
            get => (bool)GetValue(nameof(ClipCargo));
            set => SetValue(nameof(ClipCargo), value);
        }
        public bool ClipPersonal
        {
            get => (bool)GetValue(nameof(ClipPersonal));
            set => SetValue(nameof(ClipPersonal), value);
        }
    }

    public class ColoredBikePathSettings : SettingsBackup
    {
        public int ColorPreset
        {
            get => (int)GetValue(nameof(ColorPreset));
            set => SetValue(nameof(ColorPreset), value);
        }
        public string CustomColorHex
        {
            get => (string)GetValue(nameof(CustomColorHex));
            set => SetValue(nameof(CustomColorHex), value);
        }
        public float CustomColorRed
        {
            get => (float)GetValue(nameof(CustomColorRed));
            set => SetValue(nameof(CustomColorRed), value);
        }
        public float CustomColorGreen
        {
            get => (float)GetValue(nameof(CustomColorGreen));
            set => SetValue(nameof(CustomColorGreen), value);
        }
        public float CustomColorBlue
        {
            get => (float)GetValue(nameof(CustomColorBlue));
            set => SetValue(nameof(CustomColorBlue), value);
        }
        public float ColorIntensity
        {
            get => (float)GetValue(nameof(ColorIntensity));
            set => SetValue(nameof(ColorIntensity), value);
        }
        public float Saturation
        {
            get => (float)GetValue(nameof(Saturation));
            set => SetValue(nameof(Saturation), value);
        }
        public float Brightness
        {
            get => (float)GetValue(nameof(Brightness));
            set => SetValue(nameof(Brightness), value);
        }
        public bool OnlyBikeLanesNotPedestrian
        {
            get => (bool)GetValue(nameof(OnlyBikeLanesNotPedestrian));
            set => SetValue(nameof(OnlyBikeLanesNotPedestrian), value);
        }
        public bool ColorMixedPaths
        {
            get => (bool)GetValue(nameof(ColorMixedPaths));
            set => SetValue(nameof(ColorMixedPaths), value);
        }
    }

    public class ColoredBusLaneSettings : SettingsBackup
    {
        public int ColorPreset
        {
            get => (int)GetValue(nameof(ColorPreset));
            set => SetValue(nameof(ColorPreset), value);
        }
        public bool EnableColoring
        {
            get => (bool)GetValue(nameof(EnableColoring));
            set => SetValue(nameof(EnableColoring), value);
        }
        public string CustomColorHex
        {
            get => (string)GetValue(nameof(CustomColorHex));
            set => SetValue(nameof(CustomColorHex), value);
        }
        public float CustomColorRed
        {
            get => (float)GetValue(nameof(CustomColorRed));
            set => SetValue(nameof(CustomColorRed), value);
        }
        public float CustomColorGreen
        {
            get => (float)GetValue(nameof(CustomColorGreen));
            set => SetValue(nameof(CustomColorGreen), value);
        }
        public float CustomColorBlue
        {
            get => (float)GetValue(nameof(CustomColorBlue));
            set => SetValue(nameof(CustomColorBlue), value);
        }
        public float ColorIntensity
        {
            get => (float)GetValue(nameof(ColorIntensity));
            set => SetValue(nameof(ColorIntensity), value);
        }
        public float Saturation
        {
            get => (float)GetValue(nameof(Saturation));
            set => SetValue(nameof(Saturation), value);
        }
        public float Brightness
        {
            get => (float)GetValue(nameof(Brightness));
            set => SetValue(nameof(Brightness), value);
        }
    }

    public class ConfigXMLSettings : SettingsBackup
    {
        //public bool _Hidden
        //{
        //    get => (bool)GetValue(nameof(_Hidden));
        //    set => SetValue(nameof(_Hidden), value);
        //}
        public bool UseModPresets
        {
            get => (bool)GetValue(nameof(UseModPresets));
            set => SetValue(nameof(UseModPresets), value);
        }
        public bool UseLocalConfig
        {
            get => (bool)GetValue(nameof(UseLocalConfig));
            set => SetValue(nameof(UseLocalConfig), value);
        }
        //public bool VerboseLogs
        //{
        //    get => (bool)GetValue(nameof(VerboseLogs));
        //    set => SetValue(nameof(VerboseLogs), value);
        //}
    }

    public class CrimeRemoverSettings : SettingsBackup
    {
        public bool EnableCrimeRemover
        {
            get => (bool)GetValue(nameof(EnableCrimeRemover));
            set => SetValue(nameof(EnableCrimeRemover), value);
        }
        public bool RemoveCriminals
        {
            get => (bool)GetValue(nameof(RemoveCriminals));
            set => SetValue(nameof(RemoveCriminals), value);
        }
        public float CrimeBuildingPercentage
        {
            get => (float)GetValue(nameof(CrimeBuildingPercentage));
            set => SetValue(nameof(CrimeBuildingPercentage), value);
        }
        public float MaxCrime
        {
            get => (float)GetValue(nameof(MaxCrime));
            set => SetValue(nameof(MaxCrime), value);
        }
        public float CrimePercentage
        {
            get => (float)GetValue(nameof(CrimePercentage));
            set => SetValue(nameof(CrimePercentage), value);
        }
        public bool PolicePatrol
        {
            get => (bool)GetValue(nameof(PolicePatrol));
            set => SetValue(nameof(PolicePatrol), value);
        }
        public int RemoveNotification
        {
            get => (int)GetValue(nameof(RemoveNotification));
            set => SetValue(nameof(RemoveNotification), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class CustomChirpsSettings : SettingsBackup
    {
        public bool disable_vanilla_chirps
        {
            get => (bool)GetValue(nameof(disable_vanilla_chirps));
            set => SetValue(nameof(disable_vanilla_chirps), value);
        }
        public bool hide_vanilla_chirps_in_chirper_panel
        {
            get => (bool)GetValue(nameof(hide_vanilla_chirps_in_chirper_panel));
            set => SetValue(nameof(hide_vanilla_chirps_in_chirper_panel), value);
        }
    }

    public class CustomizableMenuSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public bool ProtectVanillaMenu
        {
            get => (bool)GetValue(nameof(ProtectVanillaMenu));
            set => SetValue(nameof(ProtectVanillaMenu), value);
        }
        public bool ActivateEmbedRules
        {
            get => (bool)GetValue(nameof(ActivateEmbedRules));
            set => SetValue(nameof(ActivateEmbedRules), value);
        }
        public string UpdateSource
        {
            get => (string)GetValue(nameof(UpdateSource));
            set => SetValue(nameof(UpdateSource), value);
        }
    }

    public class CustomRoadSnapSettings : SettingsBackup
    {
        public bool SnapEnabled
        {
            get => (bool)GetValue(nameof(SnapEnabled));
            set => SetValue(nameof(SnapEnabled), value);
        }
        public float SnapAngle
        {
            get => (float)GetValue(nameof(SnapAngle));
            set => SetValue(nameof(SnapAngle), value);
        }
    }

    public class CustomTourismSettings : SettingsBackup
    {
        public string[] OverridePrefabNames
        {
            get => (string[])GetValue(nameof(OverridePrefabNames));
            set => SetValue(nameof(OverridePrefabNames), value);
        }
        public int[] OverrideValues
        {
            get => (int[])GetValue(nameof(OverrideValues));
            set => SetValue(nameof(OverrideValues), value);
        }
        public int TargetTouristCount
        {
            get => (int)GetValue(nameof(TargetTouristCount));
            set => SetValue(nameof(TargetTouristCount), value);
        }
        public int Aggressiveness
        {
            get => (int)GetValue(nameof(Aggressiveness));
            set => SetValue(nameof(Aggressiveness), value);
        }
        public int RoadWeight
        {
            get => (int)GetValue(nameof(RoadWeight));
            set => SetValue(nameof(RoadWeight), value);
        }
        public int TrainWeight
        {
            get => (int)GetValue(nameof(TrainWeight));
            set => SetValue(nameof(TrainWeight), value);
        }
        public int AirWeight
        {
            get => (int)GetValue(nameof(AirWeight));
            set => SetValue(nameof(AirWeight), value);
        }
        public int ShipWeight
        {
            get => (int)GetValue(nameof(ShipWeight));
            set => SetValue(nameof(ShipWeight), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class DCMilestoneRewardsSettings : SettingsBackup
    {
        public bool disableMilestoneRewards
        {
            get => (bool)GetValue(nameof(disableMilestoneRewards));
            set => SetValue(nameof(disableMilestoneRewards), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class DemandMasterControlSettings : SettingsBackup
    {
        //public bool vanillaDataSet
        //{
        //    get => (bool)GetValue(nameof(vanillaDataSet));
        //    set => SetValue(nameof(vanillaDataSet), value);
        //}
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
        public int NeutralHomelessness
        {
            get => (int)GetValue(nameof(NeutralHomelessness));
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
        public float CommercialBaseDemand
        {
            get => (float)GetValue(nameof(CommercialBaseDemand));
            set => SetValue(nameof(CommercialBaseDemand), value);
        }

        //public float FreeCommercialProportion
        //{
        //    get => (float)GetValue(nameof(FreeCommercialProportion));
        //    set => SetValue(nameof(FreeCommercialProportion), value);
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
        public float HotelRoomPercentRequirement
        {
            get => (float)GetValue(nameof(HotelRoomPercentRequirement));
            set => SetValue(nameof(HotelRoomPercentRequirement), value);
        }
        public float IndustrialBaseDemand
        {
            get => (float)GetValue(nameof(IndustrialBaseDemand));
            set => SetValue(nameof(IndustrialBaseDemand), value);
        }

        //public float FreeIndustrialProportion
        //{
        //    get => (float)GetValue(nameof(FreeIndustrialProportion));
        //    set => SetValue(nameof(FreeIndustrialProportion), value);
        //}
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
        public string CurrentHappinessValue
        {
            get => (string)GetValue(nameof(CurrentHappinessValue));
            set => SetValue(nameof(CurrentHappinessValue), value);
        }
        public bool IsRealisticTripsRunning
        {
            get => (bool)GetValue(nameof(IsRealisticTripsRunning));
            set => SetValue(nameof(IsRealisticTripsRunning), value);
        }
        //public bool NotGameMode
        //{
        //    get => (bool)GetValue(nameof(NotGameMode));
        //    set => SetValue(nameof(NotGameMode), value);
        //}
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
        public bool ShowPublicTransportCapacity
        {
            get => (bool)GetValue(nameof(ShowPublicTransportCapacity));
            set => SetValue(nameof(ShowPublicTransportCapacity), value);
        }
        public string PublicTransportCapacityFormat
        {
            get => (string)GetValue(nameof(PublicTransportCapacityFormat));
            set => SetValue(nameof(PublicTransportCapacityFormat), value);
        }
        public bool AvoidPublicTransportCapacityDuplication
        {
            get => (bool)GetValue(nameof(AvoidPublicTransportCapacityDuplication));
            set => SetValue(nameof(AvoidPublicTransportCapacityDuplication), value);
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

    public class DisableHoverSettings : SettingsBackup
    {
        public bool DisableUIToolTips
        {
            get => (bool)GetValue(nameof(DisableUIToolTips));
            set => SetValue(nameof(DisableUIToolTips), value);
        }
        public bool DisableBlueHighLightOnBuildings
        {
            get => (bool)GetValue(nameof(DisableBlueHighLightOnBuildings));
            set => SetValue(nameof(DisableBlueHighLightOnBuildings), value);
        }
    }

    public class DisablePlacementSwaySettings : SettingsBackup
    {
        public bool DisablePlacementSway
        {
            get => (bool)GetValue(nameof(DisablePlacementSway));
            set => SetValue(nameof(DisablePlacementSway), value);
        }
    }

    public class EasyZoningSettings : SettingsBackup
    {
        public bool RemoveOccupiedCells
        {
            get => (bool)GetValue(nameof(RemoveOccupiedCells));
            set => SetValue(nameof(RemoveOccupiedCells), value);
        }
        public bool RemoveZonedCells
        {
            get => (bool)GetValue(nameof(RemoveZonedCells));
            set => SetValue(nameof(RemoveZonedCells), value);
        }
        public bool ShowContourButton
        {
            get => (bool)GetValue(nameof(ShowContourButton));
            set => SetValue(nameof(ShowContourButton), value);
        }
        public bool UseGlassPanel
        {
            get => (bool)GetValue(nameof(UseGlassPanel));
            set => SetValue(nameof(UseGlassPanel), value);
        }
        public string RemovePreviewBorderStyle
        {
            get => (string)GetValue(nameof(RemovePreviewBorderStyle));
            set => SetValue(nameof(RemovePreviewBorderStyle), value);
        }
        public bool UseOrangeRemovePreviewEdge
        {
            get => (bool)GetValue(nameof(UseOrangeRemovePreviewEdge));
            set => SetValue(nameof(UseOrangeRemovePreviewEdge), value);
        }
        public int RemovePreviewEdgeOpacityPercent
        {
            get => (int)GetValue(nameof(RemovePreviewEdgeOpacityPercent));
            set => SetValue(nameof(RemovePreviewEdgeOpacityPercent), value);
        }
        public string RemovePreviewFillStyle
        {
            get => (string)GetValue(nameof(RemovePreviewFillStyle));
            set => SetValue(nameof(RemovePreviewFillStyle), value);
        }
        public int RemovePreviewFillOpacityPercent
        {
            get => (int)GetValue(nameof(RemovePreviewFillOpacityPercent));
            set => SetValue(nameof(RemovePreviewFillOpacityPercent), value);
        }
        public bool ShowUsage
        {
            get => (bool)GetValue(nameof(ShowUsage));
            set => SetValue(nameof(ShowUsage), value);
        }
        public bool LegacyRightClickCycle
        {
            get => (bool)GetValue(nameof(LegacyRightClickCycle));
            set => SetValue(nameof(LegacyRightClickCycle), value);
        }
    }

    public class EconomyEXSettings : SettingsBackup
    {
        public string StatusInfo
        {
            get => (string)GetValue(nameof(StatusInfo));
            set => SetValue(nameof(StatusInfo), value);
        }
        public bool EnableEconomyFix
        {
            get => (bool)GetValue(nameof(EnableEconomyFix));
            set => SetValue(nameof(EnableEconomyFix), value);
        }
        public bool EnableDemandEcoSystem
        {
            get => (bool)GetValue(nameof(EnableDemandEcoSystem));
            set => SetValue(nameof(EnableDemandEcoSystem), value);
        }
        public bool EnableJobSearchEcoSystem
        {
            get => (bool)GetValue(nameof(EnableJobSearchEcoSystem));
            set => SetValue(nameof(EnableJobSearchEcoSystem), value);
        }
        public bool EnableHouseholdPropertyEcoSystem
        {
            get => (bool)GetValue(nameof(EnableHouseholdPropertyEcoSystem));
            set => SetValue(nameof(EnableHouseholdPropertyEcoSystem), value);
        }
        public bool EnableResourceBuyerEcoSystem
        {
            get => (bool)GetValue(nameof(EnableResourceBuyerEcoSystem));
            set => SetValue(nameof(EnableResourceBuyerEcoSystem), value);
        }
        public bool EnableResidentAIEcoSystem
        {
            get => (bool)GetValue(nameof(EnableResidentAIEcoSystem));
            set => SetValue(nameof(EnableResidentAIEcoSystem), value);
        }
        public float ShoppingMaxCost
        {
            get => (float)GetValue(nameof(ShoppingMaxCost));
            set => SetValue(nameof(ShoppingMaxCost), value);
        }
        public float CompanyShoppingMaxCost
        {
            get => (float)GetValue(nameof(CompanyShoppingMaxCost));
            set => SetValue(nameof(CompanyShoppingMaxCost), value);
        }
        public float LeisureMaxCost
        {
            get => (float)GetValue(nameof(LeisureMaxCost));
            set => SetValue(nameof(LeisureMaxCost), value);
        }
        public float EmergencyMaxCost
        {
            get => (float)GetValue(nameof(EmergencyMaxCost));
            set => SetValue(nameof(EmergencyMaxCost), value);
        }
        public float FindJobMaxCost
        {
            get => (float)GetValue(nameof(FindJobMaxCost));
            set => SetValue(nameof(FindJobMaxCost), value);
        }
        public float FindHomeMaxCost
        {
            get => (float)GetValue(nameof(FindHomeMaxCost));
            set => SetValue(nameof(FindHomeMaxCost), value);
        }
        public float FindSchoolElementaryMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolElementaryMaxCost));
            set => SetValue(nameof(FindSchoolElementaryMaxCost), value);
        }
        public float FindSchoolHighSchoolMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolHighSchoolMaxCost));
            set => SetValue(nameof(FindSchoolHighSchoolMaxCost), value);
        }
        public float FindSchoolCollegeMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolCollegeMaxCost));
            set => SetValue(nameof(FindSchoolCollegeMaxCost), value);
        }
        public float FindSchoolUniversityMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolUniversityMaxCost));
            set => SetValue(nameof(FindSchoolUniversityMaxCost), value);
        }
        public int JobSeekerCap
        {
            get => (int)GetValue(nameof(JobSeekerCap));
            set => SetValue(nameof(JobSeekerCap), value);
        }
        public int PathfindRequestCap
        {
            get => (int)GetValue(nameof(PathfindRequestCap));
            set => SetValue(nameof(PathfindRequestCap), value);
        }
        public float ShoppingTrafficReduction
        {
            get => (float)GetValue(nameof(ShoppingTrafficReduction));
            set => SetValue(nameof(ShoppingTrafficReduction), value);
        }
        public float HouseholdResourceDemandMultiplier
        {
            get => (float)GetValue(nameof(HouseholdResourceDemandMultiplier));
            set => SetValue(nameof(HouseholdResourceDemandMultiplier), value);
        }
        public int HomeSeekerCap
        {
            get => (int)GetValue(nameof(HomeSeekerCap));
            set => SetValue(nameof(HomeSeekerCap), value);
        }
        public int HomelessSeekerCap
        {
            get => (int)GetValue(nameof(HomelessSeekerCap));
            set => SetValue(nameof(HomelessSeekerCap), value);
        }
        public int LandValueEnvironmentEffect
        {
            get => (int)GetValue(nameof(LandValueEnvironmentEffect));
            set => SetValue(nameof(LandValueEnvironmentEffect), value);
        }
        public int ServiceBonusCapMultiplier
        {
            get => (int)GetValue(nameof(ServiceBonusCapMultiplier));
            set => SetValue(nameof(ServiceBonusCapMultiplier), value);
        }
        public int RentMultiplierResidential
        {
            get => (int)GetValue(nameof(RentMultiplierResidential));
            set => SetValue(nameof(RentMultiplierResidential), value);
        }
        public int RentMultiplierCommercial
        {
            get => (int)GetValue(nameof(RentMultiplierCommercial));
            set => SetValue(nameof(RentMultiplierCommercial), value);
        }
        public int RentMultiplierIndustrial
        {
            get => (int)GetValue(nameof(RentMultiplierIndustrial));
            set => SetValue(nameof(RentMultiplierIndustrial), value);
        }
        public int LandValueFactorResidential
        {
            get => (int)GetValue(nameof(LandValueFactorResidential));
            set => SetValue(nameof(LandValueFactorResidential), value);
        }
        public int LandValueFactorCommercial
        {
            get => (int)GetValue(nameof(LandValueFactorCommercial));
            set => SetValue(nameof(LandValueFactorCommercial), value);
        }
        public int LandValueFactorIndustrial
        {
            get => (int)GetValue(nameof(LandValueFactorIndustrial));
            set => SetValue(nameof(LandValueFactorIndustrial), value);
        }
        public int LevelFactorResidential
        {
            get => (int)GetValue(nameof(LevelFactorResidential));
            set => SetValue(nameof(LevelFactorResidential), value);
        }
        public int LevelFactorCommercial
        {
            get => (int)GetValue(nameof(LevelFactorCommercial));
            set => SetValue(nameof(LevelFactorCommercial), value);
        }
        public int LevelFactorIndustrial
        {
            get => (int)GetValue(nameof(LevelFactorIndustrial));
            set => SetValue(nameof(LevelFactorIndustrial), value);
        }
        public bool NoDogsOnStreet
        {
            get => (bool)GetValue(nameof(NoDogsOnStreet));
            set => SetValue(nameof(NoDogsOnStreet), value);
        }
        public bool NoDogsGeneration
        {
            get => (bool)GetValue(nameof(NoDogsGeneration));
            set => SetValue(nameof(NoDogsGeneration), value);
        }
        public bool NoDogsPurge
        {
            get => (bool)GetValue(nameof(NoDogsPurge));
            set => SetValue(nameof(NoDogsPurge), value);
        }

        //public int CurrentPetCount
        //{
        //    get => (int)GetValue(nameof(CurrentPetCount));
        //    set => SetValue(nameof(CurrentPetCount), value);
        //}
        public bool NoThroughTraffic
        {
            get => (bool)GetValue(nameof(NoThroughTraffic));
            set => SetValue(nameof(NoThroughTraffic), value);
        }
        public int EditorCollisionSkip
        {
            get => (int)GetValue(nameof(EditorCollisionSkip));
            set => SetValue(nameof(EditorCollisionSkip), value);
        }
        public bool DisableWorldBackdrop
        {
            get => (bool)GetValue(nameof(DisableWorldBackdrop));
            set => SetValue(nameof(DisableWorldBackdrop), value);
        }
        public int WaterSimQuality
        {
            get => (int)GetValue(nameof(WaterSimQuality));
            set => SetValue(nameof(WaterSimQuality), value);
        }
        //public string PopDiagData
        //{
        //    get => (string)GetValue(nameof(PopDiagData));
        //    set => SetValue(nameof(PopDiagData), value);
        //}
        //public bool EnableVehicleRescue
        //{
        //    get => (bool)GetValue(nameof(EnableVehicleRescue));
        //    set => SetValue(nameof(EnableVehicleRescue), value);
        //}
        //public bool EnableRescueDebugLog
        //{
        //    get => (bool)GetValue(nameof(EnableRescueDebugLog));
        //    set => SetValue(nameof(EnableRescueDebugLog), value);
        //}
    }

    public class EmergencyGhostsSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public bool EmergencyOnly
        {
            get => (bool)GetValue(nameof(EmergencyOnly));
            set => SetValue(nameof(EmergencyOnly), value);
        }
        public float SpeedMultiplier
        {
            get => (float)GetValue(nameof(SpeedMultiplier));
            set => SetValue(nameof(SpeedMultiplier), value);
        }
    }

    public class EvenBetterSaveListSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }

        //public string SelectedCityName
        //{
        //    get => (string)GetValue(nameof(SelectedCityName));
        //    set => SetValue(nameof(SelectedCityName), value);
        //}
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

    public class EXRScreenshotSettings : SettingsBackup
    {
        public int ModeDropdown
        {
            get => (int)GetValue(nameof(ModeDropdown));
            set => SetValue(nameof(ModeDropdown), value);
        }
        public int CompressionDropdown
        {
            get => (int)GetValue(nameof(CompressionDropdown));
            set => SetValue(nameof(CompressionDropdown), value);
        }
        public float SupersampleScale
        {
            get => (float)GetValue(nameof(SupersampleScale));
            set => SetValue(nameof(SupersampleScale), value);
        }
        public int AccumulationFramesDropdown
        {
            get => (int)GetValue(nameof(AccumulationFramesDropdown));
            set => SetValue(nameof(AccumulationFramesDropdown), value);
        }
        public bool TakeSuperResolution
        {
            get => (bool)GetValue(nameof(TakeSuperResolution));
            set => SetValue(nameof(TakeSuperResolution), value);
        }
        public bool MetadataLogging
        {
            get => (bool)GetValue(nameof(MetadataLogging));
            set => SetValue(nameof(MetadataLogging), value);
        }
        //public bool DebugLogging
        //{
        //    get => (bool)GetValue(nameof(DebugLogging));
        //    set => SetValue(nameof(DebugLogging), value);
        //}
    }

    public class ExtendedRadioSettings : SettingsBackup
    {
        public bool DisableAdsOnStartup
        {
            get => (bool)GetValue(nameof(DisableAdsOnStartup));
            set => SetValue(nameof(DisableAdsOnStartup), value);
        }
        public bool SaveLastRadio
        {
            get => (bool)GetValue(nameof(SaveLastRadio));
            set => SetValue(nameof(SaveLastRadio), value);
        }
        public bool MixNetworkEnabled
        {
            get => (bool)GetValue(nameof(MixNetworkEnabled));
            set => SetValue(nameof(MixNetworkEnabled), value);
        }
        public bool MixNetworkClearQueue
        {
            get => (bool)GetValue(nameof(MixNetworkClearQueue));
            set => SetValue(nameof(MixNetworkClearQueue), value);
        }
        public bool MixNetworkFinishCurrentClip
        {
            get => (bool)GetValue(nameof(MixNetworkFinishCurrentClip));
            set => SetValue(nameof(MixNetworkFinishCurrentClip), value);
        }
        public bool AudioFormatMP3
        {
            get => (bool)GetValue(nameof(AudioFormatMP3));
            set => SetValue(nameof(AudioFormatMP3), value);
        }
        public bool AudioFormatWAV
        {
            get => (bool)GetValue(nameof(AudioFormatWAV));
            set => SetValue(nameof(AudioFormatWAV), value);
        }
        public bool AudioFormatFLAC
        {
            get => (bool)GetValue(nameof(AudioFormatFLAC));
            set => SetValue(nameof(AudioFormatFLAC), value);
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
        public bool ShowCitizenShift
        {
            get => (bool)GetValue(nameof(ShowCitizenShift));
            set => SetValue(nameof(ShowCitizenShift), value);
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
        public bool ShowSpeed
        {
            get => (bool)GetValue(nameof(ShowSpeed));
            set => SetValue(nameof(ShowSpeed), value);
        }
        public bool ShowActualSpeed
        {
            get => (bool)GetValue(nameof(ShowActualSpeed));
            set => SetValue(nameof(ShowActualSpeed), value);
        }
        public int SpeedUnit
        {
            get => (int)GetValue(nameof(SpeedUnit));
            set => SetValue(nameof(SpeedUnit), value);
        }
        public bool ShowVehicleProperties
        {
            get => (bool)GetValue(nameof(ShowVehicleProperties));
            set => SetValue(nameof(ShowVehicleProperties), value);
        }
    }

    public class ExtraAssetsImporterSettings : SettingsBackup
    {
        public bool UseNewImporters
        {
            get => (bool)GetValue(nameof(UseNewImporters));
            set => SetValue(nameof(UseNewImporters), value);
        }
        public int NewImportersCompatibilityDropDown
        {
            get => (int)GetValue(nameof(NewImportersCompatibilityDropDown));
            set => SetValue(nameof(NewImportersCompatibilityDropDown), value);
        }
        public bool UseOldImporters
        {
            get => (bool)GetValue(nameof(UseOldImporters));
            set => SetValue(nameof(UseOldImporters), value);
        }
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
        public int OldImportersCompatibilityDropDown
        {
            get => (int)GetValue(nameof(OldImportersCompatibilityDropDown));
            set => SetValue(nameof(OldImportersCompatibilityDropDown), value);
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

    public class ExtractorBoostSettings : SettingsBackup
    {
        public int GrainMultiplier
        {
            get => (int)GetValue(nameof(GrainMultiplier));
            set => SetValue(nameof(GrainMultiplier), value);
        }
        public int VegetableMultiplier
        {
            get => (int)GetValue(nameof(VegetableMultiplier));
            set => SetValue(nameof(VegetableMultiplier), value);
        }
        public int CottonMultiplier
        {
            get => (int)GetValue(nameof(CottonMultiplier));
            set => SetValue(nameof(CottonMultiplier), value);
        }
        public int LivestockMultiplier
        {
            get => (int)GetValue(nameof(LivestockMultiplier));
            set => SetValue(nameof(LivestockMultiplier), value);
        }
        public int OilMultiplier
        {
            get => (int)GetValue(nameof(OilMultiplier));
            set => SetValue(nameof(OilMultiplier), value);
        }
        public int OreMultiplier
        {
            get => (int)GetValue(nameof(OreMultiplier));
            set => SetValue(nameof(OreMultiplier), value);
        }
        public int CoalMultiplier
        {
            get => (int)GetValue(nameof(CoalMultiplier));
            set => SetValue(nameof(CoalMultiplier), value);
        }
        public int StoneMultiplier
        {
            get => (int)GetValue(nameof(StoneMultiplier));
            set => SetValue(nameof(StoneMultiplier), value);
        }
        public int WoodMultiplier
        {
            get => (int)GetValue(nameof(WoodMultiplier));
            set => SetValue(nameof(WoodMultiplier), value);
        }
        public int FishMultiplier
        {
            get => (int)GetValue(nameof(FishMultiplier));
            set => SetValue(nameof(FishMultiplier), value);
        }
    }

    public class ExtractorsBegoneSettings : SettingsBackup
    {
        public bool DisableExtractorBuildings
        {
            get => (bool)GetValue(nameof(DisableExtractorBuildings));
            set => SetValue(nameof(DisableExtractorBuildings), value);
        }
        public float FarmExtractorsSpawnFactor
        {
            get => (float)GetValue(nameof(FarmExtractorsSpawnFactor));
            set => SetValue(nameof(FarmExtractorsSpawnFactor), value);
        }
        public float ForestExtractorsSpawnFactor
        {
            get => (float)GetValue(nameof(ForestExtractorsSpawnFactor));
            set => SetValue(nameof(ForestExtractorsSpawnFactor), value);
        }
        public float OilExtractorsSpawnFactor
        {
            get => (float)GetValue(nameof(OilExtractorsSpawnFactor));
            set => SetValue(nameof(OilExtractorsSpawnFactor), value);
        }
        public float OreExtractorsSpawnFactor
        {
            get => (float)GetValue(nameof(OreExtractorsSpawnFactor));
            set => SetValue(nameof(OreExtractorsSpawnFactor), value);
        }
        public float FishExtractorsSpawnFactor
        {
            get => (float)GetValue(nameof(FishExtractorsSpawnFactor));
            set => SetValue(nameof(FishExtractorsSpawnFactor), value);
        }
        public bool AllowFarmVehicles
        {
            get => (bool)GetValue(nameof(AllowFarmVehicles));
            set => SetValue(nameof(AllowFarmVehicles), value);
        }
        public bool AllowForestVehicles
        {
            get => (bool)GetValue(nameof(AllowForestVehicles));
            set => SetValue(nameof(AllowForestVehicles), value);
        }
        public bool AllowOilVehicles
        {
            get => (bool)GetValue(nameof(AllowOilVehicles));
            set => SetValue(nameof(AllowOilVehicles), value);
        }
        public bool AllowOreVehicles
        {
            get => (bool)GetValue(nameof(AllowOreVehicles));
            set => SetValue(nameof(AllowOreVehicles), value);
        }
        public bool AllowFishingBoats
        {
            get => (bool)GetValue(nameof(AllowFishingBoats));
            set => SetValue(nameof(AllowFishingBoats), value);
        }
    }

    public class FastBikesSettings : SettingsBackup
    {
        public bool EnableFastBikes
        {
            get => (bool)GetValue(nameof(EnableFastBikes));
            set => SetValue(nameof(EnableFastBikes), value);
        }
        public float SpeedScalar
        {
            get => (float)GetValue(nameof(SpeedScalar));
            set => SetValue(nameof(SpeedScalar), value);
        }
        public float StiffnessScalar
        {
            get => (float)GetValue(nameof(StiffnessScalar));
            set => SetValue(nameof(StiffnessScalar), value);
        }
        public float DampingScalar
        {
            get => (float)GetValue(nameof(DampingScalar));
            set => SetValue(nameof(DampingScalar), value);
        }
        public float PathSpeedScalar
        {
            get => (float)GetValue(nameof(PathSpeedScalar));
            set => SetValue(nameof(PathSpeedScalar), value);
        }
    }

    public class FastBoardingSettings : SettingsBackup
    {
        public int BusBoardingSpeedFactor
        {
            get => (int)GetValue(nameof(BusBoardingSpeedFactor));
            set => SetValue(nameof(BusBoardingSpeedFactor), value);
        }
        public int RailBoardingSpeedFactor
        {
            get => (int)GetValue(nameof(RailBoardingSpeedFactor));
            set => SetValue(nameof(RailBoardingSpeedFactor), value);
        }
        public int WaterBoardingSpeedFactor
        {
            get => (int)GetValue(nameof(WaterBoardingSpeedFactor));
            set => SetValue(nameof(WaterBoardingSpeedFactor), value);
        }
        public int AirBoardingSpeedFactor
        {
            get => (int)GetValue(nameof(AirBoardingSpeedFactor));
            set => SetValue(nameof(AirBoardingSpeedFactor), value);
        }
        public bool CancelLateBoarders
        {
            get => (bool)GetValue(nameof(CancelLateBoarders));
            set => SetValue(nameof(CancelLateBoarders), value);
        }
        public bool CimsRunSoonerToCatchBuses
        {
            get => (bool)GetValue(nameof(CimsRunSoonerToCatchBuses));
            set => SetValue(nameof(CimsRunSoonerToCatchBuses), value);
        }
        //public bool EnableVerboseLogging
        //{
        //    get => (bool)GetValue(nameof(EnableVerboseLogging));
        //    set => SetValue(nameof(EnableVerboseLogging), value);
        //}
    }

    public class FertilityControlSettings : SettingsBackup
    {
        public float FertilityPercentPerDay
        {
            get => (float)GetValue(nameof(FertilityPercentPerDay));
            set => SetValue(nameof(FertilityPercentPerDay), value);
        }
        public bool EnableOreOilRegen
        {
            get => (bool)GetValue(nameof(EnableOreOilRegen));
            set => SetValue(nameof(EnableOreOilRegen), value);
        }
        public float OrePercentPerDay
        {
            get => (float)GetValue(nameof(OrePercentPerDay));
            set => SetValue(nameof(OrePercentPerDay), value);
        }
        public float OilPercentPerDay
        {
            get => (float)GetValue(nameof(OilPercentPerDay));
            set => SetValue(nameof(OilPercentPerDay), value);
        }
    }

    public class FindCharacterSettings : SettingsBackup
    {
        public int ActivatedCharacterType
        {
            get => (int)GetValue(nameof(ActivatedCharacterType));
            set => SetValue(nameof(ActivatedCharacterType), value);
        }
        public string ActivatedPinyinNotation
        {
            get => (string)GetValue(nameof(ActivatedPinyinNotation));
            set => SetValue(nameof(ActivatedPinyinNotation), value);
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class FireStarterSettings : SettingsBackup
    {
        public bool enabled
        {
            get => (bool)GetValue(nameof(enabled));
            set => SetValue(nameof(enabled), value);
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
        public bool ShowGameUI
        {
            get => (bool)GetValue(nameof(ShowGameUI));
            set => SetValue(nameof(ShowGameUI), value);
        }
        public bool ShowInfoBox
        {
            get => (bool)GetValue(nameof(ShowInfoBox));
            set => SetValue(nameof(ShowInfoBox), value);
        }
        public int InfoBoxSize
        {
            get => (int)GetValue(nameof(InfoBoxSize));
            set => SetValue(nameof(InfoBoxSize), value);
        }
        public int PIPSnapToCorner
        {
            get => (int)GetValue(nameof(PIPSnapToCorner));
            set => SetValue(nameof(PIPSnapToCorner), value);
        }
        public float PIPAspectRatio
        {
            get => (float)GetValue(nameof(PIPAspectRatio));
            set => SetValue(nameof(PIPAspectRatio), value);
        }
        public float PIPSize
        {
            get => (float)GetValue(nameof(PIPSize));
            set => SetValue(nameof(PIPSize), value);
        }
        public bool ShowPIPOnEnter
        {
            get => (bool)GetValue(nameof(ShowPIPOnEnter));
            set => SetValue(nameof(ShowPIPOnEnter), value);
        }
        public bool ShowPIPMarker
        {
            get => (bool)GetValue(nameof(ShowPIPMarker));
            set => SetValue(nameof(ShowPIPMarker), value);
        }
        public bool ShowPIPUndergroundView
        {
            get => (bool)GetValue(nameof(ShowPIPUndergroundView));
            set => SetValue(nameof(ShowPIPUndergroundView), value);
        }
        public bool DisableVSync
        {
            get => (bool)GetValue(nameof(DisableVSync));
            set => SetValue(nameof(DisableVSync), value);
        }
        public int SetUnits
        {
            get => (int)GetValue(nameof(SetUnits));
            set => SetValue(nameof(SetUnits), value);
        }
        public bool ShowSpeed
        {
            get => (bool)GetValue(nameof(ShowSpeed));
            set => SetValue(nameof(ShowSpeed), value);
        }
        public bool ShowVehicleType
        {
            get => (bool)GetValue(nameof(ShowVehicleType));
            set => SetValue(nameof(ShowVehicleType), value);
        }
        public bool ShowExtraInfo
        {
            get => (bool)GetValue(nameof(ShowExtraInfo));
            set => SetValue(nameof(ShowExtraInfo), value);
        }
        public int ShowStopStrip
        {
            get => (int)GetValue(nameof(ShowStopStrip));
            set => SetValue(nameof(ShowStopStrip), value);
        }
        public int StopStripDisplayMode
        {
            get => (int)GetValue(nameof(StopStripDisplayMode));
            set => SetValue(nameof(StopStripDisplayMode), value);
        }
        public string LastSeenChangelogVersion
        {
            get => (string)GetValue(nameof(LastSeenChangelogVersion));
            set => SetValue(nameof(LastSeenChangelogVersion), value);
        }
        public int MakeSureSave
        {
            get => (int)GetValue(nameof(MakeSureSave));
            set => SetValue(nameof(MakeSureSave), value);
        }
    }

    public class FiveTwentyNineTilesSettings : SettingsBackup
    {
        public bool UnlockNone
        {
            get => (bool)GetValue(nameof(UnlockNone));
            set => SetValue(nameof(UnlockNone), value);
        }
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
        public float UpkeepMultiplier
        {
            get => (float)GetValue(nameof(UpkeepMultiplier));
            set => SetValue(nameof(UpkeepMultiplier), value);
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

    public class GhostwriterSettings : SettingsBackup
    {
        public int IntervalMinutes
        {
            get => (int)GetValue(nameof(IntervalMinutes));
            set => SetValue(nameof(IntervalMinutes), value);
        }
        public bool MapRefreshEnabled
        {
            get => (bool)GetValue(nameof(MapRefreshEnabled));
            set => SetValue(nameof(MapRefreshEnabled), value);
        }
        public int MapRefreshMinutes
        {
            get => (int)GetValue(nameof(MapRefreshMinutes));
            set => SetValue(nameof(MapRefreshMinutes), value);
        }
        public bool AutoSessionStartOnSaveLoad
        {
            get => (bool)GetValue(nameof(AutoSessionStartOnSaveLoad));
            set => SetValue(nameof(AutoSessionStartOnSaveLoad), value);
        }
        public bool ActiveEventsEnabled
        {
            get => (bool)GetValue(nameof(ActiveEventsEnabled));
            set => SetValue(nameof(ActiveEventsEnabled), value);
        }
        public int ActiveEventsIntervalMinutes
        {
            get => (int)GetValue(nameof(ActiveEventsIntervalMinutes));
            set => SetValue(nameof(ActiveEventsIntervalMinutes), value);
        }
        public int Provider
        {
            get => (int)GetValue(nameof(Provider));
            set => SetValue(nameof(Provider), value);
        }

        //public bool RevealApiKey
        //{
        //    get => (bool)GetValue(nameof(RevealApiKey));
        //    set => SetValue(nameof(RevealApiKey), value);
        //}
        //public string ApiKeyStatus
        //{
        //    get => (string)GetValue(nameof(ApiKeyStatus));
        //    set => SetValue(nameof(ApiKeyStatus), value);
        //}
        //public string ApiKey
        //{
        //    get => (string)GetValue(nameof(ApiKey));
        //    set => SetValue(nameof(ApiKey), value);
        //}
        public string Model
        {
            get => (string)GetValue(nameof(Model));
            set => SetValue(nameof(Model), value);
        }
        public string OllamaBaseUrl
        {
            get => (string)GetValue(nameof(OllamaBaseUrl));
            set => SetValue(nameof(OllamaBaseUrl), value);
        }
        public bool ShowToolCalls
        {
            get => (bool)GetValue(nameof(ShowToolCalls));
            set => SetValue(nameof(ShowToolCalls), value);
        }
    }

    public class GottaGoFastSettings : SettingsBackup
    {
        public bool Enable
        {
            get => (bool)GetValue(nameof(Enable));
            set => SetValue(nameof(Enable), value);
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
        public bool EnableMainMenuSlideshow
        {
            get => (bool)GetValue(nameof(EnableMainMenuSlideshow));
            set => SetValue(nameof(EnableMainMenuSlideshow), value);
        }
        public bool EnableLoadingScreenBackground
        {
            get => (bool)GetValue(nameof(EnableLoadingScreenBackground));
            set => SetValue(nameof(EnableLoadingScreenBackground), value);
        }
        public bool ShowFeaturedAsset
        {
            get => (bool)GetValue(nameof(ShowFeaturedAsset));
            set => SetValue(nameof(ShowFeaturedAsset), value);
        }
        public bool ShowCreatorSocials
        {
            get => (bool)GetValue(nameof(ShowCreatorSocials));
            set => SetValue(nameof(ShowCreatorSocials), value);
        }
        public bool ShowViewCount
        {
            get => (bool)GetValue(nameof(ShowViewCount));
            set => SetValue(nameof(ShowViewCount), value);
        }
        public string NamesTranslationMode
        {
            get => (string)GetValue(nameof(NamesTranslationMode));
            set => SetValue(nameof(NamesTranslationMode), value);
        }
        public int PopularScreenshotWeight
        {
            get => (int)GetValue(nameof(PopularScreenshotWeight));
            set => SetValue(nameof(PopularScreenshotWeight), value);
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
        public string CreatorsScreenshotSaveDirectory
        {
            get => (string)GetValue(nameof(CreatorsScreenshotSaveDirectory));
            set => SetValue(nameof(CreatorsScreenshotSaveDirectory), value);
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
        public string ScreenshotToLoad
        {
            get => (string)GetValue(nameof(ScreenshotToLoad));
            set => SetValue(nameof(ScreenshotToLoad), value);
        }
        public string ParadoxModsBrowsingPreference
        {
            get => (string)GetValue(nameof(ParadoxModsBrowsingPreference));
            set => SetValue(nameof(ParadoxModsBrowsingPreference), value);
        }
        public bool SavedShareModIdsPreference
        {
            get => (bool)GetValue(nameof(SavedShareModIdsPreference));
            set => SetValue(nameof(SavedShareModIdsPreference), value);
        }
        public bool SavedShareRenderSettingsPreference
        {
            get => (bool)GetValue(nameof(SavedShareRenderSettingsPreference));
            set => SetValue(nameof(SavedShareRenderSettingsPreference), value);
        }
        public string SavedScreenshotDescription
        {
            get => (string)GetValue(nameof(SavedScreenshotDescription));
            set => SetValue(nameof(SavedScreenshotDescription), value);
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
        public bool UnlockDistricts
        {
            get => (bool)GetValue(nameof(UnlockDistricts));
            set => SetValue(nameof(UnlockDistricts), value);
        }
    }

    public class HoverColorsSettings : SettingsBackup
    {
        public int GuidelineDefaultPercent
        {
            get => (int)GetValue(nameof(GuidelineDefaultPercent));
            set => SetValue(nameof(GuidelineDefaultPercent), value);
        }
        public float OutlineR
        {
            get => (float)GetValue(nameof(OutlineR));
            set => SetValue(nameof(OutlineR), value);
        }
        public float OutlineG
        {
            get => (float)GetValue(nameof(OutlineG));
            set => SetValue(nameof(OutlineG), value);
        }
        public float OutlineB
        {
            get => (float)GetValue(nameof(OutlineB));
            set => SetValue(nameof(OutlineB), value);
        }
        public float OutlineA
        {
            get => (float)GetValue(nameof(OutlineA));
            set => SetValue(nameof(OutlineA), value);
        }
        public float OwnerR
        {
            get => (float)GetValue(nameof(OwnerR));
            set => SetValue(nameof(OwnerR), value);
        }
        public float OwnerG
        {
            get => (float)GetValue(nameof(OwnerG));
            set => SetValue(nameof(OwnerG), value);
        }
        public float OwnerB
        {
            get => (float)GetValue(nameof(OwnerB));
            set => SetValue(nameof(OwnerB), value);
        }
        public float OwnerA
        {
            get => (float)GetValue(nameof(OwnerA));
            set => SetValue(nameof(OwnerA), value);
        }
        public float FillA
        {
            get => (float)GetValue(nameof(FillA));
            set => SetValue(nameof(FillA), value);
        }
        public bool DistrictColorEnabled
        {
            get => (bool)GetValue(nameof(DistrictColorEnabled));
            set => SetValue(nameof(DistrictColorEnabled), value);
        }
        public float DistrictR
        {
            get => (float)GetValue(nameof(DistrictR));
            set => SetValue(nameof(DistrictR), value);
        }
        public float DistrictG
        {
            get => (float)GetValue(nameof(DistrictG));
            set => SetValue(nameof(DistrictG), value);
        }
        public float DistrictB
        {
            get => (float)GetValue(nameof(DistrictB));
            set => SetValue(nameof(DistrictB), value);
        }
        public float DistrictA
        {
            get => (float)GetValue(nameof(DistrictA));
            set => SetValue(nameof(DistrictA), value);
        }
        public float Preset1R
        {
            get => (float)GetValue(nameof(Preset1R));
            set => SetValue(nameof(Preset1R), value);
        }
        public float Preset1G
        {
            get => (float)GetValue(nameof(Preset1G));
            set => SetValue(nameof(Preset1G), value);
        }
        public float Preset1B
        {
            get => (float)GetValue(nameof(Preset1B));
            set => SetValue(nameof(Preset1B), value);
        }
        public float Preset1A
        {
            get => (float)GetValue(nameof(Preset1A));
            set => SetValue(nameof(Preset1A), value);
        }
        public float Preset1FillA
        {
            get => (float)GetValue(nameof(Preset1FillA));
            set => SetValue(nameof(Preset1FillA), value);
        }
        public float Preset2R
        {
            get => (float)GetValue(nameof(Preset2R));
            set => SetValue(nameof(Preset2R), value);
        }
        public float Preset2G
        {
            get => (float)GetValue(nameof(Preset2G));
            set => SetValue(nameof(Preset2G), value);
        }
        public float Preset2B
        {
            get => (float)GetValue(nameof(Preset2B));
            set => SetValue(nameof(Preset2B), value);
        }
        public float Preset2A
        {
            get => (float)GetValue(nameof(Preset2A));
            set => SetValue(nameof(Preset2A), value);
        }
        public float Preset2FillA
        {
            get => (float)GetValue(nameof(Preset2FillA));
            set => SetValue(nameof(Preset2FillA), value);
        }
        public int Preset1GuidelinePercent
        {
            get => (int)GetValue(nameof(Preset1GuidelinePercent));
            set => SetValue(nameof(Preset1GuidelinePercent), value);
        }
        public int Preset2GuidelinePercent
        {
            get => (int)GetValue(nameof(Preset2GuidelinePercent));
            set => SetValue(nameof(Preset2GuidelinePercent), value);
        }
        public float GuidelineLinesR
        {
            get => (float)GetValue(nameof(GuidelineLinesR));
            set => SetValue(nameof(GuidelineLinesR), value);
        }
        public float GuidelineLinesG
        {
            get => (float)GetValue(nameof(GuidelineLinesG));
            set => SetValue(nameof(GuidelineLinesG), value);
        }
        public float GuidelineLinesB
        {
            get => (float)GetValue(nameof(GuidelineLinesB));
            set => SetValue(nameof(GuidelineLinesB), value);
        }
        public float GuidelineLinesA
        {
            get => (float)GetValue(nameof(GuidelineLinesA));
            set => SetValue(nameof(GuidelineLinesA), value);
        }
        public float GuidelinePreviewR
        {
            get => (float)GetValue(nameof(GuidelinePreviewR));
            set => SetValue(nameof(GuidelinePreviewR), value);
        }
        public float GuidelinePreviewG
        {
            get => (float)GetValue(nameof(GuidelinePreviewG));
            set => SetValue(nameof(GuidelinePreviewG), value);
        }
        public float GuidelinePreviewB
        {
            get => (float)GetValue(nameof(GuidelinePreviewB));
            set => SetValue(nameof(GuidelinePreviewB), value);
        }
        public float GuidelinePreviewA
        {
            get => (float)GetValue(nameof(GuidelinePreviewA));
            set => SetValue(nameof(GuidelinePreviewA), value);
        }
        public int GuidelineDashedColorPreset
        {
            get => (int)GetValue(nameof(GuidelineDashedColorPreset));
            set => SetValue(nameof(GuidelineDashedColorPreset), value);
        }
        public float GuidelineDashedR
        {
            get => (float)GetValue(nameof(GuidelineDashedR));
            set => SetValue(nameof(GuidelineDashedR), value);
        }
        public float GuidelineDashedG
        {
            get => (float)GetValue(nameof(GuidelineDashedG));
            set => SetValue(nameof(GuidelineDashedG), value);
        }
        public float GuidelineDashedB
        {
            get => (float)GetValue(nameof(GuidelineDashedB));
            set => SetValue(nameof(GuidelineDashedB), value);
        }
        public bool GuidelineVanillaToggleActive
        {
            get => (bool)GetValue(nameof(GuidelineVanillaToggleActive));
            set => SetValue(nameof(GuidelineVanillaToggleActive), value);
        }
        public bool GuidelineVanillaToggleHasBackup
        {
            get => (bool)GetValue(nameof(GuidelineVanillaToggleHasBackup));
            set => SetValue(nameof(GuidelineVanillaToggleHasBackup), value);
        }
        public int GuidelineBackupLinesColorPreset
        {
            get => (int)GetValue(nameof(GuidelineBackupLinesColorPreset));
            set => SetValue(nameof(GuidelineBackupLinesColorPreset), value);
        }
        public float GuidelineBackupLinesR
        {
            get => (float)GetValue(nameof(GuidelineBackupLinesR));
            set => SetValue(nameof(GuidelineBackupLinesR), value);
        }
        public float GuidelineBackupLinesG
        {
            get => (float)GetValue(nameof(GuidelineBackupLinesG));
            set => SetValue(nameof(GuidelineBackupLinesG), value);
        }
        public float GuidelineBackupLinesB
        {
            get => (float)GetValue(nameof(GuidelineBackupLinesB));
            set => SetValue(nameof(GuidelineBackupLinesB), value);
        }
        public float GuidelineBackupLinesA
        {
            get => (float)GetValue(nameof(GuidelineBackupLinesA));
            set => SetValue(nameof(GuidelineBackupLinesA), value);
        }
        public int GuidelineBackupPreviewColorPreset
        {
            get => (int)GetValue(nameof(GuidelineBackupPreviewColorPreset));
            set => SetValue(nameof(GuidelineBackupPreviewColorPreset), value);
        }
        public float GuidelineBackupPreviewR
        {
            get => (float)GetValue(nameof(GuidelineBackupPreviewR));
            set => SetValue(nameof(GuidelineBackupPreviewR), value);
        }
        public float GuidelineBackupPreviewG
        {
            get => (float)GetValue(nameof(GuidelineBackupPreviewG));
            set => SetValue(nameof(GuidelineBackupPreviewG), value);
        }
        public float GuidelineBackupPreviewB
        {
            get => (float)GetValue(nameof(GuidelineBackupPreviewB));
            set => SetValue(nameof(GuidelineBackupPreviewB), value);
        }
        public float GuidelineBackupPreviewA
        {
            get => (float)GetValue(nameof(GuidelineBackupPreviewA));
            set => SetValue(nameof(GuidelineBackupPreviewA), value);
        }
        public int GuidelineBackupDashedColorPreset
        {
            get => (int)GetValue(nameof(GuidelineBackupDashedColorPreset));
            set => SetValue(nameof(GuidelineBackupDashedColorPreset), value);
        }
        public float GuidelineBackupDashedR
        {
            get => (float)GetValue(nameof(GuidelineBackupDashedR));
            set => SetValue(nameof(GuidelineBackupDashedR), value);
        }
        public float GuidelineBackupDashedG
        {
            get => (float)GetValue(nameof(GuidelineBackupDashedG));
            set => SetValue(nameof(GuidelineBackupDashedG), value);
        }
        public float GuidelineBackupDashedB
        {
            get => (float)GetValue(nameof(GuidelineBackupDashedB));
            set => SetValue(nameof(GuidelineBackupDashedB), value);
        }
        public int GuidelineBackupOpacityPercent
        {
            get => (int)GetValue(nameof(GuidelineBackupOpacityPercent));
            set => SetValue(nameof(GuidelineBackupOpacityPercent), value);
        }
        public bool PanelTooltipsEnabled
        {
            get => (bool)GetValue(nameof(PanelTooltipsEnabled));
            set => SetValue(nameof(PanelTooltipsEnabled), value);
        }
        public bool SurfaceToolAreasSuppressed
        {
            get => (bool)GetValue(nameof(SurfaceToolAreasSuppressed));
            set => SetValue(nameof(SurfaceToolAreasSuppressed), value);
        }
        public bool SpecializedIndustryAreasSuppressed
        {
            get => (bool)GetValue(nameof(SpecializedIndustryAreasSuppressed));
            set => SetValue(nameof(SpecializedIndustryAreasSuppressed), value);
        }
        public bool SpecializedIndustryAreasSuppressionInitialized
        {
            get => (bool)GetValue(nameof(SpecializedIndustryAreasSuppressionInitialized));
            set => SetValue(nameof(SpecializedIndustryAreasSuppressionInitialized), value);
        }
        public int ToolColorMode
        {
            get => (int)GetValue(nameof(ToolColorMode));
            set => SetValue(nameof(ToolColorMode), value);
        }
        public bool UseOverlapWarningColor
        {
            get => (bool)GetValue(nameof(UseOverlapWarningColor));
            set => SetValue(nameof(UseOverlapWarningColor), value);
        }
        public bool UseCustomColorsForNetLanes
        {
            get => (bool)GetValue(nameof(UseCustomColorsForNetLanes));
            set => SetValue(nameof(UseCustomColorsForNetLanes), value);
        }
        public bool UseDarkerPanel
        {
            get => (bool)GetValue(nameof(UseDarkerPanel));
            set => SetValue(nameof(UseDarkerPanel), value);
        }
        public int GuidelineLinesColorPreset
        {
            get => (int)GetValue(nameof(GuidelineLinesColorPreset));
            set => SetValue(nameof(GuidelineLinesColorPreset), value);
        }
        public int GuidelinePreviewColorPreset
        {
            get => (int)GetValue(nameof(GuidelinePreviewColorPreset));
            set => SetValue(nameof(GuidelinePreviewColorPreset), value);
        }
        public int GuidelineOpacityPercent
        {
            get => (int)GetValue(nameof(GuidelineOpacityPercent));
            set => SetValue(nameof(GuidelineOpacityPercent), value);
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
        //public string SelectedModDropDown
        //{
        //    get => (string)GetValue(nameof(SelectedModDropDown));
        //    set => SetValue(nameof(SelectedModDropDown), value);
        //}
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class InfoLoomTwoSettings : SettingsBackup
    {
        public bool hideBuildingSection
        {
            get => (bool)GetValue(nameof(hideBuildingSection));
            set => SetValue(nameof(hideBuildingSection), value);
        }
        public bool hideCitizenSection
        {
            get => (bool)GetValue(nameof(hideCitizenSection));
            set => SetValue(nameof(hideCitizenSection), value);
        }
        public bool hideDistrictSection
        {
            get => (bool)GetValue(nameof(hideDistrictSection));
            set => SetValue(nameof(hideDistrictSection), value);
        }
        public bool hideRentSection
        {
            get => (bool)GetValue(nameof(hideRentSection));
            set => SetValue(nameof(hideRentSection), value);
        }
        public bool showEffectsButton
        {
            get => (bool)GetValue(nameof(showEffectsButton));
            set => SetValue(nameof(showEffectsButton), value);
        }
        public int crimeColorR
        {
            get => (int)GetValue(nameof(crimeColorR));
            set => SetValue(nameof(crimeColorR), value);
        }
        public int crimeColorG
        {
            get => (int)GetValue(nameof(crimeColorG));
            set => SetValue(nameof(crimeColorG), value);
        }
        public int crimeColorB
        {
            get => (int)GetValue(nameof(crimeColorB));
            set => SetValue(nameof(crimeColorB), value);
        }
        public int crimeColorA
        {
            get => (int)GetValue(nameof(crimeColorA));
            set => SetValue(nameof(crimeColorA), value);
        }
        public int wellbeingColorR
        {
            get => (int)GetValue(nameof(wellbeingColorR));
            set => SetValue(nameof(wellbeingColorR), value);
        }
        public int wellbeingColorG
        {
            get => (int)GetValue(nameof(wellbeingColorG));
            set => SetValue(nameof(wellbeingColorG), value);
        }
        public int wellbeingColorB
        {
            get => (int)GetValue(nameof(wellbeingColorB));
            set => SetValue(nameof(wellbeingColorB), value);
        }
        public int wellbeingColorA
        {
            get => (int)GetValue(nameof(wellbeingColorA));
            set => SetValue(nameof(wellbeingColorA), value);
        }
        public int healthColorR
        {
            get => (int)GetValue(nameof(healthColorR));
            set => SetValue(nameof(healthColorR), value);
        }
        public int healthColorG
        {
            get => (int)GetValue(nameof(healthColorG));
            set => SetValue(nameof(healthColorG), value);
        }
        public int healthColorB
        {
            get => (int)GetValue(nameof(healthColorB));
            set => SetValue(nameof(healthColorB), value);
        }
        public int healthColorA
        {
            get => (int)GetValue(nameof(healthColorA));
            set => SetValue(nameof(healthColorA), value);
        }
        public int fireHazardColorR
        {
            get => (int)GetValue(nameof(fireHazardColorR));
            set => SetValue(nameof(fireHazardColorR), value);
        }
        public int fireHazardColorG
        {
            get => (int)GetValue(nameof(fireHazardColorG));
            set => SetValue(nameof(fireHazardColorG), value);
        }
        public int fireHazardColorB
        {
            get => (int)GetValue(nameof(fireHazardColorB));
            set => SetValue(nameof(fireHazardColorB), value);
        }
        public int fireHazardColorA
        {
            get => (int)GetValue(nameof(fireHazardColorA));
            set => SetValue(nameof(fireHazardColorA), value);
        }
        public int fireResponseColorR
        {
            get => (int)GetValue(nameof(fireResponseColorR));
            set => SetValue(nameof(fireResponseColorR), value);
        }
        public int fireResponseColorG
        {
            get => (int)GetValue(nameof(fireResponseColorG));
            set => SetValue(nameof(fireResponseColorG), value);
        }
        public int fireResponseColorB
        {
            get => (int)GetValue(nameof(fireResponseColorB));
            set => SetValue(nameof(fireResponseColorB), value);
        }
        public int fireResponseColorA
        {
            get => (int)GetValue(nameof(fireResponseColorA));
            set => SetValue(nameof(fireResponseColorA), value);
        }
        public int comResDemValue
        {
            get => (int)GetValue(nameof(comResDemValue));
            set => SetValue(nameof(comResDemValue), value);
        }
        public int indResDemValue
        {
            get => (int)GetValue(nameof(indResDemValue));
            set => SetValue(nameof(indResDemValue), value);
        }
        public int teenAgeLimit
        {
            get => (int)GetValue(nameof(teenAgeLimit));
            set => SetValue(nameof(teenAgeLimit), value);
        }
        public int adultAgeLimit
        {
            get => (int)GetValue(nameof(adultAgeLimit));
            set => SetValue(nameof(adultAgeLimit), value);
        }
        public int elderAgeLimit
        {
            get => (int)GetValue(nameof(elderAgeLimit));
            set => SetValue(nameof(elderAgeLimit), value);
        }
        public bool enableUnemploymentChirps
        {
            get => (bool)GetValue(nameof(enableUnemploymentChirps));
            set => SetValue(nameof(enableUnemploymentChirps), value);
        }
        public bool enableUnderemploymentChirps
        {
            get => (bool)GetValue(nameof(enableUnderemploymentChirps));
            set => SetValue(nameof(enableUnderemploymentChirps), value);
        }
        public bool enableDemandChirps
        {
            get => (bool)GetValue(nameof(enableDemandChirps));
            set => SetValue(nameof(enableDemandChirps), value);
        }
        public bool enableHomelessChirps
        {
            get => (bool)GetValue(nameof(enableHomelessChirps));
            set => SetValue(nameof(enableHomelessChirps), value);
        }
        public float unemploymentThreshold
        {
            get => (float)GetValue(nameof(unemploymentThreshold));
            set => SetValue(nameof(unemploymentThreshold), value);
        }
        public float underemploymentThreshold
        {
            get => (float)GetValue(nameof(underemploymentThreshold));
            set => SetValue(nameof(underemploymentThreshold), value);
        }
        public float homelessThreshold
        {
            get => (float)GetValue(nameof(homelessThreshold));
            set => SetValue(nameof(homelessThreshold), value);
        }
        public bool enableElectrictyChirps
        {
            get => (bool)GetValue(nameof(enableElectrictyChirps));
            set => SetValue(nameof(enableElectrictyChirps), value);
        }
        public bool enableWaterAndSweageChirps
        {
            get => (bool)GetValue(nameof(enableWaterAndSweageChirps));
            set => SetValue(nameof(enableWaterAndSweageChirps), value);
        }

        //public float2 panelPosition
        //{
        //    get => (float2)GetValue(nameof(panelPosition));
        //    set => SetValue(nameof(panelPosition), value);
        //}
        public int exportFilesRetentionCount
        {
            get => (int)GetValue(nameof(exportFilesRetentionCount));
            set => SetValue(nameof(exportFilesRetentionCount), value);
        }
        public bool exportReplaceExisting
        {
            get => (bool)GetValue(nameof(exportReplaceExisting));
            set => SetValue(nameof(exportReplaceExisting), value);
        }
        public bool exportWorkforce
        {
            get => (bool)GetValue(nameof(exportWorkforce));
            set => SetValue(nameof(exportWorkforce), value);
        }
        public bool exportWorkforceCityWide
        {
            get => (bool)GetValue(nameof(exportWorkforceCityWide));
            set => SetValue(nameof(exportWorkforceCityWide), value);
        }
        public bool exportDemographics
        {
            get => (bool)GetValue(nameof(exportDemographics));
            set => SetValue(nameof(exportDemographics), value);
        }
        public bool exportDemoPerAge
        {
            get => (bool)GetValue(nameof(exportDemoPerAge));
            set => SetValue(nameof(exportDemoPerAge), value);
        }
        public bool exportDemoFiveYear
        {
            get => (bool)GetValue(nameof(exportDemoFiveYear));
            set => SetValue(nameof(exportDemoFiveYear), value);
        }
        public bool exportDemoTenYear
        {
            get => (bool)GetValue(nameof(exportDemoTenYear));
            set => SetValue(nameof(exportDemoTenYear), value);
        }
        public bool exportDemoLifecycle
        {
            get => (bool)GetValue(nameof(exportDemoLifecycle));
            set => SetValue(nameof(exportDemoLifecycle), value);
        }
        public bool exportDemoTotals
        {
            get => (bool)GetValue(nameof(exportDemoTotals));
            set => SetValue(nameof(exportDemoTotals), value);
        }
        public bool exportDemoCityWide
        {
            get => (bool)GetValue(nameof(exportDemoCityWide));
            set => SetValue(nameof(exportDemoCityWide), value);
        }
        public bool exportDemoEmploymentCols
        {
            get => (bool)GetValue(nameof(exportDemoEmploymentCols));
            set => SetValue(nameof(exportDemoEmploymentCols), value);
        }
        public bool exportDemoEducationCols
        {
            get => (bool)GetValue(nameof(exportDemoEducationCols));
            set => SetValue(nameof(exportDemoEducationCols), value);
        }
        public bool exportWorkplaces
        {
            get => (bool)GetValue(nameof(exportWorkplaces));
            set => SetValue(nameof(exportWorkplaces), value);
        }
        public bool exportWorkplacesCityWide
        {
            get => (bool)GetValue(nameof(exportWorkplacesCityWide));
            set => SetValue(nameof(exportWorkplacesCityWide), value);
        }
    }

    public class IntelligentCommoditySchedulingSettings : SettingsBackup
    {
        public bool Cloud
        {
            get => (bool)GetValue(nameof(Cloud));
            set => SetValue(nameof(Cloud), value);
        }
        public bool StrategicStockpileRelease
        {
            get => (bool)GetValue(nameof(StrategicStockpileRelease));
            set => SetValue(nameof(StrategicStockpileRelease), value);
        }

        //public bool DebugStats
        //{
        //    get => (bool)GetValue(nameof(DebugStats));
        //    set => SetValue(nameof(DebugStats), value);
        //}
        public int Level
        {
            get => (int)GetValue(nameof(Level));
            set => SetValue(nameof(Level), value);
        }
    }

    public class LaClockSettings : SettingsBackup
    {
        public int ClockFormatChoice
        {
            get => (int)GetValue(nameof(ClockFormatChoice));
            set => SetValue(nameof(ClockFormatChoice), value);
        }
        public string ClockFormatString
        {
            get => (string)GetValue(nameof(ClockFormatString));
            set => SetValue(nameof(ClockFormatString), value);
        }
        public int ClockCultureChoice
        {
            get => (int)GetValue(nameof(ClockCultureChoice));
            set => SetValue(nameof(ClockCultureChoice), value);
        }
        public float ClockSizeMultiplier
        {
            get => (float)GetValue(nameof(ClockSizeMultiplier));
            set => SetValue(nameof(ClockSizeMultiplier), value);
        }
        public string ClockWidth
        {
            get => (string)GetValue(nameof(ClockWidth));
            set => SetValue(nameof(ClockWidth), value);
        }
        public CultureInfo ClockCultureInfo
        {
            get => (CultureInfo)GetValue(nameof(ClockCultureInfo));
            set => SetValue(nameof(ClockCultureInfo), value);
        }
        public string ClockFormatStringActual
        {
            get => (string)GetValue(nameof(ClockFormatStringActual));
            set => SetValue(nameof(ClockFormatStringActual), value);
        }
        public bool EnableBlink
        {
            get => (bool)GetValue(nameof(EnableBlink));
            set => SetValue(nameof(EnableBlink), value);
        }
        public int BlinkPerMin
        {
            get => (int)GetValue(nameof(BlinkPerMin));
            set => SetValue(nameof(BlinkPerMin), value);
        }
        public int BlinkDurationSec
        {
            get => (int)GetValue(nameof(BlinkDurationSec));
            set => SetValue(nameof(BlinkDurationSec), value);
        }
    }

    public class LodControlSettings : SettingsBackup
    {
        public float LevelOfDetail
        {
            get => (float)GetValue(nameof(LevelOfDetail));
            set => SetValue(nameof(LevelOfDetail), value);
        }
        public bool DisableLodModels
        {
            get => (bool)GetValue(nameof(DisableLodModels));
            set => SetValue(nameof(DisableLodModels), value);
        }
        public float Preset1Value
        {
            get => (float)GetValue(nameof(Preset1Value));
            set => SetValue(nameof(Preset1Value), value);
        }
        public float Preset2Value
        {
            get => (float)GetValue(nameof(Preset2Value));
            set => SetValue(nameof(Preset2Value), value);
        }
        public float Preset3Value
        {
            get => (float)GetValue(nameof(Preset3Value));
            set => SetValue(nameof(Preset3Value), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class LuminaSettings : SettingsBackup
    {
        public bool EnableLuminaVolume
        {
            get => (bool)GetValue(nameof(EnableLuminaVolume));
            set => SetValue(nameof(EnableLuminaVolume), value);
        }

        //public bool EnableDebugLogging
        //{
        //    get => (bool)GetValue(nameof(EnableDebugLogging));
        //    set => SetValue(nameof(EnableDebugLogging), value);
        //}
        public bool EnablePerformanceMode
        {
            get => (bool)GetValue(nameof(EnablePerformanceMode));
            set => SetValue(nameof(EnablePerformanceMode), value);
        }
        public bool ReloadAllPackagesOnRestart
        {
            get => (bool)GetValue(nameof(ReloadAllPackagesOnRestart));
            set => SetValue(nameof(ReloadAllPackagesOnRestart), value);
        }
        public bool SaveAutomatically
        {
            get => (bool)GetValue(nameof(SaveAutomatically));
            set => SetValue(nameof(SaveAutomatically), value);
        }
        public bool LatitudeAndLongitudeAdjustments
        {
            get => (bool)GetValue(nameof(LatitudeAndLongitudeAdjustments));
            set => SetValue(nameof(LatitudeAndLongitudeAdjustments), value);
        }
        public bool UseRoadTextures
        {
            get => (bool)GetValue(nameof(UseRoadTextures));
            set => SetValue(nameof(UseRoadTextures), value);
        }
        public bool isSCGIInterventionEnabled
        {
            get => (bool)GetValue(nameof(isSCGIInterventionEnabled));
            set => SetValue(nameof(isSCGIInterventionEnabled), value);
        }
        public bool IsContactShadows
        {
            get => (bool)GetValue(nameof(IsContactShadows));
            set => SetValue(nameof(IsContactShadows), value);
        }
        public bool ScreenSpaceAmbientOcclusion
        {
            get => (bool)GetValue(nameof(ScreenSpaceAmbientOcclusion));
            set => SetValue(nameof(ScreenSpaceAmbientOcclusion), value);
        }
        public bool UseTimeOfDaySlider
        {
            get => (bool)GetValue(nameof(UseTimeOfDaySlider));
            set => SetValue(nameof(UseTimeOfDaySlider), value);
        }

        //public bool MetroFrameworkEnabled
        //{
        //    get => (bool)GetValue(nameof(MetroFrameworkEnabled));
        //    set => SetValue(nameof(MetroFrameworkEnabled), value);
        //}
        public int m_ReplaceRoadWearSystem
        {
            get => (int)GetValue(nameof(m_ReplaceRoadWearSystem));
            set => SetValue(nameof(m_ReplaceRoadWearSystem), value);
        }
    }

    public class MagicGarbageSettings : SettingsBackup
    {
        public bool TotalMagic
        {
            get => (bool)GetValue(nameof(TotalMagic));
            set => SetValue(nameof(TotalMagic), value);
        }
        public bool TrashBossEnabled
        {
            get => (bool)GetValue(nameof(TrashBossEnabled));
            set => SetValue(nameof(TrashBossEnabled), value);
        }
        public int GarbageTruckCapacityMultiplier
        {
            get => (int)GetValue(nameof(GarbageTruckCapacityMultiplier));
            set => SetValue(nameof(GarbageTruckCapacityMultiplier), value);
        }
        public int GarbageFacilityStorageMultiplier
        {
            get => (int)GetValue(nameof(GarbageFacilityStorageMultiplier));
            set => SetValue(nameof(GarbageFacilityStorageMultiplier), value);
        }
        public int GarbageFacilityProcessingMultiplier
        {
            get => (int)GetValue(nameof(GarbageFacilityProcessingMultiplier));
            set => SetValue(nameof(GarbageFacilityProcessingMultiplier), value);
        }
        public int GarbageFacilityVehicleMultiplier
        {
            get => (int)GetValue(nameof(GarbageFacilityVehicleMultiplier));
            set => SetValue(nameof(GarbageFacilityVehicleMultiplier), value);
        }
        public bool PriorityAssistEnabled
        {
            get => (bool)GetValue(nameof(PriorityAssistEnabled));
            set => SetValue(nameof(PriorityAssistEnabled), value);
        }
        public bool PowerUserOptions
        {
            get => (bool)GetValue(nameof(PowerUserOptions));
            set => SetValue(nameof(PowerUserOptions), value);
        }
        public int GarbageDispatchRequestThreshold
        {
            get => (int)GetValue(nameof(GarbageDispatchRequestThreshold));
            set => SetValue(nameof(GarbageDispatchRequestThreshold), value);
        }
        public int GarbagePickupThreshold
        {
            get => (int)GetValue(nameof(GarbagePickupThreshold));
            set => SetValue(nameof(GarbagePickupThreshold), value);
        }
        public int GarbageHappinessBaseline
        {
            get => (int)GetValue(nameof(GarbageHappinessBaseline));
            set => SetValue(nameof(GarbageHappinessBaseline), value);
        }
        public int GarbageHappinessStep
        {
            get => (int)GetValue(nameof(GarbageHappinessStep));
            set => SetValue(nameof(GarbageHappinessStep), value);
        }
        public int GarbageAccumulationRate
        {
            get => (int)GetValue(nameof(GarbageAccumulationRate));
            set => SetValue(nameof(GarbageAccumulationRate), value);
        }
    }

    public class MagicHearseSettings : SettingsBackup
    {
        public bool EnableMagicHearse
        {
            get => (bool)GetValue(nameof(EnableMagicHearse));
            set => SetValue(nameof(EnableMagicHearse), value);
        }
        public bool FuneralDirector
        {
            get => (bool)GetValue(nameof(FuneralDirector));
            set => SetValue(nameof(FuneralDirector), value);
        }
        public int ProcScalar
        {
            get => (int)GetValue(nameof(ProcScalar));
            set => SetValue(nameof(ProcScalar), value);
        }
        public int FleetScalar
        {
            get => (int)GetValue(nameof(FleetScalar));
            set => SetValue(nameof(FleetScalar), value);
        }
        public int StorageScalar
        {
            get => (int)GetValue(nameof(StorageScalar));
            set => SetValue(nameof(StorageScalar), value);
        }
        public int HearseSpeedScalar
        {
            get => (int)GetValue(nameof(HearseSpeedScalar));
            set => SetValue(nameof(HearseSpeedScalar), value);
        }
        public bool ControlWorkers
        {
            get => (bool)GetValue(nameof(ControlWorkers));
            set => SetValue(nameof(ControlWorkers), value);
        }
        public int WorkersScalar
        {
            get => (int)GetValue(nameof(WorkersScalar));
            set => SetValue(nameof(WorkersScalar), value);
        }
    }

    public class MagicMailSettings : SettingsBackup
    {
        public bool NotFirstTime
        {
            get => (bool)GetValue(nameof(NotFirstTime));
            set => SetValue(nameof(NotFirstTime), value);
        }
        public bool PO_GetLocalMail
        {
            get => (bool)GetValue(nameof(PO_GetLocalMail));
            set => SetValue(nameof(PO_GetLocalMail), value);
        }
        public int PO_GettingThresholdPercentage
        {
            get => (int)GetValue(nameof(PO_GettingThresholdPercentage));
            set => SetValue(nameof(PO_GettingThresholdPercentage), value);
        }
        public int PO_GettingPercentage
        {
            get => (int)GetValue(nameof(PO_GettingPercentage));
            set => SetValue(nameof(PO_GettingPercentage), value);
        }
        public bool FixMailOverflow
        {
            get => (bool)GetValue(nameof(FixMailOverflow));
            set => SetValue(nameof(FixMailOverflow), value);
        }
        public int PO_OverflowPercentage
        {
            get => (int)GetValue(nameof(PO_OverflowPercentage));
            set => SetValue(nameof(PO_OverflowPercentage), value);
        }
        public int PSF_OverflowPercentage
        {
            get => (int)GetValue(nameof(PSF_OverflowPercentage));
            set => SetValue(nameof(PSF_OverflowPercentage), value);
        }
        public bool ChangeCapacity
        {
            get => (bool)GetValue(nameof(ChangeCapacity));
            set => SetValue(nameof(ChangeCapacity), value);
        }
        public int PostVanMailLoadPercentage
        {
            get => (int)GetValue(nameof(PostVanMailLoadPercentage));
            set => SetValue(nameof(PostVanMailLoadPercentage), value);
        }
        public int PostVanFleetSizePercentage
        {
            get => (int)GetValue(nameof(PostVanFleetSizePercentage));
            set => SetValue(nameof(PostVanFleetSizePercentage), value);
        }
        public int TruckCapacityPercentage
        {
            get => (int)GetValue(nameof(TruckCapacityPercentage));
            set => SetValue(nameof(TruckCapacityPercentage), value);
        }
        public int PSF_SortingSpeedPercentage
        {
            get => (int)GetValue(nameof(PSF_SortingSpeedPercentage));
            set => SetValue(nameof(PSF_SortingSpeedPercentage), value);
        }
        public int PSF_StorageCapacityPercentage
        {
            get => (int)GetValue(nameof(PSF_StorageCapacityPercentage));
            set => SetValue(nameof(PSF_StorageCapacityPercentage), value);
        }
        public bool PSF_GetUnsortedMail
        {
            get => (bool)GetValue(nameof(PSF_GetUnsortedMail));
            set => SetValue(nameof(PSF_GetUnsortedMail), value);
        }
        public int PSF_GettingThresholdPercentage
        {
            get => (int)GetValue(nameof(PSF_GettingThresholdPercentage));
            set => SetValue(nameof(PSF_GettingThresholdPercentage), value);
        }
        public int PSF_GettingPercentage
        {
            get => (int)GetValue(nameof(PSF_GettingPercentage));
            set => SetValue(nameof(PSF_GettingPercentage), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class MapExtSettings : SettingsBackup
    {
        //public string DisplayedMapSize
        //{
        //    get => (string)GetValue(nameof(DisplayedMapSize));
        //    set => SetValue(nameof(DisplayedMapSize), value);
        //}
        //public string DisplayedTerrainSystemValue
        //{
        //    get => (string)GetValue(nameof(DisplayedTerrainSystemValue));
        //    set => SetValue(nameof(DisplayedTerrainSystemValue), value);
        //}
        //public string DisplayedWaterSystemValue
        //{
        //    get => (string)GetValue(nameof(DisplayedWaterSystemValue));
        //    set => SetValue(nameof(DisplayedWaterSystemValue), value);
        //}
        //public string DisplayedCellMapSystemValue
        //{
        //    get => (string)GetValue(nameof(DisplayedCellMapSystemValue));
        //    set => SetValue(nameof(DisplayedCellMapSystemValue), value);
        //}
        //public string DetectedSaveCoreValue
        //{
        //    get => (string)GetValue(nameof(DetectedSaveCoreValue));
        //    set => SetValue(nameof(DetectedSaveCoreValue), value);
        //}
        public int PatchModeChoice
        {
            get => (int)GetValue(nameof(PatchModeChoice));
            set => SetValue(nameof(PatchModeChoice), value);
        }
        public bool TerrainBufferPrealloc
        {
            get => (bool)GetValue(nameof(TerrainBufferPrealloc));
            set => SetValue(nameof(TerrainBufferPrealloc), value);
        }
        public bool TerrainCullThrottle
        {
            get => (bool)GetValue(nameof(TerrainCullThrottle));
            set => SetValue(nameof(TerrainCullThrottle), value);
        }
        public bool TerrainCascadeThrottle
        {
            get => (bool)GetValue(nameof(TerrainCascadeThrottle));
            set => SetValue(nameof(TerrainCascadeThrottle), value);
        }
        public int TerrainResolution
        {
            get => (int)GetValue(nameof(TerrainResolution));
            set => SetValue(nameof(TerrainResolution), value);
        }
        public int WaterResolution
        {
            get => (int)GetValue(nameof(WaterResolution));
            set => SetValue(nameof(WaterResolution), value);
        }
        public int WaterSimQuality
        {
            get => (int)GetValue(nameof(WaterSimQuality));
            set => SetValue(nameof(WaterSimQuality), value);
        }
        public int WaterTextureFormat
        {
            get => (int)GetValue(nameof(WaterTextureFormat));
            set => SetValue(nameof(WaterTextureFormat), value);
        }
        public bool isEnableEconomyFix
        {
            get => (bool)GetValue(nameof(isEnableEconomyFix));
            set => SetValue(nameof(isEnableEconomyFix), value);
        }
        public bool EnableDemandEcoSystem
        {
            get => (bool)GetValue(nameof(EnableDemandEcoSystem));
            set => SetValue(nameof(EnableDemandEcoSystem), value);
        }
        public bool EnableJobSearchEcoSystem
        {
            get => (bool)GetValue(nameof(EnableJobSearchEcoSystem));
            set => SetValue(nameof(EnableJobSearchEcoSystem), value);
        }
        public bool EnableHouseholdPropertyEcoSystem
        {
            get => (bool)GetValue(nameof(EnableHouseholdPropertyEcoSystem));
            set => SetValue(nameof(EnableHouseholdPropertyEcoSystem), value);
        }
        public bool EnableResourceBuyerEcoSystem
        {
            get => (bool)GetValue(nameof(EnableResourceBuyerEcoSystem));
            set => SetValue(nameof(EnableResourceBuyerEcoSystem), value);
        }
        public bool EnableResidentAIEcoSystem
        {
            get => (bool)GetValue(nameof(EnableResidentAIEcoSystem));
            set => SetValue(nameof(EnableResidentAIEcoSystem), value);
        }
        public bool EnableDownstreamAIEcoSystem
        {
            get => (bool)GetValue(nameof(EnableDownstreamAIEcoSystem));
            set => SetValue(nameof(EnableDownstreamAIEcoSystem), value);
        }
        public float ShoppingMaxCost
        {
            get => (float)GetValue(nameof(ShoppingMaxCost));
            set => SetValue(nameof(ShoppingMaxCost), value);
        }
        public float CompanyShoppingMaxCost
        {
            get => (float)GetValue(nameof(CompanyShoppingMaxCost));
            set => SetValue(nameof(CompanyShoppingMaxCost), value);
        }
        public float LeisureMaxCost
        {
            get => (float)GetValue(nameof(LeisureMaxCost));
            set => SetValue(nameof(LeisureMaxCost), value);
        }
        public float EmergencyMaxCost
        {
            get => (float)GetValue(nameof(EmergencyMaxCost));
            set => SetValue(nameof(EmergencyMaxCost), value);
        }
        public float FindJobMaxCost
        {
            get => (float)GetValue(nameof(FindJobMaxCost));
            set => SetValue(nameof(FindJobMaxCost), value);
        }
        public float FindHomeMaxCost
        {
            get => (float)GetValue(nameof(FindHomeMaxCost));
            set => SetValue(nameof(FindHomeMaxCost), value);
        }
        public float FindSchoolElementaryMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolElementaryMaxCost));
            set => SetValue(nameof(FindSchoolElementaryMaxCost), value);
        }
        public float FindSchoolHighSchoolMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolHighSchoolMaxCost));
            set => SetValue(nameof(FindSchoolHighSchoolMaxCost), value);
        }
        public float FindSchoolCollegeMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolCollegeMaxCost));
            set => SetValue(nameof(FindSchoolCollegeMaxCost), value);
        }
        public float FindSchoolUniversityMaxCost
        {
            get => (float)GetValue(nameof(FindSchoolUniversityMaxCost));
            set => SetValue(nameof(FindSchoolUniversityMaxCost), value);
        }
        public int JobSeekerCap
        {
            get => (int)GetValue(nameof(JobSeekerCap));
            set => SetValue(nameof(JobSeekerCap), value);
        }
        public int PathfindRequestCap
        {
            get => (int)GetValue(nameof(PathfindRequestCap));
            set => SetValue(nameof(PathfindRequestCap), value);
        }
        public float ShoppingTrafficReduction
        {
            get => (float)GetValue(nameof(ShoppingTrafficReduction));
            set => SetValue(nameof(ShoppingTrafficReduction), value);
        }
        public float HouseholdResourceDemandMultiplier
        {
            get => (float)GetValue(nameof(HouseholdResourceDemandMultiplier));
            set => SetValue(nameof(HouseholdResourceDemandMultiplier), value);
        }
        public int HomeSeekerCap
        {
            get => (int)GetValue(nameof(HomeSeekerCap));
            set => SetValue(nameof(HomeSeekerCap), value);
        }
        public int HomelessSeekerCap
        {
            get => (int)GetValue(nameof(HomelessSeekerCap));
            set => SetValue(nameof(HomelessSeekerCap), value);
        }
        public int LandValueEnvironmentEffect
        {
            get => (int)GetValue(nameof(LandValueEnvironmentEffect));
            set => SetValue(nameof(LandValueEnvironmentEffect), value);
        }
        public int ServiceBonusCapMultiplier
        {
            get => (int)GetValue(nameof(ServiceBonusCapMultiplier));
            set => SetValue(nameof(ServiceBonusCapMultiplier), value);
        }
        public int RentMultiplierResidential
        {
            get => (int)GetValue(nameof(RentMultiplierResidential));
            set => SetValue(nameof(RentMultiplierResidential), value);
        }
        public int RentMultiplierCommercial
        {
            get => (int)GetValue(nameof(RentMultiplierCommercial));
            set => SetValue(nameof(RentMultiplierCommercial), value);
        }
        public int RentMultiplierIndustrial
        {
            get => (int)GetValue(nameof(RentMultiplierIndustrial));
            set => SetValue(nameof(RentMultiplierIndustrial), value);
        }
        public int LandValueFactorResidential
        {
            get => (int)GetValue(nameof(LandValueFactorResidential));
            set => SetValue(nameof(LandValueFactorResidential), value);
        }
        public int LandValueFactorCommercial
        {
            get => (int)GetValue(nameof(LandValueFactorCommercial));
            set => SetValue(nameof(LandValueFactorCommercial), value);
        }
        public int LandValueFactorIndustrial
        {
            get => (int)GetValue(nameof(LandValueFactorIndustrial));
            set => SetValue(nameof(LandValueFactorIndustrial), value);
        }
        public int LevelFactorResidential
        {
            get => (int)GetValue(nameof(LevelFactorResidential));
            set => SetValue(nameof(LevelFactorResidential), value);
        }
        public int LevelFactorCommercial
        {
            get => (int)GetValue(nameof(LevelFactorCommercial));
            set => SetValue(nameof(LevelFactorCommercial), value);
        }
        public int LevelFactorIndustrial
        {
            get => (int)GetValue(nameof(LevelFactorIndustrial));
            set => SetValue(nameof(LevelFactorIndustrial), value);
        }
        public bool EnableVanillaConversion
        {
            get => (bool)GetValue(nameof(EnableVanillaConversion));
            set => SetValue(nameof(EnableVanillaConversion), value);
        }
        public bool DisableWorldBackdrop
        {
            get => (bool)GetValue(nameof(DisableWorldBackdrop));
            set => SetValue(nameof(DisableWorldBackdrop), value);
        }
        public bool NoDogsOnStreet
        {
            get => (bool)GetValue(nameof(NoDogsOnStreet));
            set => SetValue(nameof(NoDogsOnStreet), value);
        }
        public bool NoDogsGeneration
        {
            get => (bool)GetValue(nameof(NoDogsGeneration));
            set => SetValue(nameof(NoDogsGeneration), value);
        }
        public bool NoDogsPurge
        {
            get => (bool)GetValue(nameof(NoDogsPurge));
            set => SetValue(nameof(NoDogsPurge), value);
        }

        //public int CurrentPetCount
        //{
        //    get => (int)GetValue(nameof(CurrentPetCount));
        //    set => SetValue(nameof(CurrentPetCount), value);
        //}
        public bool NoThroughTraffic
        {
            get => (bool)GetValue(nameof(NoThroughTraffic));
            set => SetValue(nameof(NoThroughTraffic), value);
        }
        public bool TerrainBrushRoadBlock
        {
            get => (bool)GetValue(nameof(TerrainBrushRoadBlock));
            set => SetValue(nameof(TerrainBrushRoadBlock), value);
        }
        public float TerrainBrushRoadMargin
        {
            get => (float)GetValue(nameof(TerrainBrushRoadMargin));
            set => SetValue(nameof(TerrainBrushRoadMargin), value);
        }
        public int EditorCollisionSkip
        {
            get => (int)GetValue(nameof(EditorCollisionSkip));
            set => SetValue(nameof(EditorCollisionSkip), value);
        }
        public int UIFontSize
        {
            get => (int)GetValue(nameof(UIFontSize));
            set => SetValue(nameof(UIFontSize), value);
        }
        public int UIMenuPanelWidth
        {
            get => (int)GetValue(nameof(UIMenuPanelWidth));
            set => SetValue(nameof(UIMenuPanelWidth), value);
        }
        public int UIDetailPanelWidth
        {
            get => (int)GetValue(nameof(UIDetailPanelWidth));
            set => SetValue(nameof(UIDetailPanelWidth), value);
        }
        public int UIPanelHeight
        {
            get => (int)GetValue(nameof(UIPanelHeight));
            set => SetValue(nameof(UIPanelHeight), value);
        }
        //public bool DashboardDefaultCityStats
        //{
        //    get => (bool)GetValue(nameof(DashboardDefaultCityStats));
        //    set => SetValue(nameof(DashboardDefaultCityStats), value);
        //}
        //public bool DashboardDefaultResidential
        //{
        //    get => (bool)GetValue(nameof(DashboardDefaultResidential));
        //    set => SetValue(nameof(DashboardDefaultResidential), value);
        //}
        //public bool DashboardDefaultCommercial
        //{
        //    get => (bool)GetValue(nameof(DashboardDefaultCommercial));
        //    set => SetValue(nameof(DashboardDefaultCommercial), value);
        //}
        //public bool DashboardDefaultActivity
        //{
        //    get => (bool)GetValue(nameof(DashboardDefaultActivity));
        //    set => SetValue(nameof(DashboardDefaultActivity), value);
        //}
        //public bool DashboardDefaultMisc
        //{
        //    get => (bool)GetValue(nameof(DashboardDefaultMisc));
        //    set => SetValue(nameof(DashboardDefaultMisc), value);
        //}
        //public string PopDiagData
        //{
        //    get => (string)GetValue(nameof(PopDiagData));
        //    set => SetValue(nameof(PopDiagData), value);
        //}
        //public bool DisableLoadGameValidation
        //{
        //    get => (bool)GetValue(nameof(DisableLoadGameValidation));
        //    set => SetValue(nameof(DisableLoadGameValidation), value);
        //}
        //public bool EnableVehicleRescue
        //{
        //    get => (bool)GetValue(nameof(EnableVehicleRescue));
        //    set => SetValue(nameof(EnableVehicleRescue), value);
        //}
        //public bool EnableRescueDebugLog
        //{
        //    get => (bool)GetValue(nameof(EnableRescueDebugLog));
        //    set => SetValue(nameof(EnableRescueDebugLog), value);
        //}
    }

    public class MapTextureReplacerSettings : SettingsBackup
    {
        public bool InUniversalModMenu
        {
            get => (bool)GetValue(nameof(InUniversalModMenu));
            set => SetValue(nameof(InUniversalModMenu), value);
        }
        public bool ShowDownloadedPacks
        {
            get => (bool)GetValue(nameof(ShowDownloadedPacks));
            set => SetValue(nameof(ShowDownloadedPacks), value);
        }
        public bool ShowLocalPacks
        {
            get => (bool)GetValue(nameof(ShowLocalPacks));
            set => SetValue(nameof(ShowLocalPacks), value);
        }
        public bool ShowCameraHeight
        {
            get => (bool)GetValue(nameof(ShowCameraHeight));
            set => SetValue(nameof(ShowCameraHeight), value);
        }

        //public string ActiveDropdown
        //{
        //    get => (string)GetValue(nameof(ActiveDropdown));
        //    set => SetValue(nameof(ActiveDropdown), value);
        //}
        public string TextureSelectData
        {
            get => (string)GetValue(nameof(TextureSelectData));
            set => SetValue(nameof(TextureSelectData), value);
        }

        //public int CurrentTilingVector
        //{
        //    get => (int)GetValue(nameof(CurrentTilingVector));
        //    set => SetValue(nameof(CurrentTilingVector), value);
        //}
        public int MakeSureSave
        {
            get => (int)GetValue(nameof(MakeSureSave));
            set => SetValue(nameof(MakeSureSave), value);
        }
    }

    public class MouseLightSettings : SettingsBackup
    {
        public bool EnableCursorLight
        {
            get => (bool)GetValue(nameof(EnableCursorLight));
            set => SetValue(nameof(EnableCursorLight), value);
        }
        public float IntensityMultiplier
        {
            get => (float)GetValue(nameof(IntensityMultiplier));
            set => SetValue(nameof(IntensityMultiplier), value);
        }
        public float RangeMultiplier
        {
            get => (float)GetValue(nameof(RangeMultiplier));
            set => SetValue(nameof(RangeMultiplier), value);
        }
        public float Red
        {
            get => (float)GetValue(nameof(Red));
            set => SetValue(nameof(Red), value);
        }
        public float Green
        {
            get => (float)GetValue(nameof(Green));
            set => SetValue(nameof(Green), value);
        }
        public float Blue
        {
            get => (float)GetValue(nameof(Blue));
            set => SetValue(nameof(Blue), value);
        }
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
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
    }

    public class NetworkToolsSettings : SettingsBackup
    {
        public string DistanceUnit
        {
            get => (string)GetValue(nameof(DistanceUnit));
            set => SetValue(nameof(DistanceUnit), value);
        }

        //public bool DebugMode
        //{
        //    get => (bool)GetValue(nameof(DebugMode));
        //    set => SetValue(nameof(DebugMode), value);
        //}
        public int SavedSelectedSnaps
        {
            get => (int)GetValue(nameof(SavedSelectedSnaps));
            set => SetValue(nameof(SavedSelectedSnaps), value);
        }
        public int SavedSelectedTargets
        {
            get => (int)GetValue(nameof(SavedSelectedTargets));
            set => SetValue(nameof(SavedSelectedTargets), value);
        }
        public int SavedSelectedViews
        {
            get => (int)GetValue(nameof(SavedSelectedViews));
            set => SetValue(nameof(SavedSelectedViews), value);
        }
        public bool SavedAnarchyEnabled
        {
            get => (bool)GetValue(nameof(SavedAnarchyEnabled));
            set => SetValue(nameof(SavedAnarchyEnabled), value);
        }
        public string SavedParameterValues
        {
            get => (string)GetValue(nameof(SavedParameterValues));
            set => SetValue(nameof(SavedParameterValues), value);
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

    public class NodeControllerSettings : SettingsBackup
    {
        public bool EnableMouseRotation
        {
            get => (bool)GetValue(nameof(EnableMouseRotation));
            set => SetValue(nameof(EnableMouseRotation), value);
        }
        public int StraightenMode
        {
            get => (int)GetValue(nameof(StraightenMode));
            set => SetValue(nameof(StraightenMode), value);
        }
        public float StraightenAngle
        {
            get => (float)GetValue(nameof(StraightenAngle));
            set => SetValue(nameof(StraightenAngle), value);
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
        public int AirFade
        {
            get => (int)GetValue(nameof(AirFade));
            set => SetValue(nameof(AirFade), value);
        }
        public int GroundFade
        {
            get => (int)GetValue(nameof(GroundFade));
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class NoVehicleDespawnSettings : SettingsBackup
    {
        //public bool trafficDespawnDisabled
        //{
        //    get => (bool)GetValue(nameof(trafficDespawnDisabled));
        //    set => SetValue(nameof(trafficDespawnDisabled), value);
        //}
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

        //public bool attemptReroute
        //{
        //    get => (bool)GetValue(nameof(attemptReroute));
        //    set => SetValue(nameof(attemptReroute), value);
        //}
        //public int attemptRerouteFrames
        //{
        //    get => (int)GetValue(nameof(attemptRerouteFrames));
        //    set => SetValue(nameof(attemptRerouteFrames), value);
        //}
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
        public bool despawnBicycles
        {
            get => (bool)GetValue(nameof(despawnBicycles));
            set => SetValue(nameof(despawnBicycles), value);
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
        public bool despawnTrains
        {
            get => (bool)GetValue(nameof(despawnTrains));
            set => SetValue(nameof(despawnTrains), value);
        }
        public bool despawnTrams
        {
            get => (bool)GetValue(nameof(despawnTrams));
            set => SetValue(nameof(despawnTrams), value);
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
    public class NoVehicleTrailersSettings : SettingsBackup
    {
        public bool disableCarTrailers
        {
            get => (bool)GetValue(nameof(disableCarTrailers));
            set => SetValue(nameof(disableCarTrailers), value);
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

    public class OutsideTrafficAdjusterSettings : SettingsBackup
    {
        public float RoadMultiplier
        {
            get => (float)GetValue(nameof(RoadMultiplier));
            set => SetValue(nameof(RoadMultiplier), value);
        }
        public float TrainMultiplier
        {
            get => (float)GetValue(nameof(TrainMultiplier));
            set => SetValue(nameof(TrainMultiplier), value);
        }
        public float ShipMultiplier
        {
            get => (float)GetValue(nameof(ShipMultiplier));
            set => SetValue(nameof(ShipMultiplier), value);
        }
        public float PlaneMultiplier
        {
            get => (float)GetValue(nameof(PlaneMultiplier));
            set => SetValue(nameof(PlaneMultiplier), value);
        }
    }

    public class ParkingFeeControlSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }

        //public bool DebugLogging
        //{
        //    get => (bool)GetValue(nameof(DebugLogging));
        //    set => SetValue(nameof(DebugLogging), value);
        //}
        public int UpdateFrequencyMinutes
        {
            get => (int)GetValue(nameof(UpdateFrequencyMinutes));
            set => SetValue(nameof(UpdateFrequencyMinutes), value);
        }
        public int IgnoreTag
        {
            get => (int)GetValue(nameof(IgnoreTag));
            set => SetValue(nameof(IgnoreTag), value);
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
        public int TargetOccupancyLot
        {
            get => (int)GetValue(nameof(TargetOccupancyLot));
            set => SetValue(nameof(TargetOccupancyLot), value);
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
        public int TargetOccupancyStreet
        {
            get => (int)GetValue(nameof(TargetOccupancyStreet));
            set => SetValue(nameof(TargetOccupancyStreet), value);
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

    public class PlatterSettings : SettingsBackup
    {
        public bool EnableOverlayForTools
        {
            get => (bool)GetValue(nameof(EnableOverlayForTools));
            set => SetValue(nameof(EnableOverlayForTools), value);
        }
        public bool AllowSpawn
        {
            get => (bool)GetValue(nameof(AllowSpawn));
            set => SetValue(nameof(AllowSpawn), value);
        }
        public bool Modals_FirstLaunchTutorial
        {
            get => (bool)GetValue(nameof(Modals_FirstLaunchTutorial));
            set => SetValue(nameof(Modals_FirstLaunchTutorial), value);
        }
        public uint LastViewedChangelogVersion
        {
            get => (uint)GetValue(nameof(LastViewedChangelogVersion));
            set => SetValue(nameof(LastViewedChangelogVersion), value);
        }
        public bool RenderParcels
        {
            get => (bool)GetValue(nameof(RenderParcels));
            set => SetValue(nameof(RenderParcels), value);
        }
    }

    public class PlopTheGrowablesSettings : SettingsBackup
    {
        public bool SpawnedZoneDespawn
        {
            get => (bool)GetValue(nameof(SpawnedZoneDespawn));
            set => SetValue(nameof(SpawnedZoneDespawn), value);
        }
        public bool LockPloppedBuildings
        {
            get => (bool)GetValue(nameof(LockPloppedBuildings));
            set => SetValue(nameof(LockPloppedBuildings), value);
        }
    }

    public class PrefabAssetFixesSettings : SettingsBackup
    {
        public int IndustrialCompanyWorker
        {
            get => (int)GetValue(nameof(IndustrialCompanyWorker));
            set => SetValue(nameof(IndustrialCompanyWorker), value);
        }
        public bool Prison
        {
            get => (bool)GetValue(nameof(Prison));
            set => SetValue(nameof(Prison), value);
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
        public bool RSClinic
        {
            get => (bool)GetValue(nameof(RSClinic));
            set => SetValue(nameof(RSClinic), value);
        }
        public bool LHTBusStation02
        {
            get => (bool)GetValue(nameof(LHTBusStation02));
            set => SetValue(nameof(LHTBusStation02), value);
        }
        public bool LHTTaxiDepot01
        {
            get => (bool)GetValue(nameof(LHTTaxiDepot01));
            set => SetValue(nameof(LHTTaxiDepot01), value);
        }
        public bool LHTTramDepot01
        {
            get => (bool)GetValue(nameof(LHTTramDepot01));
            set => SetValue(nameof(LHTTramDepot01), value);
        }
        public bool LHTCargoHarbor01
        {
            get => (bool)GetValue(nameof(LHTCargoHarbor01));
            set => SetValue(nameof(LHTCargoHarbor01), value);
        }
        public bool RHTBusStation01
        {
            get => (bool)GetValue(nameof(RHTBusStation01));
            set => SetValue(nameof(RHTBusStation01), value);
        }
        public bool NLLowHousehold
        {
            get => (bool)GetValue(nameof(NLLowHousehold));
            set => SetValue(nameof(NLLowHousehold), value);
        }

        //public bool AdditionalTransformers
        //{
        //    get => (bool)GetValue(nameof(AdditionalTransformers));
        //    set => SetValue(nameof(AdditionalTransformers), value);
        //}
        public bool FRCiltyHall
        {
            get => (bool)GetValue(nameof(FRCiltyHall));
            set => SetValue(nameof(FRCiltyHall), value);
        }
    }

    public class PublicWorksPlusSettings : SettingsBackup
    {
        //public bool EnableDebugLogging
        //{
        //    get => (bool)GetValue(nameof(EnableDebugLogging));
        //    set => SetValue(nameof(EnableDebugLogging), value);
        //}
        public float SemiTruckCargoScalar
        {
            get => (float)GetValue(nameof(SemiTruckCargoScalar));
            set => SetValue(nameof(SemiTruckCargoScalar), value);
        }
        public float DeliveryVanCargoScalar
        {
            get => (float)GetValue(nameof(DeliveryVanCargoScalar));
            set => SetValue(nameof(DeliveryVanCargoScalar), value);
        }
        public float CoalTruckScalar
        {
            get => (float)GetValue(nameof(CoalTruckScalar));
            set => SetValue(nameof(CoalTruckScalar), value);
        }
        public float MotorbikeDeliveryCargoScalar
        {
            get => (float)GetValue(nameof(MotorbikeDeliveryCargoScalar));
            set => SetValue(nameof(MotorbikeDeliveryCargoScalar), value);
        }
        public float ExtractorMaxTrucksScalar
        {
            get => (float)GetValue(nameof(ExtractorMaxTrucksScalar));
            set => SetValue(nameof(ExtractorMaxTrucksScalar), value);
        }
        public float CargoStationMaxTrucksScalar
        {
            get => (float)GetValue(nameof(CargoStationMaxTrucksScalar));
            set => SetValue(nameof(CargoStationMaxTrucksScalar), value);
        }
        public float ParkMaintenanceDepotScalar
        {
            get => (float)GetValue(nameof(ParkMaintenanceDepotScalar));
            set => SetValue(nameof(ParkMaintenanceDepotScalar), value);
        }
        public float ParkMaintenanceVehicleCapacityScalar
        {
            get => (float)GetValue(nameof(ParkMaintenanceVehicleCapacityScalar));
            set => SetValue(nameof(ParkMaintenanceVehicleCapacityScalar), value);
        }
        public float ParkMaintenanceVehicleRateScalar
        {
            get => (float)GetValue(nameof(ParkMaintenanceVehicleRateScalar));
            set => SetValue(nameof(ParkMaintenanceVehicleRateScalar), value);
        }
        public float RoadMaintenanceDepotScalar
        {
            get => (float)GetValue(nameof(RoadMaintenanceDepotScalar));
            set => SetValue(nameof(RoadMaintenanceDepotScalar), value);
        }
        public float RoadMaintenanceVehicleCapacityScalar
        {
            get => (float)GetValue(nameof(RoadMaintenanceVehicleCapacityScalar));
            set => SetValue(nameof(RoadMaintenanceVehicleCapacityScalar), value);
        }
        public float RoadMaintenanceVehicleRateScalar
        {
            get => (float)GetValue(nameof(RoadMaintenanceVehicleRateScalar));
            set => SetValue(nameof(RoadMaintenanceVehicleRateScalar), value);
        }
        public float RoadWearScalar
        {
            get => (float)GetValue(nameof(RoadWearScalar));
            set => SetValue(nameof(RoadWearScalar), value);
        }
        public bool EnableLineVehicleCountTuner
        {
            get => (bool)GetValue(nameof(EnableLineVehicleCountTuner));
            set => SetValue(nameof(EnableLineVehicleCountTuner), value);
        }
        public float BusDepotScalar
        {
            get => (float)GetValue(nameof(BusDepotScalar));
            set => SetValue(nameof(BusDepotScalar), value);
        }
        public float FerryDepotScalar
        {
            get => (float)GetValue(nameof(FerryDepotScalar));
            set => SetValue(nameof(FerryDepotScalar), value);
        }
        public float SubwayDepotScalar
        {
            get => (float)GetValue(nameof(SubwayDepotScalar));
            set => SetValue(nameof(SubwayDepotScalar), value);
        }
        public float TaxiDepotScalar
        {
            get => (float)GetValue(nameof(TaxiDepotScalar));
            set => SetValue(nameof(TaxiDepotScalar), value);
        }
        public float TrainDepotScalar
        {
            get => (float)GetValue(nameof(TrainDepotScalar));
            set => SetValue(nameof(TrainDepotScalar), value);
        }
        public float TramDepotScalar
        {
            get => (float)GetValue(nameof(TramDepotScalar));
            set => SetValue(nameof(TramDepotScalar), value);
        }
        public float BusPassengerScalar
        {
            get => (float)GetValue(nameof(BusPassengerScalar));
            set => SetValue(nameof(BusPassengerScalar), value);
        }
        public float TramPassengerScalar
        {
            get => (float)GetValue(nameof(TramPassengerScalar));
            set => SetValue(nameof(TramPassengerScalar), value);
        }
        public float TrainPassengerScalar
        {
            get => (float)GetValue(nameof(TrainPassengerScalar));
            set => SetValue(nameof(TrainPassengerScalar), value);
        }
        public float SubwayPassengerScalar
        {
            get => (float)GetValue(nameof(SubwayPassengerScalar));
            set => SetValue(nameof(SubwayPassengerScalar), value);
        }
        public float ShipPassengerScalar
        {
            get => (float)GetValue(nameof(ShipPassengerScalar));
            set => SetValue(nameof(ShipPassengerScalar), value);
        }
        public float FerryPassengerScalar
        {
            get => (float)GetValue(nameof(FerryPassengerScalar));
            set => SetValue(nameof(FerryPassengerScalar), value);
        }
        public float AirplanePassengerScalar
        {
            get => (float)GetValue(nameof(AirplanePassengerScalar));
            set => SetValue(nameof(AirplanePassengerScalar), value);
        }
    }

    public class RealisticIndustrialPowerConsumptionSettings : SettingsBackup
    {
        public bool EnableMod
        {
            get => (bool)GetValue(nameof(EnableMod));
            set => SetValue(nameof(EnableMod), value);
        }
        public int IndustrialPowerConsumption
        {
            get => (int)GetValue(nameof(IndustrialPowerConsumption));
            set => SetValue(nameof(IndustrialPowerConsumption), value);
        }
        public int SmallMultiplier
        {
            get => (int)GetValue(nameof(SmallMultiplier));
            set => SetValue(nameof(SmallMultiplier), value);
        }
        public int MediumMultiplier
        {
            get => (int)GetValue(nameof(MediumMultiplier));
            set => SetValue(nameof(MediumMultiplier), value);
        }
        public int LargeMultiplier
        {
            get => (int)GetValue(nameof(LargeMultiplier));
            set => SetValue(nameof(LargeMultiplier), value);
        }
        public int VeryLargeMultiplier
        {
            get => (int)GetValue(nameof(VeryLargeMultiplier));
            set => SetValue(nameof(VeryLargeMultiplier), value);
        }
        public int HugeMultiplier
        {
            get => (int)GetValue(nameof(HugeMultiplier));
            set => SetValue(nameof(HugeMultiplier), value);
        }
        public int MassiveMultiplier
        {
            get => (int)GetValue(nameof(MassiveMultiplier));
            set => SetValue(nameof(MassiveMultiplier), value);
        }
        public int GiganticMultiplier
        {
            get => (int)GetValue(nameof(GiganticMultiplier));
            set => SetValue(nameof(GiganticMultiplier), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class RealisticJobSearchSettings : SettingsBackup
    {
        //public bool debug
        //{
        //    get => (bool)GetValue(nameof(debug));
        //    set => SetValue(nameof(debug), value);
        //}
        public float weight_free_jobs
        {
            get => (float)GetValue(nameof(weight_free_jobs));
            set => SetValue(nameof(weight_free_jobs), value);
        }
        public float weight_total_jobs
        {
            get => (float)GetValue(nameof(weight_total_jobs));
            set => SetValue(nameof(weight_total_jobs), value);
        }
        public float alpha_jobs
        {
            get => (float)GetValue(nameof(alpha_jobs));
            set => SetValue(nameof(alpha_jobs), value);
        }
        public float beta_minute
        {
            get => (float)GetValue(nameof(beta_minute));
            set => SetValue(nameof(beta_minute), value);
        }
        public float min_accept
        {
            get => (float)GetValue(nameof(min_accept));
            set => SetValue(nameof(min_accept), value);
        }
        public float max_accept
        {
            get => (float)GetValue(nameof(max_accept));
            set => SetValue(nameof(max_accept), value);
        }
    }

    public class RealisticParkingSettings : SettingsBackup
    {
        public bool EnableInducedDemand
        {
            get => (bool)GetValue(nameof(EnableInducedDemand));
            set => SetValue(nameof(EnableInducedDemand), value);
        }
        public string InducedDemandPreset
        {
            get => (string)GetValue(nameof(InducedDemandPreset));
            set => SetValue(nameof(InducedDemandPreset), value);
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
    public class RealisticPathFindingSettings : SettingsBackup
    {
        public float car_mode_weight
        {
            get => (float)GetValue(nameof(car_mode_weight));
            set => SetValue(nameof(car_mode_weight), value);
        }
        public float min_turn_agle_deg
        {
            get => (float)GetValue(nameof(min_turn_agle_deg));
            set => SetValue(nameof(min_turn_agle_deg), value);
        }
        public float max_turn_agle_deg
        {
            get => (float)GetValue(nameof(max_turn_agle_deg));
            set => SetValue(nameof(max_turn_agle_deg), value);
        }
        public float base_turn_penalty
        {
            get => (float)GetValue(nameof(base_turn_penalty));
            set => SetValue(nameof(base_turn_penalty), value);
        }
        public float uturn_threshold_deg
        {
            get => (float)GetValue(nameof(uturn_threshold_deg));
            set => SetValue(nameof(uturn_threshold_deg), value);
        }
        public float uturn_sec_penalty
        {
            get => (float)GetValue(nameof(uturn_sec_penalty));
            set => SetValue(nameof(uturn_sec_penalty), value);
        }
        public float collector_bias
        {
            get => (float)GetValue(nameof(collector_bias));
            set => SetValue(nameof(collector_bias), value);
        }
        public float local_bias
        {
            get => (float)GetValue(nameof(local_bias));
            set => SetValue(nameof(local_bias), value);
        }
        public float alleyway_bias
        {
            get => (float)GetValue(nameof(alleyway_bias));
            set => SetValue(nameof(alleyway_bias), value);
        }
        public float waiting_time_factor
        {
            get => (float)GetValue(nameof(waiting_time_factor));
            set => SetValue(nameof(waiting_time_factor), value);
        }
        public float transfer_penalty
        {
            get => (float)GetValue(nameof(transfer_penalty));
            set => SetValue(nameof(transfer_penalty), value);
        }
        public float feeder_trunk_transfer_penalty
        {
            get => (float)GetValue(nameof(feeder_trunk_transfer_penalty));
            set => SetValue(nameof(feeder_trunk_transfer_penalty), value);
        }
        public float scheduled_wt_factor
        {
            get => (float)GetValue(nameof(scheduled_wt_factor));
            set => SetValue(nameof(scheduled_wt_factor), value);
        }
        public float crowdness_factor
        {
            get => (float)GetValue(nameof(crowdness_factor));
            set => SetValue(nameof(crowdness_factor), value);
        }
        public float crowdness_stop_threashold
        {
            get => (float)GetValue(nameof(crowdness_stop_threashold));
            set => SetValue(nameof(crowdness_stop_threashold), value);
        }
        public float bus_mode_weight
        {
            get => (float)GetValue(nameof(bus_mode_weight));
            set => SetValue(nameof(bus_mode_weight), value);
        }
        public float tram_mode_weight
        {
            get => (float)GetValue(nameof(tram_mode_weight));
            set => SetValue(nameof(tram_mode_weight), value);
        }
        public float subway_mode_weight
        {
            get => (float)GetValue(nameof(subway_mode_weight));
            set => SetValue(nameof(subway_mode_weight), value);
        }
        public float train_mode_weight
        {
            get => (float)GetValue(nameof(train_mode_weight));
            set => SetValue(nameof(train_mode_weight), value);
        }
        public float ferry_mode_weight
        {
            get => (float)GetValue(nameof(ferry_mode_weight));
            set => SetValue(nameof(ferry_mode_weight), value);
        }
        public float nonbus_buslane_penalty_sec
        {
            get => (float)GetValue(nameof(nonbus_buslane_penalty_sec));
            set => SetValue(nameof(nonbus_buslane_penalty_sec), value);
        }
        public float taxi_passengers_waiting_threashold
        {
            get => (float)GetValue(nameof(taxi_passengers_waiting_threashold));
            set => SetValue(nameof(taxi_passengers_waiting_threashold), value);
        }
        public float taxi_fare_increase
        {
            get => (float)GetValue(nameof(taxi_fare_increase));
            set => SetValue(nameof(taxi_fare_increase), value);
        }
        public float average_walk_speed_child
        {
            get => (float)GetValue(nameof(average_walk_speed_child));
            set => SetValue(nameof(average_walk_speed_child), value);
        }
        public float average_walk_speed_teen
        {
            get => (float)GetValue(nameof(average_walk_speed_teen));
            set => SetValue(nameof(average_walk_speed_teen), value);
        }
        public float average_walk_speed_adult
        {
            get => (float)GetValue(nameof(average_walk_speed_adult));
            set => SetValue(nameof(average_walk_speed_adult), value);
        }
        public float average_walk_speed_elderly
        {
            get => (float)GetValue(nameof(average_walk_speed_elderly));
            set => SetValue(nameof(average_walk_speed_elderly), value);
        }
        public bool disable_ped_cost
        {
            get => (bool)GetValue(nameof(disable_ped_cost));
            set => SetValue(nameof(disable_ped_cost), value);
        }
        public float ped_walk_time_factor
        {
            get => (float)GetValue(nameof(ped_walk_time_factor));
            set => SetValue(nameof(ped_walk_time_factor), value);
        }
        public float walk_long_comfort_m
        {
            get => (float)GetValue(nameof(walk_long_comfort_m));
            set => SetValue(nameof(walk_long_comfort_m), value);
        }
        public float walk_long_ramp_m
        {
            get => (float)GetValue(nameof(walk_long_ramp_m));
            set => SetValue(nameof(walk_long_ramp_m), value);
        }
        public float walk_long_min_mult
        {
            get => (float)GetValue(nameof(walk_long_min_mult));
            set => SetValue(nameof(walk_long_min_mult), value);
        }
        public float ped_crosswalk_factor
        {
            get => (float)GetValue(nameof(ped_crosswalk_factor));
            set => SetValue(nameof(ped_crosswalk_factor), value);
        }
        public float ped_unsafe_crosswalk_factor
        {
            get => (float)GetValue(nameof(ped_unsafe_crosswalk_factor));
            set => SetValue(nameof(ped_unsafe_crosswalk_factor), value);
        }
        public float cong_alpha
        {
            get => (float)GetValue(nameof(cong_alpha));
            set => SetValue(nameof(cong_alpha), value);
        }
        public float cong_min_push_sec
        {
            get => (float)GetValue(nameof(cong_min_push_sec));
            set => SetValue(nameof(cong_min_push_sec), value);
        }
        public float cong_max_ratio
        {
            get => (float)GetValue(nameof(cong_max_ratio));
            set => SetValue(nameof(cong_max_ratio), value);
        }
        public float cong_max_density
        {
            get => (float)GetValue(nameof(cong_max_density));
            set => SetValue(nameof(cong_max_density), value);
        }
        public float cong_min_ff_mps
        {
            get => (float)GetValue(nameof(cong_min_ff_mps));
            set => SetValue(nameof(cong_min_ff_mps), value);
        }
        public float cong_min_sample_sec
        {
            get => (float)GetValue(nameof(cong_min_sample_sec));
            set => SetValue(nameof(cong_min_sample_sec), value);
        }
        public int bike_teen_percent
        {
            get => (int)GetValue(nameof(bike_teen_percent));
            set => SetValue(nameof(bike_teen_percent), value);
        }
        public int bike_adult_percent
        {
            get => (int)GetValue(nameof(bike_adult_percent));
            set => SetValue(nameof(bike_adult_percent), value);
        }
        public int bike_senior_percent
        {
            get => (int)GetValue(nameof(bike_senior_percent));
            set => SetValue(nameof(bike_senior_percent), value);
        }
        public float bike_short_comfort_m
        {
            get => (float)GetValue(nameof(bike_short_comfort_m));
            set => SetValue(nameof(bike_short_comfort_m), value);
        }
        public float bike_short_min_mult
        {
            get => (float)GetValue(nameof(bike_short_min_mult));
            set => SetValue(nameof(bike_short_min_mult), value);
        }
        public float bike_long_comfort_m
        {
            get => (float)GetValue(nameof(bike_long_comfort_m));
            set => SetValue(nameof(bike_long_comfort_m), value);
        }
        public float bike_long_ramp_m
        {
            get => (float)GetValue(nameof(bike_long_ramp_m));
            set => SetValue(nameof(bike_long_ramp_m), value);
        }
        public float bike_long_min_mult
        {
            get => (float)GetValue(nameof(bike_long_min_mult));
            set => SetValue(nameof(bike_long_min_mult), value);
        }
        public float choice_tau_sec
        {
            get => (float)GetValue(nameof(choice_tau_sec));
            set => SetValue(nameof(choice_tau_sec), value);
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
        public bool shopping_trip_gates_enabled
        {
            get => (bool)GetValue(nameof(shopping_trip_gates_enabled));
            set => SetValue(nameof(shopping_trip_gates_enabled), value);
        }
        public int shopping_gate_meals_pct
        {
            get => (int)GetValue(nameof(shopping_gate_meals_pct));
            set => SetValue(nameof(shopping_gate_meals_pct), value);
        }
        public int shopping_gate_groceries_pct
        {
            get => (int)GetValue(nameof(shopping_gate_groceries_pct));
            set => SetValue(nameof(shopping_gate_groceries_pct), value);
        }
        public int shopping_gate_health_fuel_pct
        {
            get => (int)GetValue(nameof(shopping_gate_health_fuel_pct));
            set => SetValue(nameof(shopping_gate_health_fuel_pct), value);
        }
        public int shopping_gate_household_goods_pct
        {
            get => (int)GetValue(nameof(shopping_gate_household_goods_pct));
            set => SetValue(nameof(shopping_gate_household_goods_pct), value);
        }
        public int shopping_gate_consumer_goods_pct
        {
            get => (int)GetValue(nameof(shopping_gate_consumer_goods_pct));
            set => SetValue(nameof(shopping_gate_consumer_goods_pct), value);
        }
        public int shopping_gate_large_purchases_pct
        {
            get => (int)GetValue(nameof(shopping_gate_large_purchases_pct));
            set => SetValue(nameof(shopping_gate_large_purchases_pct), value);
        }
        public bool household_shopping_cooldown_enabled
        {
            get => (bool)GetValue(nameof(household_shopping_cooldown_enabled));
            set => SetValue(nameof(household_shopping_cooldown_enabled), value);
        }
        public int household_cooldown_groceries_pct
        {
            get => (int)GetValue(nameof(household_cooldown_groceries_pct));
            set => SetValue(nameof(household_cooldown_groceries_pct), value);
        }
        public int household_cooldown_health_fuel_pct
        {
            get => (int)GetValue(nameof(household_cooldown_health_fuel_pct));
            set => SetValue(nameof(household_cooldown_health_fuel_pct), value);
        }
        public int household_cooldown_household_goods_pct
        {
            get => (int)GetValue(nameof(household_cooldown_household_goods_pct));
            set => SetValue(nameof(household_cooldown_household_goods_pct), value);
        }
        public int household_cooldown_large_purchases_pct
        {
            get => (int)GetValue(nameof(household_cooldown_large_purchases_pct));
            set => SetValue(nameof(household_cooldown_large_purchases_pct), value);
        }
        public int household_cooldown_other_pct
        {
            get => (int)GetValue(nameof(household_cooldown_other_pct));
            set => SetValue(nameof(household_cooldown_other_pct), value);
        }
        public float household_cooldown_regular_hours
        {
            get => (float)GetValue(nameof(household_cooldown_regular_hours));
            set => SetValue(nameof(household_cooldown_regular_hours), value);
        }
        public float household_cooldown_large_purchase_hours
        {
            get => (float)GetValue(nameof(household_cooldown_large_purchase_hours));
            set => SetValue(nameof(household_cooldown_large_purchase_hours), value);
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
        public bool hospital_stay_duration_enabled
        {
            get => (bool)GetValue(nameof(hospital_stay_duration_enabled));
            set => SetValue(nameof(hospital_stay_duration_enabled), value);
        }
        public int hospital_stay_inpatient_chance_pct
        {
            get => (int)GetValue(nameof(hospital_stay_inpatient_chance_pct));
            set => SetValue(nameof(hospital_stay_inpatient_chance_pct), value);
        }
        public int hospital_short_stay_average_hours
        {
            get => (int)GetValue(nameof(hospital_short_stay_average_hours));
            set => SetValue(nameof(hospital_short_stay_average_hours), value);
        }
        public int hospital_short_stay_stddev_hours
        {
            get => (int)GetValue(nameof(hospital_short_stay_stddev_hours));
            set => SetValue(nameof(hospital_short_stay_stddev_hours), value);
        }
        public int hospital_short_stay_minimum_hours
        {
            get => (int)GetValue(nameof(hospital_short_stay_minimum_hours));
            set => SetValue(nameof(hospital_short_stay_minimum_hours), value);
        }
        public int hospital_short_stay_maximum_hours
        {
            get => (int)GetValue(nameof(hospital_short_stay_maximum_hours));
            set => SetValue(nameof(hospital_short_stay_maximum_hours), value);
        }
        public int hospital_inpatient_average_hours
        {
            get => (int)GetValue(nameof(hospital_inpatient_average_hours));
            set => SetValue(nameof(hospital_inpatient_average_hours), value);
        }
        public int hospital_inpatient_stddev_hours
        {
            get => (int)GetValue(nameof(hospital_inpatient_stddev_hours));
            set => SetValue(nameof(hospital_inpatient_stddev_hours), value);
        }
        public int hospital_inpatient_minimum_hours
        {
            get => (int)GetValue(nameof(hospital_inpatient_minimum_hours));
            set => SetValue(nameof(hospital_inpatient_minimum_hours), value);
        }
        public int hospital_inpatient_maximum_hours
        {
            get => (int)GetValue(nameof(hospital_inpatient_maximum_hours));
            set => SetValue(nameof(hospital_inpatient_maximum_hours), value);
        }
        public int avg_time_prison
        {
            get => (int)GetValue(nameof(avg_time_prison));
            set => SetValue(nameof(avg_time_prison), value);
        }
        public bool use_school_vanilla_timeoff
        {
            get => (bool)GetValue(nameof(use_school_vanilla_timeoff));
            set => SetValue(nameof(use_school_vanilla_timeoff), value);
        }
        public float school_vacation_per_year
        {
            get => (float)GetValue(nameof(school_vacation_per_year));
            set => SetValue(nameof(school_vacation_per_year), value);
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
        public float avg_work_hours_ft_we
        {
            get => (float)GetValue(nameof(avg_work_hours_ft_we));
            set => SetValue(nameof(avg_work_hours_ft_we), value);
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
        public float avg_work_hours_pt_we
        {
            get => (float)GetValue(nameof(avg_work_hours_pt_we));
            set => SetValue(nameof(avg_work_hours_pt_we), value);
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
        public int date_format
        {
            get => (int)GetValue(nameof(date_format));
            set => SetValue(nameof(date_format), value);
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
        public bool better_trucks
        {
            get => (bool)GetValue(nameof(better_trucks));
            set => SetValue(nameof(better_trucks), value);
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
        public int trafficReduction
        {
            get => (int)GetValue(nameof(trafficReduction));
            set => SetValue(nameof(trafficReduction), value);
        }
        public int resourceConsumption
        {
            get => (int)GetValue(nameof(resourceConsumption));
            set => SetValue(nameof(resourceConsumption), value);
        }
        public bool shopping_log_enabled
        {
            get => (bool)GetValue(nameof(shopping_log_enabled));
            set => SetValue(nameof(shopping_log_enabled), value);
        }
        public bool use_universal_mod_menu
        {
            get => (bool)GetValue(nameof(use_universal_mod_menu));
            set => SetValue(nameof(use_universal_mod_menu), value);
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
        public int new_years_num_events
        {
            get => (int)GetValue(nameof(new_years_num_events));
            set => SetValue(nameof(new_years_num_events), value);
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
        public int commercial_sqm_per_worker_rec_entertainment
        {
            get => (int)GetValue(nameof(commercial_sqm_per_worker_rec_entertainment));
            set => SetValue(nameof(commercial_sqm_per_worker_rec_entertainment), value);
        }
        public int commercial_sqm_per_worker_hotel
        {
            get => (int)GetValue(nameof(commercial_sqm_per_worker_hotel));
            set => SetValue(nameof(commercial_sqm_per_worker_hotel), value);
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
        public int clinic_sqm_per_worker
        {
            get => (int)GetValue(nameof(clinic_sqm_per_worker));
            set => SetValue(nameof(clinic_sqm_per_worker), value);
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
        public bool disable_admin
        {
            get => (bool)GetValue(nameof(disable_admin));
            set => SetValue(nameof(disable_admin), value);
        }
        public int admin_sqm_per_worker
        {
            get => (int)GetValue(nameof(admin_sqm_per_worker));
            set => SetValue(nameof(admin_sqm_per_worker), value);
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
        public int warehouse_sqm_per_worker
        {
            get => (int)GetValue(nameof(warehouse_sqm_per_worker));
            set => SetValue(nameof(warehouse_sqm_per_worker), value);
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
        public bool powerplant_use_employees_per_gw
        {
            get => (bool)GetValue(nameof(powerplant_use_employees_per_gw));
            set => SetValue(nameof(powerplant_use_employees_per_gw), value);
        }
        public float powerplant_employees_per_gw
        {
            get => (float)GetValue(nameof(powerplant_employees_per_gw));
            set => SetValue(nameof(powerplant_employees_per_gw), value);
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
        public bool zero_park_and_parking_workers
        {
            get => (bool)GetValue(nameof(zero_park_and_parking_workers));
            set => SetValue(nameof(zero_park_and_parking_workers), value);
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
        public int clinic_sqm_per_patient
        {
            get => (int)GetValue(nameof(clinic_sqm_per_patient));
            set => SetValue(nameof(clinic_sqm_per_patient), value);
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
        public int port_sqm_per_worker
        {
            get => (int)GetValue(nameof(port_sqm_per_worker));
            set => SetValue(nameof(port_sqm_per_worker), value);
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
        public int pack_choice
        {
            get => (int)GetValue(nameof(pack_choice));
            set => SetValue(nameof(pack_choice), value);
        }
        public float pack_low
        {
            get => (float)GetValue(nameof(pack_low));
            set => SetValue(nameof(pack_low), value);
        }
        public float pack_row_homes
        {
            get => (float)GetValue(nameof(pack_row_homes));
            set => SetValue(nameof(pack_row_homes), value);
        }
        public float pack_MedHigh
        {
            get => (float)GetValue(nameof(pack_MedHigh));
            set => SetValue(nameof(pack_MedHigh), value);
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
        public float hh_spawn_speed_rate
        {
            get => (float)GetValue(nameof(hh_spawn_speed_rate));
            set => SetValue(nameof(hh_spawn_speed_rate), value);
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
        public float average_household_size
        {
            get => (float)GetValue(nameof(average_household_size));
            set => SetValue(nameof(average_household_size), value);
        }
        public bool disable_household_deletion
        {
            get => (bool)GetValue(nameof(disable_household_deletion));
            set => SetValue(nameof(disable_household_deletion), value);
        }
    }

    public class RecolorSettings : SettingsBackup
    {
        public bool ColorPainterAutomaticCopyColor
        {
            get => (bool)GetValue(nameof(ColorPainterAutomaticCopyColor));
            set => SetValue(nameof(ColorPainterAutomaticCopyColor), value);
        }
        public bool AlwaysMinimizedAtGameStart
        {
            get => (bool)GetValue(nameof(AlwaysMinimizedAtGameStart));
            set => SetValue(nameof(AlwaysMinimizedAtGameStart), value);
        }
        public bool ShowPalettesOptionDuringPlacement
        {
            get => (bool)GetValue(nameof(ShowPalettesOptionDuringPlacement));
            set => SetValue(nameof(ShowPalettesOptionDuringPlacement), value);
        }
        public int PaletteChooserBehaviorWhenSwitchingPrefab
        {
            get => (int)GetValue(nameof(PaletteChooserBehaviorWhenSwitchingPrefab));
            set => SetValue(nameof(PaletteChooserBehaviorWhenSwitchingPrefab), value);
        }
        public bool ShowHexaDecimals
        {
            get => (bool)GetValue(nameof(ShowHexaDecimals));
            set => SetValue(nameof(ShowHexaDecimals), value);
        }
        public bool Minimized
        {
            get => (bool)GetValue(nameof(Minimized));
            set => SetValue(nameof(Minimized), value);
        }

        //public string[] SelectedLocaleCodes
        //{
        //    get => (string[])GetValue(nameof(SelectedLocaleCodes));
        //    set => SetValue(nameof(SelectedLocaleCodes), value);
        //}
        public bool ShowSIPPaletteOptions
        {
            get => (bool)GetValue(nameof(ShowSIPPaletteOptions));
            set => SetValue(nameof(ShowSIPPaletteOptions), value);
        }
        public bool MinimizePaletteChooserDuringPlacement
        {
            get => (bool)GetValue(nameof(MinimizePaletteChooserDuringPlacement));
            set => SetValue(nameof(MinimizePaletteChooserDuringPlacement), value);
        }
        public string PreviousVersion
        {
            get => (string)GetValue(nameof(PreviousVersion));
            set => SetValue(nameof(PreviousVersion), value);
        }
    }

    public class RegionFlagIconsSettings : SettingsBackup
    {
        public int NorthAmericanFlagStyle
        {
            get => (int)GetValue(nameof(NorthAmericanFlagStyle));
            set => SetValue(nameof(NorthAmericanFlagStyle), value);
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
        public string FlagNL
        {
            get => (string)GetValue(nameof(FlagNL));
            set => SetValue(nameof(FlagNL), value);
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
        public int DisplayOption
        {
            get => (int)GetValue(nameof(DisplayOption));
            set => SetValue(nameof(DisplayOption), value);
        }
        public int ColorOption
        {
            get => (int)GetValue(nameof(ColorOption));
            set => SetValue(nameof(ColorOption), value);
        }
        public float OneColorR
        {
            get => (float)GetValue(nameof(OneColorR));
            set => SetValue(nameof(OneColorR), value);
        }
        public float OneColorG
        {
            get => (float)GetValue(nameof(OneColorG));
            set => SetValue(nameof(OneColorG), value);
        }
        public float OneColorB
        {
            get => (float)GetValue(nameof(OneColorB));
            set => SetValue(nameof(OneColorB), value);
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

    public class RoadConstructionEventsSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public float ActiveClosureCount
        {
            get => (float)GetValue(nameof(ActiveClosureCount));
            set => SetValue(nameof(ActiveClosureCount), value);
        }
        public float ClosureDurationSeconds
        {
            get => (float)GetValue(nameof(ClosureDurationSeconds));
            set => SetValue(nameof(ClosureDurationSeconds), value);
        }
        public float TimeBetweenStartsSeconds
        {
            get => (float)GetValue(nameof(TimeBetweenStartsSeconds));
            set => SetValue(nameof(TimeBetweenStartsSeconds), value);
        }
        public float ReopenCooldownSeconds
        {
            get => (float)GetValue(nameof(ReopenCooldownSeconds));
            set => SetValue(nameof(ReopenCooldownSeconds), value);
        }
        public bool UseRoadConditionSelection
        {
            get => (bool)GetValue(nameof(UseRoadConditionSelection));
            set => SetValue(nameof(UseRoadConditionSelection), value);
        }
        public bool ConditionDrivenClosureCount
        {
            get => (bool)GetValue(nameof(ConditionDrivenClosureCount));
            set => SetValue(nameof(ConditionDrivenClosureCount), value);
        }
        public float RoadConditionClosureThreshold
        {
            get => (float)GetValue(nameof(RoadConditionClosureThreshold));
            set => SetValue(nameof(RoadConditionClosureThreshold), value);
        }
        public bool MergeNearbyConstructionSites
        {
            get => (bool)GetValue(nameof(MergeNearbyConstructionSites));
            set => SetValue(nameof(MergeNearbyConstructionSites), value);
        }
        public float ConstructionMergeRadiusMeters
        {
            get => (float)GetValue(nameof(ConstructionMergeRadiusMeters));
            set => SetValue(nameof(ConstructionMergeRadiusMeters), value);
        }
        public bool SingleLaneOnly
        {
            get => (bool)GetValue(nameof(SingleLaneOnly));
            set => SetValue(nameof(SingleLaneOnly), value);
        }
        public bool RequireMultipleCarLanes
        {
            get => (bool)GetValue(nameof(RequireMultipleCarLanes));
            set => SetValue(nameof(RequireMultipleCarLanes), value);
        }
        public bool HardLaneClosure
        {
            get => (bool)GetValue(nameof(HardLaneClosure));
            set => SetValue(nameof(HardLaneClosure), value);
        }
        public bool BlockLaneConnections
        {
            get => (bool)GetValue(nameof(BlockLaneConnections));
            set => SetValue(nameof(BlockLaneConnections), value);
        }
        public bool AvoidParkingAndAccessRoads
        {
            get => (bool)GetValue(nameof(AvoidParkingAndAccessRoads));
            set => SetValue(nameof(AvoidParkingAndAccessRoads), value);
        }
        public bool AvoidMiddleLaneClosures
        {
            get => (bool)GetValue(nameof(AvoidMiddleLaneClosures));
            set => SetValue(nameof(AvoidMiddleLaneClosures), value);
        }
        public bool AvoidBikeLanes
        {
            get => (bool)GetValue(nameof(AvoidBikeLanes));
            set => SetValue(nameof(AvoidBikeLanes), value);
        }
        public bool UseForbiddenPathCost
        {
            get => (bool)GetValue(nameof(UseForbiddenPathCost));
            set => SetValue(nameof(UseForbiddenPathCost), value);
        }
        public bool UseFullLaneBlockage
        {
            get => (bool)GetValue(nameof(UseFullLaneBlockage));
            set => SetValue(nameof(UseFullLaneBlockage), value);
        }
        public bool UsePhysicalLaneBlockers
        {
            get => (bool)GetValue(nameof(UsePhysicalLaneBlockers));
            set => SetValue(nameof(UsePhysicalLaneBlockers), value);
        }
        public bool WaitForSupportBeforeTrafficControl
        {
            get => (bool)GetValue(nameof(WaitForSupportBeforeTrafficControl));
            set => SetValue(nameof(WaitForSupportBeforeTrafficControl), value);
        }
        public bool TemporaryAlternatingSignals
        {
            get => (bool)GetValue(nameof(TemporaryAlternatingSignals));
            set => SetValue(nameof(TemporaryAlternatingSignals), value);
        }
        public float SupportArrivalTimeoutSeconds
        {
            get => (float)GetValue(nameof(SupportArrivalTimeoutSeconds));
            set => SetValue(nameof(SupportArrivalTimeoutSeconds), value);
        }
        public bool AllowHighwayClosures
        {
            get => (bool)GetValue(nameof(AllowHighwayClosures));
            set => SetValue(nameof(AllowHighwayClosures), value);
        }
        public bool AvoidOutsideConnections
        {
            get => (bool)GetValue(nameof(AvoidOutsideConnections));
            set => SetValue(nameof(AvoidOutsideConnections), value);
        }
        public float MinimumRoadLengthMeters
        {
            get => (float)GetValue(nameof(MinimumRoadLengthMeters));
            set => SetValue(nameof(MinimumRoadLengthMeters), value);
        }
        public bool EmergencyCorridorEnabled
        {
            get => (bool)GetValue(nameof(EmergencyCorridorEnabled));
            set => SetValue(nameof(EmergencyCorridorEnabled), value);
        }
        public float EmergencyCorridorRadiusMeters
        {
            get => (float)GetValue(nameof(EmergencyCorridorRadiusMeters));
            set => SetValue(nameof(EmergencyCorridorRadiusMeters), value);
        }
        public float EmergencyCorridorSideNudge
        {
            get => (float)GetValue(nameof(EmergencyCorridorSideNudge));
            set => SetValue(nameof(EmergencyCorridorSideNudge), value);
        }
        public float EmergencyCorridorYieldSpeedKmh
        {
            get => (float)GetValue(nameof(EmergencyCorridorYieldSpeedKmh));
            set => SetValue(nameof(EmergencyCorridorYieldSpeedKmh), value);
        }
        public bool ShowClosureIcons
        {
            get => (bool)GetValue(nameof(ShowClosureIcons));
            set => SetValue(nameof(ShowClosureIcons), value);
        }
        public bool UseBottleneckIcon
        {
            get => (bool)GetValue(nameof(UseBottleneckIcon));
            set => SetValue(nameof(UseBottleneckIcon), value);
        }
        public bool ShowConstructionProps
        {
            get => (bool)GetValue(nameof(ShowConstructionProps));
            set => SetValue(nameof(ShowConstructionProps), value);
        }
        public bool UseGeneratedConstructionProps
        {
            get => (bool)GetValue(nameof(UseGeneratedConstructionProps));
            set => SetValue(nameof(UseGeneratedConstructionProps), value);
        }
        public float ConstructionPropCount
        {
            get => (float)GetValue(nameof(ConstructionPropCount));
            set => SetValue(nameof(ConstructionPropCount), value);
        }
        public bool FullSegmentWorkZones
        {
            get => (bool)GetValue(nameof(FullSegmentWorkZones));
            set => SetValue(nameof(FullSegmentWorkZones), value);
        }
        public bool ShowRoadDamageVisuals
        {
            get => (bool)GetValue(nameof(ShowRoadDamageVisuals));
            set => SetValue(nameof(ShowRoadDamageVisuals), value);
        }
        public bool IncludeEquipmentProps
        {
            get => (bool)GetValue(nameof(IncludeEquipmentProps));
            set => SetValue(nameof(IncludeEquipmentProps), value);
        }
        public bool ShowConstructionSupportVehicle
        {
            get => (bool)GetValue(nameof(ShowConstructionSupportVehicle));
            set => SetValue(nameof(ShowConstructionSupportVehicle), value);
        }
        public bool ShowPoliceSupportVehicle
        {
            get => (bool)GetValue(nameof(ShowPoliceSupportVehicle));
            set => SetValue(nameof(ShowPoliceSupportVehicle), value);
        }
        public float CandidateScanLimit
        {
            get => (float)GetValue(nameof(CandidateScanLimit));
            set => SetValue(nameof(CandidateScanLimit), value);
        }
        public float RandomSeed
        {
            get => (float)GetValue(nameof(RandomSeed));
            set => SetValue(nameof(RandomSeed), value);
        }
        public bool RestoreWhenDisabled
        {
            get => (bool)GetValue(nameof(RestoreWhenDisabled));
            set => SetValue(nameof(RestoreWhenDisabled), value);
        }
        public bool CleanupOrphanedClosuresOnLoad
        {
            get => (bool)GetValue(nameof(CleanupOrphanedClosuresOnLoad));
            set => SetValue(nameof(CleanupOrphanedClosuresOnLoad), value);
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

    public class RoadPrecisionSettings : SettingsBackup
    {
        public int DistanceDecimalPlaces
        {
            get => (int)GetValue(nameof(DistanceDecimalPlaces));
            set => SetValue(nameof(DistanceDecimalPlaces), value);
        }
        public int AngleDecimalPlaces
        {
            get => (int)GetValue(nameof(AngleDecimalPlaces));
            set => SetValue(nameof(AngleDecimalPlaces), value);
        }
        public bool EnableFloatDistance
        {
            get => (bool)GetValue(nameof(EnableFloatDistance));
            set => SetValue(nameof(EnableFloatDistance), value);
        }
        public bool EnableFloatAngle
        {
            get => (bool)GetValue(nameof(EnableFloatAngle));
            set => SetValue(nameof(EnableFloatAngle), value);
        }
    }

    public class RoadWearAdjusterSettings : SettingsBackup
    {
        public bool CarRoadWearOverrideEnable
        {
            get => (bool)GetValue(nameof(CarRoadWearOverrideEnable));
            set => SetValue(nameof(CarRoadWearOverrideEnable), value);
        }
        public int CarRoadWearTextureVariant
        {
            get => (int)GetValue(nameof(CarRoadWearTextureVariant));
            set => SetValue(nameof(CarRoadWearTextureVariant), value);
        }
        public float CarRoadWearTextureBrightness
        {
            get => (float)GetValue(nameof(CarRoadWearTextureBrightness));
            set => SetValue(nameof(CarRoadWearTextureBrightness), value);
        }
        public float CarRoadWearTextureOpacity
        {
            get => (float)GetValue(nameof(CarRoadWearTextureOpacity));
            set => SetValue(nameof(CarRoadWearTextureOpacity), value);
        }
        public float CarRoadWearTextureSmoothness
        {
            get => (float)GetValue(nameof(CarRoadWearTextureSmoothness));
            set => SetValue(nameof(CarRoadWearTextureSmoothness), value);
        }
        public bool GravelRoadWearOverrideEnable
        {
            get => (bool)GetValue(nameof(GravelRoadWearOverrideEnable));
            set => SetValue(nameof(GravelRoadWearOverrideEnable), value);
        }
        public int GravelRoadWearTextureVariant
        {
            get => (int)GetValue(nameof(GravelRoadWearTextureVariant));
            set => SetValue(nameof(GravelRoadWearTextureVariant), value);
        }
        public float GravelRoadWearTextureBrightness
        {
            get => (float)GetValue(nameof(GravelRoadWearTextureBrightness));
            set => SetValue(nameof(GravelRoadWearTextureBrightness), value);
        }
        public float GravelRoadWearTextureOpacity
        {
            get => (float)GetValue(nameof(GravelRoadWearTextureOpacity));
            set => SetValue(nameof(GravelRoadWearTextureOpacity), value);
        }
        public float GravelRoadWearTextureSmoothness
        {
            get => (float)GetValue(nameof(GravelRoadWearTextureSmoothness));
            set => SetValue(nameof(GravelRoadWearTextureSmoothness), value);
        }
        public bool BusLaneOverrideEnable
        {
            get => (bool)GetValue(nameof(BusLaneOverrideEnable));
            set => SetValue(nameof(BusLaneOverrideEnable), value);
        }
        public int BusLaneTextureVariant
        {
            get => (int)GetValue(nameof(BusLaneTextureVariant));
            set => SetValue(nameof(BusLaneTextureVariant), value);
        }
        public float BusLaneTextureBrightness
        {
            get => (float)GetValue(nameof(BusLaneTextureBrightness));
            set => SetValue(nameof(BusLaneTextureBrightness), value);
        }
        public float BusLaneTextureOpacity
        {
            get => (float)GetValue(nameof(BusLaneTextureOpacity));
            set => SetValue(nameof(BusLaneTextureOpacity), value);
        }
        public float BusLaneTextureHue
        {
            get => (float)GetValue(nameof(BusLaneTextureHue));
            set => SetValue(nameof(BusLaneTextureHue), value);
        }
        public float BusLaneTextureSmoothness
        {
            get => (float)GetValue(nameof(BusLaneTextureSmoothness));
            set => SetValue(nameof(BusLaneTextureSmoothness), value);
        }
        public bool BicycleLaneOverrideEnable
        {
            get => (bool)GetValue(nameof(BicycleLaneOverrideEnable));
            set => SetValue(nameof(BicycleLaneOverrideEnable), value);
        }
        public int BicycleLaneTextureVariant
        {
            get => (int)GetValue(nameof(BicycleLaneTextureVariant));
            set => SetValue(nameof(BicycleLaneTextureVariant), value);
        }
        public float BicycleLaneTextureBrightness
        {
            get => (float)GetValue(nameof(BicycleLaneTextureBrightness));
            set => SetValue(nameof(BicycleLaneTextureBrightness), value);
        }
        public float BicycleLaneTextureOpacity
        {
            get => (float)GetValue(nameof(BicycleLaneTextureOpacity));
            set => SetValue(nameof(BicycleLaneTextureOpacity), value);
        }
        public float BicycleLaneTextureHue
        {
            get => (float)GetValue(nameof(BicycleLaneTextureHue));
            set => SetValue(nameof(BicycleLaneTextureHue), value);
        }
        public float BicycleLaneTextureSmoothness
        {
            get => (float)GetValue(nameof(BicycleLaneTextureSmoothness));
            set => SetValue(nameof(BicycleLaneTextureSmoothness), value);
        }
    }

    public class RoadWearToolToggleSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
    }

    public class SceneExplorerSettings : SettingsBackup
    {
        public float UIScalingSlider
        {
            get => (float)GetValue(nameof(UIScalingSlider));
            set => SetValue(nameof(UIScalingSlider), value);
        }
        public float NormalizedScaling
        {
            get => (float)GetValue(nameof(NormalizedScaling));
            set => SetValue(nameof(NormalizedScaling), value);
        }
        public bool UseShortComponentNames
        {
            get => (bool)GetValue(nameof(UseShortComponentNames));
            set => SetValue(nameof(UseShortComponentNames), value);
        }
    }

    public class ServiceCimsSettings : SettingsBackup
    {
        public int DispatchIntervalMinutes
        {
            get => (int)GetValue(nameof(DispatchIntervalMinutes));
            set => SetValue(nameof(DispatchIntervalMinutes), value);
        }
        public int MaxVolunteersPerDispatch
        {
            get => (int)GetValue(nameof(MaxVolunteersPerDispatch));
            set => SetValue(nameof(MaxVolunteersPerDispatch), value);
        }
        public int MinFailureCount
        {
            get => (int)GetValue(nameof(MinFailureCount));
            set => SetValue(nameof(MinFailureCount), value);
        }
        public int MaintenanceThresholdPercent
        {
            get => (int)GetValue(nameof(MaintenanceThresholdPercent));
            set => SetValue(nameof(MaintenanceThresholdPercent), value);
        }
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

    public class SimpleBrushSettings : SettingsBackup
    {
        public bool InfiniteFertility
        {
            get => (bool)GetValue(nameof(InfiniteFertility));
            set => SetValue(nameof(InfiniteFertility), value);
        }
        public bool InfiniteOre
        {
            get => (bool)GetValue(nameof(InfiniteOre));
            set => SetValue(nameof(InfiniteOre), value);
        }
        public bool InfiniteOil
        {
            get => (bool)GetValue(nameof(InfiniteOil));
            set => SetValue(nameof(InfiniteOil), value);
        }
        public bool InfiniteFish
        {
            get => (bool)GetValue(nameof(InfiniteFish));
            set => SetValue(nameof(InfiniteFish), value);
        }
    }

    public class SimpleModCheckerSettings : SettingsBackup
    {
        public bool IsCustomChirpsOn
        {
            get => (bool)GetValue(nameof(IsCustomChirpsOn));
            set => SetValue(nameof(IsCustomChirpsOn), value);
        }
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
        public bool AutoSaveOffChirp
        {
            get => (bool)GetValue(nameof(AutoSaveOffChirp));
            set => SetValue(nameof(AutoSaveOffChirp), value);
        }

        //public bool DeleteMissingCIDs
        //{
        //    get => (bool)GetValue(nameof(DeleteMissingCIDs));
        //    set => SetValue(nameof(DeleteMissingCIDs), value);
        //}
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

        //public bool EnableVerboseLogging
        //{
        //    get => (bool)GetValue(nameof(EnableVerboseLogging));
        //    set => SetValue(nameof(EnableVerboseLogging), value);
        //}
        public bool AutoRestoreSettingBackupOnStartup
        {
            get => (bool)GetValue(nameof(AutoRestoreSettingBackupOnStartup));
            set => SetValue(nameof(AutoRestoreSettingBackupOnStartup), value);
        }
        public int ProfileDropdown
        {
            get => (int)GetValue(nameof(ProfileDropdown));
            set => SetValue(nameof(ProfileDropdown), value);
        }

        //public int ProfileListVersion
        //{
        //    get => (int)GetValue(nameof(ProfileListVersion));
        //    set => SetValue(nameof(ProfileListVersion), value);
        //}
        //public int ModDatabaseTimeVersion
        //{
        //    get => (int)GetValue(nameof(ModDatabaseTimeVersion));
        //    set => SetValue(nameof(ModDatabaseTimeVersion), value);
        //}
        //public bool VerifyRunning
        //{
        //    get => (bool)GetValue(nameof(VerifyRunning));
        //    set => SetValue(nameof(VerifyRunning), value);
        //}
        //public bool IsInGameOrEditor
        //{
        //    get => (bool)GetValue(nameof(IsInGameOrEditor));
        //    set => SetValue(nameof(IsInGameOrEditor), value);
        //}
        //public int ModLoadedVersion
        //{
        //    get => (int)GetValue(nameof(ModLoadedVersion));
        //    set => SetValue(nameof(ModLoadedVersion), value);
        //}
        //public int ModFolderListVersion
        //{
        //    get => (int)GetValue(nameof(ModFolderListVersion));
        //    set => SetValue(nameof(ModFolderListVersion), value);
        //}
        //public string ModFolderDropdown
        //{
        //    get => (string)GetValue(nameof(ModFolderDropdown));
        //    set => SetValue(nameof(ModFolderDropdown), value);
        //}
        //public bool AutoCleanUpOldVersions
        //{
        //    get => (bool)GetValue(nameof(AutoCleanUpOldVersions));
        //    set => SetValue(nameof(AutoCleanUpOldVersions), value);
        //}
        //public bool IsCleaningUp
        //{
        //    get => (bool)GetValue(nameof(IsCleaningUp));
        //    set => SetValue(nameof(IsCleaningUp), value);
        //}
        //public string ProfileName0
        //{
        //    get => (string)GetValue(nameof(ProfileName0));
        //    set => SetValue(nameof(ProfileName0), value);
        //}
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

    public class SimpleRadioSettings : SettingsBackup
    {
        public bool EnableMP3
        {
            get => (bool)GetValue(nameof(EnableMP3));
            set => SetValue(nameof(EnableMP3), value);
        }
        public bool EnableWAV
        {
            get => (bool)GetValue(nameof(EnableWAV));
            set => SetValue(nameof(EnableWAV), value);
        }
        //public string LastStation
        //{
        //    get => (string)GetValue(nameof(LastStation));
        //    set => SetValue(nameof(LastStation), value);
        //}
    }

    public class SirenChangerSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public bool AutoApplySoundSetPerCity
        {
            get => (bool)GetValue(nameof(AutoApplySoundSetPerCity));
            set => SetValue(nameof(AutoApplySoundSetPerCity), value);
        }
        public string SelectedCitySoundSet
        {
            get => (string)GetValue(nameof(SelectedCitySoundSet));
            set => SetValue(nameof(SelectedCitySoundSet), value);
        }
        public string NewCitySoundSetName
        {
            get => (string)GetValue(nameof(NewCitySoundSetName));
            set => SetValue(nameof(NewCitySoundSetName), value);
        }
        public string SelectedCitySoundSetBinding
        {
            get => (string)GetValue(nameof(SelectedCitySoundSetBinding));
            set => SetValue(nameof(SelectedCitySoundSetBinding), value);
        }
        public string PoliceSirenNA
        {
            get => (string)GetValue(nameof(PoliceSirenNA));
            set => SetValue(nameof(PoliceSirenNA), value);
        }
        public string PoliceSirenEU
        {
            get => (string)GetValue(nameof(PoliceSirenEU));
            set => SetValue(nameof(PoliceSirenEU), value);
        }
        public string FireTruckSirenNA
        {
            get => (string)GetValue(nameof(FireTruckSirenNA));
            set => SetValue(nameof(FireTruckSirenNA), value);
        }
        public string FireTruckSirenEU
        {
            get => (string)GetValue(nameof(FireTruckSirenEU));
            set => SetValue(nameof(FireTruckSirenEU), value);
        }
        public string AmbulanceSirenNA
        {
            get => (string)GetValue(nameof(AmbulanceSirenNA));
            set => SetValue(nameof(AmbulanceSirenNA), value);
        }
        public string AmbulanceSirenEU
        {
            get => (string)GetValue(nameof(AmbulanceSirenEU));
            set => SetValue(nameof(AmbulanceSirenEU), value);
        }
        public string SpecificVehiclePrefab
        {
            get => (string)GetValue(nameof(SpecificVehiclePrefab));
            set => SetValue(nameof(SpecificVehiclePrefab), value);
        }
        public string SpecificVehicleSirenOverride
        {
            get => (string)GetValue(nameof(SpecificVehicleSirenOverride));
            set => SetValue(nameof(SpecificVehicleSirenOverride), value);
        }
        public int MissingSirenFallbackBehavior
        {
            get => (int)GetValue(nameof(MissingSirenFallbackBehavior));
            set => SetValue(nameof(MissingSirenFallbackBehavior), value);
        }
        public string AlternateFallbackSiren
        {
            get => (string)GetValue(nameof(AlternateFallbackSiren));
            set => SetValue(nameof(AlternateFallbackSiren), value);
        }
        public string EditProfile
        {
            get => (string)GetValue(nameof(EditProfile));
            set => SetValue(nameof(EditProfile), value);
        }
        public string CopyFromProfile
        {
            get => (string)GetValue(nameof(CopyFromProfile));
            set => SetValue(nameof(CopyFromProfile), value);
        }
        public float ProfileVolume
        {
            get => (float)GetValue(nameof(ProfileVolume));
            set => SetValue(nameof(ProfileVolume), value);
        }
        public float ProfilePitch
        {
            get => (float)GetValue(nameof(ProfilePitch));
            set => SetValue(nameof(ProfilePitch), value);
        }
        public float ProfileSpatialBlend
        {
            get => (float)GetValue(nameof(ProfileSpatialBlend));
            set => SetValue(nameof(ProfileSpatialBlend), value);
        }
        public float ProfileDoppler
        {
            get => (float)GetValue(nameof(ProfileDoppler));
            set => SetValue(nameof(ProfileDoppler), value);
        }
        public float ProfileSpread
        {
            get => (float)GetValue(nameof(ProfileSpread));
            set => SetValue(nameof(ProfileSpread), value);
        }
        public float ProfileMinDistance
        {
            get => (float)GetValue(nameof(ProfileMinDistance));
            set => SetValue(nameof(ProfileMinDistance), value);
        }
        public float ProfileMaxDistance
        {
            get => (float)GetValue(nameof(ProfileMaxDistance));
            set => SetValue(nameof(ProfileMaxDistance), value);
        }
        public bool ProfileLoop
        {
            get => (bool)GetValue(nameof(ProfileLoop));
            set => SetValue(nameof(ProfileLoop), value);
        }
        public int ProfileRolloffMode
        {
            get => (int)GetValue(nameof(ProfileRolloffMode));
            set => SetValue(nameof(ProfileRolloffMode), value);
        }
        public bool ProfileRandomStartTime
        {
            get => (bool)GetValue(nameof(ProfileRandomStartTime));
            set => SetValue(nameof(ProfileRandomStartTime), value);
        }
        public float ProfileFadeInSeconds
        {
            get => (float)GetValue(nameof(ProfileFadeInSeconds));
            set => SetValue(nameof(ProfileFadeInSeconds), value);
        }
        public float ProfileFadeOutSeconds
        {
            get => (float)GetValue(nameof(ProfileFadeOutSeconds));
            set => SetValue(nameof(ProfileFadeOutSeconds), value);
        }
        public bool DumpDetectedSirens
        {
            get => (bool)GetValue(nameof(DumpDetectedSirens));
            set => SetValue(nameof(DumpDetectedSirens), value);
        }
        public bool DumpAllSirenCandidates
        {
            get => (bool)GetValue(nameof(DumpAllSirenCandidates));
            set => SetValue(nameof(DumpAllSirenCandidates), value);
        }
        public bool VehicleEngineEnabled
        {
            get => (bool)GetValue(nameof(VehicleEngineEnabled));
            set => SetValue(nameof(VehicleEngineEnabled), value);
        }
        public string VehicleEngineOverrideTarget
        {
            get => (string)GetValue(nameof(VehicleEngineOverrideTarget));
            set => SetValue(nameof(VehicleEngineOverrideTarget), value);
        }
        public string VehicleEngineOverrideSelection
        {
            get => (string)GetValue(nameof(VehicleEngineOverrideSelection));
            set => SetValue(nameof(VehicleEngineOverrideSelection), value);
        }
        public int MissingVehicleEngineFallbackBehavior
        {
            get => (int)GetValue(nameof(MissingVehicleEngineFallbackBehavior));
            set => SetValue(nameof(MissingVehicleEngineFallbackBehavior), value);
        }
        public string AlternateVehicleEngineFallbackSelection
        {
            get => (string)GetValue(nameof(AlternateVehicleEngineFallbackSelection));
            set => SetValue(nameof(AlternateVehicleEngineFallbackSelection), value);
        }
        public string EditVehicleEngineProfile
        {
            get => (string)GetValue(nameof(EditVehicleEngineProfile));
            set => SetValue(nameof(EditVehicleEngineProfile), value);
        }
        public string CopyFromVehicleEngineProfile
        {
            get => (string)GetValue(nameof(CopyFromVehicleEngineProfile));
            set => SetValue(nameof(CopyFromVehicleEngineProfile), value);
        }
        public float VehicleEngineProfileVolume
        {
            get => (float)GetValue(nameof(VehicleEngineProfileVolume));
            set => SetValue(nameof(VehicleEngineProfileVolume), value);
        }
        public float VehicleEngineProfilePitch
        {
            get => (float)GetValue(nameof(VehicleEngineProfilePitch));
            set => SetValue(nameof(VehicleEngineProfilePitch), value);
        }
        public float VehicleEngineProfileSpatialBlend
        {
            get => (float)GetValue(nameof(VehicleEngineProfileSpatialBlend));
            set => SetValue(nameof(VehicleEngineProfileSpatialBlend), value);
        }
        public float VehicleEngineProfileDoppler
        {
            get => (float)GetValue(nameof(VehicleEngineProfileDoppler));
            set => SetValue(nameof(VehicleEngineProfileDoppler), value);
        }
        public float VehicleEngineProfileSpread
        {
            get => (float)GetValue(nameof(VehicleEngineProfileSpread));
            set => SetValue(nameof(VehicleEngineProfileSpread), value);
        }
        public float VehicleEngineProfileMinDistance
        {
            get => (float)GetValue(nameof(VehicleEngineProfileMinDistance));
            set => SetValue(nameof(VehicleEngineProfileMinDistance), value);
        }
        public float VehicleEngineProfileMaxDistance
        {
            get => (float)GetValue(nameof(VehicleEngineProfileMaxDistance));
            set => SetValue(nameof(VehicleEngineProfileMaxDistance), value);
        }
        public bool VehicleEngineProfileLoop
        {
            get => (bool)GetValue(nameof(VehicleEngineProfileLoop));
            set => SetValue(nameof(VehicleEngineProfileLoop), value);
        }
        public int VehicleEngineProfileRolloffMode
        {
            get => (int)GetValue(nameof(VehicleEngineProfileRolloffMode));
            set => SetValue(nameof(VehicleEngineProfileRolloffMode), value);
        }
        public bool VehicleEngineProfileRandomStartTime
        {
            get => (bool)GetValue(nameof(VehicleEngineProfileRandomStartTime));
            set => SetValue(nameof(VehicleEngineProfileRandomStartTime), value);
        }
        public float VehicleEngineProfileFadeInSeconds
        {
            get => (float)GetValue(nameof(VehicleEngineProfileFadeInSeconds));
            set => SetValue(nameof(VehicleEngineProfileFadeInSeconds), value);
        }
        public float VehicleEngineProfileFadeOutSeconds
        {
            get => (float)GetValue(nameof(VehicleEngineProfileFadeOutSeconds));
            set => SetValue(nameof(VehicleEngineProfileFadeOutSeconds), value);
        }
        public bool AmbientEnabled
        {
            get => (bool)GetValue(nameof(AmbientEnabled));
            set => SetValue(nameof(AmbientEnabled), value);
        }
        public bool AmbientMuteAllTargets
        {
            get => (bool)GetValue(nameof(AmbientMuteAllTargets));
            set => SetValue(nameof(AmbientMuteAllTargets), value);
        }
        public string AmbientOverrideTarget
        {
            get => (string)GetValue(nameof(AmbientOverrideTarget));
            set => SetValue(nameof(AmbientOverrideTarget), value);
        }
        public string AmbientOverrideSelection
        {
            get => (string)GetValue(nameof(AmbientOverrideSelection));
            set => SetValue(nameof(AmbientOverrideSelection), value);
        }
        public int MissingAmbientFallbackBehavior
        {
            get => (int)GetValue(nameof(MissingAmbientFallbackBehavior));
            set => SetValue(nameof(MissingAmbientFallbackBehavior), value);
        }
        public string AlternateAmbientFallbackSelection
        {
            get => (string)GetValue(nameof(AlternateAmbientFallbackSelection));
            set => SetValue(nameof(AlternateAmbientFallbackSelection), value);
        }
        public string EditAmbientProfile
        {
            get => (string)GetValue(nameof(EditAmbientProfile));
            set => SetValue(nameof(EditAmbientProfile), value);
        }
        public string CopyFromAmbientProfile
        {
            get => (string)GetValue(nameof(CopyFromAmbientProfile));
            set => SetValue(nameof(CopyFromAmbientProfile), value);
        }
        public float AmbientProfileVolume
        {
            get => (float)GetValue(nameof(AmbientProfileVolume));
            set => SetValue(nameof(AmbientProfileVolume), value);
        }
        public float AmbientProfilePitch
        {
            get => (float)GetValue(nameof(AmbientProfilePitch));
            set => SetValue(nameof(AmbientProfilePitch), value);
        }
        public float AmbientProfileSpatialBlend
        {
            get => (float)GetValue(nameof(AmbientProfileSpatialBlend));
            set => SetValue(nameof(AmbientProfileSpatialBlend), value);
        }
        public float AmbientProfileDoppler
        {
            get => (float)GetValue(nameof(AmbientProfileDoppler));
            set => SetValue(nameof(AmbientProfileDoppler), value);
        }
        public float AmbientProfileSpread
        {
            get => (float)GetValue(nameof(AmbientProfileSpread));
            set => SetValue(nameof(AmbientProfileSpread), value);
        }
        public float AmbientProfileMinDistance
        {
            get => (float)GetValue(nameof(AmbientProfileMinDistance));
            set => SetValue(nameof(AmbientProfileMinDistance), value);
        }
        public float AmbientProfileMaxDistance
        {
            get => (float)GetValue(nameof(AmbientProfileMaxDistance));
            set => SetValue(nameof(AmbientProfileMaxDistance), value);
        }
        public bool AmbientProfileLoop
        {
            get => (bool)GetValue(nameof(AmbientProfileLoop));
            set => SetValue(nameof(AmbientProfileLoop), value);
        }
        public int AmbientProfileRolloffMode
        {
            get => (int)GetValue(nameof(AmbientProfileRolloffMode));
            set => SetValue(nameof(AmbientProfileRolloffMode), value);
        }
        public bool AmbientProfileRandomStartTime
        {
            get => (bool)GetValue(nameof(AmbientProfileRandomStartTime));
            set => SetValue(nameof(AmbientProfileRandomStartTime), value);
        }
        public float AmbientProfileFadeInSeconds
        {
            get => (float)GetValue(nameof(AmbientProfileFadeInSeconds));
            set => SetValue(nameof(AmbientProfileFadeInSeconds), value);
        }
        public float AmbientProfileFadeOutSeconds
        {
            get => (float)GetValue(nameof(AmbientProfileFadeOutSeconds));
            set => SetValue(nameof(AmbientProfileFadeOutSeconds), value);
        }
        public bool BuildingEnabled
        {
            get => (bool)GetValue(nameof(BuildingEnabled));
            set => SetValue(nameof(BuildingEnabled), value);
        }
        public bool BuildingMuteAllTargets
        {
            get => (bool)GetValue(nameof(BuildingMuteAllTargets));
            set => SetValue(nameof(BuildingMuteAllTargets), value);
        }
        public string BuildingOverrideTarget
        {
            get => (string)GetValue(nameof(BuildingOverrideTarget));
            set => SetValue(nameof(BuildingOverrideTarget), value);
        }
        public string BuildingOverrideSelection
        {
            get => (string)GetValue(nameof(BuildingOverrideSelection));
            set => SetValue(nameof(BuildingOverrideSelection), value);
        }
        public int MissingBuildingFallbackBehavior
        {
            get => (int)GetValue(nameof(MissingBuildingFallbackBehavior));
            set => SetValue(nameof(MissingBuildingFallbackBehavior), value);
        }
        public string AlternateBuildingFallbackSelection
        {
            get => (string)GetValue(nameof(AlternateBuildingFallbackSelection));
            set => SetValue(nameof(AlternateBuildingFallbackSelection), value);
        }
        public string EditBuildingProfile
        {
            get => (string)GetValue(nameof(EditBuildingProfile));
            set => SetValue(nameof(EditBuildingProfile), value);
        }
        public string CopyFromBuildingProfile
        {
            get => (string)GetValue(nameof(CopyFromBuildingProfile));
            set => SetValue(nameof(CopyFromBuildingProfile), value);
        }
        public float BuildingProfileVolume
        {
            get => (float)GetValue(nameof(BuildingProfileVolume));
            set => SetValue(nameof(BuildingProfileVolume), value);
        }
        public float BuildingProfilePitch
        {
            get => (float)GetValue(nameof(BuildingProfilePitch));
            set => SetValue(nameof(BuildingProfilePitch), value);
        }
        public float BuildingProfileSpatialBlend
        {
            get => (float)GetValue(nameof(BuildingProfileSpatialBlend));
            set => SetValue(nameof(BuildingProfileSpatialBlend), value);
        }
        public float BuildingProfileDoppler
        {
            get => (float)GetValue(nameof(BuildingProfileDoppler));
            set => SetValue(nameof(BuildingProfileDoppler), value);
        }
        public float BuildingProfileSpread
        {
            get => (float)GetValue(nameof(BuildingProfileSpread));
            set => SetValue(nameof(BuildingProfileSpread), value);
        }
        public float BuildingProfileMinDistance
        {
            get => (float)GetValue(nameof(BuildingProfileMinDistance));
            set => SetValue(nameof(BuildingProfileMinDistance), value);
        }
        public float BuildingProfileMaxDistance
        {
            get => (float)GetValue(nameof(BuildingProfileMaxDistance));
            set => SetValue(nameof(BuildingProfileMaxDistance), value);
        }
        public bool BuildingProfileLoop
        {
            get => (bool)GetValue(nameof(BuildingProfileLoop));
            set => SetValue(nameof(BuildingProfileLoop), value);
        }
        public int BuildingProfileRolloffMode
        {
            get => (int)GetValue(nameof(BuildingProfileRolloffMode));
            set => SetValue(nameof(BuildingProfileRolloffMode), value);
        }
        public bool BuildingProfileRandomStartTime
        {
            get => (bool)GetValue(nameof(BuildingProfileRandomStartTime));
            set => SetValue(nameof(BuildingProfileRandomStartTime), value);
        }
        public float BuildingProfileFadeInSeconds
        {
            get => (float)GetValue(nameof(BuildingProfileFadeInSeconds));
            set => SetValue(nameof(BuildingProfileFadeInSeconds), value);
        }
        public float BuildingProfileFadeOutSeconds
        {
            get => (float)GetValue(nameof(BuildingProfileFadeOutSeconds));
            set => SetValue(nameof(BuildingProfileFadeOutSeconds), value);
        }

        //public string DeveloperSirenSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperSirenSelection));
        //    set => SetValue(nameof(DeveloperSirenSelection), value);
        //}
        //public string DeveloperEngineSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperEngineSelection));
        //    set => SetValue(nameof(DeveloperEngineSelection), value);
        //}
        //public string DeveloperAmbientSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperAmbientSelection));
        //    set => SetValue(nameof(DeveloperAmbientSelection), value);
        //}
        //public string DeveloperBuildingSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperBuildingSelection));
        //    set => SetValue(nameof(DeveloperBuildingSelection), value);
        //}
        //public string DeveloperModuleDisplayName
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleDisplayName));
        //    set => SetValue(nameof(DeveloperModuleDisplayName), value);
        //}
        //public string DeveloperModuleId
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleId));
        //    set => SetValue(nameof(DeveloperModuleId), value);
        //}
        //public string DeveloperModuleVersion
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleVersion));
        //    set => SetValue(nameof(DeveloperModuleVersion), value);
        //}
        //public string DeveloperModuleExportDirectory
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleExportDirectory));
        //    set => SetValue(nameof(DeveloperModuleExportDirectory), value);
        //}
        //public string DeveloperModuleFolderName
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleFolderName));
        //    set => SetValue(nameof(DeveloperModuleFolderName), value);
        //}
        //public string DeveloperModuleLocalSirenSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleLocalSirenSelection));
        //    set => SetValue(nameof(DeveloperModuleLocalSirenSelection), value);
        //}
        //public string DeveloperModuleLocalEngineSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleLocalEngineSelection));
        //    set => SetValue(nameof(DeveloperModuleLocalEngineSelection), value);
        //}
        //public string DeveloperModuleLocalAmbientSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleLocalAmbientSelection));
        //    set => SetValue(nameof(DeveloperModuleLocalAmbientSelection), value);
        //}
        //public string DeveloperModuleLocalBuildingSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleLocalBuildingSelection));
        //    set => SetValue(nameof(DeveloperModuleLocalBuildingSelection), value);
        //}
        //public string DeveloperModuleLocalTransitAnnouncementSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleLocalTransitAnnouncementSelection));
        //    set => SetValue(nameof(DeveloperModuleLocalTransitAnnouncementSelection), value);
        //}
        //public string DeveloperModuleSoundSetProfileSelection
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleSoundSetProfileSelection));
        //    set => SetValue(nameof(DeveloperModuleSoundSetProfileSelection), value);
        //}
        //public int DeveloperModuleUploadAccessLevel
        //{
        //    get => (int)GetValue(nameof(DeveloperModuleUploadAccessLevel));
        //    set => SetValue(nameof(DeveloperModuleUploadAccessLevel), value);
        //}
        //public int DeveloperModuleUploadPublishMode
        //{
        //    get => (int)GetValue(nameof(DeveloperModuleUploadPublishMode));
        //    set => SetValue(nameof(DeveloperModuleUploadPublishMode), value);
        //}
        //public string DeveloperModuleUploadExistingPublishedId
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleUploadExistingPublishedId));
        //    set => SetValue(nameof(DeveloperModuleUploadExistingPublishedId), value);
        //}
        //public string DeveloperModuleUploadDescription
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleUploadDescription));
        //    set => SetValue(nameof(DeveloperModuleUploadDescription), value);
        //}
        //public string DeveloperModuleUploadAdditionalDependencies
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleUploadAdditionalDependencies));
        //    set => SetValue(nameof(DeveloperModuleUploadAdditionalDependencies), value);
        //}
        //public string DeveloperModuleUploadThumbnailDirectory
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleUploadThumbnailDirectory));
        //    set => SetValue(nameof(DeveloperModuleUploadThumbnailDirectory), value);
        //}
        //public string DeveloperModuleUploadThumbnailPath
        //{
        //    get => (string)GetValue(nameof(DeveloperModuleUploadThumbnailPath));
        //    set => SetValue(nameof(DeveloperModuleUploadThumbnailPath), value);
        //}
        public bool TransitAnnouncementsEnabled
        {
            get => (bool)GetValue(nameof(TransitAnnouncementsEnabled));
            set => SetValue(nameof(TransitAnnouncementsEnabled), value);
        }
        public float TransitAnnouncementGlobalVolume
        {
            get => (float)GetValue(nameof(TransitAnnouncementGlobalVolume));
            set => SetValue(nameof(TransitAnnouncementGlobalVolume), value);
        }
        public float TransitAnnouncementGlobalMinDistance
        {
            get => (float)GetValue(nameof(TransitAnnouncementGlobalMinDistance));
            set => SetValue(nameof(TransitAnnouncementGlobalMinDistance), value);
        }
        public float TransitAnnouncementGlobalMaxDistance
        {
            get => (float)GetValue(nameof(TransitAnnouncementGlobalMaxDistance));
            set => SetValue(nameof(TransitAnnouncementGlobalMaxDistance), value);
        }
        public string TransitAnnouncementLineOverrideService
        {
            get => (string)GetValue(nameof(TransitAnnouncementLineOverrideService));
            set => SetValue(nameof(TransitAnnouncementLineOverrideService), value);
        }
        public string TransitAnnouncementSelectedStationOverride
        {
            get => (string)GetValue(nameof(TransitAnnouncementSelectedStationOverride));
            set => SetValue(nameof(TransitAnnouncementSelectedStationOverride), value);
        }
        public string TransitAnnouncementSelectedLineOverride
        {
            get => (string)GetValue(nameof(TransitAnnouncementSelectedLineOverride));
            set => SetValue(nameof(TransitAnnouncementSelectedLineOverride), value);
        }
        public string TransitAnnouncementLineArrivalOverride
        {
            get => (string)GetValue(nameof(TransitAnnouncementLineArrivalOverride));
            set => SetValue(nameof(TransitAnnouncementLineArrivalOverride), value);
        }
        public string TransitAnnouncementLineDepartureOverride
        {
            get => (string)GetValue(nameof(TransitAnnouncementLineDepartureOverride));
            set => SetValue(nameof(TransitAnnouncementLineDepartureOverride), value);
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
        public bool disable_Ship
        {
            get => (bool)GetValue(nameof(disable_Ship));
            set => SetValue(nameof(disable_Ship), value);
        }
        public int target_occupancy_Ship
        {
            get => (int)GetValue(nameof(target_occupancy_Ship));
            set => SetValue(nameof(target_occupancy_Ship), value);
        }
        public int standard_ticket_Ship
        {
            get => (int)GetValue(nameof(standard_ticket_Ship));
            set => SetValue(nameof(standard_ticket_Ship), value);
        }
        public int max_ticket_increase_Ship
        {
            get => (int)GetValue(nameof(max_ticket_increase_Ship));
            set => SetValue(nameof(max_ticket_increase_Ship), value);
        }
        public int max_ticket_discount_Ship
        {
            get => (int)GetValue(nameof(max_ticket_discount_Ship));
            set => SetValue(nameof(max_ticket_discount_Ship), value);
        }
        public int max_vahicles_adj_Ship
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Ship));
            set => SetValue(nameof(max_vahicles_adj_Ship), value);
        }
        public int min_vahicles_adj_Ship
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Ship));
            set => SetValue(nameof(min_vahicles_adj_Ship), value);
        }
        public bool disable_Airplane
        {
            get => (bool)GetValue(nameof(disable_Airplane));
            set => SetValue(nameof(disable_Airplane), value);
        }
        public int target_occupancy_Airplane
        {
            get => (int)GetValue(nameof(target_occupancy_Airplane));
            set => SetValue(nameof(target_occupancy_Airplane), value);
        }
        public int standard_ticket_Airplane
        {
            get => (int)GetValue(nameof(standard_ticket_Airplane));
            set => SetValue(nameof(standard_ticket_Airplane), value);
        }
        public int max_ticket_increase_Airplane
        {
            get => (int)GetValue(nameof(max_ticket_increase_Airplane));
            set => SetValue(nameof(max_ticket_increase_Airplane), value);
        }
        public int max_ticket_discount_Airplane
        {
            get => (int)GetValue(nameof(max_ticket_discount_Airplane));
            set => SetValue(nameof(max_ticket_discount_Airplane), value);
        }
        public int max_vahicles_adj_Airplane
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Airplane));
            set => SetValue(nameof(max_vahicles_adj_Airplane), value);
        }
        public int min_vahicles_adj_Airplane
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Airplane));
            set => SetValue(nameof(min_vahicles_adj_Airplane), value);
        }
        public bool disable_Ferry
        {
            get => (bool)GetValue(nameof(disable_Ferry));
            set => SetValue(nameof(disable_Ferry), value);
        }
        public int target_occupancy_Ferry
        {
            get => (int)GetValue(nameof(target_occupancy_Ferry));
            set => SetValue(nameof(target_occupancy_Ferry), value);
        }
        public int standard_ticket_Ferry
        {
            get => (int)GetValue(nameof(standard_ticket_Ferry));
            set => SetValue(nameof(standard_ticket_Ferry), value);
        }
        public int max_ticket_increase_Ferry
        {
            get => (int)GetValue(nameof(max_ticket_increase_Ferry));
            set => SetValue(nameof(max_ticket_increase_Ferry), value);
        }
        public int max_ticket_discount_Ferry
        {
            get => (int)GetValue(nameof(max_ticket_discount_Ferry));
            set => SetValue(nameof(max_ticket_discount_Ferry), value);
        }
        public int max_vahicles_adj_Ferry
        {
            get => (int)GetValue(nameof(max_vahicles_adj_Ferry));
            set => SetValue(nameof(max_vahicles_adj_Ferry), value);
        }
        public int min_vahicles_adj_Ferry
        {
            get => (int)GetValue(nameof(min_vahicles_adj_Ferry));
            set => SetValue(nameof(min_vahicles_adj_Ferry), value);
        }
        public float waiting_time_weight
        {
            get => (float)GetValue(nameof(waiting_time_weight));
            set => SetValue(nameof(waiting_time_weight), value);
        }
        public float max_adjustable_ongoing_unit
        {
            get => (float)GetValue(nameof(max_adjustable_ongoing_unit));
            set => SetValue(nameof(max_adjustable_ongoing_unit), value);
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
        public bool disable_chirps
        {
            get => (bool)GetValue(nameof(disable_chirps));
            set => SetValue(nameof(disable_chirps), value);
        }
        public float busy_stop_enter_pct
        {
            get => (float)GetValue(nameof(busy_stop_enter_pct));
            set => SetValue(nameof(busy_stop_enter_pct), value);
        }
        public float busy_stop_exit_pct
        {
            get => (float)GetValue(nameof(busy_stop_exit_pct));
            set => SetValue(nameof(busy_stop_exit_pct), value);
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
        //public bool VerboseLogging
        //{
        //    get => (bool)GetValue(nameof(VerboseLogging));
        //    set => SetValue(nameof(VerboseLogging), value);
        //}
    }

    public class SnapToTopographySettings : SettingsBackup
    {
        public bool Toggle
        {
            get => (bool)GetValue(nameof(Toggle));
            set => SetValue(nameof(Toggle), value);
        }
        public int SnapInterval
        {
            get => (int)GetValue(nameof(SnapInterval));
            set => SetValue(nameof(SnapInterval), value);
        }
    }

    public class SpeechFreeRadioSettings : SettingsBackup
    {
        public bool ToggleAllowWeather
        {
            get => (bool)GetValue(nameof(ToggleAllowWeather));
            set => SetValue(nameof(ToggleAllowWeather), value);
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

        //public int RoadFormat
        //{
        //    get => (int)GetValue(nameof(RoadFormat));
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
        public bool DistrictPrefixSeparately
        {
            get => (bool)GetValue(nameof(DistrictPrefixSeparately));
            set => SetValue(nameof(DistrictPrefixSeparately), value);
        }

        //public int DistrictFormat
        //{
        //    get => (int)GetValue(nameof(DistrictFormat));
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
        public bool RoadSource
        {
            get => (bool)GetValue(nameof(RoadSource));
            set => SetValue(nameof(RoadSource), value);
        }
        public bool IntersectionSource
        {
            get => (bool)GetValue(nameof(IntersectionSource));
            set => SetValue(nameof(IntersectionSource), value);
        }
        public bool TransportStationSource
        {
            get => (bool)GetValue(nameof(TransportStationSource));
            set => SetValue(nameof(TransportStationSource), value);
        }
        public bool TransportDepotSource
        {
            get => (bool)GetValue(nameof(TransportDepotSource));
            set => SetValue(nameof(TransportDepotSource), value);
        }
        public bool SchoolSource
        {
            get => (bool)GetValue(nameof(SchoolSource));
            set => SetValue(nameof(SchoolSource), value);
        }
        public bool FireStationSource
        {
            get => (bool)GetValue(nameof(FireStationSource));
            set => SetValue(nameof(FireStationSource), value);
        }
        public bool PoliceStationSource
        {
            get => (bool)GetValue(nameof(PoliceStationSource));
            set => SetValue(nameof(PoliceStationSource), value);
        }
        public bool HospitalSource
        {
            get => (bool)GetValue(nameof(HospitalSource));
            set => SetValue(nameof(HospitalSource), value);
        }
        public bool ParkSource
        {
            get => (bool)GetValue(nameof(ParkSource));
            set => SetValue(nameof(ParkSource), value);
        }
        public bool ElectricitySource
        {
            get => (bool)GetValue(nameof(ElectricitySource));
            set => SetValue(nameof(ElectricitySource), value);
        }
        public bool WaterSource
        {
            get => (bool)GetValue(nameof(WaterSource));
            set => SetValue(nameof(WaterSource), value);
        }
        public bool SewageSource
        {
            get => (bool)GetValue(nameof(SewageSource));
            set => SetValue(nameof(SewageSource), value);
        }
        public bool GarbageSource
        {
            get => (bool)GetValue(nameof(GarbageSource));
            set => SetValue(nameof(GarbageSource), value);
        }
        public bool DisasterSource
        {
            get => (bool)GetValue(nameof(DisasterSource));
            set => SetValue(nameof(DisasterSource), value);
        }
        public bool DeathcareSource
        {
            get => (bool)GetValue(nameof(DeathcareSource));
            set => SetValue(nameof(DeathcareSource), value);
        }
        public bool TelecomSource
        {
            get => (bool)GetValue(nameof(TelecomSource));
            set => SetValue(nameof(TelecomSource), value);
        }
        public bool PostSource
        {
            get => (bool)GetValue(nameof(PostSource));
            set => SetValue(nameof(PostSource), value);
        }
        public bool ParkingSource
        {
            get => (bool)GetValue(nameof(ParkingSource));
            set => SetValue(nameof(ParkingSource), value);
        }
        public bool RoadFacilitySource
        {
            get => (bool)GetValue(nameof(RoadFacilitySource));
            set => SetValue(nameof(RoadFacilitySource), value);
        }
        public bool AdminSource
        {
            get => (bool)GetValue(nameof(AdminSource));
            set => SetValue(nameof(AdminSource), value);
        }
        public bool TransportStopAutoNaming
        {
            get => (bool)GetValue(nameof(TransportStopAutoNaming));
            set => SetValue(nameof(TransportStopAutoNaming), value);
        }
        public int StopNameSourcePriority1
        {
            get => (int)GetValue(nameof(StopNameSourcePriority1));
            set => SetValue(nameof(StopNameSourcePriority1), value);
        }
        public int StopNameSourcePriority2
        {
            get => (int)GetValue(nameof(StopNameSourcePriority2));
            set => SetValue(nameof(StopNameSourcePriority2), value);
        }
        public int StopNameSourcePriority3
        {
            get => (int)GetValue(nameof(StopNameSourcePriority3));
            set => SetValue(nameof(StopNameSourcePriority3), value);
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
        public bool TransportStationAutoNaming
        {
            get => (bool)GetValue(nameof(TransportStationAutoNaming));
            set => SetValue(nameof(TransportStationAutoNaming), value);
        }
        public bool ApplyXfixToTransportStation
        {
            get => (bool)GetValue(nameof(ApplyXfixToTransportStation));
            set => SetValue(nameof(ApplyXfixToTransportStation), value);
        }
        public string TransportStationPrefix
        {
            get => (string)GetValue(nameof(TransportStationPrefix));
            set => SetValue(nameof(TransportStationPrefix), value);
        }
        public string TransportStationSuffix
        {
            get => (string)GetValue(nameof(TransportStationSuffix));
            set => SetValue(nameof(TransportStationSuffix), value);
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
        public float GroundDiffuseLight
        {
            get => (float)GetValue(nameof(GroundDiffuseLight));
            set => SetValue(nameof(GroundDiffuseLight), value);
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

    public class SuperFastBuildingAndLevelingSettings : SettingsBackup
    {
        public bool EnableSuperFastBuild
        {
            get => (bool)GetValue(nameof(EnableSuperFastBuild));
            set => SetValue(nameof(EnableSuperFastBuild), value);
        }
        public bool EnableSuperFastLeveling
        {
            get => (bool)GetValue(nameof(EnableSuperFastLeveling));
            set => SetValue(nameof(EnableSuperFastLeveling), value);
        }
        public bool EnableSuperFastAreaPropSpawning
        {
            get => (bool)GetValue(nameof(EnableSuperFastAreaPropSpawning));
            set => SetValue(nameof(EnableSuperFastAreaPropSpawning), value);
        }
        public bool EnableCustomResidentialDemand
        {
            get => (bool)GetValue(nameof(EnableCustomResidentialDemand));
            set => SetValue(nameof(EnableCustomResidentialDemand), value);
        }
        public int HomeBuildingDemand
        {
            get => (int)GetValue(nameof(HomeBuildingDemand));
            set => SetValue(nameof(HomeBuildingDemand), value);
        }
        public bool EnableCustomCommercialDemand
        {
            get => (bool)GetValue(nameof(EnableCustomCommercialDemand));
            set => SetValue(nameof(EnableCustomCommercialDemand), value);
        }
        public int CommercialBuildingDemand
        {
            get => (int)GetValue(nameof(CommercialBuildingDemand));
            set => SetValue(nameof(CommercialBuildingDemand), value);
        }
        public bool EnableCustomIndustrialDemand
        {
            get => (bool)GetValue(nameof(EnableCustomIndustrialDemand));
            set => SetValue(nameof(EnableCustomIndustrialDemand), value);
        }
        public int IndustrialBuildingDemand
        {
            get => (int)GetValue(nameof(IndustrialBuildingDemand));
            set => SetValue(nameof(IndustrialBuildingDemand), value);
        }
        public bool EnableCustomOfficeDemand
        {
            get => (bool)GetValue(nameof(EnableCustomOfficeDemand));
            set => SetValue(nameof(EnableCustomOfficeDemand), value);
        }
        public int OfficeBuildingDemand
        {
            get => (int)GetValue(nameof(OfficeBuildingDemand));
            set => SetValue(nameof(OfficeBuildingDemand), value);
        }
        public bool Contra
        {
            get => (bool)GetValue(nameof(Contra));
            set => SetValue(nameof(Contra), value);
        }
    }

    public class TimeAndWeatherAnarchySettings : SettingsBackup
    {
        //public int Profiles
        //{
        //    get => (int)GetValue(nameof(Profiles));
        //    set => SetValue(nameof(Profiles), value);
        //}
        //public string SelectedProfile
        //{
        //    get => (string)GetValue(nameof(SelectedProfile));
        //    set => SetValue(nameof(SelectedProfile), value);
        //}
        //public float Time
        //{
        //    get => (float)GetValue(nameof(Time));
        //    set => SetValue(nameof(Time), value);
        //}
        //public float WeatherTime
        //{
        //    get => (float)GetValue(nameof(WeatherTime));
        //    set => SetValue(nameof(WeatherTime), value);
        //}
        //public int Temperature
        //{
        //    get => (int)GetValue(nameof(Temperature));
        //    set => SetValue(nameof(Temperature), value);
        //}
        //public float Fog
        //{
        //    get => (float)GetValue(nameof(Fog));
        //    set => SetValue(nameof(Fog), value);
        //}
        //public float Thunder
        //{
        //    get => (float)GetValue(nameof(Thunder));
        //    set => SetValue(nameof(Thunder), value);
        //}
        //public int TimeOption
        //{
        //    get => (int)GetValue(nameof(TimeOption));
        //    set => SetValue(nameof(TimeOption), value);
        //}
        //public int WeatherOption
        //{
        //    get => (int)GetValue(nameof(WeatherOption));
        //    set => SetValue(nameof(WeatherOption), value);
        //}
        //public bool EnableCustomPrecipitation
        //{
        //    get => (bool)GetValue(nameof(EnableCustomPrecipitation));
        //    set => SetValue(nameof(EnableCustomPrecipitation), value);
        //}
        //public bool EnableCustomTemperature
        //{
        //    get => (bool)GetValue(nameof(EnableCustomTemperature));
        //    set => SetValue(nameof(EnableCustomTemperature), value);
        //}
        //public bool EnableCustomClouds
        //{
        //    get => (bool)GetValue(nameof(EnableCustomClouds));
        //    set => SetValue(nameof(EnableCustomClouds), value);
        //}
        //public bool EnableCustomAurora
        //{
        //    get => (bool)GetValue(nameof(EnableCustomAurora));
        //    set => SetValue(nameof(EnableCustomAurora), value);
        //}
        //public bool EnableCustomFog
        //{
        //    get => (bool)GetValue(nameof(EnableCustomFog));
        //    set => SetValue(nameof(EnableCustomFog), value);
        //}
        //public bool EnableCustomThunder
        //{
        //    get => (bool)GetValue(nameof(EnableCustomThunder));
        //    set => SetValue(nameof(EnableCustomThunder), value);
        //}
        //public float Rainbow
        //{
        //    get => (float)GetValue(nameof(Rainbow));
        //    set => SetValue(nameof(Rainbow), value);
        //}
        //public float Aurora
        //{
        //    get => (float)GetValue(nameof(Aurora));
        //    set => SetValue(nameof(Aurora), value);
        //}
        //public float Clouds
        //{
        //    get => (float)GetValue(nameof(Clouds));
        //    set => SetValue(nameof(Clouds), value);
        //}
        //public float Precipitation
        //{
        //    get => (float)GetValue(nameof(Precipitation));
        //    set => SetValue(nameof(Precipitation), value);
        //}
        //public int DayOfTheYear
        //{
        //    get => (int)GetValue(nameof(DayOfTheYear));
        //    set => SetValue(nameof(DayOfTheYear), value);
        //}
        public float DayStartHour
        {
            get => (float)GetValue(nameof(DayStartHour));
            set => SetValue(nameof(DayStartHour), value);
        }
        public float DayEndHour
        {
            get => (float)GetValue(nameof(DayEndHour));
            set => SetValue(nameof(DayEndHour), value);
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
        public bool HideUIToggle
        {
            get => (bool)GetValue(nameof(HideUIToggle));
            set => SetValue(nameof(HideUIToggle), value);
        }
        public bool UseDaytimeForDarkMode
        {
            get => (bool)GetValue(nameof(UseDaytimeForDarkMode));
            set => SetValue(nameof(UseDaytimeForDarkMode), value);
        }
        public int ColorblindMode
        {
            get => (int)GetValue(nameof(ColorblindMode));
            set => SetValue(nameof(ColorblindMode), value);
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

        //public bool NotGameMode
        //{
        //    get => (bool)GetValue(nameof(NotGameMode));
        //    set => SetValue(nameof(NotGameMode), value);
        //}
        public int PoliceFee
        {
            get => (int)GetValue(nameof(PoliceFee));
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class TrafficLightManagerSettings : SettingsBackup
    {
        //public string m_LocaleOption
        //{
        //    get => (string)GetValue(nameof(m_LocaleOption));
        //    set => SetValue(nameof(m_LocaleOption), value);
        //}
        //public string m_Locale
        //{
        //    get => (string)GetValue(nameof(m_Locale));
        //    set => SetValue(nameof(m_Locale), value);
        //}
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
        public int m_CustomPhaseTemplates
        {
            get => (int)GetValue(nameof(m_CustomPhaseTemplates));
            set => SetValue(nameof(m_CustomPhaseTemplates), value);
        }
        public string m_DefaultCustomPhaseTemplateOption
        {
            get => (string)GetValue(nameof(m_DefaultCustomPhaseTemplateOption));
            set => SetValue(nameof(m_DefaultCustomPhaseTemplateOption), value);
        }
        public int m_DefaultCustomPhaseTemplate
        {
            get => (int)GetValue(nameof(m_DefaultCustomPhaseTemplate));
            set => SetValue(nameof(m_DefaultCustomPhaseTemplate), value);
        }
        public bool m_ForceNodeUpdate
        {
            get => (bool)GetValue(nameof(m_ForceNodeUpdate));
            set => SetValue(nameof(m_ForceNodeUpdate), value);
        }
        public bool m_DisplayCurrentPhase
        {
            get => (bool)GetValue(nameof(m_DisplayCurrentPhase));
            set => SetValue(nameof(m_DisplayCurrentPhase), value);
        }
        public bool m_DisplayCurrentPhaseWhenToolDisabled
        {
            get => (bool)GetValue(nameof(m_DisplayCurrentPhaseWhenToolDisabled));
            set => SetValue(nameof(m_DisplayCurrentPhaseWhenToolDisabled), value);
        }
        public bool m_DisplayTrafficLightGroupNameWhenToolDisabled
        {
            get => (bool)GetValue(nameof(m_DisplayTrafficLightGroupNameWhenToolDisabled));
            set => SetValue(nameof(m_DisplayTrafficLightGroupNameWhenToolDisabled), value);
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
        public string m_Locale
        {
            get => (string)GetValue(nameof(m_Locale));
            set => SetValue(nameof(m_Locale), value);
        }
        public bool m_CompatibilityModeOption
        {
            get => (bool)GetValue(nameof(m_CompatibilityModeOption));
            set => SetValue(nameof(m_CompatibilityModeOption), value);
        }
        public bool m_CompatibilityMode
        {
            get => (bool)GetValue(nameof(m_CompatibilityMode));
            set => SetValue(nameof(m_CompatibilityMode), value);
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
        public bool m_ForceNodeUpdate
        {
            get => (bool)GetValue(nameof(m_ForceNodeUpdate));
            set => SetValue(nameof(m_ForceNodeUpdate), value);
        }
        public string m_ComponentTypeToClear
        {
            get => (string)GetValue(nameof(m_ComponentTypeToClear));
            set => SetValue(nameof(m_ComponentTypeToClear), value);
        }
        //public bool m_SuppressCanaryWarning
        //{
        //    get => (bool)GetValue(nameof(m_SuppressCanaryWarning));
        //    set => SetValue(nameof(m_SuppressCanaryWarning), value);
        //}
        //public int UserPreset
        //{
        //    get => (int)GetValue(nameof(UserPreset));
        //    set => SetValue(nameof(UserPreset), value);
        //}
        //public string Id
        //{
        //    get => (string)GetValue(nameof(Id));
        //    set => SetValue(nameof(Id), value);
        //}
        //public string Name
        //{
        //    get => (string)GetValue(nameof(Name));
        //    set => SetValue(nameof(Name), value);
        //}
        //public ushort MinDuration
        //{
        //    get => (ushort)GetValue(nameof(MinDuration));
        //    set => SetValue(nameof(MinDuration), value);
        //}
        //public ushort MaxDuration
        //{
        //    get => (ushort)GetValue(nameof(MaxDuration));
        //    set => SetValue(nameof(MaxDuration), value);
        //}
        //public float TargetDurationMultiplier
        //{
        //    get => (float)GetValue(nameof(TargetDurationMultiplier));
        //    set => SetValue(nameof(TargetDurationMultiplier), value);
        //}
        //public float IntervalExponent
        //{
        //    get => (float)GetValue(nameof(IntervalExponent));
        //    set => SetValue(nameof(IntervalExponent), value);
        //}
        //public float WaitFlowBalance
        //{
        //    get => (float)GetValue(nameof(WaitFlowBalance));
        //    set => SetValue(nameof(WaitFlowBalance), value);
        //}
        //public int ChangeMetric
        //{
        //    get => (int)GetValue(nameof(ChangeMetric));
        //    set => SetValue(nameof(ChangeMetric), value);
        //}
        //public int m_UserPresets
        //{
        //    get => (int)GetValue(nameof(m_UserPresets));
        //    set => SetValue(nameof(m_UserPresets), value);
        //}
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
    }

    public class TrafficSettingsSettings : SettingsBackup
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
        public bool RemoveUnsafeCrosswalksWithVisualRemoval
        {
            get => (bool)GetValue(nameof(RemoveUnsafeCrosswalksWithVisualRemoval));
            set => SetValue(nameof(RemoveUnsafeCrosswalksWithVisualRemoval), value);
        }
        public bool RemoveCrosswalkByDefault
        {
            get => (bool)GetValue(nameof(RemoveCrosswalkByDefault));
            set => SetValue(nameof(RemoveCrosswalkByDefault), value);
        }
        public bool RemoveInvisibleCrosswalkByDefault
        {
            get => (bool)GetValue(nameof(RemoveInvisibleCrosswalkByDefault));
            set => SetValue(nameof(RemoveInvisibleCrosswalkByDefault), value);
        }
        public bool NewIntersectionsVanilla
        {
            get => (bool)GetValue(nameof(NewIntersectionsVanilla));
            set => SetValue(nameof(NewIntersectionsVanilla), value);
        }
        public bool NewIntersectionsWithoutUTurns
        {
            get => (bool)GetValue(nameof(NewIntersectionsWithoutUTurns));
            set => SetValue(nameof(NewIntersectionsWithoutUTurns), value);
        }
        public bool NewIntersectionsWithoutUnsafe
        {
            get => (bool)GetValue(nameof(NewIntersectionsWithoutUnsafe));
            set => SetValue(nameof(NewIntersectionsWithoutUnsafe), value);
        }
        public bool NewIntersectionsCrosswalks
        {
            get => (bool)GetValue(nameof(NewIntersectionsCrosswalks));
            set => SetValue(nameof(NewIntersectionsCrosswalks), value);
        }
        public bool NewIntersectionsUnsafeCrosswalks
        {
            get => (bool)GetValue(nameof(NewIntersectionsUnsafeCrosswalks));
            set => SetValue(nameof(NewIntersectionsUnsafeCrosswalks), value);
        }
        public int NewIntersectionDefaultsVersion
        {
            get => (int)GetValue(nameof(NewIntersectionDefaultsVersion));
            set => SetValue(nameof(NewIntersectionDefaultsVersion), value);
        }
    }

    public class TrafficSpySettings : SettingsBackup
    {
        public int RouteOpacity
        {
            get => (int)GetValue(nameof(RouteOpacity));
            set => SetValue(nameof(RouteOpacity), value);
        }
        public int MaxVehicleTraffic
        {
            get => (int)GetValue(nameof(MaxVehicleTraffic));
            set => SetValue(nameof(MaxVehicleTraffic), value);
        }
        public int MaxPedestrianTraffic
        {
            get => (int)GetValue(nameof(MaxPedestrianTraffic));
            set => SetValue(nameof(MaxPedestrianTraffic), value);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class TrafficToolEssentialsSettings : SettingsBackup
    {
        //public string m_LocaleOption
        //{
        //    get => (string)GetValue(nameof(m_LocaleOption));
        //    set => SetValue(nameof(m_LocaleOption), value);
        //}
        //public string m_Locale
        //{
        //    get => (string)GetValue(nameof(m_Locale));
        //    set => SetValue(nameof(m_Locale), value);
        //}
        public bool m_ChartSmoothedDefault
        {
            get => (bool)GetValue(nameof(m_ChartSmoothedDefault));
            set => SetValue(nameof(m_ChartSmoothedDefault), value);
        }
        public bool m_CompatibilityModeOption
        {
            get => (bool)GetValue(nameof(m_CompatibilityModeOption));
            set => SetValue(nameof(m_CompatibilityModeOption), value);
        }
        public bool m_CompatibilityMode
        {
            get => (bool)GetValue(nameof(m_CompatibilityMode));
            set => SetValue(nameof(m_CompatibilityMode), value);
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

        //public bool m_DebugLogging
        //{
        //    get => (bool)GetValue(nameof(m_DebugLogging));
        //    set => SetValue(nameof(m_DebugLogging), value);
        //}
        public bool m_DepotZonesEnabled
        {
            get => (bool)GetValue(nameof(m_DepotZonesEnabled));
            set => SetValue(nameof(m_DepotZonesEnabled), value);
        }
        public bool m_ForceNodeUpdate
        {
            get => (bool)GetValue(nameof(m_ForceNodeUpdate));
            set => SetValue(nameof(m_ForceNodeUpdate), value);
        }
        //public bool m_SuppressCanaryWarning
        //{
        //    get => (bool)GetValue(nameof(m_SuppressCanaryWarning));
        //    set => SetValue(nameof(m_SuppressCanaryWarning), value);
        //}
    }

    public class TransitNightSchedulerSettings : SettingsBackup
    {
        public bool EnableNightMode
        {
            get => (bool)GetValue(nameof(EnableNightMode));
            set => SetValue(nameof(EnableNightMode), value);
        }
        public int NightStartHour
        {
            get => (int)GetValue(nameof(NightStartHour));
            set => SetValue(nameof(NightStartHour), value);
        }
        public int NightEndHour
        {
            get => (int)GetValue(nameof(NightEndHour));
            set => SetValue(nameof(NightEndHour), value);
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
        public bool PreserveAge
        {
            get => (bool)GetValue(nameof(PreserveAge));
            set => SetValue(nameof(PreserveAge), value);
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
        public int PreviousAgeSelection
        {
            get => (int)GetValue(nameof(PreviousAgeSelection));
            set => SetValue(nameof(PreviousAgeSelection), value);
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

    public class TreesReduceNoisePollutionSettings : SettingsBackup
    {
        public bool ModEnabled
        {
            get => (bool)GetValue(nameof(ModEnabled));
            set => SetValue(nameof(ModEnabled), value);
        }
        public int TreeNoiseStrength
        {
            get => (int)GetValue(nameof(TreeNoiseStrength));
            set => SetValue(nameof(TreeNoiseStrength), value);
        }
        public int AbsorptionRadius
        {
            get => (int)GetValue(nameof(AbsorptionRadius));
            set => SetValue(nameof(AbsorptionRadius), value);
        }
        public int ReductionMode
        {
            get => (int)GetValue(nameof(ReductionMode));
            set => SetValue(nameof(ReductionMode), value);
        }
        public int UpdateInterval
        {
            get => (int)GetValue(nameof(UpdateInterval));
            set => SetValue(nameof(UpdateInterval), value);
        }
        //public bool VerboseLogging
        //{
        //    get => (bool)GetValue(nameof(VerboseLogging));
        //    set => SetValue(nameof(VerboseLogging), value);
        //}
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE1006:Naming Styles",
        Justification = "<Pending>"
    )]
    public class TripsViewSettings : SettingsBackup
    {
        public int numOutputs
        {
            get => (int)GetValue(nameof(numOutputs));
            set => SetValue(nameof(numOutputs), value);
        }
        public bool saveDuringAutoSaves
        {
            get => (bool)GetValue(nameof(saveDuringAutoSaves));
            set => SetValue(nameof(saveDuringAutoSaves), value);
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
        public float levelUpMaterialFactor
        {
            get => (float)GetValue(nameof(levelUpMaterialFactor));
            set => SetValue(nameof(levelUpMaterialFactor), value);
        }
    }

    public class VehicleControllerSettings : SettingsBackup
    {
        //public int LoggingLevel
        //{
        //    get => (int)GetValue(nameof(LoggingLevel));
        //    set => SetValue(nameof(LoggingLevel), value);
        //}
        //public string CurrentProbabilityPack
        //{
        //    get => (string)GetValue(nameof(CurrentProbabilityPack));
        //    set => SetValue(nameof(CurrentProbabilityPack), value);
        //}
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
        public int TrailerProbability
        {
            get => (int)GetValue(nameof(TrailerProbability));
            set => SetValue(nameof(TrailerProbability), value);
        }
        public bool UseImprovedStiffnessValues
        {
            get => (bool)GetValue(nameof(UseImprovedStiffnessValues));
            set => SetValue(nameof(UseImprovedStiffnessValues), value);
        }
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
        public string DefaultPropertyPackDropdown
        {
            get => (string)GetValue(nameof(DefaultPropertyPackDropdown));
            set => SetValue(nameof(DefaultPropertyPackDropdown), value);
        }
        public string SavegamePropertyPackDropdown
        {
            get => (string)GetValue(nameof(SavegamePropertyPackDropdown));
            set => SetValue(nameof(SavegamePropertyPackDropdown), value);
        }
        public float SavegamePropertyPackFactor
        {
            get => (float)GetValue(nameof(SavegamePropertyPackFactor));
            set => SetValue(nameof(SavegamePropertyPackFactor), value);
        }
        public bool CustomSpeedLimitFactor
        {
            get => (bool)GetValue(nameof(CustomSpeedLimitFactor));
            set => SetValue(nameof(CustomSpeedLimitFactor), value);
        }
        public float SpeedLimitFactor
        {
            get => (float)GetValue(nameof(SpeedLimitFactor));
            set => SetValue(nameof(SpeedLimitFactor), value);
        }
        public bool DisableSpeedLimitUpdate
        {
            get => (bool)GetValue(nameof(DisableSpeedLimitUpdate));
            set => SetValue(nameof(DisableSpeedLimitUpdate), value);
        }
        public string PackName
        {
            get => (string)GetValue(nameof(PackName));
            set => SetValue(nameof(PackName), value);
        }
        public int VehicleMaxSpeed
        {
            get => (int)GetValue(nameof(VehicleMaxSpeed));
            set => SetValue(nameof(VehicleMaxSpeed), value);
        }
        public int VehicleAcceleration
        {
            get => (int)GetValue(nameof(VehicleAcceleration));
            set => SetValue(nameof(VehicleAcceleration), value);
        }
        public int VehicleBraking
        {
            get => (int)GetValue(nameof(VehicleBraking));
            set => SetValue(nameof(VehicleBraking), value);
        }
        public bool EnableChangeVehicles
        {
            get => (bool)GetValue(nameof(EnableChangeVehicles));
            set => SetValue(nameof(EnableChangeVehicles), value);
        }
        public bool DisplayVehiclePrefabNames
        {
            get => (bool)GetValue(nameof(DisplayVehiclePrefabNames));
            set => SetValue(nameof(DisplayVehiclePrefabNames), value);
        }
    }

    public class VehicleVariationPacksSettings : SettingsBackup
    {
        public string PackDropdown
        {
            get => (string)GetValue(nameof(PackDropdown));
            set => SetValue(nameof(PackDropdown), value);
        }
        //public bool ShowDebugPacks
        //{
        //    get => (bool)GetValue(nameof(ShowDebugPacks));
        //    set => SetValue(nameof(ShowDebugPacks), value);
        //}
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
        public bool WaterCausesDamage
        {
            get => (bool)GetValue(nameof(WaterCausesDamage));
            set => SetValue(nameof(WaterCausesDamage), value);
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
        public bool ForceWaterSimulationSpeed
        {
            get => (bool)GetValue(nameof(ForceWaterSimulationSpeed));
            set => SetValue(nameof(ForceWaterSimulationSpeed), value);
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

    public class WetRoadsSettings : SettingsBackup
    {
        public bool Enabled
        {
            get => (bool)GetValue(nameof(Enabled));
            set => SetValue(nameof(Enabled), value);
        }
        public bool DisableInFreezing
        {
            get => (bool)GetValue(nameof(DisableInFreezing));
            set => SetValue(nameof(DisableInFreezing), value);
        }
        public float RainThreshold
        {
            get => (float)GetValue(nameof(RainThreshold));
            set => SetValue(nameof(RainThreshold), value);
        }
        public float RainFullValue
        {
            get => (float)GetValue(nameof(RainFullValue));
            set => SetValue(nameof(RainFullValue), value);
        }
        public float SmoothnessMin
        {
            get => (float)GetValue(nameof(SmoothnessMin));
            set => SetValue(nameof(SmoothnessMin), value);
        }
        public float SmoothnessMax
        {
            get => (float)GetValue(nameof(SmoothnessMax));
            set => SetValue(nameof(SmoothnessMax), value);
        }
    }

    public class WriteEverywhereSettings : SettingsBackup
    {
        //public bool TempDisableRendering
        //{
        //    get => (bool)GetValue(nameof(TempDisableRendering));
        //    set => SetValue(nameof(TempDisableRendering), value);
        //}
        public bool UseVT
        {
            get => (bool)GetValue(nameof(UseVT));
            set => SetValue(nameof(UseVT), value);
        }
        public float RequiredLodForFormulaesUpdate
        {
            get => (float)GetValue(nameof(RequiredLodForFormulaesUpdate));
            set => SetValue(nameof(RequiredLodForFormulaesUpdate), value);
        }
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

    public class ZoneToolsSettings : SettingsBackup
    {
        public bool ProtectOccupiedCells
        {
            get => (bool)GetValue(nameof(ProtectOccupiedCells));
            set => SetValue(nameof(ProtectOccupiedCells), value);
        }
        public bool ProtectZonedCells
        {
            get => (bool)GetValue(nameof(ProtectZonedCells));
            set => SetValue(nameof(ProtectZonedCells), value);
        }
        public bool ShowContourButton
        {
            get => (bool)GetValue(nameof(ShowContourButton));
            set => SetValue(nameof(ShowContourButton), value);
        }
        public bool UseGlassPanel
        {
            get => (bool)GetValue(nameof(UseGlassPanel));
            set => SetValue(nameof(UseGlassPanel), value);
        }
        public int DefaultPanelLocation
        {
            get => (int)GetValue(nameof(DefaultPanelLocation));
            set => SetValue(nameof(DefaultPanelLocation), value);
        }
        public bool ShowUsage
        {
            get => (bool)GetValue(nameof(ShowUsage));
            set => SetValue(nameof(ShowUsage), value);
        }
    }
}
