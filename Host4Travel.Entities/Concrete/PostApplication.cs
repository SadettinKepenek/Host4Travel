using System;
using System.Collections.Generic;
using Host4Travel.UI.Identity;

namespace Host4Travel.UI
{
    public partial class PostApplication
    {
        public PostApplication()
        {
            PostCheckIn = new HashSet<PostCheckIn>();
            PostRating = new HashSet<PostRating>();
        }

        public Guid PostApplicationId { get; set; }
        public Guid PostId { get; set; }
        public string ApplicentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ApplicationIdentityUser Applicent { get; set; }
        public virtual ICollection<PostCheckIn> PostCheckIn { get; set; }
        public virtual ICollection<PostRating> PostRating { get; set; }
    }
}
