using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.CategoryRepositories;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;
using ECommerceAPI.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<ECommerceAPIDbContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
