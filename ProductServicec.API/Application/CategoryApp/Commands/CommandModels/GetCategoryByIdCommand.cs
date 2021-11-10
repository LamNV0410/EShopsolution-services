using MediatR;
using ProductService.Domain.DTOs;
using System;

namespace ProductService.API.Application.CategoryApp.Commands.CommandModels
{
    public class GetCategoryByIdCommand : IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }
    }
}
