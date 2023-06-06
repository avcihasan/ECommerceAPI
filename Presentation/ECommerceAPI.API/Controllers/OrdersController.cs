using ECommerceAPI.Application.Features.Commands.OrderCommands.CompleteOrder;
using ECommerceAPI.Application.Features.Commands.OrderCommands.CreateOrder;
using ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders;
using ECommerceAPI.Application.Features.Queries.OrderQueries.GetByIdOrder;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrdersQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetByIdOrderQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest request)
           => Ok(await _mediator.Send(request));

    }
}
