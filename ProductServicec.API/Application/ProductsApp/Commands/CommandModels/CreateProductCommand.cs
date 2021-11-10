using MediatR;
using ProductService.Domain.DomainModel.ProductImageApp;
using ProductService.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace ProductService.API.Application.ProductsApp.Commands.CommandModels
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> SizeIds { get; set; }
        public Guid DiscountId { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
