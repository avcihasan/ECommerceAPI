using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToCategory
{
    public class ProductAddToCategoryRequest:IRequest<ProductAddToCategoryResponse>
    {
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
    }
}
