using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.CategoryRewardService;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface ICategoryRewardService
    {
        List<CategoryRewardListDto> GetAllRelations();
        List<CategoryRewardListDto> GetAllRelationsWithDetails();
        CategoryRewardListDto GetRelationById(Guid id);
        CategoryRewardListDto GetRelationByIdWithDetails(Guid id);
        void AddRelation(CategoryRewardAddDto model);
        void UpdateRelation(CategoryRewardUpdateDto model);
        void DeleteRelation(CategoryRewardDeleteDto model);
    }
}