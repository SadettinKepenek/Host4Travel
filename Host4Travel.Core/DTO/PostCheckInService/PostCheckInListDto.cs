using System;
using Host4Travel.Core.DTO.PostApplicationService;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.PostCheckInService
{
    public class PostCheckInListDto
    {
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }

        public virtual PostApplicationListDto Application { get; set; }
    }
}