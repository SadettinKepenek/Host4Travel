using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class PostCheckIn
    {
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }

        public virtual PostApplication Application { get; set; }
    }
}
