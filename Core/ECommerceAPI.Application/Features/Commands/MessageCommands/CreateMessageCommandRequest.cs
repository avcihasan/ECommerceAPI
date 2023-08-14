using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.MessageCommands
{
    public class CreateMessageCommandRequest:IRequest<CreateMessageCommandResponse>
    {
        public Guid ToUserId { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
