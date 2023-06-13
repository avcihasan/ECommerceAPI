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
        readonly ICategoryService _categoryService;
        public RemoveByIdCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<RemoveByIdCategoryCommandResponse> Handle(RemoveByIdCategoryCommandRequest request, CancellationToken cancellationToken)
        {
             await  _categoryService.RemoveCategoryByIdAsync(request.Id);
            return new();
        }
    }
}
