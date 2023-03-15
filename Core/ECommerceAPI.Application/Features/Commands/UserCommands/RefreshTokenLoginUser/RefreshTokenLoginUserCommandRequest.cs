using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.RefreshTokenLoginUser
{
    public class RefreshTokenLoginUserCommandRequest:IRequest<RefreshTokenLoginUserCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
