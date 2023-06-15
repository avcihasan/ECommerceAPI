using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
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
        readonly IServiceManager _serviceManager;

        public CheckPasswordResetTokenCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CheckPasswordResetTokenCommandResponse> Handle(CheckPasswordResetTokenCommandRequest request, CancellationToken cancellationToken)
            =>new() { State=await _serviceManager.AuthService.CheckPasswordResetTokenAsync(request.ResetToken, request.UserId) };
        
    }
}
