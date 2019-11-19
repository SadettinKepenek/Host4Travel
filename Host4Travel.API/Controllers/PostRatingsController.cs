using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostRatingService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostRatingsController : Controller
    {
        // GET
        private IPostRatingService _postRatingService;
        private IExceptionHandler _exceptionHandler;

        public PostRatingsController(IPostRatingService postRatingService, IExceptionHandler exceptionHandler)
        {
            _postRatingService = postRatingService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postRatingService.GetAllRatings();
            if (entities==null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostRatingUpdateDto model)
        {
            try
            {
                _postRatingService.UpdateRating(model);
                return Ok("Post Rating başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostRatingAddDto model)
        {
            try
            {
                _postRatingService.AddRating(model);
                return Ok("Post Rating Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] PostRatingDeleteDto model)
        {
            try
            {
                _postRatingService.DeleteRating(model);
                return Ok("Post Rating Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        

    }
}