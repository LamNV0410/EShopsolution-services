using EshopSolution.Extensions.BaseAPI;
using MediatR;
using System;
using SystemService.Domain.DTOs;

namespace SystemService.API.Application.Queries.QueryModels
{
    public class GetUsersPagingQuery : PaginatorRequest, IRequest<IPaginatorResponse<UsersDTO>>
    {
        public string Keyword { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserCreated { get; set; }
    }
}
