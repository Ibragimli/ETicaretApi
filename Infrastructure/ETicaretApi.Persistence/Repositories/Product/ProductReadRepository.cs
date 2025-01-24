using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
