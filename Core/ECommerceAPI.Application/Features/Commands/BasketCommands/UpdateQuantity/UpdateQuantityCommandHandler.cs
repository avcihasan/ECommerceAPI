using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.BasketCommands.UpdateQuantity
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        readonly IBasketService _basketService;
        readonly IMapper _mapper;
        public UpdateQuantityCommandHandler(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
           await _basketService.UpdateQuantityAsync(_mapper.Map<UpdateBasketItemDto>(request));

            return new();
        }
    }
}
