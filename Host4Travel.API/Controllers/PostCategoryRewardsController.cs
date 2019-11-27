using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostCategoryRewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostCategoryRewardsController : Controller
    {
        private IPostCategoryRewardService _postCategoryRewardService;
        private IExceptionHandler _exceptionHandler;

        public PostCategoryRewardsController(IPostCategoryRewardService postCategoryRewardService, IExceptionHandler exceptionHandler)
        {
            _postCategoryRewardService = postCategoryRewardService;
            _exceptionHandler = exceptionHandler;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var postCategoryRewards = _postCategoryRewardService.GetAllRelations();
            
            if (postCategoryRewards == null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayit bulunamadi"
                });
            }
            ResponseModelWithData<List<PostCategoryRewardListDto>> responseModelWithData = new ResponseModelWithData<List<PostCategoryRewardListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = postCategoryRewards;
            return Ok(responseModelWithData);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var postCategoryReward = _postCategoryRewardService.GetRelationById(id);
            if (postCategoryReward == null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"{id} için kayıt bulunamadı"
                });
            }
            ResponseModelWithData<PostCategoryRewardDetailDto> responseModelWithData = new ResponseModelWithData<PostCategoryRewardDetailDto>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = $"{id} başarıyla getirildi";
            responseModelWithData.Data = postCategoryReward;
            return Ok(responseModelWithData);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]PostCategoryRewardAddDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCategoryRewardService.Add(dto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post category reward başarıyla eklendi";
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
        public async Task<IActionResult> Update(PostCategoryRewardAddDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCategoryRewardService.Update(dto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post category reward başarıyla güncellendi";
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
        public async Task<IActionResult> Delete(PostCategoryRewardDeleteDto dto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _postCategoryRewardService.Delete(dto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Post category reward başarıyla silindi";
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