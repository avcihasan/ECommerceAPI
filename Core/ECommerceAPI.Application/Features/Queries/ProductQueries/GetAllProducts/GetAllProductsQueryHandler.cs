using AutoMapper;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest,List<GetAllProductsQueryResponse>>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public  async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> productList =await _readRepository.GetAllProductsAllPropertiesAsync(false) ;

            var products = _mapper.Map<List<GetAllProductsQueryResponse>>(productList);

            return products; 

        }
    }
}
