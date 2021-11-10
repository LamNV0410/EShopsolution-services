using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IQueries;

namespace SystemService.API.Application.Queries.QueryHandler
{
    public class GetUserTypeSelectRequestHandler : IRequestHandler<GetUserTypesSelectRequest, IEnumerable<UserType>>
    {
        private readonly IUserTypeQueries _userTypeQueries;
        public GetUserTypeSelectRequestHandler(
            IUserTypeQueries userTypeQueries
            )
        {
            _userTypeQueries = userTypeQueries;
        }
        public async Task<IEnumerable<UserType>> Handle(GetUserTypesSelectRequest request, CancellationToken cancellationToken)
        {
            return await _userTypeQueries.GetUsserTypeSelect();
        }
    }
}
