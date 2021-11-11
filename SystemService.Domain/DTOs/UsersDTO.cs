using EshopSolution.Extensions.BaseEntity;
using System;

namespace SystemService.Domain.DTOs
{
    public class UsersDTO : BaseEntity
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public byte Gender { get; private set; }
        public Guid userTypeId { get; private set; }
        public Guid UserTypeRoleName { get; private set; }

        public string Email { get; private set; }

        public string UserTypeName { get; set; }
        public string UserTypeLevel { get; set; }
        public string FullName => this.LastName + " " + this.FirstName;
    }
}
