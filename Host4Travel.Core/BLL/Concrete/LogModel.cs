using System;
using Microsoft.Extensions.Logging;

namespace Host4Travel.Core.BLL.Concrete
{
    public class LogModel
    {
        public string LogMessage { get; set; }
        public LogLevel LogLevel { get; set; }
        public DateTime LogDate { get; set; }
        
    }
}