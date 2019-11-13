using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Host4Travel.API.Extensions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete.AuthService;
using Host4Travel.Core.BLL.Concrete.WebAPI.Users;
using Host4Travel.Core.WebAPI.Models.Users;
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

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UsersLoginModel userModel)
        {
            if (!ModelState.IsValid)
            {
                Response.AddApplicationError("Kullanıcı verileri düzgün getirilemedi");
                return BadRequest(ModelState);
            }

            var result = _authService.Login(userModel);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return Unauthorized("Kullanıcı adı veya şifre yanlış");
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UsersRegisterModel user)
        {
            if (!ModelState.IsValid)
            {
                Response.AddApplicationError("Veri istenildiği gibi getirilemedi.");
                return BadRequest(ModelState);
            }

            var result = _authService.Register(user);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return Ok(new UsersRegisterResponseModel()
                {
                    Message = result.Message,
                    StatusCode = HttpStatusCode.OK
                });
            }

            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(new UsersRegisterResponseModel()
                {
                    Message = result.Message,
                    StatusCode = HttpStatusCode.OK
                });
            }

            return Conflict(new UsersRegisterResponseModel()
            {
                Message = result.Message,
                StatusCode = HttpStatusCode.Conflict
            });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string userId)
        {
            UsersDeleteResponseModel deleteResponseModel=new UsersDeleteResponseModel();
            var result = _authService.Delete(userId);
            deleteResponseModel.Message = result.Message;
            deleteResponseModel.StatusCode = result.StatusCode;
            if (deleteResponseModel.StatusCode==HttpStatusCode.OK)
            {
                return Ok(deleteResponseModel);

            }

            if (deleteResponseModel.StatusCode==HttpStatusCode.BadRequest)
            {
                return BadRequest(deleteResponseModel);
            }

            return Conflict(deleteResponseModel);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UsersUpdateModel updateModel)
        {
            var result = _authService.Update(updateModel);
            if (result.StatusCode==HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}