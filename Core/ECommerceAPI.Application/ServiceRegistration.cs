using ECommerceAPI.Application.Validatiors.ProductValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service)
        {
            service.AddMediatR(typeof(ServiceRegistration));
            service.AddAutoMapper(typeof(ServiceRegistration));

           

            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            service.AddValidatorsFromAssemblyContaining(typeof(CreateProductValidator));
        }
    }
}
