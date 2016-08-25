using System.Collections.Generic;
using System.Threading.Tasks;

namespace GotLcg.Config
{
    /// <summary>
    /// Defines entity that group configuration values. 
    /// As example configuration section from app.config
    /// </summary>
    public interface IConfigSection
    {
        #region Properties

        /// <summary>
        /// Verifies if specified section exists.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Gets the name of current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the collection of raw settings in format key-value pair.
        /// This property can throw exception if Exists = false.
        /// </summary>
        IDictionary<string, string> Settings { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the required setting by specified key.
        /// </summary>
        /// <param name="key">Key to fetch the setting.</param>
        /// <returns>Configuration setting casted to type of T.</returns>
        T GetSetting<T>(string key);

        /// <summary>
        /// Gets the required setting by specified key in asynchronous way.
        /// </summary>
        /// <param name="key">Key to fetch the setting.</param>
        /// <returns>Configuration setting casted to type of T.</returns>
        Task<T> GetSettingAsync<T>(string key);

        /// <summary>
        /// Gets the required setting by specified key or returns default if setting doesn't exist.
        /// </summary>
        /// <param name="key">Key to fetch the setting.</param>
        /// <param name="defaultValue">The value to return if setting is missing.</param>
        /// <returns>Configuration setting casted to type of T.</returns>
        T GetDefaultOrSetting<T>(string key, T defaultValue = default(T));

        /// <summary>
        /// Gets the required setting by specified key 
        /// or returns default if setting doesn't exist in asynchronous way.
        /// </summary>
        /// <param name="key">Key to fetch the setting.</param>
        /// <param name="defaultValue">The value to return if setting is missing.</param>
        /// <returns>Configuration setting casted to type of T.</returns>
        Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T));

        #endregion
    }
}