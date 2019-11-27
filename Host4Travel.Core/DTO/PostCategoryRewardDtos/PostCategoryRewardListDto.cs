using System;

namespace Host4Travel.Core.DTO.PostCategoryRewardDtos
{
    public class PostCategoryRewardListDto
    {
        public Guid PostCategoryRewardId { get; set; }
        public Guid PostId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public string RewardValue { get; set; }

        public bool IsActive { get; set; }
        
        
    }
}