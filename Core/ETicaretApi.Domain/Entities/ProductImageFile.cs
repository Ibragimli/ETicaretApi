using ETicaretApi.Domain.Entities.Common;

namespace ETicaretApi.Domain.Entities
{
    public class ProductImageFile : BaseEntity
    {
        public string Image { get; set; }
        public bool Showcase { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
