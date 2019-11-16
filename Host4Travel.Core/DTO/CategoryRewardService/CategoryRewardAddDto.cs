using System;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.CategoryRewardService
{
    public class CategoryRewardAddDto
    {
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public bool IsActive { get; set; }


    }
}