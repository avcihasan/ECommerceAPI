using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.BasketQueries.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
    {
        readonly IServiceManager _serviceManager;

        public GetBasketItemsQueryHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {

            List<BasketItem> baketItems = await _serviceManager.BasketService.GetBasketItemsAsync();

            return baketItems.Select(x => new GetBasketItemsQueryResponse
            {
                BasketItemId = x.Id.ToString(),
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity
            }).ToList();
        }
    }
}
