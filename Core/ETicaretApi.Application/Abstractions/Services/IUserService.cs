namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, string userId, DateTime accesTokenDate, int AddOnAccesTokenDate);
    }
}
