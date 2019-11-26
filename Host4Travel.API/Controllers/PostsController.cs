using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
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
                ResponseModel model=new ResponseModel()
                {
                    Message = "No content",
                    StatusCode = HttpStatusCode.NoContent
                };
                return BadRequest(model);
            }
            return Ok(new ResponseModelWithData<List<PostListDto>>()
            {
                Data = posts,
                Message = "OK",
                StatusCode = HttpStatusCode.OK
            });
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(string userId)
        {
            
            var posts = _postService.GetByUser(userId);
            if (posts==null)
            {
                ResponseModel model=new ResponseModel()
                {
                    Message = "No content",
                    StatusCode = HttpStatusCode.NoContent
                };
                return BadRequest(model);
            }
            return Ok(new ResponseModelWithData<List<PostListDto>>()
            {
                Data = posts,
                Message = "OK",
                StatusCode = HttpStatusCode.OK
            });
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post = _postService.GetPost(id);
            if (post==null)
            {
                
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"{id} için kayıt bulunamadı"
                });
            }
            ResponseModelWithData<PostDetailDto> responseModelWithData = new ResponseModelWithData<PostDetailDto>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = $"{id} başarıyla getirildi";
            responseModelWithData.Data = post;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PostAddDto postAddDto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postService.AddPost(postAddDto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Başarıyla Eklendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
        
        

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostUpdateDto postUpdateDto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postService.UpdatePost(postUpdateDto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Başarıyla güncellendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(PostDeleteDto deleteDto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postService.DeletePost(deleteDto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Başarıyla silindi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
    }
}