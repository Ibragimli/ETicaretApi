using ETicaretApi.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Order.CreateOrder
{
    public class OrderCreateCommandRequest : IRequest<OrderCreateCommandResponse>
    {
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
