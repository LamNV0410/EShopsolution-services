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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // find product in db
            var product =  _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest,
                    EshopMessages.GetMessage(new string[] { " Product " }, EshopMessages.NOT_FOUND_MESSAGE), null);
            }
            product.Deactive();
            await _productRepository.BaseRepository.SaveChangesAsync();
            return true;
        }
    }
}
