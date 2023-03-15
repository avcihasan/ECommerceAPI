using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
         
            return new LoginUserSuccessCommandResponse()
            {
                Token = await _authService.LoginAsync(new() { UserNameOrEmail = request.UserNameOrEmail, Password = request.Password }, 10)
            };
        }
    }
}
