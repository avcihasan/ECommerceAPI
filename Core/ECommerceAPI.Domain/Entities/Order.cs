using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public decimal TotalPrice { get; set; }
        public Basket Basket { get; set; }
        public CompletedOrder ComplatedOrder { get; set; }
    }
}
