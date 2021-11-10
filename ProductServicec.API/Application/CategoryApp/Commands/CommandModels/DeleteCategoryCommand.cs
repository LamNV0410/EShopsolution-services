using MediatR;
using System;

namespace ProductService.API.Application.CategoryApp.Commands.CommandModels
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        /// <summary>
        /// Id Delete
        /// </summary>
        public Guid Id { get; set; }
    }
}
