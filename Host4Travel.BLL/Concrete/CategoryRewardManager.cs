using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.CategoryRewardService;
using Host4Travel.Core.DTO.CategoryRewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryRewardManager : ICategoryRewardService
    {
        private ICategoryRewardDal _categoryRewardDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public CategoryRewardManager(ICategoryRewardDal categoryRewardDal, IMapper mapper,
            IExceptionHandler exceptionHandler)
        {
            _categoryRewardDal = categoryRewardDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }


        public List<CategoryRewardDetailDto> GetAllRelations()
        {
            var entities = _categoryRewardDal.GetList();
            if (entities == null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<CategoryRewardDetailDto>>(entities);
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

        public CategoryRewardDetailDto GetRelationById(Guid id)
        {
            var entity = _categoryRewardDal.Get(x => x.CategoryRewardId == id);
            if (entity == null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<CategoryRewardDetailDto>(entity);
            return mappedEntity;
        }

        public CategoryRewardDetailDto GetRelationByIdWithDetails(Guid id)
        {
            var entity = _categoryRewardDal.GetWithDetails(x => x.CategoryRewardId == id);
            if (entity == null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<CategoryRewardDetailDto>(entity);
            return mappedEntity;
        }

        public void AddRelation(CategoryRewardAddDto model)
        {
            CategoryRewardAddValidator validator = new CategoryRewardAddValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var mappedModel = _mapper.Map<CategoryReward>(model);
                    if (_categoryRewardDal.IsExists(x =>
                        x.CategoryId == mappedModel.CategoryId && x.RewardId == mappedModel.RewardId))
                    {
                        throw new UniqueConstraintException(
                            $"Reward Identifier : {mappedModel.RewardId} ve Category Identifier : {mappedModel.CategoryId} için zaten kayıt bulunmaktadır.");
                    }
                    else
                    {
                        _categoryRewardDal.Add(mappedModel);
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void UpdateRelation(CategoryRewardUpdateDto model)
        {
            CategoryRewardUpdateValidator validator = new CategoryRewardUpdateValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var mappedModel = _mapper.Map<CategoryReward>(model);
                    if (_categoryRewardDal.IsExists(x =>x.CategoryRewardId==mappedModel.CategoryRewardId))
                    {
                        _categoryRewardDal.Update(mappedModel);
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void DeleteRelation(CategoryRewardDeleteDto model)
        {
            CategoryRewardDeleteValidator validator = new CategoryRewardDeleteValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var mappedModel = _mapper.Map<CategoryReward>(model);
                    if (_categoryRewardDal.IsExists(x =>x.CategoryRewardId==mappedModel.CategoryRewardId))
                    {
                        _categoryRewardDal.Delete(mappedModel);
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }
    }
}