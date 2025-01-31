using ETicaretApi.Application.Abstractions.Helpers;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Exceptions;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
