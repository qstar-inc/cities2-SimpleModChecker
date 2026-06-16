using System.Collections.Generic;

namespace SimpleModCheckerPlus.Systems
{
    public interface ISettingsBackup
    {
        void SetValue(string property, object value);
        object GetValue(string property);
    }

    public class SettingsBackup : ISettingsBackup
    {
        private readonly Dictionary<string, object> SettingsItems = new();

        public void SetValue(string property, object value) => SettingsItems[property] = value;

        public object GetValue(string property) =>
            SettingsItems.ContainsKey(property) ? SettingsItems[property] : null;
    }
}
