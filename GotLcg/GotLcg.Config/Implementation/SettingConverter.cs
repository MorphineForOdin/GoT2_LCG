using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace GotLcg.Config.Implementation
{
    internal class SettingConverter
    {
        internal static T As<T>(IDictionary<string, string> settings, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            string value;

            if (!settings.TryGetValue(key, out value))
            {
                throw new ConfigurationErrorsException($"No setting can be found for key '{key}'");
            }

            if (!converter.IsValid(value))
            {
                throw new InvalidCastException($"Cannot cast configuration setting with key '{key}' to type {typeof(T).FullName}");
            }

            return (T)converter.ConvertFromString(value);
        }

        internal static T DefaultOrAs<T>(IDictionary<string, string> settings, string key, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            string value;

            if (settings.TryGetValue(key, out value) && converter.IsValid(value))
            {
                return (T)converter.ConvertFromString(value);
            }

            return defaultValue;
        }
    }
}