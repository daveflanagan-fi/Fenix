using System;
using System.Collections.Generic;

namespace Fenix.Managers
{
    public class SettingsManager
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        public SettingsManager()
        {
            SetDefaults();
        }

        public void Save()
        {

        }

        public void Load()
        {
            _values = new Dictionary<string, object>();
        }

        private void SetDefaults()
        {
            Set("Graphics.Window.Width", 640);
            Set("Graphics.Window.Height", 960);
            Set("Graphics.Window.Fullscreen", false);

            Set("Graphics.Virtual.Width", 640);
            Set("Graphics.Virtual.Height", 960);
        }

        public void Set(string key, object value)
        {
            _values[key] = value;
        }

        public T Get<T>(string key)
        {
            if (!_values.ContainsKey(key))
                return default(T);
            else if (_values[key] is T)
                return (T)_values[key];
            else
            {
                try
                {
                    return (T)Convert.ChangeType(_values[key], typeof(T));
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }
        }
    }
}
