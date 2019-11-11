using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Host4Travel.API.Models;
using Host4Travel.Core.AppSettings;
using Host4Travel.UI;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Host4Travel.API.Controllers
{
    // GET
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private UserManager<ApplicationIdentityUser> _userManager;
        private SignInManager<ApplicationIdentityUser> _signInManager;
        public UserController(UserManager<ApplicationIdentityUser> userManager, IOptions<AppSettings>  appSettings, SignInManager<ApplicationIdentityUser> signInManager)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetAll()
        {
            return Ok(_userManager.Users.ToList());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] User userParam)
        {
            var user = Authenticate(userParam.Username, userParam.Password);


            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            return Ok(user);
        }

        public UserAuthorizeModel Authenticate(string username, string password)
        {
            var user = _userManager.FindByNameAsync(username).Result;
            // return null if user not found
            if (user == null)
                return null;
            bool resultSucceeded = _signInManager.CheckPasswordSignInAsync(user, password, false).Result.Succeeded;
            
            if (resultSucceeded)
            {
                // authentication successful so generate jwt token

                string tokenString = GenerateToken(user.UserName, user.Email);
                
                // remove password before returning

                var userAuthorizeModel = new UserAuthorizeModel() {Token = tokenString, Username = user.Id};
                userAuthorizeModel.ExpireTime = DateTime.Now.AddDays(7);
                return userAuthorizeModel;
            }

            return null;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] User user)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var createdUser =
                await _userManager.CreateAsync(
                    new ApplicationIdentityUser() {Email = user.Email, UserName = user.Username}, user.Password);
            if (createdUser.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest("Kullanıcı oluşturulamadı");
        }

        private string GenerateToken(string userId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.Email,email), 
                
            };
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

        [HttpPost("CheckTokenIsAlive")]
        public async Task<IActionResult> CheckTokenIsAlive()
        {
            var tokenExpiration = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "exp")?.Value;
            if (DateTime.Now.Millisecond<=int.Parse(tokenExpiration))
            {
                return Ok(true);
            }
            
            return BadRequest();
        }
      
    }
}