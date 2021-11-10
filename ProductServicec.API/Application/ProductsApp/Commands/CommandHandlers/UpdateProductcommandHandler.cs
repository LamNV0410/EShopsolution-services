using EshopSolution.Extensions.Constants;
using EshopSolution.Extensions.Exceptions;
using MediatR;
using ProductService.API.Application.ProductsApp.Commands.CommandModels;
using ProductService.Domain.DomainModel.ProductImageApp;
using ProductService.Domain.DTOs;
using ProductService.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.ProductsApp.Commands.CommandHandlers
{
    public class UpdateProductcommandHandler : IRequestHandler<UpdateProductcommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        public UpdateProductcommandHandler(IProductRepository productRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }
        public async Task<bool> Handle(UpdateProductcommand request, CancellationToken cancellationToken)
        {
            // find product in db
            var product = _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest,
                    EshopMessages.GetMessage(new string[] { " Product " }, EshopMessages.NOT_FOUND_MESSAGE), null);
            }

            product.Update(request.Name, request.Price, request.Description, request.DiscountId, request.CategoryId, new Guid(), request.Quantity);
            _productRepository.Update(product);
            await _productRepository.BaseRepository.SaveChangesAsync();
            List<ProductImage> productImages = null;
            if (request.Images.Count > 0)
            {
                productImages = new List<ProductImage>();
                foreach (var item in request.Images)
                {
                    ProductImage productImage = new ProductImage(product.Id, "image-product", item.FileId, item.Description, new Guid());
                    productImages.Add(productImage);
                }
            }

            if (productImages != null || productImages.Count > 0)
            {
                _productImageRepository.AddRange(productImages);
            }

            return true;
        }
    }
}
