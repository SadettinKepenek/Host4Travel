using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.RewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : Controller
    {
        private IRewardService _rewardService;
        private IExceptionHandler _exceptionHandler;

        public RewardsController(IRewardService rewardService, IExceptionHandler exceptionHandler)
        {
            _rewardService = rewardService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var rewards = _rewardService.GetAllRewards();
            if (rewards==null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            
            ResponseModelWithData<List<RewardListDto>> responseModelWithData = new ResponseModelWithData<List<RewardListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = rewards;
            return Ok(responseModelWithData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reward = _rewardService.GetRewardById(id);
            if (reward==null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"{id} için kayıt bulunamadı"
                });
            }
            ResponseModelWithData<RewardListDto> responseModelWithData = new ResponseModelWithData<RewardListDto>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = $"{id} başarıyla getirildi";
            responseModelWithData.Data = reward;
            return Ok(responseModelWithData);
        }

        [HttpPost("AddReward")]
        public async Task<IActionResult> AddReward([FromBody]RewardAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _rewardService.AddReward(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Reward başarıyla eklendi";
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
        [HttpPut("UpdateReward")]
        public async Task<IActionResult> UpdateReward([FromBody]RewardUpdateDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _rewardService.UpdateReward(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Reward başarıyla güncellendi";
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
        [HttpDelete("DeleteReward")]
        public async Task<IActionResult> DeleteReward([FromBody]RewardDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _rewardService.DeleteReward(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Reward başarıyla silindi";
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