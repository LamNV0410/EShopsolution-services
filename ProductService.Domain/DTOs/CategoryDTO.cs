using EshopSolution.Extensions.BaseEntity;
using ProductService.Domain.DomainModel.CategoryApp;
using System;

namespace ProductService.Domain.DTOs
{
    public class CategoryDTO
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

        public CategoryDTO From(Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedDate = category.CreatedDate,
                CreatedBy = category.CreatedBy,
                UpdatedDate = category.UpdatedDate,
                UpdatedBy = category.UpdatedBy,
                IsActive = category.IsActive,
            };
        }
    }
}
