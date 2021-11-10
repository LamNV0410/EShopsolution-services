using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.API.Application.ProductsApp.Commands.CommandModels;
using ProductService.Domain.DomainModel.Product_SizeApp;
using ProductService.Domain.DomainModel.ProductApp;
using ProductService.Domain.DomainModel.ProductImageApp;
using ProductService.Domain.DTOs;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.Repositoies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.ProductsApp.Commands.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IScopeClass _context;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductImageRepository _productImageRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, 
            IScopeClass context, 
            IProductSizeRepository productSizeRepository,
            IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
            _context = context;
            _productImageRepository = productImageRepository;
        }
        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Create product
            Product product
                = new Product(
                request.Name,
                request.Price,
                request.Description,
                request.DiscountId,
                request.CategoryId,
                new Guid(),
                request.Quantity);
            List<ProductImage> images = new List<ProductImage>();
            
            var scope = _context.Context;
            var strategy = scope.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await scope.Database.BeginTransactionAsync())
                {
                    try
                    {

                        Product productCreated = _productRepository.Create(product);
                        await _productRepository.BaseRepository.SaveChangesAsync();

                        // Create Product Size
                        if (request.SizeIds != null && request.SizeIds.Count > 0)
                        {
                            List<ProductSize> productSizes = new List<ProductSize>();
                            request.SizeIds.ForEach((sizeId) =>
                            {
                                productSizes.Add(new ProductSize(productCreated.Id, sizeId, new Guid()));
                            });

                            await _productSizeRepository.AddRangeAsync(productSizes);
                            await _productSizeRepository.BaseRepository.SaveChangesAsync();
                        }

                        if (request.Images != null || request.Images.Count > 0)
                        {
                            request.Images.ForEach((imageRequest) => {
                                images.Add(new ProductImage(productCreated.Id,imageRequest.Name, imageRequest.FileId, imageRequest.Description, new Guid()));
                            });

                            _productImageRepository.AddRange(images);
                        }

                        await _productRepository.BaseRepository.SaveChangesAsync();
                        throw new Exception();
                        await transaction.CommitAsync();

                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            });

            return new ProductDTO().From(product);
        }
    }
}
