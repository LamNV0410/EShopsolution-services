using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;

namespace SystemService.API.Application.Commands.CommandHandlers
{
    public class UpdateUserTypeCommandHandler : IRequestHandler<UpdateUserTypeCommand, UserType>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IIdentityService _identityService;
        public UpdateUserTypeCommandHandler(
            IUserTypeRepository userTypeRepository,
            IIdentityService identityService
            )
        {
            _userTypeRepository = userTypeRepository;
            _identityService = identityService;
        }
        public async Task<UserType> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            var userType = await _userTypeRepository.GetByIdAsync(request.Id);
            if(userType != null)
            {
                userType.Update(request.TypeName, request.UserTypeRoleId,currentUser.Id);
                _userTypeRepository.Update(userType);
                await _userTypeRepository.BaseRepository.SaveChangesAsync();

                return userType;
            }
            else
            {
                throw new HttpStatusException(System.Net.HttpStatusCode.BadRequest, "UserType not Found !! ", null);
            }
        }
    }
}
