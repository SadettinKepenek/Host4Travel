using System;

namespace Host4Travel.Core.DTO.PostDiscussionDtos
{
    public class PostDiscussionListDto
    {
        public Guid PostDiscussionId { get; set; }
        public Guid PostId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CommentId { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CommentDate { get; set; }

        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        
        public string ParentComment { get; set; }
        public string ParentOwnerId { get; set; }

        public string OwnerFirstname { get; set; }
        public string OwnerLastname { get; set; }
        public string OwnerEmail { get; set; }
        
        public Guid PostDiscussionParentId { get; set; }
    }
}