using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.ProductImage
{
    public class ProductImageWriteRepository : WriteRepository<ProductImageFile>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
