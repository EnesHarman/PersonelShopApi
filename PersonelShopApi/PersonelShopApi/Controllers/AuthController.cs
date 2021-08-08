using Business.Abstract;
using Business.Constants;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace PersonelShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService _userService;
        IAuthService _authService;
        public AuthController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register ([FromBody] UserRegisterDto userRegisterDto)
        {
            var result = _userService.GetByMail(userRegisterDto.Email);
            if (result.Success)
            {
                return BadRequest(Messages.UserAlreadyExist);
            }

            var userResult = _authService.Register(userRegisterDto);
            if (userResult.Success)
            {
               return Ok(userResult.Message);
            }
            else
            {
                return BadRequest(userResult.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginDto userLoginDto)
        {
            var userToLogin = _authService.Login(userLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var TokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (TokenResult.Success)
            {
                return Ok(TokenResult.Data);
            }
            else
            {
                return BadRequest(TokenResult.Message);
            }
        }
    }
}
