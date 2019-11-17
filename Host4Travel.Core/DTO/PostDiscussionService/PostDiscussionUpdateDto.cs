﻿using System;

namespace Host4Travel.Core.DTO.PostDiscussionService
{
    public class PostDiscussionUpdateDto
    {
        public Guid PostDiscussionId { get; set; }
        public Guid PostId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CommentId { get; set; }
        public string Comment { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CommentDate { get; set; }
    }
}