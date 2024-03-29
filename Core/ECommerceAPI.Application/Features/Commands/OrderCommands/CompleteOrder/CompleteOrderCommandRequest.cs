﻿using MediatR;

namespace ECommerceAPI.Application.Features.Commands.OrderCommands.CompleteOrder
{
    public class CompleteOrderCommandRequest:IRequest<CompleteOrderCommandResponse>
    {
        public string Id { get; set; }
    }
}