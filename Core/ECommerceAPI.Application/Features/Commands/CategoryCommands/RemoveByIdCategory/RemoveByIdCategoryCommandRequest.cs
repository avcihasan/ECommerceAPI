using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.CategoryCommands.RemoveByIdCategory
{
    public class RemoveByIdCategoryCommandRequest:IRequest<RemoveByIdCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
