using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Status:IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
