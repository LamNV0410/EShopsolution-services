using CLSK12.BaseService.Services.IdentityService;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;

namespace SystemService.API.Application.Commands.CommandHandlers
{
    public class CreateUserTypecommandHandler : IRequestHandler<CreateUserTypecommand, UserType>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IIdentityService _identityService;
        public CreateUserTypecommandHandler(
            IUserTypeRepository userTypeRepository,
            IIdentityService identityService
            )
        {
            _userTypeRepository = userTypeRepository;
            _identityService = identityService;
        }
        public async Task<UserType> Handle(CreateUserTypecommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            Guid? userId = null;
            if(currentUser != null)
            {
                userId = currentUser.Id;
            }
            UserType userType = new UserType(
                request.Name,
                userId ?? new Guid(),
                request.UserTypeRoleId
                );
            UserType result = _userTypeRepository.Create(userType);
            await _userTypeRepository.BaseRepository.SaveChangesAsync();
            return result;
        }
    }
}
