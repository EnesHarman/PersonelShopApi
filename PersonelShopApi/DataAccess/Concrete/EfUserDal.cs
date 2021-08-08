using Core.DataAccess.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, PersonelShopDBContext>, IUserDal
    {
        public List<Role> GetRole(User user)
        {
            using (var context = new PersonelShopDBContext())
            {
                var result = from roles in context.Roles
                             join users in context.UserRoles
                             on roles.Id equals users.RoleId
                             where users.UserId == user.Id
                             select new Role { Id = roles.Id, Name = roles.Name };
                return result.ToList();
            }
        }
    }
}
