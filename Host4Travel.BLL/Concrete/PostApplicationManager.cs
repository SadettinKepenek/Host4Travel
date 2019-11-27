using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostApplicationService;
using Host4Travel.Core.DTO.PostApplicationDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostApplicationManager:IPostApplicationService
    {
        private IPostApplicationDal _postApplicationDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public PostApplicationManager(IPostApplicationDal postApplicationDal, IExceptionHandler exceptionHandler, IMapper mapper)
        {
            _postApplicationDal = postApplicationDal;
            _exceptionHandler = exceptionHandler;
            _mapper = mapper;
        }


        public List<PostApplicationListDto> GetAllApplications()
        {
            var applications = _postApplicationDal.GetList();
            if (applications==null)
            {
                return null;
            }

            var mappedApplications = _mapper.Map<List<PostApplicationListDto>>(applications);
            return mappedApplications;
        }

        public PostApplicationDetailDto GetApplicationById(Guid id)
        {
            var application = _postApplicationDal.Get(x => x.PostApplicationId == id);
            if (application==null)
            {
                return null;
            }

            var mappedApplication = _mapper.Map<PostApplicationDetailDto>(application);
            return mappedApplication;
        }

        public void AddApplication(PostApplicationAddDto dto)
        {
            try
            {
                AddPostApplicationValidator validator=new AddPostApplicationValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_postApplicationDal.IsExists(x=>x.ApplicentId==dto.ApplicentId && x.PostId==dto.PostId))
                    {
                        throw new UniqueConstraintException($"{dto.ApplicentId} Owner için {dto.PostId} postuna zaten başvuru bulunmakta");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostApplication>(dto);
                        _postApplicationDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void UpdateApplication(PostApplicationUpdateDto dto)
        {
            try
            {
                UpdatePostApplicationValidator validator=new UpdatePostApplicationValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postApplicationDal.IsExists(x=>x.PostApplicationId==dto.PostApplicationId))
                    {
                        throw new NullReferenceException($"{dto.PostApplicationId} bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostApplication>(dto);
                        _postApplicationDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void DeleteApplication(PostApplicationDeleteDto dto)
        {
            try
            {
                DeletePostApplicationValidator validator=new DeletePostApplicationValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postApplicationDal.IsExists(x=>x.PostApplicationId==dto.PostApplicationId))
                    {
                        throw new NullReferenceException($"{dto.PostApplicationId} bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostApplication>(dto);
                        _postApplicationDal.Delete(mappedEntity);
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