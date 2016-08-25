using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace GotLcg.Config.Implementation
{
    /// <summary>
    /// Implements the entity that group configuration values 
    /// based on configuration section from app.config
    /// </summary>
    public sealed class FileConfigSection : IConfigSection
    {
        #region Private Fields

        /// <summary>
        /// The lazy collection of name-value settings.
        /// </summary>
        private readonly Lazy<NameValueCollection> _lazyCollection;

        /// <summary>
        /// The backing field to cache settings in memory.
        /// </summary>
        private IDictionary<string, string> _settings;

        /// <summary>
        /// The synchronization root.
        /// </summary>
        private readonly object _syncRoot = new object();

        #endregion

        #region Constructs

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigSection"/> class.
        /// </summary>
        /// <param name="name">The section name.</param>
        public FileConfigSection(string name)
        {
            Name = name;
            _lazyCollection = new Lazy<NameValueCollection>(
                () => ConfigurationManager.GetSection(Name) as NameValueCollection
            );
        }

        #endregion

        #region Implementation of IConfigSection

        /// <summary>
        /// Verifies if specified section exists.
        /// </summary>
        public bool Exists => _lazyCollection.Value != null;

        /// <summary>
        /// Gets the name of current section.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of raw settings in format key-value pair.
        /// This property can throw exception if Exists = false.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">Could not locate section with name '{Name}'</exception>
        public IDictionary<string, string> Settings
        {
            get
            {
                if (!Exists)
                {
                    throw new ConfigurationErrorsException($"Could not locate section with name '{Name}' in app/web configuration file");
                }

                if (_settings == null)
                {
                    lock (_syncRoot)
                    {
                        if (_settings == null)
                        {
                            _settings = new Dictionary<string, string>(_lazyCollection.Value.AllKeys.Length);

                            foreach (string key in _lazyCollection.Value.AllKeys)
                            {
                                _settings.Add(key, _lazyCollection.Value[key]);
                            }
                        }
                    }
                }

                return _settings;
            }
        }

        /// <summary>
        /// Gets the required setting by specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key to fetch the setting.</param>
        /// <returns>
        /// Configuration setting casted to type of T.
        /// </returns>
        public T GetSetting<T>(string key)
        {
            return SettingConverter.As<T>(Settings, key);
        }

        /// <summary>
        /// Gets the required setting by specified key in asynchronous way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key to fetch the setting.</param>
        /// <returns>
        /// Configuration setting casted to type of T.
        /// </returns>
        public Task<T> GetSettingAsync<T>(string key)
        {
            return Task.FromResult(GetSetting<T>(key));
        }

        /// <summary>
        /// Gets the required setting by specified key
        /// or returns default if setting doesn't exist in asynchronous way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key to fetch the setting.</param>
        /// <param name="defaultValue">The value to return if setting is missing.</param>
        /// <returns>
        /// Configuration setting casted to type of T.
        /// </returns>
        public Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T))
        {
            return Task.FromResult(GetDefaultOrSetting(key, defaultValue));
        }

        /// <summary>
        /// Gets the required setting by specified key or returns default if setting doesn't exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key to fetch the setting.</param>
        /// <param name="defaultValue">The value to return if setting is missing.</param>
        /// <returns>
        /// Configuration setting casted to type of T.
        /// </returns>
        public T GetDefaultOrSetting<T>(string key, T defaultValue = default(T))
        {
            if (!Exists)
            {
                return defaultValue;
            }

            return SettingConverter.As<T>(Settings, key);
        }

        #endregion
    }
}
