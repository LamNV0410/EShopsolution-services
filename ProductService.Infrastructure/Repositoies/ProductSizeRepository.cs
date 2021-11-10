using ProductService.Domain.DomainModel.Product_SizeApp;
using ProductService.Domain.IRepositories;
using ProductService.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositoies
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly ProductDbContext _context;
        public ProductSizeRepository(ProductDbContext context)
        {
            _context = context;
        }
        public EshopSolution.Extensions.BaseDbContext.IBaseRepository BaseRepository => _context;

        public async Task AddRangeAsync(List<ProductSize> entities)
        {
            await _context.AddRangeAsync(entities);
        }
    }
}
