using System;
using System.ComponentModel.DataAnnotations;
using Host4Travel.UI;

namespace Host4Travel.Entities.Concrete
{
    public partial class PostCheckIn
    {
        [Key]
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }
        public Guid PostId { get; set; }

        public virtual PostApplication Application { get; set; }
        public virtual Post Post { get; set; }
    }
}
