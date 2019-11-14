using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
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

        public ResultModel Add(PostDiscussion entity)
        {
            return null;
        }

        public ResultModel Update(PostDiscussion entity)
        {
            return null;
        }

        public ResultModel Delete(PostDiscussion entity)
        {
            return null;
        }
    }
}