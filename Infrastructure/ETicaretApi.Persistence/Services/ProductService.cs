using ETicaretApi.Application.Abstractions;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistence.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IQRCodeService _qRCodeService;
        private readonly ProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IQRCodeService qRCodeService,ProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _qRCodeService = qRCodeService;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<byte[]> QrCodeToProductAsync(int productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedTime
            };
            string plainText = JsonSerializer.Serialize(plainObject);

            return _qRCodeService.GenerateQRCode(plainText);
        }

        public async Task StockUpdateToProductAsync(int productId, int stock)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Stock = stock;
            await _productWriteRepository.SaveAsync();
        }


    }
}
