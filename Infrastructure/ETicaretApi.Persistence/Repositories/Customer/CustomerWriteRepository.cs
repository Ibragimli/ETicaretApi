using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
