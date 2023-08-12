using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Observers
{
    public class ProductObserverSendEmail : IProductObserver
    {
        readonly IServiceProvider _serviceProvider;

        public ProductObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ChangeProductPrice(GetProductDto productDto, decimal oldPrice)
        {
            string mailBody = $"{productDto.Name} isimli ürünün fiyatı {oldPrice} yerine {productDto.Price} oldu!";
            var scope = _serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var serviceManager = scope.ServiceProvider.GetRequiredService<IServiceManager>();

            (await userManager.Users.ToListAsync()).ForEach(x => serviceManager.MailService.SendMailAsync(x.Email, "Ürün Fiyat Değişimi", mailBody));
        }
    }
}
