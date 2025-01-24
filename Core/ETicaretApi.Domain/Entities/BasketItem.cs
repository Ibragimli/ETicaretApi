using ETicaretApi.Domain.Entities.Common;

namespace ETicaretApi.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
