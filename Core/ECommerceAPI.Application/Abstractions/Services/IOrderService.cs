using ECommerceAPI.Application.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto order);
        Task<GetAllOrdersDto> GetAllOrdersAsync(int page, int size);
        Task<GetSingleOrderDto> GetOrderByIdAsync(string id);
        Task<CompletedOrderDto> CompleteOrderAsync(string id);
    }
}
