using System.Threading.Tasks;

namespace GotLcg.Config
{
    /// <summary>
    /// Abstraction to work with configuration sources like Web.Config, external API, 
    /// database or other providers.
    /// </summary>
    public interface IConfigProvider
    {
        /// <summary>
        /// Gets the database connection string by name.
        /// </summary>
        /// <param name="name">The name of connection string setting.</param>
        /// <returns>Connection string value.</returns>
        string GetConnectionString(string name);

        /// <summary>
        /// Gets the connection string by name in asynchronous manner.
        /// </summary>
        /// <param name="name">The name of connection string setting.</param>
        /// <returns>Task of type connection string.</returns>
        Task<string> GetConnectionStringAsync(string name);

        /// <summary>
        /// Gets the required configuration setting by key.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>Setting casted to T.</returns>
        T GetSetting<T>(string key, string section = null);

        /// <summary>
        /// Gets the required configuration setting by key in asynchronous way.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>Task of setting casted to T.</returns>
        Task<T> GetSettingAsync<T>(string key, string section = null);

        /// <summary>
        /// Gets the optional configuration setting by key.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="defaultValue">Value to return if setting is missing.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>Setting casted to T.</returns>
        T GetDefaultOrSetting<T>(string key, T defaultValue = default(T), string section = null);
       
        /// <summary>
        /// Gets the optional configuration setting by key with asynchronous approach.
        /// </summary>
        /// <typeparam name="T">Expected type of the setting.</typeparam>
        /// <param name="key">The setting key.</param>
        /// <param name="defaultValue">Value to return if setting is missing.</param>
        /// <param name="section">The configuration section.</param>
        /// <returns>Task of setting casted to T.</returns>
        Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T), string section = null);

        /// <summary>
        /// Gets the configuration section by it's name.
        /// </summary>
        /// <param name="section">The section name.</param>
        /// <returns>Instance of configuration section.</returns>
        IConfigSection GetSection(string section);

        /// <summary>
        /// Gets the configuration section asynchronous.
        /// </summary>
        /// <param name="section">The section name.</param>
        /// <returns>Task of configuration section.</returns>
        Task<IConfigSection> GetSectionAsync(string section);
    }
}