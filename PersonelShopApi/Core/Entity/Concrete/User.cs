using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNum { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
