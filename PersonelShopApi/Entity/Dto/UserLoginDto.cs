using Core.Entity.Abstract;

namespace Entity.Dto
{
    public class UserLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
