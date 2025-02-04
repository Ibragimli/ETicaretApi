using ETicaretApi.Application.DTOs;

namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, string userId, DateTime accesTokenDate, int AddOnAccesTokenDate);
        Task UpdatePassword(string userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUsersAsync(int page, int size);
        Task AssingRoleToUserAsync(string userId, string[] roles);
        int TotalUserCount { get; }

        Task<string[]> GetRolesToUserAsync(string userIdOrUsername);
        Task<bool> HasRolePermissionToEndpointAsync(string username, string code);

    }
}
