﻿// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.Modding;
using Game.Rendering.Utilities;
using Game.Settings;
using Game;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SimpleModCheckerPlus;
using static Colossal.IO.AssetDatabase.AssetDatabase;
using static Game.Settings.AnimationQualitySettings;
using static Game.Settings.AntiAliasingQualitySettings;
using static Game.Settings.GeneralSettings;
using static Game.Settings.GraphicsSettings;
using static Game.Settings.InterfaceSettings;
using static Game.Simulation.SimulationSystem;
using System.IO;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using Game.PSI;

namespace SimpleModChecker.Systems
{
    public class GameAudioSettings
    {
        public float MasterVolume { get; set; }
        public float UiVolume { get; set; }
        public float MenuVolume { get; set; }
        public float IngameVolume { get; set; }
        public bool RadioActive { get; set; }
        public float RadioVolume { get; set; }
        public float AmbienceVolume { get; set; }
        public float DisastersVolume { get; set; }
        public float WorldVolume { get; set; }
        public float AudioGroupsVolume { get; set; }
        public float ServiceBuildingsVolume { get; set; }
        public int ClipMemoryBudget { get; set; }
    }
    public class GameEditorSettings
    {
        public int AssetPickerColumnCount { get; set; }
        public int InspectorWidth { get; set; }
        public int HierarchyWidth { get; set; }
        public bool UseParallelImport { get; set; }
        public bool LowQualityTextureCompression { get; set; }
        public string LastSelectedProjectRootDirectory { get; set; }
        public string LastSelectedImportDirectory { get; set; }
    }
    public class GameGameplaySettings
    {
        public bool EdgeScrolling { get; set; }
        public bool DayNightVisual { get; set; }
        public bool PausedAfterLoading { get; set; }
        public bool ShowTutorials { get; set; }
    }
    public class GameGeneralSettings
    {
        public AutoReloadMode AssetDatabaseAutoReloadMode { get; set; }
        public PerformancePreference PerformancePreference { get; set; }
        public FPSMode FpsMode { get; set; }
        public bool AutoSave { get; set; }
        public AutoSaveInterval AutoSaveInterval { get; set; }
        public AutoSaveCount AutoSaveCount { get; set; }
    }
    public class GameGraphicsSettings
    {
        public bool VSync { get; set; }
        public int MaxFrameLatency { get; set; }
        public Game.Settings.GraphicsSettings.CursorMode CursorMode { get; set; }
        public Game.Settings.GraphicsSettings.DepthOfFieldMode DepthOfFieldMode { get; set; }
        public float TiltShiftNearStart { get; set; }
        public float TiltShiftNearEnd { get; set; }
        public float TiltShiftFarStart { get; set; }
        public float TiltShiftFarEnd { get; set; }
        public DlssQuality DlssQuality { get; set; }
        public Fsr2Quality Fsr2Quality { get; set; }
        public GameQualitySettings GameQualitySettings { get; set; }
    }
    public class GameQualitySettings
    {
        public GameDynamicResolutionQualitySettings GameDynamicResolutionQualitySettings { get; set; }
        public GameAntiAliasingQualitySettings GameAntiAliasingQualitySettings { get; set; }
        public GameCloudsQualitySettings GameCloudsQualitySettings { get; set; }
        public GameFogQualitySettings GameFogQualitySettings { get; set; }
        public GameVolumetricsQualitySettings GameVolumetricsQualitySettings { get; set; }
        public GameAmbientOcclustionQualitySettings GameAmbientOcclustionQualitySettings { get; set; }
        public GameIlluminationQualitySettings GameIlluminationQualitySettings { get; set; }
        public GameReflectionQualitySettings GameReflectionQualitySettings { get; set; }
        public GameDepthOfFieldQualitySettings GameDepthOfFieldQualitySettings { get; set; }
        public GameMotionBlurQualitySettings GameMotionBlurQualitySettings { get; set; }
        public GameShadowsQualitySettings GameShadowsQualitySettings { get; set; }
        public GameTerrainQualitySettings GameTerrainQualitySettings { get; set; }
        public GameWaterQualitySettings GameWaterQualitySettings { get; set; }
        public GameLevelOfDetailQualitySettings GameLevelOfDetailQualitySettings { get; set; }
        public GameAnimationQualitySetting GameAnimationQualitySetting { get; set; }
        public GameTextureQualitySettings GameTextureQualitySettings { get; set; }
    }

    public class GameDynamicResolutionQualitySettings
    {
        public bool Enabled { get; set; }
        public bool IsAdaptive { get; set; }
        public AdaptiveDynamicResolutionScale.DynResUpscaleFilter UpscaleFilter { get; set; }
        public float MinScale { get; set; }
    }

    public class GameAntiAliasingQualitySettings
    {
        public AntialiasingMethod AntiAliasingMethod { get; set; }
        public HDAdditionalCameraData.SMAAQualityLevel SmaaQuality { get; set; }
        public MSAASamples OutlinesMSAA { get; set; }
    }

    public class GameCloudsQualitySettings
    {
        public bool VolumetricCloudsEnabled { get; set; }
        public bool DistanceCloudsEnabled { get; set; }
        public bool VolumetricCloudsShadows { get; set; }
        public bool DistanceCloudsShadows { get; set; }
    }

    public class GameFogQualitySettings
    {
        public bool Enabled { get; set; }
    }

    public class GameVolumetricsQualitySettings
    {
        public bool Enabled { get; set; }
        public float Budget { get; set; }
        public float ResolutionDepthRatio { get; set; }
    }

    public class GameAmbientOcclustionQualitySettings
    {
        public bool Enabled { get; set; }
        public int MaxPixelRadius { get; set; }
        public bool Fullscreen { get; set; }
        public int StepCount { get; set; }
    }

    public class GameIlluminationQualitySettings
    {
        public bool Enabled { get; set; }
        public bool Fullscreen { get; set; }
        public int RaySteps { get; set; }
        public float DenoiserRadius { get; set; }
        public bool HalfResolutionPass { get; set; }
        public bool SecondDenoiserPass { get; set; }
        public float DepthBufferThickness { get; set; }
    }

    public class GameReflectionQualitySettings
    {
        public bool Enabled { get; set; }
        public bool EnabledTransparent { get; set; }
        public int MaxRaySteps { get; set; }
    }

    public class GameDepthOfFieldQualitySettings
    {
        public bool Enabled { get; set; }
        public int NearSampleCount { get; set; }
        public float NearMaxRadius { get; set; }
        public int FarSampleCount { get; set; }
        public float FarMaxRadius { get; set; }
        public DepthOfFieldResolution Resolution { get; set; }
        public bool HighQualityFiltering { get; set; }
    }

    public class GameMotionBlurQualitySettings
    {
        public bool Enabled { get; set; }
        public int SampleCount { get; set; }
    }

    public class GameShadowsQualitySettings
    {
        public bool Enabled { get; set; }
        public int DirectionalShadowResolution { get; set; }
        public bool TerrainCastShadows { get; set; }
        public float ShadowCullingThresholdHeight { get; set; }
        public float ShadowCullingThresholdVolume { get; set; }
    }

    public class GameTerrainQualitySettings
    {
        public int FinalTessellation { get; set; }
        public int TargetPatchSize { get; set; }
    }

