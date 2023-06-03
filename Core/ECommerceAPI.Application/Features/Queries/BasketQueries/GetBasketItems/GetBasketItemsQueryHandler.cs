using ECommerceAPI.Application.Abstractions.Services;
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
        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {

            List<BasketItem> baketItems = await _basketService.GetBasketItemsAsync();

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
