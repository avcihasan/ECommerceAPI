using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Token;
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
using ECommerceAPI.Persistence.Services;
using ECommerceAPI.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<ECommerceAPIDbContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ECommerceAPIDbContext>()
            .AddDefaultTokenProviders().AddDefaultTokenProviders(); ;
           


            service.AddScoped<IAuthService,AuthService>();
            service.AddScoped<IUserService,UserService>();
            service.AddScoped<IBasketService, BasketService>();
            service.AddScoped<IOrderService, OrderService>(); 
            service.AddScoped<IRoleService, RoleService>(); 
            service.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            service.AddScoped<IProductService, ProductService>();


            service.AddScoped<IRepositoryManager, RepositoryManager>();
            service.AddScoped<IServiceManager, ServiceManager>();

        }
    }
}
