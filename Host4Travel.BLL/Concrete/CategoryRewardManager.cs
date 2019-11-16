using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.CategoryRewardService;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryRewardManager : ICategoryRewardService
    {
        private ICategoryRewardDal _categoryRewardDal;
        private IMapper _mapper;

        public CategoryRewardManager(ICategoryRewardDal categoryRewardDal, IMapper mapper)
        {
            _categoryRewardDal = categoryRewardDal;
            _mapper = mapper;
        }


        public List<CategoryRewardListDto> GetAllRelations()
        {
            var entities = _categoryRewardDal.GetList();
            if (entities == null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<CategoryRewardListDto>>(entities);
            return mappedEntities;
        }

        public List<CategoryRewardListDto> GetAllRelationsWithDetails()
        {
            var entities = _categoryRewardDal.GetAllWithDetails();
            if (entities == null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<CategoryRewardListDto>>(entities);
            return mappedEntities;
        }

        public CategoryRewardListDto GetRelationById(Guid id)
        {
            
            var entity = _categoryRewardDal.Get(x=>x.CategoryRewardId==id);
            if (entity == null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<CategoryRewardListDto>(entity);
            return mappedEntity;
        }

        public CategoryRewardListDto GetRelationByIdWithDetails(Guid id)
        {
            var entity = _categoryRewardDal.GetWithDetails(x=>x.CategoryRewardId==id);
            if (entity == null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<CategoryRewardListDto>(entity);
            return mappedEntity;
        }

        public void AddRelation(CategoryRewardAddDto model)
        {
        }

        public void UpdateRelation(CategoryRewardAddDto model)
        {
        }

        public void DeleteRelation(CategoryRewardAddDto model)
        {
        }
    }
}