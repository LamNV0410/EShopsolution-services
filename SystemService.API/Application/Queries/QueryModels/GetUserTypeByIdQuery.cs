using MediatR;
using System;
using SystemService.Domain.DTOs;

namespace SystemService.API.Application.Queries.QueryModels
{
    public class GetUserByIdQuery : IRequest<UsersDTO>
    {
        public Guid Id { get; set; }
    }
}
