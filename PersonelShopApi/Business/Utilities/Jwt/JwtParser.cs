using Business.Abstract;
using Business.Utilities.Abstract;
using Core.Entity.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Business.Utilities.Jwt
{
    public class JwtParser : IParser
    {
        JwtSecurityTokenHandler _handler;
        IUserService _userService;
        public JwtParser(IUserService userService)
        {
            _handler = new JwtSecurityTokenHandler();
            _userService = userService;
        }
        public  User ParseJwtToUser(string token)
        {
            
            var data = _handler.ReadJwtToken(token);
            string email = data.Payload.ElementAt(1).Value.ToString();
            
            User user = _userService.GetByMail(email).Data;

            return user;
        }
    }
}
