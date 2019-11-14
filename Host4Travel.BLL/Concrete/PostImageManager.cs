using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostImageManager:IPostImageService
    {
        private IPostImageDal _postImageDal;

        public PostImageManager(IPostImageDal postImageDal)
        {
            _postImageDal = postImageDal;
        }

        public PostImage Get(Expression<Func<PostImage, bool>> filter = null)
        {
            return null;
        }

        public List<PostImage> GetAll(Expression<Func<PostImage, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(PostImage entity)
        {
            return null;
        }

        public ResultModel Update(PostImage entity)
        {
            return null;
        }

        public ResultModel Delete(PostImage entity)
        {
            return null;
        }
    }
}