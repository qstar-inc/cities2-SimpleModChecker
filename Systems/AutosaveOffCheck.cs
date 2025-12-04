using System;
using Colossal.Serialization.Entities;
using Game;
using Game.SceneFlow;
using Game.Settings;
using StarQ.Shared.Extensions;
using Unity.Entities;
using UnityEngine.Scripting;

namespace SimpleModCheckerPlus.Systems
{
    //public static class DadJokeFetcher
    //{
    //    private static readonly HttpClient client = new()
    //    {
    //        BaseAddress = new Uri("https://icanhazdadjoke.com/"),
    //    };

    //    static DadJokeFetcher()
    //    {
    //        client.DefaultRequestHeaders.Add("Accept", "text/plain");
    //    }

    //    public static string GetRandomDadJoke()
    //    {
    //        try
    //        {
    //            var response = client.GetStringAsync("").GetAwaiter().GetResult();
    //            return response.Trim();
    //        }
    //        catch (Exception ex)
    //        {
    //            return $"Failed to fetch a dad joke: {ex.Message}";
    //        }
    //    }
    //}

    public partial class AutosaveOffCheck : GameSystemBase
    {
        private float TimeSinceStartup
        {
            get { return UnityEngine.Time.realtimeSinceStartup; }
        }
        private static float LastAutoSaveCheck = -1f;

        //private float LastDadJokeCheck = 0f;

        [Preserve]
        public AutosaveOffCheck() { }

        public static void SendAutoSaveOffChirp()
        {
            if (!CustomChirpsBridge.IsAvailable)
                return;

            CustomChirpsBridge.PostChirp(
                text: $"{GetRandomText()}\nLast save: {ModDatabase.FormatTimeSpan(LastAutoSaveCheck, " ago")}",
                department: GetRandomEnumValue<DepartmentAccountBridge>(),
                entity: Entity.Null,
                customSenderName: Mod.Name
            );
        }

        //public static void SendDadJokeChirp()
        //{
        //    if (!CustomChirpsBridge.IsAvailable)
        //        return;

        //    CustomChirpsBridge.PostChirp(
        //        text: DadJokeFetcher.GetRandomDadJoke(),
        //        department: DepartmentAccountBridge.Communications,
        //        entity: Entity.Null,
        //        customSenderName: "Honu's Dad Jokes"
        //    );
        //}

        [Preserve]
        protected override void OnCreate()
        {
            base.OnCreate();
            SharedSettings.instance.general.onSettingsApplied += OnSettingsChanged;
            if (!CustomChirpsBridge.IsAvailable)
                return;
        }

        private void OnSettingsChanged(Game.Settings.Setting setting)
        {
            if (GameManager.instance.gameMode.IsGame())
            {
                if (setting is GeneralSettings generalSettings)
                {
                    if (!generalSettings.autoSave && Mod.m_Setting.AutoSaveOffChirp)
                    {
                        if (LastAutoSaveCheck < 0f)
                            LastAutoSaveCheck = TimeSinceStartup;
                    }
                    else if (LastAutoSaveCheck >= 0f)
                        LastAutoSaveCheck = -1f;
                }
            }
        }

        [Preserve]
        protected override void OnDestroy()
        {
            SharedSettings.instance.general.onSettingsApplied -= OnSettingsChanged;
            base.OnDestroy();
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            if (!SharedSettings.instance.general.autoSave)
                LastAutoSaveCheck = -1f;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            if (
                (purpose == Purpose.LoadGame || purpose == Purpose.NewGame)
                && !SharedSettings.instance.general.autoSave
                && Mod.m_Setting.AutoSaveOffChirp
            )
                LastAutoSaveCheck = TimeSinceStartup;
            //LastDadJokeCheck = TimeSinceStartup;
        }

        protected override void OnUpdate()
        {
            if (!CustomChirpsBridge.IsAvailable)
                return;
            if (LastAutoSaveCheck >= 0f && GameManager.instance.gameMode.IsGame())
            {
                GeneralSettings general = SharedSettings.instance.general;
                if (!general.autoSave && Mod.m_Setting.AutoSaveOffChirp)
                {
                    if (TimeSinceStartup - LastAutoSaveCheck > 60)
                    {
                        LastAutoSaveCheck = TimeSinceStartup;
                        SendAutoSaveOffChirp();
                    }
                }
            }
            //if (LastDadJokeCheck >= 0f && GameManager.instance.gameMode.IsGame())
            //{
            //    if (TimeSinceStartup - LastDadJokeCheck > 10)
            //    {
            //        LastDadJokeCheck = TimeSinceStartup;
            //        SendDadJokeChirp();
            //    }
            //}
        }

        private static string GetRandomText()
        {
            string[] texts = new string[]
            {
                "Autosave is off?\nBold move, Mayor. One crash and your city might be joining the lost civilizations.",
                "Autosave is off!\nLiving dangerously, are we? Just remember, the game doesn't believe in second chances.",
                "No Autosave?\nGuess you trust your PC more than I trust traffic AI.",
                "Without Autosave, one little crash and your metropolis could become a myth. Proceed with overconfidence.",
                "Autosave is off?\nWow, you must really enjoy the thrill of losing hours of progress.",
                "Autosave disabled.\nRespect. You're playing the game and gambling your entire city's existence at the same time.",
                "Autosave is off!\nDon't worry, what could possibly go wrong... other than everything?",
                "Turning off Autosave builds character.\nLosing your masterpiece builds regret.",
                "Autosave disabled.\nYou're one crash away from an emotional support mod.",
                "Hope you've memorized your city layout.\nBecause with Autosave off, it might be gone in one wrong move (it).",
                "Autosave is off?\nThat's like playing with fire, but hey, at least you won't have to deal with the ashes... until you do.",
                "Autosave off?\nEnjoy the thrill! Every minute could be your last... in-game, that is.",
            };
            return texts[UnityEngine.Random.Range(0, texts.Length)];
        }

        private static readonly Random rand = new();

        private static T GetRandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(rand.Next(values.Length));
        }
    }
}
