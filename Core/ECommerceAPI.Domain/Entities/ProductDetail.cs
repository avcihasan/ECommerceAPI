using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class ProductDetail
    {
        public Guid Id { get; set; }

        public string Color { get; set; }
        public float Weight { get; set; }

        public Product Product { get; set; }

    }
}
