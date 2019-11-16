using Host4Travel.BLL.Abstract;
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
        
    }
}