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
using Game.UI.Localization;

namespace SimpleModCheckerPlus
{
    public partial class CIDBackupRestore(Mod mod) : GameSystemBase
    {
        public Mod _mod = mod;
        public List<string> CanDelete = [];

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
                    CanDelete.Add(immediateDirectory);
                }
            }
            if (CanDelete.Count > 0)
            {
                string modList = "";
                foreach (var modID in CanDelete)
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
                Exception ex = new("Missing_CID_Exception");
                //Mod.log.Error(ex, new LocalizedString("Menu.ERROR[SimpleModCheckerPlus.Missing_CID_Exception]", null,
                //            new Dictionary<string, ILocElement>
                //            {
                //                {"modCount", LocalizedString.Value(CanDelete.Count.ToString())},
                //                {"modList", LocalizedString.Value(modList)},
                //            }));
                Mod.log.Error(ex, $"Found {CanDelete.Count} mods with missing CID with no backup:\n{modList}\n{Mod.Name} will handle the deletion of these folders on exit. On next restart, the missing mods will be redownloaded automatically.");
                NotificationSystem.Push("starq-smc-cid-check",
                        title: new LocalizedString("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.DeleteMods]", null,
                            new Dictionary<string, ILocElement>
                            {
                                {"modCount", LocalizedString.Value(CanDelete.Count.ToString())},
                            }),
                        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.DeleteMods]"),
                        onClicked: () => DeleteFolders("Click"));
            }
            DateTime CIDManagerEnd = DateTime.Now;
            TimeSpan timeTaken = CIDManagerEnd - CIDManagerStart;
            Mod.log.Info($"CID Backup and Restore took {timeTaken.TotalSeconds}s");

        }

        public void DeleteFolders(string Method = null)
        {
            Mod.log.Info(CanDelete.Count);
            for (int i = CanDelete.Count - 1; i >= 0; i--)
            {
                Directory.Delete(CanDelete[i], true);
                Mod.log.Info($"Deleted {CanDelete[i]}");
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