using ECommerceAPI.Application.DTOs.OrderDTOs;

namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public List<GetOrderDto> Orders { get; set; }
        public int TotalOrderCount { get; set; }
    }
}