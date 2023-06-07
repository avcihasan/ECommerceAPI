using MediatR;

namespace ECommerceAPI.Application.Features.Queries.RoleQueries.GetByIdRole
{
    public class GetByIdRoleQueryRequest:IRequest<GetByIdRoleQueryResponse>
    {
        public string Id { get; set; }
    }
}