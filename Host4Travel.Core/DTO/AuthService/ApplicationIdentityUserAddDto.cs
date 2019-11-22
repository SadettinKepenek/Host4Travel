using System;
using System.Net;

namespace Host4Travel.Core.DTO.AuthService
{
    public class ApplicationIdentityUserAddDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Ssn { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public string Email { get; set; }
        public DateTime CookieAcceptDate { get; set; }
        public bool IsCookieAccepted { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}