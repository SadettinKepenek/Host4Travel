using System;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.UserDtos;

namespace Host4Travel.Core.DTO.PostApplicationDtos
{
    public class PostApplicationDetailDto
    {
        public Guid PostApplicationId { get; set; }
        public Guid PostId { get; set; }
        public string ApplicentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual UserListDto Applicent { get; set; }
        public virtual PostCheckInListDto PostCheckIn { get; set; }
        
        public virtual PostListDto Post { get; set; }
    }
}