using ETicaretApi.Application.Features.Commands.User.CreateUser;
using ETicaretApi.Application.Features.Commands.User.LoginUser;
using ETicaretApi.Application.Features.Commands.User.UpdatePassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = new();
            try
            {
                response = await _mediator.Send(request);

            }
            catch (Exception ms)
            {
                return Ok(ms.Message);
            }
            return Ok(response);
        }
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromForm] UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse response = new();
            try
            {
                response = await _mediator.Send(request);

            }
            catch (Exception ms)
            {
                return Ok(ms.Message);
            }
            return Ok(response);
        }
    }
}
