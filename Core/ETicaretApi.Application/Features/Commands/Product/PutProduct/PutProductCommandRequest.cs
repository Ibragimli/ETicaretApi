using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.PutProduct
{
    public class PutProductCommandRequest:IRequest<PutProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
