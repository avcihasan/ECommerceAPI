using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandHandler : IRequestHandler<RemoveByIdProductCommandRequest, RemoveByIdProductCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public RemoveByIdProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<RemoveByIdProductCommandResponse> Handle(RemoveByIdProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.RemoveProductByIdAsync(request.Id);
            return new();
        }
    }
}
