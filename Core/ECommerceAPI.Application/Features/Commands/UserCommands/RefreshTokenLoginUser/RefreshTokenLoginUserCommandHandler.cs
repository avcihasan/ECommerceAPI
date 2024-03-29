﻿using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
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
        readonly IAuthService _serviceManager;

        public RefreshTokenLoginUserCommandHandler(IAuthService serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<RefreshTokenLoginUserCommandResponse> Handle(RefreshTokenLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return new () { Token = await _serviceManager.RefreshTokenLoginAsync(request.RefreshToken) };
        }
    }
}
