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
    public class EfPostApplicationRepository:EfEntityRepositoryBase<PostApplication,ApplicationDbContext>,IPostApplicationDal
    {
        public List<PostApplication> GetList(Expression<Func<PostApplication, bool>> filter = null)
        {
            using ApplicationDbContext context=new ApplicationDbContext();
            var applications = filter == null
                ? context.PostApplication.Include(x => x.PostCheckIn).Include(x=>x.Post).Include(x => x.Applicent).ToList()
                : context.PostApplication.Include(x => x.PostCheckIn).Include(x=>x.Post).Include(x => x.Applicent).Where(filter).ToList();
            return applications;
        }

        public PostApplication Get(Expression<Func<PostApplication, bool>> filter = null)
        {
            using ApplicationDbContext context=new ApplicationDbContext();
            var application = filter == null
                ? context.PostApplication.Include(x => x.PostCheckIn).Include(x=>x.Post).Include(x => x.Applicent).FirstOrDefault()
                : context.PostApplication.Include(x => x.PostCheckIn).Include(x=>x.Post).Include(x => x.Applicent).FirstOrDefault(filter);
            return application;
        }
    }
}