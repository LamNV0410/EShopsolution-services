using MediatR;
using System.Collections.Generic;
using SystemService.Domain.DomainModel;

namespace SystemService.API.Application.Queries.QueryModels
{
    public class GetUserTypesSelectRequest : IRequest<IEnumerable<UserType>>
    {
    }
}
