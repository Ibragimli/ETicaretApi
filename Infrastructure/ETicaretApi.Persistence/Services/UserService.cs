using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
