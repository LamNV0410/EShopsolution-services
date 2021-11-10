using EshopSolution.Extensions.BaseDbContext;
using ProductService.Domain.DomainModel.CategoryApp;
using System;
using System.Threading.Tasks;

namespace ProductService.Domain.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByIdAsync(Guid id);
        Category Create(Category entity);
        void Update(Category entiy);
    }
}
