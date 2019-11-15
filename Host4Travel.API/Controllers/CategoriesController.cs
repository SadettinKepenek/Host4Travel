using System;
using System.Net;
using System.Threading.Tasks;
using Host4Travel.API.Models.Concrete.Categories;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.Exceptions;
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
            var model = new GetAllModel
            {
                Categories = categories,
                
            };
            if (categories==null)
            {
                model.ResponseMessage = "Herhangi bir kategori bulunamadı";
                model.HttpStatusCode = HttpStatusCode.NotFound;
                return NotFound("Herhangi bir kategori bulunamadı");
            }
            model.ResponseMessage = $"{categories.Count} adet kategori listelendi.";
            model.HttpStatusCode = HttpStatusCode.OK;
            return Ok(model);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryAddDto category)
        {
            try
            {
                _categoryService.AddCategory(category);
                return Ok("Kategori başarı ile eklendi");
            }
            catch (Exception e)
            {
                return _exceptionHandler.HandleServiceException(e);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                _categoryService.UpdateCategory(categoryUpdateDto);
                return Ok("Kategori başarı ile güncellendi");
            }
            catch (Exception e)
            {
                return _exceptionHandler.HandleServiceException(e);
            }
        }
    }
}