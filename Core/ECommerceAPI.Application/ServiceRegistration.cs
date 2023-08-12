using ECommerceAPI.Application.OptionsModels;
using ECommerceAPI.Application.Validatiors.ProductValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddMediatR(typeof(ServiceRegistration));
            service.AddAutoMapper(typeof(ServiceRegistration));

            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            service.AddValidatorsFromAssemblyContaining(typeof(CreateProductValidator));

            service.Configure<ConnectionStringsOptions>(configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
            service.Configure<MailOptions>(configuration.GetSection(MailOptions.Mail));
            service.Configure<TokenOptions>(configuration.GetSection(TokenOptions.Token));
            service.Configure<StorageOptions>(configuration.GetSection(StorageOptions.Storage));








        }
    }
}
