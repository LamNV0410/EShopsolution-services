using EshopSolution.Extensions.BaseAPI;
using ProductService.Domain.DomainModel.ProductApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.IQueries
{
    public interface IProductQueries
    {
        Task<IPaginatorResponse<Product>> GetProducts(string keyword, string sortBy, string sortDirection, int pageIndex, int pageSize);
    }
}
