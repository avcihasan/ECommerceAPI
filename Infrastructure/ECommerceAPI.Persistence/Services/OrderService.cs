using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.OrderDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrderAsync(CreateOrderDto order)
        {
           await _unitOfWork.OrderWriteRepository.AddAsync(new()
            {
                Address=order.Address,
                Description=order.Description,
                Id= Guid.Parse(order.BasketId),
            });
            await _unitOfWork.SaveAsync();
        }
    }
}
