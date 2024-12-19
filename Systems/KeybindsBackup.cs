// Simple Mod Checker Plus
// https://github.com/qstar-inc/cities2-SimpleModChecker
// StarQ 2024

using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mod = SimpleModCheckerPlus.Mod;
using Game;
using Colossal.PSI.Environment;
using Game.Input;
using System.Linq;

namespace SimpleModChecker.Systems
{
    public class GameKeybind
    {
        public string ActionName { get; set; }
        public InputManager.DeviceType Device {  get; set; }
        public string BindingName {  get; set; }
        public string Path { get; set; }
        public IReadOnlyList<ProxyModifier> Modifiers { get; set; }
    }

    public class Keybinds
    {
        public string GameVersion { get; set; }
        public string LastUpdated { get; set; }
        public Dictionary<string, List<GameKeybind>> GameKeybind { get; set; }
    }

    public partial class KeybindsBackup : GameSystemBase
    {
        public Mod _mod;
        public static ModCheckup SMC = new();
        private readonly List<string> loadedMods = SMC.GetLoadedMods();
        private InputManager inputManager = InputManager.instance;
        private readonly string backupFile0 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_prev.json";
        private readonly string backupFile1 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_1.json";
        private readonly string backupFile2 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_2.json";
        private readonly string backupFile3 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_3.json";
        private readonly string backupFile4 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_4.json";
        private readonly string backupFile5 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_5.json";
        private readonly string backupFile6 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_6.json";
        private readonly string backupFile7 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_7.json";
        private readonly string backupFile8 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_8.json";
        private readonly string backupFile9 = $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_9.json";


        protected override void OnCreate()
        {
            base.OnCreate();
            if (Mod.Setting.AutoRestoreSettingBackupOnStartup)
            {
                if (File.Exists(backupFile1))
                {
                    //string currentGameVersion = Game.Version.current.version;
                    //string jsonStringRead = File.ReadAllText(backupFile1);
                    //if (jsonStringRead != null && jsonStringRead != "")
                    //{
                    //    try
                    //    {
                    //        JObject jsonObject = JObject.Parse(jsonStringRead);
                    //        if (jsonObject != null)
                    //        {
                    //            if (!jsonObject.TryGetValue("GameVersion", out JToken BackupGameVersion) || BackupGameVersion == null)
                    //            {
                    //                SendGameUpdateNotification(currentGameVersion, "null");
                    //            }
                    //            else
                    //            {
                    //                if (BackupGameVersion.ToString() != currentGameVersion)
                    //                {
                    //                    SendGameUpdateNotification(currentGameVersion, BackupGameVersion.ToString());
                    //                }
                    //            }
                    //        }
                    //    }
                    //    catch (Exception ex) { Mod.log.Info(ex); }
                    //}
                    CreateBackup(0, false);
                    if (!File.ReadAllText(backupFile0).Equals(File.ReadAllText(backupFile1)))
                    {
                        RestoreBackup(1, false);
                        //NotificationSystem.Pop("starq-smc-game-settings-restore",
                        //        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus]"),
                        //        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.AutoRestoreGame]"),
                        //        delay: 10f);;
                    }
                    //else
                    //{
                    //    Mod.log.Info("Nothing to restore");
                    //}
                }
                else
                {
                    Mod.log.Info("Auto Keybind Restore failed, no Backup was found.");
                }
            }
            else
            {
                Mod.log.Info("Auto Restore is disabled...");
            }
        }

        protected override void OnUpdate()
        {

        }
        //private void SendGameUpdateNotification(string current, string prev)
        //{
        //    //var validVersions = new HashSet<string> { "2.2.4", "2.2.5", "2.2.6", "2.2.7" };
        //    //if (validVersions.Contains(current) && (prev == "2.2.3" || validVersions.Contains(prev)))
        //    //{
        //    //    return;
        //    //}
        //    Mod.log.Info($"Game version mismatch. Current: {current}, Backup: {prev}");
        //    NotificationSystem.Push("starq-smc-game-settings-update",
        //        title: LocalizedString.Id("Menu.NOTIFICATION_TITLE[SimpleModCheckerPlus.MakeGameBackup]"),
        //        text: LocalizedString.Id("Menu.NOTIFICATION_DESCRIPTION[SimpleModCheckerPlus.MakeGameBackup]"),
        //        progressState: ProgressState.Warning,
        //        onClicked: () => { NotificationSystem.Pop("starq-smc-game-settings-update", delay: 1f); CreateBackup(1); });
        //}

