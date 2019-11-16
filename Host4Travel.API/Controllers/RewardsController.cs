using System;
using System.Threading.Tasks;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.RewardService;
using Host4Travel.Core.Exceptions;
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
                return NotFound("Herhangi bir reward bulunamadı");
            }

            return Ok(rewards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reward = _rewardService.GetRewardById(id);
            if (reward==null)
            {
                return NotFound($"{id} için istenilen reward bulunamadı");
            }
            return Ok(reward);
        }

        [HttpPost("AddReward")]
        public async Task<IActionResult> AddReward([FromBody]RewardAddDto model)
        {
            try
            {
                _rewardService.AddReward(model);
                return Ok("Reward başarıyla eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpPut("UpdateReward")]
        public async Task<IActionResult> UpdateReward([FromBody]RewardUpdateDto model)
        {
            try
            {
                _rewardService.UpdateReward(model);
                return Ok("Reward başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
        [HttpDelete("DeleteReward")]
        public async Task<IActionResult> DeleteReward([FromBody]RewardDeleteDto model)
        {
            try
            {
                _rewardService.DeleteReward(model);
                return Ok("Reward başarıyla güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}