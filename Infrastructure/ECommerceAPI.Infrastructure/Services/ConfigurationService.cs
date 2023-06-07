using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.DTOs.ConfigurationDTOs;
using ECommerceAPI.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ECommerceAPI.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public List<ControllerDto> GetAuthorizeDefinitionEndpoints(Type type)
        {
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ControllerBase)));

            List<ControllerDto> controllerDtos = new();

            if (controllers is not null)
            {
                foreach (var controller in controllers)
                {
                    var endpoints = controller.GetMethods().Where(x => x.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                    if (endpoints is not null)
                    {
                        foreach (var endpoint in endpoints)
                        {
                            var attributes = endpoint.GetCustomAttributes(true);
                            if (attributes != null)
                            {
                                ControllerDto _controller = null;
                                var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                                if (!controllerDtos.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
                                {
                                    _controller = new() { Name = authorizeDefinitionAttribute.Menu };
                                    controllerDtos.Add(_controller);
                                }
                                else
                                    _controller = controllerDtos.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);
                                EndPointDto endPointDto = new()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                    Definition = authorizeDefinitionAttribute.Definition
                                };
                                var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;


                                if (httpAttribute != null)
                                    endPointDto.HttpType = httpAttribute.HttpMethods.First();
                                else
                                    endPointDto.HttpType = HttpMethods.Get;

                                endPointDto.Code = $"{endPointDto.HttpType}.{endPointDto.ActionType}.{endPointDto.Definition.Replace(" ", "")}";

                                _controller.EndPoints.Add(endPointDto);
                            }
                        }
                    }
                }
            }

            return controllerDtos;
        }
    }
}
