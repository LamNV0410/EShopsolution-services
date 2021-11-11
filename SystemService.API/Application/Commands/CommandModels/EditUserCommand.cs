using MediatR;
using System;
using SystemService.Domain.DomainModel;

namespace SystemService.API.Application.Commands.CommandModels
{
    public class EditUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public Guid UserTypeId { get; set; }
    }
}
