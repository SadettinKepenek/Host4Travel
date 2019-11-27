using System.Collections.Generic;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface ICategoryService
    {
        List<CategoryListDto> GetAllCategories();
        CategoryDetailDto GetCategoryById(int categoryId);
        void AddCategory(CategoryAddDto model);
        void UpdateCategory(CategoryUpdateDto model);
        void DeleteCategory(CategoryDeleteDto model);
        
    }
}