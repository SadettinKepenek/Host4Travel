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
    public class EfPostCheckInRepository:EfEntityRepositoryBase<PostCheckIn,ApplicationDbContext>,IPostCheckInDal
    {
        public List<PostCheckIn> GetList(Expression<Func<PostCheckIn, bool>> filter = null)
        {
            using ApplicationDbContext context=new ApplicationDbContext();
            if (filter == null)
            {
                return context.PostCheckIn.Include(x => x.Application).ThenInclude(y => y.Applicent).Include(c => c.Post).ToList();
            }

            return context.PostCheckIn.Include(x=>x.Application).ThenInclude(y=>y.Applicent).Include(c=>c.Post).Where(filter).ToList();
            
        }
    }
}