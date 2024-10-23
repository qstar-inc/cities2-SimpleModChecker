// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using Colossal.Serialization.Entities;
using Game.PSI;
using Game.SceneFlow;
using Game.UI.Localization;
using Game.UI.Menu;
using Game;
using SimpleModCheckerPlus;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SimpleModChecker.Systems
{
    public partial class ModNotification : GameSystemBase
    {
        public Mod _mod;
        private int count;
        public static List<string> loadedMods = [];

        public static Dictionary<string, ModInfo> LoadedModsInDatabase = [];
        public static Dictionary<string, ModInfo> LoadedModsNotInDatabase = [];

        public static OptionsUISystem uISystem = new();
        public static string LoadedModsList { get; set; } = "";

        public static LocalizedString LoadedModsListLocalized()
        {
            return LocalizedString.Id(LoadedModsList);
        }

        public List<string> GetLoadedMods()
        {
            return loadedMods;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckMod();
            //CleanFolders();
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            if (mode.IsGameOrEditor())
            {
                RemoveNotification();
            }
            else
            {
                if (Mod.Setting.ShowNotif)
                {
                    SendNotification(count);
                }
            }
        }
        protected override void OnUpdate()
        {
        }

        private void CheckMod()
        {
            try
            {
                count = 0;

                foreach (var modInfo in GameManager.instance.modManager)
                {
                    string modName = modInfo.asset.name;
                    if (!loadedMods.Contains(modName) && !modName.StartsWith("Colossal."))
                    {
                        loadedMods.Add(modName);
                        ModInfo mod = ModDatabase.ModDatabaseInfo.Values.FirstOrDefault(m => m.AssemblyName == modName);
                        if (mod != null)
                        {
                            LoadedModsInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = mod.FragmentSource, ClassType = mod.ClassType, Author = mod.Author, ModName = mod.ModName, PDX_ID = mod.PDX_ID });
                        }
                        else
                        {
                            LoadedModsNotInDatabase.Add(modName, new ModInfo { AssemblyName = modName, FragmentSource = null, ClassType = null, Author = null, ModName = null, PDX_ID = null });
                        }
                        count += 1;
                        Mod.log.Info($"Loaded: {modName}");
                    }
                    else if (!loadedMods.Contains(modName))
                    {
                        Mod.log.Info($"Ignoring {modName}");
                    }
                }
                Mod.log.Info($"Total mod(s): {count}");
                if (Mod.Setting.ShowNotif)
                {
                    SendNotification(count);
                }
                List<ModInfo> sortedMods1 = ModInfoProcessor.SortByModName(LoadedModsInDatabase);
                List<ModInfo> sortedMods2 = ModInfoProcessor.SortByAssembly(LoadedModsNotInDatabase);
                sortedMods2.AddRange(sortedMods1);

                foreach (var item in sortedMods2)
                {
                    if (item.PDX_ID != null)
                    {
                        LoadedModsList += $"- <{item.ModName}> [{item.PDX_ID}] — {item.Author}\r\n";
                    }
                    else
                    {
                        LoadedModsList += $"- {item.AssemblyName}\r\n";
                    }
                }
                string ModsLoaded = Mod.Setting.ModsLoaded + LoadedModsList;
                ++Mod.Setting.ModsLoadedVersion;
            }
            catch (Exception ex) { Mod.log.Info(ex); }
        }

        public void SendNotification(int count)
        {
            uISystem = World.GetOrCreateSystemManaged<OptionsUISystem>();
            var modstext = "mod";
            if (count < 2)
            {
                modstext += "";
            }
            else
            {
                modstext += "s";
            }

            string modMessageKey = count > 1
                ? "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMods]"
                : "Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.LoadedMod]";
            //string pageID = "SimpleModChecker.SimpleModCheckerPlus.Mod";
            //Dictionary<string, OptionsUISystem.Page> pages = [];
            //if (pages.TryGetValue(pageID, out OptionsUISystem.Page value))
            //{
            //    var sections = value.visibleSections;
            //    foreach (OptionsUISystem.Section item in sections)
            //    {
            //        Mod.log.Info(item.id);
            //        try { Mod.log.Info(item.ToJSONString()); } catch (Exception) { }
            //    }
            //}
            //else { Mod.log.Info(":("); }

            NotificationSystem.Push("starq-smc-mod-check",
                        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                        text: new LocalizedString(modMessageKey, null,
                            new Dictionary<string, ILocElement>
                            {
                                {"modCount", LocalizedString.Value(count.ToString())}
                            }),
                        onClicked: () => {
                            //System.Diagnostics.Process.Start($"{EnvPath.kUserDataPath}/Logs/{Mod.logFileName}.log");
                            uISystem.OpenPage("SimpleModChecker.SimpleModCheckerPlus.Mod", "Setting.ModListTab", false);
                        });
        }

        public void RemoveNotification()
        {
            NotificationSystem.Pop("starq-smc-mod-check", delay: 1);
        }
    }
}