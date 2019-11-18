using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.PostDiscussionService
{
    public class PostDiscussionListDto
    {
        public Guid PostDiscussionId { get; set; }
        public Guid PostId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CommentId { get; set; }
        public string Comment { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual PostDiscussionListDto CommentNavigation { get; set; }
        public virtual PostListDto Post { get; set; }
        public virtual ICollection<PostDiscussionListDto> InverseCommentNavigation { get; set; }
    }
}