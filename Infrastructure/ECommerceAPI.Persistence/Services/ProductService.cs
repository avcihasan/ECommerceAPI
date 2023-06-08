using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IQRCodeService _qRCodeService;
        public ProductService(IUnitOfWork unitOfWork, IQRCodeService qRCodeService)
        {
            _unitOfWork = unitOfWork;
            _qRCodeService = qRCodeService;
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Quantity,
                product.CreatedDate
            };
            string plainText = JsonSerializer.Serialize(plainObject);

            return _qRCodeService.GenerateQRCode(plainText);
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Quantity = stock;
            await _unitOfWork.SaveAsync();
        }
    }
}
