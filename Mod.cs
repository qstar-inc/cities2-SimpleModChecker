using Colossal.Logging;
using Game.PSI;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.Threading.Tasks;

namespace SimpleModChecker
{
    public class Mod : IMod
    {
        public const string ModName = "Simple Mod Checker";
        public static ILog log = LogManager.GetLogger($"{nameof(SimpleModChecker)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        //private SimpleModCheckerSetting m_Setting;
        private int count;
        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

            //m_Setting = new SimpleModCheckerSetting(this);
            //m_Setting.RegisterInOptionsUI();
            //GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));
            //m_Setting.DummyItem = false;
            //AssetDatabase.global.LoadSettings(nameof(SimpleModChecker), m_Setting, new SimpleModCheckerSetting(this));

            count = 0;

            foreach (var modInfo in GameManager.instance.modManager)
            {
                count += 1;
                log.Info($"Loaded: {modInfo.asset.name}");
            }
            log.Info($"Total mod(s): {count}");
            //bool showNotif = m_Setting.Toggle;
            //log.Info($"showNotif = '{showNotif}'");

            //if (showNotif)
            //{
            //    log.Info("Showing Notification");
            SendNotification(count);
            //}
            //else
            //{
            //    log.Info("Hiding Notification");
            //    RemoveNotification();
            //}
        }

        private static async void SendNotification(int count)
        {
            
            while (!GameManager.instance.modManager.isInitialized)
            {
                await Task.Delay(5);
            }

            var modstext = "mod";
            if (count < 2)
            {
                modstext += "";
            } else
            {
                modstext += "s";
            }

            NotificationSystem.Push("mod-check",
                        title: "Simple Mod Checker",
                        text: $"Loaded {count} {modstext}");
        }

        //private static void RemoveNotification()
        //{
        //    NotificationSystem.Pop("mod-check");
        //}

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
            //if (m_Setting != null)
            //{
            //    m_Setting.UnregisterInOptionsUI();
            //    m_Setting = null;
            //}
        }
    }
}
