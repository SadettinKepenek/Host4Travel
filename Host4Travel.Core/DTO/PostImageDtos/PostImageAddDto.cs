﻿using System;

namespace Host4Travel.Core.DTO.PostImageDtos
{
    public class PostImageAddDto
    {
        public Guid? ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }
        public bool IsPhotoNew { get; set; } = false;
    }
}