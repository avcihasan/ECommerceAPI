using MediatR;

namespace ECommerceAPI.Application.Features.Queries.AuthorizationEndpointQueries
{
    public class GetRolesToEndpointQueryRequest:IRequest<GetRolesToEndpointQueryResponse>
    {
        public string Code { get; set; }
        public string Controller { get; set; }
    }
}