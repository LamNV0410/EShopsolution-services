using EshopSolution.Extensions.BaseEntity;
using System;

namespace SystemService.Domain.DomainModel
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public byte Gender { get; private set; }
        public string Password { get;private set; }
        public string Salt { get; private set; }
        public Guid UserTypeId { get; private set; }
        public string Email { get; private set; }

        public User()
        {

        }
        public User(
            string userName,
            string firstName,
            string lastName,
            string address,
            string phoneNumber,
            string password,
            string salt,
            Guid role,
            string email,
            Guid createdBy,
            bool isActive) : base()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Password = password;
            Salt = salt;
            UserTypeId = role;
            Email = email;
            IsActive = isActive;
            CreatedBy = createdBy;
            CreatedDate = DateTime.UtcNow;
            base.Active();
        }
    }
}
