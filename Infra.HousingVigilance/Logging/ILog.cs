using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.HousingVigilance.Logging
{
    public interface ILog
    {
        void WriteLog(LogEventType eventType, string message);
        void WriteLog(Exception exception);
    }

    /// <summary>
    /// Describes the event types
    /// </summary>
    public enum LogEventType
    {
        None = 0,

        Error = 1,

        Warning = 2,

        Info = 3
    }
}
