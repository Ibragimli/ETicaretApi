using ETicaretApi.Application.Repositories.BasketItem;
using ETicaretApi.Persistence.Contexts;

namespace ETicaretApi.Persistence.Repositories.BasketItem
{
    public class BasketItemWriteRepository : WriteRepository<ETicaretApi.Domain.Entities.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
