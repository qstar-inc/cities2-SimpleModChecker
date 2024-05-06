using System.Collections.Generic;
using Colossal.Logging;
using Colossal.Serialization.Entities;
using Game;
using Game.Modding;
using Game.PSI;
using Game.SceneFlow;
using Unity.Entities;

namespace SimpleModChecker
{
    public class Mod : IMod
    {
        public const string ModName = "Simple Mod Checker";
        public SimpleModChecker _simpleModChecker;

        public static ILog log = LogManager.GetLogger($"{nameof(SimpleModChecker)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

            _simpleModChecker = new SimpleModChecker(this);
            World.DefaultGameObjectInjectionWorld.AddSystemManaged(_simpleModChecker);
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
        }
    }

    public partial class SimpleModChecker : GameSystemBase
    {
        public Mod _mod;
        private int count;
        public List<string> loadedMods = new List<string>();

        public SimpleModChecker(Mod mod)
        {
            _mod = mod;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            CheckMod();
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
                SendNotification(count);
            }
        }
        protected override void OnUpdate()
        {
        }

        private void CheckMod()
        {
            count = 0;

            foreach (var modInfo in GameManager.instance.modManager)
            {
                if (!loadedMods.Contains(modInfo.asset.name))
                {
                    loadedMods.Add(modInfo.asset.name);
                    count += 1;
                    Mod.log.Info($"Loaded: {modInfo.asset.name}");
                }
            }
            Mod.log.Info($"Total mod(s): {count}");
            SendNotification(count);
        }

        private void SendNotification(int count)
        {
            var modstext = "mod";
            if (count < 2)
            {
                modstext += "";
            }
            else
            {
                modstext += "s";
            }

            NotificationSystem.Push("mod-check",
                        title: "Simple Mod Checker",
                        text: $"Loaded {count} {modstext}");
        }

        private void RemoveNotification()
        {
            NotificationSystem.Pop("mod-check");
        }

    }
}
