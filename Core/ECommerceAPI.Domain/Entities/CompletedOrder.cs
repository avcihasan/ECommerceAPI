using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class CompletedOrder:BaseEntity
    {
        public Order Order { get; set; }
        //public Guid OrderId { get; set; }
    }
}
