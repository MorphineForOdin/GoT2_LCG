using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace GotLcg.Config.Implementation
{
    /// <summary>
    /// Internal helper that provides methods to convert configuration setting to specific types.
    /// </summary>
    internal class SettingConverter
    {
        /// <summary>
        /// Cast the specified required settings to generic type using <c>System.ComponentModel.TypeConverter</c>.
        /// </summary>
        /// <typeparam name="T">The desired type.</typeparam>
        /// <param name="settings">The settings dictionary.</param>
        /// <param name="key">The setting key.</param>
        /// <returns>Configuration setting converted to T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ConfigurationErrorsException">No setting can be found for key '{key}'</exception>
        /// <exception cref="InvalidCastException">Cannot cast configuration setting with key '{key}' to type {typeof(T).FullName}")</exception>
        public static T As<T>(IDictionary<string, string> settings, string key)
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

        /// <summary>
        /// Cast the specified optional settings to generic type using <c>System.ComponentModel.TypeConverter</c>.
        /// </summary>
        /// <typeparam name="T">The desired type.</typeparam>
        /// <param name="settings">The settings dictionary.</param>
        /// <param name="key">The setting key.</param>
        /// <param name="defaultValue">Default value to return if setting does not exist or cast fails.</param>
        /// <returns>Configuration setting converted to T or default.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T DefaultOrAs<T>(IDictionary<string, string> settings, string key, T defaultValue = default(T))
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