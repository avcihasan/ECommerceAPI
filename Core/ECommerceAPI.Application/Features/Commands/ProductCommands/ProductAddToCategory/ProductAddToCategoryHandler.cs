using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToCategory
{
    public class ProductAddToCategoryHandler : IRequestHandler<ProductAddToCategoryRequest, ProductAddToCategoryResponse>
    {
        readonly IServiceManager _serviceManager;

        public ProductAddToCategoryHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<ProductAddToCategoryResponse> Handle(ProductAddToCategoryRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.ProductAddToCategoryAsync(request.ProductId, request.CategoryId);
           return new();
        }
    }
}
