using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.MessageDTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
