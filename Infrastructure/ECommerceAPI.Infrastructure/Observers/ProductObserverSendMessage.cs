using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ECommerceAPI.Infrastructure.Observers
{
    public class ProductObserverSendMessage : IProductObserver
    {
        readonly IServiceProvider _serviceProvider;

        public ProductObserverSendMessage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ChangeProductPrice(GetProductDto productDto, decimal oldPrice)
        {
            var scope = _serviceProvider.CreateScope();
            var repositoryManager = scope.ServiceProvider.GetRequiredService<IRepositoryManager>();
            var serviceManager = scope.ServiceProvider.GetRequiredService<IServiceManager>();

           Product product =await repositoryManager.ProductReadRepository.GetByIdProductAllPropertiesAsync(productDto.Id.ToString());

            foreach (var item in product.FavUsers.ToList())
            {
                await serviceManager.MessageService.SendMessageAsync(new() { Subject = "Fiyat değişti", Body = $"{productDto.Name} ürünün yeni fiyatı {oldPrice} yerine {productDto.Price}", ToUserId = item.UserId });
            }
        }
    }
}
