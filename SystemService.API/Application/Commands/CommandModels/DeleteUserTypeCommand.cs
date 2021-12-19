using MediatR;
using System;

namespace SystemService.API.Application.Commands.CommandModels
{
    public class DeleteUserTypeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
