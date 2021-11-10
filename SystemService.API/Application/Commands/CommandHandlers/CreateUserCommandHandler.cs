using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;

namespace SystemService.API.Application.Commands.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IIdentityService identityService
            )
        {
            _userRepository = userRepository;
            _identityService = identityService;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            var passwordHasher = new SHA256Hasher().Create(request.Password);
            User user = new User(
                request.UserName,
                request.FirstName,
                request.LastName,
                request.Address,
                request.PhoneNumber,
                passwordHasher.PasswordHashed,
                passwordHasher.Salt,
                request.TypeRoleId,
                request.Email,
                currentUser.Id,
                true
                );

            User userCreated = _userRepository.Create(user);
            await _userRepository.BaseRepository.SaveEntitiesAsync();
            if (!string.IsNullOrEmpty(request.AvatarUrl))
            {
                Avatar avatar = new Avatar(currentUser.Id);
                avatar.Url = request.AvatarUrl;
                avatar.UserId = userCreated.Id;
                await _userRepository.BaseRepository.SaveEntitiesAsync();
            }

            return userCreated;
        }
    }
}
