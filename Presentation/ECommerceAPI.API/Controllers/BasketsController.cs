using Azure.Core;
using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.Consts;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.BasketCommands.AddItemToBasket;
using ECommerceAPI.Application.Features.Commands.BasketCommands.RemoveBasketItem;
using ECommerceAPI.Application.Features.Commands.BasketCommands.UpdateQuantity;
using ECommerceAPI.Application.Features.Queries.BasketQueries.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Writing, Definition = "Add Item To Basket")]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpDelete("{BasketItemId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Deleting, Definition = "Remove Basket Item")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
          => Ok(await _mediator.Send(request));

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Updating, Definition = "Update Quantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
         => Ok(await _mediator.Send(request));
    }
}
