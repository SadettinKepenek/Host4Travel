using System;

namespace Host4Travel.Core.DTO.PostRatingService
{
    public class PostRatingUpdateDto
    {
        public Guid PostRatingId { get; set; }
        public Guid? PostId { get; set; }
        public int? RatingValue { get; set; }
        public string RatingComment { get; set; }
        public string RatingReply { get; set; }
        public bool? IsActive { get; set; }
        public string OwnerId { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}