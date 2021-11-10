using EshopSolution.Extensions.BaseDbContext;
using System;

namespace EshopSolution.Extensions.BaseEntity
{
    public abstract class BaseEntity : IAggregateRoot
    {
        /// <summary>
        /// Identify 
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Date created
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Created by
        /// </summary>
        public Guid CreatedBy { get; protected set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime? UpdatedDate { get; protected set; }

        /// <summary>
        /// Updated by
        /// </summary>
        public Guid? UpdatedBy { get; protected set; }

        /// <summary>
        /// isactive or isDelete
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// deactive / delete Entity
        /// </summary>
        public virtual void Deactive()
        {
            this.IsActive = false;
        }

        /// <summary>
        /// active Entity
        /// </summary>
        public virtual void Active()
        {
            this.IsActive = false;
        }
    }
}
