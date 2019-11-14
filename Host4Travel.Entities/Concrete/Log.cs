﻿using System;
using System.ComponentModel.DataAnnotations;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.Core.BLL.Concrete.LoggerService;
using Host4Travel.UI.Identity;

namespace Host4Travel.Entities.Concrete
{
    public partial class Log
    {
        [Key]
        public Guid LogId { get; set; }
        public string LogMessage { get; set; }
        public LogLevel LogLevel { get; set; }
        public DateTime LogDate { get; set; }
        
    }
}