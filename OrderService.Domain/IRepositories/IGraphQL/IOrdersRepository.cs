using EshopSolution.Extensions.BaseDbContext;
using OrderService.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Domain.IRepositories.IGraphQL
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<Order[]> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<List<OrderDetail>> GetOrderDetailByOrderId(Guid id);
        Order CreateOrder(Order order);
    }
}
