using ETicaretApi.Application.Abstractions.Services.Baskets;
using MediatR;

namespace ETicaretApi.Application.Features.Commands.Basket.RemoveBasket
{
    public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommandRequest, RemoveBasketCommandResponse>
    {
        private readonly IBasketService _basketService;

        public RemoveBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<RemoveBasketCommandResponse> Handle(RemoveBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.RemoveBasketItemAsync(request.BasketItemId);
            return new();
        }
    }
}
