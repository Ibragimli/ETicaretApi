using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
