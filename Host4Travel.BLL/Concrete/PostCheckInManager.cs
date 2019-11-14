using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostCheckInManager:IPostCheckInService
    {
        private IPostCheckInDal _postCheckInDal;

        public PostCheckInManager(IPostCheckInDal postCheckInDal)
        {
            _postCheckInDal = postCheckInDal;
        }

        public PostCheckIn Get(Expression<Func<PostCheckIn, bool>> filter = null)
        {
            return null;
        }

        public List<PostCheckIn> GetAll(Expression<Func<PostCheckIn, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(PostCheckIn entity)
        {
            return null;
        }

        public ResultModel Update(PostCheckIn entity)
        {
            return null;
        }

        public ResultModel Delete(PostCheckIn entity)
        {
            return null;
        }
    }
}