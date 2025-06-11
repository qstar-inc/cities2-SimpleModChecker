// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.Collections.Generic;
using System.IO;
using Colossal.PSI.Common;
using Colossal.PSI.Environment;
using Game;
using Game.PSI;
using Game.Settings;
using Game.UI.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleModCheckerPlus.Systems
{
    public partial class GameSettingsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModCheckup SMC = new();
        private readonly List<string> loadedMods = SMC.GetLoadedMods();
        private readonly string backupFile0 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_prev.json";
        private readonly string backupFile1 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_1.json";
        private readonly string backupFile2 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_2.json";
        private readonly string backupFile3 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_3.json";
        private readonly string backupFile4 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_4.json";
        private readonly string backupFile5 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_5.json";
        private readonly string backupFile6 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_6.json";
        private readonly string backupFile7 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_7.json";
        private readonly string backupFile8 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_8.json";
        private readonly string backupFile9 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\GameSettingsBackup_9.json";
        private static int i = 0;

        protected override void OnCreate()
        {
            base.OnCreate();
            if (Mod.Setting.AutoRestoreSettingBackupOnStartup)
            {
                if (File.Exists(backupFile1))
                {
                    string currentGameVersion = Game.Version.current.version;
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
                                        "GameVersion",
                                        out JToken BackupGameVersion
                                    )
                                    || BackupGameVersion == null
                                )
                                {
                                    SendGameUpdateNotification(currentGameVersion, "null");
                                }
                                else
                                {
                                    if (BackupGameVersion.ToString() != currentGameVersion)
                                    {
                                        SendGameUpdateNotification(
                                            currentGameVersion,
                                            BackupGameVersion.ToString()
                                        );
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Mod.log.Info(ex);
                        }
                    }
                    CreateBackup(0, false);
                    if (!File.ReadAllText(backupFile0).Equals(File.ReadAllText(backupFile1)))
                    {
                        RestoreBackup(1, false);
                    }
                    else
                    {
                        Mod.log.Info("Nothing to restore");
                    }
                }
                else
                {
                    Mod.log.Info("Auto Restore failed, no Backup was found.");
                }
            }
            else
            {
                Mod.log.Info("Auto Restore is disabled...");
            }
        }

        protected override void OnUpdate() { }

        private void SendGameUpdateNotification(string current, string prev)
        {
            //var validVersions = new HashSet<string> { "2.2.4", "2.2.5", "2.2.6", "2.2.7" };
            //if (validVersions.Contains(current) && (prev == "2.2.3" || validVersions.Contains(prev)))
            //{
            //    return;
            //}
            Mod.log.Info($"Game version mismatch. Current: {current}, Backup: {prev}");
            NotificationSystem.Push(
                "starq-smc-game-settings-update",
                title: LocalizedString.Id(
                    "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeGameBackup]"
                ),
                text: LocalizedString.Id(
                    "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeGameBackup]"
                ),
                progressState: ProgressState.Warning,
                onClicked: () => CreateBackup(1)
            );
        }

        public void CreateBackup(int profile, bool log = true)
        {
            if (profile == 1)
            {
                NotificationSystem.Pop(
                    "starq-smc-game-settings-update",
                    delay: 1f,
                    text: LocalizedString.Id(
                        "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.Working]"
                    )
                );
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
            Mod.log.Info($"Creating Game Settings Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                if (log)
                    Mod.log.Info("ModsData folder not found, creating...");
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
                ClipMemoryBudget = SharedSettings.instance.audio.clipMemoryBudget,
            };
            if (log)
                Mod.log.Info("Collecting GameAudioSettings");
            var GameEditorSettings = new GameEditorSettings
            {
                AssetPickerColumnCount = SharedSettings.instance.editor.assetPickerColumnCount,
                InspectorWidth = SharedSettings.instance.editor.inspectorWidth,
                HierarchyWidth = SharedSettings.instance.editor.hierarchyWidth,
                UseParallelImport = SharedSettings.instance.editor.useParallelImport,
                LowQualityTextureCompression = SharedSettings
                    .instance
                    .editor
                    .lowQualityTextureCompression,
                LastSelectedProjectRootDirectory = SharedSettings
                    .instance
                    .editor
                    .lastSelectedProjectRootDirectory,
                LastSelectedImportDirectory = SharedSettings
                    .instance
                    .editor
                    .lastSelectedImportDirectory,
            };
            if (log)
                Mod.log.Info("Collecting GameEditorSettings");
            var GameGameplaySettings = new GameGameplaySettings
            {
                EdgeScrolling = SharedSettings.instance.gameplay.edgeScrolling,
                EdgeScrollSensivity = SharedSettings.instance.gameplay.edgeScrollingSensitivity,
                DayNightVisual = SharedSettings.instance.gameplay.dayNightVisual,
                PausedAfterLoading = SharedSettings.instance.gameplay.pausedAfterLoading,
                ShowTutorials = SharedSettings.instance.gameplay.showTutorials,
            };
            if (log)
                Mod.log.Info("Collecting GameGameplaySettings");
            var GameGeneralSettings = new GameGeneralSettings
            {
                AssetDatabaseAutoReloadMode = SharedSettings
                    .instance
                    .general
                    .assetDatabaseAutoReloadMode,
                PerformancePreference = SharedSettings.instance.general.performancePreference,
                FpsMode = SharedSettings.instance.general.fpsMode,
                AutoSave = SharedSettings.instance.general.autoSave,
                AutoSaveInterval = SharedSettings.instance.general.autoSaveInterval,
                AutoSaveCount = SharedSettings.instance.general.autoSaveCount,
                AllowOptionalTelemetry = SharedSettings.instance.general.allowOptionalTelemetry,
            };
            if (log)
                Mod.log.Info("Collecting GameGeneralSettings");
            var GameDynamicResolutionQualitySettings = new GameDynamicResolutionQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                    .enabled,
                IsAdaptive = SharedSettings
                    .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                    .isAdaptive,
                UpscaleFilter = SharedSettings
                    .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                    .upscaleFilter,
                MinScale = SharedSettings
                    .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                    .minScale,
            };
            if (log)
                Mod.log.Info("Collecting GameDynamicResolutionQualitySettings");
            var GameAntiAliasingQualitySettings = new GameAntiAliasingQualitySettings
            {
                AntiAliasingMethod = SharedSettings
                    .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                    .antiAliasingMethod,
                SmaaQuality = SharedSettings
                    .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                    .smaaQuality,
                OutlinesMSAA = SharedSettings
                    .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                    .outlinesMSAA,
            };
            if (log)
                Mod.log.Info("Collecting GameAntiAliasingQualitySettings");
            var GameCloudsQualitySettings = new GameCloudsQualitySettings
            {
                VolumetricCloudsEnabled = SharedSettings
                    .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                    .volumetricCloudsEnabled,
                DistanceCloudsEnabled = SharedSettings
                    .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                    .distanceCloudsEnabled,
                VolumetricCloudsShadows = SharedSettings
                    .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                    .volumetricCloudsShadows,
                DistanceCloudsShadows = SharedSettings
                    .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                    .distanceCloudsShadows,
            };
            if (log)
                Mod.log.Info("Collecting GameCloudsQualitySettings");
            var GameFogQualitySettings = new GameFogQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<FogQualitySettings>()
                    .enabled,
            };
            if (log)
                Mod.log.Info("Collecting GameFogQualitySettings");
            var GameVolumetricsQualitySettings = new GameVolumetricsQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                    .enabled,
                Budget = SharedSettings
                    .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                    .budget,
                ResolutionDepthRatio = SharedSettings
                    .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                    .resolutionDepthRatio,
            };
            if (log)
                Mod.log.Info("Collecting GameVolumetricsQualitySettings");
            var GameAmbientOcclustionQualitySettings = new GameAmbientOcclustionQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                    .enabled,
                MaxPixelRadius = SharedSettings
                    .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                    .maxPixelRadius,
                Fullscreen = SharedSettings
                    .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                    .fullscreen,
                StepCount = SharedSettings
                    .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                    .stepCount,
            };
            if (log)
                Mod.log.Info("Collecting GameAmbientOcclustionQualitySettings");
            var GameIlluminationQualitySettings = new GameIlluminationQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .enabled,
                Fullscreen = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .fullscreen,
                RaySteps = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .raySteps,
                DenoiserRadius = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .denoiserRadius,
                HalfResolutionPass = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .halfResolutionPass,
                SecondDenoiserPass = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .secondDenoiserPass,
                DepthBufferThickness = SharedSettings
                    .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                    .depthBufferThickness,
            };
            if (log)
                Mod.log.Info("Collecting GameIlluminationQualitySettings");
            var GameReflectionQualitySettings = new GameReflectionQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                    .enabled,
                EnabledTransparent = SharedSettings
                    .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                    .enabledTransparent,
                MaxRaySteps = SharedSettings
                    .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                    .maxRaySteps,
            };
            if (log)
                Mod.log.Info("Collecting GameReflectionQualitySettings");
            var GameDepthOfFieldQualitySettings = new GameDepthOfFieldQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .enabled,
                NearSampleCount = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .nearSampleCount,
                NearMaxRadius = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .nearMaxRadius,
                FarSampleCount = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .farSampleCount,
                FarMaxRadius = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .farMaxRadius,
                Resolution = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .resolution,
                HighQualityFiltering = SharedSettings
                    .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                    .highQualityFiltering,
            };
            if (log)
                Mod.log.Info("Collecting GameDepthOfFieldQualitySettings");
            var GameMotionBlurQualitySettings = new GameMotionBlurQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                    .enabled,
                SampleCount = SharedSettings
                    .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                    .sampleCount,
            };
            if (log)
                Mod.log.Info("Collecting GameMotionBlurQualitySettings");
            var GameShadowsQualitySettings = new GameShadowsQualitySettings
            {
                Enabled = SharedSettings
                    .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                    .enabled,
                TerrainCastShadows = SharedSettings
                    .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                    .terrainCastShadows,
                DirectionalShadowResolution = SharedSettings
                    .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                    .directionalShadowResolution,
                ShadowCullingThresholdHeight = SharedSettings
                    .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                    .shadowCullingThresholdHeight,
                ShadowCullingThresholdVolume = SharedSettings
                    .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                    .shadowCullingThresholdVolume,
            };
            if (log)
                Mod.log.Info("Collecting GameShadowsQualitySettings");
            var GameTerrainQualitySettings = new GameTerrainQualitySettings
            {
                FinalTessellation = SharedSettings
                    .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                    .finalTessellation,
                TargetPatchSize = SharedSettings
                    .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                    .targetPatchSize,
            };
            if (log)
                Mod.log.Info("Collecting GameTerrainQualitySettings");
            var GameWaterQualitySettings = new GameWaterQualitySettings
            {
                Waterflow = SharedSettings
                    .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                    .waterflow,
                MaxTessellationFactor = SharedSettings
                    .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                    .maxTessellationFactor,
                TessellationFactorFadeStart = SharedSettings
                    .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                    .tessellationFactorFadeStart,
                TessellationFactorFadeRange = SharedSettings
                    .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                    .tessellationFactorFadeRange,
            };
            if (log)
                Mod.log.Info("Collecting GameWaterQualitySettings");
            var GameLevelOfDetailQualitySettings = new GameLevelOfDetailQualitySettings
            {
                LevelOfDetail = SharedSettings
                    .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                    .levelOfDetail,
                LodCrossFade = SharedSettings
                    .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                    .lodCrossFade,
                MaxLightCount = SharedSettings
                    .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                    .maxLightCount,
                MeshMemoryBudget = SharedSettings
                    .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                    .meshMemoryBudget,
                StrictMeshMemory = SharedSettings
                    .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                    .strictMeshMemory,
            };
            if (log)
                Mod.log.Info("Collecting GameLevelOfDetailQualitySettings");
            var GameAnimationQualitySetting = new GameAnimationQualitySetting
            {
                MaxBoneInfuence = SharedSettings
                    .instance.graphics.GetQualitySetting<AnimationQualitySettings>()
                    .maxBoneInfuence,
            };
            if (log)
                Mod.log.Info("Collecting GameAnimationQualitySetting");
            var GameTextureQualitySettings = new GameTextureQualitySettings
            {
                Mipbias = SharedSettings
                    .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                    .mipbias,
                FilterMode = SharedSettings
                    .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                    .filterMode,
            };
            if (log)
                Mod.log.Info("Collecting GameTextureQualitySettings");
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
                GameTextureQualitySettings = GameTextureQualitySettings,
            };
            if (log)
                Mod.log.Info("Collecting GameQualitySettings");
            var GameGraphicsSettings = new GameGraphicsSettings()
            {
                DisplayIndex = SharedSettings.instance.graphics.displayIndex,
                VSync = SharedSettings.instance.graphics.vSync,
                MaxFrameLatency = SharedSettings.instance.graphics.maxFrameLatency,
                CursorMode = SharedSettings.instance.graphics.cursorMode,
                DepthOfFieldMode = SharedSettings.instance.graphics.depthOfFieldMode,
                TiltShiftNearStart = SharedSettings.instance.graphics.tiltShiftNearStart,
                TiltShiftNearEnd = SharedSettings.instance.graphics.tiltShiftNearEnd,
                TiltShiftFarStart = SharedSettings.instance.graphics.tiltShiftFarStart,
                TiltShiftFarEnd = SharedSettings.instance.graphics.tiltShiftFarEnd,
                DlssQuality = SharedSettings.instance.graphics.dlssQuality,
                //Fsr2Quality = SharedSettings.instance.graphics.fsr2Quality,
                GameQualitySettings = GameQualitySettings,
            };
            if (log)
                Mod.log.Info("Collecting GameGraphicsSettings");
            var GameInputSettings = new GameInputSettings
            {
                ElevationDraggingEnabled = SharedSettings.instance.input.elevationDraggingEnabled,
                MouseScrollSensitivity = SharedSettings.instance.input.mouseScrollSensitivity,
                KeyboardMoveSensitivity = SharedSettings.instance.input.keyboardMoveSensitivity,
                KeyboardRotateSensitivity = SharedSettings.instance.input.keyboardRotateSensitivity,
                KeyboardZoomSensitivity = SharedSettings.instance.input.keyboardZoomSensitivity,
                MouseMoveSensitivity = SharedSettings.instance.input.mouseMoveSensitivity,
                MouseRotateSensitivity = SharedSettings.instance.input.mouseRotateSensitivity,
                MouseZoomSensitivity = SharedSettings.instance.input.mouseZoomSensitivity,
                MouseInvertX = SharedSettings.instance.input.mouseInvertX,
                MouseInvertY = SharedSettings.instance.input.mouseInvertY,
                GamepadMoveSensitivity = SharedSettings.instance.input.gamepadMoveSensitivity,
                GamepadRotateSensitivity = SharedSettings.instance.input.gamepadRotateSensitivity,
                GamepadZoomSensitivity = SharedSettings.instance.input.gamepadZoomSensitivity,
                GamepadInvertX = SharedSettings.instance.input.gamepadInvertX,
                GamepadInvertY = SharedSettings.instance.input.gamepadInvertY,
            };
            if (log)
                Mod.log.Info("Collecting GameInputSettings");
            var GameInterfaceSettings = new GameInterfaceSettings
            {
                CurrentLocale = SharedSettings.instance.userInterface.currentLocale,
                InterfaceStyle = SharedSettings.instance.userInterface.interfaceStyle,
                InterfaceTransparency = SharedSettings.instance.userInterface.interfaceTransparency,
                InterfaceScaling = SharedSettings.instance.userInterface.interfaceScaling,
                TextScale = SharedSettings.instance.userInterface.textScale,
                UnlockHighlightsEnabled = SharedSettings
                    .instance
                    .userInterface
                    .unlockHighlightsEnabled,
                ChirperPopupsEnabled = SharedSettings.instance.userInterface.chirperPopupsEnabled,
                InputHintsType = SharedSettings.instance.userInterface.inputHintsType,
                KeyboardLayout = SharedSettings.instance.userInterface.keyboardLayout,
                TimeFormat = SharedSettings.instance.userInterface.timeFormat,
                TemperatureUnit = SharedSettings.instance.userInterface.temperatureUnit,
                UnitSystem = SharedSettings.instance.userInterface.unitSystem,
                BlockingPopupsEnabled = SharedSettings.instance.userInterface.blockingPopupsEnabled,
            };
            if (log)
                Mod.log.Info("Collecting GameInterfaceSettings");
            var GameUserState = new GameUserState
            {
                LastCloudTarget = SharedSettings.instance.userState.lastCloudTarget,
                LeftHandTraffic = SharedSettings.instance.userState.leftHandTraffic,
                NaturalDisasters = SharedSettings.instance.userState.naturalDisasters,
                UnlockAll = SharedSettings.instance.userState.unlockAll,
                UnlimitedMoney = SharedSettings.instance.userState.unlimitedMoney,
                UnlockMapTiles = SharedSettings.instance.userState.unlockMapTiles,
            };
            if (log)
                Mod.log.Info("Collecting GameUserState");
            var GameSettings = new GameSettings
            {
                GameVersion = Game.Version.current.version,
                LastUpdated = DateTime.Now.ToLongDateString(),
                GameAudioSettings = GameAudioSettings,
                GameEditorSettings = GameEditorSettings,
                GameGameplaySettings = GameGameplaySettings,
                GameGeneralSettings = GameGeneralSettings,
                GameGraphicsSettings = GameGraphicsSettings,
                GameInputSettings = GameInputSettings,
                GameInterfaceSettings = GameInterfaceSettings,
                GameUserState = GameUserState,
            };
            if (log)
                Mod.log.Info("Collecting GameSettings");
            try
            {
                string jsonString = JsonConvert.SerializeObject(GameSettings, Formatting.Indented);
                File.WriteAllText(backupFile, jsonString);
                Mod.log.Info(
                    $"Game Settings backup created successfully: {Path.GetFileName(backupFile)}"
                );
            }
            catch (Exception ex)
            {
                Mod.log.Info(ex);
            }
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
                Mod.log.Error("Trying to Restore Backup, when Backup file is not found.");
                return;
            }

            Mod.log.Info($"Restoring Backup {Path.GetFileName(backupFile)}");
            string jsonString = File.ReadAllText(backupFile);

            try
            {
                JObject jsonObject = JObject.Parse(jsonString);

                if (jsonObject["GameAudioSettings"] != null)
                {
                    GameAudioSettings GameAudioSettings = jsonObject["GameAudioSettings"]
                        .ToObject<GameAudioSettings>();
                    if (
                        jsonObject["GameAudioSettings"]["MasterVolume"] != null
                        && SharedSettings.instance.audio.masterVolume
                            != GameAudioSettings.MasterVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.masterVolume'=> '{GameAudioSettings.MasterVolume}'"
                            );
                        SharedSettings.instance.audio.masterVolume = GameAudioSettings.MasterVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["UiVolume"] != null
                        && SharedSettings.instance.audio.uiVolume != GameAudioSettings.UiVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.uiVolume'=> '{GameAudioSettings.UiVolume}'"
                            );
                        SharedSettings.instance.audio.uiVolume = GameAudioSettings.UiVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["MenuVolume"] != null
                        && SharedSettings.instance.audio.menuVolume != GameAudioSettings.MenuVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.menuVolume'=> '{GameAudioSettings.MenuVolume}'"
                            );
                        SharedSettings.instance.audio.menuVolume = GameAudioSettings.MenuVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["IngameVolume"] != null
                        && SharedSettings.instance.audio.ingameVolume
                            != GameAudioSettings.IngameVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.ingameVolume'=> '{GameAudioSettings.IngameVolume}'"
                            );
                        SharedSettings.instance.audio.ingameVolume = GameAudioSettings.IngameVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["RadioActive"] != null
                        && SharedSettings.instance.audio.radioActive
                            != GameAudioSettings.RadioActive
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.radioActive'=> '{GameAudioSettings.RadioActive}'"
                            );
                        SharedSettings.instance.audio.radioActive = GameAudioSettings.RadioActive;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["RadioVolume"] != null
                        && SharedSettings.instance.audio.radioVolume
                            != GameAudioSettings.RadioVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.radioVolume'=> '{GameAudioSettings.RadioVolume}'"
                            );
                        SharedSettings.instance.audio.radioVolume = GameAudioSettings.RadioVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["AmbienceVolume"] != null
                        && SharedSettings.instance.audio.ambienceVolume
                            != GameAudioSettings.AmbienceVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.ambienceVolume'=> '{GameAudioSettings.AmbienceVolume}'"
                            );
                        SharedSettings.instance.audio.ambienceVolume =
                            GameAudioSettings.AmbienceVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["DisastersVolume"] != null
                        && SharedSettings.instance.audio.disastersVolume
                            != GameAudioSettings.DisastersVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.disastersVolume'=> '{GameAudioSettings.DisastersVolume}'"
                            );
                        SharedSettings.instance.audio.disastersVolume =
                            GameAudioSettings.DisastersVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["WorldVolume"] != null
                        && SharedSettings.instance.audio.worldVolume
                            != GameAudioSettings.WorldVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.worldVolume'=> '{GameAudioSettings.WorldVolume}'"
                            );
                        SharedSettings.instance.audio.worldVolume = GameAudioSettings.WorldVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["AudioGroupsVolume"] != null
                        && SharedSettings.instance.audio.audioGroupsVolume
                            != GameAudioSettings.AudioGroupsVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.audioGroupsVolume'=> '{GameAudioSettings.AudioGroupsVolume}'"
                            );
                        SharedSettings.instance.audio.audioGroupsVolume =
                            GameAudioSettings.AudioGroupsVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["ServiceBuildingsVolume"] != null
                        && SharedSettings.instance.audio.serviceBuildingsVolume
                            != GameAudioSettings.ServiceBuildingsVolume
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.serviceBuildingsVolume'=> '{GameAudioSettings.ServiceBuildingsVolume}'"
                            );
                        SharedSettings.instance.audio.serviceBuildingsVolume =
                            GameAudioSettings.ServiceBuildingsVolume;
                    }
                    if (
                        jsonObject["GameAudioSettings"]["ClipMemoryBudget"] != null
                        && SharedSettings.instance.audio.clipMemoryBudget
                            != GameAudioSettings.ClipMemoryBudget
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'audio.clipMemoryBudget'=> '{GameAudioSettings.ClipMemoryBudget}'"
                            );
                        SharedSettings.instance.audio.clipMemoryBudget =
                            GameAudioSettings.ClipMemoryBudget;
                    }
                }

                if (jsonObject["GameEditorSettings"] != null)
                {
                    GameEditorSettings GameEditorSettings = jsonObject["GameEditorSettings"]
                        .ToObject<GameEditorSettings>();
                    if (
                        jsonObject["GameEditorSettings"]["AssetPickerColumnCount"] != null
                        && SharedSettings.instance.editor.assetPickerColumnCount
                            != GameEditorSettings.AssetPickerColumnCount
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.assetPickerColumnCount'=> '{GameEditorSettings.AssetPickerColumnCount}'"
                            );
                        SharedSettings.instance.editor.assetPickerColumnCount =
                            GameEditorSettings.AssetPickerColumnCount;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["InspectorWidth"] != null
                        && SharedSettings.instance.editor.inspectorWidth
                            != GameEditorSettings.InspectorWidth
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.inspectorWidth'=> '{GameEditorSettings.InspectorWidth}'"
                            );
                        SharedSettings.instance.editor.inspectorWidth =
                            GameEditorSettings.InspectorWidth;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["HierarchyWidth"] != null
                        && SharedSettings.instance.editor.hierarchyWidth
                            != GameEditorSettings.HierarchyWidth
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.hierarchyWidth'=> '{GameEditorSettings.HierarchyWidth}'"
                            );
                        SharedSettings.instance.editor.hierarchyWidth =
                            GameEditorSettings.HierarchyWidth;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["UseParallelImport"] != null
                        && SharedSettings.instance.editor.useParallelImport
                            != GameEditorSettings.UseParallelImport
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.useParallelImport'=> '{GameEditorSettings.UseParallelImport}'"
                            );
                        SharedSettings.instance.editor.useParallelImport =
                            GameEditorSettings.UseParallelImport;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["LowQualityTextureCompression"] != null
                        && SharedSettings.instance.editor.lowQualityTextureCompression
                            != GameEditorSettings.LowQualityTextureCompression
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.lowQualityTextureCompression'=> '{GameEditorSettings.LowQualityTextureCompression}'"
                            );
                        SharedSettings.instance.editor.lowQualityTextureCompression =
                            GameEditorSettings.LowQualityTextureCompression;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["LastSelectedProjectRootDirectory"] != null
                        && SharedSettings.instance.editor.lastSelectedProjectRootDirectory
                            != GameEditorSettings.LastSelectedProjectRootDirectory
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.lastSelectedProjectRootDirectory'=> '{GameEditorSettings.LastSelectedProjectRootDirectory}'"
                            );
                        SharedSettings.instance.editor.lastSelectedProjectRootDirectory =
                            GameEditorSettings.LastSelectedProjectRootDirectory;
                    }
                    if (
                        jsonObject["GameEditorSettings"]["LastSelectedImportDirectory"] != null
                        && SharedSettings.instance.editor.lastSelectedImportDirectory
                            != GameEditorSettings.LastSelectedImportDirectory
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'editor.lastSelectedImportDirectory'=> '{GameEditorSettings.LastSelectedImportDirectory}'"
                            );
                        SharedSettings.instance.editor.lastSelectedImportDirectory =
                            GameEditorSettings.LastSelectedImportDirectory;
                    }
                }

                if (jsonObject["GameGameplaySettings"] != null)
                {
                    GameGameplaySettings GameGameplaySettings = jsonObject["GameGameplaySettings"]
                        .ToObject<GameGameplaySettings>();
                    if (
                        jsonObject["GameGameplaySettings"]["EdgeScrolling"] != null
                        && SharedSettings.instance.gameplay.edgeScrolling
                            != GameGameplaySettings.EdgeScrolling
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'gameplay.edgeScrolling'=> '{GameGameplaySettings.EdgeScrolling}'"
                            );
                        SharedSettings.instance.gameplay.edgeScrolling =
                            GameGameplaySettings.EdgeScrolling;
                    }
                    if (
                        jsonObject["GameGameplaySettings"]["EdgeScrollSensivity"] != null
                        && SharedSettings.instance.gameplay.edgeScrollingSensitivity
                            != GameGameplaySettings.EdgeScrollSensivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'gameplay.edgeScrollingSensitivity'=> '{GameGameplaySettings.EdgeScrollSensivity}'"
                            );
                        SharedSettings.instance.gameplay.edgeScrollingSensitivity =
                            GameGameplaySettings.EdgeScrollSensivity;
                    }
                    if (
                        jsonObject["GameGameplaySettings"]["DayNightVisual"] != null
                        && SharedSettings.instance.gameplay.dayNightVisual
                            != GameGameplaySettings.DayNightVisual
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'gameplay.dayNightVisual'=> '{GameGameplaySettings.DayNightVisual}'"
                            );
                        SharedSettings.instance.gameplay.dayNightVisual =
                            GameGameplaySettings.DayNightVisual;
                    }
                    if (
                        jsonObject["GameGameplaySettings"]["PausedAfterLoading"] != null
                        && SharedSettings.instance.gameplay.pausedAfterLoading
                            != GameGameplaySettings.PausedAfterLoading
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'gameplay.pausedAfterLoading'=> '{GameGameplaySettings.PausedAfterLoading}'"
                            );
                        SharedSettings.instance.gameplay.pausedAfterLoading =
                            GameGameplaySettings.PausedAfterLoading;
                    }
                    if (
                        jsonObject["GameGameplaySettings"]["ShowTutorials"] != null
                        && SharedSettings.instance.gameplay.showTutorials
                            != GameGameplaySettings.ShowTutorials
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'gameplay.showTutorials'=> '{GameGameplaySettings.ShowTutorials}'"
                            );
                        SharedSettings.instance.gameplay.showTutorials =
                            GameGameplaySettings.ShowTutorials;
                    }
                }

                if (jsonObject["GameGeneralSettings"] != null)
                {
                    GameGeneralSettings GameGeneralSettings = jsonObject["GameGeneralSettings"]
                        .ToObject<GameGeneralSettings>();
                    if (
                        jsonObject["GameGeneralSettings"]["AssetDatabaseAutoReloadMode"] != null
                        && SharedSettings.instance.general.assetDatabaseAutoReloadMode
                            != GameGeneralSettings.AssetDatabaseAutoReloadMode
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.assetDatabaseAutoReloadMode'=> '{GameGeneralSettings.AssetDatabaseAutoReloadMode}'"
                            );
                        SharedSettings.instance.general.assetDatabaseAutoReloadMode =
                            GameGeneralSettings.AssetDatabaseAutoReloadMode;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["PerformancePreference"] != null
                        && SharedSettings.instance.general.performancePreference
                            != GameGeneralSettings.PerformancePreference
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.performancePreference'=> '{GameGeneralSettings.PerformancePreference}'"
                            );
                        SharedSettings.instance.general.performancePreference =
                            GameGeneralSettings.PerformancePreference;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["FpsMode"] != null
                        && SharedSettings.instance.general.fpsMode != GameGeneralSettings.FpsMode
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.fpsMode'=> '{GameGeneralSettings.FpsMode}'"
                            );
                        SharedSettings.instance.general.fpsMode = GameGeneralSettings.FpsMode;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["AutoSave"] != null
                        && SharedSettings.instance.general.autoSave != GameGeneralSettings.AutoSave
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.autoSave'=> '{GameGeneralSettings.AutoSave}'"
                            );
                        SharedSettings.instance.general.autoSave = GameGeneralSettings.AutoSave;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["AutoSaveInterval"] != null
                        && SharedSettings.instance.general.autoSaveInterval
                            != GameGeneralSettings.AutoSaveInterval
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.autoSaveInterval'=> '{GameGeneralSettings.AutoSaveInterval}'"
                            );
                        SharedSettings.instance.general.autoSaveInterval =
                            GameGeneralSettings.AutoSaveInterval;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["AutoSaveCount"] != null
                        && SharedSettings.instance.general.autoSaveCount
                            != GameGeneralSettings.AutoSaveCount
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.autoSaveCount'=> '{GameGeneralSettings.AutoSaveCount}'"
                            );
                        SharedSettings.instance.general.autoSaveCount =
                            GameGeneralSettings.AutoSaveCount;
                    }
                    if (
                        jsonObject["GameGeneralSettings"]["AllowOptionalTelemetry"] != null
                        && SharedSettings.instance.general.allowOptionalTelemetry
                            != GameGeneralSettings.AllowOptionalTelemetry
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'general.allowOptionalTelemetry'=> '{GameGeneralSettings.AllowOptionalTelemetry}'"
                            );
                        SharedSettings.instance.general.allowOptionalTelemetry =
                            GameGeneralSettings.AllowOptionalTelemetry;
                    }
                }

                if (jsonObject["GameGraphicsSettings"] != null)
                {
                    GameGraphicsSettings GameGraphicsSettings = jsonObject["GameGraphicsSettings"]
                        .ToObject<GameGraphicsSettings>();
                    if (
                        jsonObject["GameGraphicsSettings"]["DisplayIndex"] != null
                        && SharedSettings.instance.graphics.displayIndex
                            != GameGraphicsSettings.DisplayIndex
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.displayIndex'=> '{GameGraphicsSettings.DisplayIndex}'"
                            );
                        SharedSettings.instance.graphics.displayIndex =
                            GameGraphicsSettings.DisplayIndex;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["VSync"] != null
                        && SharedSettings.instance.graphics.vSync != GameGraphicsSettings.VSync
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.vSync'=> '{GameGraphicsSettings.VSync}'"
                            );
                        SharedSettings.instance.graphics.vSync = GameGraphicsSettings.VSync;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["MaxFrameLatency"] != null
                        && SharedSettings.instance.graphics.maxFrameLatency
                            != GameGraphicsSettings.MaxFrameLatency
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.maxFrameLatency'=> '{GameGraphicsSettings.MaxFrameLatency}'"
                            );
                        SharedSettings.instance.graphics.maxFrameLatency =
                            GameGraphicsSettings.MaxFrameLatency;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["CursorMode"] != null
                        && SharedSettings.instance.graphics.cursorMode
                            != GameGraphicsSettings.CursorMode
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.cursorMode'=> '{GameGraphicsSettings.CursorMode}'"
                            );
                        SharedSettings.instance.graphics.cursorMode =
                            GameGraphicsSettings.CursorMode;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["DepthOfFieldMode"] != null
                        && SharedSettings.instance.graphics.depthOfFieldMode
                            != GameGraphicsSettings.DepthOfFieldMode
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.depthOfFieldMode'=> '{GameGraphicsSettings.DepthOfFieldMode}'"
                            );
                        SharedSettings.instance.graphics.depthOfFieldMode =
                            GameGraphicsSettings.DepthOfFieldMode;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["TiltShiftNearStart"] != null
                        && SharedSettings.instance.graphics.tiltShiftNearStart
                            != GameGraphicsSettings.TiltShiftNearStart
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.tiltShiftNearStart'=> '{GameGraphicsSettings.TiltShiftNearStart}'"
                            );
                        SharedSettings.instance.graphics.tiltShiftNearStart =
                            GameGraphicsSettings.TiltShiftNearStart;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["TiltShiftNearEnd"] != null
                        && SharedSettings.instance.graphics.tiltShiftNearEnd
                            != GameGraphicsSettings.TiltShiftNearEnd
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.tiltShiftNearEnd'=> '{GameGraphicsSettings.TiltShiftNearEnd}'"
                            );
                        SharedSettings.instance.graphics.tiltShiftNearEnd =
                            GameGraphicsSettings.TiltShiftNearEnd;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["TiltShiftFarStart"] != null
                        && SharedSettings.instance.graphics.tiltShiftFarStart
                            != GameGraphicsSettings.TiltShiftFarStart
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.tiltShiftFarStart'=> '{GameGraphicsSettings.TiltShiftFarStart}'"
                            );
                        SharedSettings.instance.graphics.tiltShiftFarStart =
                            GameGraphicsSettings.TiltShiftFarStart;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["TiltShiftFarEnd"] != null
                        && SharedSettings.instance.graphics.tiltShiftFarEnd
                            != GameGraphicsSettings.TiltShiftFarEnd
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.tiltShiftFarEnd'=> '{GameGraphicsSettings.TiltShiftFarEnd}'"
                            );
                        SharedSettings.instance.graphics.tiltShiftFarEnd =
                            GameGraphicsSettings.TiltShiftFarEnd;
                    }
                    if (
                        jsonObject["GameGraphicsSettings"]["DlssQuality"] != null
                        && SharedSettings.instance.graphics.dlssQuality
                            != GameGraphicsSettings.DlssQuality
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'graphics.dlssQuality'=> '{GameGraphicsSettings.DlssQuality}'"
                            );
                        SharedSettings.instance.graphics.dlssQuality =
                            GameGraphicsSettings.DlssQuality;
                    }
                    //if (jsonObject["GameGraphicsSettings"]["Fsr2Quality"] != null)
                    //{
                    //    if (log) Mod.log.Info($"Restoring 'graphics.fsr2Quality'=> '{GameGraphicsSettings.Fsr2Quality}'");
                    //    SharedSettings.instance.graphics.fsr2Quality = GameGraphicsSettings.Fsr2Quality;
                    //}
                    if (jsonObject["GameGraphicsSettings"]["GameQualitySettings"] != null)
                    {
                        GameDynamicResolutionQualitySettings GameDynamicResolutionQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameDynamicResolutionQualitySettings"]
                                .ToObject<GameDynamicResolutionQualitySettings>();
                        GameAntiAliasingQualitySettings GameAntiAliasingQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameAntiAliasingQualitySettings"]
                                .ToObject<GameAntiAliasingQualitySettings>();
                        GameCloudsQualitySettings GameCloudsQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameCloudsQualitySettings"]
                            .ToObject<GameCloudsQualitySettings>();
                        GameFogQualitySettings GameFogQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameFogQualitySettings"]
                            .ToObject<GameFogQualitySettings>();
                        GameVolumetricsQualitySettings GameVolumetricsQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameVolumetricsQualitySettings"]
                            .ToObject<GameVolumetricsQualitySettings>();
                        GameAmbientOcclustionQualitySettings GameAmbientOcclustionQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameAmbientOcclustionQualitySettings"]
                                .ToObject<GameAmbientOcclustionQualitySettings>();
                        GameIlluminationQualitySettings GameIlluminationQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameIlluminationQualitySettings"]
                                .ToObject<GameIlluminationQualitySettings>();
                        GameReflectionQualitySettings GameReflectionQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameReflectionQualitySettings"]
                            .ToObject<GameReflectionQualitySettings>();
                        GameDepthOfFieldQualitySettings GameDepthOfFieldQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameDepthOfFieldQualitySettings"]
                                .ToObject<GameDepthOfFieldQualitySettings>();
                        GameMotionBlurQualitySettings GameMotionBlurQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameMotionBlurQualitySettings"]
                            .ToObject<GameMotionBlurQualitySettings>();
                        GameShadowsQualitySettings GameShadowsQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameShadowsQualitySettings"]
                            .ToObject<GameShadowsQualitySettings>();
                        GameTerrainQualitySettings GameTerrainQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameTerrainQualitySettings"]
                            .ToObject<GameTerrainQualitySettings>();
                        GameWaterQualitySettings GameWaterQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameWaterQualitySettings"]
                            .ToObject<GameWaterQualitySettings>();
                        GameLevelOfDetailQualitySettings GameLevelOfDetailQualitySettings =
                            jsonObject["GameGraphicsSettings"]
                                ["GameQualitySettings"]["GameLevelOfDetailQualitySettings"]
                                .ToObject<GameLevelOfDetailQualitySettings>();
                        GameAnimationQualitySetting GameAnimationQualitySetting = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameAnimationQualitySetting"]
                            .ToObject<GameAnimationQualitySetting>();
                        GameTextureQualitySettings GameTextureQualitySettings = jsonObject[
                            "GameGraphicsSettings"
                        ]
                            ["GameQualitySettings"]["GameTextureQualitySettings"]
                            .ToObject<GameTextureQualitySettings>();

                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDynamicResolutionQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .enabled != GameDynamicResolutionQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().enabled'=> '{GameDynamicResolutionQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .enabled = GameDynamicResolutionQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDynamicResolutionQualitySettings"
                            ]["IsAdaptive"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .isAdaptive != GameDynamicResolutionQualitySettings.IsAdaptive
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().isAdaptive'=> '{GameDynamicResolutionQualitySettings.IsAdaptive}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .isAdaptive = GameDynamicResolutionQualitySettings.IsAdaptive;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDynamicResolutionQualitySettings"
                            ]["UpscaleFilter"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .upscaleFilter != GameDynamicResolutionQualitySettings.UpscaleFilter
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().upscaleFilter'=> '{GameDynamicResolutionQualitySettings.UpscaleFilter}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .upscaleFilter = GameDynamicResolutionQualitySettings.UpscaleFilter;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDynamicResolutionQualitySettings"
                            ]["MinScale"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .minScale != GameDynamicResolutionQualitySettings.MinScale
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DynamicResolutionScaleSettings>().minScale'=> '{GameDynamicResolutionQualitySettings.MinScale}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DynamicResolutionScaleSettings>()
                                .minScale = GameDynamicResolutionQualitySettings.MinScale;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAntiAliasingQualitySettings"
                            ]["AntiAliasingMethod"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .antiAliasingMethod
                                != GameAntiAliasingQualitySettings.AntiAliasingMethod
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().antiAliasingMethod'=> '{GameAntiAliasingQualitySettings.AntiAliasingMethod}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .antiAliasingMethod =
                                GameAntiAliasingQualitySettings.AntiAliasingMethod;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAntiAliasingQualitySettings"
                            ]["SmaaQuality"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .smaaQuality != GameAntiAliasingQualitySettings.SmaaQuality
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().smaaQuality'=> '{GameAntiAliasingQualitySettings.SmaaQuality}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .smaaQuality = GameAntiAliasingQualitySettings.SmaaQuality;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAntiAliasingQualitySettings"
                            ]["OutlinesMSAA"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .outlinesMSAA != GameAntiAliasingQualitySettings.OutlinesMSAA
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<AntiAliasingQualitySettings>().outlinesMSAA'=> '{GameAntiAliasingQualitySettings.OutlinesMSAA}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<AntiAliasingQualitySettings>()
                                .outlinesMSAA = GameAntiAliasingQualitySettings.OutlinesMSAA;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameCloudsQualitySettings"
                            ]["VolumetricCloudsEnabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .volumetricCloudsEnabled
                                != GameCloudsQualitySettings.VolumetricCloudsEnabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsEnabled'=> '{GameCloudsQualitySettings.VolumetricCloudsEnabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .volumetricCloudsEnabled =
                                GameCloudsQualitySettings.VolumetricCloudsEnabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameCloudsQualitySettings"
                            ]["DistanceCloudsEnabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .distanceCloudsEnabled
                                != GameCloudsQualitySettings.DistanceCloudsEnabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsEnabled'=> '{GameCloudsQualitySettings.DistanceCloudsEnabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .distanceCloudsEnabled =
                                GameCloudsQualitySettings.DistanceCloudsEnabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameCloudsQualitySettings"
                            ]["VolumetricCloudsShadows"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .volumetricCloudsShadows
                                != GameCloudsQualitySettings.VolumetricCloudsShadows
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().volumetricCloudsShadows'=> '{GameCloudsQualitySettings.VolumetricCloudsShadows}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .volumetricCloudsShadows =
                                GameCloudsQualitySettings.VolumetricCloudsShadows;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameCloudsQualitySettings"
                            ]["DistanceCloudsShadows"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .distanceCloudsShadows
                                != GameCloudsQualitySettings.DistanceCloudsShadows
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<CloudsQualitySettings>().distanceCloudsShadows'=> '{GameCloudsQualitySettings.DistanceCloudsShadows}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<CloudsQualitySettings>()
                                .distanceCloudsShadows =
                                GameCloudsQualitySettings.DistanceCloudsShadows;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameFogQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<FogQualitySettings>()
                                .enabled != GameFogQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<FogQualitySettings>().enabled'=> '{GameFogQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<FogQualitySettings>()
                                .enabled = GameFogQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameVolumetricsQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .enabled != GameVolumetricsQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().enabled'=> '{GameVolumetricsQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .enabled = GameVolumetricsQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameVolumetricsQualitySettings"
                            ]["Budget"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .budget != GameVolumetricsQualitySettings.Budget
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().budget'=> '{GameVolumetricsQualitySettings.Budget}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .budget = GameVolumetricsQualitySettings.Budget;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameVolumetricsQualitySettings"
                            ]["ResolutionDepthRatio"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .resolutionDepthRatio
                                != GameVolumetricsQualitySettings.ResolutionDepthRatio
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<VolumetricsQualitySettings>().resolutionDepthRatio'=> '{GameVolumetricsQualitySettings.ResolutionDepthRatio}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<VolumetricsQualitySettings>()
                                .resolutionDepthRatio =
                                GameVolumetricsQualitySettings.ResolutionDepthRatio;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAmbientOcclustionQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .enabled != GameAmbientOcclustionQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().enabled'=> '{GameAmbientOcclustionQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .enabled = GameAmbientOcclustionQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAmbientOcclustionQualitySettings"
                            ]["MaxPixelRadius"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .maxPixelRadius
                                != GameAmbientOcclustionQualitySettings.MaxPixelRadius
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().maxPixelRadius'=> '{GameAmbientOcclustionQualitySettings.MaxPixelRadius}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .maxPixelRadius =
                                GameAmbientOcclustionQualitySettings.MaxPixelRadius;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAmbientOcclustionQualitySettings"
                            ]["Fullscreen"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .fullscreen != GameAmbientOcclustionQualitySettings.Fullscreen
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().fullscreen'=> '{GameAmbientOcclustionQualitySettings.Fullscreen}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .fullscreen = GameAmbientOcclustionQualitySettings.Fullscreen;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAmbientOcclustionQualitySettings"
                            ]["StepCount"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .stepCount != GameAmbientOcclustionQualitySettings.StepCount
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSAOQualitySettings>().stepCount'=> '{GameAmbientOcclustionQualitySettings.StepCount}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSAOQualitySettings>()
                                .stepCount = GameAmbientOcclustionQualitySettings.StepCount;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .enabled != GameIlluminationQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().enabled'=> '{GameIlluminationQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .enabled = GameIlluminationQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["Fullscreen"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .fullscreen != GameIlluminationQualitySettings.Fullscreen
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().fullscreen'=> '{GameIlluminationQualitySettings.Fullscreen}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .fullscreen = GameIlluminationQualitySettings.Fullscreen;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["RaySteps"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .raySteps != GameIlluminationQualitySettings.RaySteps
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().raySteps'=> '{GameIlluminationQualitySettings.RaySteps}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .raySteps = GameIlluminationQualitySettings.RaySteps;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["DenoiserRadius"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .denoiserRadius != GameIlluminationQualitySettings.DenoiserRadius
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().denoiserRadius'=> '{GameIlluminationQualitySettings.DenoiserRadius}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .denoiserRadius = GameIlluminationQualitySettings.DenoiserRadius;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["HalfResolutionPass"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .halfResolutionPass
                                != GameIlluminationQualitySettings.HalfResolutionPass
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().halfResolutionPass'=> '{GameIlluminationQualitySettings.HalfResolutionPass}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .halfResolutionPass =
                                GameIlluminationQualitySettings.HalfResolutionPass;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["SecondDenoiserPass"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .secondDenoiserPass
                                != GameIlluminationQualitySettings.SecondDenoiserPass
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().secondDenoiserPass'=> '{GameIlluminationQualitySettings.SecondDenoiserPass}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .secondDenoiserPass =
                                GameIlluminationQualitySettings.SecondDenoiserPass;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameIlluminationQualitySettings"
                            ]["DepthBufferThickness"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .depthBufferThickness
                                != GameIlluminationQualitySettings.DepthBufferThickness
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSGIQualitySettings>().depthBufferThickness'=> '{GameIlluminationQualitySettings.DepthBufferThickness}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSGIQualitySettings>()
                                .depthBufferThickness =
                                GameIlluminationQualitySettings.DepthBufferThickness;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameReflectionQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .enabled != GameReflectionQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().enabled'=> '{GameReflectionQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .enabled = GameReflectionQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameReflectionQualitySettings"
                            ]["EnabledTransparent"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .enabledTransparent
                                != GameReflectionQualitySettings.EnabledTransparent
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().enabledTransparent'=> '{GameReflectionQualitySettings.EnabledTransparent}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .enabledTransparent =
                                GameReflectionQualitySettings.EnabledTransparent;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameReflectionQualitySettings"
                            ]["MaxRaySteps"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .maxRaySteps != GameReflectionQualitySettings.MaxRaySteps
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<SSRQualitySettings>().maxRaySteps'=> '{GameReflectionQualitySettings.MaxRaySteps}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<SSRQualitySettings>()
                                .maxRaySteps = GameReflectionQualitySettings.MaxRaySteps;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .enabled != GameDepthOfFieldQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().enabled'=> '{GameDepthOfFieldQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .enabled = GameDepthOfFieldQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["NearSampleCount"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .nearSampleCount != GameDepthOfFieldQualitySettings.NearSampleCount
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearSampleCount'=> '{GameDepthOfFieldQualitySettings.NearSampleCount}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .nearSampleCount = GameDepthOfFieldQualitySettings.NearSampleCount;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["NearMaxRadius"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .nearMaxRadius != GameDepthOfFieldQualitySettings.NearMaxRadius
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().nearMaxRadius'=> '{GameDepthOfFieldQualitySettings.NearMaxRadius}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .nearMaxRadius = GameDepthOfFieldQualitySettings.NearMaxRadius;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["FarSampleCount"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .farSampleCount != GameDepthOfFieldQualitySettings.FarSampleCount
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farSampleCount'=> '{GameDepthOfFieldQualitySettings.FarSampleCount}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .farSampleCount = GameDepthOfFieldQualitySettings.FarSampleCount;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["FarMaxRadius"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .farMaxRadius != GameDepthOfFieldQualitySettings.FarMaxRadius
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().farMaxRadius'=> '{GameDepthOfFieldQualitySettings.FarMaxRadius}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .farMaxRadius = GameDepthOfFieldQualitySettings.FarMaxRadius;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["Resolution"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .resolution != GameDepthOfFieldQualitySettings.Resolution
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().resolution'=> '{GameDepthOfFieldQualitySettings.Resolution}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .resolution = GameDepthOfFieldQualitySettings.Resolution;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameDepthOfFieldQualitySettings"
                            ]["HighQualityFiltering"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .highQualityFiltering
                                != GameDepthOfFieldQualitySettings.HighQualityFiltering
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<DepthOfFieldQualitySettings>().highQualityFiltering'=> '{GameDepthOfFieldQualitySettings.HighQualityFiltering}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<DepthOfFieldQualitySettings>()
                                .highQualityFiltering =
                                GameDepthOfFieldQualitySettings.HighQualityFiltering;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameMotionBlurQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                                .enabled != GameMotionBlurQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<MotionBlurQualitySettings>().enabled'=> '{GameMotionBlurQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                                .enabled = GameMotionBlurQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameMotionBlurQualitySettings"
                            ]["SampleCount"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                                .sampleCount != GameMotionBlurQualitySettings.SampleCount
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<MotionBlurQualitySettings>().sampleCount'=> '{GameMotionBlurQualitySettings.SampleCount}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<MotionBlurQualitySettings>()
                                .sampleCount = GameMotionBlurQualitySettings.SampleCount;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameShadowsQualitySettings"
                            ]["Enabled"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .enabled != GameShadowsQualitySettings.Enabled
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().enabled'=> '{GameShadowsQualitySettings.Enabled}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .enabled = GameShadowsQualitySettings.Enabled;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameShadowsQualitySettings"
                            ]["TerrainCastShadows"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .terrainCastShadows != GameShadowsQualitySettings.TerrainCastShadows
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().terrainCastShadows'=> '{GameShadowsQualitySettings.TerrainCastShadows}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .terrainCastShadows = GameShadowsQualitySettings.TerrainCastShadows;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameShadowsQualitySettings"
                            ]["DirectionalShadowResolution"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .directionalShadowResolution
                                != GameShadowsQualitySettings.DirectionalShadowResolution
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().directionalShadowResolution'=> '{GameShadowsQualitySettings.DirectionalShadowResolution}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .directionalShadowResolution =
                                GameShadowsQualitySettings.DirectionalShadowResolution;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameShadowsQualitySettings"
                            ]["ShadowCullingThresholdHeight"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .shadowCullingThresholdHeight
                                != GameShadowsQualitySettings.ShadowCullingThresholdHeight
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdHeight'=> '{GameShadowsQualitySettings.ShadowCullingThresholdHeight}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .shadowCullingThresholdHeight =
                                GameShadowsQualitySettings.ShadowCullingThresholdHeight;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameShadowsQualitySettings"
                            ]["ShadowCullingThresholdVolume"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .shadowCullingThresholdVolume
                                != GameShadowsQualitySettings.ShadowCullingThresholdVolume
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<ShadowsQualitySettings>().shadowCullingThresholdVolume'=> '{GameShadowsQualitySettings.ShadowCullingThresholdVolume}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<ShadowsQualitySettings>()
                                .shadowCullingThresholdVolume =
                                GameShadowsQualitySettings.ShadowCullingThresholdVolume;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameTerrainQualitySettings"
                            ]["FinalTessellation"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                                .finalTessellation != GameTerrainQualitySettings.FinalTessellation
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<TerrainQualitySettings>().finalTessellation'=> '{GameTerrainQualitySettings.FinalTessellation}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                                .finalTessellation = GameTerrainQualitySettings.FinalTessellation;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameTerrainQualitySettings"
                            ]["TargetPatchSize"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                                .targetPatchSize != GameTerrainQualitySettings.TargetPatchSize
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<TerrainQualitySettings>().targetPatchSize'=> '{GameTerrainQualitySettings.TargetPatchSize}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<TerrainQualitySettings>()
                                .targetPatchSize = GameTerrainQualitySettings.TargetPatchSize;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameWaterQualitySettings"
                            ]["Waterflow"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .waterflow != GameWaterQualitySettings.Waterflow
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().waterflow'=> '{GameWaterQualitySettings.Waterflow}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .waterflow = GameWaterQualitySettings.Waterflow;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameWaterQualitySettings"
                            ]["MaxTessellationFactor"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .maxTessellationFactor
                                != GameWaterQualitySettings.MaxTessellationFactor
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().maxTessellationFactor'=> '{GameWaterQualitySettings.MaxTessellationFactor}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .maxTessellationFactor =
                                GameWaterQualitySettings.MaxTessellationFactor;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameWaterQualitySettings"
                            ]["TessellationFactorFadeStart"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .tessellationFactorFadeStart
                                != GameWaterQualitySettings.TessellationFactorFadeStart
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeStart'=> '{GameWaterQualitySettings.TessellationFactorFadeStart}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .tessellationFactorFadeStart =
                                GameWaterQualitySettings.TessellationFactorFadeStart;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameWaterQualitySettings"
                            ]["TessellationFactorFadeRange"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .tessellationFactorFadeRange
                                != GameWaterQualitySettings.TessellationFactorFadeRange
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<WaterQualitySettings>().tessellationFactorFadeRange'=> '{GameWaterQualitySettings.TessellationFactorFadeRange}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<WaterQualitySettings>()
                                .tessellationFactorFadeRange =
                                GameWaterQualitySettings.TessellationFactorFadeRange;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameLevelOfDetailQualitySettings"
                            ]["LevelOfDetail"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .levelOfDetail != GameLevelOfDetailQualitySettings.LevelOfDetail
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().levelOfDetail'=> '{GameLevelOfDetailQualitySettings.LevelOfDetail}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .levelOfDetail = GameLevelOfDetailQualitySettings.LevelOfDetail;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameLevelOfDetailQualitySettings"
                            ]["LodCrossFade"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .lodCrossFade != GameLevelOfDetailQualitySettings.LodCrossFade
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().lodCrossFade'=> '{GameLevelOfDetailQualitySettings.LodCrossFade}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .lodCrossFade = GameLevelOfDetailQualitySettings.LodCrossFade;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameLevelOfDetailQualitySettings"
                            ]["MaxLightCount"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .maxLightCount != GameLevelOfDetailQualitySettings.MaxLightCount
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().maxLightCount'=> '{GameLevelOfDetailQualitySettings.MaxLightCount}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .maxLightCount = GameLevelOfDetailQualitySettings.MaxLightCount;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameLevelOfDetailQualitySettings"
                            ]["MeshMemoryBudget"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .meshMemoryBudget
                                != GameLevelOfDetailQualitySettings.MeshMemoryBudget
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().meshMemoryBudget'=> '{GameLevelOfDetailQualitySettings.MeshMemoryBudget}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .meshMemoryBudget =
                                GameLevelOfDetailQualitySettings.MeshMemoryBudget;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameLevelOfDetailQualitySettings"
                            ]["StrictMeshMemory"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .strictMeshMemory
                                != GameLevelOfDetailQualitySettings.StrictMeshMemory
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<LevelOfDetailQualitySettings>().strictMeshMemory'=> '{GameLevelOfDetailQualitySettings.StrictMeshMemory}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<LevelOfDetailQualitySettings>()
                                .strictMeshMemory =
                                GameLevelOfDetailQualitySettings.StrictMeshMemory;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameAnimationQualitySetting"
                            ]["MaxBoneInfuence"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<AnimationQualitySettings>()
                                .maxBoneInfuence != GameAnimationQualitySetting.MaxBoneInfuence
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<AnimationQualitySettings>().maxBoneInfuence'=> '{GameAnimationQualitySetting.MaxBoneInfuence}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<AnimationQualitySettings>()
                                .maxBoneInfuence = GameAnimationQualitySetting.MaxBoneInfuence;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameTextureQualitySettings"
                            ]["Mipbias"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                                .mipbias != GameTextureQualitySettings.Mipbias
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<TextureQualitySettings>().mipbias'=> '{GameTextureQualitySettings.Mipbias}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                                .mipbias = GameTextureQualitySettings.Mipbias;
                        }
                        if (
                            jsonObject["GameGraphicsSettings"]["GameQualitySettings"][
                                "GameTextureQualitySettings"
                            ]["FilterMode"] != null
                            && SharedSettings
                                .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                                .filterMode != GameTextureQualitySettings.FilterMode
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'graphics.GetQualitySetting<TextureQualitySettings>().filterMode'=> '{GameTextureQualitySettings.FilterMode}'"
                                );
                            SharedSettings
                                .instance.graphics.GetQualitySetting<TextureQualitySettings>()
                                .filterMode = GameTextureQualitySettings.FilterMode;
                        }
                    }
                }

                if (jsonObject["GameInputSettings"] != null)
                {
                    GameInputSettings GameInputSettings = jsonObject["GameInputSettings"]
                        .ToObject<GameInputSettings>();

                    if (
                        jsonObject["GameInputSettings"]["ElevationDraggingEnabled"] != null
                        && SharedSettings.instance.input.elevationDraggingEnabled
                            != GameInputSettings.ElevationDraggingEnabled
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.elevationDraggingEnabled'=> '{GameInputSettings.ElevationDraggingEnabled}'"
                            );
                        SharedSettings.instance.input.elevationDraggingEnabled =
                            GameInputSettings.ElevationDraggingEnabled;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseScrollSensitivity"] != null
                        && SharedSettings.instance.input.mouseScrollSensitivity
                            != GameInputSettings.MouseScrollSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseScrollSensitivity'=> '{GameInputSettings.MouseScrollSensitivity}'"
                            );
                        SharedSettings.instance.input.mouseScrollSensitivity =
                            GameInputSettings.MouseScrollSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["KeyboardMoveSensitivity"] != null
                        && SharedSettings.instance.input.keyboardMoveSensitivity
                            != GameInputSettings.KeyboardMoveSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.keyboardMoveSensitivity'=> '{GameInputSettings.KeyboardMoveSensitivity}'"
                            );
                        SharedSettings.instance.input.keyboardMoveSensitivity =
                            GameInputSettings.KeyboardMoveSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["KeyboardRotateSensitivity"] != null
                        && SharedSettings.instance.input.keyboardRotateSensitivity
                            != GameInputSettings.KeyboardRotateSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.keyboardRotateSensitivity'=> '{GameInputSettings.KeyboardRotateSensitivity}'"
                            );
                        SharedSettings.instance.input.keyboardRotateSensitivity =
                            GameInputSettings.KeyboardRotateSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["KeyboardZoomSensitivity"] != null
                        && SharedSettings.instance.input.keyboardZoomSensitivity
                            != GameInputSettings.KeyboardZoomSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.keyboardZoomSensitivity'=> '{GameInputSettings.KeyboardZoomSensitivity}'"
                            );
                        SharedSettings.instance.input.keyboardZoomSensitivity =
                            GameInputSettings.KeyboardZoomSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseMoveSensitivity"] != null
                        && SharedSettings.instance.input.mouseMoveSensitivity
                            != GameInputSettings.MouseMoveSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseMoveSensitivity'=> '{GameInputSettings.MouseMoveSensitivity}'"
                            );
                        SharedSettings.instance.input.mouseMoveSensitivity =
                            GameInputSettings.MouseMoveSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseRotateSensitivity"] != null
                        && SharedSettings.instance.input.mouseRotateSensitivity
                            != GameInputSettings.MouseRotateSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseRotateSensitivity'=> '{GameInputSettings.MouseRotateSensitivity}'"
                            );
                        SharedSettings.instance.input.mouseRotateSensitivity =
                            GameInputSettings.MouseRotateSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseZoomSensitivity"] != null
                        && SharedSettings.instance.input.mouseZoomSensitivity
                            != GameInputSettings.MouseZoomSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseZoomSensitivity'=> '{GameInputSettings.MouseZoomSensitivity}'"
                            );
                        SharedSettings.instance.input.mouseZoomSensitivity =
                            GameInputSettings.MouseZoomSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseInvertX"] != null
                        && SharedSettings.instance.input.mouseInvertX
                            != GameInputSettings.MouseInvertX
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseInvertX'=> '{GameInputSettings.MouseInvertX}'"
                            );
                        SharedSettings.instance.input.mouseInvertX = GameInputSettings.MouseInvertX;
                    }
                    if (
                        jsonObject["GameInputSettings"]["MouseInvertY"] != null
                        && SharedSettings.instance.input.mouseInvertY
                            != GameInputSettings.MouseInvertY
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.mouseInvertY'=> '{GameInputSettings.MouseInvertY}'"
                            );
                        SharedSettings.instance.input.mouseInvertY = GameInputSettings.MouseInvertY;
                    }
                    if (
                        jsonObject["GameInputSettings"]["GamepadMoveSensitivity"] != null
                        && SharedSettings.instance.input.gamepadMoveSensitivity
                            != GameInputSettings.GamepadMoveSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.gamepadMoveSensitivity'=> '{GameInputSettings.GamepadMoveSensitivity}'"
                            );
                        SharedSettings.instance.input.gamepadMoveSensitivity =
                            GameInputSettings.GamepadMoveSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["GamepadRotateSensitivity"] != null
                        && SharedSettings.instance.input.gamepadRotateSensitivity
                            != GameInputSettings.GamepadRotateSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.gamepadRotateSensitivity'=> '{GameInputSettings.GamepadRotateSensitivity}'"
                            );
                        SharedSettings.instance.input.gamepadRotateSensitivity =
                            GameInputSettings.GamepadRotateSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["GamepadZoomSensitivity"] != null
                        && SharedSettings.instance.input.gamepadZoomSensitivity
                            != GameInputSettings.GamepadZoomSensitivity
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.gamepadZoomSensitivity'=> '{GameInputSettings.GamepadZoomSensitivity}'"
                            );
                        SharedSettings.instance.input.gamepadZoomSensitivity =
                            GameInputSettings.GamepadZoomSensitivity;
                    }
                    if (
                        jsonObject["GameInputSettings"]["GamepadInvertX"] != null
                        && SharedSettings.instance.input.gamepadInvertX
                            != GameInputSettings.GamepadInvertX
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.gamepadInvertX'=> '{GameInputSettings.GamepadInvertX}'"
                            );
                        SharedSettings.instance.input.gamepadInvertX =
                            GameInputSettings.GamepadInvertX;
                    }
                    if (
                        jsonObject["GameInputSettings"]["GamepadInvertY"] != null
                        && SharedSettings.instance.input.gamepadInvertY
                            != GameInputSettings.GamepadInvertY
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'input.gamepadInvertY'=> '{GameInputSettings.GamepadInvertY}'"
                            );
                        SharedSettings.instance.input.gamepadInvertY =
                            GameInputSettings.GamepadInvertY;
                    }
                }

                if (jsonObject["GameInterfaceSettings"] != null)
                {
                    GameInterfaceSettings GameInterfaceSettings = jsonObject[
                        "GameInterfaceSettings"
                    ]
                        .ToObject<GameInterfaceSettings>();

                    if (
                        jsonObject["GameInterfaceSettings"]["CurrentLocale"] != null
                        && SharedSettings.instance.userInterface.currentLocale
                            != GameInterfaceSettings.CurrentLocale
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.currentLocale'=> '{GameInterfaceSettings.CurrentLocale}'"
                            );
                        SharedSettings.instance.userInterface.currentLocale =
                            GameInterfaceSettings.CurrentLocale;
                    }
                    if (!loadedMods.Contains("ExtraUIScreens"))
                    {
                        if (
                            jsonObject["GameInterfaceSettings"]["InterfaceStyle"] != null
                            && SharedSettings.instance.userInterface.interfaceStyle
                                != GameInterfaceSettings.InterfaceStyle
                        )
                        {
                            i++;
                            if (log)
                                Mod.log.Info(
                                    $"Restoring 'userInterface.interfaceStyle'=> '{GameInterfaceSettings.InterfaceStyle}'"
                                );
                            SharedSettings.instance.userInterface.interfaceStyle =
                                GameInterfaceSettings.InterfaceStyle;
                        }
                    }
                    else
                    {
                        Mod.log.Info("InterfaceStyle ignored because ExtraUIScreen is present.");
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["InterfaceTransparency"] != null
                        && SharedSettings.instance.userInterface.interfaceTransparency
                            != GameInterfaceSettings.InterfaceTransparency
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.interfaceTransparency'=> '{GameInterfaceSettings.InterfaceTransparency}'"
                            );
                        SharedSettings.instance.userInterface.interfaceTransparency =
                            GameInterfaceSettings.InterfaceTransparency;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["InterfaceScaling"] != null
                        && SharedSettings.instance.userInterface.interfaceScaling
                            != GameInterfaceSettings.InterfaceScaling
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.interfaceScaling'=> '{GameInterfaceSettings.InterfaceScaling}'"
                            );
                        SharedSettings.instance.userInterface.interfaceScaling =
                            GameInterfaceSettings.InterfaceScaling;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["TextScale"] != null
                        && SharedSettings.instance.userInterface.textScale
                            != GameInterfaceSettings.TextScale
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.textScale'=> '{GameInterfaceSettings.TextScale}'"
                            );
                        SharedSettings.instance.userInterface.textScale =
                            GameInterfaceSettings.TextScale;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["UnlockHighlightsEnabled"] != null
                        && SharedSettings.instance.userInterface.unlockHighlightsEnabled
                            != GameInterfaceSettings.UnlockHighlightsEnabled
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.unlockHighlightsEnabled'=> '{GameInterfaceSettings.UnlockHighlightsEnabled}'"
                            );
                        SharedSettings.instance.userInterface.unlockHighlightsEnabled =
                            GameInterfaceSettings.UnlockHighlightsEnabled;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["ChirperPopupsEnabled"] != null
                        && SharedSettings.instance.userInterface.chirperPopupsEnabled
                            != GameInterfaceSettings.ChirperPopupsEnabled
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.chirperPopupsEnabled'=> '{GameInterfaceSettings.ChirperPopupsEnabled}'"
                            );
                        SharedSettings.instance.userInterface.chirperPopupsEnabled =
                            GameInterfaceSettings.ChirperPopupsEnabled;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["InputHintsType"] != null
                        && SharedSettings.instance.userInterface.inputHintsType
                            != GameInterfaceSettings.InputHintsType
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.inputHintsType'=> '{GameInterfaceSettings.InputHintsType}'"
                            );
                        SharedSettings.instance.userInterface.inputHintsType =
                            GameInterfaceSettings.InputHintsType;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["KeyboardLayout"] != null
                        && SharedSettings.instance.userInterface.keyboardLayout
                            != GameInterfaceSettings.KeyboardLayout
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.keyboardLayout'=> '{GameInterfaceSettings.KeyboardLayout}'"
                            );
                        SharedSettings.instance.userInterface.keyboardLayout =
                            GameInterfaceSettings.KeyboardLayout;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["TimeFormat"] != null
                        && SharedSettings.instance.userInterface.timeFormat
                            != GameInterfaceSettings.TimeFormat
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.timeFormat'=> '{GameInterfaceSettings.TimeFormat}'"
                            );
                        SharedSettings.instance.userInterface.timeFormat =
                            GameInterfaceSettings.TimeFormat;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["TemperatureUnit"] != null
                        && SharedSettings.instance.userInterface.temperatureUnit
                            != GameInterfaceSettings.TemperatureUnit
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.temperatureUnit'=> '{GameInterfaceSettings.TemperatureUnit}'"
                            );
                        SharedSettings.instance.userInterface.temperatureUnit =
                            GameInterfaceSettings.TemperatureUnit;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["UnitSystem"] != null
                        && SharedSettings.instance.userInterface.unitSystem
                            != GameInterfaceSettings.UnitSystem
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.unitSystem'=> '{GameInterfaceSettings.UnitSystem}'"
                            );
                        SharedSettings.instance.userInterface.unitSystem =
                            GameInterfaceSettings.UnitSystem;
                    }
                    if (
                        jsonObject["GameInterfaceSettings"]["BlockingPopupsEnabled"] != null
                        && SharedSettings.instance.userInterface.blockingPopupsEnabled
                            != GameInterfaceSettings.BlockingPopupsEnabled
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userInterface.blockingPopupsEnabled'=> '{GameInterfaceSettings.BlockingPopupsEnabled}'"
                            );
                        SharedSettings.instance.userInterface.blockingPopupsEnabled =
                            GameInterfaceSettings.BlockingPopupsEnabled;
                    }
                }

                if (jsonObject["GameInputSettings"] != null)
                {
                    GameUserState GameUserState = jsonObject["GameUserState"]
                        .ToObject<GameUserState>();

                    if (
                        jsonObject["GameUserState"]["lastCloudTarget"] != null
                        && SharedSettings.instance.userState.lastCloudTarget
                            != GameUserState.LastCloudTarget
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.lastCloudTarget'=> '{GameUserState.LastCloudTarget}'"
                            );
                        SharedSettings.instance.userState.lastCloudTarget =
                            GameUserState.LastCloudTarget;
                    }
                    if (
                        jsonObject["GameUserState"]["leftHandTraffic"] != null
                        && SharedSettings.instance.userState.leftHandTraffic
                            != GameUserState.LeftHandTraffic
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.leftHandTraffic'=> '{GameUserState.LeftHandTraffic}'"
                            );
                        SharedSettings.instance.userState.leftHandTraffic =
                            GameUserState.LeftHandTraffic;
                    }
                    if (
                        jsonObject["GameUserState"]["naturalDisasters"] != null
                        && SharedSettings.instance.userState.naturalDisasters
                            != GameUserState.NaturalDisasters
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.naturalDisasters'=> '{GameUserState.NaturalDisasters}'"
                            );
                        SharedSettings.instance.userState.naturalDisasters =
                            GameUserState.NaturalDisasters;
                    }
                    if (
                        jsonObject["GameUserState"]["unlockAll"] != null
                        && SharedSettings.instance.userState.unlockAll != GameUserState.UnlockAll
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.unlockAll'=> '{GameUserState.UnlockAll}'"
                            );
                        SharedSettings.instance.userState.unlockAll = GameUserState.UnlockAll;
                    }
                    if (
                        jsonObject["GameUserState"]["unlimitedMoney"] != null
                        && SharedSettings.instance.userState.unlimitedMoney
                            != GameUserState.UnlimitedMoney
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.unlimitedMoney'=> '{GameUserState.UnlimitedMoney}'"
                            );
                        SharedSettings.instance.userState.unlimitedMoney =
                            GameUserState.UnlimitedMoney;
                    }
                    if (
                        jsonObject["GameUserState"]["unlockMapTiles"] != null
                        && SharedSettings.instance.userState.unlockMapTiles
                            != GameUserState.UnlockMapTiles
                    )
                    {
                        i++;
                        if (log)
                            Mod.log.Info(
                                $"Restoring 'userState.unlockMapTiles'=> '{GameUserState.UnlockMapTiles}'"
                            );
                        SharedSettings.instance.userState.unlockMapTiles =
                            GameUserState.UnlockMapTiles;
                    }
                }
                if (i > 0)
                {
                    SharedSettings.instance.Apply();
                    Mod.log.Info(
                        $"Game Settings Restoration Complete: {Path.GetFileName(backupFile)}... {i} options restored."
                    );
                    NotificationSystem.Pop(
                        "starq-smc-game-settings-restore",
                        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                        text: LocalizedString.Id(
                            "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.RestoreGame]"
                        ),
                        delay: 5f
                    );
                    ;
                }
                else
                {
                    Mod.log.Info("No changes found to restore Game Settings...");
                }
            }
            catch (Exception ex)
            {
                Mod.log.Info($"Game Settings Restoration Failed: {ex}");
            }
        }
    }
}
