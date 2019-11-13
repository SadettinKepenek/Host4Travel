using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostManager:IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }
        public Post Get(Expression<Func<Post, bool>> filter = null)
        {
            return filter==null ? _postDal.Get() : _postDal.Get(filter);
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return _postDal.GetList();
        }

        public void Add(Post entity)
        {
            _postDal.Add(entity);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }
    }
}