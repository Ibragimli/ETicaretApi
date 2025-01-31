using ETicaretApi.Application.Consts;
using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Features.Commands.Basket.AddItemToBasket;
using ETicaretApi.Application.Features.Commands.Basket.RemoveBasket;
using ETicaretApi.Application.Features.Commands.Basket.UpdateQuantity;
using ETicaretApi.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBasketItems")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Reading)]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueriesRequest getBasketItemsQueriesRequest)
        {
            List<GetBasketItemsQueriesResponse> response = await _mediator.Send(getBasketItemsQueriesRequest);
            return Ok(response);
        }

        [HttpPost("AddItemToBasket")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Writing)]
        public async Task<IActionResult> AddItemToBasket([FromBody] AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }

        [HttpPut("UpdateToBasket")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Updating)]

        public async Task<IActionResult> UpdateToBasket(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("RemoveBasket/{BasketItemId}")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinationConstants.Baskets, ActionType = Application.Enums.ActionType.Deleting)]
        public async Task<IActionResult> RemoveBasket(int BasketItemId)
        {
            // RemoveBasketCommandRequest nesnesini oluştur
            var removeBasketCommandRequest = new RemoveBasketCommandRequest
            {
                BasketItemId = BasketItemId
            };

            // MediatR üzerinden isteği gönder
            RemoveBasketCommandResponse response = await _mediator.Send(removeBasketCommandRequest);

            return Ok(response);
        }

        //[HttpDelete("RemoveBasket/{BasketItemId}")]
        //public async Task<IActionResult> RemoveBasket(RemoveBasketCommandRequest removeBasketCommandRequest)
        //{
        //    RemoveBasketCommandResponse response = await _mediator.Send(removeBasketCommandRequest);
        //    return Ok(response);
        //}
    }
}
