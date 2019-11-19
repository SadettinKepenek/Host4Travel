using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostDiscussionService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostDiscussionsController : Controller
    {
        private IPostDiscussionService _postDiscussionService;
        private IExceptionHandler _exceptionHandler;

        public PostDiscussionsController(IPostDiscussionService postDiscussionService, IExceptionHandler exceptionHandler)
        {
            _postDiscussionService = postDiscussionService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postDiscussionService.GetAll();
            if (entities == null)
            {
                return NotFound("Herhangi bir kayıt bulunamadı");
            }

            return Ok(entities);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostDiscussionAddDto model)
        {
            try
            {
                _postDiscussionService.Add(model);
                return Ok("Post Discussion başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostDiscussionUpdateDto dto)
        {
            try
            {
                _postDiscussionService.Update(dto);
                return Ok("Post Discussion başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] PostDiscussionDeleteDto dto)
        {
            try
            {
                _postDiscussionService.Delete(dto);
                return Ok("Post Discussion Başarıyla silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}