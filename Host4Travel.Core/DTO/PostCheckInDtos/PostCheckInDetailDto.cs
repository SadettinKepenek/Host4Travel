using System;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostDtos;

namespace Host4Travel.Core.DTO.PostCheckInDtos
{
    public class PostCheckInDetailDto
    {
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }
        public Guid PostId { get; set; }

        public virtual PostListDto Post { get; set; }
        public virtual PostApplicationListDto Application { get; set; }
    }
}