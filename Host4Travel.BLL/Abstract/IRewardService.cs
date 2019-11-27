using System.Collections.Generic;
using Host4Travel.Core.DTO.RewardDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IRewardService
    {
        List<RewardListDto> GetAllRewards();
        RewardDetailDto GetRewardById(int rewardId);      
        void AddReward(RewardAddDto model);
        void UpdateReward(RewardUpdateDto model);
        void DeleteReward(RewardDeleteDto model);
    }
}