using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.ConfigurationDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IConfigurationService _configurationService;
        readonly RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(IUnitOfWork unitOfWork, IConfigurationService configurationService, RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _configurationService = configurationService;
            _roleManager = roleManager;
        }

        public async Task AssignRoleEndpointAsync(string[] roles, string controllerName, string code, Type type)
        {
            Controller controller = await _unitOfWork.ControllerReadRepository.GetAsync(x => x.Name == controllerName);
            if (controller is null)
            {
                controller = new () {Name = controllerName };
                await _unitOfWork.ControllerWriteRepository.AddAsync(controller);
                await _unitOfWork.SaveAsync();
            }
            Endpoint endpoint = await _unitOfWork.EndpointReadRepository.Table.Include(x => x.Roles).Include(x => x.Controller).FirstOrDefaultAsync(x => x.Code == code && x.Controller == controller);

            if (endpoint == null)
            {
                EndPointDto _endpoint = _configurationService.GetAuthorizeDefinitionEndpoints(type)
                        .FirstOrDefault(m => m.Name == controllerName)
                        .EndPoints.FirstOrDefault(e => e.Code == code);

                endpoint = new()
                {
                    Code = _endpoint.Code,
                    ActionType = _endpoint.ActionType,
                    HttpType = _endpoint.HttpType,
                    Definition = _endpoint.Definition,
                    Id = Guid.NewGuid(),
                    Controller = controller
                };

                await _unitOfWork.EndpointWriteRepository.AddAsync(endpoint);
                await _unitOfWork.SaveAsync();
            }

            foreach (var role in endpoint.Roles)
                endpoint.Roles.Remove(role);

            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

            foreach (var role in appRoles)
                endpoint.Roles.Add(role);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<string>> GetRolesToEndpointAsync(string code, string controller)
        {
            Endpoint endpoint = await _unitOfWork.EndpointReadRepository.Table.Include(x => x.Roles).Include(x => x.Controller).FirstOrDefaultAsync(x => x.Code == code && x.Controller.Name == controller);
            if (endpoint != null)
                return endpoint.Roles.Select(r => r.Name).ToList();
            return null;
        }
    }
}
