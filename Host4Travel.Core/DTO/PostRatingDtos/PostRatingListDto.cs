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
        public Guid PostApplicationId { get; set; }
    }
}