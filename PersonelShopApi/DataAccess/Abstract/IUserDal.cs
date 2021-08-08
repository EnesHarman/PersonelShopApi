using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<Role> GetRole(User user);
    }
}
