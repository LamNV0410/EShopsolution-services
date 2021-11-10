using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.DBContext;
using System;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositoies
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _context;

        public EshopSolution.Extensions.BaseDbContext.IBaseRepository BaseRepository => _context;

        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public Category Create(Category entiy)
        {
            return _context.Add(entiy).Entity;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(Category entiy)
        {
            _context.Entry(entiy).State = EntityState.Modified;
        }
    }
}
