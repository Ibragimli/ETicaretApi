using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
