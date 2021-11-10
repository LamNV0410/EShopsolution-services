using EshopSolution.Extensions.BaseEntity;
using System;

namespace ProductService.Domain.DomainModel.Product_DiscountApp
{
    /// <summary>
    /// Product - Discount table
    /// </summary>
    public class ProductDiscount : BaseEntity
    {
        #region PROPERTIES
        /// <summary>
        /// Indentify product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Indentify discount
        /// </summary>
        public Guid DiscountId { get; set; }
        #endregion

        #region CONSTRUCTORS
        public ProductDiscount()
        {

        }

        public ProductDiscount(Guid productId, Guid discountId)
        {

        }
        #endregion
        #region METHODS
        public void Update(Guid productId,Guid discountId)
        {
            this.ProductId = productId;
            this.DiscountId = discountId;
        }

        #endregion
    }
}
