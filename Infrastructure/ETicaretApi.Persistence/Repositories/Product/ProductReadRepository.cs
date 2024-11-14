using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
