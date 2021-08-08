using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<ProductDto>> GetOrders(int userId);
        IResult Add(Order order);
        IResult Delete(Order order);
        Task<IResult> Execute(User user, List<ProductDto> orders);
    }
}
