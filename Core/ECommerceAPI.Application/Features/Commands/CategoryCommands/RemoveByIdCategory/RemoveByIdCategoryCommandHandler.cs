using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.CategoryCommands.RemoveByIdCategory
{
    public class RemoveByIdCategoryCommandHandler : IRequestHandler<RemoveByIdCategoryCommandRequest, RemoveByIdCategoryCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        public RemoveByIdCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<RemoveByIdCategoryCommandResponse> Handle(RemoveByIdCategoryCommandRequest request, CancellationToken cancellationToken)
        {
             await _serviceManager.CategoryService.RemoveCategoryByIdAsync(request.Id);
            return new();
        }
    }
}
