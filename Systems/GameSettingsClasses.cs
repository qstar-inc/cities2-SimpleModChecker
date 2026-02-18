using System.Collections.Generic;
using Game.Rendering.Utilities;
using Game.UI.Editor;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using static Colossal.IO.AssetDatabase.AssetDatabase;
using static Game.Settings.AntiAliasingQualitySettings;
using static Game.Settings.GeneralSettings;
using static Game.Settings.GraphicsSettings;
using static Game.Settings.InterfaceSettings;
using static Game.Simulation.SimulationSystem;

namespace SimpleModCheckerPlus.Systems
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
        public int PrefabPickerColumnCount { get; set; }
        public int AssetPickerColumnCount { get; set; }
        public int InspectorWidth { get; set; }
        public int HierarchyWidth { get; set; }
        public int AdvisorHeight { get; set; }
        public bool LowQualityTextureCompression { get; set; }
        public Dictionary<string, bool> ShownTutorials { get; set; }
        public Dictionary<
            EditorHierarchyUISystem.ItemType,
            bool
        > ExpandedWorkspaceItems { get; set; }
    }

    public class GameGameplaySettings
    {
        public bool EdgeScrolling { get; set; }
        public float EdgeScrollSensivity { get; set; }
        public bool DayNightVisual { get; set; }
        public bool PausedAfterLoading { get; set; }
        public bool ShowTutorials { get; set; }
        public bool ShowEditorTutorials { get; set; }
    }

    public class GameGeneralSettings
    {
        public AutoReloadMode AssetDatabaseAutoReloadMode { get; set; }
        public PerformancePreference PerformancePreference { get; set; }
        public FPSMode FpsMode { get; set; }
        public bool AutoSave { get; set; }
        public AutoSaveInterval AutoSaveInterval { get; set; }
        public AutoSaveCount AutoSaveCount { get; set; }
        public bool AllowOptionalTelemetry { get; set; }
    }

    public class GameGraphicsSettings
    {
        public int DisplayIndex { get; set; }
        public bool VSync { get; set; }
        public int MaxFrameLatency { get; set; }
        public CursorMode CursorMode { get; set; }
        public Game.Settings.GraphicsSettings.DepthOfFieldMode DepthOfFieldMode { get; set; }
        public float TiltShiftNearStart { get; set; }
        public float TiltShiftNearEnd { get; set; }
        public float TiltShiftFarStart { get; set; }
        public float TiltShiftFarEnd { get; set; }
        public DlssQuality DlssQuality { get; set; }

        //public Fsr2Quality Fsr2Quality { get; set; }
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

        //public GameAnimationQualitySetting GameAnimationQualitySetting { get; set; }
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

    //public class GameAnimationQualitySetting
    //{
    //    public Skinning MaxBoneInfuence { get; set; }
    //}

    public class GameTextureQualitySettings
    {
        public int Mipbias { get; set; }
        public UnityEngine.Rendering.VirtualTexturing.FilterMode FilterMode { get; set; }
    }

    public class GameInputSettings
    {
        public bool ElevationDraggingEnabled { get; set; }
        public bool UseLegacyCamera { get; set; }

        //public string Keybinds { get; set; }
        public float MouseScrollSensitivity { get; set; }
        public float KeyboardMoveSensitivity { get; set; }
        public float KeyboardRotateSensitivity { get; set; }
        public float KeyboardZoomSensitivity { get; set; }
        public float MouseMoveSensitivity { get; set; }
        public float MouseRotateSensitivity { get; set; }
        public float MouseZoomSensitivity { get; set; }
        public bool MouseInvertX { get; set; }
        public bool MouseInvertY { get; set; }
        public float GamepadMoveSensitivity { get; set; }
        public float GamepadRotateSensitivity { get; set; }
        public float GamepadZoomSensitivity { get; set; }
        public bool GamepadInvertX { get; set; }
        public bool GamepadInvertY { get; set; }
    }

    public class GameInterfaceSettings
    {
        public string SavedInterfaceStyle { get; set; }
        public float SavedInterfaceTransparency { get; set; }
        public string CurrentLocale { get; set; }
        public bool UseLegacyInterface { get; set; }
        public string InterfaceStyle { get; set; }
        public float InterfaceTransparency { get; set; }
        public bool InterfaceScaling { get; set; }
        public float TextScale { get; set; }
        public bool UnlockHighlightsEnabled { get; set; }
        public bool ChirperPopupsEnabled { get; set; }
        public bool BlockingPopupsEnabled { get; set; }
        public InputHintsType InputHintsType { get; set; }
        public KeyboardLayout KeyboardLayout { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public UnitSystem UnitSystem { get; set; }
    }

    public class GameUserState
    {
        public bool AutoplayTutorials { get; set; }
        public string LastCloudTarget { get; set; }
        public bool LeftHandTraffic { get; set; }
        public bool NaturalDisasters { get; set; }
        public bool UnlockAll { get; set; }
        public bool UnlimitedMoney { get; set; }
        public bool UnlockMapTiles { get; set; }
        public List<string> SeenWhatsNew { get; set; }
    }
}
