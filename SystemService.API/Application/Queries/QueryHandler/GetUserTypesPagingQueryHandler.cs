using EshopSolution.Extensions.BaseAPI;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace SystemService.API.Application.Queries.QueryHandler
{
    public class GetUserTypesPagingQueryHandler : IRequestHandler<GetUserTypesPagingQuery, IPaginatorResponse<UserTypeDTO>>
    {
        private readonly IUserTypeQueries _userTypeQueries;
        public GetUserTypesPagingQueryHandler(
            IUserTypeQueries userTypeQueries
            )
        {
            _userTypeQueries = userTypeQueries;
        }
        public async Task<IPaginatorResponse<UserTypeDTO>> Handle(GetUserTypesPagingQuery request, CancellationToken cancellationToken)
        {
            return await _userTypeQueries
                .GetUserTypesPaging(request.Keyword,request.CreatedDate,request.UserCreated,request.PageIndex,request.PageSize,request.SortBy,request.SortDirection);
        }
    }
}
