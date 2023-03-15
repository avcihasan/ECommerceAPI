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
        private readonly IUnitOfWork _unitOfWork;

        public ProductAddToCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductAddToCategoryResponse> Handle(ProductAddToCategoryRequest request, CancellationToken cancellationToken)
        {
           await _unitOfWork.ProductWriteRepository.AddCategoryByProductId(request.ProductId, request.CategoryId);
           await _unitOfWork.SaveAsync();
           return new();
        }
    }
}
