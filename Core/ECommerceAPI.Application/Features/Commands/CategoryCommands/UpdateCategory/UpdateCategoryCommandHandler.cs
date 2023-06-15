using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.CategoryDTOs;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        readonly IServiceManager _serviceManager;
        public UpdateCategoryCommandHandler(IMapper mapper, IServiceManager serviceManager)
        {
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
             await _serviceManager.CategoryService.UpdateCategoryAsync(_mapper.Map<UpdateCategoryDto>(request));
            return new();
        }
    }
}
