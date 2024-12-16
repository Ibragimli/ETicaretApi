using ETicaretApi.Application.Features.Commands.Product.DeleteProduct;
using ETicaretApi.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ETicaretApi.Application.Features.Commands.Product.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommandRequest, PutProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public PutProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<PutProductCommandResponse> Handle(PutProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productWriteRepository.SaveAsync();
            return new PutProductCommandResponse
            {
                Success = true,
                Message = "Product successfully deleted"
            };
        }
    }
}
