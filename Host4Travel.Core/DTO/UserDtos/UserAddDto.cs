using System;
using System.Net;

namespace Host4Travel.Core.DTO.AuthService
{
    public class UserAddDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public string Email { get; set; }
        public DateTime CookieAcceptDate { get; set; }
        public bool IsCookieAccepted { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

        public string AboutMe { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string ViberUrl { get; set; }

    }
}