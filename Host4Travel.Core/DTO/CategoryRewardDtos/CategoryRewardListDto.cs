﻿using System;

namespace Host4Travel.Core.DTO.CategoryRewardDtos
{
    public class CategoryRewardListDto
    {
        public Guid CategoryRewardId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public string CategoryName { get; set; }
        public string RewardName { get; set; }
        public bool IsActive { get; set; }

    }
}