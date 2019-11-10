using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class CategoryReward
    {
        public Guid CategoryRewardId { get; set; }
        public int CategoryId { get; set; }
        public int RewardId { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
