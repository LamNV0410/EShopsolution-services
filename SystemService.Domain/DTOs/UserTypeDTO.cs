using EshopSolution.Extensions.BaseEntity;
using System;

namespace SystemService.Domain.DTOs
{
    public class UserTypeDTO : BaseEntity
    {
        public string TypeName { get; set; }
        public Guid UserTypeRoleId{ get; set; }
        public string UserTypeRoleName { get; set; }

    }
}
