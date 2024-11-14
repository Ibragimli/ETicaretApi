using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
