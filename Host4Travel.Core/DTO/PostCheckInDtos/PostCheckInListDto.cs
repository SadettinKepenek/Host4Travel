using System;

namespace Host4Travel.Core.DTO.PostCheckInDtos
{
    public class PostCheckInListDto
    {
        public Guid PostCheckInId { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime CheckInEndDate { get; set; }
        
        public Guid ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        
        public string PostTitle { get; set; }
        public bool PostType { get; set; }
        public Guid PostId { get; set; }
        public string PostDescription { get; set; }

        public string OwnerId { get; set; }
        public string OwnerFirstname { get; set; }
        public string OwnerLastname { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerUserName { get; set; }
        
        public bool IsActive { get; set; }

    }
}