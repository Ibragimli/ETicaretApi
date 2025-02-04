using ETicaretApi.Application.Abstractions.Helpers;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Exceptions;
using ETicaretApi.Application.Repositories.Endpoint;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretApi.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
        }

        public int TotalUserCount => _userManager.Users.Count();

        public async Task AssingRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, roles);
            }

        }

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users.Skip(page * size).Take(size).ToListAsync();

            return users.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Name = user.Name,
                TwoFactorEnabled = user.TwoFactorEnabled
            }).ToList();
        }

        public async Task<string[]> GetRolesToUserAsync(string userIdOrUsername)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrUsername);
            if (user == null)
                user = await _userManager.FindByNameAsync(userIdOrUsername);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string username, string code)
        {
            var userRoles = await GetRolesToUserAsync(username);
            if (!userRoles.Any())
                return false;
            Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == code);
            if (endpoint == null)
                return false;

            var endpointRoles = endpoint.Roles.Select(r => r.Name);
            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                {
                    if (userRole == endpointRole)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task UpdatePassword(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }

        }

        public async Task UpdateRefreshToken(string refreshToken, string userId, DateTime accesTokenDate, int AddOnAccesTokenDate)
        {

            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accesTokenDate.AddSeconds(AddOnAccesTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("Tapilmadi istifadeci");
        }
    }
}
