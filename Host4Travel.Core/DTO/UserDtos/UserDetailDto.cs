using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.DTO.PostDtos;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.Core.DTO.UserDtos
{
    public class UserDetailDto
    {
        public string Id { get; set; }  

        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public DateTime CookieAcceptDate { get; set; }
        public bool IsCookieAccepted { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PostListDto> Post { get; set; }
        public virtual ICollection<PostApplicationListDto> PostApplication { get; set; }
        public virtual ICollection<PostRatingListDto> PostRating { get; set; }
        public virtual ICollection<DocumentListDto> Documents { get; set; }
        

    }
}