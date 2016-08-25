using System.Collections.Concurrent;
using System.Configuration;
using System.Threading.Tasks;

namespace GotLcg.Config.Implementation
{
    /// <summary>
    /// Provides wrapper to work with configuration sources like Web.Config or App.Config
    /// </summary>
    /// <seealso cref="GotLcg.Config.IConfigProvider" />
    public sealed class FileConfigProvider : IConfigProvider
    {
        #region Private Fields

        /// <summary>
        /// The configuration sections cache dictionary.
        /// </summary>
        private readonly ConcurrentDictionary<string, IConfigSection> _configSections;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigProvider"/> class.
        /// </summary>
        public FileConfigProvider()
        {
            _configSections = new ConcurrentDictionary<string, IConfigSection>();
        }

        #endregion

        #region Implementation of IConfigProvider

        /// <summary>
        /// Gets the database connection string by name.
        /// </summary>
        /// <param name="name">The name of connection string setting.</param>
        /// <returns>
        /// Connection string value.
        /// </returns>
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Gets the connection string by name in asynchronous manner.
        /// </summary>
        /// <param name="name">The name of connection string setting.</param>
        /// <returns>
        /// Task of type connection string.
        /// </returns>
        public Task<string> GetConnectionStringAsync(string name)
        {
            return Task.FromResult(this.GetConnectionString(name));
        }

        /// <summary>
        /// Gets the required configuration setting by key.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>
        /// Setting casted to T.
        /// </returns>
        public T GetSetting<T>(string key, string section = null)
        {
            return GetCached(section).GetSetting<T>(key);
        }

        /// <summary>
        /// Gets the required configuration setting by key in asynchronous way.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>
        /// Task of setting casted to T.
        /// </returns>
        public Task<T> GetSettingAsync<T>(string key, string section = null)
        {
            return Task.FromResult(GetSetting<T>(key, section));
        }

        /// <summary>
        /// Gets the optional configuration setting by key.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="defaultValue">Value to return if setting is missing.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>
        /// Setting casted to T.
        /// </returns>
        public T GetDefaultOrSetting<T>(string key, T defaultValue = default(T), string section = null)
        {
            return GetCached(section).GetDefaultOrSetting<T>(key, defaultValue);
        }

        /// <summary>
        /// Gets the optional configuration setting by key with asynchronous approach.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="defaultValue">Value to return if setting is missing.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>
        /// Task of setting casted to T.
        /// </returns>
        public Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T), string section = null)
        {
            return Task.FromResult(GetDefaultOrSetting(key, defaultValue, section));
        }

        /// <summary>
        /// Gets the configuration section by it's name.
        /// </summary>
        /// <param name="section">The section name.</param>
        /// <returns>
        /// Instance of configuration section.
        /// </returns>
        public IConfigSection GetSection(string section)
        {
            return GetCached(section);
        }

        /// <summary>
        /// Gets the configuration section asynchronous.
        /// </summary>
        /// <param name="section">The section name.</param>
        /// <returns>
        /// Task of configuration section.
        /// </returns>
        public Task<IConfigSection> GetSectionAsync(string section)
        {
            return Task.FromResult(GetSection(section));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets cached section or adds new to the cache.
        /// </summary>
        /// <param name="section">The section name.</param>
        /// <returns>Cached or new section.</returns>
        private IConfigSection GetCached(string section)
        {
            return _configSections.GetOrAdd(section ?? "appSettings", GetSection);
        }

        #endregion
    }
}