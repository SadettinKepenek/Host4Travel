using System;

namespace Host4Travel.Core.DTO.LoggerService
{
    public class LogModel
    {
        public string LogMessage { get; set; }
        public LogLevel LogLevel { get; set; }
        public DateTime LogDate { get; set; }
        
    }
}