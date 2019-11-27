using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.Core.DTO.AuthService
{
    public class UserDetailDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<PostListDto> Post { get; set; }
        public virtual ICollection<PostApplicationListDto> PostApplication { get; set; }
        public virtual ICollection<PostRatingListDto> PostRating { get; set; }
        public virtual ICollection<DocumentListDto> Documents { get; set; }
    }
}