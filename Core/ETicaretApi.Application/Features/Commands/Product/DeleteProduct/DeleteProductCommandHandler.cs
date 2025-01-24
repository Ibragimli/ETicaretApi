using ETicaretApi.Application.Abstractions.Storage;
using ETicaretApi.Application.Features.Commands.Product.DeleteProduct;
using ETicaretApi.Application.Repositories.Product;
using ETicaretApi.Application.Repositories.ProductImage;
using MediatR;

namespace ETicaretApi.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductImageReadRepository _productImageRead;
        private readonly IProductImageWriteRepository _productImageWriteRepository;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IStorageService storageService, IProductReadRepository productReadRepository, IProductImageReadRepository productImageRead, IProductImageWriteRepository productImageWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _storageService = storageService;
            _productReadRepository = productReadRepository;
            _productImageRead = productImageRead;
            _productImageWriteRepository = productImageWriteRepository;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (!await _productReadRepository.IsExistAsync(request.Id))
                //return Ok("tapilmadi");
                throw new Exception("Tapilmadi");
            foreach (var image in _productImageRead.GetWhere(x => x.ProductId == request.Id).ToList())
            {
                await _productImageWriteRepository.RemoveAsync(image.Id);
                await _storageService.DeleteAsync("files", image.Path);

            }
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();

            // İşlem başarılı olduğunda dönüş değeri ekleniyor
            return new DeleteProductCommandResponse
            {
                Success = true,
                Message = "Product successfully deleted"
            };
        }
    }
}
