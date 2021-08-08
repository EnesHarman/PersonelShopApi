using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserRoleDal _userRoleDal;

        public UserManager(IUserDal userDal, IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _userRoleDal = userRoleDal;
        }

        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                UserRole userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = Roles.StandartMemberRole,
                };
                _userRoleDal.Add(userRole);
                return new SuccessResult(Messages.UserRegistered);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UserCantRegister);
            }
        }

        public IDataResult<User> GetByMail(string email)
        {
            try
            {
                User user = _userDal.Get(u => u.Email == email);
                if(user== null)
                {
                    return new ErrorDataResult<User>(Messages.UserNotFound);
                }
                return new SuccessDataResult<User>(user);
            }
            catch (Exception)
            {

                return new ErrorDataResult<User>(Messages.UserCantGet);
            }
        }

        public IDataResult<Role> GetRoles(User user)
        {
            List<Role> roles;
            Role role;
            try
            {
                roles = _userDal.GetRole(user);
                role = roles[0];
                return new SuccessDataResult<Role>(role);

            }
            catch (Exception)
            {
                return new ErrorDataResult<Role>(Messages.CantGetRole);

            }
        }
    }
}
