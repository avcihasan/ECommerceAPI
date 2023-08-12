using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToFavorites
{
    public class ProductAddToFavoritesCommandRequest:IRequest<ProductAddToFavoritesCommandResponse>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
