using System;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.UserDtos;

namespace Host4Travel.Core.DTO.PostRatingDtos
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
        public virtual UserListDto Owner { get; set; }
        public virtual PostListDto Post { get; set; }
    }
}