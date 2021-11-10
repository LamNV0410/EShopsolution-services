using MediatR;
using System;

namespace ProductService.API.Application.ProductsApp.Commands.CommandModels
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
