using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.ProductImage
{
    public class ProductImageReadRepository : ReadRepository<ETicaretApi.Domain.Entities.ProductImageFile>, IProductImageReadRepository
    {
        public ProductImageReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
