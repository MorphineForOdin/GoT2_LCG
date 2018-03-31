using System;

namespace GotLcg.Logger.Interfaces
{
    /// <summary>
    /// Wrapper on event logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Information events describe things happening in the system that correspond to its responsibilities and functions.
        /// Generally these are the observable actions the system can perform.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Information(string message);

        /// <summary>
        /// Debug is used for internal system events that are not necessarily observable from the outside, 
        /// but useful when determining how something happened.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Debug(string message);

        /// <summary>
        ///  When service is degraded, endangered, or may be behaving outside of its expected parameters, 
        ///  Warning level events are used.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        void Warning(string message, Exception exception = null);

        /// <summary>
        /// When functionality is unavailable or expectations broken, an Error event is used.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// The most critical level, Fatal events demand immediate attention.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        void Fatal(string message, Exception exception);
    }
}