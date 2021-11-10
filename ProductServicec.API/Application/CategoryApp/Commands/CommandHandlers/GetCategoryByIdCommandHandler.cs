using MediatR;
using ProductService.API.Application.CategoryApp.Commands.CommandModels;
using ProductService.Domain.DTOs;
using ProductService.Domain.IRepositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.CategoryApp.Commands.CommandHandlers
{
    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDTO> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetByIdAsync(request.Id);
            return new CategoryDTO().From(result);
        }
    }
}
