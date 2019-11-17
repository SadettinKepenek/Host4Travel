using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
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
        // GET

    }
}