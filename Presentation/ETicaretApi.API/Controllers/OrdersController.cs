using ETicaretApi.Application.Consts;
using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Enums;
using ETicaretApi.Application.Features.Commands.Order.CompletedOrder;
using ETicaretApi.Application.Features.Commands.Order.CreateOrder;
using ETicaretApi.Application.Features.Queries.Order.GetAllOrders;
using ETicaretApi.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Writing)]
        public async Task<IActionResult> CreateOrder(OrderCreateCommandRequest orderCreateCommandRequest)
        {
            OrderCreateCommandResponse response = await _mediator.Send(orderCreateCommandRequest);
            return Ok(response);
        }

        [HttpGet("GetAllOrdersOrder")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Reading)]
        public async Task<IActionResult> GetAllOrdersOrder([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Reading)]
        public async Task<IActionResult> GetOrderById([FromRoute] OrderGetByIdQueryRequest orderGetByIdQueryRequest)
        {
            OrderGetByIdQueryResponse response = await _mediator.Send(orderGetByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet("CompleteOrder/{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinationConstants.Orders, ActionType = Application.Enums.ActionType.Updating)]
        public async Task<IActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
        {
            CompletedOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
            return Ok(response);
        }

    }
}
