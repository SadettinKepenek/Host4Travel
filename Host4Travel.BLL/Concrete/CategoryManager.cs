using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            return null;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return null;
        }

        public void Add(Category entity)
        {
        }

        public void Update(Category entity)
        {
        }

        public void Delete(Category entity)
        {
        }
    }
}