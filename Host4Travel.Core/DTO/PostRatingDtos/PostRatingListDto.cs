using System;

namespace Host4Travel.Core.DTO.PostRatingDtos
{
    public class PostRatingListDto
    {
        public Guid PostRatingId { get; set; }
        public Guid? PostId { get; set; }
        public int? RatingValue { get; set; }
        public bool? IsActive { get; set; }
        public string OwnerId { get; set; }
        public string RatingComment { get; set; }
        
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public Guid PostApplicationId { get; set; }
    }
}