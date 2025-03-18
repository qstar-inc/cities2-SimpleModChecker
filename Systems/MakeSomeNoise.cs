// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Game.Audio;
using Game.Prefabs;
using Game.SceneFlow;
using Game;
using Mod = SimpleModCheckerPlus.Mod;
using System;
using Unity.Entities;

namespace SimpleModChecker.Systems
{
    public partial class MakeSomeNoise : GameSystemBase
    {
        private EntityQuery m_SoundQuery;

        protected override void OnCreate()
        {
            base.OnCreate();
            GameManager.instance.RegisterUpdater(PlaySound);
        }

        private bool PlaySound()
        {
            if (!GameManager.instance.modManager.isInitialized ||
                GameManager.instance.gameMode != GameMode.MainMenu ||
                GameManager.instance.state == GameManager.State.Loading ||
                GameManager.instance.state == GameManager.State.Booting
            ) return false;

            try
            {
                m_SoundQuery = GetEntityQuery(ComponentType.ReadOnly<ToolUXSoundSettingsData>());
                AudioManager m_AudioManager = AudioManager.instance;
                m_AudioManager.PlayUISound(m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_SelectEntitySound);
            }
            catch (Exception e)
            {
                Mod.log.Info("Failed to play audio: " + e.Message);
            }
            return true;
        }

        protected override void OnUpdate()
        {
            Enabled = false;
        }
    }
}