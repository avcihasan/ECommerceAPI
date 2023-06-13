using AutoMapper;
using Azure.Core;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IQRCodeService qRCodeService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _qRCodeService = qRCodeService;
            _mapper = mapper;
        }

        public async Task<bool> CreateProductAsync(CreateProductDto product)
        {
          bool result = await _unitOfWork.ProductWriteRepository.AddAsync(_mapper.Map<Product>(product));
            if (result)
                await   _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<(List<GetProductDto> products, int count)> GetAllProductsAsync(int page, int size)
        {
            IQueryable<Product> products =  _unitOfWork.ProductReadRepository.GetAllProductsAllProperties(false);
            return (_mapper.Map<List<GetProductDto>>(await products.Skip(page * size).Take(size).ToListAsync()), products.Count());
        }
        public async Task<GetProductDto> GetroductByIdAsync(string id)
        => _mapper.Map<GetProductDto>(await _unitOfWork.ProductReadRepository.GetByIdProductAllPropertiesAsync(id));
            

        public async Task ProductAddToCategoryAsync(string productId, string categoryId)
        {
            await _unitOfWork.ProductWriteRepository.AddCategoryByProductId(productId,categoryId);
            await _unitOfWork.SaveAsync();
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

        public async Task<bool> RemoveProductByIdAsync(string id)
        {
           bool result = await _unitOfWork.ProductWriteRepository.RemoveByIdAsync(id);
            if (result)
                await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _unitOfWork.ProductReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Quantity = stock;
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto product)
        {
             bool result = _unitOfWork.ProductWriteRepository.Update(_mapper.Map<Product>(product));
            if (result)
                await _unitOfWork.SaveAsync();
            return result;
        }
    }
}
