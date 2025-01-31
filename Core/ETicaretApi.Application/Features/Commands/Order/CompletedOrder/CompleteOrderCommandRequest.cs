using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Order.CompletedOrder
{
    public class CompleteOrderCommandRequest : IRequest<CompletedOrderCommandResponse>
    {
        public int OrderId { get; set; }
    }
}
