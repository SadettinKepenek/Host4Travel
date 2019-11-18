using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.PostCategoryRewardService;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface IPostCategoryRewardService
    {
        List<PostCategoryRewardListDto> GetAllRelations();
        PostCategoryRewardListDto GetRelationById(Guid id);

        void Add(PostCategoryRewardAddDto dto);
        void Update(PostCategoryRewardAddDto dto);
        void Delete(PostCategoryRewardDeleteDto dto);
    }
}