using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators;
using Host4Travel.BLL.Validators.CategoryService;
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
        private IMapper _mapper;
        

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }


        public List<CategoryListDto> GetAllCategories()
        {
            var categories = _categoryDal.GetList();
            if (categories==null)
            {
                return null;
            }
            var categoriesList = _mapper.Map<List<CategoryListDto>>(categories);
            return categoriesList;
        }

        public CategoryListDto GetCategoryById(int categoryId)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            if (category==null)
            {
                return null;
            }

            var categoryReturn = _mapper.Map<CategoryListDto>(category);
            return categoryReturn;
        }

        public void AddCategory(CategoryAddDto model)
        {
            AddCategoryValidator addCategoryValidator=new AddCategoryValidator();
            try
            {
                var validationResult = addCategoryValidator.Validate(model);
                if (validationResult.IsValid)
                {
                    var categoryToAdd = _mapper.Map<Category>(model);
                    _categoryDal.Add(categoryToAdd);
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
                throw;
            }
        }

        public void UpdateCategory(CategoryUpdateDto model)
        {
            UpdateCategoryValidator updateCategoryValidator=new UpdateCategoryValidator();
            try
            {
                var validationResult = updateCategoryValidator.Validate(model);
                if (validationResult.IsValid)
                {
                    var categoryToAdd = _mapper.Map<Category>(model);
                    _categoryDal.Update(categoryToAdd);
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
                throw;
            }
        }

        public void DeleteCategory(CategoryDeleteDto model)
        {
            DeleteCategoryValidator deleteCategoryValidator=new DeleteCategoryValidator();
            try
            {
                var validationResult = deleteCategoryValidator.Validate(model);
                if (validationResult.IsValid)
                {
                    var categoryToAdd = _mapper.Map<Category>(model);
                    _categoryDal.Delete(categoryToAdd);
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
                throw;
            }
        }
    }
}