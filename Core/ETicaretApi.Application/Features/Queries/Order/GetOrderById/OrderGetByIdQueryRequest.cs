using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Queries.Order.GetOrderById
{
    public class OrderGetByIdQueryRequest : IRequest<OrderGetByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
