using ETicaretApi.Application.Features.Commands.User.LoginUser;
using ETicaretApi.Application.Features.Commands.User.PasswordReset;
using ETicaretApi.Application.Features.Commands.User.RefreshTokenLogin;
using ETicaretApi.Application.Features.Commands.User.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromForm] RefreshTokenLoginRequest refreshTokenLoginRequest)
        {
            RefreshTokenLoginResponse response = await _mediator.Send(refreshTokenLoginRequest);
            return Ok(response);
        }
        [HttpPost("PasswordReset")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }
        [HttpPost("VerifyResetToken")]
        public async Task<IActionResult> VerifyResetTokenAsync([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommand)
        {
            VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommand);
            return Ok(response);
        }
    }
}
