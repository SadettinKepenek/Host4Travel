﻿using System;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.Core.DTO.RewardService;

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