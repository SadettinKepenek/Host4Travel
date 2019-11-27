using System;

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
    }
}