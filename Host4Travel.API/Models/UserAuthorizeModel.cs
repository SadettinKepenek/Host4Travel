using System;

namespace Host4Travel.API.Models
{
    public class UserAuthorizeModel
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
        
    }
}