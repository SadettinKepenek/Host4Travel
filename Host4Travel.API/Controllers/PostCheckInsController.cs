using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostCheckInService;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostCheckInsController : Controller
    {
        private IPostCheckInService _postCheckInService;
        private IExceptionHandler _exceptionHandler;

        public PostCheckInsController(IPostCheckInService postCheckInService, IExceptionHandler exceptionHandler)
        {
            _postCheckInService = postCheckInService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postCheckInService.GetAll();
            if (entities==null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<PostCheckInListDto>> responseModelWithData = new ResponseModelWithData<List<PostCheckInListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostCheckInAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCheckInService.Add(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostCheckIn Başarıyla eklendi";
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
        public async Task<IActionResult> Update([FromBody] PostCheckInUpdateDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCheckInService.Update(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostCheckIn başarıyla güncellendi";
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
        public async Task<IActionResult> Delete([FromBody] PostCheckInDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCheckInService.Delete(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "PostCheckIn başarıyla silindi";
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