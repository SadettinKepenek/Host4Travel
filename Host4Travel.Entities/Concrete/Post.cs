using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class Post
    {
        public Post()
        {
            Chat = new HashSet<Chat>();
            PostCategoryReward = new HashSet<PostCategoryReward>();
            PostDiscussion = new HashSet<PostDiscussion>();
            PostImage = new HashSet<PostImage>();
        }

        public Guid PostId { get; set; }
        public string PostTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PostDescription { get; set; }
        public bool PostType { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual AspNetUsers Owner { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<PostCategoryReward> PostCategoryReward { get; set; }
        public virtual ICollection<PostDiscussion> PostDiscussion { get; set; }
        public virtual ICollection<PostImage> PostImage { get; set; }
    }
}
