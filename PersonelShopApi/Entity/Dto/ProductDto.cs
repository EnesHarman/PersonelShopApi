using Core.Entity.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Entity.Dto
{
    public class ProductDto:IDto
    {
        public Product  Product { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
