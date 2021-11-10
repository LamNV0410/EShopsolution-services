using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.ProductApp
{
    /// <summary>
    /// Product table
    /// </summary>
    public class Product : BaseEntity
    {
        #region PROPERTIES
        /// <summary>
        /// Name Product
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Price Product
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Information product
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Discount Id => reference to Discount table
        /// </summary>
        public Guid? DiscountId { get; private set; }

        /// <summary>
        /// Category => reference to Category Table
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Quantity product
        /// </summary>
        public int Quantity { get; private set; }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// default constructor
        /// </summary>
        public Product()
        {
            this.CreatedDate = EshopHelper.GetDateTimeNow();
        }

        /// <summary>
        /// parameter constructor/ create 
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="price">price</param>
        /// <param name="description">description</param>
        /// <param name="discountId">discountId</param>
        /// <param name="sizeId">sizeId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="userId">userId</param>
        public Product(string name,
            double price,
            string description,
            Guid? discountId,
            Guid categoryId,
            Guid userId,
            int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.DiscountId = discountId;
            this.CategoryId = categoryId;
            this.CreatedBy = userId;
            this.Quantity = quantity;
        }
        #endregion

        #region METHODS

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="price">price</param>
        /// <param name="description">description</param>
        /// <param name="discountId">discountId</param>
        /// <param name="sizeId">sizeId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="userId">userId</param>
        public void Update(string name,
            double price,
            string description,
            Guid? discountId,
            Guid categoryId,
            Guid userId,
            int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.DiscountId = discountId;
            this.CategoryId = categoryId;
            this.Quantity = quantity;
            this.UpdatedBy = userId;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
        }

        #endregion
    }
}