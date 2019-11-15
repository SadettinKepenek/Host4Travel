using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.UI
{
    public partial class Category
    {
        public Category()
        {
            CategoryReward = new HashSet<CategoryReward>();
            InverseCategoryParent = new HashSet<Category>();
            PostCategoryReward = new HashSet<PostCategoryReward>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int CategoryLevel { get; set; }
        public int? CategoryParentId { get; set; }
        public string CategoryUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual Category CategoryParent { get; set; }
        public virtual ICollection<CategoryReward> CategoryReward { get; set; }
        public virtual ICollection<Category> InverseCategoryParent { get; set; }
        public virtual ICollection<PostCategoryReward> PostCategoryReward { get; set; }
    }
}
