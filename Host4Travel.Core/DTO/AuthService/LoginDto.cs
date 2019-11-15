using System;
using System.Net;

namespace Host4Travel.Core.DTO.AuthService
{
    public class LoginDto
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public string Username { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}