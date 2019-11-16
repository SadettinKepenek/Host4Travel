using System;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.CategoryRewardService
{
    public class CategoryRewardUpdateDto
    {
        public Guid CategoryRewardId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public bool IsActive { get; set; }

     
    }
}