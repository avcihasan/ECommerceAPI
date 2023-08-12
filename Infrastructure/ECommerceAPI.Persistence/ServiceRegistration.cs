using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.Repositories.BasketItemRepositories;
using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Application.Repositories.ControllerRepositories;
using ECommerceAPI.Application.Repositories.EndpointRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.MessageRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.BasketItemRepository;
using ECommerceAPI.Persistence.Repositories.BasketRepository;
using ECommerceAPI.Persistence.Repositories.CategoryRepositories;
using ECommerceAPI.Persistence.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Persistence.Repositories.ControllerRepositories;
using ECommerceAPI.Persistence.Repositories.EndpointRepositories;
using ECommerceAPI.Persistence.Repositories.FileRepositories;
using ECommerceAPI.Persistence.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Persistence.Repositories.MessageRepositories;
using ECommerceAPI.Persistence.Repositories.OrderRepositories;
using ECommerceAPI.Persistence.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;
using ECommerceAPI.Persistence.Services;
using ECommerceAPI.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ECommerceAPIDbContext>()
            .AddDefaultTokenProviders().AddDefaultTokenProviders(); ;

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,//oluşturulacak token değerini kimlerin/hangi originlerin/sitelerin kullanıcı belirlediğimiz değerdir => www.bilmemne.com
                        ValidateIssuer = true,//oluşturulacak token değerini kimin dağıttını ifade eden alan => www.myapi.com
                        ValidateLifetime = true, //oluşturulan token değerinin süresini kontrol edecek olan doğrulamadır
                        ValidateIssuerSigningKey = true,//üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden suciry key verisinin doğrulanmasısıdr

                        ValidAudience = configuration["Token:Audience"],
                        ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SigninKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow,

                        NameClaimType = ClaimTypes.Name
                    };
                });



            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IBasketService, BasketService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IMessageService, MessageService>();

            service.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            service.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            service.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            service.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            service.AddScoped<IFileReadRepository, FileReadRepository>();
            service.AddScoped<IFileWriteRepository, FileWriteRepository>();
            service.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            service.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            service.AddScoped<IProductReadRepository,ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            service.AddScoped<IBasketReadRepository, BasketReadRepository>();
            service.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            service.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            service.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            service.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
            service.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
            service.AddScoped<IControllerReadRepository, ControllerReadRepository>();
            service.AddScoped<IControllerWriteRepository, ControllerWriteRepository>();
            service.AddScoped<IMessageReadRepository, MessageReadRepository>();
            service.AddScoped<IMessageWriteRepository, MessageWriteRepository>();

            service.AddScoped<IRepositoryManager, RepositoryManager>();
            service.AddScoped<IServiceManager, ServiceManager>();

        }
    }
}
