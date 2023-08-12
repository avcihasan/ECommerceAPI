using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.RoleDTOs;
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
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task CreateRoleAsync(string name)
        {
            IdentityResult result= await  _roleManager.CreateAsync(new() { Id=Guid.NewGuid(),Name=name});
            if (!result.Succeeded)
                throw new Exception("Rol oluşturma hatası");
        }

        public async Task DeleteRoleAsync(string id)
        {
            IdentityResult result = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
            if (!result.Succeeded)
                throw new Exception("Rol silme hatası");
        }

        public async Task<RoleDto> GetRoleByIdAsync(string id)
        {
           AppRole role= await _roleManager.FindByIdAsync(id);
            return role is null ? throw new Exception("Rol hatası") : _mapper.Map<RoleDto>(role);
        }

        public async Task<(List<RoleDto>, int)> GetRolesAsync(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<AppRole> rolesQuery ;

            if (page != -1 && size != -1)
                rolesQuery = query.Skip(page * size).Take(size);
            else
                rolesQuery = query;

            return (_mapper.Map<List<RoleDto>>(await rolesQuery.ToListAsync()),await query.CountAsync()); ;
        }
           

        public async Task UpdateRoleAsync(string id, string name)
        {
            AppRole role =  await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                throw new Exception("Rol güncelleme hatası");

        }
    }
}
