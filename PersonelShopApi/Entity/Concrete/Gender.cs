using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Gender:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
