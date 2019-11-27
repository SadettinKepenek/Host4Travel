using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostImageService;
using Host4Travel.Core.DTO.PostImageDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostImageManager:IPostImageService
    {
        private IPostImageDal _postImageDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;
        public PostImageManager(IPostImageDal postImageDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _postImageDal = postImageDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }


        public List<PostImageListDto> GetAllImages()
        {
            var images = _postImageDal.GetList();
            if (images==null)
            {
                return null;
            }

            var mappedImages = _mapper.Map<List<PostImageListDto>>(images);
            return mappedImages;
        }

        public PostImageDetailDto GetImageById(Guid id)
        {
            var image = _postImageDal.Get(x=>x.ImageId==id);
            if (image==null)
            {
                return null;
            }

            var mappedImage = _mapper.Map<PostImageDetailDto>(image);
            return mappedImage;
        }

        public void AddImage(PostImageAddDto dto)
        {
            try
            {
                AddPostImageValidator validator=new AddPostImageValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    var mappedImage = _mapper.Map<PostImage>(dto);
                    _postImageDal.Add(mappedImage);
                }
                
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void UpdateImage(PostImageAddDto dto)
        {
            try
            {
                if (dto.IsPhotoNew)
                {
                    throw new ArgumentException("IsPhotoNew False Olarak Gönderilmelidir");
                }
                AddPostImageValidator validator=new AddPostImageValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    var mappedImage = _mapper.Map<PostImage>(dto);
                    _postImageDal.Update(mappedImage);
                }
                
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void DeleteImage(PostImageDeleteDto dto)
        {
            try
            {
              
                DeletePostImageValidator validator=new DeletePostImageValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    var mappedImage = _mapper.Map<PostImage>(dto);
                    _postImageDal.Delete(mappedImage);
                }
                
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }
    }
}