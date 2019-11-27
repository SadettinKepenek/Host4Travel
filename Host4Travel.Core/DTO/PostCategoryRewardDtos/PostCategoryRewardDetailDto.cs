using System;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.RewardDtos;

namespace Host4Travel.Core.DTO.PostCategoryRewardDtos
{
    public class PostCategoryRewardDetailDto
    {
        public Guid PostCategoryRewardId { get; set; }
        public Guid PostId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public string RewardValue { get; set; }
        public bool IsActive { get; set; }

        public virtual CategoryListDto Category { get; set; }
        public virtual PostListDto Post { get; set; }
        public virtual RewardListDto Reward { get; set; }
    }
}