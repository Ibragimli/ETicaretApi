using ETicaretApi.Application.Abstractions.Services.Baskets;
using MediatR;

namespace ETicaretApi.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueriesHandler : IRequestHandler<GetBasketItemsQueriesRequest, List<GetBasketItemsQueriesResponse>>
    {
        private readonly IBasketService _basketService;

        public GetBasketItemsQueriesHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<List<GetBasketItemsQueriesResponse>> Handle(GetBasketItemsQueriesRequest request, CancellationToken cancellationToken)
        {
            var basketItems = await _basketService.GetBasketItemsAsync();
            return basketItems.Select(ba => new GetBasketItemsQueriesResponse
            {
                BasketItemId = ba.Id,
                Name = ba.Product.Name,
                Price = ba.Product.Price,
                Quantity = ba.Quantity
            }).ToList();
        }
    }
}
