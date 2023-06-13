using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandHandler : IRequestHandler<RemoveByIdProductCommandRequest, RemoveByIdProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        readonly IProductService _productService;
        public RemoveByIdProductCommandHandler(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public async Task<RemoveByIdProductCommandResponse> Handle(RemoveByIdProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productService.RemoveProductByIdAsync(request.Id);
            return new();
        }
    }
}
