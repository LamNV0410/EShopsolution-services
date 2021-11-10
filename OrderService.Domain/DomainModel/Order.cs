using EshopSolution.Extensions.BaseEntity;
using System;

namespace OrderService.Domain.DomainModel
{
    public class Order : BaseEntity
    {
        public string Name { get; private set; }

        public Order(string name, bool isActive,Guid createdBy)
        {
            this.Name = name;
            this.IsActive = isActive;
            this.CreatedBy = createdBy;
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
