using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.BasketCommands.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        readonly IMapper _mapper;
        public AddItemToBasketCommandHandler(IMapper mapper, IServiceManager serviceManager)
        {

            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {

           await _serviceManager.BasketService.AddItemToBasketAsync(_mapper.Map<CreateBasketItemDto>(request));


            return new();
        }
    }
}
