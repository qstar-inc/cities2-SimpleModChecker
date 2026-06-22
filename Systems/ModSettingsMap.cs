internal static class ModSettingsMap
{
    public static bool IsValid(string key) =>
        key switch
        {
            "74285+SceneExplorer.Settings"
            or "74286+FPS_Limiter.FPSLimiterSettings"
            or "74324+MoveIt.Settings.Settings"
            or "74328+FiveTwentyNineTiles.ModSettings"
            or "74535+HistoricalStart.ModSettings"
            or "74539+ImageOverlay.ModSettings"
            or "74604+Anarchy.Settings.AnarchyModSettings"
            or "75249+BrushSizeUnlimiter.MyOptions"
            or "75250+Better_Bulldozer.Settings.BetterBulldozerModSettings"
            or "75426+I18NEverywhere.Setting"
            or "75613+Water_Features.Settings.WaterFeaturesSettings"
            or "75816+LineTool.ModSettings"
            or "75826+PlopTheGrowables.ModSettings"
            or "75862+ExtendedRadio.Setting"
            or "75993+Tree_Controller.Settings.TreeControllerSettings"
            or "76050+MapTextureReplacer.MapTextureReplacerOptions"
            or "76662+EmploymentTracker.EmploymentTrackerSettings"
            or "76849+SunGlasses.Setting"
            or "76908+AutoDistrictNameStations.ModOptions"
            or "76972+CrimeRemover.Setting.CrimeSetting"
            or "77171+Time2Work.Setting"
            or "77240+FindIt.FindItSettings"
            or "77260+WaterVisualTweaksMod.WaterVisualTweaksSettings"
            or "77321+SuperFastBuildingAndLeveling.Setting"
            or "77345+FireStarter.Setting"
            or "77463+RoadNameRemover.Setting"
            or "77923+BetterMoonLight.Setting"
            or "78131+StationNaming.Setting.StationNamingSettings"
            or "78188+ExtendedTooltip.ModSettings"
            or "78601+NoPollution.Setting"
            or "78622+TransportPolicyAdjuster.Setting"
            or "78847+AssetVariationChanger.Setting"
            or "79186+SimpleModCheckerPlus.Setting"
            or "79237+FirstPersonCameraContinued.Setting"
            or "79634+AssetIconLibrary.Setting"
            or "79872+AutoVehicleRenamer.Setting"
            or "80095+Traffic.ModSettings"
            or "80529+ExtraAssetsImporter.Setting"
            or "80931+ToggleableOverlays.Setting"
            or "81012+VehicleVariationPacks.Setting"
            or "81157+AreaBucket.Setting"
            or "81568+ZoneColorChanger.Setting"
            or "82675+DCMilestoneRewards.Setting"
            or "84638+Recolor.Settings.Setting"
            or "85211+NoTrafficDespawn.TrafficDespawnSettings"
            or "85284+CityStats.ModSettings"
            or "86124+TradingCostTweaker.Setting"
            or "86553+NoVehicleTrailers.Setting"
            or "86605+AllAboard.Setting"
            or "86728+BoundaryLinesModifier.Setting"
            or "86868+RealLife.Setting"
            or "86944+DemandMasterControl.Setting"
            or "87190+RoadBuilder.Setting"
            or "87313+RealisticParking.Setting"
            or "87422+OSMExport.Setting"
            or "87428+Carto.Settings"
            or "87755+RealisticWorkplacesAndHouseholds.Setting"
            or "88500+NoDeadTrees.NoDeadTreesSetting"
            or "88893+TimeWeatherAnarchy.TimeWeatherAnarchySettings "
            or "89495+CityController.Settings.Setting"
            or "90264+SmartTransportation.Setting"
            or "90641+HallOfFame.Settings"
            or "91433+InfoLoomTwo.Setting"
            or "92908+BelzontWE.WEModData"
            or "92952+CitizenModelManager.Setting"
            or "93523+NavigationView.Setting"
            or "94394+Lumina.Setting"
            or "94762+BuildingUse.ModSettings"
            or "95437+RegionFlagIcons.Setting"
            or "95872+CameraFieldOfView.Setting"
            or "96619+TripsDataView.Setting"
            or "96718+RoadWearAdjuster.Setting"
            or "97195+ParkingMonitor.Setting"
            or "97381+CityServiceCapacityAdjuster.Setting"
            or "98560+AssetUIManager.Setting"
            or "98771+SpeechFreeRadio.ModSettings.ModSettings"
            or "99048+ResourceLocator.ModSettings"
            or "103983+ShowMoreHappiness.ModSettings"
            or "104707+DetailedDescriptions.Setting"
            or "104781+VehicleController.Setting"
            or "105288+AssetIconCreator.Setting"
            or "105715+DisableAccidents.ModSettings.Setting"
            or "105800+EventsController.Settings.Setting"
            or "107487+SmartUpkeepManager.Setting"
            or "107939+MapExtPDX.ModSettings"
            or "110245+UrbanInequality.Setting"
            or "112452+ParkingPricing.ModSettings"
            or "112978+EvenBetterSaveList.Setting"
            or "113193+BuildingUsageTracker.Setting"
            or "113708+PrefabAssetFixes.Setting"
            or "114101+ChangeCompany.ModSettings"
            or "116595+CustomizableMenu.Setting"
            or "117161+CitizenCleaner.Setting"
            or "120143+crud89.ExtractorsBegone.ModSettings"
            or "121226+RealisticPathFinding.Setting"
            or "121812+CustomChirps.Setting"
            or "122865+RoadWearToolToggle.RoadWearToolToggleSetting"
            or "123345+FindIt.Character.Setting"
            or "123497+MagicHearse.Setting"
            or "123500+RealisticJobSearch.Setting"
            or "123738+AdjustTransit.Setting"
            or "123887+AdjustSchoolCapacity.Setting"
            or "124159+MagicGarbage.Setting"
            or "124304+AdvancedSimulationSpeed.Setting"
            or "124548+GottaGoFast.Setting"
            or "124553+LaClock.ModSettings"
            or "124947+OutsideTrafficAdjuster.Setting"
            or "125278+Platter.Settings.PlatterModSettings"
            or "125342+C2VM.TrafficToolEssentials.Settings"
            or "125343+MagicMail.Setting"
            or "125675+ConfigXML.Setting"
            or "126306+Red_bike_path.Setting"
            or "126355+Road_Precision.Setting"
            or "126468+Colored_Bus_Lane.Setting"
            or "127507+AssetMigrationUtility.Setting"
            or "128269+ZoningToolkit.Setting"
            or "128566+TrafficSpy.ModSettings.ModSettings"
            or "128577+BuildingHeightAndFootprint.ModSettings"
            or "128911+C2VM.TrafficLightsEnhancement.Settings"
            or "129323+CollisionBeGone.Setting"
            or "130383+Realistic_Industrial_Power_Consumption.Setting"
            or "131525+EmergencyGhosts.Setting"
            or "132866+CS2_Clearance.Setting"
            or "133261+ServiceCims.ModSettings"
            or "133736+NetworkTools.Settings.NT_Settings"
            or "134032+ParkingFeeControl.ModSettings"
            or "134067+FastBikes.Setting"
            or "135367+SirenChanger.SirenChangerSettings"
            or "136261+EasyZoning.Setting"
            or "136370+ChirpGPT.Setting"
            or "137149+EconomyEX.Settings.ModSettings"
            or "137401+ExtractorBoost.Setting"
            or "138390+PublicWorksPlus.Setting"
            or "138523+NodeController.Setting"
            or "139487+TrafficLightManager.Code.Settings"
            or "139584+CameraDrag.Setting"
            or "139595+BetterTransitView.ModSettings.ModSettings"
            or "139839+EXRScreenshot.Settings.Setting"
            or "140062+Traffic_Settings.Setting"
            or "141243+CustomizeIt.Setting"
            or "141486+AdvancedTPM.TPMModSettings"
            or "141603+DisableHover.Settings.ModSettings"
            or "141606+CustomRoadSnap.Setting"
            or "141751+LodControl.Setting"
            or "141997+FastBoarding.Setting"
            or "142309+Beyond_Numbers_with_STT.Setting"
            or "142520+RoadConstructionEvents.Setting"
            or "142766+AutomaticBulldozeAndRepair.Setting"
            or "143447+WetRoads.Setting"
            or "143732+TreesReduceNoisePollution.Setting"
            or "143857+FertilityControl.Setting"
            or "144000+SnapToTopography.Setting"
            or "144908+CityWatchdog.Setting"
            or "145021+Area_of_Effect.ModSettings.ModSettings"
            or "145221+AdvancedRoadNaming.Settings.AdvancedRoadNamingSettings"
            or "145605+CityStoryMod.Settings"
            or "145663+SimpleRadio.Settings.ModSettings"
            or "145932+SimpleBrush.Settings.ModSettings"
            or "146044+HoverColors.Settings.HoverColorsSettings"
            or "146160+DisablePlacementSway.Setting"
            or "146817+IntelligentCommodityScheduling.ICSSettings"
            or "147311+CivicVoice.CivicVoiceSettings"
            or "147521+MouseLight.MouseLightSettings"
            or "147630+NightVehiclesMod.ModSettings" => true,
            _ => false,
        };

    public static string GetClassName(string key) =>
        key switch
        {
            "SceneExplorer.Settings+SceneExplorer" => "SceneExplorerSettings",
            "FPS_Limiter.FPSLimiterSettings+FPS_Limiter" => "FPSLimiterSettings",
            "MoveIt.Settings.Settings+MoveIt" => "MoveItSettings",
            "FiveTwentyNineTiles.ModSettings+FiveTwentyNineTiles" => "FiveTwentyNineTilesSettings",
            "HistoricalStart.ModSettings+HistoricalStart" => "HistoricalStartSettings",
            "ImageOverlay.ModSettings+ImageOverlay" => "ImageOverlaySettings",
            "Anarchy.Settings.AnarchyModSettings+Anarchy" => "AnarchySettings",
            "BrushSizeUnlimiter.MyOptions+BrushSizeUnlimiter" => "BrushSizeUnlimiterSettings",
            "Better_Bulldozer.Settings.BetterBulldozerModSettings+BetterBulldozer" =>
                "BetterBulldozerSettings",
            "I18NEverywhere.Setting+I18NEverywhere" => "I18NEverywhereSettings",
            "Water_Features.Settings.WaterFeaturesSettings+Water_Features" =>
                "WaterFeaturesSettings",
            "LineTool.ModSettings+LineTool" => "AdvancedLineToolSettings",
            "PlopTheGrowables.ModSettings+PlopTheGrowables" => "PlopTheGrowablesSettings",
            "ExtendedRadio.Setting+ExtendedRadio" => "ExtendedRadioSettings",
            "Tree_Controller.Settings.TreeControllerSettings+Tree_Controller" =>
                "TreeControllerSettings",
            "MapTextureReplacer.MapTextureReplacerOptions+MapTextureReplacer" =>
                "MapTextureReplacerSettings",
            "EmploymentTracker.EmploymentTrackerSettings+EmploymentTracker" =>
                "CimRouteHighlighterSettings",
            "SunGlasses.Setting+SunGlasses" => "SunGlassesSettings",
            "AutoDistrictNameStations.ModOptions+AutoDistrictNameStations" =>
                "AutoDistrictNameStationsSettings",
            "CrimeRemover.Setting.CrimeSetting+CrimeRemover" => "CrimeRemoverSettings",
            "Time2Work.Setting+Time2Work" => "RealisticTripsSettings",
            "FindIt.FindItSettings+FindIt" => "FindItSettings",
            "WaterVisualTweaksMod.WaterVisualTweaksSettings+WaterVisualTweaks" =>
                "WaterVisualTweaksSettings",
            "SuperFastBuildingAndLeveling.Setting+SuperFastBuildingAndLeveling" =>
                "SuperFastBuildingAndLevelingSettings",
            "FireStarter.Setting+FireStarter" => "FireStarterSettings",
            "RoadNameRemover.Setting+RoadNameRemover" => "RoadNameRemoverSettings",
            "BetterMoonLight.Setting+BetterMoonLight" => "BetterMoonLightSettings",
            "StationNaming.Setting.StationNamingSettings+StationNaming" => "StationNamingSettings",
            "ExtendedTooltip.ModSettings+ExtendedTooltip" => "ExtendedTooltipSettings",
            "NoPollution.Setting+NoPollution" => "NoPollutionSettings",
            "TransportPolicyAdjuster.Setting+TransportPolicyAdjuster" =>
                "TransportPolicyAdjusterSettings",
            "AssetVariationChanger.Setting+AssetVariationChanger" =>
                "AssetVariationChangerSettings",
            "SimpleModCheckerPlus.Setting+SimpleModChecker" => "SimpleModCheckerSettings",
            "FirstPersonCameraContinued.Setting+FirstPersonCameraContinued" =>
                "FirstPersonCameraContinuedSettings",
            "AssetIconLibrary.Setting+AssetIconLibrary" => "AssetIconLibrarySettings",
            "AutoVehicleRenamer.Setting+AutoVehicleRenamer" => "AutoVehicleRenamerSettings",
            "Traffic.ModSettings+Traffic" => "TrafficSettings",
            "ExtraAssetsImporter.Setting+ExtraAssetsImporter" => "ExtraAssetsImporterSettings",
            "ToggleableOverlays.Setting+ToggleableOverlays" => "ToggleOverlaysSettings",
            "VehicleVariationPacks.Setting+VehicleVariationPacks" =>
                "VehicleVariationPacksSettings",
            "AreaBucket.Setting+AreaBucket" => "AreaBucketSettings",
            "ZoneColorChanger.Setting+ZoneColorChanger" => "ZoneColorChangerSettings",
            "DCMilestoneRewards.Setting+DCMilestoneRewards" => "DCMilestoneRewardsSettings",
            "Recolor.Settings.Setting+Recolor" => "RecolorSettings",
            "NoTrafficDespawn.TrafficDespawnSettings+NoTrafficDespawn" =>
                "NoVehicleDespawnSettings",
            "CityStats.ModSettings+CityStats" => "CityStatsSettings",
            "TradingCostTweaker.Setting+TradingCostTweaker" => "TradingCostTweakerSettings",
            "NoVehicleTrailers.Setting+NoVehicleTrailers" => "NoVehicleTrailersSettings",
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
            "NoDeadTrees.NoDeadTreesSetting+NoDeadTrees" => "NoDeadTreesSettings",
            "TimeWeatherAnarchy.TimeWeatherAnarchySettings +TimeWeatherAnarchy" =>
                "TimeAndWeatherAnarchySettings",
            "CityController.Settings.Setting+CityController" => "CityControllerSettings",
            "SmartTransportation.Setting+SmartTransportation" => "SmartTransportationSettings",
            "HallOfFame.Settings+HallOfFame" => "HallOfFameSettings",
            "InfoLoomTwo.Setting+InfoLoomTwo" => "InfoLoomTwoSettings",
            "BelzontWE.WEModData+BelzontWE" => "WriteEverywhereSettings",
            "CitizenModelManager.Setting+CitizenModelManager" => "CitizenModelManagerSettings",
            "NavigationView.Setting+NavigationView" => "NavigationViewSettings",
            "Lumina.Setting+Lumina" => "LuminaSettings",
            "BuildingUse.ModSettings+BuildingUse" => "BuildingUseSettings",
            "RegionFlagIcons.Setting+RegionFlagIcons" => "RegionFlagIconsSettings",
            "CameraFieldOfView.Setting+CameraFieldOfView" => "CameraFieldOfViewSettings",
            "TripsDataView.Setting+TripsDataView" => "TripsViewSettings",
            "RoadWearAdjuster.Setting+RoadWearAdjuster" => "RoadWearAdjusterSettings",
            "ParkingMonitor.Setting+ParkingMonitor" => "ParkingMonitorSettings",
            "CityServiceCapacityAdjuster.Setting+CityServiceCapacityAdjuster" =>
                "CityServiceCapacityAdjusterSettings",
            "AssetUIManager.Setting+AssetUIManager" => "AssetUIManagerSettings",
            "SpeechFreeRadio.ModSettings.ModSettings+SpeechFreeRadio" => "SpeechFreeRadioSettings",
            "ResourceLocator.ModSettings+ResourceLocator" => "ResourceLocatorSettings",
            "ShowMoreHappiness.ModSettings+ShowMoreHappiness" => "ShowMoreHappinessSettings",
            "DetailedDescriptions.Setting+DetailedDescriptions" => "DetailedDescriptionsSettings",
            "VehicleController.Setting+VehicleController" => "VehicleControllerSettings",
            "AssetIconCreator.Setting+AssetIconCreator" => "AssetIconCreatorSettings",
            "DisableAccidents.ModSettings.Setting+DisableAccidents" => "DisableAccidentsSettings",
            "EventsController.Settings.Setting+EventsController" => "EventsControllerSettings",
            "SmartUpkeepManager.Setting+SmartUpkeepManager" => "SmartUpkeepManagerSettings",
            "MapExtPDX.ModSettings+MapExt2" => "MapExtSettings",
            "UrbanInequality.Setting+UrbanInequality" => "UrbanInequalitySettings",
            "ParkingPricing.ModSettings+ParkingPricing" => "ParkingPricingSettings",
            "EvenBetterSaveList.Setting+EvenBetterSaveList" => "EvenBetterSaveListSettings",
            "BuildingUsageTracker.Setting+BuildingUsageTracker" => "BuildingUsageTrackerSettings",
            "PrefabAssetFixes.Setting+PrefabAssetFixes" => "PrefabAssetFixesSettings",
            "ChangeCompany.ModSettings+ChangeCompany" => "ChangeCompanySettings",
            "CustomizableMenu.Setting+CustomizableMenu" => "CustomizableMenuSettings",
            "CitizenCleaner.Setting+CitizenCleaner" => "CitizenCleanerSettings",
            "crud89.ExtractorsBegone.ModSettings+ExtractorsBegone" => "ExtractorsBegoneSettings",
            "RealisticPathFinding.Setting+RealisticPathFinding" => "RealisticPathFindingSettings",
            "CustomChirps.Setting+CustomChirps" => "CustomChirpsSettings",
            "RoadWearToolToggle.RoadWearToolToggleSetting+RoadWearToolToggle" =>
                "RoadWearToolToggleSettings",
            "FindIt.Character.Setting+FindIt.Character" => "FindCharacterSettings",
            "MagicHearse.Setting+MagicHearse" => "MagicHearseSettings",
            "RealisticJobSearch.Setting+RealisticJobSearch" => "RealisticJobSearchSettings",
            "AdjustTransit.Setting+AdjustTransit" => "AdjustTransitSettings",
            "AdjustSchoolCapacity.Setting+AdjustSchoolCapacity" => "AdjustSchoolCapacitySettings",
            "MagicGarbage.Setting+MagicGarbage" => "MagicGarbageSettings",
            "AdvancedSimulationSpeed.Setting+AdvancedSimulationSpeed" =>
                "AdvancedSimulationSpeedSettings",
            "GottaGoFast.Setting+GottaGoFast" => "GottaGoFastSettings",
            "LaClock.ModSettings+LaClock" => "LaClockSettings",
            "OutsideTrafficAdjuster.Setting+OutsideTrafficAdjuster" =>
                "OutsideTrafficAdjusterSettings",
            "Platter.Settings.PlatterModSettings+Platter" => "PlatterSettings",
            "C2VM.TrafficToolEssentials.Settings+C2VM.TrafficToolEssentials" =>
                "TrafficToolEssentialsSettings",
            "MagicMail.Setting+MagicMail" => "MagicMailSettings",
            "ConfigXML.Setting+ConfigXML" => "ConfigXMLSettings",
            "Red_bike_path.Setting+Red_bike_path" => "ColoredBikePathSettings",
            "Road_Precision.Setting+Road_Precision" => "RoadPrecisionSettings",
            "Colored_Bus_Lane.Setting+Colored_Bus_Lane" => "ColoredBusLaneSettings",
            "AssetMigrationUtility.Setting+AssetMigrationUtility" =>
                "AssetMigrationUtilitySettings",
            "ZoningToolkit.Setting+ZoningToolkit" => "ZoneToolsSettings",
            "TrafficSpy.ModSettings.ModSettings+TrafficSpy" => "TrafficSpySettings",
            "BuildingHeightAndFootprint.ModSettings+BuildingHeightAndFootprint" =>
                "BuildingHeightAndFootprintSettings",
            "C2VM.TrafficLightsEnhancement.Settings+C2VM.TrafficLightsEnhancement" =>
                "TrafficLightsEnhancementSettings",
            "CollisionBeGone.Setting+CollisionBeGone" => "CollisionBeGoneSettings",
            "Realistic_Industrial_Power_Consumption.Setting+Realistic_Industrial_Power_Consumption" =>
                "RealisticIndustrialPowerConsumptionSettings",
            "EmergencyGhosts.Setting+EmergencyGhosts" => "EmergencyGhostsSettings",
            "CS2_Clearance.Setting+CS2_Clearance" => "ClearanceHelperSettings",
            "ServiceCims.ModSettings+ServiceCims" => "ServiceCimsSettings",
            "NetworkTools.Settings.NT_Settings+NetworkTools" => "NetworkToolsSettings",
            "ParkingFeeControl.ModSettings+ParkingFeeControl" => "ParkingFeeControlSettings",
            "FastBikes.Setting+FastBikes" => "FastBikesSettings",
            "SirenChanger.SirenChangerSettings+SirenChanger" => "SirenChangerSettings",
            "EasyZoning.Setting+EasyZoning" => "EasyZoningSettings",
            "ChirpGPT.Setting+ChirpGPT" => "ChirpGPTSettings",
            "EconomyEX.Settings.ModSettings+EconomyEX" => "EconomyEXSettings",
            "ExtractorBoost.Setting+ExtractorBoost" => "ExtractorBoostSettings",
            "PublicWorksPlus.Setting+PublicWorksPlus" => "PublicWorksPlusSettings",
            "NodeController.Setting+NodeController" => "NodeControllerSettings",
            "TrafficLightManager.Code.Settings+TrafficLightManager.Code" =>
                "TrafficLightManagerSettings",
            "CameraDrag.Setting+CameraDrag" => "CameraDragSettings",
            "BetterTransitView.ModSettings.ModSettings+BetterTransitView" =>
                "BetterTransitViewSettings",
            "EXRScreenshot.Settings.Setting+EXRScreenshot" => "EXRScreenshotSettings",
            "Traffic_Settings.Setting+Traffic_Settings" => "TrafficSettingsSettings",
            "CustomizeIt.Setting+CustomizeIt" => "CustomTourismSettings",
            "AdvancedTPM.TPMModSettings+AdvancedTPM" => "AdvancedTPMSettings",
            "DisableHover.Settings.ModSettings+DisableHover" => "DisableHoverSettings",
            "CustomRoadSnap.Setting+CustomRoadSnap" => "CustomRoadSnapSettings",
            "LodControl.Setting+LodControl" => "LodControlSettings",
            "FastBoarding.Setting+FastBoarding" => "FastBoardingSettings",
            "Beyond_Numbers_with_STT.Setting+Beyond_Numbers_with_STT" => "BeyondNumbersSettings",
            "RoadConstructionEvents.Setting+RoadConstructionEvents" =>
                "RoadConstructionEventsSettings",
            "AutomaticBulldozeAndRepair.Setting+AutomaticBulldozeAndRepair" =>
                "AutomaticBulldozeAndRepairSettings",
            "WetRoads.Setting+WetRoads" => "WetRoadsSettings",
            "TreesReduceNoisePollution.Setting+TreesReduceNoisePollution" =>
                "TreesReduceNoisePollutionSettings",
            "FertilityControl.Setting+FertilityControl" => "FertilityControlSettings",
            "SnapToTopography.Setting+SnapToTopography" => "SnapToTopographySettings",
            "CityWatchdog.Setting+CityWatchdog" => "CityWatchdogSettings",
            "Area_of_Effect.ModSettings.ModSettings+Area_of_Effect" => "AreaOfEffectSettings",
            "AdvancedRoadNaming.Settings.AdvancedRoadNamingSettings+AdvancedRoadNaming" =>
                "AdvancedRoadNamingSettings",
            "CityStoryMod.Settings+CityStoryMod" => "GhostwriterSettings",
            "SimpleRadio.Settings.ModSettings+SimpleRadio" => "SimpleRadioSettings",
            "SimpleBrush.Settings.ModSettings+SimpleBrush" => "SimpleBrushSettings",
            "HoverColors.Settings.HoverColorsSettings+HoverColors" => "HoverColorsSettings",
            "DisablePlacementSway.Setting+DisablePlacementSway" => "DisablePlacementSwaySettings",
            "IntelligentCommodityScheduling.ICSSettings+IntelligentCommodityScheduling" =>
                "IntelligentCommoditySchedulingSettings",
            "CivicVoice.CivicVoiceSettings+CivicVoice" => "CivicVoiceSettings",
            "MouseLight.MouseLightSettings+MouseLight" => "MouseLightSettings",
            "NightVehiclesMod.ModSettings+NightVehiclesMod" => "TransitNightSchedulerSettings",
            _ => null,
        };
}
