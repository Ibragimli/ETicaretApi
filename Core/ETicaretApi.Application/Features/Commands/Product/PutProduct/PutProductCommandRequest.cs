using MediatR;

namespace ETicaretApi.Application.Features.Commands.Product.PutProduct
{
    public class PutProductCommandRequest : IRequest<PutProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
