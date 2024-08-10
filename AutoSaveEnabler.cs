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
using Game.UI.Localization;

namespace SimpleModCheckerPlus
{
    public partial class SettingsChanger(Mod instance) : GameSystemBase
    {
        public Mod _instance = instance;
        private readonly string _settingFile = $"{EnvPath.kUserDataPath}\\Settings.coc";

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckSettingsFile();
        }

        private void CheckSettingsFile()
        {
            if (File.Exists(_settingFile))
            {
                if (!CocCleaner.IsFileLocked(_settingFile))
                {
                    try
                    {
                        using var fs = new FileStream(_settingFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                        using var reader = new StreamReader(fs, Encoding.UTF8);
                        var fileContent = reader.ReadToEnd();

                        if (fileContent.Length != 0 && !string.IsNullOrWhiteSpace(fileContent)) return;
                        if (Mod.Setting.EnableAutoSave)
                        {
                            EnableAutoSave();
                        }
                        if (Mod.Setting.DisableRadio)
                        {
                            DisableRadio();
                        }
                    }
                    catch (Exception ex)
                    {
                        Mod.log.Info($"Error reading file: {ex.Message}");
                    }
                }
                else
                {
                    Mod.log.Info($"File inaccessible: {_settingFile}");
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
            NotificationSystem.Pop(identifier: "starq-auto-save-restored", delay: 10f, title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"), text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoSave]"));
        }

        private void DisableRadio()
        {
            SharedSettings.instance.audio.radioActive = false;
            Mod.log.Info("Radio disabled");
            NotificationSystem.Pop(identifier: "starq-radio-disabled", delay: 10f, title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"), text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DisableRadio]"));
        }

        protected override void OnUpdate()
        {

        }
    }
}
