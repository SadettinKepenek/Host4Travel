﻿using Host4Travel.Core.AppSettings;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public RolesController(AppSettings appSettings, UserManager<ApplicationIdentityUser> userManager, SignInManager<ApplicationIdentityUser> signInManager)
        {
            _appSettings = appSettings;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
    }
}