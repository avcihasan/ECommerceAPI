using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.MessageQueries.GetAllMessagesByUserId
{
    public class GetAllMessagesByUserIdResponse
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
