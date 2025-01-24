using MediatR;
using Microsoft.AspNetCore.Http;

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
