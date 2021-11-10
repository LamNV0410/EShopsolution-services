using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.CategoryApp
{
    /// <summary>
    /// Category table
    /// </summary>
    public class Category : BaseEntity
    {
        #region PROPERTIES
        /// <summary>
        /// Name Product
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Information product
        /// </summary>
        public string Description { get; private set; }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor
        /// </summary>
        public Category()
        {
            this.IsActive = true;
        }

        /// <summary>
        /// parrameter constructor / Create
        /// </summary>
        /// <param name="name">category name</param>
        /// <param name="decription">category decription</param>
        /// <param name="userId">userId create</param>
        public Category(string name, string decription, Guid userId)
        {
            this.Name = name;
            this.Description = decription;
            this.CreatedDate = EshopHelper.GetDateTimeNow();
            this.CreatedBy = userId;
            this.UpdatedDate = null;
            this.UpdatedBy = null;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="name"> name update </param>
        /// <param name="decription">decription update </param>
        /// <param name="userId">user created </param>
        public void Update(string name, string decription, Guid userId)
        {
            this.Name = name;
            this.Description = decription;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
            this.UpdatedBy = userId;
        }
        #endregion
    }
}
