using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Colossal.PSI.Environment;
using Game;
using Game.Input;
using Game.PSI;
using Game.UI.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarQ.Shared.Extensions;

namespace SimpleModCheckerPlus.Systems
{
    public class GameKeybind
    {
        public string ActionName { get; set; }
        public InputManager.DeviceType Device { get; set; }
        public string BindingName { get; set; }
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
        private readonly InputManager inputManager = InputManager.instance;
        private readonly string backupFile0 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_prev.json";
        private readonly string backupFile1 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_1.json";
        private readonly string backupFile2 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_2.json";
        private readonly string backupFile3 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_3.json";
        private readonly string backupFile4 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_4.json";
        private readonly string backupFile5 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_5.json";
        private readonly string backupFile6 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_6.json";
        private readonly string backupFile7 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_7.json";
        private readonly string backupFile8 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_8.json";
        private readonly string backupFile9 =
            $"{EnvPath.kUserDataPath}\\ModsData\\SimpleModChecker\\SettingsBackup\\KeybindsBackup_9.json";
        private static int i = 0;

        protected override void OnCreate()
        {
            base.OnCreate();
            if (Mod.m_Setting.AutoRestoreSettingBackupOnStartup)
            {
                if (File.Exists(backupFile1))
                {
                    CreateBackup(0, false);
                    if (!File.ReadAllText(backupFile0).Equals(File.ReadAllText(backupFile1)))
                    {
                        RestoreBackup(1, false);
                    }
                }
                else
                {
                    LogHelper.SendLog("Auto Keybind Restore failed, no Backup was found.");
                }
            }
            else
            {
                LogHelper.SendLog("Auto Restore is disabled...");
            }
        }

        protected override void OnUpdate() { }

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
            LogHelper.SendLog($"Creating Keybinds Backup: {Path.GetFileName(backupFile)}");
            string directoryPath = Path.GetDirectoryName(backupFile);
            if (!Directory.Exists(directoryPath))
            {
                if (log)
                    LogHelper.SendLog("ModsData folder not found, creating...");
                Directory.CreateDirectory(directoryPath);
            }

            Dictionary<string, List<GameKeybind>> existingKeybinds = new();
            try
            {
                if (File.Exists(backupFile))
                {
                    string existingJson = File.ReadAllText(backupFile);
                    var keybindsGrouped = JsonConvert.DeserializeObject<Keybinds>(existingJson);
                    existingKeybinds = keybindsGrouped?.GameKeybind ?? new();
                }

                var GameKeybindsTemp = existingKeybinds
                    .SelectMany(kv => kv.Value.Select(g => new { MapName = kv.Key, Keybind = g }))
                    .ToList();

                List<ProxyBinding> bindings = new(
                    inputManager.GetBindings(
                        InputManager.PathType.Effective,
                        InputManager.BindingOptions.None
                    )
                );

                foreach (ProxyBinding binding in bindings)
                {
                    if (binding.isRebindable)
                        try
                        {
                            var existing = GameKeybindsTemp.FirstOrDefault(k =>
                                k.Keybind.ActionName == binding.actionName
                                && k.Keybind.BindingName == binding.name
                                && k.MapName == binding.mapName
                                && k.Keybind.Device == binding.device
                            );

                            if (existing != null)
                            {
                                GameKeybindsTemp.Remove(existing);
                            }

                            GameKeybindsTemp.Add(
                                new
                                {
                                    MapName = binding.mapName,
                                    Keybind = new GameKeybind
                                    {
                                        ActionName = binding.actionName,
                                        BindingName = binding.name,
                                        Modifiers = binding.modifiers,
                                        Device = binding.device,
                                        Path = binding.path,
                                    },
                                }
                            );
                        }
                        catch (Exception ex)
                        {
                            LogHelper.SendLog(ex);
                        }
                }
                var GameKeybinds = GameKeybindsTemp
                    .GroupBy(k => k.MapName)
                    .ToDictionary(g => g.Key, g => g.Select(k => k.Keybind).ToList());

                var Keybinds = new Keybinds
                {
                    GameVersion = Game.Version.current.version,
                    LastUpdated = DateTime.Now.ToLongDateString(),
                    GameKeybind = GameKeybinds,
                };

                if (log)
                    LogHelper.SendLog("Collecting Keybinds");
                try
                {
                    string jsonString = JsonConvert.SerializeObject(Keybinds, Formatting.Indented);
                    File.WriteAllText(backupFile, jsonString);
                    LogHelper.SendLog(
                        $"Keybinds backup created successfully: {Path.GetFileName(backupFile)}"
                    );
                }
                catch (Exception ex)
                {
                    LogHelper.SendLog(ex);
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog(ex);
            }
        }

