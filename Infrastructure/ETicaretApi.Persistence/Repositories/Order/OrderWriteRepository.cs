using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
