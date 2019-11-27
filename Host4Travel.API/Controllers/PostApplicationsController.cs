using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostApplicationsController : Controller
    {
        private IPostApplicationService _postApplicationService;
        private IExceptionHandler _exceptionHandler;

        public PostApplicationsController(IPostApplicationService postApplicationService, IExceptionHandler exceptionHandler)
        {
            _postApplicationService = postApplicationService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _postApplicationService.GetAllApplications();
            if (entities==null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Herhangi bir kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<PostApplicationListDto>> responseModelWithData = new ResponseModelWithData<List<PostApplicationListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostApplicationAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postApplicationService.AddApplication(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Başvuru başarıyla eklendi";
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
        public async Task<IActionResult> Update([FromBody] PostApplicationUpdateDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postApplicationService.UpdateApplication(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Başvuru başarıyla güncellendi";
                return Ok(responseModel);
;            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PostApplicationDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postApplicationService.DeleteApplication(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Başvuru başarıyla silindi";
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