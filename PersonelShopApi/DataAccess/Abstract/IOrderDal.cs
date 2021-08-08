using Core.DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public  interface IOrderDal : IEntityRepository<Order>
    {
        List<Product> GetOrders(int userId);
    }
}
