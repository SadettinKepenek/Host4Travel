using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.AppSettings;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Host4Travel.BLL.Concrete
{
    public class AuthService:IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContext;
        private UserManager<ApplicationIdentityUser> _userManager;
        private RoleManager<ApplicationIdentityRole> _roleManager;
        private SignInManager<ApplicationIdentityUser> _signInManager;

        public AuthService(IOptions<AppSettings>  appSettings, IHttpContextAccessor httpContext, UserManager<ApplicationIdentityUser> userManager, RoleManager<ApplicationIdentityRole> roleManager, SignInManager<ApplicationIdentityUser> signInManager)
        {
            _appSettings = appSettings.Value;
            _httpContext = httpContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public AuthenticateModel Authenticate(User userParam)
        {
            
            var user=_userManager.FindByNameAsync(userParam.Username).Result;
            bool resultSucceeded = CheckUserIsValid(userParam,user);
            if (resultSucceeded)
            {
                return GenerateToken(user);
            }
            else
            {
                return new AuthenticateModel()
                {
                    Token = String.Empty,
                    Username = String.Empty,
                    StatusCode = HttpStatusCode.Unauthorized,
                    ResponseMessage = "Yetkisiz İşlem.",
                    TokenExpireDate = DateTime.Now
                };
            }
            
        }

      
     

        public AuthenticateModel GenerateToken(ApplicationIdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generateTokenModel = new AuthenticateModel()
            {
                Token = tokenHandler.WriteToken(token),
                Username = user.UserName,
                ResponseMessage = "Success",
                StatusCode = HttpStatusCode.OK,
                TokenExpireDate = expirationDate
            };
            return generateTokenModel;
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

        public bool CheckUserIsValid(User userParam, ApplicationIdentityUser applicationIdentityUser)
        {
            if (applicationIdentityUser==null)
            {
                return false;
            }
            
            bool resultSucceeded = _signInManager.CheckPasswordSignInAsync(applicationIdentityUser, userParam.Password, false).Result.Succeeded;
            return resultSucceeded;
        }
    }
}