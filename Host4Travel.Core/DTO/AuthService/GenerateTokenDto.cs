using System;

namespace Host4Travel.Core.DTO.AuthService
{
    public class GenerateTokenDto
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}