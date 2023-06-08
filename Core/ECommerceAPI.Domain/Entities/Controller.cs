using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Controller:BaseEntity
    {
        public Controller()
        {
            Endpoints = new HashSet<Endpoint>();
        }
        public string Name { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
