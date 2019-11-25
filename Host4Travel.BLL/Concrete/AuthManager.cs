using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.AuthService;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.Core.SystemSettings;
using Host4Travel.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Host4Travel.BLL.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly IPasswordHasher<ApplicationIdentityUser> _passwordHasher;
        private ICrpytoService _crpytoService;
        private IHttpContextAccessor _httpContext;
        private IExceptionHandler _exceptionHandler;
        private IMapper _mapper;

        public AuthService(UserManager<ApplicationIdentityUser> userManager,
            SignInManager<ApplicationIdentityUser> signInManager,
            IPasswordHasher<ApplicationIdentityUser> passwordHasher, IExceptionHandler exceptionHandler, ICrpytoService crpytoService, IHttpContextAccessor httpContext, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _exceptionHandler = exceptionHandler;
            _crpytoService = crpytoService;
            _httpContext = httpContext;
            _mapper = mapper;
        }

        public IdentityLoginResponseDto Login(IdentityLoginRequestDto dto)
        {
            try
            {
                LoginRequestValidator validator = new LoginRequestValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }

                //
                var user = _userManager.FindByNameAsync(dto.Username).Result;
                if (user==null)
                {
                    throw new NullReferenceException();
                }

                var decryptedPassword = _crpytoService.Decrypt(dto.Password);
                var resultSucceeded = MatchPasswordAndHash(user, decryptedPassword);
                if (resultSucceeded)
                {
                    var generateTokenModel = GenerateToken(user, Configuration.TokenExpirationDate);
                    var authenticateModel = new IdentityLoginResponseDto()
                    {
                        Username = user.UserName,
                        Token = generateTokenModel,
                        TokenExpireDate = Configuration.TokenExpirationDate
                    };
                    return authenticateModel;
                }

                throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış");
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        private string GenerateToken(ApplicationIdentityUser user, DateTime expireDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.SecretKey);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public void Register(ApplicationIdentityUserAddDto applicationIdentityUserAddModel, string password)
        {
            //
            try
            {
                RegisterValidator validator = new RegisterValidator();
                var validationResult = validator.Validate(applicationIdentityUserAddModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }

                var identityUser = new ApplicationIdentityUser
                {
                    Email = applicationIdentityUserAddModel.Email,
                    UserName = applicationIdentityUserAddModel.Username,
                    Firstname = applicationIdentityUserAddModel.Firstname,
                    Lastname = applicationIdentityUserAddModel.Lastname,
                    CookieAcceptIpAddress = applicationIdentityUserAddModel.CookieAcceptIpAddress,
                    IsVerified = applicationIdentityUserAddModel.IsVerified,
                    IsCookieAccepted = applicationIdentityUserAddModel.IsCookieAccepted,
                };
                string decryptedPassword = _crpytoService.Decrypt(password);
                var createdUser =
                    _userManager.CreateAsync(
                        identityUser, decryptedPassword);
                if (!createdUser.Result.Succeeded)
                {
                    throw new Exception("Kayıt sırasında hata oluştu.");
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(ApplicationIdentityUserUpdateDto applicationIdentityUserUpdateModel, string password)
        {
            try
            {
                UpdateValidator validator = new UpdateValidator();
                var validationResult = validator.Validate(applicationIdentityUserUpdateModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }

                var user = _userManager.FindByNameAsync(applicationIdentityUserUpdateModel.Username).Result;
                if (user == null)
                {
                    throw new NullReferenceException();
                }
                var newPassword = _passwordHasher.HashPassword(user, password);
                user.Firstname = applicationIdentityUserUpdateModel.Firstname;
                user.Lastname = applicationIdentityUserUpdateModel.Lastname;
                user.Email = applicationIdentityUserUpdateModel.Email;
                user.PasswordHash = newPassword;
                user.CookieAcceptDate = applicationIdentityUserUpdateModel.CookieAcceptDate;
                user.CookieAcceptIpAddress = applicationIdentityUserUpdateModel.CookieAcceptIpAddress;
                user.IsCookieAccepted = applicationIdentityUserUpdateModel.IsCookieAccepted;
                user.IsVerified = applicationIdentityUserUpdateModel.IsVerified;
                user.IsActive = applicationIdentityUserUpdateModel.IsActive;
                var result = _userManager.UpdateAsync(user).Result;
                if (!result.Succeeded)
                {
                    throw new Exception("Güncelleme sırasında hata oluştu");
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(ApplicationIdentityUserDeleteDto dto)
        {
            try
            {
                var validator = new DeleteValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    var applicationIdentityUser = _userManager.FindByNameAsync(dto.Username).Result;
                    if (applicationIdentityUser == null)
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var result = _userManager.DeleteAsync(applicationIdentityUser);
                        var returnModel = new ApplicationIdentityUserDeleteDto();
                        if (result.IsCompletedSuccessfully)
                        {
                            // Do Nothing
                        }
                        else if (result.IsFaulted)
                        {
                            throw new Exception("Silme sırasında hata oluştu");
                        }
                        else if (result.IsCanceled)
                        {
                            throw new Exception("Silme iptal edildi");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public ApplicationIdentityUserListDto GetUser()
        {
            var user = _httpContext.HttpContext.User.Identity.Name;
            if (user==null)
            {
                throw new NullReferenceException("");
            }

            var dbUser = _userManager.Users.
                Include(x => x.PostApplication).
                Include(x => x.Post).
                Include(x=>x.Documents).
                Include(x=>x.PostRating)
                .FirstOrDefault(x => x.NormalizedUserName == user);
            if (dbUser==null)
            {
                throw new NullReferenceException("");
            }

            var mappedUser = _mapper.Map<ApplicationIdentityUserListDto>(dbUser);
            return mappedUser;
        }

        public ApplicationIdentityUserDetailDto GetUserDetail(string userId)
        {
            var dbUser = _userManager.Users.
                Include(x => x.PostApplication).
                Include(x => x.Post).
                Include(x=>x.Documents).
                Include(x=>x.PostRating)
                .FirstOrDefault(x => x.Id == userId);
            if (dbUser==null)
            {
                throw new NullReferenceException("");
            }

            var mappedUser = _mapper.Map<ApplicationIdentityUserDetailDto>(dbUser);
            return mappedUser;
        }

        public bool CheckTokenExpiration()
        {
            var expClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "exp");
            if (expClaim==null)
            {
                throw new UnauthorizedAccessException("Geçerliliği kontrol edilmek istenilen token hatalı.");
            }
            DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(expClaim.Value)).ToLocalTime();
            return dtDateTime>DateTime.Now;
        }

        private bool MatchPasswordAndHash(ApplicationIdentityUser applicationIdentityUser, string password)
        {
            if (applicationIdentityUser == null)
            {
                return false;
            }

            bool resultSucceeded = _signInManager.CheckPasswordSignInAsync(applicationIdentityUser, password, false)
                .Result.Succeeded;
            return resultSucceeded;
        }
    }
}