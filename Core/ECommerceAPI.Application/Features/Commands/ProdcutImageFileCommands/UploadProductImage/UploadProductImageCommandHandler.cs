using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProdcutImageFileCommands.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        private readonly IRepositoryManager _unitOfWork;

        public UploadProductImageCommandHandler(IRepositoryManager unitOfWork, IServiceManager serviceManager)
        {
            _unitOfWork = unitOfWork;
            _serviceManager = serviceManager;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var datas = await _serviceManager.StorageService.UploadAsync("resource/ProductImages", request.Files);

            Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(request.Id);

            await _unitOfWork.ProductImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _serviceManager.StorageService.StorageName,
                Products = new List<Product>() { product }

            }).ToList());
            await _unitOfWork.SaveAsync();

            return new();
        }
    }
}
