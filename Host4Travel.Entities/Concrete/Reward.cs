using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.UI
{
    public partial class Reward
    {
        public Reward()
        {
            CategoryReward = new HashSet<CategoryReward>();
            PostCategoryReward = new HashSet<PostCategoryReward>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CategoryReward> CategoryReward { get; set; }
        public virtual ICollection<PostCategoryReward> PostCategoryReward { get; set; }
    }
}
