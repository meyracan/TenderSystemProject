using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _categoryDal.GetList();
                return new SuccessResult(data, "Categories listed.");
            }
            catch { }

            return new ErrorResult("Error: Categories could not listed."); 
        }

        public Result GetById(int categoryId)
        {
            try
            {
                var data =_categoryDal.Get(c => c.Id == categoryId);
                if (data == null)
                {
                    return new ErrorResult("Category Id could not found.");
                }

                return new SuccessResult(data, "Category listed.");
            }
            catch { }

            return new ErrorResult("Error: Category could not listed.");
        }

        public Result Add(Category category)
        {
            try
            {
                var categoryTitle = _categoryDal.Get(c => c.CategoryName == category.CategoryName);
                if (categoryTitle != null)
                {
                    return new ErrorResult("Category title already in use!");
                }
                _categoryDal.Add(category);
                return new SuccessResult("Category added.");
            }
            catch { }

            return new ErrorResult("Error: Category could not added.");
        }

        public Result Update(Category category)
        {
            try
            {
                var categoryTitle = _categoryDal.Get(c => c.CategoryName == category.CategoryName);
                if (categoryTitle != null)
                {
                    return new ErrorResult("Category title already in use!");
                }
                _categoryDal.Update(category);
                return new SuccessResult("Category updated.");
            }
            catch { }

            return new ErrorResult("Error: Category could not updated.");
        }

        public Result Delete(int categoryId)
        {
            try
            {
                var data = _categoryDal.Get(c => c.Id == categoryId);
                if (data != null)
                {
                    return new ErrorResult("Category Id could not found.");
                }
                _categoryDal.Delete(data);
                return new SuccessResult("Category deleted.");
            }
            catch { }

            return new ErrorResult("Error: Category could not deleted.");
        }
    }
}
