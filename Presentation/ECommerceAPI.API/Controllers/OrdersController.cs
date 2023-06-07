using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.Consts;
using ECommerceAPI.Application.Enums;
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
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Create Order")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get All Orders")]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrdersQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order By Id")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetByIdOrderQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("[action]/{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating, Definition = "Complete Order")]
        public async Task<IActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest request)
           => Ok(await _mediator.Send(request));

    }
}
