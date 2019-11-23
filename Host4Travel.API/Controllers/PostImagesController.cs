using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
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
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<PostImageListDto>> responseModelWithData = new ResponseModelWithData<List<PostImageListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostImageAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postImageService.AddImage(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostImage başarıyla eklendi";
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
        public async Task<IActionResult> Update([FromBody] PostImageAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postImageService.UpdateImage(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostImage başarıyla güncellendi";
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
        public async Task<IActionResult> Delete([FromBody] PostImageDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postImageService.DeleteImage(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostImage başarıyla silindi";
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