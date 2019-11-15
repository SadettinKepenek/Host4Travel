using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators;
using Host4Travel.Core.DTO.CategoryService;
using Host4Travel.Core.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public List<CategoryListDto> GetAllCategories()
        {
            return null;
        }

        public CategoryListDto GetCategoryById(int categoryId)
        {
            return null;
        }

        public void AddCategory(CategoryAddDto model)
        {
            
        }

        public void UpdateCategory(CategoryUpdateDto model)
        {
        }

        public void DeleteCategory(CategoryDeleteDto model)
        {
        }
    }
}