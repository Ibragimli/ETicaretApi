using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, string userId, DateTime accesTokenDate, int AddOnAccesTokenDate);
    }
}
