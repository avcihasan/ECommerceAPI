using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandRequest:IRequest<RemoveByIdProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
