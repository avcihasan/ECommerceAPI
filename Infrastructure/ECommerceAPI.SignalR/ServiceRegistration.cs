﻿using ECommerceAPI.Application.Abstractions.Hubs;
using ECommerceAPI.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection service)
        {
            service.AddTransient<IProductHubServcie, ProductHubService>();
            service.AddTransient<IOrderHubService, OrderHubService>();
            service.AddSignalR();
        }
    }
}