    public class GameWaterQualitySettings
    {
        public bool Waterflow { get; set; }
        public float MaxTessellationFactor { get; set; }
        public float TessellationFactorFadeStart { get; set; }
        public float TessellationFactorFadeRange { get; set; }
    }

    public class GameLevelOfDetailQualitySettings
    {
        public float LevelOfDetail { get; set; }
        public bool LodCrossFade { get; set; }
        public int MaxLightCount { get; set; }
        public int MeshMemoryBudget { get; set; }
        public bool StrictMeshMemory { get; set; }
    }

    public class GameAnimationQualitySetting
    {
        public Skinning MaxBoneInfuence { get; set; }
    }

    public class GameTextureQualitySettings
    {
        public int Mipbias { get; set; }
        public UnityEngine.Rendering.VirtualTexturing.FilterMode FilterMode { get; set; }
    }

    public class GameInputSettings
    {
        public bool ElevationDraggingEnabled { get; set; }
        //public string Keybinds { get; set; }
    }

    public class GameInterfaceSettings
    {
        public string CurrentLocale { get; set; }
        public string InterfaceStyle { get; set; }
        public float InterfaceTransparency { get; set; }
        public bool InterfaceScaling { get; set; }
        public float TextScale { get; set; }
        public bool UnlockHighlightsEnabled { get; set; }
        public bool ChirperPopupsEnabled { get; set; }
        public InputHintsType InputHintsType { get; set; }
        public KeyboardLayout KeyboardLayout { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public UnitSystem UnitSystem { get; set; }
        public bool BlockingPopupsEnabled { get; set; }
    }
    public class GameUserState
    {
        public string LastCloudTarget { get; set; }
        public bool LeftHandTraffic { get; set; }
        public bool NaturalDisasters { get; set; }
        public bool UnlockAll { get; set; }
        public bool UnlimitedMoney { get; set; }
        public bool UnlockMapTiles { get; set; }
    }
    public class GameSettings
    {
        public GameAudioSettings GameAudioSettings { get; set; }
        public GameEditorSettings GameEditorSettings { get; set; }
        public GameGameplaySettings GameGameplaySettings { get; set; }
        public GameGeneralSettings GameGeneralSettings { get; set; }
        public GameGraphicsSettings GameGraphicsSettings { get; set; }
        public GameInputSettings GameInputSettings { get; set; }
        public GameInterfaceSettings GameInterfaceSettings { get; set; }
        public GameUserState GameUserState { get; set; }
    }

    public partial class GameSettingsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModManager modManager = Mod.modManager;
        private readonly string backupFile1 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\GameSettingsBackup_1.json";
        private readonly string backupFile2 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\GameSettingsBackup_2.json";

        protected override void OnCreate()
        {
            if (File.Exists(backupFile1) && Mod.Setting.AutoRestoreSettingBackupOnStartup)
            {
                RestoreBackup(1, false);
                NotificationSystem.Pop("starq-smc-settings-restore",
                        title: Mod.Name,
                        text: $"Auto Restored settings after a crash...",
                        onClicked: () => { },
                        delay: 10f);
            }
            else
            {
                Mod.log.Info("Auto Restore failed, no Backup was found.");
            }
        }

        protected override void OnUpdate()
        {

        }

