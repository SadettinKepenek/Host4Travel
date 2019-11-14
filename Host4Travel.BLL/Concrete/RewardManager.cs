using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class RewardManager:IRewardService
    {
        private IRewardDal _rewardDal;

        public RewardManager(IRewardDal rewardDal)
        {
            _rewardDal = rewardDal;
        }

        public Reward Get(Expression<Func<Reward, bool>> filter = null)
        {
            return null;
        }

        public List<Reward> GetAll(Expression<Func<Reward, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(Reward entity)
        {
            return null;
        }

        public ResultModel Update(Reward entity)
        {
            return null;
        }

        public ResultModel Delete(Reward entity)
        {
            return null;
        }
    }
}