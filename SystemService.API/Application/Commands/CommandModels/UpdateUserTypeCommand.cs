using MediatR;
using System;
using SystemService.Domain.DomainModel;

namespace SystemService.API.Application.Commands.CommandModels
{
    public class UpdateUserTypeCommand :IRequest<UserType>
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public Guid UserTypeRoleId { get; set; }
    }
}
