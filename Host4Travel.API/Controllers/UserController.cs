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
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.AppSettings;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly IAuthService _authService;
        public UserController(UserManager<ApplicationIdentityUser> userManager, SignInManager<ApplicationIdentityUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] User userParam)
        {
            var result=_authService.Authenticate(userParam);
            if (result.StatusCode==HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return Unauthorized("Kullanıcı adı veya şifre yanlış");
        }

     
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                Response.AddApplicationError("Veri istenildiği gibi getirilemedi.");
                return BadRequest(ModelState);
            }
            var identityUser = new ApplicationIdentityUser
            {
                Email = user.Email,
                UserName = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                CookieAcceptIpAddress = user.CookieAcceptIpAddress,
                SSN = user.SSN
            };

            var createdUser =
                await _userManager.CreateAsync(
                    identityUser, user.Password);
            if (createdUser.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest("Kullanıcı oluşturulamadı");
        }
        
        [HttpGet("IsTokenAlive")]
        public async Task<IActionResult> CheckTokenIsAlive()
        {
            return _authService.CheckTokenExpiration();
        }
      
    }
}