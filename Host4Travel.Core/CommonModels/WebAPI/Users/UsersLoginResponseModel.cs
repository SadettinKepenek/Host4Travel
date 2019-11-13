using System;
using System.Net;

namespace Host4Travel.Core.WebAPI.Models.Users
{
    public class UsersLoginResponseModel
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public string Username { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}