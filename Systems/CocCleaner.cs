// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Colossal.PSI.Environment;
using Game;
using Game.PSI;
using Game.UI.Localization;
using UnityEngine;

namespace SimpleModCheckerPlus.Systems
{
    public partial class CocCleaner : GameSystemBase
    {
        public Mod _mod;
        public static List<string> CanDelete = new();

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
                NotificationSystem.Push(
                    "starq-smc-coc-check",
                    title: new LocalizedString(
                        "Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]",
                        null,
                        new Dictionary<string, ILocElement>
                        {
                            { "fileCount", LocalizedString.Value(CanDelete.Count.ToString()) },
                        }
                    ),
                    text: LocalizedString.Id(
                        "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]"
                    ),
                    onClicked: () =>
                    {
                        DeleteFolders("Click");
                        NotificationSystem.Pop("starq-smc-coc-check");
                    }
                );
            }
        }

        public static void DeleteFolders(string Method = null)
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
                            using FileStream fs = new(
                                file,
                                FileMode.Open,
                                FileAccess.Read,
                                FileShare.Read
                            );
                            using StreamReader reader = new(fs, Encoding.UTF8);

                            string firstLine = null;
                            string secondLine = null;
                            string lastLine = null;

                            if (!reader.EndOfStream)
                            {
                                firstLine = reader.ReadLine()?.Trim();
                            }

                            if (!reader.EndOfStream)
                            {
                                secondLine = reader.ReadLine()?.Trim();
                            }

                            string currentLine;
                            while (!reader.EndOfStream)
                            {
                                currentLine = reader.ReadLine()?.Trim();
                                if (!string.IsNullOrEmpty(currentLine))
                                {
                                    lastLine = currentLine;
                                }
                            }

                            if (
                                string.IsNullOrEmpty(firstLine)
                                && string.IsNullOrEmpty(secondLine)
                                && string.IsNullOrEmpty(lastLine)
                            )
                            {
                                Mod.log.Info($"{file} looks empty");
                                deleteables.Add(file);
                            }
                            else if (firstLine == null || secondLine != "{" || lastLine != "}")
                            {
                                Mod.log.Info($"{file} doesn't look right");
                                deleteables.Add(file);
                            }
                            else if (!IsLegibleText(firstLine + secondLine + lastLine))
                            {
                                Mod.log.Info($"{file} is eligible");
                                deleteables.Add(file);
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
                using FileStream fs = File.Open(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None
                );
                fs.Close();
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        protected override void OnUpdate() { }
    }
}
