using ETicaretApi.Application.Abstractions.Services.Authentications;

namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication, IExternalAuthentication
    {
        Task PasswordResetAsync(string username);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
