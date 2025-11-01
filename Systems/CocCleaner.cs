using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Colossal.PSI.Environment;
using Game;
using Game.PSI;
using Game.UI.Localization;
using StarQ.Shared.Extensions;
using UnityEngine;

namespace SimpleModCheckerPlus.Systems
{
    public partial class CocCleaner : GameSystemBase
    {
        public Mod _mod;
        public static List<string> CanDelete { get; } = new();

        protected override void OnCreate()
        {
            base.OnCreate();
            StartCleaningCoc();
        }

        private void StartCleaningCoc()
        {
            string rootFolderPath = EnvPath.kUserDataPath;

            LoopThroughFolders(rootFolderPath);

            if (CanDelete.Count > 0)
            {
                string notifPrefix = $"{Mod.Id}.CocCleaner";
                NotificationSystem.Push(
                    "starq-smc-coc-check",
                    title: new LocalizedString(
                        $"{notifPrefix}.Title",
                        null,
                        new Dictionary<string, ILocElement>
                        {
                            { "FileCount", LocalizedString.Value(CanDelete.Count.ToString()) },
                        }
                    ),
                    text: LocalizedString.Id($"{notifPrefix}.Desc"),
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
            foreach (var file in CanDelete.ToList())
            {
                try
                {
                    File.Delete(file);
                    LogHelper.SendLog($"Deleted {file}");
                    CanDelete.Remove(file);
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog($"Failed to delete {file}: {ex.Message}", LogLevel.Error);
                }
            }

            if (Method == "Click")
            {
                Application.Quit(0);
            }
        }

        public static bool IsLegibleText(string text)
        {
            return text.All(c => !char.IsControl(c) || c == '\n' || c == '\r' || c == '\t');
        }

        private static void LoopThroughFolders(string path)
        {
            try
            {
                foreach (string file in Directory.GetFiles(path, "*.coc"))
                    ProcessFile(file);

                foreach (var dir in Directory.GetDirectories(path))
                    LoopThroughFolders(dir);
            }
            catch (UnauthorizedAccessException e)
            {
                LogHelper.SendLog($"Access denied to {path}: {e.Message}", LogLevel.Error);
            }
            catch (Exception e)
            {
                LogHelper.SendLog($"Error processing {path}: {e.Message}", LogLevel.Error);
            }
        }

        public static void ProcessFile(string file)
        {
            if (file.Contains(".SupportLogs"))
                return;
            if (IsFileLocked(file))
            {
                LogHelper.SendLog($"File inaccessible: {file}");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(file, Encoding.UTF8)
                    .Select(l => l?.Trim())
                    .Where(l => !string.IsNullOrEmpty(l))
                    .ToArray();

                string firstLine = lines.ElementAtOrDefault(0);
                string secondLine = lines.ElementAtOrDefault(1);
                string lastLine = lines.LastOrDefault();

                bool emptyFile = lines.Length == 0;
                bool invalidStructure = firstLine == null || secondLine != "{" || lastLine != "}";
                bool illegibleText = !IsLegibleText(string.Join("", lines));

                if (emptyFile)
                    LogHelper.SendLog($"{file} looks empty");
                else if (invalidStructure)
                    LogHelper.SendLog($"{file} doesn't look right");
                else if (illegibleText)
                    LogHelper.SendLog($"{file} is illegible");

                if (emptyFile || invalidStructure || illegibleText)
                    CanDelete.Add(file);
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Error processing file {file}: {ex.Message}");
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
