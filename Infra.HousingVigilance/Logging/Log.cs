using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.HousingVigilance.Logging
{
    public class Log : ILog
    {
        private static bool _isInitialized;
        public Log()
        {
            //Intialize the log configuration
            if (!_isInitialized)
            {
                var config = ConfigurationSourceFactory.Create();
                var logWriterFactory = new LogWriterFactory(config);
                Logger.SetLogWriter(logWriterFactory.Create());
                _isInitialized = true;
            }
        }
        public void WriteLog(LogEventType eventType, string message)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = new LogEntry();
            switch (eventType)
            {
                case LogEventType.Error:
                    entry.EventId = (int)LogEventType.Error;
                    entry.Message = message;
                    entry.Title = "Housing Vigilance Error";
                    entry.Categories.Add("Error");
                    entry.Priority = (int)Priority.Critical;
                    entry.Severity = TraceEventType.Error;
                    break;
                case LogEventType.Warning:
                    entry.EventId = (int)LogEventType.Warning;
                    entry.Message = message;
                    entry.Title = "Housing Vigilance Warning";
                    entry.Categories.Add("Warning");
                    entry.Priority = (int)Priority.High;
                    entry.Severity = TraceEventType.Warning;
                    break;
                case LogEventType.Info:
                    entry.EventId = (int)LogEventType.Info;
                    entry.Message = message;
                    entry.Title = "Housing Vigilance Information";
                    entry.Categories.Add("Info");
                    entry.Priority = (int)Priority.Medium;
                    entry.Severity = TraceEventType.Information;
                    break;
                default:
                    entry.EventId = (int)LogEventType.None;
                    entry.Message = message;
                    entry.Title = "Housing Vigilance Log";
                    entry.Categories.Add("Log");
                    entry.Priority = (int)Priority.None;
                    entry.Severity = TraceEventType.Information;
                    break;
            }

            Logger.Write(entry);
        }

        public void WriteLog(Exception exception)
        {
            // Only for testing
            if (!Logger.IsLoggingEnabled())
                return;

            var entry = new LogEntry { EventId = 100, Message = exception.Message, Title = "Housing Vigilance Test trace" };
            entry.Categories.Add("Exception");
            entry.Priority = (int)Priority.Critical;
            entry.Severity = TraceEventType.Error;
            Logger.Write(entry);
        }
    }

    /// <summary>
    /// Represents priority level.
    /// The values get mapped to the integer Priority values used by Enterprise Library Logging
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Represents Priority None
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents Priority Critical
        /// </summary>
        Critical = 25,

        /// <summary>
        /// Represents Priority High
        /// </summary>
        High = 20,

        /// <summary>
        /// Represents Priority Medium
        /// </summary>
        Medium = 15,

        /// <summary>
        /// Represents Priority Low
        /// </summary>
        Low = 10,

        /// <summary>
        /// Represents Trace. The Tracer class in Enterprise Library Logging uses a priority of 5
        /// </summary>
        Trace = 5,

        /// <summary>
        /// Represents Debug
        /// </summary>
        Debug = 4
    }
}
