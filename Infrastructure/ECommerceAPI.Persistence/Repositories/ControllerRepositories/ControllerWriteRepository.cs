using ECommerceAPI.Application.Repositories.ControllerRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories.ControllerRepositories
{
    public class ControllerWriteRepository : WriteRepository<Controller>, IControllerWriteRepository
    {
        public ControllerWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
