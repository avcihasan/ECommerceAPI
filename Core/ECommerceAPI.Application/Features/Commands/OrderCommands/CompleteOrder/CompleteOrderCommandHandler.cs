using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.OrderDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.OrderCommands.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
    {
        readonly IServiceManager _serviceManager;

        public CompleteOrderCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
          CompletedOrderDto dto= await _serviceManager.OrderService.CompleteOrderAsync(request.Id);
            if (dto.IsCompleted)
                await _serviceManager.MailService.SendCompletedOrderMailAsync(dto.Email,dto.OrderCode,dto.OrderDate,dto.UserName,dto.UserSurname);



            return new();
        }
    }
}
