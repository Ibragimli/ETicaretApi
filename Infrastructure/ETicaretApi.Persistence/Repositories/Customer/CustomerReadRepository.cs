using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
