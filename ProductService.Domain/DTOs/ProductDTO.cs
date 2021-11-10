using ProductService.Domain.DomainModel.ProductApp;
using System;

namespace ProductService.Domain.DTOs
{
    public class ProductDTO
    {
        /// <summary>
        /// Identify 
        /// </summary>
        public Guid Id { get; set; }

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
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price Product
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Discount Id => reference to Discount table
        /// </summary>
        public Guid? DiscountId { get; private set; }

        /// <summary>
        /// Size => reference to Size Table
        /// </summary>
        public Guid SizeId { get; private set; }

        /// <summary>
        /// Category => reference to Category Table
        /// </summary>
        public Guid CategoryId { get; private set; }

        /// <summary>
        /// Quantity product
        /// </summary>
        public int Quantity { get; private set; }

        public ProductDTO From(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                CreatedDate = product.CreatedDate,
                CreatedBy = product.CreatedBy,
                UpdatedDate = product.UpdatedDate,
                UpdatedBy = product.UpdatedBy,
                IsActive = product.IsActive,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountId = product.DiscountId,
                CategoryId = product.CategoryId,
            };
        }
    }
}
