using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.RefreshTokenLoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            return Ok(await _mediator.Send(loginUserCommandRequest));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginUserCommandRequest refreshTokenLoginUserCommandRequest)
        {
            return Ok(await _mediator.Send(refreshTokenLoginUserCommandRequest));
        }
    }
}
