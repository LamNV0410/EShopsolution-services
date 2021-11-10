using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.DiscountApp
{
    /// <summary>
    /// Discount table
    /// </summary>
    public class Discount : BaseEntity
    {
        #region PROPERTIES

        /// <summary>
        /// decription Discount
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// code Discount
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Discount Price
        /// </summary>
        public double DiscountPrice { get; private set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// defaut constructor
        /// </summary>
        public Discount()
        {
            this.IsActive = false;
            this.CreatedDate = EshopHelper.GetDateTimeNow();
            this.UpdatedDate = null;
            this.UpdatedBy = null;
        }

        /// <summary>
        /// parameter constructor / create Discount
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="code"> code discount </param>
        /// <param name="discountPrice"> price discount </param>
        /// <param name="userId"> userId create</param>
        public Discount(string description, string code, double discountPrice, Guid userId)
        {
            this.Description = description;
            this.Code = code;
            this.DiscountPrice = discountPrice;
            this.CreatedBy = userId;
            
        }

        /// <summary>
        /// Update discount
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="code"> code discount </param>
        /// <param name="discountPrice"> price discount </param>
        /// <param name="userId"> userId create</param>
        public void Update(string description, string code, double discountPrice,Guid userId)
        {
            this.Description = description;
            this.Code = code;
            this.DiscountPrice = discountPrice;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
        }
        #endregion
    }
}
