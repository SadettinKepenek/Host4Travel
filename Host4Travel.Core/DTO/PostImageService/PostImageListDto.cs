using System;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.UI;

namespace Host4Travel.Core.DTO.PostImageService
{
    public class PostImageListDto
    {
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

        public virtual PostListDto Post { get; set; }
    }
}