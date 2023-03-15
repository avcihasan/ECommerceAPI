using AutoMapper;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public  async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Product> productList = _unitOfWork.ProductReadRepository.GetAllProductsAllProperties(false);
            int count = productList.Count();
            ;
            List<GetProductDto> products = _mapper.Map<List<GetProductDto>>(productList.Skip(request.Page * request.Size).Take(request.Size).ToList());
            
            GetAllProductsQueryResponse response = new() { Products = products, TotalCount = count };

            await Task.Delay(1);
            return  response; 

        }
    }
}
