using EshopSolution.Extensions.BaseAPI;
using MediatR;
using OrderService.Domain.DomainModel;
using System;

namespace OrderService.API.Application.Queries.QueryModels
{
    public class GetOrdersByUserIdQuery : PaginatorRequest, IRequest<Order>
    {
        public Guid UserId { get; set; }
        public string Keyword { get; set; }
    }
}
