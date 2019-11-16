using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Host4Travel.Core.DAL.Concrete.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfCategoryRewardRepository:EfEntityRepositoryBase<CategoryReward,ApplicationDbContext>,ICategoryRewardDal
    {
        public List<CategoryReward> GetAllWithDetails(Expression<Func<CategoryReward, bool>> filter = null)
        {
            using ApplicationDbContext dbContext=new ApplicationDbContext();
            var relations = dbContext.CategoryReward.Include(x => x.Category).Include(x => x.Reward).ToList();
            return relations;
        }

        public CategoryReward GetWithDetails(Expression<Func<CategoryReward, bool>> filter = null)
        {
            using ApplicationDbContext dbContext=new ApplicationDbContext();
            var relation = dbContext.CategoryReward.Include(x => x.Category).Include(x => x.Reward).FirstOrDefault(filter);
            return relation;
        }
    }
}