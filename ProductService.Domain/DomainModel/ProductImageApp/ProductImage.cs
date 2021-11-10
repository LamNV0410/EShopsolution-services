using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.ProductImageApp
{
    /// <summary>
    /// images product
    /// </summary>
    public class ProductImage : BaseEntity
    {
        #region PROPERTIES
        /// <summary>
        /// Name image
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Folder file Id image
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Decription image
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public Guid ProductId { get; set; }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// default constructor
        /// </summary>
        public ProductImage()
        {
            this.CreatedDate = EshopHelper.GetDateTimeNow();
        }

        /// <summary>
        /// parameter constructor / create ProductImage
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="fileId">fileId</param>
        /// <param name="description">description</param>
        /// <param name="userId">userId</param>
        public ProductImage(Guid productId,string name, string fileId, string description, Guid userId)
        {
            this.Name = name;
            this.FileId = fileId;
            this.Description = description;
            this.CreatedBy = userId;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// update ProductImage
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="fileId">fileId</param>
        /// <param name="description">description</param>
        /// <param name="userId">userId</param>
        public void Update(string name, string fileId, string description, Guid userId)
        {
            this.Name = name;
            this.FileId = fileId;
            this.Description = description;
            this.UpdatedBy = userId;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
        }

        #endregion
    }
}
