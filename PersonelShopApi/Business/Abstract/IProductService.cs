using Core.Utilities.Results;
using Entity.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<ProductDto> GetById(int id);
        IDataResult<List<ProductDto>> GetList();
        IDataResult<List<ProductDto>> GetListByCategoryId(int categoryId);
        IResult Add(ProductDto product);
        IResult Update(ProductDto product);
        IResult Delete(ProductDto product);
    }
}
