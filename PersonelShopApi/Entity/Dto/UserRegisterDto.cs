using Core.Entity.Abstract;

namespace Entity.Dto
{
    public class UserRegisterDto : IDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNum { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Gender {get; set;}
        public string Password { get; set; }
    }
}
