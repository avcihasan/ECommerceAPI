using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public List<GetProductDto> Products { get; set; } 
        public int TotalCount { get; set; } 

    }
    
}