        public void RestoreBackup(int profile, bool log = true)
        {
            i = 0;
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
                LogHelper.SendLog(
                    "Trying to Restore Backup, when Backup file is not found.",
                    LogLevel.Error
                );
                return;
            }

            LogHelper.SendLog($"Restoring Backup {Path.GetFileName(backupFile)}");
            string jsonString = File.ReadAllText(backupFile);

            try
            {
                var bindings = inputManager.GetBindings(
                    InputManager.PathType.Effective,
                    InputManager.BindingOptions.None
                );
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

                            if (log)
                                LogHelper.SendLog($"Checking {mapName}");

                            foreach (var keybind in keybindsArray)
                            {
                                string actionName = keybind["ActionName"]?.ToString();
                                string bindingName = keybind["BindingName"]?.ToString();
                                int deviceString = keybind["Device"].Value<int>();
                                JArray modifiers = keybind["Modifiers"] as JArray;
                                string path = keybind["Path"]?.ToString();
                                InputManager.DeviceType device =
                                    (InputManager.DeviceType)deviceString;
                                if (inputManager.TryFindAction(mapName, actionName, out var action))
                                {
                                    ProxyBinding oldBinding = bindings.FirstOrDefault(b =>
                                        b.mapName == mapName
                                        && b.actionName == actionName
                                        && b.name == bindingName
                                        && b.device == device
                                    );

                                    if (oldBinding != null)
                                    {
                                        ProxyBinding newBinding = oldBinding.Copy();

                                        newBinding.modifiers =
                                            modifiers != null
                                                ? modifiers
                                                    .Select(m => new ProxyModifier
                                                    {
                                                        m_Component = (ActionComponent)
                                                            Enum.Parse(
                                                                typeof(ActionComponent),
                                                                m["m_Component"]?.ToString()
                                                                    ?? "None"
                                                            ),
                                                        m_Name = m["m_Name"]?.ToString(),
                                                        m_Path = m["m_Path"]?.ToString(),
                                                    })
                                                    .ToArray()
                                                : Array.Empty<ProxyModifier>();
                                        newBinding.path = string.IsNullOrEmpty(path)
                                            ? oldBinding.path
                                            : path;

                                        if (!(newBinding.path == oldBinding.path))
                                        {
                                            i++;
                                            inputManager.SetBinding(newBinding, out ProxyBinding _);

                                            if (log)
                                            {
                                                string newBindingText = string.IsNullOrEmpty(
                                                    newBinding.path
                                                )
                                                    ? "Not set"
                                                    : string.Join(
                                                        " + ",
                                                        newBinding
                                                            .modifiers.Select(m => m.m_Path)
                                                            .Append(newBinding.path)
                                                    );
                                                LogHelper.SendLog(
                                                    $"Setting {newBinding.title} to {newBindingText}"
                                                );
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (i > 0)
                {
                    NotificationSystem.Pop(
                        "starq-smc-mod-settings-restore",
                        title: Mod.Name,
                        text: new LocalizedString(
                            $"{Mod.Id}.RestoreKeybinds",
                            null,
                            new Dictionary<string, ILocElement>
                            {
                                { "Count", new LocalizedNumber<int>(i) },
                            }
                        ),
                        delay: 5f
                    );
                    LogHelper.SendLog($"Keybinds Restoration Complete... ({i} options restored)");
                }
                else
                {
                    LogHelper.SendLog("No changes found to restore Keybinds...");
                }
            }
            catch (Exception ex)
            {
                LogHelper.SendLog($"Keybinds Restoration Failed: {ex}");
            }
        }
    }
}
