using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest:IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
