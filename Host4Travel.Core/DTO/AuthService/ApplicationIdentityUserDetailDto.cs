using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.DocumentService;
using Host4Travel.Core.DTO.PostApplicationService;
using Host4Travel.Core.DTO.PostRatingService;
using Host4Travel.Core.DTO.PostService;

namespace Host4Travel.Core.DTO.AuthService
{
    public class ApplicationIdentityUserDetailDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}