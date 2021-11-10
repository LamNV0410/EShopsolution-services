using EshopSolution.Extensions.BaseDbContext;
using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.Product_SizeApp
{
    /// <summary>
    /// Sizes of Prduct Table
    /// </summary>
    public class ProductSize : BaseEntity, IAggregateRoot
    {
        #region PROPERTIES

        /// <summary>
        /// Id product
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Size Id
        /// </summary>
        public Guid SizeId { get; private set; }

        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// default constructor
        /// </summary>
        public ProductSize()
        {
            this.CreatedDate = EshopHelper.GetDateTimeNow();
            this.IsActive = false;
        }

        /// <summary>
        /// parameter constructor
        /// </summary>
        /// <param name="productId">productId</param>
        /// <param name="sizeId">sizeId</param>
        /// <param name="userId">userId</param>
        public ProductSize(Guid productId, Guid sizeId, Guid userId)
        {
            this.ProductId = productId;
            this.SizeId = sizeId;
            this.CreatedBy = userId;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update ProductSize
        /// </summary>
        /// <param name="productId">productId</param>
        /// <param name="sizeId">sizeId</param>
        /// <param name="userId">userId</param>
        public void Update(Guid productId, Guid sizeId, Guid userId)
        {
            this.ProductId = productId;
            this.SizeId = sizeId;
            this.UpdatedBy = userId;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
        }

        #endregion
    }
}
