using ECommerceAPI.Application.Features.Queries.ProductImageFileQueries.GetProductImages;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.ProductDTOs
{
    public class GetProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool Sale { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<GetProductImagesQueryResponse> ProductImageFiles { get; set; }
    }
}
