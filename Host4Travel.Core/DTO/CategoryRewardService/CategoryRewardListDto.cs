using System;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.DTO.RewardService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.CategoryRewardService
{
    public class CategoryRewardListDto
    {
        public Guid CategoryRewardId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public bool IsActive { get; set; }

        public virtual CategoryListDto Category { get; set; }
        public virtual RewardListDto Reward { get; set; }
    }
}