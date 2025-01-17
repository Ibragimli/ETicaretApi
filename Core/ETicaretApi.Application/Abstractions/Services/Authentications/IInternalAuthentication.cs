using ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
