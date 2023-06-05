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
        readonly IUnitOfWork _unitOfWork;
        readonly IBasketService _basketService;
        readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IBasketService basketService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto order)
        {
            await _unitOfWork.OrderWriteRepository.AddAsync(new()
            {
                Address = order.Address,
                Description = order.Description,
                Id = Guid.Parse(order.BasketId),
                TotalPrice = await _basketService.GetBasketTotalPrice(order.BasketId),
                OrderCode = GenerateOrderCode()
            }); ;;
            await _unitOfWork.SaveAsync();
        }

        public async Task<GetAllOrdersDto> GetAllOrdersAsync(int page, int size)
        {
           var query= _unitOfWork.OrderReadRepository.Table
                .Include(x => x.Basket)
                    .ThenInclude(x => x.User)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.BasketItems)
                        .ThenInclude(x => x.Product);

            var data = query.Skip(page * size).Take(size);

            return new()
            {
                Orders = await data.Select(x => new GetOrderDto()
                {
                    Id=x.Id.ToString(),
                    CreatedDate = x.CreatedDate,
                    OrderCode = x.OrderCode,
                    TotalPrice = x.TotalPrice,
                    UserName = x.Basket.User.UserName
                }).ToListAsync(),
                TotalOrderCount = await data.CountAsync()
            };
        }

        public async Task<GetSingleOrderDto> GetOrderByIdAsync(string id)
        {
          Order data =  await _unitOfWork.OrderReadRepository.Table
                .Include(x => x.Basket)
                    .ThenInclude(x => x.BasketItems)
                        .ThenInclude(x => x.Product).FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
            GetSingleOrderDto orderDto = _mapper.Map<GetSingleOrderDto>(data);
            orderDto.BasketItems = data.Basket.BasketItems.Select(x => new GetBasketItemsDto()
            {
                ProductName = x.Product.Name,
                Quantity = x.Quantity,
                Price = x.Product.Price
            }).ToList();
            return orderDto;
        }


        private string GenerateOrderCode()
            => $"HSN-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}-{(new Random().NextDouble() * 1000000).ToString().Substring(0, 4)}";


          
    }
}
