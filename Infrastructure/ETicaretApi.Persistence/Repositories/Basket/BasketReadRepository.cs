using ETicaretApi.Application.Repositories.Basket;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.Basket
{
    public class BasketReadRepository : ReadRepository<ETicaretApi.Domain.Entities.Basket>, IBasketReadRepository
    {
        public BasketReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
