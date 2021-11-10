using Microsoft.EntityFrameworkCore;
using OrderService.Domain.DomainModel;
using OrderService.Domain.IRepositories.IGraphQL;
using OrderService.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositoies.GraphQL
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrderDBContext _context;
        public OrdersRepository(OrderDBContext context)
        {
            _context = context;
        }

        public EshopSolution.Extensions.BaseDbContext.IBaseRepository BaseRepository => _context;

        public Order CreateOrder(Order order)
        {
            _context.Add(order);
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrderDetail>> GetOrderDetailByOrderId(Guid id)
        {
            return await _context.OrderDetails.Where(x => x.OrderId == id).ToListAsync();
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            return await _context.Orders.ToArrayAsync();
        }
    }
}
