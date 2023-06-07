using ECommerceAPI.Application.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string name);
        Task UpdateRoleAsync(string id,string name);
        Task DeleteRoleAsync(string id);
        Task<RoleDto> GetRoleByIdAsync(string id);
        Task<(List<RoleDto>,int)> GetRolesAsync(int page,int size);
    }
}
