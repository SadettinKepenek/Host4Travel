﻿using Host4Travel.Core.DataAccessLayer.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfRewardRepository:EfEntityRepositoryBase<Reward,ApplicationDbContext>,IRewardDal
    {
        
    }
}