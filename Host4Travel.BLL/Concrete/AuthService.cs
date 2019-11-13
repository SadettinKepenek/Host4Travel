using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Core.SystemProperties;
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
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public AuthService(IOptions<AppSettings>  appSettings, UserManager<ApplicationIdentityUser> userManager, SignInManager<ApplicationIdentityUser> signInManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public AuthenticateModel Login(UsersLoginModel userParam)
        {
            
            var user=_userManager.FindByNameAsync(userParam.Username).Result;
            bool resultSucceeded = MatchPasswordAndHash(user,userParam.Password);
            if (resultSucceeded)
            {
              
                var generateTokenModel = GenerateToken(user);
                var authenticateModel=new AuthenticateModel()
                {
                    Username = user.UserName,
                    Token = generateTokenModel.Token,
                    ResponseMessage = "Success",
                    StatusCode = HttpStatusCode.OK,
                    TokenExpireDate = generateTokenModel.TokenExpireDate
                };
                return authenticateModel;
            }

            var model = new AuthenticateModel();
            model.Token = String.Empty;
            model.Username = String.Empty;
            model.StatusCode = HttpStatusCode.Unauthorized;
            model.ResponseMessage = "Yetkisiz İşlem.";
            model.TokenExpireDate = DateTime.Now;
            return model;

        }

        public GenerateTokenModel GenerateToken(ApplicationIdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
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
            var model=new GenerateTokenModel();
            model.Token = tokenHandler.WriteToken(token);
            model.TokenExpireDate = expirationDate;
            
            return model;
        }

        public RegisterModel Register(UsersRegisterModel registerModel)
        {
            var identityUser = new ApplicationIdentityUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                Firstname = registerModel.Firstname,
                Lastname = registerModel.Lastname,
                CookieAcceptIpAddress = registerModel.CookieAcceptIpAddress,
                SSN = registerModel.Ssn
            };

            var createdUser =
                _userManager.CreateAsync(
                    identityUser, registerModel.Password);
            if (createdUser.Result.Succeeded)
            {
                return new RegisterModel()
                {
                    Message = "Kullanıcı başarı ile oluşturuldu",
                    StatusCode = HttpStatusCode.OK
                };
            }

            return new RegisterModel
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = String.Join(',',createdUser.Result.Errors.ToList())
            };
        }

        public StatusCodeResult CheckTokenExpiration(string expirationTime)
        {
            
            if (DateTime.Now.Millisecond<=int.Parse(expirationTime))
            {
                return new OkResult();
            }
            
            return new BadRequestResult();
        }

        public bool MatchPasswordAndHash(ApplicationIdentityUser applicationIdentityUser,string password)
        {
            if (applicationIdentityUser==null)
            {
                return false;
            }
            
            bool resultSucceeded = _signInManager.CheckPasswordSignInAsync(applicationIdentityUser, password, false).Result.Succeeded;
            return resultSucceeded;
        }
    }
}