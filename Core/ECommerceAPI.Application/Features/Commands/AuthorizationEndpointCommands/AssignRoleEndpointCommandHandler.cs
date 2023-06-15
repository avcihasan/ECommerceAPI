using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.AuthorizationEndpointCommands
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        public AssignRoleEndpointCommandHandler(IServiceManager serviceManager)
        {

            _serviceManager = serviceManager;
        }

        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
          await  _serviceManager.AuthorizationEndpointService.AssignRoleEndpointAsync(request.Roles,request.Controller, request.Code,request.Type);
            return new();
        }
    }
}
