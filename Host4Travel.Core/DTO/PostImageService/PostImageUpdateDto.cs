﻿using System;

namespace Host4Travel.Core.DTO.PostImageService
{
    public class PostImageUpdateDto
    {
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }
    }
}