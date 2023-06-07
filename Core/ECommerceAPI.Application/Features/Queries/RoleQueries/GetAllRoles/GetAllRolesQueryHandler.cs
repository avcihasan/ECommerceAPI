using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.RoleDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
           (List<RoleDto> roles, int totalCount) = await _roleService.GetRolesAsync(request.Page,request.Size);
            return new()
            {
                Datas = roles,
                TotalCount = totalCount
            };
        }
    }
}
