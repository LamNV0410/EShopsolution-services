using MediatR;
using System;
using SystemService.Domain.DTOs;

namespace SystemService.API.Application.Queries.QueryModels
{
    public class GetUserTypeByIdQuery : IRequest<UserTypeDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetUsersByIdResponse
    {

    }
}
