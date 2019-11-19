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


    }
}