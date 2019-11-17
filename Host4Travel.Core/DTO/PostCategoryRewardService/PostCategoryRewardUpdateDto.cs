using System;

namespace Host4Travel.Core.DTO.PostCategoryRewardService
{
    public class PostCategoryRewardUpdateDto
    {
        public Guid PostCategoryRewardId { get; set; }
        public Guid PostId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public string RewardValue { get; set; }
        public bool IsActive { get; set; }
    }
}