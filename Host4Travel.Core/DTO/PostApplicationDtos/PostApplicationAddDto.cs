using System;

namespace Host4Travel.Core.DTO.PostApplicationDtos
{
    public class PostApplicationAddDto
    {
        public Guid PostId { get; set; }
        public string ApplicentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }
    }
}