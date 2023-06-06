using ECommerceAPI.Application.DTOs.BasketItemDTOs;

namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetByIdOrder
{
    public class GetByIdOrderQueryResponse
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Completed { get; set; }
        public List<GetBasketItemsDto> BasketItems { get; set; }
    }
}