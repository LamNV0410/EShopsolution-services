using EshopSolution.Extensions.BaseAPI;
using MediatR;
using OrderService.API.Application.Queries.QueryModels;
using OrderService.Domain.DomainModel;
using OrderService.Domain.IQueries;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.API.Application.Queries.QueryHandler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IPaginatorResponse<Order>>
    {
        private readonly IOrderQueries _orderQueries;
        public GetOrdersQueryHandler(IOrderQueries orderQueries)
        {
            _orderQueries = orderQueries;
        }
        public async Task<IPaginatorResponse<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            IPaginatorResponse<Order> orders =  await _orderQueries.GetAllAsync(request.Keyword, request.SortBy, request.SortDirection, request.PageIndex, request.PageSize);
            
            return orders;
        }
    }
}
