using EshopSolution.Extensions.BaseDbContext;
using ProductService.Domain.DomainModel.Product_SizeApp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Domain.IRepositories
{
    public interface IProductSizeRepository : IRepository<ProductSize>
    {
        Task AddRangeAsync(List<ProductSize> entities);
    }
}
