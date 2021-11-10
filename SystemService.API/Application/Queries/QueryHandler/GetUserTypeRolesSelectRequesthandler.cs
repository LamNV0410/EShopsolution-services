using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IQueries;

namespace SystemService.API.Application.Queries.QueryHandler
{
    public class GetUserTypeRolesSelectRequesthandler : IRequestHandler<GetUserTypeRolesSelectRequest, IEnumerable<UserTypeRole>>
    {
        private readonly IUserTypeQueries _userTypeQueries;
        public GetUserTypeRolesSelectRequesthandler(
            IUserTypeQueries userTypeQueries
            )
        {
            _userTypeQueries = userTypeQueries;
        }
        public async Task<IEnumerable<UserTypeRole>> Handle(GetUserTypeRolesSelectRequest request, CancellationToken cancellationToken)
        {
            return await _userTypeQueries.GetUserTypeRolesSelect();
        }
    }
}
