using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.Abstract;
using Host4Travel.API.Models.ResponseModels;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host4Travel.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        private IExceptionHandler _exceptionHandler;

        public CategoriesController(ICategoryService categoryService, IExceptionHandler exceptionHandler)
        {
            _categoryService = categoryService;
            _exceptionHandler = exceptionHandler;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var categories = _categoryService.GetAllCategories();
            
            if (categories==null)
            {
                ResponseModelBase responseModel = new ResponseModel();
                responseModel.StatusCode = HttpStatusCode.NotFound;
                responseModel.Message = "Herhangi bir kategori bulunamadı";
                return NotFound(responseModel);
            }

            ResponseModelWithData<List<CategoryDetailDto>> responseModelWithData = new ResponseModelWithData<List<CategoryDetailDto>>();
            responseModelWithData.StatusCode = HttpStatusCode.OK;
            responseModelWithData.Message = "Kayıtlar başarıyla getirildi";
            responseModelWithData.Data = categories;
            return Ok(responseModelWithData);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CategoryAddDto category)
        {
            
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryService.AddCategory(category);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Kategori başarı ile eklendi";
                return Ok(responseModel);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel
                {
                    Message = _exceptionHandler.HandleControllerException(e),
                    StatusCode = HttpStatusCode.BadRequest
                        
                });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryService.UpdateCategory(categoryUpdateDto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Kategori başarı ile güncellendi";
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
        public async Task<IActionResult> Delete([FromBody]CategoryDeleteDto deleteDto)
        {
            try
            {
                ResponseModel responseModel = new ResponseModel();
                _categoryService.DeleteCategory(deleteDto);
                responseModel.StatusCode = HttpStatusCode.OK;
                responseModel.Message = "Kategori başarı ile silindi";
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