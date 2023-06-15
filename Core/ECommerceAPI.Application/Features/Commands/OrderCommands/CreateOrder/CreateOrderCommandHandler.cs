using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public CreateOrderCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
           await _serviceManager.OrderService.CreateOrderAsync(new()
            {
                Address = request.Address,
                Description = request.Description,
                BasketId = _serviceManager.BasketService.GetUserActiveBasket.Id.ToString()

            });
            await _serviceManager.OrderHubService.OrderAddedMessageAsync("Yeni bir sipariş var ...");
            return new();
        }
    }
}
