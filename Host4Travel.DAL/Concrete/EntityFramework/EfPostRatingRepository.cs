using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Host4Travel.Core.DAL.Concrete.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfPostRatingRepository:EfEntityRepositoryBase<PostRating,ApplicationDbContext>,IPostRatingDal
    {
        public List<PostRating> GetList(Expression<Func<PostRating, bool>> filter = null)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            if (filter == null)
            {
                return context.PostRating
                    .Include(x => x.Application)
                    .Include(x => x.Owner)
                    .Include(x => x.Post)
                    .ToList();
            }
            return context.PostRating
                .Include(x => x.Application)
                .Include(x => x.Owner)
                .Include(x => x.Post)
                .Where(filter)
                .ToList();
        }
    }
}