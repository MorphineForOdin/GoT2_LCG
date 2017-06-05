using Serilog;
using System;

namespace GotLcg.Logger.Implementation
{
    /// <summary>
    /// This Serilog wrapper implements the <see cref = "ILogger" /> interface.
    /// </summary>
    public class SerilogLoggerAdapter : Interfaces.ILogger
    {
        #region Private members

        /// <summary>
        /// Serilog logger instance.
        /// </summary>
        private readonly ILogger _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that initialize logger to save logs in file.
        /// </summary>
        /// <param name="logFilesPath">Path to log files location.</param>
        public SerilogLoggerAdapter(string logFilesPath)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(
                    pathFormat: logFilesPath,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}{NewLine}")
                .CreateLogger();
        }

        /// <summary>
        /// TODO: This implementation will be used for configurable logging soon!
        /// </summary>
        public SerilogLoggerAdapter()
        {
            _logger = null;
        }

        #endregion

        #region ILogger implementation

        /// <summary>
        /// Information events describe things happening in the system that correspond to its responsibilities and functions.
        /// Generally these are the observable actions the system can perform.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void Information(string message)
        {
            _logger.Information(message);
        }

        /// <summary>
        /// Debug is used for internal system events that are not necessarily observable from the outside, 
        /// but useful when determining how something happened.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        /// <summary>
        ///  When service is degraded, endangered, or may be behaving outside of its expected parameters, 
        ///  Warning level events are used.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        public void Warning(string message, Exception exception = null)
        {
            _logger.Warning(exception, message);
        }

        /// <summary>
        /// When functionality is unavailable or expectations broken, an Error event is used.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        public void Error(string message, Exception exception = null)
        {
            _logger.Error(exception, message);
        }

        /// <summary>
        /// The most critical level, Fatal events demand immediate attention.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Optional exception instance.</param>
        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception, message);
        }

        #endregion
    }
}