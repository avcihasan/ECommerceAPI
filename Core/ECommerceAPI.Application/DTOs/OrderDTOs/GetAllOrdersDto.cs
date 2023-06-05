using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.OrderDTOs
{
    public class GetAllOrdersDto
    {
        public List<GetOrderDto> Orders { get; set; }
        public int TotalOrderCount { get; set; }
    }
}
