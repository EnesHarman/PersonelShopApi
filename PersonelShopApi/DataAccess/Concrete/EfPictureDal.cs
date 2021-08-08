using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class EfPictureDal : EfEntityRepositoryBase<Picture,PersonelShopDBContext>, IPictureDal
    {
    }
}
