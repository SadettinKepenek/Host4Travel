﻿using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesRewardsController : Controller
    {
        private ICategoryRewardService _categoryRewardService;
        private IExceptionHandler _exceptionHandler;

        public CategoriesRewardsController(IExceptionHandler exceptionHandler, ICategoryRewardService categoryRewardService)
        {
            _exceptionHandler = exceptionHandler;
            _categoryRewardService = categoryRewardService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok();
        }
        
    }
}