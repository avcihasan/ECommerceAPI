using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateStockQrCodeToProduct
{
    public class UpdateStockQrCodeToProductCommandHandler:IRequestHandler<UpdateStockQrCodeToProductCommandRequest, UpdateStockQrCodeToProductCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public UpdateStockQrCodeToProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateStockQrCodeToProductCommandResponse> Handle(UpdateStockQrCodeToProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.StockUpdateToProductAsync(request.ProductId, request.Stock);
            return new();
        }
    }
}
