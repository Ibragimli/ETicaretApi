using ETicaretApi.Application.DTOs;
using ETicaretApi.Domain.Entities.Identity;

namespace ETicaretApi.Application.Abstractions.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccesToken(int minute, AppUser user);
        string CreateRefreshToken();


    }
}
