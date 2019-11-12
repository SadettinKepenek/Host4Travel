using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Host4Travel.UI
{
    public partial class PostCategoryReward
    {
        [Key]
        public Guid PostCategoryRewardId { get; set; }
        public Guid PostId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public string RewardValue { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
