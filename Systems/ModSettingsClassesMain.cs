using System.Collections.Generic;

namespace SimpleModCheckerPlus.Systems
{
    public interface ISettingsBackup
    {
        void SetValue(string property, object value);
        object GetValue(string property);
        bool HasValue(string property);
    }

    public class SettingsBackup : ISettingsBackup
    {
        private readonly Dictionary<string, object> SettingsItems = new();

        public void SetValue(string property, object value) => SettingsItems[property] = value;

        public object GetValue(string property) =>
            SettingsItems.ContainsKey(property) ? SettingsItems[property] : null;

        /// <summary>
        /// Whether we ever read a value into this property. The store is a dictionary, so "never
        /// set" and "set to null" both come back null from <see cref="GetValue"/>. Serialization
        /// uses this to tell them apart and leave the unset ones out.
        /// </summary>
        public bool HasValue(string property) => SettingsItems.ContainsKey(property);
    }
}
