using Colossal.PSI.Environment;
using Game;
using System.IO;
using Game.Settings;
using Game.PSI;

namespace SimpleModChecker
{
    public partial class SettingsChanger : GameSystemBase
    {
        public Mod _mod;
        public string settingFile = $"{EnvPath.kUserDataPath}\\Settings.coc";

        public SettingsChanger(Mod mod)
        {
            _mod = mod;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckSettingsFile();
        }

        private void CheckSettingsFile()
        {
            if (File.Exists(settingFile))
            {
                string content = File.ReadAllText(settingFile);

            if (string.IsNullOrWhiteSpace(content))
                {
                    if (Mod.Setting.EnableAutoSave)
                    {
                        EnableAutoSave();
                    }
                    if (Mod.Setting.DisableRadio)
                    {
                        DisableRadio();
                    }
                }
            }
            else
            {
                if (Mod.Setting.EnableAutoSave)
                {
                    EnableAutoSave();
                }
                if (Mod.Setting.DisableRadio)
                {
                    DisableRadio();
                }
            }

        }

        private void EnableAutoSave()
        {
            SharedSettings.instance.general.autoSave = true;
            Mod.log.Info("Autosave enabled");
            NotificationSystem.Pop(identifier: "starq-auto-save-restored", delay: 10f, title: Mod.ModName, text: "Auto Save enabled");
        }
        private void DisableRadio()
        {
            SharedSettings.instance.audio.radioActive = false;
            Mod.log.Info("Radio disabled");
            NotificationSystem.Pop(identifier: "starq-radio-disabled", delay: 10f, title: Mod.ModName, text: "Radio disabled");
        }

        protected override void OnUpdate()
        {

        }
    }
}
