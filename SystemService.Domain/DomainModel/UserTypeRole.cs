using EshopSolution.Extensions.BaseEntity;

namespace SystemService.Domain.DomainModel
{
    public class UserTypeRole : BaseEntity
    {
        public string UserTypeRoleName { get; set; }
        public string UserTypeRoleCode { get; set; }
    }
}
