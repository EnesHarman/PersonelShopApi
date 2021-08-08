using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
        IDataResult<Category> Get(int id);
        IResult Update(Category category);
        IResult Add(Category category);
        IResult Delete(Category category);
    }
}
