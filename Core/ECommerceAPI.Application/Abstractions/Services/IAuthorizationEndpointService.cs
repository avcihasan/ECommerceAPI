﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IAuthorizationEndpointService
    {
        Task AssignRoleEndpointAsync(string[] roles, string controllerName, string code, Type type);
        public Task<List<string>> GetRolesToEndpointAsync(string code, string controller);
    }
}
