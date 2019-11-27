using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostCheckInService;
using Host4Travel.Core.DTO.PostCheckInDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostCheckInManager:IPostCheckInService
    {
        private IPostCheckInDal _postCheckInDal;
        private IExceptionHandler _exceptionHandler;
        private IMapper _mapper;
        public PostCheckInManager(IPostCheckInDal postCheckInDal, IExceptionHandler exceptionHandler, IMapper mapper)
        {
            _postCheckInDal = postCheckInDal;
            _exceptionHandler = exceptionHandler;
            _mapper = mapper;
        }

        public List<PostCheckInListDto> GetAll()
        {
            var entities = _postCheckInDal.GetList();
            if (entities==null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<PostCheckInListDto>>(entities);
            return mappedEntities;
        }

        public PostCheckInListDto GetById(Guid id)
        {
            var entity = _postCheckInDal.Get(x=>x.PostCheckInId==id);
            if (entity==null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<PostCheckInListDto>(entity);
            return mappedEntities;
        }

        public void Add(PostCheckInAddDto model)
        {
            try
            {
                AddPostCheckInValidator validator=new AddPostCheckInValidator();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new ValidationFailureException(result.ToString());
                }
                else
                {
                    if (_postCheckInDal.IsExists(x=>x.PostId==model.PostId ))
                    {
                        throw new UniqueConstraintException($"{model.PostId} Numaralı post için zaten CheckIn yapılmış.");
                    }
                    else
                    {
                        var mappedModel = _mapper.Map<PostCheckIn>(model);
                        _postCheckInDal.Add(mappedModel);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(PostCheckInUpdateDto model)
        {
            try
            {
                UpdatePostCheckInValidator validator=new UpdatePostCheckInValidator();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new ValidationFailureException(result.ToString());
                }
                else
                {
                    if (!_postCheckInDal.IsExists(x=>x.PostCheckInId==model.PostCheckInId ))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedModel = _mapper.Map<PostCheckIn>(model);
                        _postCheckInDal.Update(mappedModel);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(PostCheckInDeleteDto model)
        {
            try
            {
                DeletePostCheckInValidator validator=new DeletePostCheckInValidator();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new ValidationFailureException(result.ToString());
                }
                else
                {
                    if (!_postCheckInDal.IsExists(x=>x.PostCheckInId==model.PostCheckInId ))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedModel = _mapper.Map<PostCheckIn>(model);
                        _postCheckInDal.Delete(mappedModel);
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