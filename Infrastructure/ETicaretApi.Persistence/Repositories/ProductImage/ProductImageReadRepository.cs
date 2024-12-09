using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.ProductImage
{
    public class ProductImageReadRepository : ReadRepository<ETicaretApi.Domain.Entities.ProductImageFile>, IProductImageReadRepository
    {
        public ProductImageReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
