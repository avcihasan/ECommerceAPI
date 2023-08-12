using AutoMapper;
using Azure.Core;
using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
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
        readonly IRepositoryManager _repositoryManager;
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        readonly IQRCodeService _qRCodeService;
        readonly IProductObserverSubject _productObserverSubject;
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper, IQRCodeService qRCodeService, UserManager<AppUser> userManager, IProductObserverSubject productObserverSubject)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _qRCodeService = qRCodeService;
            _userManager = userManager;
            _productObserverSubject = productObserverSubject;
        }

        public async Task<bool> CreateProductAsync(CreateProductDto product)
        {
            bool result = await _repositoryManager.ProductWriteRepository.AddAsync(_mapper.Map<Product>(product));
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }

        public async Task<(List<GetProductDto> products, int count)> GetAllProductsAsync(int page, int size)
        {
            IQueryable<Product> products = _repositoryManager.ProductReadRepository.GetAllProductsAllProperties(false);
            return (_mapper.Map<List<GetProductDto>>(await products.Skip(page * size).Take(size).ToListAsync()), products.Count());
        }
        public async Task<GetProductDto> GetroductByIdAsync(string id)
        => _mapper.Map<GetProductDto>(await _repositoryManager.ProductReadRepository.GetByIdProductAllPropertiesAsync(id));


        public async Task ProductAddToCategoryAsync(string productId, string categoryId)
        {
            await _repositoryManager.ProductWriteRepository.AddCategoryByProductId(productId, categoryId);
            await _repositoryManager.SaveAsync();
        }

        public async Task ProductAddToFavoritesAsync(string productId, string userId)
        {
           (await _userManager.FindByIdAsync(userId)).FavProducts.Add(new() { ProductId = Guid.Parse(productId), UserId = Guid.Parse(userId) });
            await _repositoryManager.SaveAsync();
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _repositoryManager.ProductReadRepository.GetByIdAsync(productId);
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
            bool result = await _repositoryManager.ProductWriteRepository.RemoveByIdAsync(id);
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _repositoryManager.ProductReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Quantity = stock;
            await _repositoryManager.SaveAsync();
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto product)
        {
            bool result = _repositoryManager.ProductWriteRepository.Update(_mapper.Map<Product>(product));
            if (result)
                await _repositoryManager.SaveAsync();
            return result;
        }

        public async Task UpdateProductPriceAsync(string productId, decimal newPrice)
        {
            Product product = await _repositoryManager.ProductReadRepository.GetByIdProductAllPropertiesAsync(productId);
            var oldPrice = product.Price;
            product.Price = newPrice;
            await _repositoryManager.SaveAsync();
            _productObserverSubject.NotifyObserver(_mapper.Map<GetProductDto>(product),oldPrice);
        }
    }
}
