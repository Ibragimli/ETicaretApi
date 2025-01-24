using ETicaretApi.Domain.Entities.Common;

namespace ETicaretApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public Basket Basket { get; set; }
    }
}
