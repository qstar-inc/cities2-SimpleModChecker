namespace SimpleModCheckerPlus.Systems
{
    public class GameSettings
    {
        public string GameVersion { get; set; }
        public string LastUpdated { get; set; }
        public GameAudioSettings GameAudioSettings { get; set; }
        public GameEditorSettings GameEditorSettings { get; set; }
        public GameGameplaySettings GameGameplaySettings { get; set; }
        public GameGeneralSettings GameGeneralSettings { get; set; }
        public GameGraphicsSettings GameGraphicsSettings { get; set; }
        public GameInputSettings GameInputSettings { get; set; }
        public GameInterfaceSettings GameInterfaceSettings { get; set; }
        public GameUserState GameUserState { get; set; }
    }
}
