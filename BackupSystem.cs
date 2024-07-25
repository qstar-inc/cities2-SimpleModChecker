// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.PSI.Environment;
using Game.PSI;
using Game;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;

namespace SimpleModCheckerPlus
{
    public partial class CIDBackupRestore : GameSystemBase
    {
        public Mod _mod;
        public List<string> deleteables = [];

        public CIDBackupRestore(Mod mod)
        {
            _mod = mod;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            BackupAndRestoreCID();
        }

        private void BackupAndRestoreCID()
        {
            DateTime CIDManagerStart = DateTime.Now;

            string rootFolderPath = $"{EnvPath.kUserDataPath}/.cache/Mods/mods_subscribed/";
            foreach (var immediateDirectory in Directory.GetDirectories(rootFolderPath))
            {
                bool toBeDeleted = LoopThroughModsSubscribed(immediateDirectory);
                if (toBeDeleted)
                {
                    deleteables.Add(immediateDirectory);
                }
            }
            if (deleteables.Count > 0)
            {
                string modList = "";
                foreach (var modID in deleteables)
                {
                    if (modList == "")
                    {
                        modList += modID.Replace(rootFolderPath, "").Remove(5).ToString();
                    }
                    else
                    {
                        modList += ", " + modID.Replace(rootFolderPath, "").Remove(5).ToString();
                    }
                }
                    Exception ex = new Exception("Missing_CID_Exception");
                Mod.log.Error(ex, $"Found {deleteables.Count} mods with missing CID with no backup:\n{modList}\n{Mod.ModName} will handle the deletion of these folders on exit. On next restart, the missing mods will be redownloaded automatically.");
                NotificationSystem.Push("starq-cid-check",
                        title: $"{Mod.ModName}: Found {deleteables.Count} mod(s) with missing CIDs",
                        text: $"Click here to delete and restart to prevent errors...",
                        onClicked: () => DeleteFolders());
            }
            DateTime CIDManagerEnd = DateTime.Now;
            TimeSpan timeTaken = CIDManagerEnd - CIDManagerStart;
            Mod.log.Info($"CID Backup and Restore took {timeTaken.TotalSeconds}s");

        }

        public void DeleteFolders()
        {
            foreach (var directory in deleteables)
            {
                Directory.Delete(directory, true);
                Mod.log.Info($"Deleted {directory}");
            }
            Application.Quit(0);
        }

        private static bool LoopThroughModsSubscribed(string directoryPath)
        {
            string[] validExtensions = { ".Prefab", ".cok", ".Texture", ".Geometry", ".Surface" };
            bool hasValidFile = false;

            var files = Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories)
                                 .Where(file => validExtensions.Contains(Path.GetExtension(file)));

            if (!files.Any())
            {
                return false;
            }

            foreach (var file in files)
            {
                string cidFilePath = file + ".cid";
                string cidBakFilePath = file + ".cid.bak";
                string cidBackupFilePath = file + ".cid.backup";

                if (File.Exists(cidFilePath))
                {
                    hasValidFile = true;
                    if (!File.Exists(cidBackupFilePath))
                    {
                        //Mod.log.Info($"CID backup created: {file}");
                        File.Copy(cidFilePath, cidBackupFilePath);
                    }
                }
                else if (File.Exists(cidBakFilePath))
                {
                    File.Copy(cidBakFilePath, cidFilePath);
                    //Mod.log.Info($"CID backup restored: {file}");
                    hasValidFile = true;
                }
                else if (File.Exists(cidBackupFilePath))
                {
                    File.Copy(cidBackupFilePath, cidFilePath);
                    //Mod.log.Info($"CID backup restored: {file}");
                    hasValidFile = true;
                }
                else
                {
                    Mod.log.Info($"CID not found: {file}");
                    return true;
                }
            }
            return !hasValidFile;
        }
        protected override void OnUpdate()
        {
        }
    }
}