﻿using AutoMapper;
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

        public CreateProductCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProductWriteRepository.AddAsync(_mapper.Map<Product>(request));
            await _unitOfWork.SaveAsync();
            return new();


        }
    }
}
