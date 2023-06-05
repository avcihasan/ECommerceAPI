﻿using MediatR;

namespace ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryRequest:IRequest<GetAllOrdersQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}