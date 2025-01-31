using ETicaretApi.Application.ViewModels.Basket;
using ETicaretApi.Domain.Entities;

namespace ETicaretApi.Application.Abstractions.Services.Baskets
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(BasketItemViewModel basketItemVM);
        public Task UpdateQuantityAsync(UpdateBasketItemViewModel updateBasketItemVM);
        public Task RemoveBasketItemAsync(int basketId);
        public Basket? GetUserActiveBasket { get; }
    }
}
