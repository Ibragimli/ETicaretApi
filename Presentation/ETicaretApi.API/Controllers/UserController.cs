using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Enums;
using ETicaretApi.Application.Features.Commands.User.AssignRoleToUser;
using ETicaretApi.Application.Features.Commands.User.CreateUser;
using ETicaretApi.Application.Features.Commands.User.LoginUser;
using ETicaretApi.Application.Features.Commands.User.UpdatePassword;
using ETicaretApi.Application.Features.Queries.Role.GetRoles;
using ETicaretApi.Application.Features.Queries.User.GetAllUsers;
using ETicaretApi.Application.Features.Queries.User.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetAllUsers")]
        [Authorize(AuthenticationSchemes = ("Admin"))]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest request)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetRolesToUser/{UserId}")]
        [Authorize(AuthenticationSchemes = ("Admin"))]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromQuery] GetRolesToUserQueryRequest request)
        {
            GetRolesToUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AssignRoleToUser")]
        [Authorize(AuthenticationSchemes = ("Admin"))]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser([FromForm] AssignRoleToUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
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
