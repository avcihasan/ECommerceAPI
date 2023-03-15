using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            return Ok(await _mediator.Send(createUserCommandRequest));
        }

        
    }
}
