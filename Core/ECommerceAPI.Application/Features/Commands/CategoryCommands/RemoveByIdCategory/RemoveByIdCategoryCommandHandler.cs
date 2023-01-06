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
        private readonly ICategoryWriteRepository _writeRepo;
        private readonly ICategoryReadRepository _readRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveByIdCategoryCommandHandler(ICategoryWriteRepository writeRepo, IUnitOfWork unitOfWork, ICategoryReadRepository readRepo)
        {
            _writeRepo = writeRepo;
            _unitOfWork = unitOfWork;
            _readRepo = readRepo;
        }

        public async Task<RemoveByIdCategoryCommandResponse> Handle(RemoveByIdCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _readRepo.GetByIdAsync(request.Id.ToString());
            _writeRepo.Remove(category);
            await _unitOfWork.SaveAsync();
            return new();
        }
    }
}
