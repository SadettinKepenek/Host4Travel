using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
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
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<PostRatingListDto>> responseModelWithData  = new ResponseModelWithData<List<PostRatingListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostRatingUpdateDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postRatingService.UpdateRating(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Rating başarıyla güncellendi";
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
        
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostRatingAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postRatingService.AddRating(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Rating başarıyla eklendi";
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
        public async Task<IActionResult> Delete([FromBody] PostRatingDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postRatingService.DeleteRating(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Rating başarıyla silindi";
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