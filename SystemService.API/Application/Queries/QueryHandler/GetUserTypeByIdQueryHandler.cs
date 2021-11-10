using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Queries.QueryModels;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace OrderService.API.Application.Queries.QueryHandler
{
    public class GetUserTypeByIdQueryHandler : IRequestHandler<GetUserTypeByIdQuery, UserTypeDTO>
    {
        private readonly IUserTypeQueries _userTypeQueries;
        public GetUserTypeByIdQueryHandler(IUserTypeQueries userTypeQueries)
        {
            _userTypeQueries = userTypeQueries;
        }
        public async Task<UserTypeDTO> Handle(GetUserTypeByIdQuery request, CancellationToken cancellationToken)
        {
            UserTypeDTO user =  
                await _userTypeQueries.GetById(request.Id);
            
            return user;
        }
    }
}
