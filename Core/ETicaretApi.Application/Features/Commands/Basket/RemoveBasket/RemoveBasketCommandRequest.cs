using MediatR;

namespace ETicaretApi.Application.Features.Commands.Basket.RemoveBasket
{
    public class RemoveBasketCommandRequest : IRequest<RemoveBasketCommandResponse>
    {
        public int BasketItemId { get; set; }
    }
}
