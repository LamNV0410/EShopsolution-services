using MediatR;
using System.Collections.Generic;
using SystemService.Domain.DomainModel;
using SystemService.Domain.DTOs;

namespace SystemService.API.Application.Queries.QueryModels
{
    public class GetUserTypeRolesSelectRequest : IRequest<IEnumerable<UserTypeRole>>
    {
    }
}
