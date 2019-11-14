using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryRewardManager:ICategoryRewardService
    {
        private ICategoryRewardDal _categoryRewardDal;

        public CategoryRewardManager(ICategoryRewardDal categoryRewardDal)
        {
            _categoryRewardDal = categoryRewardDal;
        }

        public CategoryReward Get(Expression<Func<CategoryReward, bool>> filter = null)
        {
            return null;
        }

        public List<CategoryReward> GetAll(Expression<Func<CategoryReward, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(CategoryReward entity)
        {
            return null;
        }

        public ResultModel Update(CategoryReward entity)
        {
            return null;
        }

        public ResultModel Delete(CategoryReward entity)
        {
            return null;
        }
    }
}