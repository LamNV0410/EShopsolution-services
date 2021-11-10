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
            base.Active();
        }
    }
}
