using System;
using System.Collections.Generic;
using Host4Travel.Core.DTO.CategoryRewardDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface ICategoryRewardService
    {
        List<CategoryRewardDetailDto> GetAllRelations();
        List<CategoryRewardListDto> GetAllRelationsWithDetails();
        CategoryRewardDetailDto GetRelationById(Guid id);
        CategoryRewardDetailDto GetRelationByIdWithDetails(Guid id);
        void AddRelation(CategoryRewardAddDto model);
        void UpdateRelation(CategoryRewardUpdateDto model);
        void DeleteRelation(CategoryRewardDeleteDto model);
    }
}