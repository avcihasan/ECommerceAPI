using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Hubs
{
    public interface IProductHubServcie
    {
        Task ProductAddedMessageAsync(string message);
    }
}
