using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            try
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryNotAdded);
            }
        }

        public IResult Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryNotDeleted);
            }
        }

        public IDataResult<Category> Get(int id)
        {
            try
            {
                var category = _categoryDal.Get(p => p.Id == id);
                return new SuccessDataResult<Category>(category);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Category>(Messages.CategoryNotGet);
            }
        }

        public IDataResult<List<Category>> GetList()
        {
            try
            {
                var categories = _categoryDal.GetList().ToList();
                return new SuccessDataResult<List<Category>>(categories);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Category>>(Messages.CategoryNotGet);
            }
        }

        public IResult Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return new SuccessResult(Messages.ProductUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ProductNotUpdated);
            }
        }
    }
}
