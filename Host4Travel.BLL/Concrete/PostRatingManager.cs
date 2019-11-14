using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostRatingManager:IPostRatingService
    {
        private IPostRatingDal _postRatingDal;

        public PostRatingManager(IPostRatingDal postRatingDal)
        {
            _postRatingDal = postRatingDal;
        }

        public PostRating Get(Expression<Func<PostRating, bool>> filter = null)
        {
            return null;
        }

        public List<PostRating> GetAll(Expression<Func<PostRating, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(PostRating entity)
        {
            return null;
        }

        public ResultModel Update(PostRating entity)
        {
            return null;
        }

        public ResultModel Delete(PostRating entity)
        {
            return null;
        }
    }
}