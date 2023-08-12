using ECommerceAPI.Application.Features.Commands.UserCommands.CheckPasswordResetToken;
using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.PasswordReset;
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
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginUserCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> CheckPasswordResetToken([FromBody] CheckPasswordResetTokenCommandRequest request)
            => Ok(await _mediator.Send(request));

    }
}
