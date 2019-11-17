using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.UI
{
    public partial class PostApplication
    {
        public PostApplication()
        {
        }

        [Key]
        public Guid PostApplicationId { get; set; }
        public Guid PostId { get; set; }
        public string ApplicentId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ApplicationIdentityUser Applicent { get; set; }
        public virtual PostCheckIn PostCheckIn { get; set; }
        public virtual PostRating PostRating { get; set; }
    }
}
