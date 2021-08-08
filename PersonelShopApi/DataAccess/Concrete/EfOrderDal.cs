using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfOrderDal:EfEntityRepositoryBase<Order,PersonelShopDBContext>,IOrderDal
    {
        public List<Product> GetOrders(int userId)
        {
            using(var context = new PersonelShopDBContext())
            {
                var result = from orders in context.Orders
                             join product in context.Products
                             on orders.ProductId equals product.Id
                             where orders.UserID == userId
                             select new Product
                             {
                                 Id = product.Id,
                                 Code=product.Code,
                                 Name = product.Name,
                                 Definition = product.Definition,
                                 QuantityPerUnit = product.QuantityPerUnit,
                                 Price = product.Price,
                                 CategoryId = product.CategoryId
                                 
                             };
                return result.ToList();
                             
            }
        }
    }
}
