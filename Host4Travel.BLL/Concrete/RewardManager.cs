﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.RewardService;
using Host4Travel.Core.DTO.RewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;
using Microsoft.Data.SqlClient;

namespace Host4Travel.BLL.Concrete
{
    public class RewardManager : IRewardService
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


        public List<RewardListDto> GetAllRewards()
        {
            var rewards = _rewardDal.GetList();
            if (rewards == null)
            {
                return null;
            }

            var rewardToReturn = _mapper.Map<List<RewardListDto>>(rewards);
            return rewardToReturn;
        }

        public RewardDetailDto GetRewardById(int rewardId)
        {
            var reward = _rewardDal.Get(x => x.RewardId == rewardId);
            if (reward == null)
            {
                return null;
            }

            var rewardToReturn = _mapper.Map<RewardDetailDto>(reward);
            return rewardToReturn;
        }

        public void AddReward(RewardAddDto model)
        {
            AddRewardValidator validator = new AddRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    if (_rewardDal.IsExists(x => x.RewardName == addModel.RewardName))
                    {
                        throw new UniqueConstraintException($"{addModel.RewardName} zaten mevcut");
                    }
                    else
                    {
                        _rewardDal.Add(addModel);
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

        public void UpdateReward(RewardUpdateDto model)
        {
            UpdateRewardValidator validator = new UpdateRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    if (_rewardDal.IsExists(x => x.RewardId == addModel.RewardId))
                    {
                        _rewardDal.Update(addModel);
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

        public void DeleteReward(RewardDeleteDto model)
        {
            DeleteRewardValidator validator = new DeleteRewardValidator();
            try
            {
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var addModel = _mapper.Map<Reward>(model);
                    if (_rewardDal.IsExists(x => x.RewardId == addModel.RewardId))
                    {
                        _rewardDal.Delete(addModel);
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