using System;
using System.ComponentModel.DataAnnotations;

namespace Host4Travel.Entities.Concrete
{
    public partial class Log
    {
        [Key]
        public Guid LogId { get; set; }
        public string LogMessage { get; set; }
        
        public DateTime LogDate { get; set; }
        
    }
}