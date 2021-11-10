using EshopSolution.Extensions.Constants;
using EshopSolution.Extensions.Exceptions;
using MediatR;
using ProductService.API.Application.CategoryApp.Commands.CommandModels;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.IRepositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.CategoryApp.Commands.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category =await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest,
                    EshopMessages.GetMessage(new string[] { " Category " }, EshopMessages.NOT_FOUND_MESSAGE), null);
            }
            category.Deactive();
            _categoryRepository.Update(category);
            await _categoryRepository.BaseRepository.SaveChangesAsync();

            return true;
        }
    }
}
