using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.PostRatingService;
using Host4Travel.Core.DTO.PostRatingDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostRatingManager:IPostRatingService
    {
        private IPostRatingDal _postRatingDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;
        

        public PostRatingManager(IPostRatingDal postRatingDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _postRatingDal = postRatingDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }


        public List<PostRatingListDto> GetAllRatings()
        {
            var ratings = _postRatingDal.GetList();
            if (ratings==null)
            {
                return null;
            }

            var mappedRatings = _mapper.Map<List<PostRatingListDto>>(ratings);
            return mappedRatings;
        }

        public PostRatingDetailDto GetById(Guid ratingId)
        {
            var rating = _postRatingDal.Get(x => x.PostRatingId == ratingId);
            if (rating==null)
            {
                return null;
            }

            var mappedRating = _mapper.Map<PostRatingDetailDto>(rating);
            return mappedRating;
        }

        public void AddRating(PostRatingAddDto dto)
        {
            try
            {
                AddPostRatingValidator validator=new AddPostRatingValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());

                }
                else
                {
                    if (_postRatingDal.IsExists(x=>x.ApplicationId==dto.ApplicationId && x.PostId==dto.PostId && x.OwnerId==dto.OwnerId))
                    {
                        throw new UniqueConstraintException($"{dto.ApplicationId} Numaralı Başvuru için {dto.OwnerId} Kullanıcısının Zaten Değerlendirmesi Mevcut");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostRating>(dto);
                        _postRatingDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void UpdateRating(PostRatingUpdateDto dto)
        {
            try
            {
                UpdatePostRatingValidator validator=new UpdatePostRatingValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());

                }
                else
                {
                    if (!_postRatingDal.IsExists(x=>x.PostRatingId==dto.PostRatingId))
                    {
                        throw new NullReferenceException($"{dto.ApplicationId} Numaralı Başvuru için {dto.OwnerId} Kullanıcısının Zaten Değerlendirmesi Mevcut");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostRating>(dto);
                        _postRatingDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void DeleteRating(PostRatingDeleteDto dto)
        {
            try
            {
                DeletePostRatingValidator validator=new DeletePostRatingValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());

                }
                else
                {
                    if (!_postRatingDal.IsExists(x=>x.PostRatingId==dto.PostRatingId))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<PostRating>(dto);
                        _postRatingDal.Delete(mappedEntity);
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