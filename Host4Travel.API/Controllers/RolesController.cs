﻿using System.Linq;
 using System.Threading.Tasks;
 using Host4Travel.Core.BLL.Concrete.WebAPI.Roles;
 using Host4Travel.Core.SystemProperties;
 using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Options;

 namespace Host4Travel.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private RoleManager<ApplicationIdentityRole> _roleManager;

        public RolesController( UserManager<ApplicationIdentityUser> userManager, SignInManager<ApplicationIdentityUser> signInManager, RoleManager<ApplicationIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = _roleManager.Roles.ToList();
            if (roles.Count==0)
            {
                return NotFound();
            }
            return Ok(roles);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> Add([FromBody] RolesAddModel role)
        {
            bool isRoleExists = await _roleManager.RoleExistsAsync(role.RoleName);
            if (isRoleExists)
            {
                return BadRequest("Rol zaten mevcut");
            }
            var identityRole=new ApplicationIdentityRole();
            identityRole.Name = role.RoleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                return Problem("Rol eklenirken hata oluştu lütfen site sahibi ile iletişime geçiniz.");
            }
            return Ok(identityRole);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RolesAssignRoleModel roleModel)
        {
            var user = await _userManager.FindByNameAsync(roleModel.Username);
            var role = await _roleManager.FindByNameAsync(roleModel.Rolename);
            if (user==null)
            {
                return BadRequest("Kullanıcı bulunamadı");
            }

            if (role==null)
            {
                return BadRequest("Rol Bulunamadı");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return Ok("Rol atama işlemi başarılı");
            }
            
            
            return Problem("Rol atama işlemi yapılamadı lütfen site yöneticisi ile iletişime geçin");
        }
        
        
        
    }
}