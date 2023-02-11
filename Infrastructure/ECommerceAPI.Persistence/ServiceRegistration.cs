using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.CategoryRepositories;
using ECommerceAPI.Persistence.Repositories.FileRepositories;
using ECommerceAPI.Persistence.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Persistence.Repositories.ProductImageFileRepositories;
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
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ECommerceAPIDbContext>();
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            service.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            service.AddScoped<IFileReadRepository, FileReadRepository>();
            service.AddScoped<IFileWriteRepository, FileWriteRepository>();

            service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            service.AddScoped<IInvoiceFileReadRepository,InvoiceFileReadRepository>();
            service.AddScoped<IInvoiceFileWriteRepository,InvoiceFileWriteRepository>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
