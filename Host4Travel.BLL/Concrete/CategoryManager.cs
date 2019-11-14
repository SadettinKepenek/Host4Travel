using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators;
using Host4Travel.Core.BLL.Concrete;
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

        public void Add(Category entity)
        {
            // Start Logging
            try
            {
                CategoryValidator categoryValidator=new CategoryValidator();
                var validationResult = categoryValidator.Validate(entity);
                if (validationResult.IsValid)
                {
                    _categoryDal.Add(entity);
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                    
                }
                
            }
            catch (Exception e)
            {
                if (e is SqlException || e is DbUpdateException || e is DbException)
                {
                    throw new EfCrudException(e.Message);
                }
                else if (e is ValidationFailureException)
                {
                    throw;
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
           

        }

        public void Update(Category entity)
        {
            try
            {
                CategoryValidator categoryValidator=new CategoryValidator();
                var validationResult = categoryValidator.Validate(entity);
                if (validationResult.IsValid)
                {
                    _categoryDal.Update(entity);
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                }
                
            }
            catch (Exception e)
            {
                if (e is SqlException || e is DbUpdateException || e is DbException)
                {
                    throw new EfCrudException(e.Message);
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void Delete(Category entity)
        {
            try
            {
                CategoryValidator categoryValidator=new CategoryValidator();
                var validationResult = categoryValidator.Validate(entity);
                if (validationResult.IsValid)
                {
                    _categoryDal.Delete(entity);
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                }
                
            }
            catch (Exception e)
            {
                if (e is SqlException || e is DbUpdateException || e is DbException)
                {
                    throw new EfCrudException(e.Message);
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}