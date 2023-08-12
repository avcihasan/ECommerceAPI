using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProductPrice
{
    public class UpdateProductPriceCommandHandler : IRequestHandler<UpdateProductPriceCommandRequest, UpdateProductPriceCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public UpdateProductPriceCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateProductPriceCommandResponse> Handle(UpdateProductPriceCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.UpdateProductPriceAsync(request.ProductId, request.NewPrice);
            return new();
        }
    }
}
