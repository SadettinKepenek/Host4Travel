using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.CategoryRewardDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesRewardsController : Controller
    {
        private ICategoryRewardService _categoryRewardService;
        private IExceptionHandler _exceptionHandler;

        public CategoriesRewardsController(IExceptionHandler exceptionHandler, ICategoryRewardService categoryRewardService)
        {
            _exceptionHandler = exceptionHandler;
            _categoryRewardService = categoryRewardService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _categoryRewardService.GetAllRelationsWithDetails();
            if (entities==null)
            {
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<List<CategoryRewardListDto>> responseModelWithData = new ResponseModelWithData<List<CategoryRewardListDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = entities;
            return Ok(responseModelWithData);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = _categoryRewardService.GetRelationByIdWithDetails(id);
            if (entity==null)
            {
                
                return NotFound(new ResponseModel
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Kayıt bulunamadı"
                });
            }
            ResponseModelWithData<CategoryRewardListDto> responseModelWithData = new ResponseModelWithData<CategoryRewardListDto>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıt başarıyla getirildi";
            responseModelWithData.Data = entity;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CategoryRewardAddDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryRewardService.AddRelation(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Category Reward Relationı başarı ile eklendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryRewardUpdateDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryRewardService.UpdateRelation(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Category Reward Relationı başarı ile güncellendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryRewardDeleteDto model)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryRewardService.DeleteRelation(model);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Category Reward Relationı başarı ile silindi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = _exceptionHandler.HandleControllerException(e)
                });
            }
        }
        
    }
}