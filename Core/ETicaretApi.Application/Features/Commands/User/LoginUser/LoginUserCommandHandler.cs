using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Exceptions;
using ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(SignInManager<AppUser> signInManager, IUserService userService, UserManager<AppUser> userManager, ITokenHandler tokenHandler, ILogger<LoginUserCommandHandler> logger)
        {
            _signInManager = signInManager;
            _userService = userService;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _logger = logger;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
                throw new NotFoundUserException("Istifadeci tapilmadi");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccesToken(20, user);

                await _userService.UpdateRefreshToken(token.RefreshToken, user.Id, token.Expiration, 15);
                _logger.LogInformation(user.Name + "-hesaba daxil oldu.");
                return new LoginUserCommandResponse()
                {
                    Token = token,
                    Message = "Daxil oldunuz " + user.Name + "bəy"

                };

            }
            return new()
            {
                Succes = false,
                Message = "Tapılmadı istifadeçi"
            };
        }
    }
}
