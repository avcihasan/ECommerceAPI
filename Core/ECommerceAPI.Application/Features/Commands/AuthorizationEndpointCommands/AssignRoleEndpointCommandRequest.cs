using MediatR;

namespace ECommerceAPI.Application.Features.Commands.AuthorizationEndpointCommands
{
    public class AssignRoleEndpointCommandRequest:IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Controller { get; set; }
        public Type? Type { get; set; }
    }
}