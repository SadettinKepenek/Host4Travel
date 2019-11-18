using System;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.PostApplicationService;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.PostRatingService
{
    public class PostRatingListDto
    {
        public Guid PostRatingId { get; set; }
        public Guid? PostId { get; set; }
        public int? RatingValue { get; set; }
        public string RatingComment { get; set; }
        public string RatingReply { get; set; }
        public bool? IsActive { get; set; }
        public string OwnerId { get; set; }
        public Guid? ApplicationId { get; set; }

        public virtual PostApplicationListDto Application { get; set; }
        public virtual ApplicationIdentityUserListDto Owner { get; set; }
        public virtual PostListDto Post { get; set; }
    }
}