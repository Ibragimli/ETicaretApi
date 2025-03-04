﻿using ETicaretApi.Application.Abstractions.Hubs;
using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretApi.Application.Features.Commands.Product.PostProduct
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommandRequest, PostProductCommandResponse>
    {
        private readonly IProductHubService _productHubService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IProductImageWriteRepository _productImageWriteRepository;

        public PostProductCommandHandler(IProductHubService productHubService, IHttpContextAccessor httpContextAccessor, IProductWriteRepository productWriteRepository, IStorageService storageService, IProductImageWriteRepository productImageWriteRepository)
        {
            _productHubService = productHubService;
            _httpContextAccessor = httpContextAccessor;
            _productWriteRepository = productWriteRepository;
            _storageService = storageService;
            _productImageWriteRepository = productImageWriteRepository;
        }
        public async Task<PostProductCommandResponse> Handle(PostProductCommandRequest request, CancellationToken cancellationToken)
        {
            var newProduct = await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            });
            await _productWriteRepository.SaveAsync();

            var paths = await _storageService.UploadAsync("files", _httpContextAccessor.HttpContext.Request.Form.Files);

            var newProductImages = request.ImageFiles.Select((image, index) => new ETicaretApi.Domain.Entities.ProductImageFile
            {
                ProductId = newProduct.Id,
                Image = image.Name,
                Path = paths.ElementAtOrDefault(index).fileName
            }).ToList();

            await _productImageWriteRepository.AddRangeAsync(newProductImages);
            await _productImageWriteRepository.SaveAsync();
            await _productHubService.ProductAddedMessageAsync($"{request.Name}-prodcut added.");
            return new PostProductCommandResponse
            {
                Success = true,
                Message = "Product successfully Add"
            };
        }
    }
}
