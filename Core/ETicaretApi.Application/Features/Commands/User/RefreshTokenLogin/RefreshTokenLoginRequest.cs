using MediatR;

namespace ETicaretApi.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginRequest : IRequest<RefreshTokenLoginResponse>
    {
        public string RefreshToken { get; set; }
    }
}
