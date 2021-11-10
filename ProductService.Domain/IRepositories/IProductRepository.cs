using EshopSolution.Extensions.BaseDbContext;
using ProductService.Domain.DomainModel.ProductApp;
using System;
using System.Threading.Tasks;

namespace ProductService.Domain.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Create(Product entity);
        Product GetByIdAsync(Guid id);
        void Update(Product entity);
    }
}
