using MediatR;
using System;

namespace ProductService.API.Application.CategoryApp.Commands.CommandModels
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        /// <summary>
        /// Id edit
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name create
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description create
        /// </summary>
        public string Description { get; set; }
    }
}
