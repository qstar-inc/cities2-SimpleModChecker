// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game.UI.Localization;
using Game;
using SimpleModCheckerPlus;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

namespace SimpleModChecker.Systems
{
    public partial class CocCleaner(Mod mod) : GameSystemBase
    {
        public Mod _mod = mod;
        public List<string> CanDelete = [];

        protected override void OnCreate()
        {
            base.OnCreate();
            StartCleaningCoc();
        }

        private void StartCleaningCoc()
        {
            string rootFolderPath = $"{EnvPath.kUserDataPath}";

            LoopThroughFolders(rootFolderPath, CanDelete);

            if (CanDelete.Count > 0)
            {
                NotificationSystem.Push("starq-smc-coc-check",
                        title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]", null,
                            new Dictionary<string, ILocElement>
                            {
                                {"fileCount", LocalizedString.Value(CanDelete.Count.ToString())}
                            }),
                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]"),
                        onClicked: () => DeleteFolders("Click"));
            }

        }

        public void DeleteFolders(string Method = null)
        {
            for (int i = CanDelete.Count - 1; i >= 0; i--)
            {
                File.Delete(CanDelete[i]);
                Mod.log.Info($"Deleted {CanDelete[i]}");
                CanDelete.RemoveAt(i);
            }

            if (Method == "Click")
            {
                Application.Quit(0);
            }
        }

        public static bool IsLegibleText(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsControl(c) || c == '\n' || c == '\r' || c == '\t')
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private static void LoopThroughFolders(string currentPath, List<string> deleteables)
        {
            try
            {
                foreach (string file in Directory.GetFiles(currentPath, "*.coc"))
                {
                    if (!IsFileLocked(file))
                    {
                        try
                        {
                            using FileStream fs = new(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                            using StreamReader reader = new(fs, Encoding.UTF8);
                            string fileContent = reader.ReadToEnd();

                            if (fileContent.Length == 0)
                            {
                                return;
                            }

                            if (!IsLegibleText(fileContent))
                            {
                                deleteables.Add(file);
                                Mod.log.Info($"Scheduled for deletion: {file}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Mod.log.Info($"Error processing file {file}: {ex.Message}");
                        }
                    }
                    else
                    {
                        Mod.log.Info($"File inaccessible: {file}");
                    }
                }

                foreach (string directory in Directory.GetDirectories(currentPath))
                {
                    LoopThroughFolders(directory, deleteables);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Mod.log.Error($"Access denied to {currentPath}: {e.Message}");
            }
            catch (Exception e)
            {
                Mod.log.Error($"Error processing {currentPath}: {e.Message}");
            }
        }

        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                fs.Close();
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        protected override void OnUpdate()
        {
        }
    }
}