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
using System.Diagnostics;
using Game.UI.Localization;
using UnityEngine;

namespace SimpleModCheckerPlus
{
    public partial class CIDBackupRestore : GameSystemBase
    {
        public Mod _instance;
        public Queue<string> CanDelete { get; set; } = [];

        public CIDBackupRestore(Mod instance)
        {
            _instance = instance;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            BackupAndRestoreCID();
        }

        private void BackupAndRestoreCID()
        {
            var watch = new Stopwatch();
            watch.Start();

            var rootFolderPath = $"{EnvPath.kUserDataPath}/.cache/Mods/mods_subscribed/";
            foreach (var immediateDirectory in Directory.GetDirectories(rootFolderPath))
            {
                var toBeDeleted = LoopThroughModsSubscribed(immediateDirectory);
                if (toBeDeleted)
                {
                    CanDelete.Enqueue(immediateDirectory);
                }
            }

            if (CanDelete.Count > 0)
            {
                var modList = "";
                foreach (var modId in CanDelete)
                {
                    if (modList == "")
                    {
                        modList += modId.Replace(rootFolderPath, "").Remove(5);
                    }
                    else
                    {
                        modList += ", " + modId.Replace(rootFolderPath, "").Remove(5);
                    }
                }

                var ex = new Exception("Missing_CID_Exception");
                Mod.log.Error(ex,
                    $"Found {CanDelete.Count} mods with missing CID with no backup:\n{modList}\n{Mod.ModName} will handle the deletion of these folders on exit. On next restart, the missing mods will be redownloaded automatically.");
                NotificationSystem.Push("starq-cid-check",
                    title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", null,
                        new Dictionary<string, ILocElement>()
                        {
                            {"modCount", LocalizedString.Value(CanDelete.Count.ToString())}
                        }),
                    text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]"),
                    onClicked: DeleteFolders);
            }

            watch.Stop();
            var timeTaken = watch.Elapsed;
            Mod.log.Info($"CID Backup and Restore took {timeTaken.TotalSeconds}s");
        }

        public void DeleteFolders()
        {
            while (CanDelete.Count > 0)
            {
                var directory = CanDelete.Dequeue();
                Directory.Delete(directory, true);
                Mod.log.InfoFormat("Deleted {0}", directory);
            }

            Application.Quit(0);
        }

        private static bool LoopThroughModsSubscribed(string directoryPath)
        {
            string[] validExtensions = [".Prefab", ".cok", ".Texture", ".Geometry", ".Surface"];
            var hasValidFile = false;

            var files = Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories)
                .Where(file => validExtensions.Contains(Path.GetExtension(file)));

            if (!files.Any())
            {
                return false;
            }

            foreach (var file in files)
            {
                var cidFilePath = file + ".cid";
                var cidBakFilePath = file + ".cid.bak";
                var cidBackupFilePath = file + ".cid.backup";

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
                    Mod.log.InfoFormat("CID not found: {0}", file);
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