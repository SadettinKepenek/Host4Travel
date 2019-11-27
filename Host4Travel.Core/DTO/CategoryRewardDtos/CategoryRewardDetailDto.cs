﻿using System;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.Core.DTO.RewardDtos;

namespace Host4Travel.Core.DTO.CategoryRewardDtos
{
    public class CategoryRewardDetailDto
    {
        public Guid CategoryRewardId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public bool IsActive { get; set; }

        public virtual CategoryDetailDto Category { get; set; }
        public virtual RewardDetailDto Reward { get; set; }
    }
}