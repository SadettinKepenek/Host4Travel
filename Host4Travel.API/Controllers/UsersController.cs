﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Host4Travel.API.Extensions;
using Host4Travel.API.Models;
using Host4Travel.API.Models.Abstract;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.UserDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;
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


        public UsersController(IAuthService authService, UserManager<ApplicationIdentityUser> userManager,
            IExceptionHandler exceptionHandler)
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
                if (result == null)
                {
                    ResponseModelBase responseModel = new ResponseModel();
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = "No Content";
                    return BadRequest(responseModel);
                }
                else
                {
                    ResponseModelWithData<LoginResponseDto> responseModelWithData =
                        new ResponseModelWithData<LoginResponseDto>();
                    responseModelWithData.Message = "OK";
                    responseModelWithData.StatusCode = HttpStatusCode.OK;
                    responseModelWithData.Data = result;
                    return Ok(responseModelWithData);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserAddDto user)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Kayıt Başarılı";
                _authService.Register(user, user.Password);
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(UserDeleteDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _authService.Delete(dto);
                responseModel.Message = "Başarı ile silindi";
                responseModel.StatusCode = HttpStatusCode.OK;
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateModel,
            string password)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _authService.Update(userUpdateModel, password);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Başarı ile güncellendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }

        [HttpPost("CheckIsTokenAlive")]
        [Authorize]
        public async Task<IActionResult> CheckIsTokenAlive()
        {
            try
            {
                if (_authService.CheckTokenExpiration())
                {
                    return Ok(new ResponseModel
                    {
                        Message = "OK",
                        StatusCode = HttpStatusCode.OK
                    });
                }

                return Unauthorized(new ResponseModel()
                {
                    Message = "Token has been expired",
                    StatusCode = HttpStatusCode.Unauthorized
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                });
                ;
            }
        }

        [HttpGet("GetMyProfile")]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                var user = _authService.GetUser();
                if (user == null)
                {
                    return BadRequest(
                        new ResponseModel
                        {
                            Message = "Kullanıcı bulunamadı",
                            StatusCode = HttpStatusCode.NoContent
                        });
                }

                return Ok(new ResponseModelWithData<UserDetailDto>
                {
                    Data = user,
                    Message = "OK",
                    StatusCode = HttpStatusCode.OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }
        [HttpGet("GetUserProfile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile(string userId)
        {
            try
            {
                var user = _authService.GetUserDetail(userId);
                if (user == null)
                {
                    return BadRequest(
                        new ResponseModel
                        {
                            Message = "Kullanıcı bulunamadı",
                            StatusCode = HttpStatusCode.NoContent
                        });
                }

                return Ok(new ResponseModelWithData<UserProfileDto>
                {
                    Data = user,
                    Message = "OK",
                    StatusCode = HttpStatusCode.OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
        }
    }
}