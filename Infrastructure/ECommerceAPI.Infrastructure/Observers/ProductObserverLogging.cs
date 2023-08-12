using ECommerceAPI.Application.Abstractions.Observers;
using ECommerceAPI.Application.DTOs.ProductDTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ECommerceAPI.Infrastructure.Observers
{
    public class ProductObserverLogging : IProductObserver
    {
        readonly IServiceProvider _serviceProvider;

        public ProductObserverLogging(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task ChangeProductPrice(GetProductDto productDto, decimal oldPrice)
        {
            var scope = _serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<Serilog.ILogger>();
            logger.Warning($"{productDto.Name} ürünün yeni fiyatı {oldPrice} yerine {productDto.Price} oldu");

            return Task.CompletedTask;
        }
    }
}
