﻿using ECommerceAPI.Application.DTOs.ConfigurationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IConfigurationService
    {
        List<ControllerDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
