using ECommerceAPI.Application.DTOs.RoleDTOs;

namespace ECommerceAPI.Application.Features.Queries.RoleQueries.GetAllRoles
{
    public class GetAllRolesQueryResponse
    {
        public List<RoleDto> Datas { get; set; }
        public int TotalCount { get; set; }
    }
}