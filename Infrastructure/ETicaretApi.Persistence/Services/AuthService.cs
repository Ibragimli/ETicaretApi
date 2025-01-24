using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccesToken(500, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user.Id, token.Expiration, 500);
                return token;
            }
            else
                throw new Exception("user tapilmadi");
        }
    }
}
