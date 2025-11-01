using System;
using System.IO;
using Colossal.PSI.Environment;
using Game;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarQ.Shared.Extensions;

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
                    Profile1 = Mod.m_Setting.ProfileName1,
                    Profile2 = Mod.m_Setting.ProfileName2,
                    Profile3 = Mod.m_Setting.ProfileName3,
                    Profile4 = Mod.m_Setting.ProfileName4,
                    Profile5 = Mod.m_Setting.ProfileName5,
                    Profile6 = Mod.m_Setting.ProfileName6,
                    Profile7 = Mod.m_Setting.ProfileName7,
                    Profile8 = Mod.m_Setting.ProfileName8,
                    Profile9 = Mod.m_Setting.ProfileName9,
                };

                string jsonString = JsonConvert.SerializeObject(ProfileNames, Formatting.Indented);
                File.WriteAllText(backupFile, jsonString);
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
        }

        public void RestoreBackup()
        {
            LogHelper.SendLog($"Restore backup {backupFile}");
            try
            {
                if (!File.Exists(backupFile))
                {
                    LogHelper.SendLog($"{backupFile} doesn't exist");
                    return;
                }
                string jsonString = File.ReadAllText(backupFile);

                JObject jsonObject = JObject.Parse(jsonString);
                if (jsonObject != null)
                {
                    ProfileNames ProfileNames = jsonObject.ToObject<ProfileNames>();
                    //LogHelper.SendLog(ProfileNames.Profile1);
                    if (Mod.m_Setting.ProfileName1 != ProfileNames.Profile1)
                        Mod.m_Setting.ProfileName1 = ProfileNames.Profile1;
                    if (Mod.m_Setting.ProfileName2 != ProfileNames.Profile2)
                        Mod.m_Setting.ProfileName2 = ProfileNames.Profile2;
                    if (Mod.m_Setting.ProfileName3 != ProfileNames.Profile3)
                        Mod.m_Setting.ProfileName3 = ProfileNames.Profile3;
                    if (Mod.m_Setting.ProfileName4 != ProfileNames.Profile4)
                        Mod.m_Setting.ProfileName4 = ProfileNames.Profile4;
                    if (Mod.m_Setting.ProfileName5 != ProfileNames.Profile5)
                        Mod.m_Setting.ProfileName5 = ProfileNames.Profile5;
                    if (Mod.m_Setting.ProfileName6 != ProfileNames.Profile6)
                        Mod.m_Setting.ProfileName6 = ProfileNames.Profile6;
                    if (Mod.m_Setting.ProfileName7 != ProfileNames.Profile7)
                        Mod.m_Setting.ProfileName7 = ProfileNames.Profile7;
                    if (Mod.m_Setting.ProfileName8 != ProfileNames.Profile8)
                        Mod.m_Setting.ProfileName8 = ProfileNames.Profile8;
                    if (Mod.m_Setting.ProfileName9 != ProfileNames.Profile9)
                        Mod.m_Setting.ProfileName9 = ProfileNames.Profile9;
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
            ++Mod.m_Setting.ProfileListVersion;
        }
    }
}
