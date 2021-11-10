using Microsoft.EntityFrameworkCore;
using ProductService.Domain.DomainModel.ProductApp;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.DBContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositoies
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public EshopSolution.Extensions.BaseDbContext.IBaseRepository BaseRepository => _context;

        public Product Create(Product entity)
        {
            return _context.Add(entity).Entity;
        }

        public Product GetByIdAsync(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
