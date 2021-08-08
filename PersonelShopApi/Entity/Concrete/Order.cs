using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }       
        public int ProductId { get; set; }

    }
}
