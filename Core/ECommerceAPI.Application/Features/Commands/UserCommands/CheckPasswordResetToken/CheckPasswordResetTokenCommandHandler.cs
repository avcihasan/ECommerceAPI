using ECommerceAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.CheckPasswordResetToken
{
    public class CheckPasswordResetTokenCommandHandler : IRequestHandler<CheckPasswordResetTokenCommandRequest, CheckPasswordResetTokenCommandResponse>
    {
        readonly IAuthService _authService;

        public CheckPasswordResetTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CheckPasswordResetTokenCommandResponse> Handle(CheckPasswordResetTokenCommandRequest request, CancellationToken cancellationToken)
            =>new() { State=await _authService.CheckPasswordResetTokenAsync(request.ResetToken, request.UserId) };
        
    }
}
