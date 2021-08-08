using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Code { get; set; }
    }
}
