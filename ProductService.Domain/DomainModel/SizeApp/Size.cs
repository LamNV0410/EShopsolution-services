using EshopSolution.Extensions.BaseEntity;
using EshopSolution.Extensions.EshopHelper;
using System;

namespace ProductService.Domain.DomainModel.SizeApp
{
    /// <summary>
    /// Size table
    /// </summary>
    public class Size : BaseEntity
    {
        #region PROPERTIES
        /// <summary>
        /// Name size
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// decription size
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// code size
        /// </summary>
        public string Code { get; private set; }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// default constructor
        /// </summary>
        public Size()
        {
            this.CreatedDate = EshopHelper.GetDateTimeNow();
        }

        /// <summary>
        /// parameter constructor / create entity
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="code">code</param>
        public Size(string name,string description,string code,Guid userId)
        {
            this.Name = name;
            this.Description = description;
            this.Code = code;
            this.CreatedBy = userId;
        }
        #endregion

        #region METHODS

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="code">code</param>
        public void Update(string name, string description, string code, Guid userId)
        {
            this.Name = name;
            this.Description = description;
            this.Code = code;
            this.UpdatedBy = userId;
            this.UpdatedDate = EshopHelper.GetDateTimeNow();
        }
        #endregion
    }
}
