using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.UnitOfWorks
{
    public interface IServiceManager
    {
        IAuthorizationEndpointService AuthorizationEndpointService { get; }
        IAuthService AuthService { get; }
        IBasketService BasketService { get; }
        ICategoryService CategoryService { get; }
        IConfigurationService ConfigurationService { get; }
        IMailService MailService { get; }
        IOrderService OrderService { get; }
        IProductService ProductService { get; }
        IQRCodeService QRCodeService { get; }
        IRoleService RoleService { get; }
        IUserService UserService { get; }
        IOrderHubService OrderHubService { get; }
        IProductHubServcie ProductHubService { get; }
        ITokenHandler TokenHandler { get; }
        IStorageService StorageService { get; }
        IMessageService MessageService { get; }

    }
}
