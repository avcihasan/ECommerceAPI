using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System.Linq;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFileQueries.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductImagesQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetByIdProductAllPropertiesAsync(request.Id);

            return product.ProductImageFiles.Select(x => new GetProductImagesQueryResponse
            {
                Path = Path.Combine("../../../assets/", x.Path),
                FileName = x.FileName,
                Id = x.Id
            }).ToList() ;
        }
    }
}
