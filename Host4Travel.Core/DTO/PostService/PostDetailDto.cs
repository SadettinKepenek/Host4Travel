using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.PostCategoryRewardService;
using Host4Travel.Core.DTO.PostCheckInService;
using Host4Travel.Core.DTO.PostDiscussionService;
using Host4Travel.Core.DTO.PostImageService;
using Host4Travel.Core.DTO.PostRatingService;

namespace Host4Travel.Core.DTO.PostService
{
    public class PostDetailDto
    {
        public Guid PostId { get; set; }
        public string PostTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PostDescription { get; set; }
        public bool PostType { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual ApplicationIdentityUserListDto Owner { get; set; }
        public virtual ICollection<PostCategoryRewardListDto> PostCategoryReward { get; set; }
        public virtual ICollection<PostDiscussionListDto> PostDiscussion { get; set; }
        public virtual ICollection<PostImageListDto> PostImage { get; set; }
        public virtual ICollection<PostRatingListDto> PostRating { get; set; }
        public virtual PostCheckInListDto PostCheckIn { get; set; }
    }
}