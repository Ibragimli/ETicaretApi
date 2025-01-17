using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginHandler : IRequestHandler<RefreshTokenLoginRequest, RefreshTokenLoginResponse>
    {
        private readonly IAuthService _authService;

        public RefreshTokenLoginHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<RefreshTokenLoginResponse> Handle(RefreshTokenLoginRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new()
            {
                Token = token
            };
        }
    }
}
