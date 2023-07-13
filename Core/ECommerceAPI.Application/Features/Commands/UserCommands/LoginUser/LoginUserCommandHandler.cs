using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _serviceManager;

        public LoginUserCommandHandler(IAuthService serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
         
            return new LoginUserSuccessCommandResponse()
            {
                Token = await _serviceManager.LoginAsync(new() { UserNameOrEmail = request.UserNameOrEmail, Password = request.Password }, 10)
            };
        }
    }
}
