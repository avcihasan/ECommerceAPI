using AutoMapper;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetByIdProductHandler(IProductReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product p =await _readRepository.GetByIdProductAllPropertiesAsync(request.Id);
          
            return _mapper.Map<GetByIdProductQueryResponse>(p);
        }
    }
}
