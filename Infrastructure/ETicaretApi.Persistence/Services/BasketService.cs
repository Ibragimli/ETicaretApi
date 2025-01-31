using ETicaretApi.Application.Abstractions.Services.Baskets;
using ETicaretApi.Application.Repositories.Basket;
using ETicaretApi.Application.Repositories.BasketItem;
using ETicaretApi.Application.Repositories.Order;
using ETicaretApi.Application.ViewModels.Basket;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Identity;
using ETicaretApi.Persistence.Repositories.BasketItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Persistence.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IBasketItemWriteRepository _basketItemWriteRepository;
        private readonly IBasketItemReadRepository _basketItemReadRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;

        public BasketService(IHttpContextAccessor httpContextAccessor, IBasketReadRepository basketReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketReadRepository = basketReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }
        public Basket? GetUserActiveBasket
        {
            get
            {
                //Basket? basket = ContextUser().Result;
                //return basket;
                try
                {
                    Basket? basket = ContextUser().Result;
                    return basket;
                }
                catch (Exception ex)
                {
                    // Hata detaylarını logla veya özel bir mesaj döndür
                    throw new Exception("Error getting active basket: " + ex.Message, ex);
                }
            }

        }
        private async Task<Basket?> ContextUser()
        {
            AppUser? user = new AppUser();

            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
            {
                user = await _userManager.Users.Include(x => x.Baskets).FirstOrDefaultAsync(x => x.UserName == username);
                var _basket = from basket in user.Baskets
                              join order in _orderReadRepository.Table
                              on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };
                Basket targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(x => x.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }
                try
                {
                    await _basketWriteRepository.SaveAsync();
                }
                catch (Exception ex)
                {
                    // İç hatayı ve mesajı logla
                    throw new Exception("An error occurred while saving the entity changes.", ex.InnerException);
                }
                //await _basketWriteRepository.SaveAsync();

                return targetBasket;
            }
            throw new Exception("Error message for basket");
        }
        public async Task AddItemToBasketAsync(BasketItemViewModel basketItemVM)
        {
            Basket? basket = await ContextUser();
            if (basket != null)
            {
                var basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == basketItemVM.ProductId);
                if (basketItem != null)
                    basketItem.Quantity++;
                else
                {
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = basketItemVM.ProductId,
                        Quantity = basketItemVM.Quantity
                    });
                }
                await _basketItemWriteRepository.SaveAsync();

            }
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            Basket? result = await _basketReadRepository.Table.Include(b => b.BasketItems).ThenInclude(bi => bi.Product).FirstOrDefaultAsync(b => b.Id == basket.Id);
            return result.BasketItems.ToList();
        }

        public async Task RemoveBasketItemAsync(int basketId)
        {
            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketId);
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(UpdateBasketItemViewModel updateBasketItemVM)
        {
            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(updateBasketItemVM.BasketItemId);
            if (basketItem != null)
            {
                basketItem.Quantity = updateBasketItemVM.Quantity;
                await _basketItemWriteRepository.SaveAsync();
            }
        }
    }
}
