using AutoMapper;
using ECommerceAPI.Application.Abstractions.Hubs;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        readonly IProductHubServcie _hubService;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductHubServcie hubService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hubService = hubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductWriteRepository.AddAsync(_mapper.Map<Product>(request));
            await _unitOfWork.SaveAsync();
            await _hubService.ProductAddedMessageAsync($"{request.Name} isimli ürün eklendi fiyatı {request.Price}.");
            return new();


        }
    }
}
