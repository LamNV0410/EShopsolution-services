using EshopSolution.Extensions.BaseAPI;
using ProductService.Domain.DomainModel.CategoryApp;
using System.Threading.Tasks;

namespace ProductService.Domain.IQueries
{
    public interface ICategoriesQueries
    {
        Task<IPaginatorResponse<Category>> GetAll(string keyword, string sortBy, string sortDirection, int pageIndex, int pageSize);
    }
}
