using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Exceptions;
using EshopSolution.Extensions.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SystemService.API.Application.Commands.CommandModels;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;

namespace SystemService.API.Application.Commands.CommandHandlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        public EditUserCommandHandler(
            IUserRepository userRepository,
            IIdentityService identityService
            )
        {
            _userRepository = userRepository;
            _identityService = identityService;
        }
        public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user != null)
            {
                user.Update(
                request.UserName,
                request.FirstName,
                request.LastName,
                request.Address,
                request.PhoneNumber,
                request.Gender,
                request.UserTypeId,
                request.Email,
                currentUser.Id,
                true
                );

                if (!string.IsNullOrEmpty(request.Password))
                {
                    var passwordHasher = new SHA256Hasher().Create(request.Password);

                    user.UpdatePassword(passwordHasher.PasswordHashed, passwordHasher.Salt);
                }

                var userUpdated = _userRepository.Update(user);
                await _userRepository.BaseRepository.SaveChangesAsync();
                return userUpdated;
            }
            else
            {
                throw new HttpStatusException(System.Net.HttpStatusCode.BadRequest, "User not Found !! ", null);
            }
        }
    }
}
