using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostCategoryRewardService;
using Host4Travel.Core.DTO.PostCategoryRewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostCategoryRewardManager:IPostCategoryRewardService
    {
        private IPostCategoryRewardDal _postCategoryRewardDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public PostCategoryRewardManager(IPostCategoryRewardDal postCategoryRewardDal, IExceptionHandler exceptionHandler, IMapper mapper)
        {
            _postCategoryRewardDal = postCategoryRewardDal;
            _exceptionHandler = exceptionHandler;
            _mapper = mapper;
        }


        public List<PostCategoryRewardListDto> GetAllRelations()
        {
            var entities = _postCategoryRewardDal.GetList();
            if (entities==null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<PostCategoryRewardListDto>>(entities);
            return mappedEntities;
        }

        public PostCategoryRewardListDto GetRelationById(Guid id)
        {
            var entity = _postCategoryRewardDal.Get(x => x.PostCategoryRewardId == id);
            if (entity==null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<PostCategoryRewardListDto>(entity);
            return mappedEntity;
        }

        public void Add(PostCategoryRewardAddDto dto)
        {
            try
            {
                AddPostCategoryRewardValidator validator=new AddPostCategoryRewardValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_postCategoryRewardDal.IsExists(x=>x.CategoryId==dto.CategoryId && x.RewardId==dto.RewardId && x.PostId==dto.PostId))
                    {
                        throw new UniqueConstraintException($"Category Id {dto.CategoryId} ve Reward Id {dto.RewardId} zaten {dto.PostId} için eklenmiş durumda");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostCategoryReward>(dto);
                        _postCategoryRewardDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(PostCategoryRewardAddDto dto)
        {
            if (dto.IsNew)
            {
                throw new ArgumentException("IsNew Update İçin false olarak gönderilmelidir");
            }
            try
            {
                AddPostCategoryRewardValidator validator=new AddPostCategoryRewardValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postCategoryRewardDal.IsExists(x=>x.PostCategoryRewardId==dto.PostCategoryRewardId))
                    {
                        throw new NullReferenceException($"PostCategoryRewardId {dto.PostCategoryRewardId} için bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostCategoryReward>(dto);
                        _postCategoryRewardDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(PostCategoryRewardDeleteDto dto)
        {
           
            try
            {
                DeletePostCategoryRewardValidator validator=new DeletePostCategoryRewardValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postCategoryRewardDal.IsExists(x=>x.PostCategoryRewardId==dto.PostCategoryRewardId))
                    {
                        throw new NullReferenceException($"PostCategoryRewardId {dto.PostCategoryRewardId} için bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostCategoryReward>(dto);
                        _postCategoryRewardDal.Delete(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }
    }
}