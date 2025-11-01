using System;
using System.IO;
using Colossal.PSI.Environment;
using StarQ.Shared.Extensions;

namespace SimpleModCheckerPlus.Systems
{
    public class MakeBackupOfModsData
    {
        public static void MakePrev()
        {
            string sourcePath = Path.Combine(
                EnvPath.kUserDataPath,
                "ModsData",
                "SimpleModChecker",
                "SettingsBackup"
            );

            if (!Directory.Exists(sourcePath))
                return;

            string destinationPath = Path.Combine(sourcePath, "_prev");
            Directory.CreateDirectory(destinationPath);

            foreach (var file in Directory.EnumerateFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Equals("_prev", StringComparison.OrdinalIgnoreCase))
                    continue;
                string destinationFile = Path.Combine(destinationPath, fileName);
                try
                {
                    File.Copy(file, destinationFile, overwrite: true);
                    LogHelper.SendLog($"Copied {fileName} to _prev backup", LogLevel.DEV);
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog($"Failed to copy {fileName}: {ex.Message}", LogLevel.Warn);
                }
            }
        }
    }
}
