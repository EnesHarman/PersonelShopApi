using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Picture:IEntity
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } 
        public string Definition { get; set; }
        public string Url { get; set; }
    }
}
