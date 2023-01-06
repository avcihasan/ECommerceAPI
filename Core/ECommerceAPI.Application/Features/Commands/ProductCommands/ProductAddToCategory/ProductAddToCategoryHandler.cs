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
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductAddToCategoryHandler(IProductWriteRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductAddToCategoryResponse> Handle(ProductAddToCategoryRequest request, CancellationToken cancellationToken)
        {
           await _productWriteRepository.AddCategoryByProductId(request.ProductId, request.CategoryId);
           await _unitOfWork.SaveAsync();
           return new();
        }
    }
}
