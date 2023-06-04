using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.BasketItemDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IUnitOfWork _unitOfWork;
        readonly UserManager<AppUser> _userManager;
       
        public Basket GetUserActiveBasket => GetBasketAsync().Result;

        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        private async Task<Basket> GetBasketAsync()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
                throw new Exception("Beklenmeyen bir hata oluştu");

            AppUser user = await _userManager.Users
                .Include(x => x.Baskets).ThenInclude(x => x.Order)
                .Include(x => x.Baskets).ThenInclude(x => x.BasketItems).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserName == userName);

            Basket targetBasket = null;

            if (user.Baskets.Any(b => b.Order is null))
                targetBasket = user.Baskets.FirstOrDefault(b => b.Order is null);
            else
            {
                targetBasket = new();
                user.Baskets.Add(targetBasket);
            }
            await _unitOfWork.SaveAsync();
            return targetBasket;
        }

        private void NullCheckException<T>(T entity)
        {
            if (entity == null)
                throw new Exception("Beklenmeyen bir hata oluştu");
        }


        public async Task AddItemToBasketAsync(CreateBasketItemDto basketItem)
        {
            Basket basket = await GetBasketAsync();
            NullCheckException(basket);

            BasketItem _basketItem = await _unitOfWork.BasketItemReadRepository.GetAsync(x => x.BasketId == basket.Id && x.ProductId == Guid.Parse(basketItem.ProductId));
            if (_basketItem is not null)
                _basketItem.Quantity++;
            else
                basket.BasketItems.Add(new()
                { BasketId = basket.Id, 
                    ProductId = Guid.Parse(basketItem.ProductId), 
                    Quantity = basketItem.Quantity 
                });
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket basket = await GetBasketAsync();
            return basket.BasketItems.ToList();
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem basketItem = await _unitOfWork.BasketItemReadRepository.GetByIdAsync(basketItemId);

            NullCheckException(basketItem);
            //if (basketItem == null)
            //    throw new Exception("Beklenmeyen bir hata oluştu");

            _unitOfWork.BasketItemWriteRepository.Remove(basketItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateQuantityAsync(UpdateBasketItemDto basketItem)
        {
            BasketItem _basketItem = await _unitOfWork.BasketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);

            NullCheckException(_basketItem);

            //if (_basketItem == null)
            //    throw new Exception("Beklenmeyen bir hata oluştu");

            _basketItem.Quantity = basketItem.Quantity;
            await _unitOfWork.SaveAsync();
        }
    }
}
