using EshopSolution.Extensions.BaseEntity;
using System;

namespace OrderService.Domain.DomainModel
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get;private set; }
        public Guid ProductId { get; set; }
    }
}
