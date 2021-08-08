using Core.Entity.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<Role> GetRoles(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
    }
}
