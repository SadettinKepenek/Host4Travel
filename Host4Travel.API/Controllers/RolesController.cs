﻿using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using System.Threading.Tasks;
 using Host4Travel.API.Models.Concrete.Roles;
 using Host4Travel.API.Models.ResponseModels;
 using Host4Travel.Core.DTO.RewardService;
 using Host4Travel.Entities.Concrete;
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
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<ApplicationIdentityRole>> responseModelWithData = new ResponseModelWithData<List<ApplicationIdentityRole>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = roles;
            return Ok(responseModelWithData);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> Add([FromBody] RolesAddModel role)
        {
            bool isRoleExists = await _roleManager.RoleExistsAsync(role.RoleName);
            if (isRoleExists)
            {
                
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Rol zaten mevcut"
                });
            }
            var identityRole=new ApplicationIdentityRole();
            identityRole.Name = role.RoleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Rol eklenirken hata oluştu lütfen site sahibi ile iletişime geçiniz."
                });
            }
            ResponseModel responseModel = new ResponseModel();
            responseModel.StatusCode = HttpStatusCode.OK;
            responseModel.Message = "Rol başarıyla eklendi";
            return Ok(responseModel);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RolesAssignRoleModel roleModel)
        {
            var user = await _userManager.FindByNameAsync(roleModel.Username);
            var role = await _roleManager.FindByNameAsync(roleModel.Rolename);
            if (user==null)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Kullanıcı bulunamadı"
                });
            }

            if (role==null)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Rol bulunamadı"
                });
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return Ok(new ResponseModel
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Rol atama işlemi başarılı"
                });
            }
            
            ResponseModel responseModel = new ResponseModel();
            responseModel.StatusCode = HttpStatusCode.BadRequest;
            responseModel.Message = "Rol atama işlemi yapılamadı lütfen site yöneticisi ile iletişime geçin";
            return BadRequest(responseModel);
        }
        
        
        
    }
}