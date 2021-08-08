using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
