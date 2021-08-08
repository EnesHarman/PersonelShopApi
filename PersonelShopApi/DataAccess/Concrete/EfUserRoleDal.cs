using Core.DataAccess.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole,PersonelShopDBContext>,IUserRoleDal
    {
    }
}
