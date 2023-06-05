using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        Task<List<BasketItem>> GetBasketItemsAsync();
        Task AddItemToBasketAsync(CreateBasketItemDto basketItem);
        Task UpdateQuantityAsync(UpdateBasketItemDto basketItem);
        Task RemoveBasketItemAsync(string basketItemId);
        Task<decimal> GetBasketTotalPrice(string basketId);
        Basket GetUserActiveBasket { get; }
    }
}
