using Azure.Core;
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
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
          => Ok(await _mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
         => Ok(await _mediator.Send(request));
    }
}
