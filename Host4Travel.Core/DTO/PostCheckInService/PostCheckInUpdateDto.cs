using System;

namespace Host4Travel.Core.DTO.PostCheckInService
{
    public class PostCheckInUpdateDto
    {
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }
        public Guid PostId { get; set; }
    }
}