// Simple Mod Checker
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

namespace SimpleModChecker
{
    public partial class CocCleaner : GameSystemBase
    {
        public Mod _mod;
        public List<string> deleteables = [];

        public CocCleaner(Mod mod)
        {
            _mod = mod;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            StartCleaningCoc();
        }

        private void StartCleaningCoc()
        {
            string rootFolderPath = $"{EnvPath.kUserDataPath}";
            
            LoopThroughFolders(rootFolderPath, deleteables);
           
            if (deleteables.Count > 0)
            {
                NotificationSystem.Push("starq-coc-check",
                        title: $"{Mod.ModName}: Found {deleteables.Count} corrupted Settings file",
                        text: $"Click here to delete and restart to prevent errors...",
                        onClicked: () => DeleteFolders());
            }

        }

        public void DeleteFolders()
        {
            foreach (var file in deleteables)
            {
                File.Delete(file);
                Mod.log.Info($"Deleted {file}");
            }
            Application.Quit(0);
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
                    try
                    {
                        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                            {
                                string fileContent = reader.ReadToEnd();

                                if (fileContent.Length == 0)
                                {
                                    return;
                                }
                                
                                if(!IsLegibleText(fileContent))
                                {
                                    deleteables.Add(file);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Mod.log.Error($"Error processing file {file}: {ex.Message}");
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
        
        protected override void OnUpdate()
        {
        }
    }
}