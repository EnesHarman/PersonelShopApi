using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