        public void CreateBackup(int profile)
        {
            string backupFile = profile switch
            {
                1 => backupFile1,
                2 => backupFile2,
                _ => backupFile1,
            };
            Mod.log.Info("Creating Backup");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var GameAudioSettings = new GameAudioSettings
            {
                MasterVolume = SharedSettings.instance.audio.masterVolume,
                UiVolume = SharedSettings.instance.audio.uiVolume,
                MenuVolume = SharedSettings.instance.audio.menuVolume,
                IngameVolume = SharedSettings.instance.audio.ingameVolume,
                RadioActive = SharedSettings.instance.audio.radioActive,
                RadioVolume = SharedSettings.instance.audio.radioVolume,
                AmbienceVolume = SharedSettings.instance.audio.ambienceVolume,
                DisastersVolume = SharedSettings.instance.audio.disastersVolume,
                WorldVolume = SharedSettings.instance.audio.worldVolume,
                AudioGroupsVolume = SharedSettings.instance.audio.audioGroupsVolume,
                ServiceBuildingsVolume = SharedSettings.instance.audio.serviceBuildingsVolume,
                ClipMemoryBudget = SharedSettings.instance.audio.clipMemoryBudget
            };
            var GameEditorSettings = new GameEditorSettings
            {
                AssetPickerColumnCount = SharedSettings.instance.editor.assetPickerColumnCount,
                InspectorWidth = SharedSettings.instance.editor.inspectorWidth,
                HierarchyWidth = SharedSettings.instance.editor.hierarchyWidth,
                UseParallelImport = SharedSettings.instance.editor.useParallelImport,
                LowQualityTextureCompression = SharedSettings.instance.editor.lowQualityTextureCompression,
                LastSelectedProjectRootDirectory = SharedSettings.instance.editor.lastSelectedProjectRootDirectory,
                LastSelectedImportDirectory = SharedSettings.instance.editor.lastSelectedImportDirectory
            };
            var GameGameplaySettings = new GameGameplaySettings
            {
                EdgeScrolling = SharedSettings.instance.gameplay.edgeScrolling,
                DayNightVisual = SharedSettings.instance.gameplay.dayNightVisual,
                PausedAfterLoading = SharedSettings.instance.gameplay.pausedAfterLoading,
                ShowTutorials = SharedSettings.instance.gameplay.showTutorials
            };
            var GameGeneralSettings = new GameGeneralSettings
            {
                AssetDatabaseAutoReloadMode = SharedSettings.instance.general.assetDatabaseAutoReloadMode,
                PerformancePreference = SharedSettings.instance.general.performancePreference,
                FpsMode = SharedSettings.instance.general.fpsMode,
                AutoSave = SharedSettings.instance.general.autoSave,
                AutoSaveInterval = SharedSettings.instance.general.autoSaveInterval,
                AutoSaveCount = SharedSettings.instance.general.autoSaveCount
            };
            var GameDynamicResolutionQualitySettings = new GameDynamicResolutionQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().enabled,
                IsAdaptive = SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().isAdaptive,
                UpscaleFilter = SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().upscaleFilter,
                MinScale = SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().minScale
            };
            var GameAntiAliasingQualitySettings = new GameAntiAliasingQualitySettings
            {
                AntiAliasingMethod = SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().antiAliasingMethod,
                SmaaQuality = SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().smaaQuality,
                OutlinesMSAA = SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().outlinesMSAA
            };
            var GameCloudsQualitySettings = new GameCloudsQualitySettings
            {
                VolumetricCloudsEnabled = SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsEnabled,
                DistanceCloudsEnabled = SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsEnabled,
                VolumetricCloudsShadows = SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsShadows,
                DistanceCloudsShadows = SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsShadows
            };
            var GameFogQualitySettings = new GameFogQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<FogQualitySettings>().enabled,
            };
            var GameVolumetricsQualitySettings = new GameVolumetricsQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().enabled,
                Budget = SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().budget,
                ResolutionDepthRatio = SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().resolutionDepthRatio
            };
            var GameAmbientOcclustionQualitySettings = new GameAmbientOcclustionQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().enabled,
                MaxPixelRadius = SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().maxPixelRadius,
                Fullscreen = SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().fullscreen,
                StepCount = SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().stepCount
            };
            var GameIlluminationQualitySettings = new GameIlluminationQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().enabled,
                Fullscreen = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().fullscreen,
                RaySteps = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().raySteps,
                DenoiserRadius = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().denoiserRadius,
                HalfResolutionPass = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().halfResolutionPass,
                SecondDenoiserPass = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().secondDenoiserPass,
                DepthBufferThickness = SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().depthBufferThickness
            };
            var GameReflectionQualitySettings = new GameReflectionQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().enabled,
                EnabledTransparent = SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().enabledTransparent,
                MaxRaySteps = SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().maxRaySteps
            };
            var GameDepthOfFieldQualitySettings = new GameDepthOfFieldQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().enabled,
                NearSampleCount = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearSampleCount,
                NearMaxRadius = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearMaxRadius,
                FarSampleCount = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farSampleCount,
                FarMaxRadius = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farMaxRadius,
                Resolution = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().resolution,
                HighQualityFiltering = SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().highQualityFiltering
            };
            var GameMotionBlurQualitySettings = new GameMotionBlurQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<MotionBlurQualitySettings>().enabled,
                SampleCount = SharedSettings.instance.graphics.GetQualitySetting<MotionBlurQualitySettings>().sampleCount
            };
            var GameShadowsQualitySettings = new GameShadowsQualitySettings
            {
                Enabled = SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().enabled,
                TerrainCastShadows = SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().terrainCastShadows,
                DirectionalShadowResolution = SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().directionalShadowResolution,
                ShadowCullingThresholdHeight = SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdHeight,
                ShadowCullingThresholdVolume = SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdVolume
            };
            var GameTerrainQualitySettings = new GameTerrainQualitySettings
            {
                FinalTessellation = SharedSettings.instance.graphics.GetQualitySetting<TerrainQualitySettings>().finalTessellation,
                TargetPatchSize = SharedSettings.instance.graphics.GetQualitySetting<TerrainQualitySettings>().targetPatchSize
            };
            var GameWaterQualitySettings = new GameWaterQualitySettings
            {
                Waterflow = SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().waterflow,
                MaxTessellationFactor = SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().maxTessellationFactor,
                TessellationFactorFadeStart = SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeStart,
                TessellationFactorFadeRange = SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeRange
            };
            var GameLevelOfDetailQualitySettings = new GameLevelOfDetailQualitySettings
            {
                LevelOfDetail = SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().levelOfDetail,
                LodCrossFade = SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().lodCrossFade,
                MaxLightCount = SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().maxLightCount,
                MeshMemoryBudget = SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().meshMemoryBudget,
                StrictMeshMemory = SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().strictMeshMemory
            };
            var GameAnimationQualitySetting = new GameAnimationQualitySetting
            {
                MaxBoneInfuence = SharedSettings.instance.graphics.GetQualitySetting<AnimationQualitySettings>().maxBoneInfuence
            };
            var GameTextureQualitySettings = new GameTextureQualitySettings
            {
                Mipbias = SharedSettings.instance.graphics.GetQualitySetting<TextureQualitySettings>().mipbias,
                FilterMode = SharedSettings.instance.graphics.GetQualitySetting<TextureQualitySettings>().filterMode
            };

            var GameQualitySettings = new GameQualitySettings()
            {
                GameDynamicResolutionQualitySettings = GameDynamicResolutionQualitySettings,
                GameAntiAliasingQualitySettings = GameAntiAliasingQualitySettings,
                GameCloudsQualitySettings = GameCloudsQualitySettings,
                GameFogQualitySettings = GameFogQualitySettings,
                GameVolumetricsQualitySettings = GameVolumetricsQualitySettings,
                GameAmbientOcclustionQualitySettings = GameAmbientOcclustionQualitySettings,
                GameIlluminationQualitySettings = GameIlluminationQualitySettings,
                GameReflectionQualitySettings = GameReflectionQualitySettings,
                GameDepthOfFieldQualitySettings = GameDepthOfFieldQualitySettings,
                GameMotionBlurQualitySettings = GameMotionBlurQualitySettings,
                GameShadowsQualitySettings = GameShadowsQualitySettings,
                GameTerrainQualitySettings = GameTerrainQualitySettings,
                GameWaterQualitySettings = GameWaterQualitySettings,
                GameLevelOfDetailQualitySettings = GameLevelOfDetailQualitySettings,
                GameAnimationQualitySetting = GameAnimationQualitySetting,
                GameTextureQualitySettings = GameTextureQualitySettings
            };
            Mod.log.Info("Ok");
            var GameGraphicsSettings = new GameGraphicsSettings()
            {
                VSync = SharedSettings.instance.graphics.vSync,
                MaxFrameLatency = SharedSettings.instance.graphics.maxFrameLatency,
                CursorMode = SharedSettings.instance.graphics.cursorMode,
                DepthOfFieldMode = SharedSettings.instance.graphics.depthOfFieldMode,
                TiltShiftNearStart = SharedSettings.instance.graphics.tiltShiftNearStart,
                TiltShiftNearEnd = SharedSettings.instance.graphics.tiltShiftNearEnd,
                TiltShiftFarStart = SharedSettings.instance.graphics.tiltShiftFarStart,
                TiltShiftFarEnd = SharedSettings.instance.graphics.tiltShiftFarEnd,
                DlssQuality = SharedSettings.instance.graphics.dlssQuality,
                Fsr2Quality = SharedSettings.instance.graphics.fsr2Quality,
                GameQualitySettings = GameQualitySettings
            }; Mod.log.Info("Ok2");
            Mod.log.Info(SharedSettings.instance.keybinding.ToString());
            Mod.log.Info("OkX");
            var GameInputSettings = new GameInputSettings
            {
                ElevationDraggingEnabled = SharedSettings.instance.input.elevationDraggingEnabled,
                //Keybinds = SharedSettings.instance.keybinding.bindings.ToJSONString()
            };
            var GameInterfaceSettings = new GameInterfaceSettings
            {
                CurrentLocale = SharedSettings.instance.userInterface.currentLocale,
                InterfaceStyle = SharedSettings.instance.userInterface.interfaceStyle,
                InterfaceTransparency = SharedSettings.instance.userInterface.interfaceTransparency,
                InterfaceScaling = SharedSettings.instance.userInterface.interfaceScaling,
                TextScale = SharedSettings.instance.userInterface.textScale,
                UnlockHighlightsEnabled = SharedSettings.instance.userInterface.unlockHighlightsEnabled,
                ChirperPopupsEnabled = SharedSettings.instance.userInterface.chirperPopupsEnabled,
                InputHintsType = SharedSettings.instance.userInterface.inputHintsType,
                KeyboardLayout = SharedSettings.instance.userInterface.keyboardLayout,
                TimeFormat = SharedSettings.instance.userInterface.timeFormat,
                TemperatureUnit = SharedSettings.instance.userInterface.temperatureUnit,
                UnitSystem = SharedSettings.instance.userInterface.unitSystem,
                BlockingPopupsEnabled = SharedSettings.instance.userInterface.blockingPopupsEnabled
            };
            var GameUserState = new GameUserState
            {
                LastCloudTarget = SharedSettings.instance.userState.lastCloudTarget,
                LeftHandTraffic = SharedSettings.instance.userState.leftHandTraffic,
                NaturalDisasters = SharedSettings.instance.userState.naturalDisasters,
                UnlockAll = SharedSettings.instance.userState.unlockAll,
                UnlimitedMoney = SharedSettings.instance.userState.unlimitedMoney,
                UnlockMapTiles = SharedSettings.instance.userState.unlockMapTiles
            };

            var GameSettings = new GameSettings
            {
                GameAudioSettings = GameAudioSettings,
                GameEditorSettings = GameEditorSettings,
                GameGameplaySettings = GameGameplaySettings,
                GameGeneralSettings = GameGeneralSettings,
                GameGraphicsSettings = GameGraphicsSettings,
                GameInputSettings = GameInputSettings,
                GameInterfaceSettings = GameInterfaceSettings,
                GameUserState = GameUserState
            };

            string jsonString = JsonConvert.SerializeObject(GameSettings, Formatting.Indented);
            File.WriteAllText(backupFile, jsonString);
        }

        public void RestoreBackup(int profile, bool log = true)
        {
            string backupFile = profile switch
            {
                1 => backupFile1,
                2 => backupFile2,
                _ => backupFile1,
            };
            if (!File.Exists(backupFile))
            {
                Mod.log.Error("Trying to Restore Backup, when Backup file is not found.");
            }

            Mod.log.Info("Restoring Backup");
            string jsonString = File.ReadAllText(backupFile);

            JObject jsonObject = JObject.Parse(jsonString);

            if (jsonObject["GameAudioSettings"] != null)
            {
                GameAudioSettings GameAudioSettings = jsonObject["GameAudioSettings"].ToObject<GameAudioSettings>();
                if (jsonObject["GameAudioSettings"]["MasterVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.masterVolume'=> '{GameAudioSettings.MasterVolume}'");
                    SharedSettings.instance.audio.masterVolume = GameAudioSettings.MasterVolume;
                }
                if (jsonObject["GameAudioSettings"]["UiVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.uiVolume'=> '{GameAudioSettings.UiVolume}'");
                    SharedSettings.instance.audio.uiVolume = GameAudioSettings.UiVolume;
                }
                if (jsonObject["GameAudioSettings"]["MenuVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.menuVolume'=> '{GameAudioSettings.MenuVolume}'");
                    SharedSettings.instance.audio.menuVolume = GameAudioSettings.MenuVolume;
                }
                if (jsonObject["GameAudioSettings"]["IngameVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.ingameVolume'=> '{GameAudioSettings.IngameVolume}'");
                    SharedSettings.instance.audio.ingameVolume = GameAudioSettings.IngameVolume;
                }
                if (jsonObject["GameAudioSettings"]["RadioActive"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.radioActive'=> '{GameAudioSettings.RadioActive}'");
                    SharedSettings.instance.audio.radioActive = GameAudioSettings.RadioActive;
                }
                if (jsonObject["GameAudioSettings"]["RadioVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.radioVolume'=> '{GameAudioSettings.RadioVolume}'");
                    SharedSettings.instance.audio.radioVolume = GameAudioSettings.RadioVolume;
                }
                if (jsonObject["GameAudioSettings"]["AmbienceVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.ambienceVolume'=> '{GameAudioSettings.AmbienceVolume}'");
                    SharedSettings.instance.audio.ambienceVolume = GameAudioSettings.AmbienceVolume;
                }
                if (jsonObject["GameAudioSettings"]["DisastersVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.disastersVolume'=> '{GameAudioSettings.DisastersVolume}'");
                    SharedSettings.instance.audio.disastersVolume = GameAudioSettings.DisastersVolume;
                }
                if (jsonObject["GameAudioSettings"]["WorldVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.worldVolume'=> '{GameAudioSettings.WorldVolume}'");
                    SharedSettings.instance.audio.worldVolume = GameAudioSettings.WorldVolume;
                }
                if (jsonObject["GameAudioSettings"]["AudioGroupsVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.audioGroupsVolume'=> '{GameAudioSettings.AudioGroupsVolume}'");
                    SharedSettings.instance.audio.audioGroupsVolume = GameAudioSettings.AudioGroupsVolume;
                }
                if (jsonObject["GameAudioSettings"]["ServiceBuildingsVolume"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.serviceBuildingsVolume'=> '{GameAudioSettings.ServiceBuildingsVolume}'");
                    SharedSettings.instance.audio.serviceBuildingsVolume = GameAudioSettings.ServiceBuildingsVolume;
                }
                if (jsonObject["GameAudioSettings"]["ClipMemoryBudget"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'audio.clipMemoryBudget'=> '{GameAudioSettings.ClipMemoryBudget}'");
                    SharedSettings.instance.audio.clipMemoryBudget = GameAudioSettings.ClipMemoryBudget;
                }
            }

            if (jsonObject["GameEditorSettings"] != null)
            {
                GameEditorSettings GameEditorSettings = jsonObject["GameEditorSettings"].ToObject<GameEditorSettings>();
                if (jsonObject["GameEditorSettings"]["AssetPickerColumnCount"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.assetPickerColumnCount'=> '{GameEditorSettings.AssetPickerColumnCount}'");
                    SharedSettings.instance.editor.assetPickerColumnCount = GameEditorSettings.AssetPickerColumnCount;
                }
                if (jsonObject["GameEditorSettings"]["InspectorWidth"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.inspectorWidth'=> '{GameEditorSettings.InspectorWidth}'");
                    SharedSettings.instance.editor.inspectorWidth = GameEditorSettings.InspectorWidth;
                }
                if (jsonObject["GameEditorSettings"]["HierarchyWidth"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.hierarchyWidth'=> '{GameEditorSettings.HierarchyWidth}'");
                    SharedSettings.instance.editor.hierarchyWidth = GameEditorSettings.HierarchyWidth;
                }
                if (jsonObject["GameEditorSettings"]["UseParallelImport"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.useParallelImport'=> '{GameEditorSettings.UseParallelImport}'");
                    SharedSettings.instance.editor.useParallelImport = GameEditorSettings.UseParallelImport;
                }
                if (jsonObject["GameEditorSettings"]["LowQualityTextureCompression"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.lowQualityTextureCompression'=> '{GameEditorSettings.LowQualityTextureCompression}'");
                    SharedSettings.instance.editor.lowQualityTextureCompression = GameEditorSettings.LowQualityTextureCompression;
                }
                if (jsonObject["GameEditorSettings"]["LastSelectedProjectRootDirectory"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.lastSelectedProjectRootDirectory'=> '{GameEditorSettings.LastSelectedProjectRootDirectory}'");
                    SharedSettings.instance.editor.lastSelectedProjectRootDirectory = GameEditorSettings.LastSelectedProjectRootDirectory;
                }
                if (jsonObject["GameEditorSettings"]["LastSelectedImportDirectory"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'editor.lastSelectedImportDirectory'=> '{GameEditorSettings.LastSelectedImportDirectory}'");
                    SharedSettings.instance.editor.lastSelectedImportDirectory = GameEditorSettings.LastSelectedImportDirectory;
                }
            }

            if (jsonObject["GameGameplaySettings"] != null)
            {
                GameGameplaySettings GameGameplaySettings = jsonObject["GameGameplaySettings"].ToObject<GameGameplaySettings>();
                if (jsonObject["GameGameplaySettings"]["EdgeScrolling"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'gameplay.edgeScrolling'=> '{GameGameplaySettings.EdgeScrolling}'");
                    SharedSettings.instance.gameplay.edgeScrolling = GameGameplaySettings.EdgeScrolling;
                }
                if (jsonObject["GameGameplaySettings"]["DayNightVisual"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'gameplay.dayNightVisual'=> '{GameGameplaySettings.DayNightVisual}'");
                    SharedSettings.instance.gameplay.dayNightVisual = GameGameplaySettings.DayNightVisual;
                }
                if (jsonObject["GameGameplaySettings"]["PausedAfterLoading"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'gameplay.pausedAfterLoading'=> '{GameGameplaySettings.PausedAfterLoading}'");
                    SharedSettings.instance.gameplay.pausedAfterLoading = GameGameplaySettings.PausedAfterLoading;
                }
                if (jsonObject["GameGameplaySettings"]["ShowTutorials"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'gameplay.showTutorials'=> '{GameGameplaySettings.ShowTutorials}'");
                    SharedSettings.instance.gameplay.showTutorials = GameGameplaySettings.ShowTutorials;
                }
            }

            if (jsonObject["GameGeneralSettings"] != null)
            {
                GameGeneralSettings GameGeneralSettings = jsonObject["GameGeneralSettings"].ToObject<GameGeneralSettings>();
                if (jsonObject["GameGeneralSettings"]["AssetDatabaseAutoReloadMode"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.assetDatabaseAutoReloadMode'=> '{GameGeneralSettings.AssetDatabaseAutoReloadMode}'");
                    SharedSettings.instance.general.assetDatabaseAutoReloadMode = GameGeneralSettings.AssetDatabaseAutoReloadMode;
                }
                if (jsonObject["GameGeneralSettings"]["PerformancePreference"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.performancePreference'=> '{GameGeneralSettings.PerformancePreference}'");
                    SharedSettings.instance.general.performancePreference = GameGeneralSettings.PerformancePreference;
                }
                if (jsonObject["GameGeneralSettings"]["FpsMode"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.fpsMode'=> '{GameGeneralSettings.FpsMode}'");
                    SharedSettings.instance.general.fpsMode = GameGeneralSettings.FpsMode;
                }
                if (jsonObject["GameGeneralSettings"]["AutoSave"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.autoSave'=> '{GameGeneralSettings.AutoSave}'");
                    SharedSettings.instance.general.autoSave = GameGeneralSettings.AutoSave;
                }
                if (jsonObject["GameGeneralSettings"]["AutoSaveInterval"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.autoSaveInterval'=> '{GameGeneralSettings.AutoSaveInterval}'");
                    SharedSettings.instance.general.autoSaveInterval = GameGeneralSettings.AutoSaveInterval;
                }
                if (jsonObject["GameGeneralSettings"]["AutoSaveCount"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'general.autoSaveCount'=> '{GameGeneralSettings.AutoSaveCount}'");
                    SharedSettings.instance.general.autoSaveCount = GameGeneralSettings.AutoSaveCount;
                }
            }

            if (jsonObject["GameGraphicsSettings"] != null)
            {
                GameGraphicsSettings GameGraphicsSettings = jsonObject["GameGraphicsSettings"].ToObject<GameGraphicsSettings>();
                if (jsonObject["GameGraphicsSettings"]["VSync"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.vSync'=> '{GameGraphicsSettings.VSync}'");
                    SharedSettings.instance.graphics.vSync = GameGraphicsSettings.VSync;
                }
                if (jsonObject["GameGraphicsSettings"]["MaxFrameLatency"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.maxFrameLatency'=> '{GameGraphicsSettings.MaxFrameLatency}'");
                    SharedSettings.instance.graphics.maxFrameLatency = GameGraphicsSettings.MaxFrameLatency;
                }
                if (jsonObject["GameGraphicsSettings"]["CursorMode"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.cursorMode'=> '{GameGraphicsSettings.CursorMode}'");
                    SharedSettings.instance.graphics.cursorMode = GameGraphicsSettings.CursorMode;
                }
                if (jsonObject["GameGraphicsSettings"]["DepthOfFieldMode"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.depthOfFieldMode'=> '{GameGraphicsSettings.DepthOfFieldMode}'");
                    SharedSettings.instance.graphics.depthOfFieldMode = GameGraphicsSettings.DepthOfFieldMode;
                }
                if (jsonObject["GameGraphicsSettings"]["TiltShiftNearStart"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.tiltShiftNearStart'=> '{GameGraphicsSettings.TiltShiftNearStart}'");
                    SharedSettings.instance.graphics.tiltShiftNearStart = GameGraphicsSettings.TiltShiftNearStart;
                }
                if (jsonObject["GameGraphicsSettings"]["TiltShiftNearEnd"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.tiltShiftNearEnd'=> '{GameGraphicsSettings.TiltShiftNearEnd}'");
                    SharedSettings.instance.graphics.tiltShiftNearEnd = GameGraphicsSettings.TiltShiftNearEnd;
                }
                if (jsonObject["GameGraphicsSettings"]["TiltShiftFarStart"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.tiltShiftFarStart'=> '{GameGraphicsSettings.TiltShiftFarStart}'");
                    SharedSettings.instance.graphics.tiltShiftFarStart = GameGraphicsSettings.TiltShiftFarStart;
                }
                if (jsonObject["GameGraphicsSettings"]["TiltShiftFarEnd"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.tiltShiftFarEnd'=> '{GameGraphicsSettings.TiltShiftFarEnd}'");
                    SharedSettings.instance.graphics.tiltShiftFarEnd = GameGraphicsSettings.TiltShiftFarEnd;
                }
                if (jsonObject["GameGraphicsSettings"]["DlssQuality"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.dlssQuality'=> '{GameGraphicsSettings.DlssQuality}'");
                    SharedSettings.instance.graphics.dlssQuality = GameGraphicsSettings.DlssQuality;
                }
                if (jsonObject["GameGraphicsSettings"]["Fsr2Quality"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'graphics.fsr2Quality'=> '{GameGraphicsSettings.Fsr2Quality}'");
                    SharedSettings.instance.graphics.fsr2Quality = GameGraphicsSettings.Fsr2Quality;
                }
                if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"] != null)
                {
                    GameDynamicResolutionQualitySettings GameDynamicResolutionQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDynamicResolutionQualitySettings"].ToObject<GameDynamicResolutionQualitySettings>();
                    GameAntiAliasingQualitySettings GameAntiAliasingQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAntiAliasingQualitySettings"].ToObject<GameAntiAliasingQualitySettings>();
                    GameCloudsQualitySettings GameCloudsQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameCloudsQualitySettings"].ToObject<GameCloudsQualitySettings>();
                    GameFogQualitySettings GameFogQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameFogQualitySettings"].ToObject<GameFogQualitySettings>();
                    GameVolumetricsQualitySettings GameVolumetricsQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameVolumetricsQualitySettings"].ToObject<GameVolumetricsQualitySettings>();
                    GameAmbientOcclustionQualitySettings GameAmbientOcclustionQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"].ToObject<GameAmbientOcclustionQualitySettings>();
                    GameIlluminationQualitySettings GameIlluminationQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"].ToObject<GameIlluminationQualitySettings>();
                    GameReflectionQualitySettings GameReflectionQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameReflectionQualitySettings"].ToObject<GameReflectionQualitySettings>();
                    GameDepthOfFieldQualitySettings GameDepthOfFieldQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"].ToObject<GameDepthOfFieldQualitySettings>();
                    GameMotionBlurQualitySettings GameMotionBlurQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameMotionBlurQualitySettings"].ToObject<GameMotionBlurQualitySettings>();
                    GameShadowsQualitySettings GameShadowsQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"].ToObject<GameShadowsQualitySettings>();
                    GameTerrainQualitySettings GameTerrainQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTerrainQualitySettings"].ToObject<GameTerrainQualitySettings>();
                    GameWaterQualitySettings GameWaterQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameWaterQualitySettings"].ToObject<GameWaterQualitySettings>();
                    GameLevelOfDetailQualitySettings GameLevelOfDetailQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"].ToObject<GameLevelOfDetailQualitySettings>();
                    GameAnimationQualitySetting GameAnimationQualitySetting = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAnimationQualitySetting"].ToObject<GameAnimationQualitySetting>();
                    GameTextureQualitySettings GameTextureQualitySettings = jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTextureQualitySettings"].ToObject<GameTextureQualitySettings>();

                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDynamicResolutionQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().enabled'=> '{GameDynamicResolutionQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().enabled = GameDynamicResolutionQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDynamicResolutionQualitySettings"]["IsAdaptive"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().isAdaptive'=> '{GameDynamicResolutionQualitySettings.IsAdaptive}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().isAdaptive = GameDynamicResolutionQualitySettings.IsAdaptive;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDynamicResolutionQualitySettings"]["UpscaleFilter"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().upscaleFilter'=> '{GameDynamicResolutionQualitySettings.UpscaleFilter}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().upscaleFilter = GameDynamicResolutionQualitySettings.UpscaleFilter;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDynamicResolutionQualitySettings"]["MinScale"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().minScale'=> '{GameDynamicResolutionQualitySettings.MinScale}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>().minScale = GameDynamicResolutionQualitySettings.MinScale;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAntiAliasingQualitySettings"]["AntiAliasingMethod"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().antiAliasingMethod'=> '{GameAntiAliasingQualitySettings.AntiAliasingMethod}'");
                        SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().antiAliasingMethod = GameAntiAliasingQualitySettings.AntiAliasingMethod;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAntiAliasingQualitySettings"]["SmaaQuality"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().smaaQuality'=> '{GameAntiAliasingQualitySettings.SmaaQuality}'");
                        SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().smaaQuality = GameAntiAliasingQualitySettings.SmaaQuality;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAntiAliasingQualitySettings"]["OutlinesMSAA"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().outlinesMSAA'=> '{GameAntiAliasingQualitySettings.OutlinesMSAA}'");
                        SharedSettings.instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>().outlinesMSAA = GameAntiAliasingQualitySettings.OutlinesMSAA;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameCloudsQualitySettings"]["VolumetricCloudsEnabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsEnabled'=> '{GameCloudsQualitySettings.VolumetricCloudsEnabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsEnabled = GameCloudsQualitySettings.VolumetricCloudsEnabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameCloudsQualitySettings"]["DistanceCloudsEnabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsEnabled'=> '{GameCloudsQualitySettings.DistanceCloudsEnabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsEnabled = GameCloudsQualitySettings.DistanceCloudsEnabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameCloudsQualitySettings"]["VolumetricCloudsShadows"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsShadows'=> '{GameCloudsQualitySettings.VolumetricCloudsShadows}'");
                        SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsShadows = GameCloudsQualitySettings.VolumetricCloudsShadows;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameCloudsQualitySettings"]["DistanceCloudsShadows"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsShadows'=> '{GameCloudsQualitySettings.DistanceCloudsShadows}'");
                        SharedSettings.instance.graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsShadows = GameCloudsQualitySettings.DistanceCloudsShadows;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameFogQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<FogQualitySettings>().enabled'=> '{GameFogQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<FogQualitySettings>().enabled = GameFogQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameVolumetricsQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().enabled'=> '{GameVolumetricsQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().enabled = GameVolumetricsQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameVolumetricsQualitySettings"]["Budget"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().budget'=> '{GameVolumetricsQualitySettings.Budget}'");
                        SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().budget = GameVolumetricsQualitySettings.Budget;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameVolumetricsQualitySettings"]["ResolutionDepthRatio"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().resolutionDepthRatio'=> '{GameVolumetricsQualitySettings.ResolutionDepthRatio}'");
                        SharedSettings.instance.graphics.GetQualitySetting<VolumetricsQualitySettings>().resolutionDepthRatio = GameVolumetricsQualitySettings.ResolutionDepthRatio;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().enabled'=> '{GameAmbientOcclustionQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().enabled = GameAmbientOcclustionQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"]["MaxPixelRadius"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().maxPixelRadius'=> '{GameAmbientOcclustionQualitySettings.MaxPixelRadius}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().maxPixelRadius = GameAmbientOcclustionQualitySettings.MaxPixelRadius;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"]["Fullscreen"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().fullscreen'=> '{GameAmbientOcclustionQualitySettings.Fullscreen}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().fullscreen = GameAmbientOcclustionQualitySettings.Fullscreen;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"]["StepCount"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().stepCount'=> '{GameAmbientOcclustionQualitySettings.StepCount}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSAOQualitySettings>().stepCount = GameAmbientOcclustionQualitySettings.StepCount;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().enabled'=> '{GameIlluminationQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().enabled = GameIlluminationQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["Fullscreen"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().fullscreen'=> '{GameIlluminationQualitySettings.Fullscreen}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().fullscreen = GameIlluminationQualitySettings.Fullscreen;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["RaySteps"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().raySteps'=> '{GameIlluminationQualitySettings.RaySteps}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().raySteps = GameIlluminationQualitySettings.RaySteps;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["DenoiserRadius"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().denoiserRadius'=> '{GameIlluminationQualitySettings.DenoiserRadius}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().denoiserRadius = GameIlluminationQualitySettings.DenoiserRadius;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["HalfResolutionPass"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().halfResolutionPass'=> '{GameIlluminationQualitySettings.HalfResolutionPass}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().halfResolutionPass = GameIlluminationQualitySettings.HalfResolutionPass;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["SecondDenoiserPass"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().secondDenoiserPass'=> '{GameIlluminationQualitySettings.SecondDenoiserPass}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().secondDenoiserPass = GameIlluminationQualitySettings.SecondDenoiserPass;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameIlluminationQualitySettings"]["DepthBufferThickness"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().depthBufferThickness'=> '{GameIlluminationQualitySettings.DepthBufferThickness}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSGIQualitySettings>().depthBufferThickness = GameIlluminationQualitySettings.DepthBufferThickness;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameReflectionQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().enabled'=> '{GameReflectionQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().enabled = GameReflectionQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameReflectionQualitySettings"]["EnabledTransparent"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().enabledTransparent'=> '{GameReflectionQualitySettings.EnabledTransparent}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().enabledTransparent = GameReflectionQualitySettings.EnabledTransparent;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameReflectionQualitySettings"]["MaxRaySteps"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().maxRaySteps'=> '{GameReflectionQualitySettings.MaxRaySteps}'");
                        SharedSettings.instance.graphics.GetQualitySetting<SSRQualitySettings>().maxRaySteps = GameReflectionQualitySettings.MaxRaySteps;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().enabled'=> '{GameDepthOfFieldQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().enabled = GameDepthOfFieldQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["NearSampleCount"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearSampleCount'=> '{GameDepthOfFieldQualitySettings.NearSampleCount}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearSampleCount = GameDepthOfFieldQualitySettings.NearSampleCount;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["NearMaxRadius"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearMaxRadius'=> '{GameDepthOfFieldQualitySettings.NearMaxRadius}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearMaxRadius = GameDepthOfFieldQualitySettings.NearMaxRadius;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["FarSampleCount"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farSampleCount'=> '{GameDepthOfFieldQualitySettings.FarSampleCount}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farSampleCount = GameDepthOfFieldQualitySettings.FarSampleCount;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["FarMaxRadius"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farMaxRadius'=> '{GameDepthOfFieldQualitySettings.FarMaxRadius}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farMaxRadius = GameDepthOfFieldQualitySettings.FarMaxRadius;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["Resolution"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().resolution'=> '{GameDepthOfFieldQualitySettings.Resolution}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().resolution = GameDepthOfFieldQualitySettings.Resolution;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]["HighQualityFiltering"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().highQualityFiltering'=> '{GameDepthOfFieldQualitySettings.HighQualityFiltering}'");
                        SharedSettings.instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>().highQualityFiltering = GameDepthOfFieldQualitySettings.HighQualityFiltering;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameMotionBlurQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<MotionBlurQualitySettings>().enabled'=> '{GameMotionBlurQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<MotionBlurQualitySettings>().enabled = GameMotionBlurQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameMotionBlurQualitySettings"]["SampleCount"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<MotionBlurQualitySettings>().sampleCount'=> '{GameMotionBlurQualitySettings.SampleCount}'");
                        SharedSettings.instance.graphics.GetQualitySetting<MotionBlurQualitySettings>().sampleCount = GameMotionBlurQualitySettings.SampleCount;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"]["Enabled"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().enabled'=> '{GameShadowsQualitySettings.Enabled}'");
                        SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().enabled = GameShadowsQualitySettings.Enabled;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"]["TerrainCastShadows"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().terrainCastShadows'=> '{GameShadowsQualitySettings.TerrainCastShadows}'");
                        SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().terrainCastShadows = GameShadowsQualitySettings.TerrainCastShadows;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"]["DirectionalShadowResolution"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().directionalShadowResolution'=> '{GameShadowsQualitySettings.DirectionalShadowResolution}'");
                        SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().directionalShadowResolution = GameShadowsQualitySettings.DirectionalShadowResolution;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"]["ShadowCullingThresholdHeight"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdHeight'=> '{GameShadowsQualitySettings.ShadowCullingThresholdHeight}'");
                        SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdHeight = GameShadowsQualitySettings.ShadowCullingThresholdHeight;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameShadowsQualitySettings"]["ShadowCullingThresholdVolume"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdVolume'=> '{GameShadowsQualitySettings.ShadowCullingThresholdVolume}'");
                        SharedSettings.instance.graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdVolume = GameShadowsQualitySettings.ShadowCullingThresholdVolume;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTerrainQualitySettings"]["FinalTessellation"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<TerrainQualitySettings>().finalTessellation'=> '{GameTerrainQualitySettings.FinalTessellation}'");
                        SharedSettings.instance.graphics.GetQualitySetting<TerrainQualitySettings>().finalTessellation = GameTerrainQualitySettings.FinalTessellation;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTerrainQualitySettings"]["TargetPatchSize"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<TerrainQualitySettings>().targetPatchSize'=> '{GameTerrainQualitySettings.TargetPatchSize}'");
                        SharedSettings.instance.graphics.GetQualitySetting<TerrainQualitySettings>().targetPatchSize = GameTerrainQualitySettings.TargetPatchSize;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameWaterQualitySettings"]["Waterflow"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().waterflow'=> '{GameWaterQualitySettings.Waterflow}'");
                        SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().waterflow = GameWaterQualitySettings.Waterflow;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameWaterQualitySettings"]["MaxTessellationFactor"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().maxTessellationFactor'=> '{GameWaterQualitySettings.MaxTessellationFactor}'");
                        SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().maxTessellationFactor = GameWaterQualitySettings.MaxTessellationFactor;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameWaterQualitySettings"]["TessellationFactorFadeStart"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeStart'=> '{GameWaterQualitySettings.TessellationFactorFadeStart}'");
                        SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeStart = GameWaterQualitySettings.TessellationFactorFadeStart;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameWaterQualitySettings"]["TessellationFactorFadeRange"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeRange'=> '{GameWaterQualitySettings.TessellationFactorFadeRange}'");
                        SharedSettings.instance.graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeRange = GameWaterQualitySettings.TessellationFactorFadeRange;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]["LevelOfDetail"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().levelOfDetail'=> '{GameLevelOfDetailQualitySettings.LevelOfDetail}'");
                        SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().levelOfDetail = GameLevelOfDetailQualitySettings.LevelOfDetail;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]["LodCrossFade"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().lodCrossFade'=> '{GameLevelOfDetailQualitySettings.LodCrossFade}'");
                        SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().lodCrossFade = GameLevelOfDetailQualitySettings.LodCrossFade;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]["MaxLightCount"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().maxLightCount'=> '{GameLevelOfDetailQualitySettings.MaxLightCount}'");
                        SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().maxLightCount = GameLevelOfDetailQualitySettings.MaxLightCount;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]["MeshMemoryBudget"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().meshMemoryBudget'=> '{GameLevelOfDetailQualitySettings.MeshMemoryBudget}'");
                        SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().meshMemoryBudget = GameLevelOfDetailQualitySettings.MeshMemoryBudget;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]["StrictMeshMemory"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().strictMeshMemory'=> '{GameLevelOfDetailQualitySettings.StrictMeshMemory}'");
                        SharedSettings.instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>().strictMeshMemory = GameLevelOfDetailQualitySettings.StrictMeshMemory;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameAnimationQualitySetting"]["MaxBoneInfuence"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<AnimationQualitySettings>().maxBoneInfuence'=> '{GameAnimationQualitySetting.MaxBoneInfuence}'");
                        SharedSettings.instance.graphics.GetQualitySetting<AnimationQualitySettings>().maxBoneInfuence = GameAnimationQualitySetting.MaxBoneInfuence;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTextureQualitySettings"]["Mipbias"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<TextureQualitySettings>().mipbias'=> '{GameTextureQualitySettings.Mipbias}'");
                        SharedSettings.instance.graphics.GetQualitySetting<TextureQualitySettings>().mipbias = GameTextureQualitySettings.Mipbias;
                    }
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"]["GameTextureQualitySettings"]["FilterMode"] != null)
                    {
                        if (log) Mod.log.Info($"Restoring 'graphics.GetQualitySetting<TextureQualitySettings>().filterMode'=> '{GameTextureQualitySettings.FilterMode}'");
                        SharedSettings.instance.graphics.GetQualitySetting<TextureQualitySettings>().filterMode = GameTextureQualitySettings.FilterMode;
                    }

                }
            }

            if (jsonObject["GameInputSettings"] != null)
            {
                GameInputSettings GameInputSettings = jsonObject["GameInputSettings"].ToObject<GameInputSettings>();

                if (jsonObject["GameInputSettings"]["ElevationDraggingEnabled"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'input.elevationDraggingEnabled'=> '{GameInputSettings.ElevationDraggingEnabled}'");
                    SharedSettings.instance.input.elevationDraggingEnabled = GameInputSettings.ElevationDraggingEnabled;
                }
                //if (jsonObject["GameInputSettings"]["Keybinds"] != null)
                //{
                //    SharedSettings.instance.keybinding.bindings = JsonConvert.DeserializeObject<List<ProxyBinding>>(jsonObject["GameInputSettings"]["Keybinds"].ToString());
                //}
            }

            if (jsonObject["GameInterfaceSettings"] != null)
            {
                GameInterfaceSettings GameInterfaceSettings = jsonObject["GameInterfaceSettings"].ToObject<GameInterfaceSettings>();

                if (jsonObject["GameInterfaceSettings"]["CurrentLocale"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.currentLocale'=> '{GameInterfaceSettings.CurrentLocale}'");
                    SharedSettings.instance.userInterface.currentLocale = GameInterfaceSettings.CurrentLocale;
                }
                if (jsonObject["GameInterfaceSettings"]["InterfaceStyle"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.interfaceStyle'=> '{GameInterfaceSettings.InterfaceStyle}'");
                    SharedSettings.instance.userInterface.interfaceStyle = GameInterfaceSettings.InterfaceStyle;
                }
                if (jsonObject["GameInterfaceSettings"]["InterfaceTransparency"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.interfaceTransparency'=> '{GameInterfaceSettings.InterfaceTransparency}'");
                    SharedSettings.instance.userInterface.interfaceTransparency = GameInterfaceSettings.InterfaceTransparency;
                }
                if (jsonObject["GameInterfaceSettings"]["InterfaceScaling"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.interfaceScaling'=> '{GameInterfaceSettings.InterfaceScaling}'");
                    SharedSettings.instance.userInterface.interfaceScaling = GameInterfaceSettings.InterfaceScaling;
                }
                if (jsonObject["GameInterfaceSettings"]["TextScale"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.textScale'=> '{GameInterfaceSettings.TextScale}'");
                    SharedSettings.instance.userInterface.textScale = GameInterfaceSettings.TextScale;
                }
                if (jsonObject["GameInterfaceSettings"]["UnlockHighlightsEnabled"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.unlockHighlightsEnabled'=> '{GameInterfaceSettings.UnlockHighlightsEnabled}'");
                    SharedSettings.instance.userInterface.unlockHighlightsEnabled = GameInterfaceSettings.UnlockHighlightsEnabled;
                }
                if (jsonObject["GameInterfaceSettings"]["ChirperPopupsEnabled"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.chirperPopupsEnabled'=> '{GameInterfaceSettings.ChirperPopupsEnabled}'");
                    SharedSettings.instance.userInterface.chirperPopupsEnabled = GameInterfaceSettings.ChirperPopupsEnabled;
                }
                if (jsonObject["GameInterfaceSettings"]["InputHintsType"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.inputHintsType'=> '{GameInterfaceSettings.InputHintsType}'");
                    SharedSettings.instance.userInterface.inputHintsType = GameInterfaceSettings.InputHintsType;
                }
                if (jsonObject["GameInterfaceSettings"]["KeyboardLayout"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.keyboardLayout'=> '{GameInterfaceSettings.KeyboardLayout}'");
                    SharedSettings.instance.userInterface.keyboardLayout = GameInterfaceSettings.KeyboardLayout;
                }
                if (jsonObject["GameInterfaceSettings"]["TimeFormat"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.timeFormat'=> '{GameInterfaceSettings.TimeFormat}'");
                    SharedSettings.instance.userInterface.timeFormat = GameInterfaceSettings.TimeFormat;
                }
                if (jsonObject["GameInterfaceSettings"]["TemperatureUnit"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.temperatureUnit'=> '{GameInterfaceSettings.TemperatureUnit}'");
                    SharedSettings.instance.userInterface.temperatureUnit = GameInterfaceSettings.TemperatureUnit;
                }
                if (jsonObject["GameInterfaceSettings"]["UnitSystem"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.unitSystem'=> '{GameInterfaceSettings.UnitSystem}'");
                    SharedSettings.instance.userInterface.unitSystem = GameInterfaceSettings.UnitSystem;
                }
                if (jsonObject["GameInterfaceSettings"]["BlockingPopupsEnabled"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userInterface.blockingPopupsEnabled'=> '{GameInterfaceSettings.BlockingPopupsEnabled}'");
                    SharedSettings.instance.userInterface.blockingPopupsEnabled = GameInterfaceSettings.BlockingPopupsEnabled;
                }
            }

            if (jsonObject["GameInputSettings"] != null)
            {
                GameUserState GameUserState = jsonObject["GameUserState"].ToObject<GameUserState>();

                if (jsonObject["GameUserState"]["lastCloudTarget"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.lastCloudTarget'=> '{GameUserState.LastCloudTarget}'");
                    SharedSettings.instance.userState.lastCloudTarget = GameUserState.LastCloudTarget;
                }
                if (jsonObject["GameUserState"]["leftHandTraffic"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.leftHandTraffic'=> '{GameUserState.LeftHandTraffic}'");
                    SharedSettings.instance.userState.leftHandTraffic = GameUserState.LeftHandTraffic;
                }
                if (jsonObject["GameUserState"]["naturalDisasters"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.naturalDisasters'=> '{GameUserState.NaturalDisasters}'");
                    SharedSettings.instance.userState.naturalDisasters = GameUserState.NaturalDisasters;
                }
                if (jsonObject["GameUserState"]["unlockAll"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.unlockAll'=> '{GameUserState.UnlockAll}'");
                    SharedSettings.instance.userState.unlockAll = GameUserState.UnlockAll;
                }
                if (jsonObject["GameUserState"]["unlimitedMoney"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.unlimitedMoney'=> '{GameUserState.UnlimitedMoney}'");
                    SharedSettings.instance.userState.unlimitedMoney = GameUserState.UnlimitedMoney;
                }
                if (jsonObject["GameUserState"]["unlockMapTiles"] != null)
                {
                    if (log) Mod.log.Info($"Restoring 'userState.unlockMapTiles'=> '{GameUserState.UnlockMapTiles}'");
                    SharedSettings.instance.userState.unlockMapTiles = GameUserState.UnlockMapTiles;
                }
            }
            Mod.log.Info("Restoration Complete...");
        }
    }
}