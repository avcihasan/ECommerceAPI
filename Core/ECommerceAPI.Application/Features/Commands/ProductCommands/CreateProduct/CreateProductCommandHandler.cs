using AutoMapper;
using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        readonly IServiceManager _serviceManager;
        public CreateProductCommandHandler(IMapper mapper, IServiceManager serviceManager)
        {
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.CreateProductAsync(_mapper.Map<CreateProductDto>(request));
            await _serviceManager.ProductHubService.ProductAddedMessageAsync($"{request.Name} isimli ürün eklendi fiyatı {request.Price}.");
            return new();
        }
    }
}
