using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.AppSettings;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Host4Travel.BLL.Concrete
{
    public class AuthService:IAuthService
    {
        private readonly AppSettings AppSettings;
        private IHttpContextAccessor _httpContext;
        private IConfiguration _configuration;

        public AuthService(IOptions<AppSettings>  appSettings, IHttpContextAccessor httpContext)
        {
            AppSettings = appSettings.Value;
            _httpContext = httpContext;
        }
        public string GenerateToken(ApplicationIdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email,user.Email));
            
            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public StatusCodeResult CheckTokenExpiration()
        {
            var tokenExpiration = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "exp")?.Value;
            if (DateTime.Now.Millisecond<=int.Parse(tokenExpiration))
            {
                return new OkResult();
            }
            
            return new BadRequestResult();
        }
    }
}