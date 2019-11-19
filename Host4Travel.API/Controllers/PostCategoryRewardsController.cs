using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostCategoryRewardService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostCategoryRewardsController : Controller
    {
        private IPostCategoryRewardService _postCategoryRewardService;
        private IExceptionHandler _exceptionHandler;

        public PostCategoryRewardsController(IPostCategoryRewardService postCategoryRewardService, IExceptionHandler exceptionHandler)
        {
            _postCategoryRewardService = postCategoryRewardService;
            _exceptionHandler = exceptionHandler;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var postCategoryRewards = _postCategoryRewardService.GetAllRelations();
            
            if (postCategoryRewards == null)
            {
                return NotFound($"Herhangi bir kayıt bulunamadı");
            }

            return Ok(postCategoryRewards);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var postCategoryReward = _postCategoryRewardService.GetRelationById(id);
            if (postCategoryReward == null)
            {
                return NotFound($"{id} için kayıt bulunamadı");
            }

            return Ok(postCategoryReward);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(PostCategoryRewardAddDto dto)
        {
            try
            {
                _postCategoryRewardService.Add(dto);
                return Ok("Post category reward başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostCategoryRewardAddDto dto)
        {
            try
            {
                _postCategoryRewardService.Update(dto);
                return Ok("Post category reward başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(PostCategoryRewardDeleteDto dto)
        {
            try
            {
                _postCategoryRewardService.Delete(dto);
                return Ok("Post category reward başarıyla silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        
    }
}