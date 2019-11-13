using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
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
        public CategoryReward GetById(Expression<Func<CategoryReward, bool>> filter = null)
        {
            return null;
        }

        public List<CategoryReward> GetAll(Expression<Func<CategoryReward, bool>> filter = null)
        {
            return null;
        }

        public void Add(CategoryReward entity)
        {
        }

        public void Update(CategoryReward entity)
        {
        }

        public void Delete(CategoryReward entity)
        {
        }
    }
}