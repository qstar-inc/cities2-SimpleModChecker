// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.IO;
using Colossal.PSI.Environment;
using Game;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleModCheckerPlus;

namespace SimpleModCheckerPlus.Systems
{
    public class ProfileNames
    {
        public string Profile1 { get; set; }
        public string Profile2 { get; set; }
        public string Profile3 { get; set; }
        public string Profile4 { get; set; }
        public string Profile5 { get; set; }
        public string Profile6 { get; set; }
        public string Profile7 { get; set; }
        public string Profile8 { get; set; }
        public string Profile9 { get; set; }
    }

    public partial class ProfileNameBackup : GameSystemBase
    {
        public Mod _mod;
        private readonly string backupFile =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\ProfileNameBackup.json";

        protected override void OnCreate()
        {
            if (File.Exists(backupFile))
            {
                RestoreBackup();
            }
        }

        protected override void OnUpdate() { }

        public void CreateBackup()
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(backupFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var ProfileNames = new ProfileNames
                {
                    Profile1 = Mod.Setting.ProfileName1,
                    Profile2 = Mod.Setting.ProfileName2,
                    Profile3 = Mod.Setting.ProfileName3,
                    Profile4 = Mod.Setting.ProfileName4,
                    Profile5 = Mod.Setting.ProfileName5,
                    Profile6 = Mod.Setting.ProfileName6,
                    Profile7 = Mod.Setting.ProfileName7,
                    Profile8 = Mod.Setting.ProfileName8,
                    Profile9 = Mod.Setting.ProfileName9,
                };

                string jsonString = JsonConvert.SerializeObject(ProfileNames, Formatting.Indented);
                File.WriteAllText(backupFile, jsonString);
            }
            catch (Exception ex)
            {
                Mod.log.Info(ex);
            }
        }

        public void RestoreBackup()
        {
            Mod.log.Info($"Restore backup {backupFile}");
            try
            {
                if (!File.Exists(backupFile))
                {
                    Mod.log.Info($"{backupFile} doesn't exist");
                    return;
                }
                string jsonString = File.ReadAllText(backupFile);

                JObject jsonObject = JObject.Parse(jsonString);
                if (jsonObject != null)
                {
                    ProfileNames ProfileNames = jsonObject.ToObject<ProfileNames>();
                    //Mod.log.Info(ProfileNames.Profile1);
                    if (Mod.Setting.ProfileName1 != ProfileNames.Profile1)
                        Mod.Setting.ProfileName1 = ProfileNames.Profile1;
                    if (Mod.Setting.ProfileName2 != ProfileNames.Profile2)
                        Mod.Setting.ProfileName2 = ProfileNames.Profile2;
                    if (Mod.Setting.ProfileName3 != ProfileNames.Profile3)
                        Mod.Setting.ProfileName3 = ProfileNames.Profile3;
                    if (Mod.Setting.ProfileName4 != ProfileNames.Profile4)
                        Mod.Setting.ProfileName4 = ProfileNames.Profile4;
                    if (Mod.Setting.ProfileName5 != ProfileNames.Profile5)
                        Mod.Setting.ProfileName5 = ProfileNames.Profile5;
                    if (Mod.Setting.ProfileName6 != ProfileNames.Profile6)
                        Mod.Setting.ProfileName6 = ProfileNames.Profile6;
                    if (Mod.Setting.ProfileName7 != ProfileNames.Profile7)
                        Mod.Setting.ProfileName7 = ProfileNames.Profile7;
                    if (Mod.Setting.ProfileName8 != ProfileNames.Profile8)
                        Mod.Setting.ProfileName8 = ProfileNames.Profile8;
                    if (Mod.Setting.ProfileName9 != ProfileNames.Profile9)
                        Mod.Setting.ProfileName9 = ProfileNames.Profile9;
                }
            }
            catch (Exception ex)
            {
                Mod.log.Info(ex);
            }
            ++Mod.Setting.ProfileListVersion;
        }
    }
}
