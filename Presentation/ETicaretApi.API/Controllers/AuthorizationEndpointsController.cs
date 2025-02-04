using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Enums;
using ETicaretApi.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using ETicaretApi.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints;
using ETicaretApi.Application.Features.Queries.Role.GetRoleById;
using ETicaretApi.Application.Features.Queries.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AuthorizationEndpointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("GetRolesToEndpoints")]
        public async Task<IActionResult> GetRolesToEndpoints( GetRolesToEndpointQueryRequest getRolesToEndpointQueryRequest)
        {
            GetRolesToEndpointQueryResponse response = await _mediator.Send(getRolesToEndpointQueryRequest);
            return Ok(response);
        }

        [HttpPost("AssignRoleEndpoint")]
        [AuthorizeDefinition(ActionType = ActionType.Writing)]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
