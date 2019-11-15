using System.Collections.Generic;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.UI;

namespace Host4Travel.BLL.Abstract
{
    public interface ICategoryService
    {
        List<CategoryListDto> GetAllCategories();
        CategoryListDto GetCategoryById(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        
    }
}