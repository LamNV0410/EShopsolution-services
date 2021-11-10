using ProductService.Domain.DomainModel.ProductImageApp;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.DBContext;
using System.Collections.Generic;

namespace ProductService.Infrastructure.Repositoies
{
    public class ProductImageRepository : IProductImageRepository
    {
        private ProductDbContext _context;
        public ProductImageRepository(ProductDbContext context)
        {
            _context = context;
        }
        public EshopSolution.Extensions.BaseDbContext.IBaseRepository BaseRepository => _context;

        public void AddRange(List<ProductImage> entities)
        {
            _context.AddRange(entities);
        }
    }
}
