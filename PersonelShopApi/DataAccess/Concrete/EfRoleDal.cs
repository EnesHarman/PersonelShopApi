using Core.DataAccess.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete
{
    public class EfRoleDal:EfEntityRepositoryBase<Role,PersonelShopDBContext>,IRoleDal
    {
    }
}
