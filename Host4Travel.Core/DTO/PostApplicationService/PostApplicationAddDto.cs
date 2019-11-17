using System;

namespace Host4Travel.Core.DTO.PostApplicationService
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