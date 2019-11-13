using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
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

        public void Add(Reward entity)
        {
        }

        public void Update(Reward entity)
        {
        }

        public void Delete(Reward entity)
        {
        }
    }
}