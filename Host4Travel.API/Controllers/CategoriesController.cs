using System;
using System.Net;
using System.Threading.Tasks;
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
           
            if (categories==null)
            {
                return NotFound("Herhangi bir kategori bulunamadı");
            }
      
            return Ok(categories);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CategoryAddDto category)
        {
            try
            {
                _categoryService.AddCategory(category);
                return Ok("Kategori başarı ile eklendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                _categoryService.UpdateCategory(categoryUpdateDto);
                return Ok("Kategori başarı ile güncellendi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody]CategoryDeleteDto deleteDto)
        {
            try
            {
                _categoryService.DeleteCategory(deleteDto);
                return Ok("Kategori başarı ile silindi");
            }
            catch (Exception e)
            {
                return BadRequest(_exceptionHandler.HandleControllerException(e));
            }
        }
    }
}