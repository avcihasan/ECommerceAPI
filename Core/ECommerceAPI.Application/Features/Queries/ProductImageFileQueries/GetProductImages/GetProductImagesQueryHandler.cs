using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System.Linq;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFileQueries.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        readonly IServiceManager _serviceManager;

        public GetProductImagesQueryHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            GetProductDto product = await _serviceManager.ProductService.GetroductByIdAsync(request.Id);

            return product.ProductImageFiles.Select(x => new GetProductImagesQueryResponse
            {
                Path = Path.Combine("../../../assets/", x.Path),
                FileName = x.FileName,
                Id = x.Id
            }).ToList() ;
        }
    } 
}
