using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.DAL.Abstract
{
    public interface ICategoryRewardDal:IEntityRepository<CategoryReward>
    {
        List<CategoryReward> GetAllWithDetails(Expression<Func<CategoryReward, bool>> filter = null);
        CategoryReward GetWithDetails(Expression<Func<CategoryReward, bool>> filter = null);
        
    }
}