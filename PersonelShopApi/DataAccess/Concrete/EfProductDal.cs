using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product,PersonelShopDBContext>,IProductDal
    {

    }
}
