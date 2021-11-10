using EshopSolution.Extensions.BaseAPI;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace OrderService.API.Application.Queries.QueryHandler
{
    public class GetUserPagingQueryHandler : IRequestHandler<GetUsersPagingQuery, IPaginatorResponse<UsersDTO>>
    {
        private readonly IUserQueries _userQueries;
        public GetUserPagingQueryHandler(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }
        public async Task<IPaginatorResponse<UsersDTO>> Handle(GetUsersPagingQuery request, CancellationToken cancellationToken)
        {
            return
                await _userQueries
                .GetUsersPaging(
                    request.Keyword,
                    request.CreatedDate,
                    request.UserCreated,
                    request.PageIndex,
                    request.PageSize,
                     request.SortBy,
                    request.SortDirection,
                    true
                    );
        }
    }
}
