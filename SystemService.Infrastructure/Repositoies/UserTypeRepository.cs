using EshopSolution.Extensions.BaseDbContext;
using System;
using System.Threading.Tasks;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;
using SystemService.Infrastructure.DBContext;

namespace SystemService.Infrastructure.Repositoies
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly SystemDBContext _context;
        public UserTypeRepository(SystemDBContext context)
        {
            _context = context;
        }
        public IBaseRepository BaseRepository => _context;

        public UserType Create(UserType entity)
        {
            return _context.Add(entity).Entity;
        }

        public UserType GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserType> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserType entity)
        {
            throw new NotImplementedException();
        }

        public UserType Update(UserType entity)
        {
            throw new NotImplementedException();
        }
    }
}
