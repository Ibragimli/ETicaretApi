using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
