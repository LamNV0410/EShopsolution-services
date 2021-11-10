using EshopSolution.Extensions.BaseEntity;
using System;

namespace SystemService.Domain.DomainModel
{
    public class Avatar : BaseEntity
    {
        public Avatar()
        {

        }
        public Avatar(Guid userId)
        {
            this.CreatedBy = userId;
        }
        public string Url { get; set; }
        public Guid UserId { get; set; }
    }
}
