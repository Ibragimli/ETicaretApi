using MediatR;

namespace ETicaretApi.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
    }
}
