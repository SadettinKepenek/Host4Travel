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
        public Guid PostDiscussionParentId { get; set; }
    }
}