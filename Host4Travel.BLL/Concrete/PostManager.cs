using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostService;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public PostManager(IPostDal postDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _postDal = postDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
      
        }

        public List<PostListDto> GetAllPosts()
        {
            var posts = _postDal.GetList();
            if (posts==null)
            {
                return null;
            }

            var mappedPosts = _mapper.Map<List<PostListDto>>(posts);
            return mappedPosts;
        }

        public PostDetailDto GetPost(Guid postId)
        {
            var post = _postDal.Get(x=>x.PostId==postId);
            if (post==null)
            {
                return null;
            }

            var mappedPost = _mapper.Map<PostDetailDto>(post);
            return mappedPost;
        }

        public List<PostListDto> GetByUser(string userId)
        {
            
            var posts = _postDal.GetList(x=>x.OwnerId==userId);
            if (posts==null)
            {
                return new List<PostListDto>();
            }

            var mappedPosts = _mapper.Map<List<PostListDto>>(posts);
            return mappedPosts;
        }

        public void AddPost(PostAddDto model)
        {
            try
            {
                PostAddValidator validator=new PostAddValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_postDal.IsExists(x=>x.OwnerId==model.OwnerId && x.PostTitle==model.PostTitle && x.PostType==model.PostType && x.Latitude ==model.Latitude && x.Longitude==model.Longitude))
                    {
                        throw new UniqueConstraintException("Eklenmek istenilen post zaten mevcut");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Post>(model);
                        _postDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
            
        }

    

        public void UpdatePost(PostUpdateDto model)
        {
            try
            {
                PostUpdateValidator validator=new PostUpdateValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postDal.IsExists(x=>x.PostId==model.PostId))
                    {
                        throw new NullReferenceException("Eklenmek istenilen post bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Post>(model);
                        _postDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void DeletePost(PostDeleteDto model)
        {
            try
            {
                PostDeleteValidator validator=new PostDeleteValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_postDal.IsExists(x=>x.PostId==model.PostId))
                    {
                        throw new NullReferenceException("Eklenmek istenilen post bulunamadı");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Post>(model);
                        
                        _postDal.Delete(mappedEntity);
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