using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.Domain.IRepositories;

namespace SystemService.API.Application.Commands.CommandHandlers
{
    public class DeleteUserTypeCommandHandler : IRequestHandler<DeleteUserTypeCommand, bool>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IIdentityService _identityService;
        public DeleteUserTypeCommandHandler(
            IUserTypeRepository userTypeRepository,
            IIdentityService identityService
            )
        {
            _userTypeRepository = userTypeRepository;
            _identityService = identityService;
        }
        public async Task<bool> Handle(DeleteUserTypeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            var userDelete = await _userTypeRepository.GetByIdAsync(request.Id);
            if(userDelete != null)
            {
                userDelete.Deactive(currentUser.Id);
                _userTypeRepository.Update(userDelete);
               return await _userTypeRepository.BaseRepository.SaveEntitiesAsync();
            }
            else
            {
                throw new HttpStatusException(System.Net.HttpStatusCode.BadRequest, "UserType not found!!", null);
            }
        }
    }
}
