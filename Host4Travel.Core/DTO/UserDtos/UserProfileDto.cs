using System.Collections.Generic;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.Core.DTO.UserDtos
{
    public class UserProfileDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public string? AboutMe { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? ViberUrl { get; set; }
        public virtual ICollection<PostListDto> Post { get; set; }
        public virtual ICollection<PostRatingListDto> PostRating { get; set; }

    }
}