using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
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

        public Task<UserType> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserType> GetByIdAsync(Guid id)
        {
            return await _context.UserTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(UserType entity)
        {
            throw new NotImplementedException();
        }

        public UserType Update(UserType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
