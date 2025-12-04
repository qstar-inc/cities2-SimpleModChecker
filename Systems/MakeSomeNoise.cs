using System;
using Game;
using Game.Audio;
using Game.Prefabs;
using Game.SceneFlow;
using StarQ.Shared.Extensions;
using Unity.Entities;

namespace SimpleModCheckerPlus.Systems
{
    public partial class MakeSomeNoise : GameSystemBase
    {
        private EntityQuery m_SoundQuery;

        protected override void OnCreate()
        {
            base.OnCreate();
            Colossal.Core.MainThreadDispatcher.RegisterUpdater(PlaySound);
        }

        private bool PlaySound()
        {
            Enabled = false;
            if (
                !GameManager.instance.modManager.isInitialized
                || GameManager.instance.gameMode != GameMode.MainMenu
                || GameManager.instance.state == GameManager.State.Loading
                || GameManager.instance.state == GameManager.State.Booting
            )
                return false;

            try
            {
                m_SoundQuery = GetEntityQuery(ComponentType.ReadOnly<ToolUXSoundSettingsData>());
                AudioManager m_AudioManager = AudioManager.instance;
                m_AudioManager.PlayUISound(
                    m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_SelectEntitySound
                );
            }
            catch (Exception e)
            {
                LogHelper.SendLog("Failed to play audio: " + e.Message);
            }
            return true;
        }

        protected override void OnUpdate() { }
    }
}
