using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostApplicationManager:IPostApplicationService
    {
        private IPostApplicationDal _postApplicationDal;

        public PostApplicationManager(IPostApplicationDal postApplicationDal)
        {
            _postApplicationDal = postApplicationDal;
        }


        public PostApplication Get(Expression<Func<PostApplication, bool>> filter = null)
        {
            return null;
        }

        public List<PostApplication> GetAll(Expression<Func<PostApplication, bool>> filter = null)
        {
            return null;
        }

        public void Add(PostApplication entity)
        {
        }

        public void Update(PostApplication entity)
        {
        }

        public void Delete(PostApplication entity)
        {
        }
    }
}