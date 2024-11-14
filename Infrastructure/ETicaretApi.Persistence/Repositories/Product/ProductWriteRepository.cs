using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
