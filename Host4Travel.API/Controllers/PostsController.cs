using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private IPostService _postService;

        private IExceptionHandler _exceptionHandler;

        public PostsController(IPostService postService, IExceptionHandler exceptionHandler)
        {
            _postService = postService;
            _exceptionHandler = exceptionHandler;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var posts = _postService.GetAllPosts();
            if (posts==null)
            {
                return NotFound("Herhangi bir kayıt bulunamadı");
            }
            return Ok(posts);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post = _postService.GetPost(id);
            if (post==null)
            {
                return NotFound($"{id} için kayıt bulunamadı");
            }

            return Ok(post);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            try
            {
                _postService.AddPost(postAddDto);
                return Ok("Post Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostUpdateDto postUpdateDto)
        {
            try
            {
                _postService.UpdatePost(postUpdateDto);
                return Ok("Post Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(PostDeleteDto deleteDto)
        {
            try
            {
                _postService.DeletePost(deleteDto);
                return Ok("Post Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}