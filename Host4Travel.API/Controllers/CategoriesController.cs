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

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
                switch (e)
                {
                    case ValidationFailureException exception:
                        return BadRequest("Veriler doğrulanırken hata oluştu\n"+exception.Message);
                    case EfCrudException _:
                        return BadRequest("Sistem yöneticinizle görüşün");
                    default:
                        return BadRequest("Some error occured");
                }
            }
            return Ok();
        }
    }
}