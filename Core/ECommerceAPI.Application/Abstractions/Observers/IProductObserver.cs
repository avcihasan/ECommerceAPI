using ECommerceAPI.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Observers
{
    public interface IProductObserver
    {
        Task ChangeProductPrice(GetProductDto productDto,decimal oldPrice);
    }
}
