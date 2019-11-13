using System;
using System.Net;

namespace Host4Travel.Core.BLL.Concrete.AuthService
{
    public class GenerateTokenModel
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}