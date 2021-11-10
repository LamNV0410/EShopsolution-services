using MediatR;
using ProductService.API.Application.CommonRequestModels;
using System;
using System.Collections.Generic;

namespace ProductService.API.Application.ProductsApp.Commands.CommandModels
{
    public class UpdateProductcommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> SizeIds { get; set; }
        public Guid DiscountId { get; set; }
        public List<ProductImageRequest> Images{ get; set; }
    }
}
