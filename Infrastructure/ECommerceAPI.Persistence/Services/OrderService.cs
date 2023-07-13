using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using ECommerceAPI.Application.DTOs.OrderDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly IBasketService _basketService;

        public OrderService(IRepositoryManager repositoryManager, IBasketService basketService)
        {
            _repositoryManager = repositoryManager;
            _basketService = basketService;
        }



        public async Task CreateOrderAsync(CreateOrderDto order)
        {
            await _repositoryManager.OrderWriteRepository.AddAsync(new()
            {
                Address = order.Address,
                Description = order.Description,
                Id = Guid.Parse(order.BasketId),
                TotalPrice = await _basketService.GetBasketTotalPrice(order.BasketId),
                OrderCode = GenerateOrderCode()
            }); ; ;
            await _repositoryManager.SaveAsync();
        }

        public async Task<GetAllOrdersDto> GetAllOrdersAsync(int page, int size)
        {
            var query = _repositoryManager.OrderReadRepository.Table
                 .Include(x => x.Basket)
                     .ThenInclude(x => x.User)
                 .Include(x => x.Basket)
                     .ThenInclude(x => x.BasketItems)
                         .ThenInclude(x => x.Product);

            var data = query.Skip(page * size).Take(size);


            var data2 = from order in data
                        join completedOrder in _repositoryManager.CompletedOrderReadRepository.Table
                           on order.Id equals completedOrder.Id into co
                        from _co in co.DefaultIfEmpty()
                        select new
                        {
                            Id = order.Id,
                            CreatedDate = order.CreatedDate,
                            OrderCode = order.OrderCode,
                            Basket = order.Basket,
                            TotalPrice = order.TotalPrice,
                            Completed = _co != null ? true : false
                        };


            return new()
            {
                Orders = await data2.Select(x => new GetOrderDto()
                {
                    Id = x.Id.ToString(),
                    CreatedDate = x.CreatedDate,
                    OrderCode = x.OrderCode,
                    TotalPrice = x.TotalPrice,
                    UserName = x.Basket.User.UserName,
                    Completed = x.Completed
                }).ToListAsync(),
                TotalOrderCount = await query.CountAsync()
            };
        }

        public async Task<GetSingleOrderDto> GetOrderByIdAsync(string id)
        {
            IQueryable<Order> data = _repositoryManager.OrderReadRepository.Table
                  .Include(x => x.Basket)
                      .ThenInclude(x => x.BasketItems)
                          .ThenInclude(x => x.Product);

            return await (from order in data
                          join completedOrder in _repositoryManager.CompletedOrderReadRepository.Table
                               on order.Id equals completedOrder.Id into co
                          from _co in co.DefaultIfEmpty()
                          select new GetSingleOrderDto()
                          {
                              Id = order.Id.ToString(),
                              CreatedDate = order.CreatedDate,
                              OrderCode = order.OrderCode,
                              Completed = _co != null ? true : false,
                              Address = order.Address,
                              Description = order.Description,
                              TotalPrice = order.TotalPrice,
                              BasketItems = order.Basket.BasketItems.Select(x => new GetBasketItemsDto()
                              {
                                  ProductName = x.Product.Name,
                                  Quantity = x.Quantity,
                                  Price = x.Product.Price
                              }).ToList()

                          }).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<CompletedOrderDto> CompleteOrderAsync(string id)
        {
            CompletedOrderDto dto = new();
            Order order = await _repositoryManager.OrderReadRepository.Table.Include(x=>x.Basket).ThenInclude(x=>x.User).FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
            if (order is not null)
            {
                dto.OrderCode = order.OrderCode;
                dto.OrderDate = order.CreatedDate;
                dto.UserName = order.Basket.User.Name;
                dto.UserSurname = order.Basket.User.Surname;
                dto.Email = order.Basket.User.Email;

                bool result = await _repositoryManager.CompletedOrderWriteRepository.AddAsync(new() { Id = Guid.Parse(id) });
                if (result)
                {
                    await _repositoryManager.SaveAsync();
                    dto.IsCompleted = true;
                    return dto;
                }
            }
            dto.IsCompleted = false;
            return dto;
        }
        private string GenerateOrderCode()
            => $"HSN-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}";



    }
}
