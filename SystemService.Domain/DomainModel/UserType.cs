using EshopSolution.Extensions.BaseEntity;
using System;

namespace SystemService.Domain.DomainModel
{
    public class UserType : BaseEntity
    {
        public string TypeName { get; private set; }
        public int Level { get; private set; }
        public Guid UserTypeRoleId { get; set; }
        public UserType()
        {

        }
        public UserType(
            string typeName,
            Guid userId,
            Guid userTypeRoleId
            )
        {
            TypeName = typeName;
            CreatedBy = userId;
            UserTypeRoleId = userTypeRoleId;
            CreatedDate = DateTime.UtcNow;
            base.Active(userId);
        }

        public void Update(string typeName,Guid userTypeRoleId, Guid updateBy)
        {
            this.TypeName = typeName;
            this.UserTypeRoleId = userTypeRoleId;
            this.UpdatedBy = updateBy;
            this.UpdatedDate = DateTime.UtcNow;
        }

        public void Delete()
        {
            this.IsActive = false;
        }
    }
}
