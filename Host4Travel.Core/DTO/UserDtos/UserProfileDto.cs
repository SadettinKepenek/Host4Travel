using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.Core.DTO.UserDtos
{
    public class UserProfileDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<PostListDto> Post { get; set; }
        public virtual ICollection<PostRatingDetailDto> PostRating { get; set; }
    }
}