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
    public class EfPostCategoryRewardRepository:EfEntityRepositoryBase<PostCategoryReward,ApplicationDbContext>,IPostCategoryRewardDal
    {
        public List<PostCategoryReward> GetList(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            using ApplicationDbContext context=new ApplicationDbContext();

            var entities = filter == null
                ? context.PostCategoryReward.Include(x => x.Post).ThenInclude(y=>y.Owner).Include(x => x.Category).Include(x => x.Reward)
                    .ToList()
                : context.PostCategoryReward.Where(filter).Include(x => x.Post).Include(x => x.Category).Include(x => x.Reward)
                    .ToList();
            return entities;
        }

        public PostCategoryReward Get(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            using ApplicationDbContext context=new ApplicationDbContext();

            var entity = filter == null
                ? context.PostCategoryReward.Include(x => x.Post).ThenInclude(y => y.Owner).Include(x => x.Category)
                    .Include(x => x.Reward)
                    .FirstOrDefault()
                : context.PostCategoryReward.Include(x => x.Post).Include(x => x.Category).Include(x => x.Reward)
                    .FirstOrDefault(filter);
            return entity;
        }
    }
}