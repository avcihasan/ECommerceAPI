using ECommerceAPI.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<(List<GetProductDto> products,int count)> GetAllProductsAsync(int page,int size);
        Task<GetProductDto> GetroductByIdAsync(string id);
        Task<bool> CreateProductAsync(CreateProductDto product);
        Task ProductAddToCategoryAsync(string productId, string categoryId);
        Task<bool> RemoveProductByIdAsync(string id);
        Task<bool> UpdateProductAsync(UpdateProductDto product);
        Task<byte[]> QrCodeToProductAsync(string productId);
        Task StockUpdateToProductAsync(string productId, int stock);
        Task UpdateProductPriceAsync(string productId, decimal newPrice);
        Task ProductAddToFavoritesAsync(string productId, string userId);
    }
}
