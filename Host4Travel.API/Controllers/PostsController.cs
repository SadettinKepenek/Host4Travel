using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Get(Guid guid)
        {
            var result=_postService.Get(x => x.PostId == guid);
            if (result==null)
            {
                return NotFound("İstenilen posta ulaşılamadı");
            }
            return Ok(result);
        }
        
    }
}