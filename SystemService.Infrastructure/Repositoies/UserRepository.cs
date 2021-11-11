using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;
using SystemService.Infrastructure.DBContext;

namespace SystemService.Infrastructure.Repositoies
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDBContext _context;
        public UserRepository(SystemDBContext context)
        {
            _context = context;
        }
        public IBaseRepository BaseRepository => _context;

        public User Create(User entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
        }

        public User Update(User entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }
    }
}
