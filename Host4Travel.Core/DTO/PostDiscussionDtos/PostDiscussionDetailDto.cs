﻿using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.UserDtos;

namespace Host4Travel.Core.DTO.PostDiscussionDtos
{
    public class PostDiscussionDetailDto
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
        public virtual UserListDto Owner { get; set; }
    }
}