// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game.Settings;
using Game;
using System.IO;
using System.Text;
using System;

namespace SimpleModCheckerPlus
{
    public partial class SettingsChanger(Mod mod) : GameSystemBase
    {
        public Mod _mod = mod;
        public string settingFile = $"{EnvPath.kUserDataPath}\\Settings.coc";

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckSettingsFile();
        }

        private void CheckSettingsFile()
        {
            if (File.Exists(settingFile))
            {
                if (!CocCleaner.IsFileLocked(settingFile))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(settingFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                            {
                                string fileContent = reader.ReadToEnd();

                                if (fileContent.Length == 0 || string.IsNullOrWhiteSpace(fileContent))
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
                        }
                    }
                    catch (Exception ex)
                    {
                        Mod.log.Info($"Error reading file: {ex.Message}");
                    }
                }
                else
                {
                    Mod.log.Info($"File inaccessible: {settingFile}");
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
