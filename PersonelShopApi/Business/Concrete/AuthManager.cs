using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity.Dto;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            Role role = _userService.GetRoles(user).Data;
            AccessToken token = _tokenHelper.CreateToken(user,role);
            return new SuccessDataResult<AccessToken>(token);

        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            IDataResult<User> result = _userService.GetByMail(userLoginDto.Email);
            if (!result.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, result.Data.PasswordHash, result.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(result.Data);

        }

        public IResult Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);

            User user = new User
            {
                Name = userRegisterDto.Name,
                SurName = userRegisterDto.SurName,
                PhoneNum = userRegisterDto.PhoneNum,
                Adress = userRegisterDto.Adress,
                Email = userRegisterDto.Email,
                Age = userRegisterDto.Age,
                Gender = userRegisterDto.Gender,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            var result = _userService.Add(user);

            return result;
        }

        public IResult UserExist(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
