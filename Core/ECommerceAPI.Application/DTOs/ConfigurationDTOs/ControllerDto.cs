using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.ConfigurationDTOs
{
    public class ControllerDto
    {
        public ControllerDto()
        {
            EndPoints = new List<EndPointDto>();
        }
        public string Name { get; set; }
        public List<EndPointDto> EndPoints { get; set; }
    }
}
