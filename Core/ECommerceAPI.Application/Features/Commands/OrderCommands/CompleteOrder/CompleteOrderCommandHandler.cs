using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.OrderDTOs;
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
        readonly IOrderService _orderService;
        readonly IMailService _mailService;

        public CompleteOrderCommandHandler(IOrderService orderService, IMailService mailService)
        {
            _orderService = orderService;
            _mailService = mailService;
        }

        public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
          CompletedOrderDto dto= await _orderService.CompleteOrderAsync(request.Id);
            if (dto.IsCompleted)
                await _mailService.SendCompletedOrderMailAsync(dto.Email,dto.OrderCode,dto.OrderDate,dto.UserName,dto.UserSurname);



            return new();
        }
    }
}
