// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Game.UI.Localization;
using UnityEngine;

namespace SimpleModCheckerPlus
{
    public partial class CocCleaner(Mod instance) : GameSystemBase
    {
        private Mod _instance = instance;
        public Queue<string> CanDelete { get; set; } = [];

        protected override void OnCreate()
        {
            base.OnCreate();
            StartCleaningCoc();
        }

        private void StartCleaningCoc()
        {
            var rootFolderPath = $"{EnvPath.kUserDataPath}";

            LoopThroughFolders(rootFolderPath, CanDelete);

            if (CanDelete.Count > 0)
            {
                NotificationSystem.Push("starq-coc-check",
                    title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.CocChecker]", null,
                        new Dictionary<string, ILocElement>
                        {
                            {"fileCount", LocalizedString.Value(CanDelete.Count.ToString())}
                        }),
                    text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.CocChecker]"),
                    onClicked: DeleteFolders);
            }
        }

        public void DeleteFolders()
        {
            while (CanDelete.Count > 0)
            {
                var file = CanDelete.Dequeue();
                File.Delete(file);
                Mod.log.InfoFormat("Deleted {0}", file);
            }

            Application.Quit(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsLegibleText(string text) =>
            !text.Any(c => char.IsControl(c) && c != '\n' && c != '\r' && c != '\t');


        private static void LoopThroughFolders(string currentPath, Queue<string> canDelete)
        {
            try
            {
                foreach (var file in Directory.GetFiles(currentPath, "*.coc"))
                {
                    if (!IsFileLocked(file))
                    {
                        try
                        {
                            using var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                            using var reader = new StreamReader(fs, Encoding.UTF8);
                            var fileContent = reader.ReadToEnd();

                            if (fileContent.Length == 0)
                            {
                                return;
                            }

                            if (IsLegibleText(fileContent)) continue;
                            canDelete.Enqueue(file);
                            Mod.log.InfoFormat("Scheduled for deletion: {0}", file);
                        }
                        catch (Exception ex)
                        {
                            Mod.log.WarnFormat("Error processing file {0}: {1}", file, ex.Message);
                        }
                    }
                    else
                    {
                        Mod.log.WarnFormat("File inaccessible: {0}", file);
                    }
                }

                foreach (var directory in Directory.GetDirectories(currentPath))
                {
                    LoopThroughFolders(directory, canDelete);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Mod.log.ErrorFormat("Access denied to {0}: {1}", currentPath, e.Message);
            }
            catch (Exception e)
            {
                Mod.log.ErrorFormat("Error processing {0}: {1}", currentPath, e.Message);
            }
        }

        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
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