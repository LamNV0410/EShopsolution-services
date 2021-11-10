using MediatR;
using System;
using SystemService.Domain.DomainModel;

namespace SystemService.API.Application.Commands.CommandModels
{
    public class CreateUserTypecommand : IRequest<UserType>
    {
        public string Name { get; set; }
        public Guid UserTypeRoleId { get; set; }
    }
}
