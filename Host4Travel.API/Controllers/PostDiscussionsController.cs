using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
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
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<PostDiscussionListDto>> responseModelWithData = new ResponseModelWithData<List<PostDiscussionListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostDiscussionAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postDiscussionService.Add(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Discussion başarıyla eklendi";
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
        public async Task<IActionResult> Update([FromBody] PostDiscussionUpdateDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postDiscussionService.Update(dto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Discussion başarıyla güncellendi";
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
        public async Task<IActionResult> Delete([FromBody] PostDiscussionDeleteDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postDiscussionService.Delete(dto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post Discussion başarıyla silindi";
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