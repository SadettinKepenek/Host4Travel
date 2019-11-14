using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.Core.BLL.Concrete.EntityService;
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

        public ResultModel Add(PostApplication entity)
        {
            return null;
        }

        public ResultModel Update(PostApplication entity)
        {
            return null;
        }

        public ResultModel Delete(PostApplication entity)
        {
            return null;
        }
    }
}