using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.PostProduct
{
    public class PostProductCommandRequest : IRequest<PostProductCommandResponse>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }
}
