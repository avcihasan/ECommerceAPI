using MediatR;

namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetByIdOrder
{
    public class GetByIdOrderQueryRequest:IRequest<GetByIdOrderQueryResponse>
    {
        public string Id { get; set; }
    }
}