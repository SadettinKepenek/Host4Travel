using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostCategoryRewardDtos;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.Core.DTO.PostDiscussionDtos;
using Host4Travel.Core.DTO.PostImageDtos;
using Host4Travel.Core.DTO.PostRatingDtos;
using Host4Travel.Core.DTO.UserDtos;

namespace Host4Travel.Core.DTO.PostDtos
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

        public virtual UserListDto Owner { get; set; }
        public virtual ICollection<PostCategoryRewardListDto> PostCategoryReward { get; set; }
        public virtual ICollection<PostDiscussionListDto> PostDiscussion { get; set; }
        public virtual ICollection<PostImageListDto> PostImage { get; set; }
        public virtual ICollection<PostRatingListDto> PostRating { get; set; }
        public virtual PostCheckInListDto PostCheckIn { get; set; }
    }
}