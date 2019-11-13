using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostDiscussionManager:IPostDiscussionService
    {
        private IPostDiscussionDal _postDiscussionDal;

        public PostDiscussionManager(IPostDiscussionDal postDiscussionDal)
        {
            _postDiscussionDal = postDiscussionDal;
        }
        public PostDiscussion Get(Expression<Func<PostDiscussion, bool>> filter = null)
        {
            return null;
        }

        public List<PostDiscussion> GetAll(Expression<Func<PostDiscussion, bool>> filter = null)
        {
            return null;
        }

        public void Add(PostDiscussion entity)
        {
        }

        public void Update(PostDiscussion entity)
        {
        }

        public void Delete(PostDiscussion entity)
        {
        }
    }
}