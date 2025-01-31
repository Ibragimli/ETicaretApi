using ETicaretApi.Application.Abstractions.Services.Order;
using ETicaretApi.Application.Features.Queries.Product.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Queries.Order.GetOrderById
{
    public class OrderGetByIdQueryHandler : IRequestHandler<OrderGetByIdQueryRequest, OrderGetByIdQueryResponse>
    {
        readonly IOrderService _orderService;

        public OrderGetByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<OrderGetByIdQueryResponse> Handle(OrderGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _orderService.GetOrderByIdAsync(request.Id);
            return new()
            {
                Id = data.Id,
                OrderCode = data.OrderCode,
                Address = data.Address,
                BasketItems = data.BasketItems,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                Completed = data.Completed
            };
        }
    }
}
