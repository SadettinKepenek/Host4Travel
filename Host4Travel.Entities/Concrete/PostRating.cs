using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class PostRating
    {
        public Guid PostRatingId { get; set; }
        public Guid? PostId { get; set; }
        public int? RatingValue { get; set; }
        public string RatingComment { get; set; }
        public string RatingReply { get; set; }
        public bool? IsActive { get; set; }
        public string OwnerId { get; set; }
        public Guid? ApplicationId { get; set; }

        public virtual PostApplication Application { get; set; }
        public virtual AspNetUsers Owner { get; set; }
        public virtual Post Post { get; set; }
    }
}
