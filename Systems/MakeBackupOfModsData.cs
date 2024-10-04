// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using System.IO;

namespace SimpleModChecker.Systems
{
    public class MakeBackupOfModsData 
    {
        public static void MakePrev()
        {
            string sourcePath = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup";
            if (Directory.Exists(sourcePath))
            {
                string destinationPath = Path.Combine(sourcePath,"_prev");
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }
                var files = Directory.GetFiles(sourcePath);

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFile = Path.Combine(destinationPath, fileName);
                    if (!fileName.Equals("_prev"))
                    {
                        File.Copy(file, destinationFile, overwrite: true);
                    }
                }
            }
        }
    }
}
