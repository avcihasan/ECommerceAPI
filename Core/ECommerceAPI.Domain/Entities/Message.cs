using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
