using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators;
using Host4Travel.BLL.Validators.CategoryService;
using Host4Travel.Core.DTO.CategoryDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        private IExceptionHandler _handler;
        

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IExceptionHandler handler)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _handler = handler;
        }


        public List<CategoryDetailDto> GetAllCategories()
        {
            var categories = _categoryDal.GetList();
            if (categories==null)
            {
                return null;
            }
            var categoriesList = _mapper.Map<List<CategoryDetailDto>>(categories);
            return categoriesList;
        }

        public CategoryDetailDto GetCategoryById(int categoryId)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            if (category==null)
            {
                return null;
            }

            var categoryReturn = _mapper.Map<CategoryDetailDto>(category);
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
                    if (_categoryDal.IsExists(x=>x.CategoryName==categoryToAdd.CategoryName))
                    {
                        throw new UniqueConstraintException($"{categoryToAdd.CategoryName} zaten mevcut.");
                    }
                    else
                    {
                        _categoryDal.Add(categoryToAdd);
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                }
            }
            catch (Exception e)
            {
                throw _handler.HandleServiceException(e);
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
                    if (_categoryDal.IsExists(x=>x.CategoryId==categoryToAdd.CategoryId))
                    {
                        _categoryDal.Update(categoryToAdd);
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                }
            }
            catch (Exception e)
            {
                throw _handler.HandleServiceException(e);

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
                    if (_categoryDal.IsExists(x=>x.CategoryId==categoryToAdd.CategoryId))
                    {
                        _categoryDal.Delete(categoryToAdd);
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new ValidationFailureException(validationResult.ToString().Replace("~","\n"));
                }
            }
            catch (Exception e)
            {
                throw _handler.HandleServiceException(e);

            }
        }
    }
}