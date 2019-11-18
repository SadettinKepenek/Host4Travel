using System;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.PostCheckInService;
using Host4Travel.Core.DTO.PostRatingService;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.PostApplicationService
{
    public class PostApplicationListDto
    {
        public Guid PostApplicationId { get; set; }
        public Guid PostId { get; set; }
        public string ApplicentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ApplicationIdentityUserListDto Applicent { get; set; }
        public virtual PostCheckInListDto PostCheckIn { get; set; }
        public virtual PostRatingListDto PostRating { get; set; }
        
        public virtual PostListDto Post { get; set; }
    }
}