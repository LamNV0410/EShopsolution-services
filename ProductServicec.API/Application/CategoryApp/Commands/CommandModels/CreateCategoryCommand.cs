using MediatR;
using ProductService.Domain.DTOs;
using System;

namespace ProductService.API.Application.CategoryApp.Commands.CommandModels
{
    public class CreateCategoryCommand : IRequest<CategoryDTO>
    {
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
