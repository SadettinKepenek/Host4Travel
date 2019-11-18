using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using Host4Travel.Core.DAL.Concrete.EntityFramework;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.DAL.Concrete.EntityFramework
{
    public class EfPostRepository:EfEntityRepositoryBase<Post,ApplicationDbContext>,IPostDal
    {
        public Post Get(Expression<Func<Post, bool>> filter = null)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            if (filter==null)
            {
                return context.Post.Include(x=>x.PostApplication).Include(x=>x.PostCheckIn).Include(x => x.PostImage).Include(x => x.PostRating).Include(x=>x.PostDiscussion).Include(x=>x.PostCategoryReward).Include(x => x.Owner).FirstOrDefault();
            }
            return context.Post.Include(x=>x.PostApplication).Include(x=>x.PostCheckIn).Include(x => x.PostImage).Include(x => x.PostRating).Include(x=>x.PostDiscussion).Include(x=>x.PostCategoryReward).Include(x => x.Owner).FirstOrDefault(filter);;
        }

        public List<Post> GetList(Expression<Func<Post, bool>> filter = null)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            if (filter==null)
            {
                return context.Post.Include(x=>x.PostApplication).Include(x=>x.PostCheckIn).Include(x => x.PostImage).Include(x => x.PostRating).Include(x => x.Owner).ToList();
            }
            return context.Post.Include(x=>x.PostApplication).Include(x=>x.PostCheckIn).Include(x => x.PostImage).Include(x => x.PostRating).Include(x => x.Owner).Where(filter).ToList();;
        }
    }
}