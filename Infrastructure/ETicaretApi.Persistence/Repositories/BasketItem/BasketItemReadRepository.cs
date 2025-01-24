using ETicaretApi.Application.Repositories.BasketItem;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.BasketItem
{
    public class BasketItemReadRepository : ReadRepository<ETicaretApi.Domain.Entities.BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
