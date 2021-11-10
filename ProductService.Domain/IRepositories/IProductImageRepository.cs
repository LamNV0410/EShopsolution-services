using EshopSolution.Extensions.BaseDbContext;
using ProductService.Domain.DomainModel.ProductImageApp;
using System.Collections.Generic;

namespace ProductService.Domain.IRepositories
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        void AddRange(List<ProductImage> entities);
    }
}
