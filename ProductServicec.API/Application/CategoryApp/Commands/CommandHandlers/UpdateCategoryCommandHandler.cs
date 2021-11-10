using EshopSolution.Extensions.Constants;
using EshopSolution.Extensions.Exceptions;
using MediatR;
using ProductService.API.Application.CategoryApp.Commands.CommandModels;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.IRepositories;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.CategoryApp.Commands.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest,
                    EshopMessages.GetMessage(new string[] { " Category " }, EshopMessages.NOT_FOUND_MESSAGE), null);
            }

            category.Update(request.Name, request.Description, new Guid());
            _categoryRepository.Update(category);
            await _categoryRepository.BaseRepository.SaveChangesAsync();
            return true;
        }
    }
}
