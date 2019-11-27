using System;

namespace Host4Travel.Core.DTO.PostImageDtos
{
    public class PostImageListDto
    {
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
    }
}