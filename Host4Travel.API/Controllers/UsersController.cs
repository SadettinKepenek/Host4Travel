using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Host4Travel.API.Extensions;
using Host4Travel.API.Models.Users;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Core.BLL.Concrete.WebAPI.Users;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Host4Travel.API.Controllers
{
    // GET
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private UserManager<ApplicationIdentityUser> _userManager;
        private IExceptionHandler _exceptionHandler;
        

        public UsersController(IAuthService authService, UserManager<ApplicationIdentityUser> userManager, IExceptionHandler exceptionHandler)
        {
            _authService = authService;
            _userManager = userManager;
            _exceptionHandler = exceptionHandler;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto userModel)
        {
            try
            {
                
                var result = _authService.Login(userModel);
                if (result==null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
            

        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
          

            var newUser=new ApplicationIdentityUser()
            {
                //mapping
            };
            try
            {
                _authService.Register(user,user.Password);
                return Ok("Kayıt başarılı");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string userId)
        {
//            DeleteDto deleteResponseModel=new DeleteDto();
//            var result = _authService.Delete(userId);
//            deleteResponseModel.Message = result.Message;
//            deleteResponseModel.StatusCode = result.StatusCode;
//            if (deleteResponseModel.StatusCode==HttpStatusCode.OK)
//            {
//                return Ok(deleteResponseModel);
//
//            }
//
//            if (deleteResponseModel.StatusCode==HttpStatusCode.BadRequest)
//            {
//                return BadRequest(deleteResponseModel);
//            }

            return Conflict(null);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ApplicationIdentityUser updateModel,string password)
        {
            
//            var result = _authService.Update(updateModel,password);
//            if (result.StatusCode==HttpStatusCode.OK)
//            {
//                return Ok(result);
//            }
            return BadRequest(null);
        }
    }
}