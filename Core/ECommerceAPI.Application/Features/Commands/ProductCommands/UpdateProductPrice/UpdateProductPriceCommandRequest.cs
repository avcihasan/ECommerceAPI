using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProductPrice
{
    public class UpdateProductPriceCommandRequest:IRequest<UpdateProductPriceCommandResponse>
    {
        public string ProductId { get; set; }
        public decimal NewPrice { get; set; }
    }
}
