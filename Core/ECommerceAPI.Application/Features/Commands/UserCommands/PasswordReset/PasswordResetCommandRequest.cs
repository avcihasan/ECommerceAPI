using MediatR;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.PasswordReset
{
    public class PasswordResetCommandRequest:IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}