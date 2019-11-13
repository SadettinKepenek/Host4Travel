using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
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
        public PostCategoryReward GetById(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            return null;
        }

        public List<PostCategoryReward> GetAll(Expression<Func<PostCategoryReward, bool>> filter = null)
        {
            return null;
        }

        public void Add(PostCategoryReward entity)
        {
        }

        public void Update(PostCategoryReward entity)
        {
        }

        public void Delete(PostCategoryReward entity)
        {
        }
    }
}