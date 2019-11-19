using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostImageService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostImagesController : Controller
    {
        private IPostImageService _postImageService;
        private IExceptionHandler _exceptionHandler;

        public PostImagesController(IPostImageService postImageService, IExceptionHandler exceptionHandler)
        {
            _postImageService = postImageService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postImageService.GetAllImages();
            if (entities==null)
            {
                return NotFound("Herhangi bir kayıt bulunamadı");
            }
            return Ok(entities);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostImageAddDto model)
        {
            try
            {
                _postImageService.AddImage(model);
                return Ok("PostImage başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostImageAddDto model)
        {
            try
            {
                _postImageService.UpdateImage(model);
                return Ok("PostImage başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] PostImageDeleteDto model)
        {
            try
            {
                _postImageService.DeleteImage(model);
                return Ok("Resim başarıyla silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

    }
}