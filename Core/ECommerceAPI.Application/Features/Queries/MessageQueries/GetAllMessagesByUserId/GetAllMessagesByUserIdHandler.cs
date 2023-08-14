using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.MessageQueries.GetAllMessagesByUserId
{
    public class GetAllMessagesByUserIdHandler : IRequestHandler<GetAllMessagesByUserIdRequest, List<GetAllMessagesByUserIdResponse>>
    {
        readonly IServiceManager _serviceManager;

        public GetAllMessagesByUserIdHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<List<GetAllMessagesByUserIdResponse>> Handle(GetAllMessagesByUserIdRequest request, CancellationToken cancellationToken)
        {
           return (await _serviceManager.MessageService.GetAllMessagesByUserNameAsync()).Select(x => new GetAllMessagesByUserIdResponse() { Id=x.Id,Body=x.Body,Subject=x.Subject}).ToList(); 
        }
    }
}
