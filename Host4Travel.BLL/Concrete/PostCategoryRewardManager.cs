using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostCategoryRewardManager:IPostCategoryRewardService
    {
        private IPostCategoryRewardDal _postCategoryRewardDal;

        public PostCategoryRewardManager(IPostCategoryRewardDal postCategoryRewardDal)
        {
            _postCategoryRewardDal = postCategoryRewardDal;
        }

        public PostCategoryReward Get(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            return null;
        }

        public List<PostCategoryReward> GetAll(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(PostCategoryReward entity)
        {
            return null;
        }

        public ResultModel Update(PostCategoryReward entity)
        {
            return null;
        }

        public ResultModel Delete(PostCategoryReward entity)
        {
            return null;
        }
    }
}