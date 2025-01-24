using MediatR;

namespace ETicaretApi.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
