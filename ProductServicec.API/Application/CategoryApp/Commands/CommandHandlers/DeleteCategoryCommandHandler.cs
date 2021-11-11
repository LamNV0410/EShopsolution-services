using CLSK12.BaseService.Services.IdentityService;
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
        private readonly IIdentityService _identityService;
        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IIdentityService identityService
            )
        {
            _categoryRepository = categoryRepository;
            _identityService = identityService;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _identityService.GetUserIdentity();
            Category category =await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest,
                    EshopMessages.GetMessage(new string[] { " Category " }, EshopMessages.NOT_FOUND_MESSAGE), null);
            }
            category.Deactive(currentUser.Id);
            _categoryRepository.Update(category);
            await _categoryRepository.BaseRepository.SaveChangesAsync();

            return true;
        }
    }
}
