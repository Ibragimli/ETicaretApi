using ETicaretApi.Application.Repositories.Basket;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Basket
{
    public class BasketWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
