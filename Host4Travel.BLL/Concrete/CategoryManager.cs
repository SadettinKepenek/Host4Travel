using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
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
            var categories = filter == null ? _categoryDal.Get() : _categoryDal.Get(filter);
            return categories;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var categories = filter == null ? _categoryDal.GetList() : _categoryDal.GetList(filter);
            return categories;
        }

        public ResultModel Add(Category entity)
        {
            return null;
        }

        public ResultModel Update(Category entity)
        {
            return null;
        }

        public ResultModel Delete(Category entity)
        {
            return null;
        }
    }
}