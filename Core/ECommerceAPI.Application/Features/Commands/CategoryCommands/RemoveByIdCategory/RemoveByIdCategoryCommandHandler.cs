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
        private readonly IUnitOfWork _unitOfWork;

        public RemoveByIdCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveByIdCategoryCommandResponse> Handle(RemoveByIdCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _unitOfWork.CategoryReadRepository.GetByIdAsync(request.Id.ToString());
            _unitOfWork.CategoryWriteRepository.Remove(category);
            await _unitOfWork.SaveAsync();
            return new();
        }
    }
}
