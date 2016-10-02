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
        /// <param name="filePath">Log file path.</param>
        public SerilogLoggerAdapter(string filePath)
        {
            _logger = new LoggerConfiguration()
                .WriteTo.RollingFile("log-{Date}.txt")
                .CreateLogger();
        }

        /// <summary>
        /// Initialize logger adapter with existing configured logger.
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> implementation instance.</param>
        public SerilogLoggerAdapter(ILogger logger)
        {
            _logger = logger;
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