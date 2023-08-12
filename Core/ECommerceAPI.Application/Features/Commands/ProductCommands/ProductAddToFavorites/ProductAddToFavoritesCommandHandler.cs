using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToFavorites
{
    public class ProductAddToFavoritesCommandHandler : IRequestHandler<ProductAddToFavoritesCommandRequest, ProductAddToFavoritesCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public ProductAddToFavoritesCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<ProductAddToFavoritesCommandResponse> Handle(ProductAddToFavoritesCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.ProductAddToFavoritesAsync(request.ProductId, request.UserId);
            return new();
        }
    }
}