        public void CreateBackup(int profile, bool log = true)
        {
            string backupFile = profile switch
            {
                0 => backupFile0,
                1 => backupFile1,
                2 => backupFile2,
                3 => backupFile3,
                4 => backupFile4,
                5 => backupFile5,
                6 => backupFile6,
                7 => backupFile7,
                8 => backupFile8,
                9 => backupFile9,
                _ => backupFile1,
            };
            Mod.log.Info($"Creating Keybinds Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                if (log) Mod.log.Info("ModsData folder not found, creating...");
                Directory.CreateDirectory(directoryPath);
            }

            //List<GameKeybind> GameKeybinds = [];
            Dictionary<string, List<GameKeybind>> existingKeybinds = [];
            try
            {
                if (File.Exists(backupFile))
                {
                    string existingJson = File.ReadAllText(backupFile);
                    var keybindsGrouped = JsonConvert.DeserializeObject<Keybinds>(existingJson);
                    existingKeybinds = keybindsGrouped?.GameKeybind ?? [];
                }

                var GameKeybindsTemp = existingKeybinds
                    .SelectMany(kv => kv.Value.Select(g => new { MapName = kv.Key, Keybind = g }))
                    .ToList();

                List<ProxyBinding> bindings = [.. inputManager.GetBindings(InputManager.PathType.Effective, InputManager.BindingOptions.None)];

                //Mod.log.Info(bindings.Count);
                foreach (ProxyBinding binding in bindings)
                {
                    if (binding.isRebindable)
                    try
                    {
                            var existing = GameKeybindsTemp.FirstOrDefault(k =>
                                k.Keybind.ActionName == binding.actionName &&
                                k.Keybind.BindingName == binding.name &&
                                k.MapName == binding.mapName &&
                                k.Keybind.Device == binding.device);

                            if (existing != null)
                            {
                                GameKeybindsTemp.Remove(existing);
                            }

                            GameKeybindsTemp.Add(new 
                            {
                                MapName = binding.mapName,
                                Keybind = new GameKeybind
                                {
                                    ActionName = binding.actionName,
                                    BindingName = binding.name,
                                    Modifiers = binding.modifiers,
                                    Device = binding.device,
                                    Path = binding.path,
                                }
                            });
                    }
                    catch (Exception ex) { Mod.log.Info(ex); }
                }
                var GameKeybinds = GameKeybindsTemp
                    .GroupBy(k => k.MapName)
                    .ToDictionary(g => g.Key, g => g.Select(k => k.Keybind).ToList());

                var Keybinds = new Keybinds
                {
                    GameVersion = Game.Version.current.version,
                    LastUpdated = DateTime.Now.ToLongDateString(),
                    GameKeybind = GameKeybinds
                };

                if (log) Mod.log.Info("Collecting Keybinds");
                try
                {
                    string jsonString = JsonConvert.SerializeObject(Keybinds, Formatting.Indented);
                    File.WriteAllText(backupFile, jsonString);
                    if (log) Mod.log.Info($"Keybinds backup created successfully: {backupFile}");
                }
                catch (Exception ex)
                {
                    Mod.log.Info(ex);
                }
            }
            catch { }
            //try
            //    {
            //    List<ProxyBinding> bindings = [.. inputManager.GetBindings(InputManager.PathType.Effective, InputManager.BindingOptions.None)];

            //    Mod.log.Info(bindings.Count);
            //    foreach (ProxyBinding binding in bindings)
            //    {
            //        try { Mod.log.Info("---------------------------------"); } catch { }
            //        try { Mod.log.Info($"binding: {binding}"); } catch { }
            //        try { Mod.log.Info($"binding.actionName: {binding.actionName}"); } catch { }
            //        try { Mod.log.Info($"binding.allowModifiers: {binding.allowModifiers}"); } catch { }
            //        try { Mod.log.Info($"binding.canBeEmpty: {binding.canBeEmpty}"); } catch { }
            //        try { Mod.log.Info($"binding.component: {binding.component}"); } catch { }
            //        try { Mod.log.Info($"binding.conflicts: {binding.conflicts}"); } catch { }
            //        try { Mod.log.Info($"binding.developerOnly: {binding.developerOnly}"); } catch { }
            //        try { Mod.log.Info($"binding.device: {binding.device}"); } catch { }
            //        try { Mod.log.Info($"binding.hasConflicts: {binding.hasConflicts}"); } catch { }
            //        try { Mod.log.Info($"binding.isBuiltIn: {binding.isBuiltIn}"); } catch { }
            //        try { Mod.log.Info($"binding.isGamepad: {binding.isGamepad}"); } catch { }
            //        try { Mod.log.Info($"binding.isKeyboard: {binding.isKeyboard}"); } catch { }
            //        try { Mod.log.Info($"binding.isModifiersRebindable: {binding.isModifiersRebindable}"); } catch { }
            //        try { Mod.log.Info($"binding.isMouse: {binding.isMouse}"); } catch { }
            //        try { Mod.log.Info($"binding.isOriginal: {binding.isOriginal}"); } catch { }
            //        try { Mod.log.Info($"binding.isRebindable: {binding.isRebindable}"); } catch { }
            //        try { Mod.log.Info($"binding.isSet: {binding.isSet}"); } catch { }
            //        try { Mod.log.Info($"binding.mapName: {binding.mapName}"); } catch { }
            //        try { Mod.log.Info($"binding.modifiers: {binding.modifiers}"); } catch { }
            //        try { Mod.log.Info($"binding.name: {binding.name}"); } catch { }
            //        try { Mod.log.Info($"binding.original: {binding.original}"); } catch { }
            //        try { Mod.log.Info($"binding.originalModifiers: {binding.originalModifiers}"); } catch { }
            //        try { Mod.log.Info($"binding.originalPath: {binding.originalPath}"); } catch { }
            //        try { Mod.log.Info($"binding.path: {binding.path}"); } catch { }
            //        try { Mod.log.Info($"binding.title: {binding.title}"); } catch { }
            //        try { Mod.log.Info($"binding.usages: {binding.usages}"); } catch { }
            //        //if (binding.isKeyboard && binding.path == "<Keyboard>/r")
            //        //{
            //        //    ProxyBinding proxyBinding = binding.Copy();
            //        //    proxyBinding.path = "<Keyboard>/f";
            //        //    proxyBinding.device = InputManager.DeviceType.Keyboard;
            //        //    InputManager.instance.SetBinding(proxyBinding, out ProxyBinding _);
            //        //    Mod.log.Info($"Setting {proxyBinding.actionName} to ({proxyBinding.modifiers}){proxyBinding.path}");
            //        //}
            //    }
            //}
            //catch { }
        }

