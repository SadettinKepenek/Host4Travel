using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostCategoryRewardService;
using Host4Travel.Core.ExceptionService.Abstract;
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
            return null;
        }

        public PostCategoryRewardListDto GetRelationById(Guid id)
        {
            return null;
        }

        public void Add(PostCategoryRewardAddDto dto)
        {
        }

        public void Update(PostCategoryRewardAddDto dto)
        {
        }

        public void Delete(PostCategoryRewardDeleteDto dto)
        {
        }
    }
}