using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandHandler : IRequestHandler<RemoveByIdProductCommandRequest, RemoveByIdProductCommandResponse>
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveByIdProductCommandHandler(IProductWriteRepository writeRepository, IUnitOfWork unitOfWork, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
            _readRepository = readRepository;
        }

        public async Task<RemoveByIdProductCommandResponse> Handle(RemoveByIdProductCommandRequest request, CancellationToken cancellationToken)
        {
         
            await _writeRepository.RemoveByIdAsync(request.Id);
           
            await _unitOfWork.SaveAsync();
            return new();
        }
    }
}
