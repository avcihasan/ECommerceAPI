using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Baskets = new HashSet<Basket>();
            Messages = new HashSet<Message>();
            FavProducts = new HashSet<FavoriteProduct>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<Basket> Baskets { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<FavoriteProduct> FavProducts { get; set; }
    }
}
