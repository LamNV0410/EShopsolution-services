using EshopSolution.Extensions.BaseAPI;
using MediatR;
using OrderService.Domain.DomainModel;

namespace OrderService.API.Application.Queries.QueryModels
{
    public class GetOrdersQuery : PaginatorRequest, IRequest<IPaginatorResponse<Order>>
    {
        public string Keyword { get; set; }
    }
}
