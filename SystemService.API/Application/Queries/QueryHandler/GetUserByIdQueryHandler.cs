using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace OrderService.API.Application.Queries.QueryHandler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UsersDTO>
    {
        private readonly IUserQueries _userQueries;
        public GetUserByIdQueryHandler(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }
        public async Task<UsersDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UsersDTO user =  
                await _userQueries.GetByIdAsync(request.Id);
            
            return user;
        }
    }
}
