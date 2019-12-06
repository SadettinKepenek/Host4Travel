using System;
using Host4Travel.Core.DTO.PostCheckInDtos;

namespace Host4Travel.Core.DTO.PostApplicationDtos
{
    public class PostApplicationListDto
    {
        public Guid PostApplicationId { get; set; }
        public Guid PostId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }

        //public PostCheckInListDto PostCheckIn { get; set; }
        
    }
}