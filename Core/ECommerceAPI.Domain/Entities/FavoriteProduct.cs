using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class FavoriteProduct
    {
        public Guid UserId { get; set; }
        public AppUser User{ get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
