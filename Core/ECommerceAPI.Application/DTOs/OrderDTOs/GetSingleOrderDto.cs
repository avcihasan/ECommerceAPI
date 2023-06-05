using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.OrderDTOs
{
    public class GetSingleOrderDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal  TotalPrice{ get; set; }
        public List<GetBasketItemsDto> BasketItems { get; set; }
    }
}