        public void RestoreBackup(int profile, bool log = true)
        {
            string backupFile = profile switch
            {
                0 => backupFile0,
                1 => backupFile1,
                2 => backupFile2,
                3 => backupFile3,
                4 => backupFile4,
                5 => backupFile5,
                6 => backupFile6,
                7 => backupFile7,
                8 => backupFile8,
                9 => backupFile9,
                _ => backupFile1,
            };
            if (!File.Exists(backupFile))
            {
                Mod.log.Error("Trying to Restore Backup, when Backup file is not found.");
                return;
            }

            Mod.log.Info($"Restoring Backup {backupFile}");
            string jsonString = File.ReadAllText(backupFile);

            try
            {
                var bindings = inputManager.GetBindings(InputManager.PathType.Effective, InputManager.BindingOptions.None);
                JObject jsonObject = JObject.Parse(jsonString);

                if (jsonObject["GameKeybind"] != null)
                {
                    var gameKeybindDict = jsonObject["GameKeybind"] as JObject;

                    foreach (var mapEntry in gameKeybindDict)
                    {
                        string mapName = mapEntry.Key;

                        if (inputManager.TryFindActionMap(mapName, out var _))
                        {
                            JArray keybindsArray = (JArray)mapEntry.Value;

                            if (log) Mod.log.Info($"Checking {mapName}");

                            foreach (var keybind in keybindsArray)
                            {
                                string actionName = keybind["ActionName"]?.ToString();
                                string bindingName = keybind["BindingName"]?.ToString();
                                int deviceString = keybind["Device"].Value<int>();
                                JArray modifiers = keybind["Modifiers"] as JArray;
                                string path = keybind["Path"]?.ToString();
                                InputManager.DeviceType device = (InputManager.DeviceType)deviceString;
                                if (inputManager.TryFindAction(mapName, actionName, out var action))
                                {
                                    ProxyBinding oldBinding = bindings.FirstOrDefault(b =>
                                        b.mapName == mapName &&
                                        b.actionName == actionName &&
                                        b.name == bindingName &&
                                        b.device == device);

                                    if (oldBinding != null)
                                    {
                                        ProxyBinding newBinding = oldBinding.Copy();

                                        newBinding.modifiers = modifiers != null
                                            ? modifiers.Select(m => new ProxyModifier
                                            {
                                                m_Component = (ActionComponent)Enum.Parse(typeof(ActionComponent), m["m_Component"]?.ToString() ?? "None"),
                                                m_Name = m["m_Name"]?.ToString(),
                                                m_Path = m["m_Path"]?.ToString()
                                            }).ToArray() : [];
                                        newBinding.path = string.IsNullOrEmpty(path) ? oldBinding.path : path;

                                        if (!(newBinding.path == oldBinding.path))
                                        {
                                            inputManager.SetBinding(newBinding, out ProxyBinding _);

                                            if (log)
                                            {
                                                string newBindingText = string.IsNullOrEmpty(newBinding.path) ? "Not set" : string.Join(" + ", newBinding.modifiers.Select((ProxyModifier m) => m.m_Path).Append(newBinding.path));
                                                Mod.log.Info($"Setting {newBinding.title} to {newBindingText}");
                                            }
                                        }
                                    }
                                }
                                //if (InputManager.instance.TryFindAction(mapName, keybind["ActionName"], out var action))
                                //{
                                //    Mod.log.Info(keybind.ToString(Formatting.Indented));
                                //    // You can access properties of each GameKeybind like this:
                                //    string actionName = keybind["ActionName"]?.ToString();
                                //    string bindingName = keybind["BindingName"]?.ToString();
                                //    string path = keybind["Path"]?.ToString();

                                //    ProxyBinding proxyBinding = binding.Copy();
                                //    proxyBinding.path = "<Keyboard>/f";
                                //    proxyBinding.device = InputManager.DeviceType.Keyboard;
                                //    InputManager.instance.SetBinding(proxyBinding, out ProxyBinding _);

                                //    Mod.log.Info($" - Action: {actionName}, Binding: {bindingName}, Path: {path}");
                                //}
                            }
                        }
                    }

                    //List<ProxyBinding> bindings = [.. InputManager.instance.GetBindings(InputManager.PathType.Effective, InputManager.BindingOptions.None)];
                    //foreach (var item in jsonObject["GameKeybind"])
                    //{
                    //    if (InputManager.instance.TryFindAction(item["MapName"].ToString(), item["ActionName"].ToString(), out ProxyAction action))
                    //    {
                    //        InputManager.instance.TryGetBinding()
                    //        ProxyBinding proxyBinding = binding.Copy();
                    //        proxyBinding.path = "<Keyboard>/f";
                    //        proxyBinding.device = InputManager.DeviceType.Keyboard;
                    //        InputManager.instance.SetBinding(proxyBinding, out ProxyBinding _);
                    //        Mod.log.Info($"Setting {proxyBinding.actionName} to ({proxyBinding.modifiers}){proxyBinding.path}");
                    //    }
                    //}
                }
                //SharedSettings.instance.Apply();
                Mod.log.Info("Keybinds Restoration Complete...");
            }
            catch (Exception ex)
            {
                Mod.log.Info($"Keybinds Restoration Failed: {ex}");
            }
        }
    }
}