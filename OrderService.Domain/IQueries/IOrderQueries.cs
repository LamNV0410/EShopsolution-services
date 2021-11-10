using EshopSolution.Extensions.BaseAPI;
using OrderService.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.IQueries
{
    public interface IOrderQueries
    {
        Task<IPaginatorResponse<Order>> GetAllAsync(string keyword, string sortBy, string sortDirection, int pageIndex, int pageSize);
    }
}
