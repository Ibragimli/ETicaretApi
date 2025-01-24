using ETicaretApi.Application.Repositories.ProductImage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        private readonly IProductImageWriteRepository _productImageWriteRepository;

        public ChangeShowcaseImageCommandHandler(IProductImageWriteRepository productImageWriteRepository)
        {
            _productImageWriteRepository = productImageWriteRepository;
        }
        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _productImageWriteRepository.Table
                      .Include(p => p.Products)
                      .SelectMany(p => p.Products, (pif, p) => new
                      {
                          pif,
                          p
                      });
            var data = await query.FirstOrDefaultAsync(x => x.p.Id == request.ProductId && x.pif.Showcase);
            data.pif.Showcase = false;
            if (data != null)
                data.pif.Showcase = false;
            var image = await query.FirstOrDefaultAsync(p => p.pif.Id == request.ImageId);
            if (image != null)
                image.pif.Showcase = true;
            await _productImageWriteRepository.SaveAsync();
            return new();

        }
    }
}
