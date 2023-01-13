using AutoMapper;
using ECommerceAPI.Application.DTOs.ProductDTOs;
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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest,GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public  async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Product> productList = _readRepository.GetAllProductsAllProperties(false);
            int count = productList.Count();
            ;
            List<GetProductDto> products = _mapper.Map<List<GetProductDto>>(productList.Skip(request.Page * request.Size).Take(request.Size).ToList());
            
            GetAllProductsQueryResponse response = new() { Products = products, TotalCount = count };

            await Task.Delay(1);
            return  response; 

        }
    }
}
