using ETicaretApi.Application.Abstractions.Hubs;
using ETicaretApi.Application.Abstractions.Services.Baskets;
using ETicaretApi.Application.Abstractions.Services.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Order.CreateOrder
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommandRequest, OrderCreateCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IOrderHubService _orderHubService;

        public OrderCreateCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _orderHubService = orderHubService;
        }
        public async Task<OrderCreateCommandResponse> Handle(OrderCreateCommandRequest request, CancellationToken cancellationToken)
        {
            int baskId =  _basketService.GetUserActiveBasket.Id;
            await _orderService.CreateOrderAsync(new()
            {
                Adress = request.Address,
                Description = request.Description,
                BasketId = baskId
            });
            //await _orderHubService.OrderAddedMessageAsync("Completed Order");
            return new();

        }
    }
}
