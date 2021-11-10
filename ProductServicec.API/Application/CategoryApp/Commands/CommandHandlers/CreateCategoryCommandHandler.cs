using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.API.Application.CategoryApp.Commands.CommandModels;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.DTOs;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.Repositoies;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.CategoryApp.Commands.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IScopeClass _context;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IScopeClass context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }
        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var userId = new System.Guid();
            Category category = new Category(request.Name, request.Description, userId);

            var context = _context.Context;
            var strategy = context.Database.CreateExecutionStrategy();
            Category categoryCreated = null;
            //await strategy.ExecuteAsync(async () =>
            //{
            //    using (var scope = await context.Database.BeginTransactionAsync())
            //    {
            //        categoryCreated = _categoryRepository.Create(category);


            //    }
            //});

            try
            {
                categoryCreated = _categoryRepository.Create(category);
                await _categoryRepository.BaseRepository.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw;
            }

            return new CategoryDTO().From(categoryCreated);
        }
    }
}
