
using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Infrastructure.Observers;
using ECommerceAPI.Infrastructure.Services;
using ECommerceAPI.Infrastructure.Services.Storage;
using ECommerceAPI.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IStorageService, StorageService>();
            service.AddScoped<ITokenHandler, TokenHandler>();
            service.AddScoped<IMailService, MailService>();
            service.AddScoped<IConfigurationService, ConfigurationService>();
            service.AddScoped<IQRCodeService, QRCodeService>();

            service.AddSingleton<IProductObserverSubject>(sp =>
            {
                ProductObserverSubject productObserverSubject = new();
                productObserverSubject.AddObserver(new ProductObserverSendEmail(sp));
                productObserverSubject.AddObserver(new ProductObserverSendMessage(sp));
                productObserverSubject.AddObserver(new ProductObserverLogging(sp));
                return productObserverSubject;
            });

        }

        public static void AddStorage<T>(this IServiceCollection service) where T: Storage, IStorage
        {
            service.AddScoped<IStorage, T>(); 
        }
    }
}
