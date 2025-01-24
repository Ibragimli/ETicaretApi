using ETicaretApi.Application.DTOs;

namespace ETicaretApi.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
