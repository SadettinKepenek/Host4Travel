using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class PostDiscussion
    {
        public PostDiscussion()
        {
            InverseCommentNavigation = new HashSet<PostDiscussion>();
        }

        public Guid PostDiscussionId { get; set; }
        public Guid PostId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CommentId { get; set; }
        public string Comment { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual PostDiscussion CommentNavigation { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<PostDiscussion> InverseCommentNavigation { get; set; }
    }
}
