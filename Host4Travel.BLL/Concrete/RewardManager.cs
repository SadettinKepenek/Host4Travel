using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.RewardService;
using Host4Travel.Core.DTO.RewardService;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;
using Microsoft.Data.SqlClient;

namespace Host4Travel.BLL.Concrete
{
    public class RewardManager:IRewardService
    {
        private IRewardDal _rewardDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public RewardManager(IRewardDal rewardDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _rewardDal = rewardDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }


        public List<RewardGetDto> GetAllRewards()
        {
            var rewards = _rewardDal.GetList();
            if (rewards==null)
            {
                return null;
            }
            var rewardToReturn = _mapper.Map<List<RewardGetDto>>(rewards);
            return rewardToReturn;
        }

        public RewardGetDto GetRewardById(int rewardId)
        {
            var reward = _rewardDal.Get(x => x.RewardId == rewardId);
            if (reward==null)
            {
                return null;
            }

            var rewardToReturn = _mapper.Map<RewardGetDto>(reward);
            return rewardToReturn;
        }

        public void AddReward(RewardAddDto model)
        {
            AddRewardValidator validator=new AddRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    _rewardDal.Add(addModel);
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

        public void UpdateReward(RewardUpdateDto model)
        {
            UpdateRewardValidator validator=new UpdateRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    _rewardDal.Update(addModel);
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

        public void DeleteReward(RewardDeleteDto model)
        {
            DeleteRewardValidator validator=new DeleteRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    _rewardDal.Delete(addModel);
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