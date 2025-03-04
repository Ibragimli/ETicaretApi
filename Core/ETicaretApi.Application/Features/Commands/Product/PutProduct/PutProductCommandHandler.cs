﻿using ETicaretApi.Application.Repositories.Product;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ETicaretApi.Application.Features.Commands.Product.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommandRequest, PutProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ILogger<PutProductCommandHandler> _logger;

        public PutProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<PutProductCommandHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }
        public async Task<PutProductCommandResponse> Handle(PutProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product update");
            return new PutProductCommandResponse
            {
                Success = true,
                Message = "Product successfully deleted"
            };
        }
    }
}
