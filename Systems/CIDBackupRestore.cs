// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Game.PSI;
using Game.UI.Localization;
using Game;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;
using SimpleModCheckerPlus;
using Game.Routes;

namespace SimpleModChecker.Systems
{
    public partial class CIDBackupRestore : GameSystemBase
    {
        public Mod _mod;
        public static List<PDX.SDK.Contracts.Service.Mods.Models.Mod> CanDelete = [];

        protected override void OnCreate()
        {
            base.OnCreate();
            BackupAndRestoreCID();
        }

        private void BackupAndRestoreCID()
        {
            DateTime CIDManagerStart = DateTime.Now;

            foreach (PDX.SDK.Contracts.Service.Mods.Models.Mod mod in ModCheckup.allMods.Values)
            {
                string immediateDirectory = mod.LocalData?.FolderAbsolutePath;
                if (!Directory.Exists(immediateDirectory))
                {
                    continue;
                }
                bool toBeDeleted = LoopThroughModsSubscribed(immediateDirectory);
                if (toBeDeleted)
                {
                    CanDelete.Add(mod);
                }
            }
            if (CanDelete.Count > 0)
            {
                string modList = "";
                foreach (PDX.SDK.Contracts.Service.Mods.Models.Mod mod in CanDelete)
                {
                    modList += $"- {mod.DisplayName} ({mod.Id}) by {mod.Author}\n";
                }

                string plural = "mods";
                if (CanDelete.Count == 1) plural = "mod";
                
                if (Mod.Setting.DeleteMissing)
                {
                    string errorText = $"Found {CanDelete.Count} {plural} with missing/invalid CID with no backup:\n{modList}\n{Mod.Name} will handle the deletion of these folders on exit. On next restart, the missing {plural} will be redownloaded automatically. If this persists, contact the author of the {plural} listed above.";
                    Exception ex = new("Missing_CID_Exception");
                    Mod.log.Error(ex, errorText);
                }
                else
                {
                    string errorText = $"Found {CanDelete.Count} {plural} with missing/invalid CID with no backup:\n{modList}\nDelete missing CID option is disabled in {Mod.Name} options, so it will not be deleted.";
                    Mod.log.Info(errorText);
                }

                NotificationSystem.Push("starq-smc-cid-check",
                        title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", null,
                            new Dictionary<string, ILocElement>
                            {
                                {"modCount", LocalizedString.Value(CanDelete.Count.ToString())},
                            }),
                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]"),
                        onClicked: () => {
                            DeleteFolders("Click");
                            NotificationSystem.Pop("starq-smc-cid-check");
                        });
            }
            DateTime CIDManagerEnd = DateTime.Now;
            TimeSpan timeTaken = CIDManagerEnd - CIDManagerStart;
            Mod.log.Info($"CID Backup and Restore took {timeTaken.TotalSeconds}s");

        }

        public static void DeleteFolders(string Method = null)
        {
            Mod.log.Info($"Deleting {CanDelete.Count} folders for missing CID.");
            for (int i = CanDelete.Count - 1; i >= 0; i--)
            {
                Directory.Delete(CanDelete[i].LocalData.FolderAbsolutePath, true);
                Mod.log.Info($"Deleted {CanDelete[i].DisplayName} ({CanDelete[i].Id})");
                CanDelete.RemoveAt(i);
            }

            if (Method == "Click")
            {
                NotificationSystem.Pop("starq-smc-cid-check");
                Application.Quit(0);
            }
        }

        private static bool LoopThroughModsSubscribed(string directoryPath)
        {
            string[] validExtensions = [".Prefab", ".cok", ".Texture", ".Geometry", ".Surface"];
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
                    if (File.Exists(cidBackupFilePath))
                    {
                        string actualCid = File.Exists(cidFilePath) ? File.ReadAllText(cidFilePath) : "";
                        string backupCid = File.Exists(cidBackupFilePath) ? File.ReadAllText(cidBackupFilePath) : "";

                        if (actualCid != backupCid)
                        {
                            hasValidFile = false;
                            Mod.log.Info($"CID mismatched: {file}");
                        }
                    }
                    else
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