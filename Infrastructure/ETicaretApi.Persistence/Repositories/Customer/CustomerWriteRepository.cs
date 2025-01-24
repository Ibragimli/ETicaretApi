using ETicaretApi.Application.Repositories.Customer;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
