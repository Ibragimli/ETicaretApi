namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, string userId, DateTime accesTokenDate, int AddOnAccesTokenDate);
        Task UpdatePassword(string userId,string resetToken,string newPassword);
    }
}
