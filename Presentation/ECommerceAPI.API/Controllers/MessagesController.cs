using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.Consts;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.MessageCommands;
using ECommerceAPI.Application.Features.Queries.MessageQueries.GetAllMessagesByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageCommandRequest request)
            => Ok(await _mediator.Send(request));

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Messages, ActionType = ActionType.Reading, Definition = "Read Messages")]
        [HttpGet]
        public async Task<IActionResult> GetAllMessages([FromQuery] GetAllMessagesByUserIdRequest request)
          => Ok(await _mediator.Send(request));
    }
}
