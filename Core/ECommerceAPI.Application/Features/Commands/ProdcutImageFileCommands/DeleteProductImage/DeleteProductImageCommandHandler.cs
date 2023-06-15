using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ECommerceAPI.Application.Features.Commands.ProdcutImageFileCommands.DeleteProductImage
{
    internal class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        private readonly IRepositoryManager _unitOfWork;

        public DeleteProductImageCommandHandler(IRepositoryManager unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _unitOfWork.ProductReadRepository.GetByIdProductAllPropertiesAsync(request.Id);
            ProductImageFile file = product.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));
            product.ProductImageFiles.Remove(file);
            await _unitOfWork.SaveAsync();
            return new();
        }
    }
}
