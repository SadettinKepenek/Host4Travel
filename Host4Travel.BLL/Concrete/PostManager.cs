using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public Post Get(Expression<Func<Post, bool>> filter = null)
        {
            return null;
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return null;
        }

        public void Add(Post entity)
        {
        }

        public void Update(Post entity)
        {
        }

        public void Delete(Post entity)
        {
        }
    }
}