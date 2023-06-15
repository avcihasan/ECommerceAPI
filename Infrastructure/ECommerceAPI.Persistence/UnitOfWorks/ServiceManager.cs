using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.UnitOfWorks
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(IAuthorizationEndpointService authorizationEndpointService, IAuthService authService, IBasketService basketService, ICategoryService categoryService, IConfigurationService configurationService, IMailService mailService, IOrderService orderService, IProductService productService, IQRCodeService qRCodeService, IRoleService roleService, IUserService userService, IOrderHubService orderHubService, IProductHubServcie productHubService, ITokenHandler tokenHandler, IStorageService storageService)
        {
            AuthorizationEndpointService = authorizationEndpointService;
            AuthService = authService;
            BasketService = basketService;
            CategoryService = categoryService;
            ConfigurationService = configurationService;
            MailService = mailService;
            OrderService = orderService;
            ProductService = productService;
            QRCodeService = qRCodeService;
            RoleService = roleService;
            UserService = userService;
            OrderHubService = orderHubService;
            ProductHubService = productHubService;
            TokenHandler = tokenHandler;
            StorageService = storageService;
        }

        public IAuthorizationEndpointService AuthorizationEndpointService { get; private set; }

        public IAuthService AuthService { get; private set; }

        public IBasketService BasketService { get; private set; }

        public ICategoryService CategoryService { get; private set; }

        public IConfigurationService ConfigurationService { get; private set; }

        public IMailService MailService { get; private set; }

        public IOrderService OrderService { get; private set; }

        public IProductService ProductService { get; private set; }

        public IQRCodeService QRCodeService { get; private set; }

        public IRoleService RoleService { get; private set; }

        public IUserService UserService { get; private set; }

        public IOrderHubService OrderHubService { get; private set; }

        public IProductHubServcie ProductHubService { get; private set; }
        public ITokenHandler TokenHandler { get; private set; }

        public IStorageService StorageService { get; private set; }
    }
}
