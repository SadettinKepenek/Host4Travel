using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.CategoryRewardService;
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
            var entities = _categoryRewardService.GetAllRelationsWithDetails();
            if (entities==null)
            {
                return NotFound("Herhangi bir sonuç bulunamadı");
            }
            return Ok(entities);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = _categoryRewardService.GetRelationByIdWithDetails(id);
            if (entity==null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CategoryRewardAddDto model)
        {
            try
            {
                _categoryRewardService.AddRelation(model);
                return Ok("Category Reward Relationı başarı ile eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryRewardUpdateDto model)
        {
            try
            {
                _categoryRewardService.UpdateRelation(model);
                return Ok("Category Reward Relationı başarı ile güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryRewardDeleteDto model)
        {
            try
            {
                _categoryRewardService.DeleteRelation(model);
                return Ok("Category Reward Relationı başarı ile silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
    }
}