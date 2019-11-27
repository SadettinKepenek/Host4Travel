using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostDiscussionService;
using Host4Travel.Core.DTO.PostDiscussionDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostDiscussionManager:IPostDiscussionService
    {
        private IPostDiscussionDal _postDiscussionDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;


        public PostDiscussionManager(IPostDiscussionDal postDiscussionDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _postDiscussionDal = postDiscussionDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }
        
        public List<PostDiscussionListDto> GetAll()
        {
            var entities = _postDiscussionDal.GetList();
            if (entities == null)
            {
                return null;
            }

            var mappedPostDiscussions = _mapper.Map<List<PostDiscussionListDto>>(entities);
            return mappedPostDiscussions;
        }

        public PostDiscussionDetailDto GetById(Guid id)
        {
            var entity = _postDiscussionDal.Get(x => x.PostDiscussionId == id);
            if (entity == null)
            {
                return null;
            }

            var mappedPostDiscussion = _mapper.Map<PostDiscussionDetailDto>(entity);
            return mappedPostDiscussion;

        }

        public void Add(PostDiscussionAddDto dto)
        {
            try
            {
                AddPostDiscussionValidator validator = new AddPostDiscussionValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_postDiscussionDal.IsExists(x => x.PostId == dto.PostId && x.CommentId == dto.CommentId))
                    {
                        throw new UniqueConstraintException($"PostId {dto.PostId} ve CommentId {dto.CommentId} için zaten eklenmiş");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostDiscussion>(dto);
                        _postDiscussionDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(PostDiscussionUpdateDto dto)
        {
            
            try
            {
                UpdatePostDiscussionValidator validator = new UpdatePostDiscussionValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postDiscussionDal.IsExists(x => x.PostDiscussionId == dto.PostDiscussionId))
                    {
                        throw  new NullReferenceException($"{dto.PostDiscussionId} bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostDiscussion>(dto);
                        _postDiscussionDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(PostDiscussionDeleteDto dto)
        {
            try
            {
                DeletePostDiscussionValidator validator = new DeletePostDiscussionValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postDiscussionDal.IsExists(x => x.PostDiscussionId == dto.PostDiscussionId))
                    {
                        throw  new NullReferenceException($"{dto.PostDiscussionId} bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostDiscussion>(dto);
                        _postDiscussionDal.Delete(mappedEntity);
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