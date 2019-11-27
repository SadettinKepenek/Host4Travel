using System;
using Host4Travel.Core.DTO.PostDtos;

namespace Host4Travel.Core.DTO.PostImageDtos
{
    public class PostImageDetailDto
    {
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

        public virtual PostListDto Post { get; set; }
    }
}