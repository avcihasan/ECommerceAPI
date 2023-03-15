using ECommerceAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.RefreshTokenLoginUser
{
    public class RefreshTokenLoginUserCommandHandler : IRequestHandler<RefreshTokenLoginUserCommandRequest, RefreshTokenLoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public RefreshTokenLoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginUserCommandResponse> Handle(RefreshTokenLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return new () { Token = await _authService.RefreshTokenLoginAsync(request.RefreshToken) };
        }
    }
}
