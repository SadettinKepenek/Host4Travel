using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
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
        public PostCheckIn GetById(Expression<Func<PostCheckIn, bool>> filter = null)
        {
            return null;
        }

        public List<PostCheckIn> GetAll(Expression<Func<PostCheckIn, bool>> filter = null)
        {
            return null;
        }

        public void Add(PostCheckIn entity)
        {
        }

        public void Update(PostCheckIn entity)
        {
        }

        public void Delete(PostCheckIn entity)
        {
        }
    }
}