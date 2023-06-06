using MediatR;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.CheckPasswordResetToken
{
    public class CheckPasswordResetTokenCommandRequest:IRequest<CheckPasswordResetTokenCommandResponse>
    {
        public string ResetToken { get; set; }
        public string UserId { get; set; }
    }
}