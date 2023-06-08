using MediatR;

namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryRequest:IRequest<GetAllUserQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}